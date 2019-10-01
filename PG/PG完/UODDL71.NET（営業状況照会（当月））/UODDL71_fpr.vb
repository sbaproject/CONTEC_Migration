Option Strict Off
Option Explicit On
Module SSSMAIN0001
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	
	'単プロジェクトごとの共通ライブラリ
	Public PP_SSSMAIN As clsPP
	Public CP_SSSMAIN(1242 + 40 + 0 + 1) As clsCP
	Public CQ_SSSMAIN(82) As String

    '□□□□□□□□ プログラム単位の共通処理 Start □□□□□□□□□□□□□□□□
    'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    'Invalid_string_refer_to_original_code
    Public gv_bolUODDL71_LF_Enable As Boolean 'LF処理実行フラグ(False：実行しない)
	Public gv_bolKeyFlg As Boolean
	' === 20060801 === INSERT E
	Public gv_bolUODDL71_Active As Boolean 'Form_Active実行制御
	Public gv_bolUODDL71_EndFlg As Boolean '終了フラグ

    'ADD 20190402  START saiki
    Public UODDL71_fpr As FR_SSSMAIN
    Public UODDL71 As FR_SSSMAIN1 = New FR_SSSMAIN1
    Public UODDL712 As FR_SSSMAIN2 = New FR_SSSMAIN2
    'ADD 20190402  END saiki

    'add start 20190805 kuwahara
    'マイグレ前はボタンのキャプションで画面の切替を判断していたため、マイグレに伴い画面切替用のフラグ変数を用意
    '初期値を1にしておかないと、一度目のクリックで、同じ画面を再表示してしまう。
    Public Judge1 As Integer = 1 '受注/売上切替用変数 0 = 受注　1＝売上 　
    Public Judge2 As Integer = 1 '単月/累計切替用変数 0 = 単月　1＝累計 
    'add end 20190805 kuwahara


    Public Structure UODDL71_TYPE_MEIMTC
		Dim DATKB As String '削除区分
		Dim MEICDA As String 'コード１
		Dim MEINMA As String '名称１
	End Structure
	'名称マスタ情報
	Public UODDL71_MEIMTC_Inf As UODDL71_TYPE_MEIMTC
	
	Public Structure UODDL71_TYPE_BMNSOU
		Dim BMNCD As String '部門コード
		Dim BMNNM As String '部門名称
		Dim BMNBR As Decimal '部門空行数
		Dim TIKKB As String '地区区分
		Dim TIKNM As String '地区名称
		Dim TIKBR As Decimal '地区空行数
		Dim EIGYOCD As String '営業所コード
		Dim EIGYONM As String '営業所名称
		Dim EIGYOBR As Decimal '営業所空行数
		Dim DSPORD As String '表示順
		Dim UODSU As Decimal '受注数量
		Dim UODKN As Decimal '受注金額
		Dim SIKKN As Decimal '仕切
		Dim BAISA As Decimal '売差
		Dim BSART As Decimal '売差率
	End Structure
	'部門別総括表情報
	Public UODDL71_BMNSOU_Inf() As UODDL71_TYPE_BMNSOU
	
	Public Structure UODDL71_TYPE_KISSOU
		Dim PCODE As String '集計コード
		' 2007/01/10  ADD START  KUMEDA
		Dim HGROUP As String '商品集計グループ
		' 2007/01/10  ADD END
		'2007/10/12 FKS)minamoto ADD START
		Dim HGROUPNM As String '商品集計グループ名称
		'2007/10/12 FKS)minamoto ADD END
		Dim SYOHIN As String '商品
		Dim NAIGAICD As String '国内外コード
		Dim NAIGAINM As String '国内外
		Dim UODSU As Decimal '受注数量
		Dim UODKN As Decimal '受注金額
		Dim SIKKN As Decimal '仕切
		Dim BAISA As Decimal '売差
		Dim BSART As Decimal '売差率
	End Structure
	'機種別総括表情報
	Public UODDL71_KISSOU_Inf() As UODDL71_TYPE_KISSOU
	
	Public Structure UODDL71_TYPE_KISMEI
		Dim SYOHIN As String '商品群名称
		Dim SYOHINRM As String '商品群略称
		Dim BUNRUIA As String '分類Ａ
		Dim BUNRUIB As String '分類Ｂ
		Dim BUNRUIC As String '分類Ｃ
		Dim UODSU_T As Decimal '受注数量
		Dim UODKN_T As Decimal '受注金額
		Dim SIKKN_T As Decimal '仕切
		Dim BAISA_T As Decimal '売差
		Dim BSART_T As Decimal '売差率
	End Structure
	'機種明細表情報
	Public UODDL71_KISMEI_Inf() As UODDL71_TYPE_KISMEI
	
	'ページ情報
	Public MaxPageNum As Short '明細の最大ページ数
	Public NowPageNum As Short '明細の現在のページ数
	Public MinPageNum As Short '明細の最小ページ数
	
	'部門コード
	Public gv_UODDL71_BMNCD As String
	'地区区分
	Public gv_UODDL71_TIKCD As String
	'営業所コード
	Public gv_UODDL71_EIGCD As String
	'受注／売上
	Public gv_UODDL71_JUC_URI As String '1:受注、2:売上
	'当月／当期
	Public gv_UODDL71_GETU_KI As String '1:当月、2:当期
	
	
	'条件の値の変更フラグ
	Private pv_JYOKEN_INPUT As Boolean
	
	'列番号
	Private Const pc_COL_MEISYO As Short = 1 '名称
	Private Const pc_COL_UODSU_T As Short = 2 '受注数
	Private Const pc_COL_UODKN_T As Short = 3 '受注金額
	Private Const pc_COL_SIKKN_T As Short = 4 '仕切
	Private Const pc_COL_BAISA_T As Short = 5 '売差
	Private Const pc_COL_BSART_T As Short = 6 '売差率
	
	Private Const pc_Bmncd_Keycode As String = "069" '名称マスタの部門
	Private Const pc_Tikcd_Keycode As String = "060" '名称マスタの地区区分
	Private Const pc_Eigcd_Keycode As String = "058" '名称マスタの営業所
	Private Const pc_Syohin_Keycode As String = "042" '名称マスタの商品群
	Private Const pc_BunruiA_Keycode As String = "051" '名称マスタの分類Ａ
	Private Const pc_BunruiB_Keycode As String = "052" '名称マスタの分類Ｂ
	Private Const pc_BunruiC_Keycode As String = "053" '名称マスタの分類Ｃ
	'2007/10/12 FKS)minamoto ADD START
	Private Const pc_Hgroup_Keycode As String = "091" '名称マスタの商品集計グループ名称
	'2007/10/12 FKS)minamoto ADD END
	
	Public Const gc_Sum_Text_Kei As String = "　　　　計"
	Public Const gc_Sum_Text_Syokei As String = "　　小計"
	Public Const gc_Sum_Text_Gokei As String = "　　合計"
	' 2007/03/04  ADD START  KUMEDA
	Public Const DATE_GET_INF As String = "データ読み込み中です。" 'データ読み込み
	' 2007/03/04  ADD END
	
	'//明細色設定
	Public Const COLOR_DTL_GREEN As Integer = &H80FF80 '緑色
	Public Const COLOR_DTL_LIGHTGREEN As Integer = &HC0FFC0 '薄緑色
	Public Const COLOR_DTL_BLUE As Integer = &HFFFFC0 '青色
	Public Const COLOR_DTL_LIGHTYELLOW As Integer = &H80FFFF '薄黄色
	
	'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
	
	''**ﾁｪｯｸ関数関連 Start **
	'//戻値
	Public Const CHK_OK As Short = 0 '正常
	Public Const CHK_WARN As Short = 1 '警告
	Public Const CHK_ERR_NOT_INPUT As Short = 10 '未入力エラー
	Public Const CHK_ERR_ELSE As Short = 11 'その他エラー
	
	'F_Chk_Jge_Action関数用
	Public Const CHK_KEEP As Short = 0 'チェック続行
	Public Const CHK_STOP As Short = 1 'チェック中断
	
	'**ﾁｪｯｸ関数関連 End  **
	
	'//F_Set_Next_Focus処理モード
	Public Const NEXT_FOCUS_MODE_KEYRETURN As Short = 1 'KEYRETURNと同様の制御
	Public Const NEXT_FOCUS_MODE_KEYRIGHT As Short = 2 'KEYRIGHTと同様の制御
	'======================= 変更部分 2006.07.02 Start =================================
	Public Const NEXT_FOCUS_MODE_KEYDOWN As Short = 3 'KEYDOWNと同様の制御
	'======================= 変更部分 2006.07.02 End =================================
	'//F_Dsp_Item_Detail処理モード
	Public Const DSP_SET As Short = 0 '表示
	Public Const DSP_CLR As Short = 1 'クリア
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_FIRSTDAY
	'   概要：  月初日または期首日を返す
	'   引数：　pm_Kind         1:月初日、2:期首日
	'           pm_Date         基準日
	'   戻値：　月初日または期首日
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_FIRSTDAY(ByVal pm_Kind As String, ByVal pm_Date As String) As String
		
		Dim Fst_Day As String
		Dim Wk_Year As String
		Dim Wk_Month As String
		
		Select Case pm_Kind
			Case "1"
				'月初日
				Fst_Day = Left(pm_Date, 6) & "01"
				
			Case "2"
				'期首日
				Wk_Year = Left(pm_Date, 4)
				Wk_Month = Mid(pm_Date, 5, 2)
				
				'１月～３月の場合、前年を計算
				If Wk_Month >= "01" And Wk_Month <= "03" Then
					Wk_Year = CStr(CShort(Wk_Year) - 1)
				End If
				
				Fst_Day = Wk_Year & "0401"
				
		End Select
		
		F_GET_FIRSTDAY = Fst_Day
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_BMN_SOUKATU_JUC_SQL
	'   概要：  データ取得ＳＱＬ生成（部門別総括表：受注）
	'   引数：　pm_Kind         1:月初日、2:期首日
	'   戻値：　生成SQL
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_BMN_SOUKATU_JUC_SQL(ByVal pm_Kind As String) As String
		
		Dim strSQL As String
		Dim StartDate As String
		
		'検索開始日の取得
		StartDate = F_GET_FIRSTDAY(pm_Kind, GV_UNYDate)
		
		'検索ＳＱＬ発行
		strSQL = ""
		strSQL = strSQL & " Select "
		strSQL = strSQL & "     WAKU.BMNCD As BMNCD "
		strSQL = strSQL & "    ,WAKU.BMNNM As BMNNM "
		strSQL = strSQL & "    ,WAKU.BMNBR As BMNBR "
		strSQL = strSQL & "    ,WAKU.TIKKB As TIKKB "
		strSQL = strSQL & "    ,WAKU.TIKNM As TIKNM "
		strSQL = strSQL & "    ,WAKU.TIKBR As TIKBR "
		strSQL = strSQL & "    ,WAKU.EIGYOCD As EIGYOCD "
		strSQL = strSQL & "    ,WAKU.EIGYONM As EIGYONM "
		strSQL = strSQL & "    ,WAKU.EIGYOBR As EIGYOBR "
		strSQL = strSQL & "    ,WAKU.DSPORD58 As DSPORD "
		strSQL = strSQL & "    ,SUM(MAIN.UODSU) As UODSU "
		strSQL = strSQL & "    ,Round(SUM(MAIN.UODKN)) As UODKN "
		strSQL = strSQL & "    ,Round(SUM(MAIN.SIKKN)) As SIKKN "
		strSQL = strSQL & " From "
		strSQL = strSQL & "     ( "
		strSQL = strSQL & "         Select  "
		strSQL = strSQL & "             JIGYOBU AS BMNCD "
		strSQL = strSQL & "            ,TIKKB "
		strSQL = strSQL & "            ,EIGYOCD "
		strSQL = strSQL & "            ,SUM(UODSU) AS UODSU "
		strSQL = strSQL & "            ,SUM(UODKN) AS UODKN "
		strSQL = strSQL & "            ,SUM(SIKKN) AS SIKKN "
		strSQL = strSQL & "         From "
		strSQL = strSQL & "             JDNDLA "
		strSQL = strSQL & "         Where "
		strSQL = strSQL & "             JDNDT >= '" & StartDate & "' "
		strSQL = strSQL & "         And JDNDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         Group By "
		strSQL = strSQL & "             JIGYOBU "
		strSQL = strSQL & "            ,TIKKB "
		strSQL = strSQL & "            ,EIGYOCD "
		strSQL = strSQL & "     ) MAIN "
		strSQL = strSQL & "    ,( "
		strSQL = strSQL & "         Select Distinct "
		strSQL = strSQL & "             MEI58.MEIKBA As BMNCD "
		'''' UPD 2010/03/16  FKS) T.Yamamoto    Start    連絡票№CF09122201
		'    strSQL = strSQL & "            ,MEI69.MEINMA As BMNNM "
		strSQL = strSQL & "            ,MEI69.MEINMC As BMNNM "
		'''' UPD 2010/03/16  FKS) T.Yamamoto    End
		strSQL = strSQL & "            ,MEI69.MEISUA As BMNBR "
		strSQL = strSQL & "            ,BMN.TIKKB As TIKKB "
		strSQL = strSQL & "            ,MEI60.MEINMA As TIKNM "
		strSQL = strSQL & "            ,MEI60.MEISUA As TIKBR "
		strSQL = strSQL & "            ,BMN.EIGYOCD As EIGYOCD "
		strSQL = strSQL & "            ,MEI58.MEINMA As EIGYONM "
		strSQL = strSQL & "            ,MEI58.MEISUA As EIGYOBR "
		strSQL = strSQL & "            ,MEI58.DSPORD As DSPORD58 "
		strSQL = strSQL & "            ,MEI60.DSPORD As DSPORD60 "
		strSQL = strSQL & "            ,MEI69.DSPORD As DSPORD69 "
		strSQL = strSQL & "         From "
		strSQL = strSQL & "             ( "
		strSQL = strSQL & "                 Select * "
		strSQL = strSQL & "                 From MEIMTC "
		strSQL = strSQL & "                 Where KEYCD = '" & pc_Tikcd_Keycode & "' "
		strSQL = strSQL & "                 And   STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "                 And   ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "             ) MEI60 "
		strSQL = strSQL & "            ,BMNMTA BMN "
		strSQL = strSQL & "            ,MEIMTC MEI69 "
		strSQL = strSQL & "            ,MEIMTC MEI58 "
		strSQL = strSQL & "         Where "
		strSQL = strSQL & "             MEI58.KEYCD = '" & pc_Eigcd_Keycode & "' "
		strSQL = strSQL & "         And MEI58.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEI58.ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEI69.KEYCD = '" & pc_Bmncd_Keycode & "' "
		strSQL = strSQL & "         And MEI69.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEI69.ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEI69.MEICDA = MEI58.MEIKBA "
		strSQL = strSQL & "         And BMN.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And BMN.ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And BMN.EIGYOCD = MEI58.MEICDA "
		strSQL = strSQL & "         And MEI60.MEICDA(+) = BMN.TIKKB "
		strSQL = strSQL & "     ) WAKU "
		strSQL = strSQL & " Where "
		strSQL = strSQL & "     MAIN.BMNCD(+) = WAKU.BMNCD "
		strSQL = strSQL & " And MAIN.TIKKB(+) = WAKU.TIKKB "
		strSQL = strSQL & " And MAIN.EIGYOCD(+) = WAKU.EIGYOCD "
		strSQL = strSQL & " GROUP BY"
		strSQL = strSQL & "     WAKU.BMNCD "
		strSQL = strSQL & "    ,WAKU.BMNNM "
		strSQL = strSQL & "    ,WAKU.BMNBR "
		strSQL = strSQL & "    ,WAKU.TIKKB "
		strSQL = strSQL & "    ,WAKU.TIKNM "
		strSQL = strSQL & "    ,WAKU.TIKBR "
		strSQL = strSQL & "    ,WAKU.EIGYOCD "
		strSQL = strSQL & "    ,WAKU.EIGYONM "
		strSQL = strSQL & "    ,WAKU.EIGYOBR "
		strSQL = strSQL & "    ,WAKU.DSPORD58 "
		strSQL = strSQL & "    ,WAKU.DSPORD60 "
		strSQL = strSQL & "    ,WAKU.DSPORD69 "
		strSQL = strSQL & " Order By "
		strSQL = strSQL & "     WAKU.DSPORD69 "
		strSQL = strSQL & "    ,WAKU.BMNCD "
		strSQL = strSQL & "    ,WAKU.DSPORD60 "
		strSQL = strSQL & "    ,TIKKB DESC "
		strSQL = strSQL & "    ,WAKU.DSPORD58 "
		strSQL = strSQL & "    ,WAKU.EIGYOCD "
		
		F_GET_BMN_SOUKATU_JUC_SQL = strSQL
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_BMN_SOUKATU_URI_SQL
	'   概要：  データ取得ＳＱＬ生成（部門別総括表：売上）
	'   引数：　pm_Kind         1:月初日、2:期首日
	'   戻値：　生成SQL
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_BMN_SOUKATU_URI_SQL(ByVal pm_Kind As String) As String
		
		Dim strSQL As String
		Dim StartDate As String
		
		'検索開始日の取得
		StartDate = F_GET_FIRSTDAY(pm_Kind, GV_UNYDate)
		
		'検索ＳＱＬ発行
		strSQL = ""
		strSQL = strSQL & " Select "
		strSQL = strSQL & "     WAKU.BMNCD As BMNCD "
		strSQL = strSQL & "    ,WAKU.BMNNM As BMNNM "
		strSQL = strSQL & "    ,WAKU.BMNBR As BMNBR "
		strSQL = strSQL & "    ,WAKU.TIKKB As TIKKB "
		strSQL = strSQL & "    ,WAKU.TIKNM As TIKNM "
		strSQL = strSQL & "    ,WAKU.TIKBR As TIKBR "
		strSQL = strSQL & "    ,WAKU.EIGYOCD As EIGYOCD "
		strSQL = strSQL & "    ,WAKU.EIGYONM As EIGYONM "
		strSQL = strSQL & "    ,WAKU.EIGYOBR As EIGYOBR "
		strSQL = strSQL & "    ,WAKU.DSPORD58 As DSPORD "
		strSQL = strSQL & "    ,SUM(MAIN.URISU) As UODSU "
		strSQL = strSQL & "    ,Round(SUM(MAIN.URIKN)) As UODKN "
		strSQL = strSQL & "    ,Round(SUM(MAIN.SIKKN)) As SIKKN "
		strSQL = strSQL & " From "
		strSQL = strSQL & "     ( "
		strSQL = strSQL & "         Select  "
		strSQL = strSQL & "             JIGYOBU AS BMNCD "
		strSQL = strSQL & "            ,TIKKB "
		strSQL = strSQL & "            ,EIGYOCD "
		strSQL = strSQL & "            ,SUM(URISU) AS URISU "
		strSQL = strSQL & "            ,SUM(URIKN) AS URIKN "
		strSQL = strSQL & "            ,SUM(SIKKN) AS SIKKN "
		strSQL = strSQL & "         From "
		strSQL = strSQL & "             UDNDLA "
		strSQL = strSQL & "         Where "
		strSQL = strSQL & "             UDNDT >= '" & StartDate & "' "
		strSQL = strSQL & "         And UDNDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         Group By "
		strSQL = strSQL & "             JIGYOBU "
		strSQL = strSQL & "            ,TIKKB "
		strSQL = strSQL & "            ,EIGYOCD "
		strSQL = strSQL & "     ) MAIN "
		strSQL = strSQL & "    ,( "
		strSQL = strSQL & "         Select Distinct "
		strSQL = strSQL & "             MEI58.MEIKBA As BMNCD "
		'''' UPD 2010/03/16  FKS) T.Yamamoto    Start    連絡票№CF09122201
		'    strSQL = strSQL & "            ,MEI69.MEINMA As BMNNM "
		strSQL = strSQL & "            ,MEI69.MEINMC As BMNNM "
		'''' UPD 2010/03/16  FKS) T.Yamamoto    End
		strSQL = strSQL & "            ,MEI69.MEISUA As BMNBR "
		strSQL = strSQL & "            ,BMN.TIKKB As TIKKB "
		strSQL = strSQL & "            ,MEI60.MEINMA As TIKNM "
		strSQL = strSQL & "            ,MEI60.MEISUA As TIKBR "
		strSQL = strSQL & "            ,BMN.EIGYOCD As EIGYOCD "
		strSQL = strSQL & "            ,MEI58.MEINMA As EIGYONM "
		strSQL = strSQL & "            ,MEI58.MEISUA As EIGYOBR "
		strSQL = strSQL & "            ,MEI58.DSPORD As DSPORD58 "
		strSQL = strSQL & "            ,MEI60.DSPORD As DSPORD60 "
		strSQL = strSQL & "            ,MEI69.DSPORD As DSPORD69 "
		strSQL = strSQL & "         From "
		strSQL = strSQL & "             ( "
		strSQL = strSQL & "                 Select * "
		strSQL = strSQL & "                 From MEIMTC "
		strSQL = strSQL & "                 Where KEYCD = '" & pc_Tikcd_Keycode & "' "
		strSQL = strSQL & "                 And   STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "                 And   ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "             ) MEI60 "
		strSQL = strSQL & "            ,BMNMTA BMN "
		strSQL = strSQL & "            ,MEIMTC MEI69 "
		strSQL = strSQL & "            ,MEIMTC MEI58 "
		strSQL = strSQL & "         Where "
		strSQL = strSQL & "             MEI58.KEYCD = '" & pc_Eigcd_Keycode & "' "
		strSQL = strSQL & "         And MEI58.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEI58.ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEI69.KEYCD = '" & pc_Bmncd_Keycode & "' "
		strSQL = strSQL & "         And MEI69.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEI69.ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEI69.MEICDA = MEI58.MEIKBA "
		strSQL = strSQL & "         And BMN.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And BMN.ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And BMN.EIGYOCD = MEI58.MEICDA "
		strSQL = strSQL & "         And MEI60.MEICDA(+) = BMN.TIKKB "
		strSQL = strSQL & "     ) WAKU "
		strSQL = strSQL & " Where "
		strSQL = strSQL & "     MAIN.BMNCD(+) = WAKU.BMNCD "
		strSQL = strSQL & " And MAIN.TIKKB(+) = WAKU.TIKKB "
		strSQL = strSQL & " And MAIN.EIGYOCD(+) = WAKU.EIGYOCD "
		strSQL = strSQL & " GROUP BY"
		strSQL = strSQL & "     WAKU.BMNCD "
		strSQL = strSQL & "    ,WAKU.BMNNM "
		strSQL = strSQL & "    ,WAKU.BMNBR "
		strSQL = strSQL & "    ,WAKU.TIKKB "
		strSQL = strSQL & "    ,WAKU.TIKNM "
		strSQL = strSQL & "    ,WAKU.TIKBR "
		strSQL = strSQL & "    ,WAKU.EIGYOCD "
		strSQL = strSQL & "    ,WAKU.EIGYONM "
		strSQL = strSQL & "    ,WAKU.EIGYOBR "
		strSQL = strSQL & "    ,WAKU.DSPORD58 "
		strSQL = strSQL & "    ,WAKU.DSPORD60 "
		strSQL = strSQL & "    ,WAKU.DSPORD69 "
		strSQL = strSQL & " Order By "
		strSQL = strSQL & "     WAKU.DSPORD69 "
		strSQL = strSQL & "    ,WAKU.BMNCD "
		strSQL = strSQL & "    ,WAKU.DSPORD60 "
		strSQL = strSQL & "    ,TIKKB DESC "
		strSQL = strSQL & "    ,WAKU.DSPORD58 "
		strSQL = strSQL & "    ,WAKU.EIGYOCD "
		
		F_GET_BMN_SOUKATU_URI_SQL = strSQL
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_BD_DATA_BMN_SOUKATU_JUC
	'   概要：  ボディ部データ取得（部門別総括表：受注）
	'   引数：  pm_Kind     1:月初日、2:期首日
	'           pm_All      :全構造体
	'   戻値：　取得行数
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_BD_DATA_BMN_SOUKATU_JUC(ByVal pm_Kind As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim Ret_Value As Short

        'delete 20190327 START saiki
		'ADD 20150710 START C2-20150708-01
        'Call F_Ctl_LAB_EXC(pm_All)
        'ADD 20150710 END C2-20150708-01
        'delete 20190327 END saiki
		
		'検索ＳＱＬ生成
		strSQL = F_GET_BMN_SOUKATU_JUC_SQL(pm_Kind)
		
		'Ret_Value = F_GET_BD_DATA_BMN_SOUKATU(strSQL, pm_All)
		Ret_Value = F_GET_BD_DATA_BMN_SOUKATU2(strSQL, pm_All)
		
		'ADD 20150710 START C2-20150708-01
        'UPGRADE_ISSUE: Control lab_exc は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'delete 20190325　START saiki
        'If pm_All.Dsp_Base.FormCtl.lab_exc.Visible = False Then

        'Call F_Ctl_LAB_EXC(pm_All)

        'End If
        'delete 20190325　END saiki
        'ADD 20150710 END C2-20150708-01

        F_GET_BD_DATA_BMN_SOUKATU_JUC = Ret_Value
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_BD_DATA_BMN_SOUKATU_URI
	'   概要：  ボディ部データ取得（部門別総括表：売上）
	'   引数：  pm_Kind     1:月初日、2:期首日
	'           pm_All      :全構造体
	'   戻値：　取得行数
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_BD_DATA_BMN_SOUKATU_URI(ByVal pm_Kind As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim Ret_Value As Short

        'delete 20190327 START saiki
		'ADD 20150710 START C2-20150708-01
        'Call F_Ctl_LAB_EXC(pm_All)
        'ADD 20150710 END C2-20150708-01
        'delete 20190327 END saiki

		
		'検索ＳＱＬ生成
		strSQL = F_GET_BMN_SOUKATU_URI_SQL(pm_Kind)
		
		'Ret_Value = F_GET_BD_DATA_BMN_SOUKATU(strSQL, pm_All)
		Ret_Value = F_GET_BD_DATA_BMN_SOUKATU2(strSQL, pm_All)
		
		'ADD 20150710 START C2-20150708-01
        'UPGRADE_ISSUE: Control lab_exc は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'delete 20190325　START saiki
        'If pm_All.Dsp_Base.FormCtl.lab_exc.Visible = False Then

        'Call F_Ctl_LAB_EXC(pm_All)

        'End If
        'delete 20190327　END saiki
        'ADD 20150710 END C2-20150708-01

        F_GET_BD_DATA_BMN_SOUKATU_URI = Ret_Value

    End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_BD_DATA_BMN_SOUKATU
	'   概要：  ボディ部データ取得（部門別総括表）
	'   引数：  pm_Kind     1:月初日、2:期首日
	'           pm_All      :全構造体
	'   戻値：　取得行数
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_BD_DATA_BMN_SOUKATU(ByVal pm_SQL As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim intMode As Short
		Dim intCnt As Short
		Dim Wk_Index As Short
		Dim Err_Cd As String
		Dim intRowCnt As Short
		Dim intBmnCnt As Short
		Dim intTikCnt As Short
		Dim BmnGokei() As UODDL71_TYPE_BMNSOU
		Dim TikGokei() As UODDL71_TYPE_BMNSOU
		Dim ZenGokei As UODDL71_TYPE_BMNSOU
		Dim Wk_BmnCd As String
		Dim Wk_TikCd As String
		
		On Error GoTo ERR_F_GET_BD_DATA_BMN_SOUKATU
		F_GET_BD_DATA_BMN_SOUKATU = -1
		
		' 2007/03/04  ADD START  KUMEDA
		Call FR_SSSMAIN.Ctl_MN_APPENDC_Click()
		Call CF_Set_Prompt(DATE_GET_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), pm_All)
		System.Windows.Forms.Application.DoEvents()
		' 2007/03/04  ADD END
		
		'初期化
		Err_Cd = ""
		Wk_BmnCd = ""
		Wk_TikCd = ""
		ReDim BmnGokei(0)
		ReDim TikGokei(0)
		
		'検索ＳＱＬ生成
		strSQL = pm_SQL
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		
		If CF_Ora_EOF(Usr_Ody) = True Then
			'取得データなし
			F_GET_BD_DATA_BMN_SOUKATU = 0
			Err_Cd = gc_strMsgUODDL71_E_002
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			
			Exit Function
		Else
			
			intCnt = 0
			Do Until CF_Ora_EOF(Usr_Ody) = True
				'取得全レコードよりボディ情報退避
				intCnt = intCnt + 1
				'行追加
				ReDim Preserve UODDL71_BMNSOU_Inf(intCnt)
				
				With UODDL71_BMNSOU_Inf(intCnt)
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.BMNCD = CF_Ora_GetDyn(Usr_Ody, "BMNCD", "") '部門コード
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.BMNNM = CF_Ora_GetDyn(Usr_Ody, "BMNNM", "") '部門名称
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.TIKKB = CF_Ora_GetDyn(Usr_Ody, "TIKKB", "") '地区区分
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.TIKNM = CF_Ora_GetDyn(Usr_Ody, "TIKNM", "") '地区名称
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.EIGYOCD = CF_Ora_GetDyn(Usr_Ody, "EIGYOCD", "") '営業所コード
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.EIGYONM = CF_Ora_GetDyn(Usr_Ody, "EIGYONM", "") '営業所名称
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.DSPORD = CF_Ora_GetDyn(Usr_Ody, "DSPORD", "") '表示順
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.UODSU = CF_Ora_GetDyn(Usr_Ody, "UODSU", 0) '受注数量
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.UODKN = CF_Ora_GetDyn(Usr_Ody, "UODKN", 0) '受注金額
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.SIKKN = CF_Ora_GetDyn(Usr_Ody, "SIKKN", 0) '仕切
					.BAISA = .UODKN - .SIKKN '売差
				End With
				
				'次レコード
				Call CF_Ora_MoveNext(Usr_Ody)
			Loop 
			
			intRowCnt = 0
			intBmnCnt = 0
			intTikCnt = 0
			For intData = 1 To intCnt
				With UODDL71_BMNSOU_Inf(intData)
					'前データの部門コードと異なる場合
					If Wk_BmnCd <> .BMNCD Then
						'最初の地区でない場合、前の地区の計行を作成
						If Trim(Wk_TikCd) <> "" Then
							'行追加
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'行項目情報コピー
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
								.Selected = CStr(False)
								.MEISYO = gc_Sum_Text_Kei
								.BD_UODSU_T = TikGokei(intTikCnt).UODSU '受注数
								.BD_UODKN_T = TikGokei(intTikCnt).UODKN '受注金額
								.BD_SIKKN_T = TikGokei(intTikCnt).SIKKN '仕切
								.BD_BAISA_T = TikGokei(intTikCnt).BAISA '売差
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
								End If

                                '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                                '名称
                                'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                                'delete 20190325 END saiki
                                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '受注数
                                'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                                'delete 20190325 END saiki
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'受注金額
								'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                                'delete 20190325 END saiki
								Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'仕切
								'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                                'delete 20190325 END saiki
                                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'売差
								'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                                'delete 20190325 END saiki
								Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'売差率
								If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
									'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                    'delete 20190325 START saiki
                                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                    'delete 20190325 END saiki
									Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								Else
									'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                    'delete 20190325 START saiki
                                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                    'delete 20190325 END saiki
									Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								End If
							End With
						End If
						
						'最初の部門でない場合、前の部門の小計行を作成
						If Trim(Wk_BmnCd) <> "" Then
							'行追加
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'行項目情報コピー
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
								.Selected = CStr(False)
								.MEISYO = gc_Sum_Text_Syokei
								.BD_UODSU_T = BmnGokei(intBmnCnt).UODSU '受注数
								.BD_UODKN_T = BmnGokei(intBmnCnt).UODKN '受注金額
								.BD_SIKKN_T = BmnGokei(intBmnCnt).SIKKN '仕切
								.BD_BAISA_T = BmnGokei(intBmnCnt).BAISA '売差
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
								End If
								
								'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
								'名称
								'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                                'delete 20190325 END saiki
								Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'受注数
                                'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                                'delete 20190325 END saiki
								Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'受注金額
                                'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                                'delete 20190325 END saiki
								Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'仕切
                                'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                                'delete 20190325 END saiki
								Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'売差
                                'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                                'delete 20190325 END saiki
								Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'売差率
								If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                    'delete 20190325 START saiki
                                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                    'delete 20190325 END saiki
									Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								Else
                                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                    'delete 20190325 START saiki
                                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                    'delete 20190325 END saiki
									Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								End If
							End With
						End If
						
						'部門のカウント
						intBmnCnt = intBmnCnt + 1
						'部門合計計算用
						ReDim Preserve BmnGokei(intBmnCnt)
						BmnGokei(intBmnCnt).BMNCD = .BMNCD '部門コード
						BmnGokei(intBmnCnt).BMNNM = .BMNNM '部門名称
						BmnGokei(intBmnCnt).UODSU = 0 '受注数量
						BmnGokei(intBmnCnt).UODKN = 0 '受注金額
						BmnGokei(intBmnCnt).SIKKN = 0 '仕切
						BmnGokei(intBmnCnt).BAISA = 0 '売差
						
						'行追加
						intRowCnt = intRowCnt + 1
						ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
						'行項目情報コピー
						Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
						
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = .BMNNM
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVISION = "1"
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVCODE = .BMNCD
						
						'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
						'名称
                        'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        'delete 20190325 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                        'delete 20190325 END saiki
						Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					End If
					
					'前データの地区区分と異なる場合
					If Wk_TikCd <> .TIKKB Then
						'最初の地区でない場合、前の地区の計行を作成（前データの部門コードと同じ）
						If Trim(Wk_TikCd) <> "" And Wk_BmnCd = .BMNCD Then
							'行追加
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'行項目情報コピー
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
								.Selected = CStr(False)
								.MEISYO = gc_Sum_Text_Kei
								.BD_UODSU_T = TikGokei(intTikCnt).UODSU '受注数
								.BD_UODKN_T = TikGokei(intTikCnt).UODKN '受注金額
								.BD_SIKKN_T = TikGokei(intTikCnt).SIKKN '仕切
								.BD_BAISA_T = TikGokei(intTikCnt).BAISA '売差
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
								End If
								
								'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
								'名称
                                'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                                'delete 20190325 END saiki
								Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'受注数
                                'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                                'delete 20190325 END saiki
								Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'受注金額
                                'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                                'delete 20190325 END saiki
								Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'仕切
                                'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                                'delete 20190325 END saiki
								Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'売差
                                'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                                'delete 20190325 END saiki
                                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'売差率
								If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                    'delete 20190325 START saiki
                                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                    'delete 20190325 END saiki
									Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								Else
                                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                    'delete 20190325 START saiki
                                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                    'delete 20190325 END saiki
									Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								End If
							End With
						End If
						
						'今データの地区区分がある場合
						If Trim(.TIKKB) <> "" Then
							'地区のカウント
							intTikCnt = intTikCnt + 1
							'地区合計計算用
							ReDim Preserve TikGokei(intTikCnt)
							TikGokei(intTikCnt).TIKNM = .TIKNM '地区名称
							TikGokei(intTikCnt).UODSU = 0 '受注数量
							TikGokei(intTikCnt).UODKN = 0 '受注金額
							TikGokei(intTikCnt).SIKKN = 0 '仕切
							TikGokei(intTikCnt).BAISA = 0 '売差
							
							'行追加
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'行項目情報コピー
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
							pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = "　　" & .TIKNM
							pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVISION = "2"
							pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVCODE = .TIKKB
							
							'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
							'名称
                            'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                            'delete 20190325 START saiki
                            'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                            'delete 20190325 END saiki
							Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						End If
					End If
					
					'行追加
					intRowCnt = intRowCnt + 1
					ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
					'行項目情報コピー
					Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
					
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = "　　　　" & .EIGYONM & .EIGYOCD
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVISION = "3"
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVCODE = .EIGYOCD
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_UODSU_T = .UODSU '受注数
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_UODKN_T = .UODKN '受注金額
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_SIKKN_T = .SIKKN '仕切
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_BAISA_T = .BAISA '売差
					If .UODKN = 0 Then
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_BSART_T = 0
					Else
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_BSART_T = System.Math.Round(.BAISA / .UODKN * 100, 1) '売差率
					End If
					
					'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
					With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
						'名称
                        'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        'delete 20190325 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                        'delete 20190325 END saiki
						Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						'受注数
                        'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        'delete 20190325 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                        'delete 20190325 END saiki
						Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						'受注金額
                        'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        'delete 20190325 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                        'delete 20190325 END saiki
						Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						'仕切
                        'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        'delete 20190325 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                        'delete 20190325 END saiki
						Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						'売差
                        'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        'delete 20190325 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                        'delete 20190325 END saiki
						Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						'売差率
						If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                            'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                            'delete 20190325 START saiki
                            'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                            'delete 20190325 END saiki
							Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						Else
                            'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                            'delete 20190325 START saiki
                            'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                            'delete 20190325 END saiki
							Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						End If
					End With
					
					'地区合計計算
					If .TIKNM <> "" Then
						TikGokei(intTikCnt).UODSU = TikGokei(intTikCnt).UODSU + .UODSU '受注数量
						TikGokei(intTikCnt).UODKN = TikGokei(intTikCnt).UODKN + .UODKN '受注金額
						TikGokei(intTikCnt).SIKKN = TikGokei(intTikCnt).SIKKN + .SIKKN '仕切
						TikGokei(intTikCnt).BAISA = TikGokei(intTikCnt).BAISA + .BAISA '売差
					End If
					
					'営業所合計計算
					BmnGokei(intBmnCnt).UODSU = BmnGokei(intBmnCnt).UODSU + .UODSU '受注数量
					BmnGokei(intBmnCnt).UODKN = BmnGokei(intBmnCnt).UODKN + .UODKN '受注金額
					BmnGokei(intBmnCnt).SIKKN = BmnGokei(intBmnCnt).SIKKN + .SIKKN '仕切
					BmnGokei(intBmnCnt).BAISA = BmnGokei(intBmnCnt).BAISA + .BAISA '売差
					
					'今データの退避
					Wk_BmnCd = .BMNCD
					Wk_TikCd = .TIKKB
				End With
			Next 
			
			'地区区分がある場合、最終の地区の計行を作成
			If Trim(Wk_TikCd) <> "" Then
				'行追加
				intRowCnt = intRowCnt + 1
				ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
				'行項目情報コピー
				Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
				
				With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
					.Selected = CStr(False)
					.MEISYO = gc_Sum_Text_Kei
					.BD_UODSU_T = TikGokei(intTikCnt).UODSU '受注数
					.BD_UODKN_T = TikGokei(intTikCnt).UODKN '受注金額
					.BD_SIKKN_T = TikGokei(intTikCnt).SIKKN '仕切
					.BD_BAISA_T = TikGokei(intTikCnt).BAISA '売差
					If .BD_UODKN_T = 0 Then
						.BD_BSART_T = 0
					Else
						.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
					End If
					
					'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
					'名称
                    'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                    'delete 20190325 END saiki
					Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					'受注数
                    'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                    'delete 20190325 END saiki
					Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					'受注金額
                    'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                    'delete 20190325 END saiki

					Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					'仕切
					'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                    'delete 20190325 END saiki

					Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					'売差
					'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                    'delete 20190325 END saiki
                    Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					'売差率
					If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
						'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                        'delete 20190325 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                        'delete 20190325 END saiki
						Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					Else
						'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                        'delete 20190325 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                        'delete 20190325 END saiki
						Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					End If
				End With
			End If
			
			'最終の営業所の小計行を作成
			'行追加
			intRowCnt = intRowCnt + 1
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
			'行項目情報コピー
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			
			With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
				.Selected = CStr(False)
				.MEISYO = gc_Sum_Text_Syokei
				.BD_UODSU_T = BmnGokei(intBmnCnt).UODSU '受注数
				.BD_UODKN_T = BmnGokei(intBmnCnt).UODKN '受注金額
				.BD_SIKKN_T = BmnGokei(intBmnCnt).SIKKN '仕切
				.BD_BAISA_T = BmnGokei(intBmnCnt).BAISA '売差
				If .BD_UODKN_T = 0 Then
					.BD_BSART_T = 0
				Else
					.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
				End If
				
				'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
				'名称
				'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                'delete 20190325 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                'delete 20190325 END saiki
				Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				'受注数
				'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                'delete 20190325 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                'delete 20190325 END saiki
				Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				'受注金額
				'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                'delete 20190325 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                'delete 20190325 END saiki
				Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				'仕切
				'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                'delete 20190325 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                'delete 20190325 END saiki
				Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				'売差
				'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                'delete 20190325 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                'delete 20190325 END saiki
				Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				'売差率
				If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
					'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                    'delete 20190325 END saiki
					Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				Else
					'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                    'delete 20190325 END saiki
					Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				End If
			End With
			
			'全社行の作成
			'行追加
			intRowCnt = intRowCnt + 1
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
			'行項目情報コピー
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			
			pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
			pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = "全社"
			pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVISION = "99"
			pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVCODE = "Z"
			
			'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
			'名称
			'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

            'delete 20190325 START saiki
            'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
            'delete 20190325 END saiki
			Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
			
			'全社欄の事業部合計行の作成
			For intData = 1 To intBmnCnt
				'行追加
				intRowCnt = intRowCnt + 1
				ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
				'行項目情報コピー
				Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
				
				With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
					.Selected = CStr(False)
					.DIVISION = "1"
					.DIVCODE = BmnGokei(intData).BMNCD
					.MEISYO = "　　" & BmnGokei(intData).BMNNM '部門名称
					.BD_UODSU_T = BmnGokei(intData).UODSU '受注数
					.BD_UODKN_T = BmnGokei(intData).UODKN '受注金額
					.BD_SIKKN_T = BmnGokei(intData).SIKKN '仕切
					.BD_BAISA_T = BmnGokei(intData).BAISA '売差
					If .BD_UODKN_T = 0 Then
						.BD_BSART_T = 0
					Else
						.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
					End If
					
					'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
					'名称
					'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                    'delete 20190325 END saiki
					Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					'受注数
					'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                    ''delete 20190325 END saiki
					Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					'受注金額
					'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                    'delete 20190325 END saiki
					Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					'仕切
					'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                    'delete 20190325 END saiki
					Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					'売差
					'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                    'delete 20190325 END saiki
					Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					'売差率
					If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
						'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                        'delete 20190325 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                        'delete 20190325 END saiki
						Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					Else
						'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                        'delete 20190325 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                        'delete 20190325 END saiki
						Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					End If
				End With
				
				'全社合計計算
				ZenGokei.UODSU = ZenGokei.UODSU + BmnGokei(intData).UODSU '受注数量
				ZenGokei.UODKN = ZenGokei.UODKN + BmnGokei(intData).UODKN '受注金額
				ZenGokei.SIKKN = ZenGokei.SIKKN + BmnGokei(intData).SIKKN '仕切
				ZenGokei.BAISA = ZenGokei.BAISA + BmnGokei(intData).BAISA '売差
			Next 
			
			'全社合計行の作成
			'行追加
			intRowCnt = intRowCnt + 1
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
			'行項目情報コピー
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			
			With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
				.Selected = CStr(False)
				.MEISYO = gc_Sum_Text_Gokei
				.BD_UODSU_T = ZenGokei.UODSU '受注数
				.BD_UODKN_T = ZenGokei.UODKN '受注金額
				.BD_SIKKN_T = ZenGokei.SIKKN '仕切
				.BD_BAISA_T = ZenGokei.BAISA '売差
				If .BD_UODKN_T = 0 Then
					.BD_BSART_T = 0
				Else
					.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
				End If
				
				'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
				'名称
				'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                'delete 20190325 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                'delete 20190325 END saiki
				Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				'受注数
				'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                'delete 20190325 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                'delete 20190325 END saiki
				Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				'受注金額
				'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                'delete 20190325 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                'delete 20190325 END saiki
				Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				'仕切
				'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                'delete 20190325 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                'delete 20190325 END saiki
				Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				'売差
				'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                'delete 20190325 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                'delete 20190325 END saiki
				Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				'売差率
				If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
					'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                    'delete 20190325 END saiki
					Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				Else
					'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                    'delete 20190325 END saiki
					Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				End If
			End With
			
			'行情報構造体配列の Redim
			MaxPageNum = F_Ctl_Add_BlankRow(pm_All)
			
			NowPageNum = 1
		End If
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		' 2007/03/04  ADD START  KUMEDA
		Call CF_Clr_Prompt(pm_All)
		' 2007/03/04  ADD END
		
		F_GET_BD_DATA_BMN_SOUKATU = intCnt
		
		Exit Function
		
ERR_F_GET_BD_DATA_BMN_SOUKATU: 
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_BD_DATA_BMN_SOUKATU
	'   概要：  ボディ部データ取得（部門別総括表）
	'   引数：  pm_Kind     1:月初日、2:期首日
	'           pm_All      :全構造体
	'   戻値：　取得行数
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_BD_DATA_BMN_SOUKATU2(ByVal pm_SQL As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim intMode As Short
		Dim intCnt As Short
		Dim Wk_Index As Short
		Dim Err_Cd As String
		Dim intRowCnt As Short
		Dim intBmnCnt As Short
		Dim intTikCnt As Short
		Dim BmnGokei() As UODDL71_TYPE_BMNSOU
		Dim TikGokei() As UODDL71_TYPE_BMNSOU
		Dim ZenGokei As UODDL71_TYPE_BMNSOU
		Dim Wk_BmnCd As String
		Dim Wk_TikCd As String
		Dim Wk_Bmn_Index As Short
		Dim Wk_Tik_Index As Short
		Dim Wk_Zen_Index As Short
		Dim Br_Cnt As Short
		
		On Error GoTo ERR_F_GET_BD_DATA_BMN_SOUKATU2
		F_GET_BD_DATA_BMN_SOUKATU2 = -1
		
		' 2007/03/04  ADD START  KUMEDA
		Call FR_SSSMAIN.Ctl_MN_APPENDC_Click()
		Call CF_Set_Prompt(DATE_GET_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), pm_All)
		System.Windows.Forms.Application.DoEvents()
		' 2007/03/04  ADD END
		
		'初期化
		Err_Cd = ""
		Wk_BmnCd = ""
		Wk_TikCd = ""
		ReDim BmnGokei(0)
		ReDim TikGokei(0)
		
		'検索ＳＱＬ生成
		strSQL = pm_SQL

        'change 20190327 START saiki
		'DBアクセス
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change 20190327 END saiki

        'change 20190329 START saiki
        ' If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                'change 20190329 END saiki
                '取得データなし
                F_GET_BD_DATA_BMN_SOUKATU2 = 0
                Err_Cd = gc_strMsgUODDL71_E_002
                Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)

                Exit Function
            Else

            intCnt = 0
            'change 20190329 START saiki
            ' Do Until CF_Ora_EOF(Usr_Ody) = True
            ''取得全レコードよりボディ情報退避
            'intCnt = intCnt + 1
            '    '行追加
            '    ReDim Preserve UODDL71_BMNSOU_Inf(intCnt)

            '    With UODDL71_BMNSOU_Inf(intCnt)
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BMNCD = CF_Ora_GetDyn(Usr_Ody, "BMNCD", "") '部門コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BMNNM = CF_Ora_GetDyn(Usr_Ody, "BMNNM", "") '部門名称
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BMNBR = CF_Ora_GetDyn(Usr_Ody, "BMNBR", 0) '部門空行数
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TIKKB = CF_Ora_GetDyn(Usr_Ody, "TIKKB", "") '地区区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TIKNM = CF_Ora_GetDyn(Usr_Ody, "TIKNM", "") '地区名称
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TIKBR = CF_Ora_GetDyn(Usr_Ody, "TIKBR", 0) '地区空行数
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .EIGYOCD = CF_Ora_GetDyn(Usr_Ody, "EIGYOCD", "") '営業所コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .EIGYONM = CF_Ora_GetDyn(Usr_Ody, "EIGYONM", "") '営業所名称
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .EIGYOBR = CF_Ora_GetDyn(Usr_Ody, "EIGYOBR", 0) '営業所空行数
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .DSPORD = CF_Ora_GetDyn(Usr_Ody, "DSPORD", "") '表示順
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .UODSU = CF_Ora_GetDyn(Usr_Ody, "UODSU", 0) '受注数量
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .UODKN = CF_Ora_GetDyn(Usr_Ody, "UODKN", 0) '受注金額
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .SIKKN = CF_Ora_GetDyn(Usr_Ody, "SIKKN", 0) '仕切
            '        .BAISA = .UODKN - .SIKKN '売差
            '    End With


            'Do Until dt IsNot Nothing OrElse dt.Rows.Count > 0
            For Each row As DataRow In dt.Rows
                '取得全レコードよりボディ情報退避
                intCnt = intCnt + 1
                '行追加
                ReDim Preserve UODDL71_BMNSOU_Inf(intCnt)

                With UODDL71_BMNSOU_Inf(intCnt)
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .BMNCD = DB_NullReplace(row("BMNCD"), "") '部門コード
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .BMNNM = DB_NullReplace(row("BMNNM"), "") '部門名称
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .BMNBR = DB_NullReplace(row("BMNBR"), 0) '部門空行数
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .TIKKB = DB_NullReplace(row("TIKKB"), "") '地区区分
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .TIKNM = DB_NullReplace(row("TIKNM"), "") '地区名称
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .TIKBR = DB_NullReplace(row("TIKBR"), 0) '地区空行数
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .EIGYOCD = DB_NullReplace(row("EIGYOCD"), "") '営業所コード
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .EIGYONM = DB_NullReplace(row("EIGYONM"), "") '営業所名称
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .EIGYOBR = DB_NullReplace(row("EIGYOBR"), 0) '営業所空行数
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .DSPORD = DB_NullReplace(row("DSPORD"), "") '表示順
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .UODSU = DB_NullReplace(row("UODSU"), 0) '受注数量
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .UODKN = DB_NullReplace(row("UODKN"), 0) '受注金額
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .SIKKN = DB_NullReplace(row("SIKKN"), 0) '仕切
                    .BAISA = .UODKN - .SIKKN '売差
                End With

                'change 20190329 END saiki

                'delete 20190329 START saiki
                ''次レコード
                'Call CF_Ora_MoveNext(Usr_Ody)
                'delete 20190329 END saiki
            Next

            intRowCnt = 0
			intBmnCnt = 0
			intTikCnt = 0
			For intData = 1 To intCnt
				With UODDL71_BMNSOU_Inf(intData)
					'前データの部門コードと異なる場合
					If Wk_BmnCd <> .BMNCD Then
						'最初の部門でない場合、前の部門の小計をタイトル行に代入
						If Trim(Wk_BmnCd) <> "" Then
							With pm_All.Dsp_Body_Inf.Row_Inf(Wk_Bmn_Index).Bus_Inf
								.BD_UODSU_T = BmnGokei(intBmnCnt).UODSU '受注数
								.BD_UODKN_T = BmnGokei(intBmnCnt).UODKN '受注金額
								.BD_SIKKN_T = BmnGokei(intBmnCnt).SIKKN '仕切
								.BD_BAISA_T = BmnGokei(intBmnCnt).BAISA '売差
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
								End If

                                '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                                '名称
                                'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'change 20190329 START saiki
                                '  Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                Wk_Index = CShort(UODDL71_fpr.BD_MEISYO(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Bmn_Index, pm_All, SET_FLG_DB)
                                'change 20190329 END saiki

                                '受注数
                                'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                                'change 20190329 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                                Wk_Index = CShort(UODDL71_fpr.BD_UODSU(1).Tag)
                                'change 20190329 END saiki

                                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Bmn_Index, pm_All, SET_FLG_DB)
                                '受注金額
                                'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                                'change 20190329 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                                Wk_Index = CShort(UODDL71_fpr.BD_UODKN(1).Tag)
                                'change 20190329 END saiki

                                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Bmn_Index, pm_All, SET_FLG_DB)
                                '仕切
                                'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                                'change 20190329 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                                Wk_Index = CShort(UODDL71_fpr.BD_SIKKN(1).Tag)
                                'change 20190329 END saiki

                                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Bmn_Index, pm_All, SET_FLG_DB)
                                '売差
                                'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                                'change 20190329 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                                Wk_Index = CShort(UODDL71_fpr.BD_BAISA(1).Tag)
                                'change 20190329 END saiki

                                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Bmn_Index, pm_All, SET_FLG_DB)
								'売差率
								If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                                    'change 20190329 START saiki
                                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                    Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                                    'change 20190329 END saiki

                                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Bmn_Index, pm_All, SET_FLG_DB)
								Else
                                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                                    'change 20190329 START saiki
                                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                    Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                                    'change 20190329 END saiki

                                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Bmn_Index, pm_All, SET_FLG_DB)
								End If
							End With
						End If
						
						'最初の部門でない場合
						If Trim(Wk_BmnCd) <> "" Then
							'マスタに登録されている行数分の空行作成
							For Br_Cnt = 1 To BmnGokei(intBmnCnt).BMNBR
								'行追加
								intRowCnt = intRowCnt + 1
								ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
								'行項目情報コピー
								Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							Next 
						End If
						
						'部門のカウント
						intBmnCnt = intBmnCnt + 1
						'部門合計計算用
						ReDim Preserve BmnGokei(intBmnCnt)
						BmnGokei(intBmnCnt).BMNCD = .BMNCD '部門コード
						BmnGokei(intBmnCnt).BMNNM = .BMNNM '部門名称
						BmnGokei(intBmnCnt).BMNBR = .BMNBR '部門空行数
						BmnGokei(intBmnCnt).UODSU = 0 '受注数量
						BmnGokei(intBmnCnt).UODKN = 0 '受注金額
						BmnGokei(intBmnCnt).SIKKN = 0 '仕切
						BmnGokei(intBmnCnt).BAISA = 0 '売差
						
						'行追加
						intRowCnt = intRowCnt + 1
						ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
						'行項目情報コピー
						Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
						
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = .BMNNM
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVISION = "1"
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVCODE = .BMNCD

                        '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                        '名称
                        'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                        'change 20190329 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                        Wk_Index = CShort(UODDL71_fpr.BD_MEISYO(1).Tag)
                        'change 20190329 END saiki
                        Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)

                        '部門のタイトル行の番号を退避
                        Wk_Bmn_Index = intRowCnt
					End If
					
					'前データの地区区分と異なる場合
					If Wk_TikCd <> .TIKKB Then
						'最初の地区でない場合、前の地区の計をタイトル行に代入
						If Trim(Wk_TikCd) <> "" Then
							With pm_All.Dsp_Body_Inf.Row_Inf(Wk_Tik_Index).Bus_Inf
								.BD_UODSU_T = TikGokei(intTikCnt).UODSU '受注数
								.BD_UODKN_T = TikGokei(intTikCnt).UODKN '受注金額
								.BD_SIKKN_T = TikGokei(intTikCnt).SIKKN '仕切
								.BD_BAISA_T = TikGokei(intTikCnt).BAISA '売差
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
								End If

                                '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                                '受注数
                                'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                                'change 20190329 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                                Wk_Index = CShort(UODDL71_fpr.BD_UODSU(1).Tag)
                                'change 20190329 END saiki
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Tik_Index, pm_All, SET_FLG_DB)
                                '受注金額
                                'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                                'change 20190329 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                                Wk_Index = CShort(UODDL71_fpr.BD_UODKN(1).Tag)
                                'change 20190329 END saiki
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Tik_Index, pm_All, SET_FLG_DB)
                                '仕切
                                'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                                'change 20190329 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                                Wk_Index = CShort(UODDL71_fpr.BD_SIKKN(1).Tag)
                                'change 20190329 END saiki
                                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Tik_Index, pm_All, SET_FLG_DB)
                                '売差
                                'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                                'change 20190329 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                                Wk_Index = CShort(UODDL71_fpr.BD_BAISA(1).Tag)
                                'change 20190329 END saiki
                                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Tik_Index, pm_All, SET_FLG_DB)
								'売差率
								If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                                    'change 20190329 START saiki
                                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                    Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                                    'change 20190329 END saiki
                                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Tik_Index, pm_All, SET_FLG_DB)
								Else
                                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                                    'change 20190329 START saiki
                                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                    Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                                    'change 20190329 END saiki
                                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Tik_Index, pm_All, SET_FLG_DB)
								End If
							End With
						End If
						
						'最初の地区でない場合
						If Trim(Wk_TikCd) <> "" Then
							'マスタに登録されている行数分の空行作成
							For Br_Cnt = 1 To TikGokei(intTikCnt).TIKBR
								'行追加
								intRowCnt = intRowCnt + 1
								ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
								'行項目情報コピー
								Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							Next 
						End If
						
						'今データの地区区分がある場合
						If Trim(.TIKKB) <> "" Then
							'地区のカウント
							intTikCnt = intTikCnt + 1
							'地区合計計算用
							ReDim Preserve TikGokei(intTikCnt)
							TikGokei(intTikCnt).TIKNM = .TIKNM '地区名称
							TikGokei(intTikCnt).TIKBR = .TIKBR '地区空行数
							TikGokei(intTikCnt).UODSU = 0 '受注数量
							TikGokei(intTikCnt).UODKN = 0 '受注金額
							TikGokei(intTikCnt).SIKKN = 0 '仕切
							TikGokei(intTikCnt).BAISA = 0 '売差
							
							'行追加
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'行項目情報コピー
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
							pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = "　　" & .TIKNM
							pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVISION = "2"
							pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVCODE = .TIKKB

                            '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                            '名称
                            'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                            'change 20190329 START saiki
                            'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                            Wk_Index = CShort(UODDL71_fpr.BD_MEISYO(1).Tag)
                            'change 20190329 END saiki

                            Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
							
							'部門のタイトル行の番号を退避
							Wk_Tik_Index = intRowCnt
						End If
					End If
					
					'営業所明細行の編集
					'行追加
					intRowCnt = intRowCnt + 1
					ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
					'行項目情報コピー
					Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
					
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = "　　　　" & .EIGYONM & .EIGYOCD
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVISION = "3"
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVCODE = .EIGYOCD
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_UODSU_T = .UODSU '受注数
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_UODKN_T = .UODKN '受注金額
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_SIKKN_T = .SIKKN '仕切
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_BAISA_T = .BAISA '売差
					If .UODKN = 0 Then
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_BSART_T = 0
					Else
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_BSART_T = System.Math.Round(.BAISA / .UODKN * 100, 1) '売差率
					End If
					
					'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
					With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
                        '名称
                        'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                        'change 20190329 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                        Wk_Index = CShort(UODDL71_fpr.BD_MEISYO(1).Tag)
                        'change 20190329 END saiki
                        Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        '受注数
                        'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                        'change 20190329 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                        Wk_Index = CShort(UODDL71_fpr.BD_UODSU(1).Tag)
                        'change 20190329 END saiki
                        Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        '受注金額
                        'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                        'change 20190329 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                        Wk_Index = CShort(UODDL71_fpr.BD_UODKN(1).Tag)
                        'change 20190329 END saiki
                        Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        '仕切
                        'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                        'change 20190329 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                        Wk_Index = CShort(UODDL71_fpr.BD_SIKKN(1).Tag)
                        'change 20190329 END saiki
                        Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        '売差
                        'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                        'change 20190329 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                        Wk_Index = CShort(UODDL71_fpr.BD_BAISA(1).Tag)
                        'change 20190329 END saiki
                        Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						'売差率
						If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                            'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                            'change 20190329 START saiki
                            'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                            Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                            'change 20190329 END saiki
                            Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						Else
                            'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                            'change 20190329 START saiki
                            'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                            Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                            'change 20190329 END saiki
                            Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						End If
					End With
					
					'マスタに登録されている行数分の空行作成
					For Br_Cnt = 1 To .EIGYOBR
						'行追加
						intRowCnt = intRowCnt + 1
						ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
						'行項目情報コピー
						Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
					Next 
					
					'地区合計計算
					If .TIKNM <> "" Then
						TikGokei(intTikCnt).UODSU = TikGokei(intTikCnt).UODSU + .UODSU '受注数量
						TikGokei(intTikCnt).UODKN = TikGokei(intTikCnt).UODKN + .UODKN '受注金額
						TikGokei(intTikCnt).SIKKN = TikGokei(intTikCnt).SIKKN + .SIKKN '仕切
						TikGokei(intTikCnt).BAISA = TikGokei(intTikCnt).BAISA + .BAISA '売差
					End If
					
					'営業所合計計算
					BmnGokei(intBmnCnt).UODSU = BmnGokei(intBmnCnt).UODSU + .UODSU '受注数量
					BmnGokei(intBmnCnt).UODKN = BmnGokei(intBmnCnt).UODKN + .UODKN '受注金額
					BmnGokei(intBmnCnt).SIKKN = BmnGokei(intBmnCnt).SIKKN + .SIKKN '仕切
					BmnGokei(intBmnCnt).BAISA = BmnGokei(intBmnCnt).BAISA + .BAISA '売差
					
					'今データの退避
					Wk_BmnCd = .BMNCD
					Wk_TikCd = .TIKKB
				End With
			Next 
			
			'地区区分がある場合、最終の地区の計をタイトル行に代入
			If Trim(Wk_TikCd) <> "" Then
				With pm_All.Dsp_Body_Inf.Row_Inf(Wk_Tik_Index).Bus_Inf
					.BD_UODSU_T = TikGokei(intTikCnt).UODSU '受注数
					.BD_UODKN_T = TikGokei(intTikCnt).UODKN '受注金額
					.BD_SIKKN_T = TikGokei(intTikCnt).SIKKN '仕切
					.BD_BAISA_T = TikGokei(intTikCnt).BAISA '売差
					If .BD_UODKN_T = 0 Then
						.BD_BSART_T = 0
					Else
						.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
					End If

                    '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                    '受注数
                    'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                    'change 20190329 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                    Wk_Index = CShort(UODDL71_fpr.BD_UODSU(1).Tag)
                    'change 20190329 END saiki
                    Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Tik_Index, pm_All, SET_FLG_DB)
                    '受注金額
                    'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                    'change 20190329 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                    Wk_Index = CShort(UODDL71_fpr.BD_UODKN(1).Tag)
                    'change 20190329 END saiki
                    Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Tik_Index, pm_All, SET_FLG_DB)
                    '仕切
                    'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                    'change 20190329 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                    Wk_Index = CShort(UODDL71_fpr.BD_SIKKN(1).Tag)
                    'change 20190329 END saiki
                    Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Tik_Index, pm_All, SET_FLG_DB)
                    '売差
                    'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                    'change 20190329 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                    Wk_Index = CShort(UODDL71_fpr.BD_BAISA(1).Tag)
                    'change 20190329 END saiki
                    Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Tik_Index, pm_All, SET_FLG_DB)
					'売差率
					If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                        'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                        'change 20190329 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                        Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                        'change 20190329 END saiki
                        Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Tik_Index, pm_All, SET_FLG_DB)
					Else
                        'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                        'change 20190329 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                        Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                        'change 20190329 END saiki
                        Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Tik_Index, pm_All, SET_FLG_DB)
					End If
				End With
				
				'マスタに登録されている行数分の空行作成
				For Br_Cnt = 1 To TikGokei(intTikCnt).TIKBR
					'行追加
					intRowCnt = intRowCnt + 1
					ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
					'行項目情報コピー
					Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
				Next 
			End If
			
			'最終の営業所の小計をタイトル行に代入
			With pm_All.Dsp_Body_Inf.Row_Inf(Wk_Bmn_Index).Bus_Inf
				.BD_UODSU_T = BmnGokei(intBmnCnt).UODSU '受注数
				.BD_UODKN_T = BmnGokei(intBmnCnt).UODKN '受注金額
				.BD_SIKKN_T = BmnGokei(intBmnCnt).SIKKN '仕切
				.BD_BAISA_T = BmnGokei(intBmnCnt).BAISA '売差
				If .BD_UODKN_T = 0 Then
					.BD_BSART_T = 0
				Else
					.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
				End If

                '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                '受注数
                'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                'change 20190329 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                Wk_Index = CShort(UODDL71_fpr.BD_UODSU(1).Tag)
                'change 20190329 END saiki
                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Bmn_Index, pm_All, SET_FLG_DB)
                '受注金額
                'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                'change 20190329 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                Wk_Index = CShort(UODDL71_fpr.BD_UODKN(1).Tag)
                'change 20190329 END saiki
                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Bmn_Index, pm_All, SET_FLG_DB)
                '仕切
                'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                'change 20190329 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                Wk_Index = CShort(UODDL71_fpr.BD_SIKKN(1).Tag)
                'change 20190329 END saiki
                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Bmn_Index, pm_All, SET_FLG_DB)
                '売差
                'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                'change 20190329 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                Wk_Index = CShort(UODDL71_fpr.BD_BAISA(1).Tag)
                'change 20190329 END saiki
                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Bmn_Index, pm_All, SET_FLG_DB)
				'売差率
				If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                    'change 20190329 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                    Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                    'change 20190329 END saiki
                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Bmn_Index, pm_All, SET_FLG_DB)
				Else
                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                    'change 20190329 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                    Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                    'change 20190329 END saiki
                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Bmn_Index, pm_All, SET_FLG_DB)
				End If
			End With
			
			'マスタに登録されている行数分の空行作成
			For Br_Cnt = 1 To BmnGokei(intBmnCnt).BMNBR
				'行追加
				intRowCnt = intRowCnt + 1
				ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
				'行項目情報コピー
				Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			Next 
			
			'全社行の作成
			'行追加
			intRowCnt = intRowCnt + 1
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
			'行項目情報コピー
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			
			pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
			pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = "全社"
			pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVISION = "99"
			pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVCODE = "Z"

            '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
            '名称
            'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

            'change 20190329 START saiki
            'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
            Wk_Index = CShort(UODDL71_fpr.BD_MEISYO(1).Tag)
            'change 20190329 END saiki
            Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
			
			'全社のタイトル行の番号を退避
			Wk_Zen_Index = intRowCnt
			
			'全社欄の事業部合計行の作成
			For intData = 1 To intBmnCnt
				'行追加
				intRowCnt = intRowCnt + 1
				ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
				'行項目情報コピー
				Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
				
				With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
					.Selected = CStr(False)
					.DIVISION = "1"
					.DIVCODE = BmnGokei(intData).BMNCD
					.MEISYO = "　　" & BmnGokei(intData).BMNNM '部門名称
					.BD_UODSU_T = BmnGokei(intData).UODSU '受注数
					.BD_UODKN_T = BmnGokei(intData).UODKN '受注金額
					.BD_SIKKN_T = BmnGokei(intData).SIKKN '仕切
					.BD_BAISA_T = BmnGokei(intData).BAISA '売差
					If .BD_UODKN_T = 0 Then
						.BD_BSART_T = 0
					Else
						.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
					End If

                    '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                    '名称
                    'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                    'change 20190329 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                    Wk_Index = CShort(UODDL71_fpr.BD_MEISYO(1).Tag)
                    'change 20190329 END saiki
                    Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '受注数
                    'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                    'change 20190329 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                    Wk_Index = CShort(UODDL71_fpr.BD_UODSU(1).Tag)
                    'change 20190329 END saiki
                    Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '受注金額
                    'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                    'change 20190329 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                    Wk_Index = CShort(UODDL71_fpr.BD_UODKN(1).Tag)
                    'change 20190329 END saiki
                    Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '仕切
                    'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                    'change 20190329 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                    Wk_Index = CShort(UODDL71_fpr.BD_SIKKN(1).Tag)
                    'change 20190329 END saiki
                    Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '売差
                    'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                    'change 20190329 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                    Wk_Index = CShort(UODDL71_fpr.BD_BAISA(1).Tag)
                    'change 20190329 END saiki
                    Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					'売差率
					If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                        'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                        'change 20190329 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                        Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                        'change 20190329 END saiki
                        Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					Else
                        'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                        'change 20190329 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                        Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                        'change 20190329 END saiki
                        Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					End If
				End With
				
				'全社合計計算
				ZenGokei.UODSU = ZenGokei.UODSU + BmnGokei(intData).UODSU '受注数量
				ZenGokei.UODKN = ZenGokei.UODKN + BmnGokei(intData).UODKN '受注金額
				ZenGokei.SIKKN = ZenGokei.SIKKN + BmnGokei(intData).SIKKN '仕切
				ZenGokei.BAISA = ZenGokei.BAISA + BmnGokei(intData).BAISA '売差
			Next 
			
			'全社合計をタイトル行に代入
			With pm_All.Dsp_Body_Inf.Row_Inf(Wk_Zen_Index).Bus_Inf
				.BD_UODSU_T = ZenGokei.UODSU '受注数
				.BD_UODKN_T = ZenGokei.UODKN '受注金額
				.BD_SIKKN_T = ZenGokei.SIKKN '仕切
				.BD_BAISA_T = ZenGokei.BAISA '売差
				If .BD_UODKN_T = 0 Then
					.BD_BSART_T = 0
				Else
					.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
				End If

                'change 20190325 START saiki
                ''画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                ''受注数
                ''UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Zen_Index, pm_All, SET_FLG_DB)
                ''受注金額
                ''UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Zen_Index, pm_All, SET_FLG_DB)
                ''仕切
                ''UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Zen_Index, pm_All, SET_FLG_DB)
                ''売差
                ''UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Zen_Index, pm_All, SET_FLG_DB)
                ''売差率
                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                '	'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Zen_Index, pm_All, SET_FLG_DB)
                'Else
                '	'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Zen_Index, pm_All, SET_FLG_DB)
                '            End If

                '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                '受注数
                'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71_fpr.BD_UODSU(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Zen_Index, pm_All, SET_FLG_DB)
                '受注金額
                'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71_fpr.BD_UODKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Zen_Index, pm_All, SET_FLG_DB)
                '仕切
                'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71_fpr.BD_SIKKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Zen_Index, pm_All, SET_FLG_DB)
                '売差
                'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71_fpr.BD_BAISA(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Zen_Index, pm_All, SET_FLG_DB)
                '売差率
                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Zen_Index, pm_All, SET_FLG_DB)
                Else
                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Zen_Index, pm_All, SET_FLG_DB)
                End If
                'change 20190329 END saiki
            End With
			
			'行情報構造体配列の Redim
			MaxPageNum = F_Ctl_Add_BlankRow(pm_All)
			
			NowPageNum = 1
		End If
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		' 2007/03/04  ADD START  KUMEDA
		Call CF_Clr_Prompt(pm_All)
		' 2007/03/04  ADD END
		
		F_GET_BD_DATA_BMN_SOUKATU2 = intCnt
		
		Exit Function
		
ERR_F_GET_BD_DATA_BMN_SOUKATU2: 
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_KIS_SOUKATU_JUC_SQL
	'   概要：  データ取得ＳＱＬ生成（機種別総括表：受注）
	'   引数：　pm_Kind         1:月初日、2:期首日
	'   戻値：　生成SQL
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_KIS_SOUKATU_JUC_SQL(ByVal pm_Kind As String) As String
		
		Dim strSQL As String
		Dim StartDate As String
		
		'検索開始日の取得
		StartDate = F_GET_FIRSTDAY(pm_Kind, GV_UNYDate)
		
		'検索ＳＱＬ発行
		strSQL = ""
		strSQL = strSQL & " Select "
		'2007/10/12 FKS)minamoto CHG START
		'strSQL = strSQL & "     WAKU.SYOHIN As SYOHIN "
		strSQL = strSQL & "     WAKU.SYOHINC As SYOHIN "
		'2007/10/12 FKS)minamoto CHG END
		strSQL = strSQL & "    ,WAKU.HGROUP As HGROUP "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "    ,WAKU.HGROUPNM As HGROUPNM "
		'2007/10/12 FKS)minamoto ADD END
		strSQL = strSQL & "    ,WAKU.FRNKB As FRNKB "
		strSQL = strSQL & "    ,WAKU.NAIGAI As NAIGAI "
		strSQL = strSQL & "    ,MAIN.UODSU As UODSU "
		strSQL = strSQL & "    ,Round(MAIN.UODKN) As UODKN "
		strSQL = strSQL & "    ,Round(MAIN.SIKKN) As SIKKN "
		strSQL = strSQL & " From "
		strSQL = strSQL & "     ( "
		strSQL = strSQL & "         Select "
		strSQL = strSQL & "             KSY.HINGRPRM "
		strSQL = strSQL & "            ,PSUM.FRNKB "
		strSQL = strSQL & "            ,Sum(PSUM.UODSU) As UODSU "
		strSQL = strSQL & "            ,Sum(PSUM.UODKN) As UODKN "
		strSQL = strSQL & "            ,Sum(PSUM.SIKKN) As SIKKN "
		strSQL = strSQL & "         From "
		strSQL = strSQL & "             ( "
		strSQL = strSQL & "                 Select "
		strSQL = strSQL & "                     PCODE "
		strSQL = strSQL & "                    ,FRNKB "
		strSQL = strSQL & "                    ,JDNDT "
		strSQL = strSQL & "                    ,Sum(UODSU) As UODSU "
		strSQL = strSQL & "                    ,Sum(UODKN) As UODKN "
		strSQL = strSQL & "                    ,Sum(SIKKN) As SIKKN "
		strSQL = strSQL & "                 From "
		strSQL = strSQL & "                     JDNDLA "
		strSQL = strSQL & "                 Where "
		strSQL = strSQL & "                     JDNDT >= '" & StartDate & "' "
		strSQL = strSQL & "                 And JDNDT <= '" & GV_UNYDate & "' "
		
		If Trim(gv_UODDL71_TIKCD) <> "" Then
			strSQL = strSQL & "                 And TIKKB = '" & gv_UODDL71_TIKCD & "' "
		End If
		
		If Trim(gv_UODDL71_EIGCD) <> "" Then
			strSQL = strSQL & "                 And EIGYOCD = '" & gv_UODDL71_EIGCD & "' "
		End If
		
		If Trim(gv_UODDL71_BMNCD) <> "" Then
			strSQL = strSQL & "                 And JIGYOBU = '" & gv_UODDL71_BMNCD & "' "
		End If
		
		strSQL = strSQL & "                 Group By "
		strSQL = strSQL & "                     PCODE "
		strSQL = strSQL & "                    ,FRNKB "
		strSQL = strSQL & "                    ,JDNDT "
		strSQL = strSQL & "             ) PSUM "
		strSQL = strSQL & "            ,( "
		strSQL = strSQL & "                 Select Distinct "
		'2007/12/07 FKS)minamoto CHG START
		'strSQL = strSQL & "                     HINGRPRM "
		'strSQL = strSQL & "                    ,PCODE "
		'2007/07/11  DLT START  KUMEDA
		''    strSQL = strSQL & "                    ,STTTKDT "
		''    strSQL = strSQL & "                    ,ENDTKDT "
		'2007/07/11  DLT END
		strSQL = strSQL & "                     K.HINGRPRM HINGRPRM "
		strSQL = strSQL & "                    ,K.PCODE    PCODE "
		strSQL = strSQL & "                    ,M.STTTKDT  STTTKDT "
		strSQL = strSQL & "                    ,M.ENDTKDT  ENDTKDT "
		'2007/12/07 FKS)minamoto CHG END
		strSQL = strSQL & "                 From "
		'2007/12/07 FKS)minamoto CHG START
		'strSQL = strSQL & "                     KSYMTA "
		strSQL = strSQL & "                     KSYMTA K, MEIMTC M "
		'2007/12/07 FKS)minamoto CHG END
		strSQL = strSQL & "                 Where "
		'2007/12/07 FKS)minamoto CHG START
		'strSQL = strSQL & "                     STTTKDT <= '" & GV_UNYDate & "' "
		'strSQL = strSQL & "                 And ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "                     K.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "                 And K.ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "                 And M.KEYCD = '" & pc_Syohin_Keycode & "' "
		strSQL = strSQL & "                 And K.HINGRPRM = M.MEINMB "
		'2007/12/07 FKS)minamoto CHG END
		strSQL = strSQL & "             ) KSY "
		strSQL = strSQL & "         Where "
		'2007/12/07 FKS)minamoto CHG START
		'2007/07/11  CHG START  KUMEDA
		''    strSQL = strSQL & "             KSY.STTTKDT <= PSUM.JDNDT "
		''    strSQL = strSQL & "         And KSY.ENDTKDT >= PSUM.JDNDT "
		''    strSQL = strSQL & "         And KSY.PCODE = PSUM.PCODE "
		'    strSQL = strSQL & "             KSY.PCODE = PSUM.PCODE "
		'2007/07/11  CHG END
		strSQL = strSQL & "             KSY.STTTKDT <= PSUM.JDNDT "
		strSQL = strSQL & "         And KSY.ENDTKDT >= PSUM.JDNDT "
		strSQL = strSQL & "         And KSY.PCODE = PSUM.PCODE "
		'2007/12/07 FKS)minamoto CHG END
		strSQL = strSQL & "         Group By "
		strSQL = strSQL & "             KSY.HINGRPRM "
		strSQL = strSQL & "            ,PSUM.FRNKB "
		strSQL = strSQL & "     ) MAIN "
		strSQL = strSQL & "    ,( "
		strSQL = strSQL & "         Select "
		strSQL = strSQL & "             MEI.MEINMB As SYOHIN "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "            ,MEI.MEINMC As SYOHINC "
		'2007/10/12 FKS)minamoto ADD END
		strSQL = strSQL & "            ,MEI.DSPORD As DSPORD "
		strSQL = strSQL & "            ,MEI.MEIKBA As HGROUP "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "            ,HG.MEINMA As HGROUPNM "
		'2007/10/12 FKS)minamoto ADD END
		strSQL = strSQL & "            ,FRN.FRNKB As FRNKB "
		strSQL = strSQL & "            ,FRN.NAIGAI As NAIGAI "
		strSQL = strSQL & "         From "
		strSQL = strSQL & "             MEIMTC MEI "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "             ,MEIMTC HG "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "            ,( "
		strSQL = strSQL & "                 Select '0' As FRNKB, '国内' As NAIGAI "
		strSQL = strSQL & "                 From DUAL "
		strSQL = strSQL & "                 Union "
		strSQL = strSQL & "                 Select '1' As FRNKB, '海外' As NAIGAI "
		strSQL = strSQL & "                 From DUAL "
		strSQL = strSQL & "             ) FRN "
		strSQL = strSQL & "         Where "
		strSQL = strSQL & "             MEI.KEYCD = '" & pc_Syohin_Keycode & "' "
		strSQL = strSQL & "         And MEI.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEI.ENDTKDT >= '" & GV_UNYDate & "' "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "         And HG.KEYCD = '" & pc_Hgroup_Keycode & "' "
		strSQL = strSQL & "         And HG.MEIKBA = MEI.MEIKBA "
		strSQL = strSQL & "         And HG.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And HG.ENDTKDT >= '" & GV_UNYDate & "' "
		'2007/10/12 FKS)minamoto ADD END
		strSQL = strSQL & "     ) WAKU "
		strSQL = strSQL & " Where "
		strSQL = strSQL & "     MAIN.HINGRPRM(+) = WAKU.SYOHIN "
		strSQL = strSQL & " And MAIN.FRNKB(+) = WAKU.FRNKB "
		strSQL = strSQL & " Order By "
		strSQL = strSQL & "     WAKU.HGROUP "
		strSQL = strSQL & "    ,WAKU.DSPORD "
		strSQL = strSQL & "    ,WAKU.FRNKB "
		
		F_GET_KIS_SOUKATU_JUC_SQL = strSQL
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_KIS_SOUKATU_URI_SQL
	'   概要：  データ取得ＳＱＬ生成（機種別総括表：売上）
	'   引数：　pm_Kind         1:月初日、2:期首日
	'   戻値：　生成SQL
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_KIS_SOUKATU_URI_SQL(ByVal pm_Kind As String) As String
		
		Dim strSQL As String
		Dim StartDate As String
		
		'検索開始日の取得
		StartDate = F_GET_FIRSTDAY(pm_Kind, GV_UNYDate)
		
		'検索ＳＱＬ発行
		strSQL = ""
		strSQL = strSQL & " Select"
		'2007/10/12 FKS)minamoto CHG START
		'strSQL = strSQL & "     WAKU.SYOHIN As SYOHIN "
		strSQL = strSQL & "     WAKU.SYOHINC As SYOHIN "
		'2007/10/12 FKS)minamoto CHG END
		strSQL = strSQL & "    ,WAKU.HGROUP As HGROUP "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "    ,WAKU.HGROUPNM As HGROUPNM "
		'2007/10/12 FKS)minamoto ADD END
		strSQL = strSQL & "    ,WAKU.FRNKB As FRNKB "
		strSQL = strSQL & "    ,WAKU.NAIGAI As NAIGAI "
		strSQL = strSQL & "    ,MAIN.URISU As UODSU "
		strSQL = strSQL & "    ,Round(MAIN.URIKN) As UODKN "
		strSQL = strSQL & "    ,Round(MAIN.SIKKN) As SIKKN "
		strSQL = strSQL & " From "
		strSQL = strSQL & "     ( "
		strSQL = strSQL & "         Select "
		strSQL = strSQL & "             KSY.HINGRPRM "
		strSQL = strSQL & "            ,PSUM.FRNKB "
		strSQL = strSQL & "            ,Sum(PSUM.URISU) As URISU "
		strSQL = strSQL & "            ,Sum(PSUM.URIKN) As URIKN "
		strSQL = strSQL & "            ,Sum(PSUM.SIKKN) As SIKKN "
		strSQL = strSQL & "         From "
		strSQL = strSQL & "             ( "
		strSQL = strSQL & "                 Select "
		strSQL = strSQL & "                     PCODE "
		strSQL = strSQL & "                    ,FRNKB "
		strSQL = strSQL & "                    ,UDNDT "
		strSQL = strSQL & "                    ,Sum(URISU) As URISU "
		strSQL = strSQL & "                    ,Sum(URIKN) As URIKN "
		strSQL = strSQL & "                    ,Sum(SIKKN) As SIKKN "
		strSQL = strSQL & "                 From "
		strSQL = strSQL & "                     UDNDLA "
		strSQL = strSQL & "                 Where "
		strSQL = strSQL & "                     UDNDT >= '" & StartDate & "' "
		strSQL = strSQL & "                 And UDNDT <= '" & GV_UNYDate & "' "
		
		If Trim(gv_UODDL71_TIKCD) <> "" Then
			strSQL = strSQL & "                 And TIKKB = '" & gv_UODDL71_TIKCD & "' "
		End If
		
		If Trim(gv_UODDL71_EIGCD) <> "" Then
			strSQL = strSQL & "                 And EIGYOCD = '" & gv_UODDL71_EIGCD & "' "
		End If
		
		If Trim(gv_UODDL71_BMNCD) <> "" Then
			strSQL = strSQL & "                 And JIGYOBU = '" & gv_UODDL71_BMNCD & "' "
		End If
		
		strSQL = strSQL & "                 Group By "
		strSQL = strSQL & "                     PCODE "
		strSQL = strSQL & "                    ,FRNKB "
		strSQL = strSQL & "                    ,UDNDT "
		strSQL = strSQL & "             ) PSUM "
		strSQL = strSQL & "            ,( "
		strSQL = strSQL & "                 Select Distinct "
		'2007/12/07 FKS)minamoto CHG START
		'strSQL = strSQL & "                     HINGRPRM "
		'strSQL = strSQL & "                    ,PCODE "
		'2007/07/11  DLT START  KUMEDA
		''    strSQL = strSQL & "                    ,STTTKDT "
		''    strSQL = strSQL & "                    ,ENDTKDT "
		'2007/07/11  DLT END
		strSQL = strSQL & "                     K.HINGRPRM HINGRPRM "
		strSQL = strSQL & "                    ,K.PCODE    PCODE "
		strSQL = strSQL & "                    ,M.STTTKDT  STTTKDT "
		strSQL = strSQL & "                    ,M.ENDTKDT  ENDTKDT "
		'2007/12/07 FKS)minamoto CHG END
		strSQL = strSQL & "                 From "
		'2007/12/07 FKS)minamoto CHG START
		'strSQL = strSQL & "                     KSYMTA "
		strSQL = strSQL & "                     KSYMTA K, MEIMTC M "
		'2007/12/07 FKS)minamoto CHG END
		strSQL = strSQL & "                 Where "
		'2007/12/07 FKS)minamoto CHG START
		'strSQL = strSQL & "                     STTTKDT <= '" & GV_UNYDate & "' "
		'strSQL = strSQL & "                 And ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "                     K.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "                 And K.ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "                 And M.KEYCD = '" & pc_Syohin_Keycode & "' "
		strSQL = strSQL & "                 And K.HINGRPRM = M.MEINMB "
		'2007/12/07 FKS)minamoto CHG END
		strSQL = strSQL & "             ) KSY "
		strSQL = strSQL & "         Where "
		'2007/12/07 FKS)minamoto CHG START
		'2007/07/11  CHG START  KUMEDA
		''    strSQL = strSQL & "             KSY.STTTKDT <= PSUM.UDNDT "
		''    strSQL = strSQL & "         And KSY.ENDTKDT >= PSUM.UDNDT "
		''    strSQL = strSQL & "         And KSY.PCODE = PSUM.PCODE "
		'    strSQL = strSQL & "             KSY.PCODE = PSUM.PCODE "
		'2007/07/11  CHG END
		strSQL = strSQL & "             KSY.STTTKDT <= PSUM.UDNDT "
		strSQL = strSQL & "         And KSY.ENDTKDT >= PSUM.UDNDT "
		strSQL = strSQL & "         And KSY.PCODE = PSUM.PCODE "
		'2007/12/07 FKS)minamoto CHG END
		strSQL = strSQL & "         Group By "
		strSQL = strSQL & "             KSY.HINGRPRM "
		strSQL = strSQL & "            ,PSUM.FRNKB "
		strSQL = strSQL & "     ) MAIN "
		strSQL = strSQL & "    ,( "
		strSQL = strSQL & "         Select "
		strSQL = strSQL & "             MEI.MEINMB As SYOHIN "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "            ,MEI.MEINMC As SYOHINC "
		'2007/10/12 FKS)minamoto ADD END
		strSQL = strSQL & "            ,MEI.DSPORD As DSPORD "
		strSQL = strSQL & "            ,MEI.MEIKBA As HGROUP "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "            ,HG.MEINMA As HGROUPNM "
		'2007/10/12 FKS)minamoto ADD END
		strSQL = strSQL & "            ,FRN.FRNKB As FRNKB "
		strSQL = strSQL & "            ,FRN.NAIGAI As NAIGAI "
		strSQL = strSQL & "         From "
		strSQL = strSQL & "             MEIMTC MEI "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "             ,MEIMTC HG "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "            ,( "
		strSQL = strSQL & "                 Select '0' As FRNKB, '国内' As NAIGAI "
		strSQL = strSQL & "                 From DUAL "
		strSQL = strSQL & "                 Union "
		strSQL = strSQL & "                 Select '1' As FRNKB, '海外' As NAIGAI "
		strSQL = strSQL & "                 From DUAL "
		strSQL = strSQL & "             ) FRN "
		strSQL = strSQL & "         Where "
		strSQL = strSQL & "             MEI.KEYCD = '" & pc_Syohin_Keycode & "' "
		strSQL = strSQL & "         And MEI.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEI.ENDTKDT >= '" & GV_UNYDate & "' "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "         And HG.KEYCD = '" & pc_Hgroup_Keycode & "' "
		strSQL = strSQL & "         And HG.MEIKBA = MEI.MEIKBA "
		strSQL = strSQL & "         And HG.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And HG.ENDTKDT >= '" & GV_UNYDate & "' "
		'2007/10/12 FKS)minamoto ADD END
		strSQL = strSQL & "     ) WAKU "
		strSQL = strSQL & " Where "
		strSQL = strSQL & "     MAIN.HINGRPRM(+) = WAKU.SYOHIN "
		strSQL = strSQL & " And MAIN.FRNKB(+) = WAKU.FRNKB "
		strSQL = strSQL & " Order By "
		strSQL = strSQL & "     WAKU.HGROUP "
		strSQL = strSQL & "    ,WAKU.DSPORD "
		strSQL = strSQL & "    ,WAKU.FRNKB "
		
		F_GET_KIS_SOUKATU_URI_SQL = strSQL
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_BD_DATA_KIS_SOUKATU_JUC
	'   概要：  ボディ部データ取得（機種別総括表：受注）
	'   引数：  pm_Kind     1:月初日、2:期首日
	'           pm_All      :全構造体
	'   戻値：　取得行数
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_BD_DATA_KIS_SOUKATU_JUC(ByVal pm_Kind As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim Ret_Value As Short

        'delete 20190327 START saiki
		'ADD 20150710 START C2-20150708-01
        'Call F_Ctl_LAB_EXC(pm_All)
        'ADD 20150710 END C2-20150708-01
        'delete 20190327 END saiki
		
		'検索ＳＱＬ生成
		strSQL = F_GET_KIS_SOUKATU_JUC_SQL(pm_Kind)
		
		Ret_Value = F_GET_BD_DATA_KIS_SOUKATU(strSQL, pm_All)
		
		'ADD 20150710 START C2-20150708-01
		'UPGRADE_ISSUE: Control lab_exc は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'delete 20190325 START saiki
        'If pm_All.Dsp_Base.FormCtl.lab_exc.Visible = False Then
        '    Call F_Ctl_LAB_EXC(pm_All)
        'End If
        'delete 20190325 END saiki
		'ADD 20150710 END C2-20150708-01
		
		F_GET_BD_DATA_KIS_SOUKATU_JUC = Ret_Value
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_BD_DATA_KIS_SOUKATU_URI
	'   概要：  ボディ部データ取得（機種別総括表：売上）
	'   引数：  pm_Kind     1:月初日、2:期首日
	'           pm_All      :全構造体
	'   戻値：　取得行数
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_BD_DATA_KIS_SOUKATU_URI(ByVal pm_Kind As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim Ret_Value As Short

        'delete 20190327 START saiki
		'ADD 20150710 START C2-20150708-01
        'Call F_Ctl_LAB_EXC(pm_All)
        'ADD 20150710 END C2-20150708-01
        'delete 20190327 END saiki
		
		'検索ＳＱＬ生成
		strSQL = F_GET_KIS_SOUKATU_URI_SQL(pm_Kind)
		
		Ret_Value = F_GET_BD_DATA_KIS_SOUKATU(strSQL, pm_All)
		
		'ADD 20150710 START C2-20150708-01
		'UPGRADE_ISSUE: Control lab_exc は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'delete 20190325 START saiki
        'If pm_All.Dsp_Base.FormCtl.lab_exc.Visible = False Then
        '    Call F_Ctl_LAB_EXC(pm_All)
        'End If
        'delete 20190325 END saiki
		'ADD 20150710 END C2-20150708-01
		
		F_GET_BD_DATA_KIS_SOUKATU_URI = Ret_Value
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_BD_DATA_BMN_SOUKATU
	'   概要：  ボディ部データ取得（部門別総括表）
	'   引数：  pm_Kind     1:月初日、2:期首日
	'           pm_All      :全構造体
	'   戻値：　取得行数
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_BD_DATA_KIS_SOUKATU(ByVal pm_SQL As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim intMode As Short
		Dim intCnt As Short
		Dim Wk_Index As Short
		Dim Err_Cd As String
		Dim intRowCnt As Short
		Dim intKisCnt As Short
		Dim KisGokei() As UODDL71_TYPE_KISSOU
		' 2007/01/13  ADD START  KUMEDA
		Dim KisGokeiNai() As UODDL71_TYPE_KISSOU
		Dim KisGokeiGai() As UODDL71_TYPE_KISSOU
		Dim SumGokeiNai As UODDL71_TYPE_KISSOU
		Dim SumGokeiGai As UODDL71_TYPE_KISSOU
		' 2007/01/13  ADD END
		Dim SumGokei As UODDL71_TYPE_KISSOU
		Dim Wk_KisCd As String
		Dim Wk_DivNm As String
		Dim Wk_DivRn As String
		' 2007/01/10  ADD START  KUMEDA
		Dim Wk_GrpCd As String
		' 2007/01/10  ADD END
		' 2007/01/12  ADD START  KUMEDA
		Dim bufRowCnt As Short
		Dim sumUODSU As Decimal
		Dim sumUODKN As Decimal
		Dim sumSIKKN As Decimal
		Dim sumBAISA As Decimal
		
		bufRowCnt = 0
		sumUODSU = 0
		sumUODKN = 0
		sumSIKKN = 0
		sumBAISA = 0
		' 2007/01/12  ADD END
		' 2007/01/13  ADD START  KUMEDA
		Dim bufGrpCnt As Short
		Dim bufGrpCntNai As Short
		Dim bufGrpCntGai As Short
		' 2007/01/13  ADD END
		
		On Error GoTo ERR_F_GET_BD_DATA_KIS_SOUKATU
		F_GET_BD_DATA_KIS_SOUKATU = -1

        ' 2007/03/04  ADD START  KUMEDA
        'delete 20190403 START saiki
        'Call FR_SSSMAIN1.Ctl_MN_APPENDC_Click()
        'delete 20190403 END saiki
        Call CF_Set_Prompt(DATE_GET_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), pm_All)
		System.Windows.Forms.Application.DoEvents()
		' 2007/03/04  ADD END
		
		'初期化
		Err_Cd = ""
        Wk_KisCd = ""
        'ADD 20190403 START saiki
        Wk_GrpCd = ""
        'ADD 20190403 END saiki
        ReDim KisGokei(0)
		' 2007/01/13  ADD START  KUMEDA
		ReDim KisGokeiNai(0)
		ReDim KisGokeiGai(0)
        ' 2007/01/13  ADD END

        'change 20190403  START saiki
        '部門or地区or営業所 取得
        'If Trim(gv_UODDL71_BMNCD) <> "" Then
        '	Wk_DivNm = "部門"
        '	'UPGRADE_ISSUE: Control HD_BMNNM は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '	Wk_DivRn = pm_All.Dsp_Base.FormCtl.HD_BMNNM.Text
        'ElseIf Trim(gv_UODDL71_TIKCD) <> "" Then 
        '	Wk_DivNm = "地区"
        '	'UPGRADE_ISSUE: Control HD_TIKNM は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '	Wk_DivRn = pm_All.Dsp_Base.FormCtl.HD_TIKNM.Text
        'ElseIf Trim(gv_UODDL71_EIGCD) <> "" Then 
        '	Wk_DivNm = "営業所"
        '	'UPGRADE_ISSUE: Control HD_EIGNM は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '	Wk_DivRn = pm_All.Dsp_Base.FormCtl.HD_EIGNM.Text
        'Else
        '	Wk_DivNm = "全社"
        '	Wk_DivRn = "全社"
        'End If

        '部門or地区or営業所 取得
        If Trim(gv_UODDL71_BMNCD) <> "" Then
            Wk_DivNm = "部門"
            'UPGRADE_ISSUE: Control HD_BMNNM は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            Wk_DivRn = UODDL71.HD_BMNNM.Text
        ElseIf Trim(gv_UODDL71_TIKCD) <> "" Then
            Wk_DivNm = "地区"
            'UPGRADE_ISSUE: Control HD_TIKNM は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            Wk_DivRn = UODDL71.HD_TIKNM.Text
        ElseIf Trim(gv_UODDL71_EIGCD) <> "" Then
            Wk_DivNm = "営業所"
            'UPGRADE_ISSUE: Control HD_EIGNM は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            Wk_DivRn = UODDL71.HD_EIGNM.Text
        Else
            Wk_DivNm = "全社"
            Wk_DivRn = "全社"
        End If
        'change 20190403  END saiki

        '検索ＳＱＬ生成
        strSQL = pm_SQL

        'DBアクセス
        'change 20190326 START saiki
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        dt = Nothing
        dt = DB_GetTable(strSQL)
        'change 20190326 END saiki

        'change 20190403 START saiki
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            'change 20190403 END saiki
            '取得データなし
            F_GET_BD_DATA_KIS_SOUKATU = 0
            Err_Cd = gc_strMsgUODDL71_E_002
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)

            Exit Function
        Else

            intCnt = 0

            'change 20190403 START saiki
            'Do Until CF_Ora_EOF(Usr_Ody) = True
            '    '取得全レコードよりボディ情報退避
            '    intCnt = intCnt + 1
            '    '行追加
            '    ReDim Preserve UODDL71_KISSOU_Inf(intCnt)

            '    With UODDL71_KISSOU_Inf(intCnt)
            '        ' 2007/01/10  ADD START  KUMEDA
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .HGROUP = CF_Ora_GetDyn(Usr_Ody, "HGROUP", "") '商品集計グループ
            '        ' 2007/01/10  ADD END
            '        '2007/10/12 FKS)minamoto ADD START
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .HGROUPNM = CF_Ora_GetDyn(Usr_Ody, "HGROUPNM", "") '商品集計グループ名称
            '        '2007/10/12 FKS)minamoto ADD END
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .SYOHIN = CF_Ora_GetDyn(Usr_Ody, "SYOHIN", "") '商品
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .NAIGAICD = CF_Ora_GetDyn(Usr_Ody, "FRNKB", "") '国内外コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .NAIGAINM = CF_Ora_GetDyn(Usr_Ody, "NAIGAI", "") '国内外
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .UODSU = CF_Ora_GetDyn(Usr_Ody, "UODSU", 0) '受注数量
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .UODKN = CF_Ora_GetDyn(Usr_Ody, "UODKN", 0) '受注金額
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .SIKKN = CF_Ora_GetDyn(Usr_Ody, "SIKKN", 0) '仕切
            '        .BAISA = .UODKN - .SIKKN '売差
            '    End With

            '    '次レコード
            '    Call CF_Ora_MoveNext(Usr_Ody)
            'Loop

            For Each row As DataRow In dt.Rows
                '取得全レコードよりボディ情報退避
                intCnt = intCnt + 1
                '行追加
                ReDim Preserve UODDL71_KISSOU_Inf(intCnt)

                With UODDL71_KISSOU_Inf(intCnt)
                    ' 2007/01/10  ADD START  KUMEDA
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HGROUP = DB_NullReplace(row("HGROUP"), "") '商品集計グループ
                    ' 2007/01/10  ADD END
                    '2007/10/12 FKS)minamoto ADD START
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HGROUPNM = DB_NullReplace(row("HGROUPNM"), "") '商品集計グループ名称
                    '2007/10/12 FKS)minamoto ADD END
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .SYOHIN = DB_NullReplace(row("SYOHIN"), "") '商品
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .NAIGAICD = DB_NullReplace(row("FRNKB"), "") '国内外コード
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .NAIGAINM = DB_NullReplace(row("NAIGAI"), "") '国内外
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .UODSU = DB_NullReplace(row("UODSU"), 0) '受注数量
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .UODKN = DB_NullReplace(row("UODKN"), 0) '受注金額
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .SIKKN = DB_NullReplace(row("SIKKN"), 0) '仕切
                    .BAISA = .UODKN - .SIKKN '売差
                End With

            Next
            'change 20190403 END saiki


            intRowCnt = 0
			intKisCnt = 0
			
			'部門or地区or営業所名称行を作成
			'行追加
			intRowCnt = intRowCnt + 1
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
			'行項目情報コピー
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			
			pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
			pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = Wk_DivRn

            '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
            '名称
            'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

            'change 20190325 START saiki
            'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
            Wk_Index = CShort(UODDL71.BD_MEISYO(1).Tag)
            'change 20190325 END saiki
            Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
			
			For intData = 1 To intCnt
				With UODDL71_KISSOU_Inf(intData)
					' 2007/01/10  CHG START  KUMEDA
					''                '前データの商品群１桁目と異なる場合
					''                If Left(Wk_KisCd, 1) <> Left(.SYOHIN, 1) Then
					'前データの商品集計グループと異なる場合
					If Wk_GrpCd <> .HGROUP Then
						' 2007/01/10  CHG END
						'最初の商品群でない場合、前の商品群の合計行を作成
						If Trim(Wk_KisCd) <> "" Then
							' 2007/01/13  CHG START  KUMEDA   ---> intRowCnt を bufGrpCnt に変更
							With pm_All.Dsp_Body_Inf.Row_Inf(bufGrpCnt).Bus_Inf
								.Selected = CStr(False)
								.MEISYO = KisGokei(intKisCnt).SYOHIN '商品群
								.DIVISION = "1"
								.BD_UODSU_T = KisGokei(intKisCnt).UODSU '受注数
								.BD_UODKN_T = KisGokei(intKisCnt).UODKN '受注金額
								.BD_SIKKN_T = KisGokei(intKisCnt).SIKKN '仕切
								.BD_BAISA_T = KisGokei(intKisCnt).BAISA '売差
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
								End If

                                'change 20190403  START saiki
                                ''画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                                ''名称
                                ''UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                ''受注数
                                ''UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                ''受注金額
                                ''UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                ''仕切
                                ''UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                ''売差
                                ''UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                ''売差率
                                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                '	'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                'Else
                                '	'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                '                        End If


                                '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                                '名称
                                'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL71.BD_MEISYO(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                '受注数
                                'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL71.BD_UODSU(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                '受注金額
                                'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL71.BD_UODKN(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                '仕切
                                'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL71.BD_SIKKN(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                '売差
                                'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL71.BD_BAISA(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                '売差率
                                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                Else
                                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                End If
                                'change 20190403  END saiki
                            End With
							'---> 国内、海外データの合計行追加
							With pm_All.Dsp_Body_Inf.Row_Inf(bufGrpCntNai).Bus_Inf
								.Selected = CStr(False)
								.MEISYO = KisGokeiNai(intKisCnt).SYOHIN '商品群
								.DIVISION = "2"
								.BD_UODSU_T = KisGokeiNai(intKisCnt).UODSU '受注数
								.BD_UODKN_T = KisGokeiNai(intKisCnt).UODKN '受注金額
								.BD_SIKKN_T = KisGokeiNai(intKisCnt).SIKKN '仕切
								.BD_BAISA_T = KisGokeiNai(intKisCnt).BAISA '売差
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
								End If

                                'change 20190403  START saiki
                                ''画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                                ''名称
                                ''UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                ''受注数
                                ''UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                ''受注金額
                                ''UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                ''仕切
                                ''UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                ''売差
                                ''UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                ''売差率
                                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                '	'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                'Else
                                '	'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                '                        End If

                                '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                                '名称
                                'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL71.BD_MEISYO(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                '受注数
                                'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL71.BD_UODSU(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                '受注金額
                                'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL71.BD_UODKN(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                '仕切
                                'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL71.BD_SIKKN(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                '売差
                                'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL71.BD_BAISA(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                '売差率
                                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                Else
                                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                                        End If
                                'change 20190403 END saiki
                            End With
							
							With pm_All.Dsp_Body_Inf.Row_Inf(bufGrpCntGai).Bus_Inf
								.Selected = CStr(False)
								.MEISYO = KisGokeiGai(intKisCnt).SYOHIN '商品群
								.DIVISION = "2"
								.BD_UODSU_T = KisGokeiGai(intKisCnt).UODSU '受注数
								.BD_UODKN_T = KisGokeiGai(intKisCnt).UODKN '受注金額
								.BD_SIKKN_T = KisGokeiGai(intKisCnt).SIKKN '仕切
								.BD_BAISA_T = KisGokeiGai(intKisCnt).BAISA '売差
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
								End If

                                'change 20190403  START saiki
                                ''画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                                ''名称
                                ''UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                ''受注数
                                ''UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                ''受注金額
                                ''UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                ''仕切
                                ''UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                ''売差
                                ''UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                ''売差率
                                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                '	'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                'Else
                                '	'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                '                        End If

                                '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                                '名称
                                'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL71.BD_MEISYO(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                '受注数
                                'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL71.BD_UODSU(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                '受注金額
                                'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL71.BD_UODKN(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                '仕切
                                'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL71.BD_SIKKN(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                '売差
                                'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL71.BD_BAISA(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                '売差率
                                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                Else
                                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                End If
                                'change 20190403  END saiki

                            End With
							'<--- 国内、海外データの合計行追加
							'空白行追加
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'行項目情報コピー
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							'商品群合計行追加
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'行項目情報コピー
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							'商品群合計行の退避
							bufGrpCnt = intRowCnt
							
							'商品群（国内）合計行追加
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'行項目情報コピー
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							'商品群合計行の退避
							bufGrpCntNai = intRowCnt
							
							'商品群（海外）合計行追加
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'行項目情報コピー
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							'商品群合計行の退避
							bufGrpCntGai = intRowCnt
							' 2007/01/13  CHG END
							
							' 2007/01/13  ADD START  KUMEDA
						Else
							'商品群合計行追加
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'行項目情報コピー
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							'商品群合計行の退避
							bufGrpCnt = intRowCnt
							
							'商品群（国内）合計行追加
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'行項目情報コピー
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							'商品群合計行の退避
							bufGrpCntNai = intRowCnt
							
							'商品群（海外）合計行追加
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'行項目情報コピー
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							'商品群合計行の退避
							bufGrpCntGai = intRowCnt
							' 2007/01/13  ADD END
						End If
						
						'商品群のカウント
						intKisCnt = intKisCnt + 1
						'商品群合計計算用
						ReDim Preserve KisGokei(intKisCnt)
						' 2007/03/04  CHG START  KUMEDA
						'                    KisGokei(intKisCnt).SYOHIN = "　　" & Left(.SYOHIN, 1) & "合計" '商品群
						'2007/10/12 FKS)minamoto CHG START
						'                    KisGokei(intKisCnt).SYOHIN = "　　" & Left(.SYOHIN, 1) & "計" '商品群
						KisGokei(intKisCnt).SYOHIN = "　　" & Trim(.HGROUPNM) & "計" '商品集計グループ名称
						'2007/10/12 FKS)minamoto CHG END
						' 2007/03/04  CHG END
						KisGokei(intKisCnt).UODSU = 0 '受注数量
						KisGokei(intKisCnt).UODKN = 0 '受注金額
						KisGokei(intKisCnt).SIKKN = 0 '仕切
						KisGokei(intKisCnt).BAISA = 0 '売差
						'Invalid_string_refer_to_original_code
						'商品群合計計算用
						ReDim Preserve KisGokeiNai(intKisCnt)
						KisGokeiNai(intKisCnt).SYOHIN = "　　" & "　　国内" '商品群
						KisGokeiNai(intKisCnt).UODSU = 0 '受注数量
						KisGokeiNai(intKisCnt).UODKN = 0 '受注金額
						KisGokeiNai(intKisCnt).SIKKN = 0 '仕切
						KisGokeiNai(intKisCnt).BAISA = 0 '売差
						'商品群合計計算用
						ReDim Preserve KisGokeiGai(intKisCnt)
						KisGokeiGai(intKisCnt).SYOHIN = "　　" & "　　海外" '商品群
						KisGokeiGai(intKisCnt).UODSU = 0 '受注数量
						KisGokeiGai(intKisCnt).UODKN = 0 '受注金額
						KisGokeiGai(intKisCnt).SIKKN = 0 '仕切
						KisGokeiGai(intKisCnt).BAISA = 0 '売差
						' 2007/01/13  ADD END
						
					End If
					
					'前データの商品群と異なる場合
					If Wk_KisCd <> .SYOHIN Then
						'行追加
						intRowCnt = intRowCnt + 1
						
						ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
						'行項目情報コピー
						Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
						
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = "　　" & .SYOHIN

                        '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                        '名称
                        'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                        'change 20190403 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                        Wk_Index = CShort(UODDL71.BD_MEISYO(1).Tag)
                        'change 20190403 END saiki
                        Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						' 2007/01/12  ADD START  KUMEDA   *** 商品群合計追加
						If bufRowCnt <> 0 Then
							pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.DIVISION = "3"
							pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.BD_UODSU_T = sumUODSU
							pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.BD_UODKN_T = sumUODKN
							pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.BD_SIKKN_T = sumSIKKN
							pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.BD_BAISA_T = sumBAISA
							If sumUODKN = 0 Then
								pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.BD_BSART_T = 0
							Else
								pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.BD_BSART_T = System.Math.Round(sumBAISA / sumUODKN * 100, 1)
							End If

                            'change 20190403 START saiki
                            'With pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf
                            '	'受注数
                            '	'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                            '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                            '	Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                            '	'受注金額
                            '	'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                            '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                            '	Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                            '	'仕切
                            '	'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                            '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                            '	Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                            '	'売差
                            '	'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                            '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                            '	Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                            '	'売差率
                            '	If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                            '		'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                            '		Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                            '		Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                            '	Else
                            '		'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                            '		Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                            '		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                            '	End If
                            '                     End With


                            With pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf
                                '受注数
                                'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL71.BD_UODSU(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                                '受注金額
                                'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL71.BD_UODKN(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                                '仕切
                                'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL71.BD_SIKKN(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                                '売差
                                'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL71.BD_BAISA(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                                '売差率
                                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                                Else
                                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                                End If
                            End With
                            'change 20190403 END saiki
                        End If
						'商品群合計ワークの初期化
						bufRowCnt = intRowCnt
						sumUODSU = 0
						sumUODKN = 0
						sumSIKKN = 0
						sumBAISA = 0
						' 2007/01/12  ADD END
					End If
					
					'行追加
					intRowCnt = intRowCnt + 1
					ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
					'行項目情報コピー
					Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
					
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = "　　　　" & .NAIGAINM
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVISION = "2"
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_UODSU_T = .UODSU '受注数
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_UODKN_T = .UODKN '受注金額
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_SIKKN_T = .SIKKN '仕切
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_BAISA_T = .BAISA '売差
					If .UODKN = 0 Then
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_BSART_T = 0
					Else
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_BSART_T = System.Math.Round(.BAISA / .UODKN * 100, 1) '売差率
					End If
					
					' 2007/01/12  ADD START  KUMEDA   *** 商品群合計
					sumUODSU = sumUODSU + .UODSU
					sumUODKN = sumUODKN + .UODKN
					sumSIKKN = sumSIKKN + .SIKKN
					sumBAISA = sumBAISA + .BAISA
                    ' 2007/01/12  ADD END

                    'change 20190403 START saiki
                    ''画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                    'With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
                    '	'名称
                    '	'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                    '	Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '	'受注数
                    '	'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                    '	Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '	'受注金額
                    '	'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                    '	Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '	'仕切
                    '	'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                    '	Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '	'売差
                    '	'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                    '	Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '	'売差率
                    '	If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    '		'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    '		Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                    '		Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '	Else
                    '		'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    '		Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                    '		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '	End If
                    '               End With


                    '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                    With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
                        '名称
                        'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        Wk_Index = CShort(UODDL71.BD_MEISYO(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        '受注数
                        'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        Wk_Index = CShort(UODDL71.BD_UODSU(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        '受注金額
                        'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        Wk_Index = CShort(UODDL71.BD_UODKN(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        '仕切
                        'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        Wk_Index = CShort(UODDL71.BD_SIKKN(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        '売差
                        'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        Wk_Index = CShort(UODDL71.BD_BAISA(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        '売差率
                        If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                            'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                            Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                            Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        Else
                            'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                            Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                            Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        End If
                    End With
                    'change 20190403 END saiki

                    '商品群合計計算
                    KisGokei(intKisCnt).UODSU = KisGokei(intKisCnt).UODSU + .UODSU '受注数量
					KisGokei(intKisCnt).UODKN = KisGokei(intKisCnt).UODKN + .UODKN '受注金額
					KisGokei(intKisCnt).SIKKN = KisGokei(intKisCnt).SIKKN + .SIKKN '仕切
					KisGokei(intKisCnt).BAISA = KisGokei(intKisCnt).BAISA + .BAISA '売差
					' 2007/01/13  ADD START  KUMEDA
					If .NAIGAICD = "0" Then '国内合計
						KisGokeiNai(intKisCnt).UODSU = KisGokeiNai(intKisCnt).UODSU + .UODSU '受注数量
						KisGokeiNai(intKisCnt).UODKN = KisGokeiNai(intKisCnt).UODKN + .UODKN '受注金額
						KisGokeiNai(intKisCnt).SIKKN = KisGokeiNai(intKisCnt).SIKKN + .SIKKN '仕切
						KisGokeiNai(intKisCnt).BAISA = KisGokeiNai(intKisCnt).BAISA + .BAISA '売差
					Else
						KisGokeiGai(intKisCnt).UODSU = KisGokeiGai(intKisCnt).UODSU + .UODSU '受注数量
						KisGokeiGai(intKisCnt).UODKN = KisGokeiGai(intKisCnt).UODKN + .UODKN '受注金額
						KisGokeiGai(intKisCnt).SIKKN = KisGokeiGai(intKisCnt).SIKKN + .SIKKN '仕切
						KisGokeiGai(intKisCnt).BAISA = KisGokeiGai(intKisCnt).BAISA + .BAISA '売差
					End If
					' 2007/01/13  ADD END
					
					'今データの退避
					Wk_KisCd = .SYOHIN
					' 2007/01/10  ADD START  KUMEDA
					Wk_GrpCd = .HGROUP
					' 2007/01/10  ADD END
				End With
			Next 
			
			' 2007/01/12  ADD START  KUMEDA   *** 最終の商品群の合計追加
			If bufRowCnt <> 0 Then
				pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.DIVISION = "3"
				pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.BD_UODSU_T = sumUODSU
				pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.BD_UODKN_T = sumUODKN
				pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.BD_SIKKN_T = sumSIKKN
				pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.BD_BAISA_T = sumBAISA
				If sumUODKN = 0 Then
					pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.BD_BSART_T = 0
				Else
					pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.BD_BSART_T = System.Math.Round(sumBAISA / sumUODKN * 100, 1)
				End If

                'change 20190325 START saiki
                'With pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf
                '	'受注数
                '	'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                '	'受注金額
                '	'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                '	'仕切
                '	'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                '	'売差
                '	'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                '	'売差率
                '	If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                '		'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                '		Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '		Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                '	Else
                '		'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                '		Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                '	End If
                '            End With


                With pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf
                    '受注数
                    'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL71.BD_UODSU(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                    '受注金額
                    'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL71.BD_UODKN(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                    '仕切
                    'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL71.BD_SIKKN(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                    '売差
                    'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL71.BD_BAISA(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                    '売差率
                    If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                        'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                    Else
                        'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                    End If
                End With
                'change 20190325 END saiki
            End If
			' 2007/01/12  ADD END
			
			' 2007/01/13  CHG START  KUMEDA   ---> intRowCnt を bufGrpCnt に変更
			'最終の商品群グループの合計行を作成
			'行追加
			''        intRowCnt = intRowCnt + 1
			''        ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
			''        '行項目情報コピー
			''        Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			
			With pm_All.Dsp_Body_Inf.Row_Inf(bufGrpCnt).Bus_Inf
				.Selected = CStr(False)
				.MEISYO = KisGokei(intKisCnt).SYOHIN '商品群
				.DIVISION = "1"
				.BD_UODSU_T = KisGokei(intKisCnt).UODSU '受注数
				.BD_UODKN_T = KisGokei(intKisCnt).UODKN '受注金額
				.BD_SIKKN_T = KisGokei(intKisCnt).SIKKN '仕切
				.BD_BAISA_T = KisGokei(intKisCnt).BAISA '売差
				If .BD_UODKN_T = 0 Then
					.BD_BSART_T = 0
				Else
					.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
				End If

                'change 20190325 START saiki
                ''画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                ''名称
                ''UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                ''受注数
                ''UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                ''受注金額
                ''UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                ''仕切
                ''UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                ''売差
                ''UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                ''売差率
                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                '	'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                'Else
                '	'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                '            End If


                '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                '名称
                'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_MEISYO(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                '受注数
                'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_UODSU(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                '受注金額
                'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_UODKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                '仕切
                'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_SIKKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                '売差
                'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_BAISA(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                '売差率
                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                Else
                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                End If
                'change 20190325 END saiki
            End With
			'---> 国内、海外データの合計行追加
			With pm_All.Dsp_Body_Inf.Row_Inf(bufGrpCntNai).Bus_Inf
				.Selected = CStr(False)
				.MEISYO = KisGokeiNai(intKisCnt).SYOHIN '商品群
				.DIVISION = "2"
				.BD_UODSU_T = KisGokeiNai(intKisCnt).UODSU '受注数
				.BD_UODKN_T = KisGokeiNai(intKisCnt).UODKN '受注金額
				.BD_SIKKN_T = KisGokeiNai(intKisCnt).SIKKN '仕切
				.BD_BAISA_T = KisGokeiNai(intKisCnt).BAISA '売差
				If .BD_UODKN_T = 0 Then
					.BD_BSART_T = 0
				Else
					.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
				End If

                'change 20190325 START saiki
                ''画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                ''名称
                ''UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                ''受注数
                ''UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                ''受注金額
                ''UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                ''仕切
                ''UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                ''売差
                ''UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                ''売差率
                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                '	'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                'Else
                '	'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                '            End If

                '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                '名称
                'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_MEISYO(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                '受注数
                'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_UODSU(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                '受注金額
                'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_UODKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                '仕切
                'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_SIKKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                '売差
                'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_BAISA(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                '売差率
                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                Else
                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                End If
                'change 20190325 END saiki
            End With
			
			With pm_All.Dsp_Body_Inf.Row_Inf(bufGrpCntGai).Bus_Inf
				.Selected = CStr(False)
				.MEISYO = KisGokeiGai(intKisCnt).SYOHIN '商品群
				.DIVISION = "2"
				.BD_UODSU_T = KisGokeiGai(intKisCnt).UODSU '受注数
				.BD_UODKN_T = KisGokeiGai(intKisCnt).UODKN '受注金額
				.BD_SIKKN_T = KisGokeiGai(intKisCnt).SIKKN '仕切
				.BD_BAISA_T = KisGokeiGai(intKisCnt).BAISA '売差
				If .BD_UODKN_T = 0 Then
					.BD_BSART_T = 0
				Else
					.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
				End If

                'change 20190325 START saiki
                ''画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                ''名称
                ''UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                ''受注数
                ''UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                ''受注金額
                ''UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                ''仕切
                ''UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                ''売差
                ''UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                ''売差率
                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                '	'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                'Else
                '	'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                '            End If


                '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                '名称
                'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_MEISYO(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                '受注数
                'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_UODSU(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                '受注金額
                'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_UODKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                '仕切
                'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_SIKKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                '売差
                'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_BAISA(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                '売差率
                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                Else
                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                End If
                'change 20190325 END saiki
            End With
			'<--- 国内、海外データの合計行追加
			' 2007/01/13  CHG END
			
			'合計計算
			For intData = 1 To intKisCnt
				SumGokei.UODSU = SumGokei.UODSU + KisGokei(intData).UODSU '受注数量
				SumGokei.UODKN = SumGokei.UODKN + KisGokei(intData).UODKN '受注金額
				SumGokei.SIKKN = SumGokei.SIKKN + KisGokei(intData).SIKKN '仕切
				SumGokei.BAISA = SumGokei.BAISA + KisGokei(intData).BAISA '売差
				' 2007/01/13  ADD START  KUMEDA   '国内合計、海外合計
				SumGokeiNai.UODSU = SumGokeiNai.UODSU + KisGokeiNai(intData).UODSU '受注数量
				SumGokeiNai.UODKN = SumGokeiNai.UODKN + KisGokeiNai(intData).UODKN '受注金額
				SumGokeiNai.SIKKN = SumGokeiNai.SIKKN + KisGokeiNai(intData).SIKKN '仕切
				SumGokeiNai.BAISA = SumGokeiNai.BAISA + KisGokeiNai(intData).BAISA '売差
				SumGokeiGai.UODSU = SumGokeiGai.UODSU + KisGokeiGai(intData).UODSU '受注数量
				SumGokeiGai.UODKN = SumGokeiGai.UODKN + KisGokeiGai(intData).UODKN '受注金額
				SumGokeiGai.SIKKN = SumGokeiGai.SIKKN + KisGokeiGai(intData).SIKKN '仕切
				SumGokeiGai.BAISA = SumGokeiGai.BAISA + KisGokeiGai(intData).BAISA '売差
				' 2007/01/13  ADD END
			Next 
			
			'合計行の作成
			' 2007/01/13  ADD START  KUMEDA
			'空白行追加
			intRowCnt = intRowCnt + 1
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
			'行項目情報コピー
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			' 2007/01/13  ADD END
			
			'行追加
			intRowCnt = intRowCnt + 1
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
			'行項目情報コピー
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			
			With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
				.Selected = CStr(False)
				.MEISYO = Wk_DivNm & "合計"
				.DIVISION = "99"
				.BD_UODSU_T = SumGokei.UODSU '受注数
				.BD_UODKN_T = SumGokei.UODKN '受注金額
				.BD_SIKKN_T = SumGokei.SIKKN '仕切
				.BD_BAISA_T = SumGokei.BAISA '売差
				If .BD_UODKN_T = 0 Then
					.BD_BSART_T = 0
				Else
					.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
				End If

                'change 20190325 START saiki
                ''画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                ''名称
                ''UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''受注数
                ''UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''受注金額
                ''UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''仕切
                ''UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''売差
                ''UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''売差率
                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                '	'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                'Else
                '	'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '            End If


                '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                '名称
                'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_MEISYO(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '受注数
                'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_UODSU(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '受注金額
                'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_UODKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '仕切
                'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_SIKKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '売差
                'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_BAISA(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '売差率
                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                Else
                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                End If
                'change 20190325 END saiki
            End With
			
			'---> 国内合計、海外合計の表示追加
			'行追加
			intRowCnt = intRowCnt + 1
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
			'行項目情報コピー
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			
			With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
				.Selected = CStr(False)
				.MEISYO = "　　" & "　　国内" '商品群
				.DIVISION = "2"
				.BD_UODSU_T = SumGokeiNai.UODSU '受注数
				.BD_UODKN_T = SumGokeiNai.UODKN '受注金額
				.BD_SIKKN_T = SumGokeiNai.SIKKN '仕切
				.BD_BAISA_T = SumGokeiNai.BAISA '売差
				If .BD_UODKN_T = 0 Then
					.BD_BSART_T = 0
				Else
					.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
				End If

                'change 20190325 START saiki
                ''画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                ''名称
                ''UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''受注数
                ''UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''受注金額
                ''UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''仕切
                ''UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''売差
                ''UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''売差率
                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                '	'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                'Else
                '	'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '            End If


                '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                '名称
                'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_MEISYO(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '受注数
                'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_UODSU(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '受注金額
                'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_UODKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '仕切
                'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_SIKKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '売差
                'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_BAISA(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '売差率
                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                Else
                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                End If
                'change 20190325 END saiki
            End With
			
			'行追加
			intRowCnt = intRowCnt + 1
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
			'行項目情報コピー
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			
			With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
				.Selected = CStr(False)
				.MEISYO = "　　" & "　　海外" '商品群
				.DIVISION = "2"
				.BD_UODSU_T = SumGokeiGai.UODSU '受注数
				.BD_UODKN_T = SumGokeiGai.UODKN '受注金額
				.BD_SIKKN_T = SumGokeiGai.SIKKN '仕切
				.BD_BAISA_T = SumGokeiGai.BAISA '売差
				If .BD_UODKN_T = 0 Then
					.BD_BSART_T = 0
				Else
					.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
				End If

                'change 20190325 START saiki
                ''画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                ''名称
                ''UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''受注数
                ''UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''受注金額
                ''UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''仕切
                ''UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''売差
                ''UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''売差率
                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                '	'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                'Else
                '	'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '            End If


                '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                '名称
                'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_MEISYO(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '受注数
                'UPGRADE_ISSUE: Control BD_UODSU は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_UODSU(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '受注金額
                'UPGRADE_ISSUE: Control BD_UODKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_UODKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '仕切
                'UPGRADE_ISSUE: Control BD_SIKKN は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_SIKKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '売差
                'UPGRADE_ISSUE: Control BD_BAISA は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL71.BD_BAISA(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '売差率
                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                Else
                    'UPGRADE_ISSUE: Control BD_BSART は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                End If
                'change 20190325 END saiki
            End With
			'<--- 国内合計、海外合計の表示追加
			
			'        '総計行の作成
			'        '行追加
			'        intRowCnt = intRowCnt + 1
			'        ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
			'        '行項目情報コピー
			'        Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			'
			'        With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
			'            .Selected = False
			'            .MEISYO = "総計"
			'            .BD_UODSU_T = SumGokei.UODSU   '受注数
			'            .BD_UODKN_T = SumGokei.UODKN   '受注金額
			'            .BD_SIKKN_T = SumGokei.SIKKN   '仕切
			'            .BD_BAISA_T = SumGokei.BAISA   '売差
			'            If .BD_UODKN_T = 0 Then
			'                .BD_BSART_T = 0
			'            Else
			'                .BD_BSART_T = Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
			'            End If
			'
			'            '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
			'            '名称
			'            Wk_Index = CInt(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
			'            Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
			'            '受注数
			'            Wk_Index = CInt(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
			'            Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
			'            '受注金額
			'            Wk_Index = CInt(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
			'            Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
			'            '仕切
			'            Wk_Index = CInt(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
			'            Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
			'            '売差
			'            Wk_Index = CInt(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
			'            Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
			'            '売差率
			'            If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
			'                Wk_Index = CInt(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
			'                Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
			'            Else
			'                Wk_Index = CInt(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
			'                Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
			'            End If
			'        End With
			
			'行情報構造体配列の Redim
			MaxPageNum = F_Ctl_Add_BlankRow(pm_All)
			
			NowPageNum = 1
		End If
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		' 2007/03/04  ADD START  KUMEDA
		Call CF_Clr_Prompt(pm_All)
		' 2007/03/04  ADD END
		
		F_GET_BD_DATA_KIS_SOUKATU = intCnt
		
		Exit Function
		
ERR_F_GET_BD_DATA_KIS_SOUKATU: 
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_KIS_MEISAI_JUC_SQL
	'   概要：  データ取得ＳＱＬ生成（機種明細表：受注）
	'   引数：　pm_Kind         1:月初日、2:期首日
	'   戻値：　生成SQL
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_KIS_MEISAI_JUC_SQL(ByVal pm_Kind As String) As String
		
		Dim strSQL As String
		Dim StartDate As String
		
		'検索開始日の取得
		StartDate = F_GET_FIRSTDAY(pm_Kind, GV_UNYDate)
		
		'検索ＳＱＬ発行
		strSQL = ""
		strSQL = strSQL & " Select "
		strSQL = strSQL & "     Max(WAKU.HINDSP) As HINDSP "
		strSQL = strSQL & "    ,WAKU.HINGRPNM As SYOHIN "
		strSQL = strSQL & "    ,WAKU.HINGRPRM As SYOHINRM "
		strSQL = strSQL & "    ,WAKU.HINBRNMA As HINBRNMA "
		strSQL = strSQL & "    ,WAKU.HINBRNMB As HINBRNMB "
		strSQL = strSQL & "    ,WAKU.HINBRNMC As HINBRNMC "
		strSQL = strSQL & "    ,Sum(MAIN.UODSU) As UODSU "
		strSQL = strSQL & "    ,Round(Sum(MAIN.UODKN)) As UODKN "
		strSQL = strSQL & "    ,Round(Sum(MAIN.SIKKN)) As SIKKN "
		strSQL = strSQL & " From "
		strSQL = strSQL & "     ( "
		strSQL = strSQL & "         Select "
		strSQL = strSQL & "             PCODE "
		strSQL = strSQL & "            ,Sum(UODSU) As UODSU "
		strSQL = strSQL & "            ,Sum(UODKN) As UODKN "
		strSQL = strSQL & "            ,Sum(SIKKN) As SIKKN "
		strSQL = strSQL & "         From "
		strSQL = strSQL & "             JDNDLA "
		strSQL = strSQL & "         Where "
		strSQL = strSQL & "             JDNDT >= '" & StartDate & "' "
		strSQL = strSQL & "         And JDNDT <= '" & GV_UNYDate & "' "
		
		If Trim(gv_UODDL71_TIKCD) <> "" Then
			strSQL = strSQL & "         And TIKKB = '" & gv_UODDL71_TIKCD & "' "
		End If
		
		If Trim(gv_UODDL71_EIGCD) <> "" Then
			strSQL = strSQL & "         And EIGYOCD = '" & gv_UODDL71_EIGCD & "' "
		End If
		
		If Trim(gv_UODDL71_BMNCD) <> "" Then
			strSQL = strSQL & "         And JIGYOBU = '" & gv_UODDL71_BMNCD & "' "
		End If
		
		strSQL = strSQL & "         Group By "
		strSQL = strSQL & "             PCODE "
		strSQL = strSQL & "     ) MAIN "
		strSQL = strSQL & "    ,("
		strSQL = strSQL & "         Select Distinct "
		strSQL = strSQL & "             HINDSP "
		strSQL = strSQL & "            ,HINGRPNM "
		'2007/10/12 FKS)minamoto CHG START
		'strSQL = strSQL & "            ,HINGRPRM "
		strSQL = strSQL & "            ,MEINMC HINGRPRM "
		'2007/10/12 FKS)minamoto CHG END
		strSQL = strSQL & "            ,HINBRNMA "
		strSQL = strSQL & "            ,HINBRNMB "
		strSQL = strSQL & "            ,HINBRNMC "
		strSQL = strSQL & "            ,PCODE "
		strSQL = strSQL & "         From "
		strSQL = strSQL & "             KSYMTA "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "            ,MEIMTC "
		'2007/10/12 FKS)minamoto ADD END
		strSQL = strSQL & "         Where "
		'2007/10/12 FKS)minamoto CHG START
		'strSQL = strSQL & "             STTTKDT <= '" & GV_UNYDate & "' "
		'strSQL = strSQL & "         And ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "             MEIMTC.MEINMB = KSYMTA.HINGRPRM"
		strSQL = strSQL & "         And KSYMTA.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And KSYMTA.ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEIMTC.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEIMTC.ENDTKDT >= '" & GV_UNYDate & "' "
		'2007/10/12 FKS)minamoto CHG END
		strSQL = strSQL & "     ) WAKU "
		strSQL = strSQL & " Where "
		strSQL = strSQL & "     MAIN.PCODE(+) = WAKU.PCODE "
		strSQL = strSQL & " Group By "
		strSQL = strSQL & "     WAKU.HINGRPNM "
		strSQL = strSQL & "    ,WAKU.HINGRPRM "
		strSQL = strSQL & "    ,WAKU.HINBRNMA "
		strSQL = strSQL & "    ,WAKU.HINBRNMB "
		strSQL = strSQL & "    ,WAKU.HINBRNMC "
		strSQL = strSQL & " Order By "
		strSQL = strSQL & "     HINDSP "
		
		F_GET_KIS_MEISAI_JUC_SQL = strSQL
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_KIS_MEISAI_URI_SQL
	'   概要：  データ取得ＳＱＬ生成（機種明細表：売上）
	'   引数：　pm_Kind         1:月初日、2:期首日
	'   戻値：　生成SQL
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_KIS_MEISAI_URI_SQL(ByVal pm_Kind As String) As String
		
		Dim strSQL As String
		Dim StartDate As String
		
		'検索開始日の取得
		StartDate = F_GET_FIRSTDAY(pm_Kind, GV_UNYDate)
		
		'検索ＳＱＬ発行
		strSQL = ""
		strSQL = strSQL & " Select "
		strSQL = strSQL & "     Max(WAKU.HINDSP) As HINDSP "
		strSQL = strSQL & "    ,WAKU.HINGRPNM As SYOHIN "
		strSQL = strSQL & "    ,WAKU.HINGRPRM As SYOHINRM "
		strSQL = strSQL & "    ,WAKU.HINBRNMA As HINBRNMA "
		strSQL = strSQL & "    ,WAKU.HINBRNMB As HINBRNMB "
		strSQL = strSQL & "    ,WAKU.HINBRNMC As HINBRNMC "
		strSQL = strSQL & "    ,Sum(MAIN.URISU) As UODSU "
		strSQL = strSQL & "    ,Round(Sum(MAIN.URIKN)) As UODKN "
		strSQL = strSQL & "    ,Round(Sum(MAIN.SIKKN)) As SIKKN "
		strSQL = strSQL & " From "
		strSQL = strSQL & "     ( "
		strSQL = strSQL & "         Select "
		strSQL = strSQL & "             PCODE "
		strSQL = strSQL & "            ,Sum(URISU) As URISU "
		strSQL = strSQL & "            ,Sum(URIKN) As URIKN "
		strSQL = strSQL & "            ,Sum(SIKKN) As SIKKN "
		strSQL = strSQL & "         From "
		strSQL = strSQL & "             UDNDLA "
		strSQL = strSQL & "         Where "
		strSQL = strSQL & "             UDNDT >= '" & StartDate & "' "
		strSQL = strSQL & "         And UDNDT <= '" & GV_UNYDate & "' "
		
		If Trim(gv_UODDL71_TIKCD) <> "" Then
			strSQL = strSQL & "         And TIKKB = '" & gv_UODDL71_TIKCD & "' "
		End If
		
		If Trim(gv_UODDL71_EIGCD) <> "" Then
			strSQL = strSQL & "         And EIGYOCD = '" & gv_UODDL71_EIGCD & "' "
		End If
		
		If Trim(gv_UODDL71_BMNCD) <> "" Then
			strSQL = strSQL & "         And JIGYOBU = '" & gv_UODDL71_BMNCD & "' "
		End If
		
		strSQL = strSQL & "         Group By "
		strSQL = strSQL & "             PCODE "
		strSQL = strSQL & "     ) MAIN "
		strSQL = strSQL & "    ,( "
		strSQL = strSQL & "        Select Distinct "
		strSQL = strSQL & "             HINDSP "
		strSQL = strSQL & "            ,HINGRPNM "
		'2007/10/12 FKS)minamoto CHG START
		'strSQL = strSQL & "            ,HINGRPRM "
		strSQL = strSQL & "            ,MEINMC HINGRPRM "
		'2007/10/12 FKS)minamoto CHG END
		strSQL = strSQL & "            ,HINBRNMA "
		strSQL = strSQL & "            ,HINBRNMB "
		strSQL = strSQL & "            ,HINBRNMC "
		strSQL = strSQL & "            ,PCODE "
		strSQL = strSQL & "         From "
		strSQL = strSQL & "             KSYMTA "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "            ,MEIMTC "
		'2007/10/12 FKS)minamoto ADD END
		strSQL = strSQL & "         Where "
		'2007/10/12 FKS)minamoto CHG START
		'strSQL = strSQL & "             STTTKDT <= '" & GV_UNYDate & "' "
		'strSQL = strSQL & "         And ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "             MEIMTC.MEINMB = KSYMTA.HINGRPRM"
		strSQL = strSQL & "         And KSYMTA.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And KSYMTA.ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEIMTC.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEIMTC.ENDTKDT >= '" & GV_UNYDate & "' "
		'2007/10/12 FKS)minamoto CHG END
		strSQL = strSQL & "     ) WAKU "
		strSQL = strSQL & " Where "
		strSQL = strSQL & "     MAIN.PCODE(+) = WAKU.PCODE "
		strSQL = strSQL & " Group By "
		strSQL = strSQL & "     WAKU.HINGRPNM "
        strSQL = strSQL & "    ,WAKU.HINGRPRM "
        strSQL = strSQL & "    ,WAKU.HINBRNMA "
		strSQL = strSQL & "    ,WAKU.HINBRNMB "
		strSQL = strSQL & "    ,WAKU.HINBRNMC "
		strSQL = strSQL & " Order By "
		strSQL = strSQL & "     HINDSP "
		
		F_GET_KIS_MEISAI_URI_SQL = strSQL
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_BD_DATA_KIS_SOUKATU_JUC
	'   概要：  ボディ部データ取得（機種別総括表：受注）
	'   引数：  pm_Kind     1:月初日、2:期首日
	'           pm_All      :全構造体
	'   戻値：　取得行数
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_BD_DATA_KIS_MEISAI_JUC(ByVal pm_Kind As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim Ret_Value As Short

        'delete 20190327 START saiki
		'ADD 20150710 START C2-20150708-01
        'Call F_Ctl_LAB_EXC(pm_All)
        'ADD 20150710 END C2-20150708-01
        'delete 20190327 END saiki

		
		'検索ＳＱＬ生成
		strSQL = F_GET_KIS_MEISAI_JUC_SQL(pm_Kind)
		
		Ret_Value = F_GET_BD_DATA_KIS_MEISAI(strSQL, pm_All)
		
		'ADD 20150710 START C2-20150708-01
		'UPGRADE_ISSUE: Control lab_exc は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'delete 20190325 START saiki
        'If pm_All.Dsp_Base.FormCtl.lab_exc.Visible = False Then
        '    Call F_Ctl_LAB_EXC(pm_All)
        'End If
        'delete 20190325 END saiki
		'ADD 20150710 END C2-20150708-01
		
		F_GET_BD_DATA_KIS_MEISAI_JUC = Ret_Value
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_BD_DATA_KIS_SOUKATU_URI
	'   概要：  ボディ部データ取得（機種別総括表：売上）
	'   引数：  pm_Kind     1:月初日、2:期首日
	'           pm_All      :全構造体
	'   戻値：　取得行数
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_BD_DATA_KIS_MEISAI_URI(ByVal pm_Kind As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim Ret_Value As Short

        'delete 20190327 START saiki
		'ADD 20150710 START C2-20150708-01
        'Call F_Ctl_LAB_EXC(pm_All)
        'ADD 20150710 END C2-20150708-01
        'delete 20190327 END saiki
		
		'検索ＳＱＬ生成
		strSQL = F_GET_KIS_MEISAI_URI_SQL(pm_Kind)
		
		Ret_Value = F_GET_BD_DATA_KIS_MEISAI(strSQL, pm_All)
		
		'ADD 20150710 START C2-20150708-01
		'UPGRADE_ISSUE: Control lab_exc は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'delete 20190325 START saiki
        'If pm_All.Dsp_Base.FormCtl.lab_exc.Visible = False Then
        '    Call F_Ctl_LAB_EXC(pm_All)
        'End If
        'delete 20190325 END saiki
		'ADD 20150710 END C2-20150708-01
		
		F_GET_BD_DATA_KIS_MEISAI_URI = Ret_Value
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_BD_DATA_BMN_SOUKATU
	'   概要：  ボディ部データ取得（部門別総括表）
	'   引数：  pm_Kind     1:月初日、2:期首日
	'           pm_All      :全構造体
	'   戻値：　取得行数
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_BD_DATA_KIS_MEISAI(ByVal pm_SQL As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim intMode As Short
		Dim intCnt As Short
		Dim Wk_Index As Short
		Dim Err_Cd As String
		Dim intRowCnt As Short
		Dim intSyoCnt As Short
		Dim intBrACnt As Short
		Dim intBrBCnt As Short
		Dim SyoGokei() As UODDL71_TYPE_KISMEI
		Dim BrAGokei() As UODDL71_TYPE_KISMEI
		Dim BrBGokei() As UODDL71_TYPE_KISMEI
		Dim ZenGokei As UODDL71_TYPE_KISMEI
		Dim Wk_SyoCd As String
		Dim Wk_BrACd As String
		Dim Wk_BrBCd As String
		Dim Wk_BrCCd As String
		
		On Error GoTo ERR_F_GET_BD_DATA_KIS_MEISAI
		F_GET_BD_DATA_KIS_MEISAI = -1

        'UODDL712.BD_UODSU_T(1).Tag = pm_All.Dsp_Base.FormCtl.BD_UODSU_T(1).Tag

        ' 2007/03/04  ADD START  KUMEDA
        Call FR_SSSMAIN2.Ctl_MN_APPENDC_Click()
		Call CF_Set_Prompt(DATE_GET_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), pm_All)
		System.Windows.Forms.Application.DoEvents()
		' 2007/03/04  ADD END
		
		'初期化
		Err_Cd = ""
		Wk_SyoCd = ""
		Wk_BrACd = ""
		Wk_BrBCd = ""
		Wk_BrCCd = ""
		ReDim SyoGokei(0)
		ReDim BrAGokei(0)
		ReDim BrBGokei(0)
		
		'検索ＳＱＬ生成
		strSQL = pm_SQL

        'DBアクセス
        'change 20190403 START saiki
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change 20190403 END saiki

        'change 20190403 START saiki
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                'change 20190403 END saiki
                '取得データなし
                F_GET_BD_DATA_KIS_MEISAI = 0
                Err_Cd = gc_strMsgUODDL71_E_002
                Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)

                Exit Function
            Else

            intCnt = 0
            'change 20190403 START saiki
            '         Do Until CF_Ora_EOF(Usr_Ody) = True
            '	'取得全レコードよりボディ情報退避
            '	intCnt = intCnt + 1
            '	'行追加
            '	ReDim Preserve UODDL71_KISMEI_Inf(intCnt)

            '	With UODDL71_KISMEI_Inf(intCnt)
            '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		.SYOHIN = CF_Ora_GetDyn(Usr_Ody, "SYOHIN", "") '商品群名称
            '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		.SYOHINRM = CF_Ora_GetDyn(Usr_Ody, "SYOHINRM", "") '商品群略称
            '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		.BUNRUIA = CF_Ora_GetDyn(Usr_Ody, "HINBRNMA", "") '分類Ａ
            '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		.BUNRUIB = CF_Ora_GetDyn(Usr_Ody, "HINBRNMB", "") '分類Ｂ
            '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		.BUNRUIC = CF_Ora_GetDyn(Usr_Ody, "HINBRNMC", "") '分類Ｃ
            '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		.UODSU_T = CF_Ora_GetDyn(Usr_Ody, "UODSU", 0) '受注数量
            '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		.UODKN_T = CF_Ora_GetDyn(Usr_Ody, "UODKN", 0) '受注金額
            '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		.SIKKN_T = CF_Ora_GetDyn(Usr_Ody, "SIKKN", 0) '仕切
            '		.BAISA_T = .UODKN_T - .SIKKN_T '売差
            '	End With

            '	'次レコード
            '	Call CF_Ora_MoveNext(Usr_Ody)
            'Loop 

            For Each row As DataRow In dt.Rows
                '取得全レコードよりボディ情報退避
                intCnt = intCnt + 1
                '行追加
                ReDim Preserve UODDL71_KISMEI_Inf(intCnt)

                With UODDL71_KISMEI_Inf(intCnt)
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .SYOHIN = DB_NullReplace(row("SYOHIN"), "") '商品群名称
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .SYOHINRM = DB_NullReplace(row("SYOHINRM"), "") '商品群略称
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .BUNRUIA = DB_NullReplace(row("HINBRNMA"), "") '分類Ａ
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .BUNRUIB = DB_NullReplace(row("HINBRNMB"), "") '分類Ｂ
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .BUNRUIC = DB_NullReplace(row("HINBRNMC"), "") '分類Ｃ
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .UODSU_T = DB_NullReplace(row("UODSU"), 0) '受注数量
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .UODKN_T = DB_NullReplace(row("UODKN"), 0) '受注金額
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .SIKKN_T = DB_NullReplace(row("SIKKN"), 0) '仕切
                    .BAISA_T = .UODKN_T - .SIKKN_T '売差
                End With

            Next
            'change 20190403 END saiki


            intRowCnt = 0
			intSyoCnt = 0
			intBrACnt = 0
			intBrBCnt = 0
			For intData = 1 To intCnt
				With UODDL71_KISMEI_Inf(intData)
					'前データの商品群と異なる場合
					If Wk_SyoCd <> .SYOHIN Then
						'分類Ｃがある場合、前の分類Ｂの計行を作成
						If Trim(Wk_BrCCd) <> "" Then
							'行追加
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'行項目情報コピー
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
								.Selected = CStr(False)
								' 2007/03/04  CHG START  KUMEDA
								'                            .MEISYO = "　　　　-- 計 --"
								.MEISYO = "　　　　-- " & Trim(BrBGokei(intBrBCnt).BUNRUIB) & "計 --"
								' 2007/03/04  CHG END
								.DIVISION = "3"
								.BD_UODSU_T = BrBGokei(intBrBCnt).UODSU_T '受注数
								.BD_UODKN_T = BrBGokei(intBrBCnt).UODKN_T '受注金額
								.BD_SIKKN_T = BrBGokei(intBrBCnt).SIKKN_T '仕切
								.BD_BAISA_T = BrBGokei(intBrBCnt).BAISA_T '売差
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
								End If

                                'change 20190325 START saiki
                                ''画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                                ''名称
                                ''UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''受注数
                                ''UPGRADE_ISSUE: Control BD_UODSU_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''受注金額
                                ''UPGRADE_ISSUE: Control BD_UODKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''仕切
                                ''UPGRADE_ISSUE: Control BD_SIKKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''売差
                                ''UPGRADE_ISSUE: Control BD_BAISA_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''売差率
                                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                '	'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                'Else
                                '	'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '                        End If


                                '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                                '名称
                                'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '受注数
                                'UPGRADE_ISSUE: Control BD_UODSU_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_UODSU_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '受注金額
                                'UPGRADE_ISSUE: Control BD_UODKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_UODKN_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '仕切
                                'UPGRADE_ISSUE: Control BD_SIKKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_SIKKN_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '売差
                                'UPGRADE_ISSUE: Control BD_BAISA_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_BAISA_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '売差率
                                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                Else
                                    'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                End If
                                'change 20190325 END saiki
                            End With
						End If
						
						'分類Ｂがある場合、前の分類Ａの計行を作成
						If Trim(Wk_BrBCd) <> "" Then
							'行追加
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'行項目情報コピー
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
								.Selected = CStr(False)
								.MEISYO = "　　< " & Trim(BrAGokei(intBrACnt).BUNRUIA) & "計 >"
								.DIVISION = "2"
								.BD_UODSU_T = BrAGokei(intBrACnt).UODSU_T '受注数
								.BD_UODKN_T = BrAGokei(intBrACnt).UODKN_T '受注金額
								.BD_SIKKN_T = BrAGokei(intBrACnt).SIKKN_T '仕切
								.BD_BAISA_T = BrAGokei(intBrACnt).BAISA_T '売差
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
								End If

                                'change 20190325 START saiki
                                ''画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                                ''名称
                                ''UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''受注数
                                ''UPGRADE_ISSUE: Control BD_UODSU_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''受注金額
                                ''UPGRADE_ISSUE: Control BD_UODKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''仕切
                                ''UPGRADE_ISSUE: Control BD_SIKKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''売差
                                ''UPGRADE_ISSUE: Control BD_BAISA_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''売差率
                                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                '	'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                'Else
                                '	'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '                        End If


                                '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                                '名称
                                'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '受注数
                                'UPGRADE_ISSUE: Control BD_UODSU_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_UODSU_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '受注金額
                                'UPGRADE_ISSUE: Control BD_UODKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_UODKN_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '仕切
                                'UPGRADE_ISSUE: Control BD_SIKKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_SIKKN_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '売差
                                'UPGRADE_ISSUE: Control BD_BAISA_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_BAISA_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '売差率
                                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                Else
                                    'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                End If
                                'change 20190325 END saiki
                            End With
						End If
						
						'最初の商品群でない場合、前の商品群の合計行を作成
						If Trim(Wk_SyoCd) <> "" Then
							'行追加
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'行項目情報コピー
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
								.Selected = CStr(False)
								' 2007/03/04  CHG START  KUMEDA
								'                            .MEISYO = "～ " & Trim(SyoGokei(intSyoCnt).SYOHINRM) & "合計 ～"
								'2007/11/06 FKS)minamoto CHG START
								'.MEISYO = "～ " & Trim(SyoGokei(intSyoCnt).SYOHINRM) & "計 ～"
								.MEISYO = "～ " & Trim(SyoGokei(intSyoCnt).SYOHIN) & "計 ～"
								'2007/11/06 FKS)minamoto CHG END
								' 2007/030/4  CHG END
								.DIVISION = "1"
								.BD_UODSU_T = SyoGokei(intSyoCnt).UODSU_T '受注数
								.BD_UODKN_T = SyoGokei(intSyoCnt).UODKN_T '受注金額
								.BD_SIKKN_T = SyoGokei(intSyoCnt).SIKKN_T '仕切
								.BD_BAISA_T = SyoGokei(intSyoCnt).BAISA_T '売差
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
								End If

                                'change 20190325 START saiki
                                ''画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                                ''名称
                                ''UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''受注数
                                ''UPGRADE_ISSUE: Control BD_UODSU_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''受注金額
                                ''UPGRADE_ISSUE: Control BD_UODKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''仕切
                                ''UPGRADE_ISSUE: Control BD_SIKKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''売差
                                ''UPGRADE_ISSUE: Control BD_BAISA_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''売差率
                                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                '	'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                'Else
                                '	'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '                        End If


                                '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                                '名称
                                'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '受注数
                                'UPGRADE_ISSUE: Control BD_UODSU_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_UODSU_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '受注金額
                                'UPGRADE_ISSUE: Control BD_UODKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_UODKN_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '仕切
                                'UPGRADE_ISSUE: Control BD_SIKKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_SIKKN_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '売差
                                'UPGRADE_ISSUE: Control BD_BAISA_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_BAISA_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '売差率
                                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                Else
                                    'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                End If
                                'change 20190325 END saiki
                            End With
						End If
						
						'商品群のカウント
						intSyoCnt = intSyoCnt + 1
						'商品群合計計算用
						ReDim Preserve SyoGokei(intSyoCnt)
						SyoGokei(intSyoCnt).SYOHIN = .SYOHIN '商品群名称
						SyoGokei(intSyoCnt).SYOHINRM = .SYOHINRM '商品群略称
						SyoGokei(intSyoCnt).UODSU_T = 0 '受注数量
						SyoGokei(intSyoCnt).UODKN_T = 0 '受注金額
						SyoGokei(intSyoCnt).SIKKN_T = 0 '仕切
						SyoGokei(intSyoCnt).BAISA_T = 0 '売差
						
						'行追加
						intRowCnt = intRowCnt + 1
						ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
						'行項目情報コピー
						Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
						
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = .SYOHIN

                        '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                        '名称
                        'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        'change 20190325 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                        Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                        'change 20190325 END saiki
                        Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					End If
					
					'前データの分類Ａと異なる場合
					If Wk_BrACd <> .BUNRUIA Then
						'分類Ｃがある場合、前の分類Ｂの計行を作成（前データの商品群と同じ）
						If Trim(Wk_BrCCd) <> "" And Wk_SyoCd = .SYOHIN Then
							'行追加
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'行項目情報コピー
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
								.Selected = CStr(False)
								' 2007/03/04  CHG START  KUMEDA
								'                            .MEISYO = "　　　　-- 計 --"
								.MEISYO = "　　　　-- " & Trim(BrBGokei(intBrBCnt).BUNRUIB) & "計 --"
								' 2007/03/04  CHG END
								.DIVISION = "3"
								.BD_UODSU_T = BrBGokei(intBrBCnt).UODSU_T '受注数
								.BD_UODKN_T = BrBGokei(intBrBCnt).UODKN_T '受注金額
								.BD_SIKKN_T = BrBGokei(intBrBCnt).SIKKN_T '仕切
								.BD_BAISA_T = BrBGokei(intBrBCnt).BAISA_T '売差
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
								End If

                                'change 20190325 START saiki
                                ''画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                                ''名称
                                ''UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''受注数
                                ''UPGRADE_ISSUE: Control BD_UODSU_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''受注金額
                                ''UPGRADE_ISSUE: Control BD_UODKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''仕切
                                ''UPGRADE_ISSUE: Control BD_SIKKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''売差
                                ''UPGRADE_ISSUE: Control BD_BAISA_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''売差率
                                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                '	'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                'Else
                                '	'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '                        End If


                                '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                                '名称
                                'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '受注数
                                'UPGRADE_ISSUE: Control BD_UODSU_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_UODSU_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '受注金額
                                'UPGRADE_ISSUE: Control BD_UODKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_UODKN_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '仕切
                                'UPGRADE_ISSUE: Control BD_SIKKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_SIKKN_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '売差
                                'UPGRADE_ISSUE: Control BD_BAISA_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_BAISA_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '売差率
                                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                Else
                                    'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                End If
                                'change 20190325 END saiki
                            End With
						End If
						
						'最初の分類Ａでない場合、前の分類Ａの計行を作成（前データの商品群と同じ）
						If Trim(Wk_BrACd) <> "" And Trim(Wk_BrBCd) <> "" And Wk_SyoCd = .SYOHIN Then
							'行追加
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'行項目情報コピー
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
								.Selected = CStr(False)
								.MEISYO = "　　< " & Trim(BrAGokei(intBrACnt).BUNRUIA) & "計 >"
								.DIVISION = "2"
								.BD_UODSU_T = BrAGokei(intBrACnt).UODSU_T '受注数
								.BD_UODKN_T = BrAGokei(intBrACnt).UODKN_T '受注金額
								.BD_SIKKN_T = BrAGokei(intBrACnt).SIKKN_T '仕切
								.BD_BAISA_T = BrAGokei(intBrACnt).BAISA_T '売差
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
								End If

                                '                        'change 20190325 START saiki
                                ''画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                                ''名称
                                ''UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''受注数
                                ''UPGRADE_ISSUE: Control BD_UODSU_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''受注金額
                                ''UPGRADE_ISSUE: Control BD_UODKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''仕切
                                ''UPGRADE_ISSUE: Control BD_SIKKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''売差
                                ''UPGRADE_ISSUE: Control BD_BAISA_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''売差率
                                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                '	'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                'Else
                                '	'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '                        End If


                                '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                                '名称
                                'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '受注数
                                'UPGRADE_ISSUE: Control BD_UODSU_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_UODSU_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '受注金額
                                'UPGRADE_ISSUE: Control BD_UODKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_UODKN_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '仕切
                                'UPGRADE_ISSUE: Control BD_SIKKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_SIKKN_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '売差
                                'UPGRADE_ISSUE: Control BD_BAISA_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_BAISA_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '売差率
                                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                Else
                                    'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                End If
                                'change 20190325 END saiki
                            End With
						End If
						
						'今データの分類Ａがある場合
						If Trim(.BUNRUIA) <> "" Then
							'分類Ａのカウント
							intBrACnt = intBrACnt + 1
							'分類Ａ合計計算用
							ReDim Preserve BrAGokei(intBrACnt)
							BrAGokei(intBrACnt).BUNRUIA = .BUNRUIA '分類Ａ名称
							BrAGokei(intBrACnt).UODSU_T = 0 '受注数量
							BrAGokei(intBrACnt).UODKN_T = 0 '受注金額
							BrAGokei(intBrACnt).SIKKN_T = 0 '仕切
							BrAGokei(intBrACnt).BAISA_T = 0 '売差
							
							'行追加
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'行項目情報コピー
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
							pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = "　　" & .BUNRUIA

                            '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                            '名称
                            'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                            'change 20190325 START saiki
                            'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                            Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                            'change 20190325 END saiki
                            Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						End If
					End If
					
					'前データの分類Ｂと異なる場合
					If Wk_BrBCd <> .BUNRUIB Then
						'最初の分類Ｂでない場合、前の分類Ｂの計行を作成（前データの商品群、分類Ａと同じ）
						If Trim(Wk_BrBCd) <> "" And Trim(Wk_BrCCd) <> "" And Wk_SyoCd = .SYOHIN And Wk_BrACd = .BUNRUIA Then
							'行追加
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'行項目情報コピー
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
								.Selected = CStr(False)
								' 2007/03/04  CHG START  KUMEDA
								'                            .MEISYO = "　　　　-- 計 --"
								.MEISYO = "　　　　-- " & Trim(BrBGokei(intBrBCnt).BUNRUIB) & "計 --"
								' 2007/03/04  CHG END
								.DIVISION = "3"
								.BD_UODSU_T = BrBGokei(intBrBCnt).UODSU_T '受注数
								.BD_UODKN_T = BrBGokei(intBrBCnt).UODKN_T '受注金額
								.BD_SIKKN_T = BrBGokei(intBrBCnt).SIKKN_T '仕切
								.BD_BAISA_T = BrBGokei(intBrBCnt).BAISA_T '売差
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
								End If

                                'change 20190325 START saiki
                                ''画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                                ''名称
                                ''UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''受注数
                                ''UPGRADE_ISSUE: Control BD_UODSU_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''受注金額
                                ''UPGRADE_ISSUE: Control BD_UODKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''仕切
                                ''UPGRADE_ISSUE: Control BD_SIKKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''売差
                                ''UPGRADE_ISSUE: Control BD_BAISA_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''売差率
                                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                '	'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                'Else
                                '	'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '                        End If


                                '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                                '名称
                                'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '受注数
                                'UPGRADE_ISSUE: Control BD_UODSU_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_UODSU_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '受注金額
                                'UPGRADE_ISSUE: Control BD_UODKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_UODKN_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '仕切
                                'UPGRADE_ISSUE: Control BD_SIKKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_SIKKN_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '売差
                                'UPGRADE_ISSUE: Control BD_BAISA_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                Wk_Index = CShort(UODDL712.BD_BAISA_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '売差率
                                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                Else
                                    'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                End If
                                'change 20190325 END saiki
                            End With
						End If
						
						'今データの分類Ｂがある場合
						If Trim(.BUNRUIB) <> "" Then
							'分類Ｂのカウント
							intBrBCnt = intBrBCnt + 1
							'分類Ｂ合計計算用
							ReDim Preserve BrBGokei(intBrBCnt)
							BrBGokei(intBrBCnt).BUNRUIB = .BUNRUIB '分類Ｂ名称
							BrBGokei(intBrBCnt).UODSU_T = 0 '受注数量
							BrBGokei(intBrBCnt).UODKN_T = 0 '受注金額
							BrBGokei(intBrBCnt).SIKKN_T = 0 '仕切
							BrBGokei(intBrBCnt).BAISA_T = 0 '売差
							
							'行追加
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'行項目情報コピー
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
							pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = "　　　　" & .BUNRUIB

                            '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                            '名称
                            'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                            'change 20190325 START saiki
                            'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                            Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                            'change 20190325 END saiki
                            Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						End If
					End If
					
					'今データの分類Ｃがある場合
					If Trim(.BUNRUIC) <> "" Then
						'行追加
						intRowCnt = intRowCnt + 1
						ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
						'行項目情報コピー
						Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
						
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = "　　　　　　" & .BUNRUIC

                        '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                        '名称
                        'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        'change 20190325 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                        Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                        'change 20190325 END saiki
                        Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					End If
					
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_UODSU_T = .UODSU_T '受注数
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_UODKN_T = .UODKN_T '受注金額
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_SIKKN_T = .SIKKN_T '仕切
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_BAISA_T = .BAISA_T '売差
					If .UODKN_T = 0 Then
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_BSART_T = 0
					Else
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_BSART_T = System.Math.Round(.BAISA_T / .UODKN_T * 100, 1) '売差率
					End If

                    'change 20190325 START saiki
                    ''画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                    'With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
                    '	'受注数
                    '	'UPGRADE_ISSUE: Control BD_UODSU_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU_T(1).Tag)
                    '	Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '	'受注金額
                    '	'UPGRADE_ISSUE: Control BD_UODKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN_T(1).Tag)
                    '	Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '	'仕切
                    '	'UPGRADE_ISSUE: Control BD_SIKKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN_T(1).Tag)
                    '	Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '	'売差
                    '	'UPGRADE_ISSUE: Control BD_BAISA_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA_T(1).Tag)
                    '	Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '	'売差率
                    '	If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    '		'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    '		Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                    '		Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '	Else
                    '		'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    '		Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                    '		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '	End If
                    '               End With


                    '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                    With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
                        '受注数
                        'UPGRADE_ISSUE: Control BD_UODSU_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        Wk_Index = CShort(UODDL712.BD_UODSU_T(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        '受注金額
                        'UPGRADE_ISSUE: Control BD_UODKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        Wk_Index = CShort(UODDL712.BD_UODKN_T(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        '仕切
                        'UPGRADE_ISSUE: Control BD_SIKKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        Wk_Index = CShort(UODDL712.BD_SIKKN_T(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        '売差
                        'UPGRADE_ISSUE: Control BD_BAISA_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        Wk_Index = CShort(UODDL712.BD_BAISA_T(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        '売差率
                        If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                            'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                            Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                            Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        Else
                            'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                            Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                            Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        End If
                    End With
                    'change 20190325 END saiki

                    '分類Ｂ合計計算
                    If .BUNRUIB <> "" Then
						BrBGokei(intBrBCnt).UODSU_T = BrBGokei(intBrBCnt).UODSU_T + .UODSU_T '受注数量
						BrBGokei(intBrBCnt).UODKN_T = BrBGokei(intBrBCnt).UODKN_T + .UODKN_T '受注金額
						BrBGokei(intBrBCnt).SIKKN_T = BrBGokei(intBrBCnt).SIKKN_T + .SIKKN_T '仕切
						BrBGokei(intBrBCnt).BAISA_T = BrBGokei(intBrBCnt).BAISA_T + .BAISA_T '売差
					End If
					
					'分類Ａ合計計算
					If .BUNRUIA <> "" Then
						BrAGokei(intBrACnt).UODSU_T = BrAGokei(intBrACnt).UODSU_T + .UODSU_T '受注数量
						BrAGokei(intBrACnt).UODKN_T = BrAGokei(intBrACnt).UODKN_T + .UODKN_T '受注金額
						BrAGokei(intBrACnt).SIKKN_T = BrAGokei(intBrACnt).SIKKN_T + .SIKKN_T '仕切
						BrAGokei(intBrACnt).BAISA_T = BrAGokei(intBrACnt).BAISA_T + .BAISA_T '売差
					End If
					
					'商品群合計計算
					SyoGokei(intSyoCnt).UODSU_T = SyoGokei(intSyoCnt).UODSU_T + .UODSU_T '受注数量
					SyoGokei(intSyoCnt).UODKN_T = SyoGokei(intSyoCnt).UODKN_T + .UODKN_T '受注金額
					SyoGokei(intSyoCnt).SIKKN_T = SyoGokei(intSyoCnt).SIKKN_T + .SIKKN_T '仕切
					SyoGokei(intSyoCnt).BAISA_T = SyoGokei(intSyoCnt).BAISA_T + .BAISA_T '売差
					
					'今データの退避
					Wk_SyoCd = .SYOHIN
					Wk_BrACd = .BUNRUIA
					Wk_BrBCd = .BUNRUIB
					Wk_BrCCd = .BUNRUIC
				End With
			Next 
			
			'分類Ｃがある場合、最終の分類Ｂの計行を作成
			If Trim(Wk_BrCCd) <> "" Then
				'行追加
				intRowCnt = intRowCnt + 1
				ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
				'行項目情報コピー
				Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
				
				With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
					.Selected = CStr(False)
					' 2007/03/04  CHG START  KUMEDA
					'                .MEISYO = "　　　　-- 計 --"
					.MEISYO = "　　　　-- " & Trim(BrBGokei(intBrBCnt).BUNRUIB) & "計 --"
					' 2007/03/04  CHG END
					.DIVISION = "3"
					.BD_UODSU_T = BrBGokei(intBrBCnt).UODSU_T '受注数
					.BD_UODKN_T = BrBGokei(intBrBCnt).UODKN_T '受注金額
					.BD_SIKKN_T = BrBGokei(intBrBCnt).SIKKN_T '仕切
					.BD_BAISA_T = BrBGokei(intBrBCnt).BAISA_T '売差
					If .BD_UODKN_T = 0 Then
						.BD_BSART_T = 0
					Else
						.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
					End If

                    'change 20190325 START saiki
                    ''画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                    ''名称
                    ''UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                    'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    ''受注数
                    ''UPGRADE_ISSUE: Control BD_UODSU_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU_T(1).Tag)
                    'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    ''受注金額
                    ''UPGRADE_ISSUE: Control BD_UODKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN_T(1).Tag)
                    'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    ''仕切
                    ''UPGRADE_ISSUE: Control BD_SIKKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN_T(1).Tag)
                    'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    ''売差
                    ''UPGRADE_ISSUE: Control BD_BAISA_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA_T(1).Tag)
                    'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    ''売差率
                    'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    '	'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                    '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    'Else
                    '	'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                    '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '               End If

                    '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                    '名称
                    'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '受注数
                    'UPGRADE_ISSUE: Control BD_UODSU_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL712.BD_UODSU_T(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '受注金額
                    'UPGRADE_ISSUE: Control BD_UODKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL712.BD_UODKN_T(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '仕切
                    'UPGRADE_ISSUE: Control BD_SIKKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL712.BD_SIKKN_T(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '売差
                    'UPGRADE_ISSUE: Control BD_BAISA_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL712.BD_BAISA_T(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '売差率
                    If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                        'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    Else
                        'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    End If
                    'change 20190325 END saiki
                End With
			End If
			
			'分類Ｂがある場合、最終の分類Ａの計行を作成
			If Trim(Wk_BrBCd) <> "" Then
				'行追加
				intRowCnt = intRowCnt + 1
				ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
				'行項目情報コピー
				Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
				
				With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
					.Selected = CStr(False)
					.MEISYO = "　　< " & Trim(BrAGokei(intBrACnt).BUNRUIA) & "計 >"
					.DIVISION = "2"
					.BD_UODSU_T = BrAGokei(intBrACnt).UODSU_T '受注数
					.BD_UODKN_T = BrAGokei(intBrACnt).UODKN_T '受注金額
					.BD_SIKKN_T = BrAGokei(intBrACnt).SIKKN_T '仕切
					.BD_BAISA_T = BrAGokei(intBrACnt).BAISA_T '売差
					If .BD_UODKN_T = 0 Then
						.BD_BSART_T = 0
					Else
						.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
					End If

                    'change 20190325 START saiki
                    ''画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                    ''名称
                    ''UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                    'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    ''受注数
                    ''UPGRADE_ISSUE: Control BD_UODSU_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU_T(1).Tag)
                    'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    ''受注金額
                    ''UPGRADE_ISSUE: Control BD_UODKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN_T(1).Tag)
                    'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    ''仕切
                    ''UPGRADE_ISSUE: Control BD_SIKKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN_T(1).Tag)
                    'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    ''売差
                    ''UPGRADE_ISSUE: Control BD_BAISA_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA_T(1).Tag)
                    'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    ''売差率
                    'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    '	'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                    '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    'Else
                    '	'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                    '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '               End If

                    '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                    '名称
                    'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '受注数
                    'UPGRADE_ISSUE: Control BD_UODSU_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL712.BD_UODSU_T(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '受注金額
                    'UPGRADE_ISSUE: Control BD_UODKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL712.BD_UODKN_T(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '仕切
                    'UPGRADE_ISSUE: Control BD_SIKKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL712.BD_SIKKN_T(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '売差
                    'UPGRADE_ISSUE: Control BD_BAISA_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL712.BD_BAISA_T(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '売差率
                    If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                        'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    Else
                        'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    End If
                    'change 20190325 END saiki
                End With
			End If
			
			'最終の商品群の合計行を作成
			'行追加
			intRowCnt = intRowCnt + 1
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
			'行項目情報コピー
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			
			With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
				.Selected = CStr(False)
				' 2007/03/04  CHG START  KUMEDA
				'            .MEISYO = "～ " & Trim(SyoGokei(intSyoCnt).SYOHINRM) & "合計 ～"
				'2007/11/06 FKS)minamoto CHG START
				'.MEISYO = "～ " & Trim(SyoGokei(intSyoCnt).SYOHINRM) & "計 ～"
				.MEISYO = "～ " & Trim(SyoGokei(intSyoCnt).SYOHIN) & "計 ～"
				'2007/11/06 FKS)minamoto CHG END
				' 2007/03/04  CHG END
				.DIVISION = "1"
				.BD_UODSU_T = SyoGokei(intSyoCnt).UODSU_T '受注数
				.BD_UODKN_T = SyoGokei(intSyoCnt).UODKN_T '受注金額
				.BD_SIKKN_T = SyoGokei(intSyoCnt).SIKKN_T '仕切
				.BD_BAISA_T = SyoGokei(intSyoCnt).BAISA_T '売差
				If .BD_UODKN_T = 0 Then
					.BD_BSART_T = 0
				Else
					.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
				End If

                'change 20190325 START saiki
                ''画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                ''名称
                ''UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''受注数
                ''UPGRADE_ISSUE: Control BD_UODSU_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU_T(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''受注金額
                ''UPGRADE_ISSUE: Control BD_UODKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN_T(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''仕切
                ''UPGRADE_ISSUE: Control BD_SIKKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN_T(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''売差
                ''UPGRADE_ISSUE: Control BD_BAISA_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA_T(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''売差率
                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                '	'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                'Else
                '	'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '            End If


                '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                '名称
                'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '受注数
                'UPGRADE_ISSUE: Control BD_UODSU_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL712.BD_UODSU_T(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '受注金額
                'UPGRADE_ISSUE: Control BD_UODKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL712.BD_UODKN_T(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '仕切
                'UPGRADE_ISSUE: Control BD_SIKKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL712.BD_SIKKN_T(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '売差
                'UPGRADE_ISSUE: Control BD_BAISA_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL712.BD_BAISA_T(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '売差率
                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                Else
                    'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                End If
                'change 20190325 END saiki
            End With
			
			'総合計の作成
			For intData = 1 To intSyoCnt
				With SyoGokei(intData)
					ZenGokei.UODSU_T = ZenGokei.UODSU_T + .UODSU_T '受注数量
					ZenGokei.UODKN_T = ZenGokei.UODKN_T + .UODKN_T '受注金額
					ZenGokei.SIKKN_T = ZenGokei.SIKKN_T + .SIKKN_T '仕切
					ZenGokei.BAISA_T = ZenGokei.BAISA_T + .BAISA_T '売差
				End With
			Next 
			
			'総合計行の作成
			'行追加
			intRowCnt = intRowCnt + 1
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
			'行項目情報コピー
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			
			With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
				.Selected = CStr(False)
				.MEISYO = "合計"
				.DIVISION = "99"
				.BD_UODSU_T = ZenGokei.UODSU_T '受注数
				.BD_UODKN_T = ZenGokei.UODKN_T '受注金額
				.BD_SIKKN_T = ZenGokei.SIKKN_T '仕切
				.BD_BAISA_T = ZenGokei.BAISA_T '売差
				If .BD_UODKN_T = 0 Then
					.BD_BSART_T = 0
				Else
					.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '売差率
				End If

                'change 20190325 START saiki
                ''画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                ''名称
                ''UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''受注数
                ''UPGRADE_ISSUE: Control BD_UODSU_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU_T(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''受注金額
                ''UPGRADE_ISSUE: Control BD_UODKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN_T(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''仕切
                ''UPGRADE_ISSUE: Control BD_SIKKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN_T(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''売差
                ''UPGRADE_ISSUE: Control BD_BAISA_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA_T(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''売差率
                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                '	'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                'Else
                '	'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '            End If


                '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                '名称
                'UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '受注数
                'UPGRADE_ISSUE: Control BD_UODSU_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL712.BD_UODSU_T(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '受注金額
                'UPGRADE_ISSUE: Control BD_UODKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL712.BD_UODKN_T(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '仕切
                'UPGRADE_ISSUE: Control BD_SIKKN_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL712.BD_SIKKN_T(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '売差
                'UPGRADE_ISSUE: Control BD_BAISA_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Wk_Index = CShort(UODDL712.BD_BAISA_T(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '売差率
                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                Else
                    'UPGRADE_ISSUE: Control BD_BSART_T は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                End If
                'change 20190325 END saiki
            End With
			
			'行情報構造体配列の Redim
			MaxPageNum = F_Ctl_Add_BlankRow(pm_All)
			
			NowPageNum = 1
		End If
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		' 2007/03/04  ADD START  KUMEDA
		Call CF_Clr_Prompt(pm_All)
		' 2007/03/04  ADD END
		
		F_GET_BD_DATA_KIS_MEISAI = intCnt
		
		Exit Function
		
ERR_F_GET_BD_DATA_KIS_MEISAI: 
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_SET_BD_DATA
	'   概要：  ボディ部データ取得
	'   引数：　pm_All      :全構造体
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_SET_BD_DATA(ByRef pm_All As Cls_All) As Object
		
		Dim Row_Cnt As Short
		Dim Index_Cnt As Short
		Dim Bd_Index As Short
		
		'明細編集
		Call CF_Body_Dsp(pm_All)
		
		If pm_All.Dsp_Base.FormCtl.Name = "FR_SSSMAIN" Then
			'部門別総括表画面
			'オプションボタン使用制御
			For Row_Cnt = 1 To pm_All.Dsp_Base.Dsp_Body_Cnt
                With pm_All.Dsp_Base.FormCtl
                    'delete 20190325 START saiki
                    ''UPGRADE_ISSUE: Control BD_MEISYO は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    'If (Trim(.BD_MEISYO(Row_Cnt).Text) = Trim(gc_Sum_Text_Kei)) Or (Trim(.BD_MEISYO(Row_Cnt).Text) = Trim(gc_Sum_Text_Syokei)) Or (Trim(.BD_MEISYO(Row_Cnt).Text) = Trim(gc_Sum_Text_Gokei)) Or (Trim(.BD_MEISYO(Row_Cnt).Text) = "") Then
                    '    '集計欄、または空欄の場合
                    '    'UPGRADE_ISSUE: Control BD_SELECTB は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    '    .BD_SELECTB(Row_Cnt).Enabled = False

                    'Else
                    '    '部門、地区、営業欄の場合
                    '    'UPGRADE_ISSUE: Control BD_SELECTB は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    '    .BD_SELECTB(Row_Cnt).Enabled = True

                    'End If
                    'delete 20190325 END saiki
                End With
			Next 
			
			For Index_Cnt = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
				If pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.Name <> "BD_SELECTB" Then
					'Dsp_Body_Infの行ＮＯ取得
					Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Index_Cnt), pm_All)
					
					'背景色制御
					Select Case pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DIVISION
						Case "1"
							'部門
							pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_LIGHTGREEN)
						Case "2"
							'地区
							pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_BLUE)
						Case "99"
							'全社
							pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_GREEN)
					End Select
				End If
				
				If pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.Name = "BD_BSART" Then
					'売差率の背景色制御
					'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If (Trim(pm_All.Dsp_Sub_Inf(Index_Cnt - 1).Detail.Dsp_Value) <> "") And (Trim(pm_All.Dsp_Sub_Inf(Index_Cnt).Detail.Dsp_Value) = "") Then
                        pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = ACE_CMN.COLOR_RED
                        'delete 20190325 START saiki
                        'Else
                        '	'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf(Index_Cnt - 1).Ctl.BackColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '                   pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(pm_All.Dsp_Sub_Inf(Index_Cnt - 1).Ctl.BackColor)
                        'delete 20190325 END saiki
					End If
				End If
			Next 
			
		ElseIf pm_All.Dsp_Base.FormCtl.Name = "FR_SSSMAIN1" Then 
			'機種別総括表画面
			For Index_Cnt = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
				'Dsp_Body_Infの行ＮＯ取得
				Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Index_Cnt), pm_All)
				
				'背景色制御
				Select Case pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DIVISION
					Case "1"
						'商品群グループ別合計
						pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_LIGHTGREEN)
						' 2007/01/12  ADD START  KUMEDA
					Case "3"
						'商品群別合計
						pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_BLUE)
						' 2007/01/12  ADD END
					Case "99"
						'総合計
						pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_GREEN)
				End Select
				If pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.Name = "BD_BSART" Then
					'売差率の背景色制御
					'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If (Trim(pm_All.Dsp_Sub_Inf(Index_Cnt - 1).Detail.Dsp_Value) <> "") And (Trim(pm_All.Dsp_Sub_Inf(Index_Cnt).Detail.Dsp_Value) = "") Then
                        pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = ACE_CMN.COLOR_RED
                        'delete 20190325 START saiki
                        'Else
                        '	'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf(Index_Cnt - 1).Ctl.BackColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '                   pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(pm_All.Dsp_Sub_Inf(Index_Cnt - 1).Ctl.BackColor)
                        'delete 20190325 END saiki
					End If
				End If
			Next 
			
		ElseIf pm_All.Dsp_Base.FormCtl.Name = "FR_SSSMAIN2" Then 
			'機種明細表画面
			For Index_Cnt = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
				'Dsp_Body_Infの行ＮＯ取得
				Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Index_Cnt), pm_All)
				
				'背景色制御
				Select Case pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DIVISION
					Case "1"
						'商品群合計
						pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_LIGHTGREEN)
					Case "2"
						'分類Ａ合計
						pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_BLUE)
					Case "3"
						'分類Ｂ合計
						pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_LIGHTYELLOW)
					Case "99"
						'総合計
						pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_GREEN)
				End Select
				
				If pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.Name = "BD_BSART_T" Then
					'売差率の背景色制御
					'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If (Trim(pm_All.Dsp_Sub_Inf(Index_Cnt - 1).Detail.Dsp_Value) <> "") And (Trim(pm_All.Dsp_Sub_Inf(Index_Cnt).Detail.Dsp_Value) = "") Then
                        pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = ACE_CMN.COLOR_RED
                        'delete 20190325 START saiki
                        'Else
                        '	'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf(Index_Cnt - 1).Ctl.BackColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '                   pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(pm_All.Dsp_Sub_Inf(Index_Cnt - 1).Ctl.BackColor)
                        'delete 20190325 END saiki
					End If
				End If
			Next 
		End If
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_Item_Change
	'   概要：  対象項目のCHANGEの制御
	'   引数：　pm_Dsp_Sub_Inf      :画面項目情報
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_Change(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Wk_CurMoji As String
		Dim Wk_Cnt As Short
		Dim Wk_EditMoji As String
		Dim Wk_DspMoji As String
		Dim Move_Flg As Boolean
		
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		Select Case True
            Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
                'change start 20190805 kuwahara
                'ﾃｷｽﾄﾎﾞｯｸｽの場合()
                '現在のﾃｷｽﾄ上の選択状態を取得()
                'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
                Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
                'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
                Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
                'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
                Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
                'change end 20190805 kuwahara

                Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)

                '現在の値を取得
                'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Wk_CurMoji = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

                Wk_EditMoji = ""

                Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
                    Case IN_TYP_NUM
                        '数値項目の場合
                        'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
                    Case IN_TYP_DATE
                        '日付項目の場合
                        'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
                    Case IN_TYP_CODE, IN_TYP_STR
                        'コード、文字項目
                        Select Case pm_Dsp_Sub_Inf.Detail.In_Str_Typ
                            '変更後の値変換
                            Case IN_STR_TYP_N
                                '全角の場合
                                '半角空白⇒全角空白
                                For Wk_Cnt = 1 To Len(Wk_CurMoji)
                                    If Mid(Wk_CurMoji, Wk_Cnt, 1) = Space(1) Then
                                        Wk_EditMoji = Wk_EditMoji & "　"
                                    Else
                                        Wk_EditMoji = Wk_EditMoji & Mid(Wk_CurMoji, Wk_Cnt, 1)
                                    End If
                                Next

                            Case Else
                                '全角以外
                                '半角空白⇒全角空白
                                For Wk_Cnt = 1 To Len(Wk_CurMoji)
                                    If Mid(Wk_CurMoji, Wk_Cnt, 1) = "　" Then
                                        Wk_EditMoji = Wk_EditMoji & Space(2)
                                    Else
                                        Wk_EditMoji = Wk_EditMoji & Mid(Wk_CurMoji, Wk_Cnt, 1)
                                    End If
                                Next

                        End Select
                    Case IN_TYP_YYYYMM
                        '年月項目の場合
                        'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)

                    Case IN_TYP_HHMM
                        '時刻項目の場合
                        'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)

                    Case Else
                End Select

                '編集後の文字を表示形式に変換
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, False)

                '選択文字と入力文字の置き換え
                '文字設定
                Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)

                '現在ﾌｫｰｶｽ位置から右へ移動
                Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, pm_All, True)
				
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.CheckBox
				
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.RadioButton
				
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.PictureBox
				
		End Select
		
		'入力後処理
		Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
		'明細入力後の後処理
		Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
	End Function
	
	
	'======================= 変更部分 2006.06.12 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_Item_GotFocus
	'   概要：  対象項目のGOTFOCUSの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_GotFocus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Move_Flg As Boolean
		
		If CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All) = False Then
			'ﾌｫｰｶｽを受け取れない場合
			'@'        '次の項目へﾌｫｰｶｽ移動
			'@'        If TypeOf pm_Dsp_Sub_Inf.Ctl Is SSCommand5 Then
			'@'            Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, Move_Flg, pm_All)
			'@'        Else
			'@'        '元の項目へﾌｫｰｶｽ移動
			'@'            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Cursor_Idx), pm_All)
			'@'        End If
			
			'元の項目へﾌｫｰｶｽ移動
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Cursor_Idx), pm_All)
		Else
			
			'移動前と異なる場合のみ退避
			If pm_All.Dsp_Base.Cursor_Idx <> CShort(pm_Dsp_Sub_Inf.Ctl.Tag) Then
				'前ﾌｫｰｶｽのｲﾝﾃﾞｯｸｽを退避
				pm_All.Dsp_Base.Bef_Cursor_Idx = pm_All.Dsp_Base.Cursor_Idx
				'移動後のｲﾝﾃﾞｯｸｽを退避
				pm_All.Dsp_Base.Cursor_Idx = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
			End If
			
			'選択状態の設定（初期選択）
			Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
			'項目色設定
			' 2006/12/18  CHG START  KUMEDA
			'        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
			Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
			' 2006/12/18  CHG END
		End If
		
	End Function
	'======================= 変更部分 2006.06.12 End =================================
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_Item_KeyPress
	'   概要：  対象項目のKEYPRESSの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_KeyPress(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_KeyAscii As Short, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, ByRef pm_Run_Flg As Boolean) As Short
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim All_Sel_Flg As Boolean
		Dim wk_Moji As String
		Dim Wk_SelMoji As String
		Dim Wk_BefMoji As String
		Dim Wk_DelMoji As String
		Dim Wk_EditMoji As String
		Dim Wk_DspMoji As String
		Dim Wk_Cnt As Short
		Dim Wk_SelStart As Short
		Dim Wk_SelLength As Short
		Dim Wk_CurMoji As String
		Dim Input_Flg As Boolean
		Dim Re_Body_Crt As Boolean
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		'入力フラグ初期化
		Input_Flg = False
		'明細部再作成フラグ初期化
		Re_Body_Crt = False
		
		'以下の入力の場合、無視する
		Select Case pm_KeyAscii
			Case 1 To 7, 9 To 12, 14 To 29, 127
				Beep()
				pm_KeyAscii = 0
				Exit Function
		End Select
		
		'入力文字取得
		wk_Moji = Chr(pm_KeyAscii)
		
		'ﾃｷｽﾄﾎﾞｯｸｽのみ対象
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
            'change start 20190805 kuwahara
            'ﾃｷｽﾄﾎﾞｯｸｽの場合()
            '現在のﾃｷｽﾄ上の選択状態を取得()
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            'change end 20190805 kuwahara

            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			'現在の値を取得
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Wk_CurMoji = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
			
			All_Sel_Flg = False
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'全選択の場合（選択文字が最大バイト数と一致）
				All_Sel_Flg = True
			End If
			
			'入力コード判定
			If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, wk_Moji) = 1 Then
				'入力可能文字の場合
				
				'入力可能な文字の場合、入力後処理、明細部再作成を行う
				Input_Flg = True
				Re_Body_Crt = True
				
				'CF_Jge_Input_Str関数の文字変更を考慮
				pm_KeyAscii = Asc(wk_Moji)
				
				'日付/年月/時刻でかつ選択状態が１つ以外の場合、入力不可
				'表示形式が決まっているため一つずつ入力させる
				Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
					Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM
						If Act_SelLength <> 1 Then
							Beep()
							pm_KeyAscii = 0
							Exit Function
						End If
				End Select
				
				If All_Sel_Flg = True Then
					'全選択時
					
					If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
						'詰文字が左詰の場合
						Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & wk_Moji
						
					Else
						'詰文字が左詰以外の場合
						Wk_EditMoji = wk_Moji & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
						
					End If
					
					'編集後の文字を表示形式に変換
					'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
					
					'編集後のSelStartを決定
					If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
						'詰文字が左詰の場合
						'右端へ移動
						Wk_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
						Wk_SelLength = 0
					Else
						'詰文字が左詰以外の場合
						Wk_SelStart = 0
						Wk_SelLength = 1
					End If
					
					'削除後の文字置き換え
					'文字設定
					Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
					pm_KeyAscii = 0

                    'change start 20190805 kuwa
                    ''編集後のSelStartを決定
                    ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart + 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart + 1
                    ''編集後のSelLengthを決定
                    ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '               pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                    'change end 20190805 kuwahara

                    '数値項目特別処理
                    If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
						
						'小数部があり小数桁数と設定値が同じ場合
						If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
							'現在ﾌｫｰｶｽ位置から右へ移動
							Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
						Else
							If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
								'編集後の文字がMAXの場合
								'現在ﾌｫｰｶｽ位置から右へ移動
								Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
							End If
						End If
						
					Else
						'数値項目以外
                        If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                            'change start 20190805 kuwahara
                            ''編集後の文字がMAXの場合
                            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Len(wk_Moji)
                            ''編集後のSelLengthを決定
                            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 0
                            'change end 20190805
                            '現在ﾌｫｰｶｽ位置から右へ移動
                            Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                        End If
					End If
					
				Else
					'部分選択もしくは、選択なし
					
					If Act_SelLength = 0 Then
						'選択なしの場合(挿入状態)
						'挿入部分の前の文字を取得
						Wk_BefMoji = Left(Wk_CurMoji, Act_SelStart)
						'数値項目特別処理
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							Select Case wk_Moji
								Case "+"
									'｢＋｣入力時
									If Trim(Wk_BefMoji) <> "" Then
										'前文字が上記の文字以外は挿入できない
										'入力不可
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
									
								Case "-"
									'｢－｣入力時
									If Trim(Wk_BefMoji) <> "" Then
										'前文字が上記の文字以外は挿入できない
										'入力不可
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
									
								Case "."
									'｢．｣入力時
									If InStr(Wk_CurMoji, ".") > 1 Then
										'すでに｢．｣が入力されいる場合
										'入力不可
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
							End Select
						End If
						
						If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
							'空白除去後の現在の文字がMAXの場合、オーバーフロー
							
							'数値項目特別処理
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								'一番右でオーバーフローした場合、次の項目へ
								If Act_SelStart >= Len(Wk_CurMoji) Then
									'編集前の開始位置が一番右の場合
									'現在ﾌｫｰｶｽ位置から右へ移動
									Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								Else
									'入力不可
									Beep()
								End If
							Else

                                '編集後の移動先を判定
                                If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                                    '詰文字が左詰の場合
                                Else
                                    '編集後のSelStartを決定
                                    If Act_SelStart + 1 > Len(Wk_CurMoji) Then
                                        '１つ右の位置が右端の場合
                                        Wk_SelStart = Len(Wk_CurMoji)
                                    Else
                                        '１つ右へ
                                        Wk_SelStart = Act_SelStart + 1
                                    End If
                                    '編集後のSelLengthを決定
                                    Wk_SelLength = 0
                                    'change start 20190805 kuwahara
                                    '編集後のSelStartを決定
                                    ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                                    ''編集後のSelLengthを決定
                                    ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    '                           pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                                    'change end 20190805 kuwahara
                                End If
                                '入力不可
                                Beep()
							End If
							
							'入力不可
							pm_KeyAscii = 0
							Exit Function
						End If
						
						'文字編集
						Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Chr(pm_KeyAscii) & Mid(Wk_CurMoji, Act_SelStart + 1)
						
						'編集後の文字を表示形式に変換
						'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
						
						'数値項目特別処理
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							'整数部で整数桁数より多く入力されている場合
							If Len(CF_Get_Num_Int_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
								'入力不可
								pm_KeyAscii = 0
								Exit Function
							End If
							
							'小数部があり小数桁数と設定値が同じ場合
							If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
								'現在ﾌｫｰｶｽ位置から右へ移動
								Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								'入力不可
								pm_KeyAscii = 0
								Exit Function
							End If
						End If
						
						'編集後のSelStartを決定
						If Act_SelStart + 1 > Len(Wk_DspMoji) Then
							'１つ右の位置が右端の場合
							Wk_SelStart = Len(Wk_DspMoji)
						Else
							'１つ右へ
							Wk_SelStart = Act_SelStart + 1
						End If
						'編集後のSelLengthを決定
						Wk_SelLength = 0
						
						'削除後の文字置き換え
						'文字設定
						Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
						pm_KeyAscii = 0

                        'change start 20190805 kuwahara
                        '編集後のSelStartを決定
                        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                        ''編集後のSelLengthを決定
                        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '                  pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                        'change end 20190805 kuwahara

                        '編集後の移動先を判定
                        If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
							'詰文字が左詰の場合
							
							If Wk_SelStart >= Len(Wk_DspMoji) Then
								'編集後の開始位置が一番右の場合
								'数値項目特別処理
								If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
									'小数部があり小数桁数と設定値が同じ場合
									If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
										'現在ﾌｫｰｶｽ位置から右へ移動
										Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									Else
										If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
											'編集後の文字がMAXの場合
											'現在ﾌｫｰｶｽ位置から右へ移動
											Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
										End If
									End If
								Else
									'数値項目以外
									If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
										'編集後の文字がMAXの場合
										'現在ﾌｫｰｶｽ位置から右へ移動
										Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									End If
								End If
							End If
						Else
							'詰文字が左詰以外の場合
							If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                                '編集後の文字がMAXの場合
                                'change start 20190805 kuwahara
                                ''編集後のSelStartを決定
                                ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Len(Wk_DspMoji)
                                ''編集後のSelLengthを決定
                                ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 1
                                'change end 20190805 kuwahara
                                '現在ﾌｫｰｶｽ位置から右へ移動
                                Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
							End If
						End If
					Else
						'一部選択
						'現在選択されている文字の１桁を取得
						Wk_SelMoji = Mid(Wk_CurMoji, Act_SelStart + 1, 1)
						
						If Trim(Wk_SelMoji) <> "" And CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Wk_SelMoji) <> 1 Then
							'選択文字が空文字以外でかつ入力対象の文字以外の場合
							
							'入力不可
							Beep()
							pm_KeyAscii = 0
							Exit Function
						End If
						
						'数値項目特別処理
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							Select Case wk_Moji
								Case "+"
									'｢＋｣入力時
									If Wk_SelMoji <> "-" And Wk_SelMoji <> "." And Wk_SelMoji <> "%" And Trim(Wk_SelMoji) <> "" Then
										'選択文字が上記の文字以外は置き換えられない
										'入力不可
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
									
								Case "-"
									'｢－｣入力時
									If Wk_SelMoji <> "+" And Wk_SelMoji <> "." And Wk_SelMoji <> "%" And Trim(Wk_SelMoji) <> "" Then
										'選択文字が上記の文字以外は置き換えられない
										'入力不可
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
									
								Case "."
									'｢．｣入力時
									If InStr(Wk_CurMoji, ".") > 0 Then
										'すでに｢．｣が入力されいる場合
										'入力不可
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
							End Select
						End If
						
						'文字編集
						Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Chr(pm_KeyAscii) & Mid(Wk_CurMoji, Act_SelStart + Act_SelLength + 1)
						
						'編集後の文字を表示形式に変換
						'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
						
						'数値項目特別処理
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							'整数部無しの場合
							'整数部ありで整数桁数より多く入力されている場合
							If Len(CF_Get_Num_Int_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
								'入力不可
								pm_KeyAscii = 0
								Exit Function
							End If
							
							'小数部があり小数桁数と設定値が同じ場合
							If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
								'現在ﾌｫｰｶｽ位置から右へ移動
								Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								'入力不可
								pm_KeyAscii = 0
								Exit Function
							End If
						End If
						
						If Act_SelStart >= Len(Wk_DspMoji) - 1 Then
							'編集前の開始位置が最後の文字以降の場合
							'編集後のSelStartを決定
							Wk_SelStart = Len(Wk_DspMoji)
							'編集後のSelLengthを決定
							Wk_SelLength = 0
						Else
							'編集後のSelStartを決定
							Wk_SelStart = Act_SelStart
							'編集後のSelLengthを決定
							Wk_SelLength = 1
						End If
						
						'数値項目特別処理
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							If Len(CF_Get_Input_Ok_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) = 1 Then
								'入力可能な文字が１桁の場合
								'開始位置を一番右に設定
								'編集後のSelStartを決定
								Wk_SelStart = Len(Wk_DspMoji)
								'編集後のSelLengthを決定
								Wk_SelLength = 0
							End If
							
						End If
						
						'編集後の文字置き換え
						'文字設定
						Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
						pm_KeyAscii = 0
                        'change start 20190805 kuwahara
                        ''編集後のSelStartを決定
                        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                        ''編集後のSelLengthを決定
                        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                        'change end 20190805 kuwahara
                        '編集後の移動先を判定
                        If Wk_SelStart >= Len(Wk_DspMoji) - 1 Then
							'編集後の開始位置が最後の文字以降の場合
							'数値項目特別処理
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								
								'小数部があり小数桁数と設定値が同じ場合
								If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
									'現在ﾌｫｰｶｽ位置から右へ移動
									Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								Else
									If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
										'編集後の文字がMAXの場合
										'現在ﾌｫｰｶｽ位置から右へ移動
										Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									End If
								End If
								
							Else
								'数値項目以外
								If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
									'編集後の文字がMAXの場合
									'現在ﾌｫｰｶｽ位置から右へ移動
									Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								End If
							End If
						Else
							'現在ﾌｫｰｶｽ位置から右へ移動
							Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
						End If
						
					End If
				End If
				
			Else
				'入力コード以外
				Select Case pm_KeyAscii
					Case System.Windows.Forms.Keys.Back
						'BackSpaceキー
						pm_KeyAscii = 0
						
						'日付/年月/時刻の場合
						Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
							Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM
								'削除後のSelStartを決定
								Wk_SelStart = Act_SelStart
								For Wk_Cnt = Act_SelStart - 1 To 0 Step -1
									'削現在の開始位置から左へ移動し文字が入力対象かを判定
									If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Mid(Wk_CurMoji, Wk_Cnt + 1, 1)) = 1 Then
										'入力文字でない場合
										Wk_SelStart = Wk_Cnt
										Exit For
									End If
									
								Next 
								'編集後のSelLengthを決定
								Wk_SelLength = Act_SelLength
                                'change start 20190805 kuwahara
                                ''編集後のSelStartを決定
                                ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                                ''編集後のSelLengthを決定
                                ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                                'change end 20190805 kuwahara
                                '削除不可
                                Exit Function
							Case Else
								
						End Select
						
						If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
							'詰文字が左詰の場合
							'開始位置が左の場合、終了
							If Act_SelStart = 0 Then
								'削除不可
								Exit Function
							End If
							
							'削除対象の文字１桁を取得
							Wk_DelMoji = Mid(Wk_CurMoji, Act_SelStart, 1)
							
							'数値項目特別処理
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								If Wk_DelMoji = "." Then
									'削除対象の文字が小数点の場合
									If Len(CF_Get_Num_Int_Part(Wk_CurMoji)) + Len(CF_Get_Num_Fra_Part(Wk_CurMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
										'削除後の桁数オーバーの場合
										'削除不可
										Exit Function
									End If
								End If
							End If
							
							'削除文字の判定
							If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Wk_DelMoji) = 1 Then
								'削除文字が入力対象の文字の場合
								If CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf) <> "" Then
									'文字編集
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & Left(Wk_CurMoji, Act_SelStart - 1) & Mid(Wk_CurMoji, Act_SelStart + 1)
								Else
									'削除対象がない為、空白を編集
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								End If
							Else
								'削除文字が入力対象の文字の以外場合
								'そのまま
								Wk_EditMoji = Wk_CurMoji
							End If
							
							'削除後の文字を表示形式に変換
							'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
							
							'削除後のSelStartを決定
							Wk_SelStart = Act_SelStart
							For Wk_Cnt = Act_SelStart To Len(Wk_CurMoji) - 1
								'削除後に現在の開始位置からの文字が入力対象かを判定
								If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Mid(Wk_DspMoji, Wk_Cnt + 1, 1)) = 1 Then
									Exit For
								End If
								'入力文字でない場合、右へ移動
								Wk_SelStart = Wk_SelStart + 1
							Next 
							'編集後のSelLengthを決定
							Wk_SelLength = Act_SelLength
							
							'数値項目特別処理
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								'数値項目で未入力の場合は、一番右を開始位置に設定
								If CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf) = "" Then
									Wk_SelStart = Len(Wk_DspMoji)
									'編集後のSelLengthを決定
									Wk_SelLength = 0
								End If
							End If
						Else
							'詰文字が左詰以外の場合
							If Act_SelStart = 0 Then
								'開始位置が一番左の場合
								If CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf) <> "" Then
									'文字編集
									Wk_EditMoji = Right(Wk_CurMoji, Len(Wk_CurMoji) - 1) & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								Else
									'削除対象がない為、空白を編集
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								End If
								
								'削除後のSelStartを決定
								Wk_SelStart = Act_SelStart
							Else
								'文字編集
								Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart - 1) & Mid(Wk_CurMoji, Act_SelStart + 1) & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								
								'削除後のSelStartを決定
								Wk_SelStart = Act_SelStart - 1
							End If
							'編集後のSelLengthを決定
							Wk_SelLength = Act_SelLength
							
							'編集後の文字を表示形式に変換
							'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
						End If
						
						'削除後の文字置き換え
						'文字設定
						Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
                        'change start 20190805 kuwahara
                        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                        'change end 20190805　kuwahara

                        'add start 20190823 kuwa
                        'ﾃｷｽﾄﾎﾞｯｸｽが空白時にエンターを押すと黄色のフォーカスが残る不具合を修正
                    Case System.Windows.Forms.Keys.Return
                        pm_Move_Flg = True
                        pm_KeyAscii = 0
                        'add end 20190823 kuwa
                    Case Else

                        pm_KeyAscii = 0
						
				End Select
			End If
		End If
		
		If Input_Flg = True Then
			'入力後処理
			Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		End If
		
		If Re_Body_Crt = True Then
			'明細入力後の後処理
			Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		End If
		
	End Function
	
	'======================= 変更部分 2006.07.02 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_Item_MouseDown
	'   概要：  対象項目のMOUSEDOWNの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_MouseDown(ByRef pm_Trg_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All, ByRef pm_Button As Short, ByRef pm_Shift As Short, ByRef pm_X As Single, ByRef pm_Y As Single) As Short
		Dim Wk_Index As Short
		Dim bolSameCtl As Boolean
		
		If pm_Button = VB6.MouseButtonConstants.RightButton Then
			'右クリック
			
			bolSameCtl = False
            If CShort(pm_Trg_Dsp_Sub_Inf.Ctl.Tag) = CShort(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
                'delete 20190325 START saiki
                '右クリックしたコントロールがアクティブなコントロールと一致
                'カーソル制御用テキストにフォーカスを一時的に退避
                'UPGRADE_ISSUE: Control TX_CursorRest は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.TX_CursorRest.Tag)
                'delete 20190325 END saiki
                Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
                bolSameCtl = True
            End If
            'delete 20190325 START saiki
            ''｢項目内容コピー｣判定
            ''UPGRADE_ISSUE: Control SM_AllCopy は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            'pm_All.Dsp_Base.FormCtl.SM_AllCopy = CF_Jge_Enabled_SM_AllCopy(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All)

            ''｢項目内容に貼り付け｣判定
            ''UPGRADE_ISSUE: Control SM_FullPast は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            'pm_All.Dsp_Base.FormCtl.SM_FullPast = CF_Jge_Enabled_SM_FullPast(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All)
            'delete 20190325 END saiki
			'対象コントロールの使用不可
			pm_Trg_Dsp_Sub_Inf.Ctl.Enabled = False
			
			'｢ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰ｣判定
			If CF_Jge_Enabled_PopupMenu(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All) = True Then
				'ﾛｽﾄﾌｫｰｶｽｲﾍﾞﾝﾄの抑制
				pm_All.Dsp_Base.LostFocus_Flg = True
				'ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰ表示
				'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
				'UPGRADE_ISSUE: Control SM_ShortCut は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
				'UPGRADE_ISSUE: Form メソッド Dsp_Base.FormCtl.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                'delete 20190325 START saiki
                'pm_All.Dsp_Base.FormCtl.PopupMenu(pm_All.Dsp_Base.FormCtl.SM_ShortCut, vbPopupMenuLeftButton)
                'delete 20190325 END saiki
				'ﾛｽﾄﾌｫｰｶｽｲﾍﾞﾝﾄの抑制解除
				pm_All.Dsp_Base.LostFocus_Flg = False
				System.Windows.Forms.Application.DoEvents()
			End If
			
			'ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰ表示状態で画面の終了処理に入ってしまった場合は、
			'以降の処理は行わない。
			If pm_All.Dsp_Base.IsUnload = True Then
				Exit Function
			End If
			
			'対象コントロールの使用可
			pm_Trg_Dsp_Sub_Inf.Ctl.Enabled = True
			'フォーカスを移動を元に戻す
			If bolSameCtl = True Then
				Call CF_Set_Item_SetFocus(pm_Trg_Dsp_Sub_Inf, pm_All)
			End If
			
		End If
		
	End Function
	'======================= 変更部分 2006.07.02 End =================================
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_VS_Scrl_CHANGE
	'   概要：  VS_ScrlのMOUSEDOWNの制御
	'   引数：　pm_Dsp_Sub_Inf      :画面項目情報
	'           pm_Act_Dsp_Sub_Inf  :画面項目情報
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_VS_Scrl_Change(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim Move_Flg As Boolean
		Dim Row_Move_Value As Short
		Dim Cur_Row As Short
		Dim Next_Row As Short
		Dim Next_Index As Short
		
		'最上明細ｲﾝﾃﾞｯｸｽを退避
		Cur_Top_Index = pm_All.Dsp_Body_Inf.Cur_Top_Index
		
		'画面の内容を退避
		Call CF_Body_Bkup(pm_All)
		'======================= 変更部分 2006.06.26 Start =================================
		'縦スクロールバーの値を最上明細ｲﾝﾃﾞｯｸｽに設定
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_All.Dsp_Body_Inf.Cur_Top_Index = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
		'画面ボディ情報の配列を再設定
		Call CF_Dell_Refresh_Body_Inf(pm_All)
		'======================= 変更部分 2006.06.26 End =================================
		'画面表示
		Call CF_Body_Dsp(pm_All)
		
		'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙが明細部のみ制御
		If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
			
			'現在の行を取得
			Cur_Row = pm_Act_Dsp_Sub_Inf.Detail.Body_Index
			'ﾌｫｰｶｽ制御
			'移動量
			Row_Move_Value = Cur_Top_Index - pm_All.Dsp_Body_Inf.Cur_Top_Index
			
			'移動後の行
			Next_Row = Cur_Row + Row_Move_Value
			If Next_Row <= 0 Then
				Next_Row = 1
			End If
			If Next_Row > pm_All.Dsp_Base.Dsp_Body_Cnt Then
				Next_Row = pm_All.Dsp_Base.Dsp_Body_Cnt
			End If
			
			'移動後の行のの同一項目のｲﾝﾃﾞｯｸｽを取得
			Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Act_Dsp_Sub_Inf, Next_Row, pm_All)
			If Next_Index > 0 Then
				If Next_Index = CShort(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
					'同一ｺﾝﾄﾛｰﾙの場合
					'選択状態の設定（初期選択）
					Call CF_Set_Sel_Ini(pm_Act_Dsp_Sub_Inf, SEL_INI_MODE_2)
					'項目色設定
					' 2006/12/18  CHG START  KUMEDA
					'                Call CF_Set_Item_Color(pm_Act_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
					Call CF_Set_Item_Color_MEISAI(pm_Act_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
					' 2006/12/18  CHG END
				Else
					'同一ｺﾝﾄﾛｰﾙでない場合
					'同一項目の１つ前からENTキー押下と同様に次の項目へ
					Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				End If
			Else
				'入力可能な最初のインデックスを取得
				Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(Next_Row, pm_All)
				If Focus_Ctl_Ok_Fst_Idx > 0 Then
					'同一項目の１つ前からENTキー押下と同様に次の項目へ
					Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					
					If Row_Move_Value > 0 Then
						'上へ移動
						'ヘッダ部の最後の項目の１つ後ろから
						'１つ前の項目へ
						Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), Move_Flg, pm_All)
					Else
						'下へ移動
						'フッタ部の最初の項目の１つ前から
						'ENTキー押下と同様に次の項目へ
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
					End If
				End If
			End If
		End If
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_Dsp_Body_Page
	'   概要：  明細部分のページ制御
	'   引数：　pm_Page_Value       :明細のページ数
	'           pm_Dsp_Sub_Inf      :画面項目情報
	'           pm_all              :全構造体
	'           pm_Border_Body_Cnt  :
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Dsp_Body_Page(ByRef pm_Page_Value As Short, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All, Optional ByRef pm_Border_Body_Cnt As Short = 0) As Short
		
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim Move_Flg As Boolean
		Dim Row_Move_Value As Short
		Dim Cur_Row As Short
		Dim Next_Row As Short
		Dim Next_Index As Short
		
		'最上明細ｲﾝﾃﾞｯｸｽを退避
		Cur_Top_Index = pm_All.Dsp_Body_Inf.Cur_Top_Index
		
		'画面の内容を退避
		Call CF_Body_Bkup(pm_All)
		'最上明細ｲﾝﾃﾞｯｸｽに設定
		'（画面表示明細数－境界明細数）×（ページ数－１）＋１　　⇒１、６、１１、１６となる
		pm_All.Dsp_Body_Inf.Cur_Top_Index = (pm_All.Dsp_Base.Dsp_Body_Cnt - pm_Border_Body_Cnt) * (pm_Page_Value - 1) + 1
		'画面表示
		Call CF_Body_Dsp(pm_All)
		
		'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙが明細部のみ制御
		If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
			
			'現在の行を取得
			Cur_Row = pm_Act_Dsp_Sub_Inf.Detail.Body_Index
			'ﾌｫｰｶｽ制御
			'移動量
			Row_Move_Value = Cur_Top_Index - pm_All.Dsp_Body_Inf.Cur_Top_Index
			
			'移動後の行
			Next_Row = Cur_Row + Row_Move_Value
			If Next_Row <= 0 Then
				Next_Row = 1
			End If
			If Next_Row > pm_All.Dsp_Base.Dsp_Body_Cnt Then
				Next_Row = pm_All.Dsp_Base.Dsp_Body_Cnt
			End If
			
			'移動後の行のの同一項目のｲﾝﾃﾞｯｸｽを取得
			Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Act_Dsp_Sub_Inf, Next_Row, pm_All)
			If Next_Index > 0 Then
				If Next_Index = CShort(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
					'同一ｺﾝﾄﾛｰﾙの場合
					'選択状態の設定（初期選択）
					Call CF_Set_Sel_Ini(pm_Act_Dsp_Sub_Inf, SEL_INI_MODE_2)
					'項目色設定
					Call CF_Set_Item_Color(pm_Act_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
				Else
					'同一ｺﾝﾄﾛｰﾙでない場合
					'同一項目の１つ前からENTキー押下と同様に次の項目へ
					Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				End If
			Else
				'入力可能な最初のインデックスを取得
				Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(Next_Row, pm_All)
				If Focus_Ctl_Ok_Fst_Idx > 0 Then
					'同一項目の１つ前からENTキー押下と同様に次の項目へ
					Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					
					If Row_Move_Value > 0 Then
						'上へ移動
						'ヘッダ部の最後の項目の１つ後ろから
						'１つ前の項目へ
						Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), Move_Flg, pm_All)
					Else
						'下へ移動
						'フッタ部の最初の項目の１つ前から
						'ENTキー押下と同様に次の項目へ
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
					End If
				End If
			End If
		End If
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Add_BlankRow
	'   概要：  空白行情報追加
	'   引数：　pm_All                :全構造体
	'   戻値：　必要ページ数
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Add_BlankRow(ByRef pm_All As Cls_All) As Short
		
		Dim Ret_Value As Short
		Dim intPage As Short
		Dim bolFind As Boolean
		Dim intBfrUBound As Short
		Dim intAfrUBound As Short
		Dim intIdx As Short
		
		Ret_Value = 0
		
		'初期化
		intBfrUBound = UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		intAfrUBound = 0
		intPage = 0
		bolFind = False
		
		'必要ページ数を取得
		'（ページ数に上限をもたせる場合は、ここに "Or intPage > NN" を追加？）
		Do Until bolFind = True
			'インクリメント
			intPage = intPage + 1
			'ページ数をもとに行情報配列の上限を算出
			intAfrUBound = pm_All.Dsp_Base.Dsp_Body_Cnt * intPage
			'行構造体の上限以上になったらページ数を退避し、ブレイク
			If intAfrUBound >= intBfrUBound Then
				Ret_Value = intPage
				bolFind = True
			End If
		Loop 
		
		'空白行情報を追加
		If intAfrUBound > intBfrUBound Then
			'行追加
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intAfrUBound)
			For intIdx = intBfrUBound + 1 To intAfrUBound
				'行項目情報コピー
				Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intIdx))
			Next intIdx
		End If
		
		F_Ctl_Add_BlankRow = Ret_Value
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Init_Dsp_Body
	'   概要：  指定された明細の初期値を設定する
	'   引数：　pm_Bd_Index     :明細行インデックス
	'           pm_all          :全構造体
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Dsp_Body(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All) As Short
		Dim Wk_Index As Short
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'    '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
		'    Call CF_Edi_Dsp_Body_Inf(pm_Bd_Index _
		''                           , pm_All.Dsp_Sub_Inf(Wk_Index) _
		''                           , pm_Bd_Index _
		''                           , pm_All)
		'
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Item_Input_Aft
	'   概要：  画面で項目入力された場合の後処理を行います
	'   引数：　pm_Dsp_Sub_Inf      :画面項目情報
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Item_Input_Aft(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		
		Dim Row_Inf_Max_S As Short
		Dim Row_Inf_Max_E As Short
		Dim Bd_Index As Short
		
		'明細の再作成を行う
		Call CF_Re_Crt_Body_Inf(pm_Dsp_Sub_Inf, pm_All, Row_Inf_Max_S, Row_Inf_Max_E)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'    '行を追加された後に
		'    '初期値を追加した行に対してループ内で１行ずつ行う
		'    'ここでの行は、Dsp_Body_Infの行！！
		'    For Bd_Index = Row_Inf_Max_S To Row_Inf_Max_E
		'        Call F_Init_Dsp_Body(Bd_Index, pm_All)
		'    Next
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Befe_Focus
	'   概要：  前のフォーカス位置設定(LEFTなど)
	'   引数：　pm_Dsp_Sub_Inf      :画面項目情報
	'           pm_Move_Flg         :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Befe_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, Optional ByRef pm_Run_Flg As Boolean = True) As Short
		Dim Trg_Index As Short
		Dim Index_Wk As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Lst_Idx As Short
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		
		'次の項目を検索
		For Index_Wk = Trg_Index - 1 To 1 Step -1
			
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_TL And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
				'フッタ部からボディ部へ移動する場合
				'入力可能な最初のインデックスを取得
				Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index, pm_All)
				If Focus_Ctl_Ok_Fst_Idx > 0 Then
					Index_Wk = Focus_Ctl_Ok_Fst_Idx
				End If
				
			End If
			
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD Then
				'ボディ部からヘッダ部へ移動する場合
				If CF_Jdg_Row_Up_Focus(Cur_Top_Index, pm_All) = True Then
					'｢上移動した場合、ﾌｫｰｶｽ移動可能な行がある｣場合
					
					'画面の内容を退避
					Call CF_Body_Bkup(pm_All)
					'移動可能行を一番上に表示した場合の最上明細インデックスを設定
					pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
					If pm_All.Bd_Vs_Scrl Is Nothing = False Then
						'縦スクロールバーを設定
						Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
					End If
					'画面ボディ情報の配列を再設定
					Call CF_Dell_Refresh_Body_Inf(pm_All)
					'画面表示
					Call CF_Body_Dsp(pm_All)
					
					'入力可能な最後のインデックスを取得
					Focus_Ctl_Ok_Lst_Idx = CF_Get_Body_Focus_Ctl_Lst_Idx(1, pm_All)
					If Focus_Ctl_Ok_Lst_Idx > 0 Then
						Index_Wk = Focus_Ctl_Ok_Lst_Idx
					End If
					
				End If
			End If
			
			'ﾌｫｰｶｽ移動がOK
			If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All) = True Then
				If pm_Run_Flg = True Then
					'実行指定がある場合(基本あり)
					'ﾌｫｰｶｽ移動
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
				End If
				'移動フラグ決定
				pm_Move_Flg = True
				Exit For
			End If
		Next 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Next_Focus
	'   概要：  次のフォーカス位置設定(ENT、RIGHTなど)
	'   引数：　pm_Dsp_Sub_Inf      :画面項目情報
	'           pm_Mode             :モード
	'           pm_all              :全構造体
	'           pm_Move_Flg         :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_Run_Flg          :実行指定フラグ（T：あり、F：なし）
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, Optional ByRef pm_Run_Flg As Boolean = True) As Short
		Dim Sta_Index As Short
		Dim Index_Wk As Short
		Dim Rtn_Chk As Short
		Dim Bd_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim Focus_Ctl_Ok_Lst_Idx As Short
		Dim Focus_Ctl_Ok_Fst_Idx_Wk As Short
		Dim Cur_Top_Index As Short
		
		Dim bolDsp As Boolean
		Dim bolAllChk As Boolean
		Dim RtnCode As Short
		
		Dim Trg_Index As Short
        Dim Chk_Move_Flg As Boolean

        'add start 20190805 kuwa
        Dim form71 As Object

        If Trim(pm_All.Dsp_Base.FormCtl.Name) = "FR_SSSMAIN1" Then
            form71 = UODDL71
        Else
            form71 = UODDL712
        End If

        'add end 20190805 kuwa


        bolDsp = False
		bolAllChk = False
		RtnCode = -1
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CShort(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
			'ボディ部
			'Dsp_Body_Infの行ＮＯを取得
			Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
			
			If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_LST_ROW Then
				'最終準備行の場合
				'入力可能な最初のインデックスを取得
				Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
				
				If CShort(pm_Dsp_Sub_Inf.Ctl.Tag) = Focus_Ctl_Ok_Fst_Idx Then
					'入力可能な最初の項目の場合
					'モードにより検索開始位置を決定
					Select Case pm_Mode
						'======================= 変更部分 2006.07.02 Start =================================
						Case NEXT_FOCUS_MODE_KEYRETURN, NEXT_FOCUS_MODE_KEYDOWN
							'KEYRETURN、KEYDOWNの場合
							'======================= 変更部分 2006.07.02 End =================================
							'検索開始はフッタ部の最初の項目から
							Sta_Index = pm_All.Dsp_Base.Foot_Fst_Idx
							
						Case NEXT_FOCUS_MODE_KEYRIGHT
							'KEYRIGHTの場合
							'割当ｲﾝﾃﾞｯｸｽ取得
							'検索開始は対象の項目の次
							Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
							
					End Select
				Else
					'検索開始は対象の項目の次
					Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
				End If
				
			Else
				'最終準備行以外の場合
				If pm_Dsp_Sub_Inf.Detail.Body_Index = pm_All.Dsp_Base.Dsp_Body_Cnt Then
					'表示されている最終行の場合
					'入力可能な最後のインデックスを取得
					Focus_Ctl_Ok_Lst_Idx = CF_Get_Body_Focus_Ctl_Lst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
					
					If CShort(pm_Dsp_Sub_Inf.Ctl.Tag) = Focus_Ctl_Ok_Lst_Idx Then
						'入力可能な最後の項目の場合
						If CF_Jdg_Row_Down_Focus(Cur_Top_Index, pm_All) = True Then
							'最終準備行以外＆画面上の最終行＆最終項目
							'｢下移動した場合、ﾌｫｰｶｽ移動可能な行がある｣場合
							
							'画面の内容を退避
							Call CF_Body_Bkup(pm_All)
							'移動可能行を一番下に表示した場合の最上明細インデックスを設定
							pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
							If pm_All.Bd_Vs_Scrl Is Nothing = False Then
								'縦スクロールバーを設定
								Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
							End If
							'======================= 変更部分 2006.07.02 Start =================================
							'画面ボディ情報の配列を再設定
							Call CF_Dell_Refresh_Body_Inf(pm_All)
							'======================= 変更部分 2006.07.02 End =================================
							'画面表示
							Call CF_Body_Dsp(pm_All)
							
							'明細１番下行の入力可能な最初のインデックスを取得
							Focus_Ctl_Ok_Fst_Idx_Wk = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
							If Focus_Ctl_Ok_Fst_Idx_Wk > 0 Then
								'明細１番下行の最初の項目の一つ前から検索
								Sta_Index = Focus_Ctl_Ok_Fst_Idx_Wk - 1
							Else
								'検索開始は対象の項目の次
								Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
							End If
							
						Else
							'｢下移動した場合、ﾌｫｰｶｽ移動可能な行がない｣場合
							'検索開始は対象の項目の次
							Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
						End If
					Else
						'入力可能な最後の項目以外の場合
						'検索開始は対象の項目の次
						Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
					End If
					
				Else
					'最終行以外場合
					'検索開始は対象の項目の次
					Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
				End If
			End If
			
		Else
			'ボディ部以外
			'検索開始は対象の項目の次
			Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
		End If
		
		'部門の場合
		If (pm_Dsp_Sub_Inf.Detail.Item_Nm = "HD_BMNCD") Then
			'前回値と入力値が異なる場合
			If pv_JYOKEN_INPUT = True Then
                '入力値の退避
                'UPGRADE_ISSUE: Control HD_BMNCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'change start 20190805 kuwa
                'gv_UODDL71_BMNCD = pm_All.Dsp_Base.FormCtl.HD_BMNCD.Text
                gv_UODDL71_BMNCD = pm_Dsp_Sub_Inf.Ctl.Text
                'change end 20190805 kuwa

                gv_UODDL71_TIKCD = ""
				gv_UODDL71_EIGCD = ""

                '地区（クリア）
                'UPGRADE_ISSUE: Control HD_TIKCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'change start 20190805 kuwa
                'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_TIKCD.Tag)
                Trg_Index = CShort(form71.HD_TIKCD.Tag)
                'change end 20190805 kuwa
                Call CF_Set_Item_Direct(Space(2), pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_CLR, pm_All)

                '営業所（クリア）
                'UPGRADE_ISSUE: Control HD_EIGCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'change start 20190805 kuwa
                'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_EIGCD.Tag)
                Trg_Index = CShort(form71.HD_EIGCD.Tag)
                'change end 20190805 kuwa
                Call CF_Set_Item_Direct(Space(1), pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_CLR, pm_All)
			End If
		End If
		' 2007/01/17  ADD START  KUMEDA
		If Trim(gv_UODDL71_BMNCD) = "9" Then
			gv_UODDL71_BMNCD = " "
		End If
		If Trim(gv_UODDL71_TIKCD) = "99" Then
			gv_UODDL71_TIKCD = "  "
		End If
		If Trim(gv_UODDL71_EIGCD) = "9" Then
			gv_UODDL71_EIGCD = " "
		End If
        ' 2007/01/17  ADD END

        '地区の場合
        If (pm_Dsp_Sub_Inf.Detail.Item_Nm = "HD_TIKCD") Then
            '前回値と入力値が異なる場合
            If pv_JYOKEN_INPUT = True Then
                '入力値の退避
                gv_UODDL71_BMNCD = ""
                'UPGRADE_ISSUE: Control HD_TIKCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'change start 20190805 kuwa
                'gv_UODDL71_TIKCD = pm_All.Dsp_Base.FormCtl.HD_TIKCD.Text
                gv_UODDL71_TIKCD = pm_Dsp_Sub_Inf.Ctl.Text
                'change end 20190805 kuwa
                gv_UODDL71_EIGCD = ""

                '部門（クリア）
                'UPGRADE_ISSUE: Control HD_BMNCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'change start 20190805 kuwa
                'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_BMNCD.Tag)
                Trg_Index = CShort(form71.HD_BMNCD.Tag)
                'change end 20190805 kuwa
                Call CF_Set_Item_Direct(Space(1), pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_CLR, pm_All)

                '営業所（クリア）
                'UPGRADE_ISSUE: Control HD_EIGCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'change start 20190805 kuwa
                'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_EIGCD.Tag)
                Trg_Index = CShort(form71.HD_EIGCD.Tag)
                'change end 20190805 kuwa
                Call CF_Set_Item_Direct(Space(1), pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_CLR, pm_All)
            End If
        End If
        ' 2007/01/17  ADD START  KUMEDA
        If Trim(gv_UODDL71_BMNCD) = "9" Then
			gv_UODDL71_BMNCD = " "
		End If
		If Trim(gv_UODDL71_TIKCD) = "99" Then
			gv_UODDL71_TIKCD = "  "
		End If
		If Trim(gv_UODDL71_EIGCD) = "9" Then
			gv_UODDL71_EIGCD = " "
		End If
        ' 2007/01/17  ADD END

        '営業所の場合
        If (pm_Dsp_Sub_Inf.Detail.Item_Nm = "HD_EIGCD") Then
            '前回値と入力値が異なる場合
            If pv_JYOKEN_INPUT = True Then
                '入力値の退避
                gv_UODDL71_BMNCD = ""
                gv_UODDL71_TIKCD = ""
                'UPGRADE_ISSUE: Control HD_EIGCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'change start 20190805 kuwahara
                'gv_UODDL71_EIGCD = pm_All.Dsp_Base.FormCtl.HD_EIGCD.Text
                gv_UODDL71_EIGCD = pm_Dsp_Sub_Inf.Ctl.Text
                'change end 20190805 kuwahara
                ' 2007/01/17  ADD START  KUMEDA
                If Trim(gv_UODDL71_BMNCD) = "9" Then
                    gv_UODDL71_BMNCD = " "
                End If
                If Trim(gv_UODDL71_TIKCD) = "99" Then
                    gv_UODDL71_TIKCD = "  "
                End If
                If Trim(gv_UODDL71_EIGCD) = "9" Then
                    gv_UODDL71_EIGCD = " "
                End If
                ' 2007/01/17  ADD END
                '部門（クリア）
                'UPGRADE_ISSUE: Control HD_BMNCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'change start 20190805 kuwahara
                'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_BMNCD.Tag)
                Trg_Index = CShort(form71.HD_BMNCD.Tag)
                'change end 20190805 kuwahara
                Call CF_Set_Item_Direct(Space(1), pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_CLR, pm_All)

                '地区（クリア）
                'UPGRADE_ISSUE: Control HD_TIKCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'change start 20190805 kuwahara
                'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_TIKCD.Tag)
                Trg_Index = CShort(form71.HD_TIKCD.Tag)
                'change end 20190805 kuwahara
                Call CF_Set_Item_Direct(Space(2), pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_CLR, pm_All)
            End If
        End If

        '部門or地区or営業所の場合
        If (pm_Dsp_Sub_Inf.Detail.Item_Nm = "HD_BMNCD") Or (pm_Dsp_Sub_Inf.Detail.Item_Nm = "HD_TIKCD") Or (pm_Dsp_Sub_Inf.Detail.Item_Nm = "HD_EIGCD") Then
			
			'前回値と入力値が異なる場合
			If pv_JYOKEN_INPUT = True Then
				'ﾍｯﾀﾞ部ﾁｪｯｸ
				Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All)
				If Rtn_Chk = CHK_OK Then
					'チェックOKの場合
					If bolDsp = False Then
						'まだ画面に明細を編集していない場合
						bolDsp = True
						
						If gv_UODDL71_JUC_URI = "1" Then
							'受注
							If pm_All.Dsp_Base.FormCtl.Name = "FR_SSSMAIN1" Then
								'機種別総括表
								RtnCode = F_GET_BD_DATA_KIS_SOUKATU_JUC(gv_UODDL71_GETU_KI, pm_All)
							ElseIf pm_All.Dsp_Base.FormCtl.Name = "FR_SSSMAIN2" Then 
								'機種明細表
								RtnCode = F_GET_BD_DATA_KIS_MEISAI_JUC(gv_UODDL71_GETU_KI, pm_All)
							End If
						Else
							'売上
							If pm_All.Dsp_Base.FormCtl.Name = "FR_SSSMAIN1" Then
								'機種別総括表
								RtnCode = F_GET_BD_DATA_KIS_SOUKATU_URI(gv_UODDL71_GETU_KI, pm_All)
							ElseIf pm_All.Dsp_Base.FormCtl.Name = "FR_SSSMAIN2" Then 
								'機種明細表
								RtnCode = F_GET_BD_DATA_KIS_MEISAI_URI(gv_UODDL71_GETU_KI, pm_All)
							End If
						End If
						
						If RtnCode = 0 Then
							'出力できる明細データが無い
							Exit Function
						Else
							'現在のページ数初期化
							NowPageNum = 1
							
							'最上明細ｲﾝﾃﾞｯｸｽ初期化
							pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
							
							'明細を画面に編集
							Call F_DSP_BD_Inf(pm_Dsp_Sub_Inf, DSP_SET, pm_All)
						End If
					End If
				Else
					'チェックＮＧの場合
					Exit Function
				End If
			End If
		End If
		
		'次の項目を検索
		For Index_Wk = Sta_Index To pm_All.Dsp_Base.Item_Cnt
			
			'ﾌｫｰｶｽ移動がOK
			If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All) = True Then
				If pm_Run_Flg = True Then
					'実行指定がある場合(基本あり)
					'ﾌｫｰｶｽ移動
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
				End If
				'移動フラグ決定
				pm_Move_Flg = True
				Exit For
			End If
			
		Next 
		
		'移動可能項目がない場合
		If Index_Wk = pm_All.Dsp_Base.Item_Cnt + 1 Then
			'ﾌｫｰｶｽ移動
			Call F_Init_Cursor_Set(pm_All)
			
			'移動フラグ決定
			pm_Move_Flg = True
		End If
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Left_Next_Focus
	'   概要：  Left押下時のフォーカス位置設定
	'   引数：　pm_Dsp_Sub_Inf      :画面項目情報
	'           pm_Move_Flg         :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Left_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, Optional ByRef pm_Run_Flg As Boolean = True) As Short
		Dim Index_Wk As Short
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Str_Wk As String
		Dim Wk_Point As Short
		Dim Wk_SelStart As Short
		Dim Wk_SelLength As Short
		
		'移動フラグ初期化
		pm_Move_Flg = False

        '現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの場合
        'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
            'change start 20190805 kuwahara
            'ﾃｷｽﾄﾎﾞｯｸｽの場合()
            '現在のﾃｷｽﾄ上の選択状態を取得()
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            'change end 20190805 kuwahara
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)

            If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                '全選択の場合（選択文字が最大バイト数と一致）
                If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    'change start 20190805 kuwahara
                    '    '詰文字が左詰の場合
                    '    '１文字目を選択する
                    '    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    pm_Dsp_Sub_Inf.Ctl.SelStart = 0
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = 0
                    '    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 1
                    'change end 20190805 kuwahara
                Else
                    '詰文字が左詰以外の場合
                    '１つ前の項目へ
                    Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)

                End If
            Else
                If Act_SelStart = 0 Then
                    '開始位置が一番左の場合
                    '１つ前の項目へ
                    Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                Else

                    '左に１桁ずつずらし入力可能な文字を検索
                    Wk_SelStart = -1
                    For Wk_Point = Act_SelStart - 1 To 0 Step -1
                        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Wk_Point + 1, 1)
                        If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Str_Wk) = 1 Then
                            Wk_SelStart = Wk_Point
                            Exit For
                        End If
                    Next

                    If Wk_SelStart = -1 Then
                        '選択可能な文字がない場合
                        '１つ前の項目へ
                        Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                    Else
                        '選択可能な文字がある場合
                        If Act_SelStart < Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) And Act_SelLength = 0 Then
                            '移動前の選択開始位置が一番右以外でかつ
                            '選択文字数がない場合のみ、
                            '同じ項目で移動する場合に選択文字数は継続する
                            Wk_SelLength = 0
                        Else
                            Wk_SelLength = 1
                        End If
                        'change start 20190805 kuwahara
                        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                        'change end 20190805 kuwahara
                    End If

                End If
            End If
        Else
            '現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの以外場合
            '１つ前の項目へ
            Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
        End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Right_Next_Focus
	'   概要：  Right押下時のフォーカス位置設定
	'   引数：　pm_Dsp_Sub_Inf      :画面項目情報
	'           pm_Move_Flg         :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_all              :全構造体
	'           pm_Run_Flg          :実行指定フラグ（T：あり、F：なし）
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Right_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, ByRef pm_Run_Flg As Boolean) As Short
		Dim Index_Wk As Short
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Str_Wk As String
		Dim Next_SelStart As Short
		Dim Wk_Point As Short
		Dim Wk_SelLength As Short
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		'現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの場合
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
            'delete 20190325 START saiki
            ''現在のﾃｷｽﾄ上の選択状態を取得
            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            'delete 20190325 END saiki
            'add 20190725 START hou
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            'add 20190725 END hou
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)

            If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                'change start 20190805 kuwahara
                '全選択の場合（選択文字が最大バイト数と一致）
                If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '    '詰文字が左詰の場合
                    '    '最終文字を選択する
                    '    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1
                    '    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 1
                Else
                    '    '詰文字が左詰以外の場合
                    '    '１桁目を選択する
                    '    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    pm_Dsp_Sub_Inf.Ctl.SelStart = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = 1
                    '    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 1
                End If
                'change end 20190805 kuwahara
            Else
                    If Act_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) Then
                    '選択開始位置が一番右の場合
                    'ENTキー押下と同様に次の項目へ
                    Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
                Else
                    '選択開始位置が一番右でない場合

                    '１つ右の１桁を取得
                    'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Act_SelStart + 1 + 1, 1)

                    If Str_Wk = "" Then
                        '次の１桁がない場合
                        If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                            'change start 20190805 kuwahara
                            '    '詰文字が左詰の場合
                            '    '一番右へ移動し選択なし状態に
                            '    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '    pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                            '    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '    pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 0
                        Else
                            '    '詰文字が左詰以外の場合
                            If Act_SelLength = 0 Then
                                '        '移動前の選択文字数がない場合
                                '        '一番右へ移動し選択なし状態に
                                '        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                '        pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                                '        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                '        pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 0
                            Else
                                'ENTキー押下と同様に次の項目へ
                                Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
                            End If
                            'change end 20190805 kuwahara
                        End If
                            Else

                        '右に１桁ずつずらし入力可能な文字を検索
                        Next_SelStart = -1
                        For Wk_Point = Act_SelStart + 1 To Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) Step 1

                            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Wk_Point + 1, 1)

                            Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
                                Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM
                                    '日付/年月/時刻項目の場合
                                    '入力可能文字＆と空白も移動可能
                                    If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Str_Wk) = 1 Or Str_Wk = Space(1) Then
                                        Next_SelStart = Wk_Point
                                        Exit For
                                    End If
                                Case Else
                                    '日付/年月/時刻項目以外の場合
                                    If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Str_Wk) = 1 Then
                                        Next_SelStart = Wk_Point
                                        Exit For
                                    End If

                            End Select
                        Next

                        If Next_SelStart = -1 Then
                            '選択可能な文字がない場合
                            'ENTキー押下と同様に次の項目へ
                            Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
                        Else
                            '選択可能な文字がある場合

                            If Act_SelLength = 0 Then
                                '移動前の選択文字数がない場合
                                '同じ項目で移動する場合に選択文字数は継続する
                                Wk_SelLength = 0
                            Else
                                Wk_SelLength = 1
                            End If
                            'change start 20190805 kuwahara
                            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Next_SelStart
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Next_SelStart
                            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                            'change end 20190805 kuwahara
                        End If
                    End If
                End If

            End If
        Else
            '現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの以外場合
            'ENTキー押下と同様に次の項目へ
            Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
        End If
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Down_Next_Focus
	'   概要：  Down押下時のフォーカス位置設定
	'   引数：　pm_Dsp_Sub_Inf      :画面項目情報
	'           pm_Move_Flg         :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Down_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Trg_Index As Short
		Dim Index_Wk As Short
		Dim Next_Index As Short
		Dim Wk_Cnt As Short
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		
		If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CShort(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
			'明細部の場合
			Wk_Cnt = 0
			Do 
				Wk_Cnt = Wk_Cnt + 1
				'現在の項目に列分だけ下に移動したｲﾝﾃﾞｯｸｽを求める
				Next_Index = Trg_Index + (pm_All.Dsp_Base.Body_Col_Cnt * Wk_Cnt)
				
				If Next_Index > pm_All.Dsp_Base.Item_Cnt Then
					'項目数を超えた場合
					'ENTキー押下と同様に次の項目へ
					Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
					Exit Do
				End If
				
				If pm_All.Dsp_Sub_Inf(Next_Index).Detail.In_Area = IN_AREA_DSP_BD And pm_All.Dsp_Sub_Inf(Next_Index).Ctl.Name = pm_Dsp_Sub_Inf.Ctl.Name Then
					'移動先が明細部でかつ移動前と同じｺﾝﾄﾛｰﾙ名の場合
					If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Next_Index), pm_All) = True Then
						'ﾌｫｰｶｽ受取ＯＫ
						'同一列に移動
						Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Next_Index), pm_All)
						pm_Move_Flg = True
						Exit Do
					End If
				Else
					'次の項目名が明細部でない場合
					If CF_Jdg_Row_Down_Focus(Cur_Top_Index, pm_All) = True Then
						'｢下移動した場合、ﾌｫｰｶｽ移動可能な行がある｣場合
						'画面の内容を退避
						Call CF_Body_Bkup(pm_All)
						'移動可能行を一番下に表示した場合の最上明細インデックスを設定
						pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
						If pm_All.Bd_Vs_Scrl Is Nothing = False Then
							'縦スクロールバーを設定
							Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
						End If
						'画面ボディ情報の配列を再設定
						Call CF_Dell_Refresh_Body_Inf(pm_All)
						'画面表示
						Call CF_Body_Dsp(pm_All)
						'明細の一番下の同一項目のｲﾝﾃﾞｯｸｽを取得
						Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
						If Next_Index > 0 Then
							If Next_Index = Trg_Index Then
								'同一ｺﾝﾄﾛｰﾙの場合
								'移動無しで終了
								pm_Move_Flg = False
								Exit Do
							Else
								'同一ｺﾝﾄﾛｰﾙでない場合
								'同一項目の１つ前からENTキー押下と同様に次の項目へ
								Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
								Exit Do
							End If
						Else
							'入力可能な最初のインデックスを取得
							Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
							If Focus_Ctl_Ok_Fst_Idx > 0 Then
								'同一項目の１つ前からENTキー押下と同様に次の項目へ
								Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
								Exit Do
							Else
								'フッタ部の最初の項目の１つ前から
								'ENTキー押下と同様に次の項目へ
								Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
								Exit Do
							End If
						End If
						
					Else
						'｢下移動した場合、ﾌｫｰｶｽ移動可能な行がない｣場合
						'フッタ部の最初の項目の１つ前から
						'ENTキー押下と同様に次の項目へ
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
						Exit Do
					End If
				End If
			Loop 
			
		Else
			'明細部以外の場合
			'ENTキー押下と同様に次の項目へ
			Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Up_Next_Focus
	'   概要：  Up押下時のフォーカス位置設定
	'   引数：　pm_Dsp_Sub_Inf      :画面項目情報
	'           pm_Move_Flg         :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Up_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Trg_Index As Short
		Dim Index_Wk As Short
		Dim Next_Index As Short
		Dim Wk_Cnt As Short
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		
		If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CShort(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
			'明細部の場合
			Wk_Cnt = 0
			Do 
				Wk_Cnt = Wk_Cnt + 1
				'現在の項目に列分だけ上に移動したｲﾝﾃﾞｯｸｽを求める
				Next_Index = Trg_Index - (pm_All.Dsp_Base.Body_Col_Cnt * Wk_Cnt)
				
				If Next_Index < 0 Then
					'マイナスの場合
					'１つ前の項目へ
					Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
					Exit Do
				End If
				
				If pm_All.Dsp_Sub_Inf(Next_Index).Detail.In_Area = IN_AREA_DSP_BD And pm_All.Dsp_Sub_Inf(Next_Index).Ctl.Name = pm_Dsp_Sub_Inf.Ctl.Name Then
					'移動先が明細部でかつ移動前と同じｺﾝﾄﾛｰﾙ名の場合
					If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Next_Index), pm_All) = True Then
						'ﾌｫｰｶｽ受取ＯＫ
						'同一列に移動
						Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Next_Index), pm_All)
						pm_Move_Flg = True
						Exit Do
					End If
				Else
					'次の項目名が明細部でない場合
					If CF_Jdg_Row_Up_Focus(Cur_Top_Index, pm_All) = True Then
						'｢上移動した場合、ﾌｫｰｶｽ移動可能な行がある｣場合
						'画面の内容を退避
						Call CF_Body_Bkup(pm_All)
						'移動可能行を一番上に表示した場合の最上明細インデックスを設定
						pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
						If pm_All.Bd_Vs_Scrl Is Nothing = False Then
							'縦スクロールバーを設定
							Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
						End If
						'画面ボディ情報の配列を再設定
						Call CF_Dell_Refresh_Body_Inf(pm_All)
						'画面表示
						Call CF_Body_Dsp(pm_All)
						'明細の一番上の同一項目のｲﾝﾃﾞｯｸｽを取得
						Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, 1, pm_All)
						If Next_Index > 0 Then
							If Next_Index = Trg_Index Then
								'同一ｺﾝﾄﾛｰﾙの場合
								'移動無しで終了
								pm_Move_Flg = False
								Exit Do
							Else
								'同一ｺﾝﾄﾛｰﾙでない場合
								'同一項目の１つ後ろから
								'１つ前の項目へ
								Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(Next_Index + 1), pm_Move_Flg, pm_All)
								Exit Do
							End If
						Else
							'入力可能な最初のインデックスを取得
							Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
							If Focus_Ctl_Ok_Fst_Idx > 0 Then
								'入力可能な最初の項目の１つ後ろから
								'１つ前の項目へ
								Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx + 1), pm_Move_Flg, pm_All)
								Exit Do
							Else
								'ヘッダ部の最後の項目の１つ後ろから
								'１つ前の項目へ
								Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), pm_Move_Flg, pm_All)
								Exit Do
								
							End If
						End If
					Else
						'ヘッダ部の最後の項目の１つ後ろから
						'１つ前の項目へ
						Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), pm_Move_Flg, pm_All)
						Exit Do
					End If
					
				End If
			Loop 
		Else
			'明細部以外の場合
			'１つ前の項目へ
			Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_Jge_Action
	'   概要：  各チェック関数のチェック前の
	'　　　　　 チェック続行を判定
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_From_Process　　　 :呼出元処理
	'           pm_Err_Rtn　　     　 :エラー戻値
	'           pm_Msg_Flg　　     　 :メッセージフラグ
	'           pm_Move　　　　　　　  :チェック後移動フラグ（T：移動OK、F：移動NG）
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_Jge_Action(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Err_Rtn As Short, ByRef pm_Msg_Flg As Boolean, ByRef pm_Move As Boolean) As Short
		Dim Rtn_Cd As Short
		
		'続行
		Rtn_Cd = CHK_KEEP
		
		Select Case pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process
			Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN, CHK_FROM_KEYLEFT, CHK_FROM_KEYUP, CHK_FROM_BACK_PROCESS
				'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'前回と同じチェック内容の場合
					If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT Then
						'項目のステータスがエラーなし
						'中断
						Rtn_Cd = CHK_STOP
						'メッセージ非表示
						pm_Msg_Flg = False
						'移動可
						pm_Move = True
						'チェックＯＫ
						pm_Err_Rtn = CHK_OK
					End If
				End If
				
			Case CHK_FROM_KEYPRESS
				'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'前回と同じチェック内容の場合
					If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT Then
						'項目のステータスがエラーなし
						'中断
						Rtn_Cd = CHK_STOP
						'メッセージ非表示
						pm_Msg_Flg = False
						'移動可
						pm_Move = True
						'チェックＯＫ
						pm_Err_Rtn = CHK_OK
					End If
					
				End If
				
			Case CHK_FROM_KEYRETURN
				'｢KEYRETURN｣
				'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'前回と同じチェック内容の場合
					If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT Then
						'項目のステータスがエラーなし
						'中断
						Rtn_Cd = CHK_STOP
						'メッセージ非表示
						pm_Msg_Flg = False
						'移動可
						pm_Move = True
						'チェックＯＫ
						pm_Err_Rtn = CHK_OK
					End If
					
				End If
				
			Case CHK_FROM_ALL_CHK
				'一括チェックなど｣
				'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'前回と同じチェック内容の場合
					If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT And pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True Then
						'項目のステータスがエラーなしでかつ未入力以外のチェックを行っている場合
						'中断
						Rtn_Cd = CHK_STOP
						'メッセージ非表示
						pm_Msg_Flg = False
						'移動可
						pm_Move = True
						'チェックＯＫ
						pm_Err_Rtn = CHK_OK
					End If
					
				End If
				
		End Select
		
		If Rtn_Cd = CHK_STOP Then
			'チェックを中断
			'チェック関数呼出元処理をクリア
			pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_ALL_DEFAULT
		End If
		
		F_Chk_Jge_Action = Rtn_Cd
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_Jge_Msg_Move
	'   概要：  各チェック関数のチェック後の
	'　　　　　 メッセージ、ステータス、移動制御
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_From_Process　　　 :呼出元処理
	'           pm_Err_Rtn　　     　 :エラー戻値
	'           pm_Msg_Flg　　     　 :メッセージフラグ
	'           pm_Move　　　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_Jge_Msg_Move(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Err_Rtn As Short, ByRef pm_Msg_Flg As Boolean, ByRef pm_Move As Boolean) As Short
		
		'メッセージ表示なし
		pm_Msg_Flg = False
		'移動可
		pm_Move = True
		
		If pm_Err_Rtn = CHK_OK Then
			'チェックＯＫ
			pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
		Else
			
			Select Case pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process
				Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN, CHK_FROM_KEYLEFT, CHK_FROM_KEYUP, CHK_FROM_BACK_PROCESS
					Select Case pm_Err_Rtn
						Case CHK_ERR_NOT_INPUT
							'必須入力で未入力
							If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
								'１度も未入力以外チェックをしていない場合
								'チェックＯＫとする
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
								pm_Err_Rtn = CHK_OK
								'メッセージ出力なし
								pm_Msg_Flg = False
								'移動ＯＫ
								pm_Move = True
							Else
								'１度でも未入力チェックをしている場合
								'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
									'前回と同じチェック内容の場合
									'チェックエラーとする
									pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
									'メッセージ出力なし
									pm_Msg_Flg = False
									'移動ＯＫ
									pm_Move = True
								Else
									'前回と異なるチェック内容の場合
									'チェックエラーとする
									pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
									'メッセージ出力なし
									pm_Msg_Flg = False
									'移動ＯＫ
									pm_Move = False
								End If
								
							End If
						Case CHK_ERR_ELSE
							'その他エラー時
							'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
								'前回と同じチェック内容の場合
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
								'メッセージ出力なし
								pm_Msg_Flg = False
								'移動ＯＫ
								pm_Move = True
							Else
								'前回と異なるチェック内容の場合
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
								'メッセージ出力あり
								pm_Msg_Flg = True
								'移動ＯＫ
								pm_Move = False
							End If
							
					End Select
					
				Case CHK_FROM_KEYPRESS
					Select Case pm_Err_Rtn
						Case CHK_ERR_NOT_INPUT
							'必須入力で未入力
							If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
								'１度も未入力以外チェックをしていない場合
								'チェックＯＫとする
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
								pm_Err_Rtn = CHK_OK
								'メッセージ出力なし
								pm_Msg_Flg = False
								'移動ＯＫ
								pm_Move = True
							Else
								'１度でも未入力チェックをしている場合
								'チェックエラーとする
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
								'メッセージ出力なし
								pm_Msg_Flg = False
								'移動ＯＫ
								pm_Move = True
							End If
						Case CHK_ERR_ELSE
							'その他エラー時
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
							'メッセージ出力あり
							pm_Msg_Flg = True
							'移動ＮＧ
							pm_Move = False
							
					End Select
					
				Case CHK_FROM_KEYRETURN
					'｢KEYRETURN｣
					Select Case pm_Err_Rtn
						Case CHK_ERR_NOT_INPUT
							'必須入力で未入力
							If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
								'１度も未入力以外チェックをしていない場合
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
								pm_Err_Rtn = CHK_OK
								'メッセージ出力なし
								pm_Msg_Flg = False
								'移動ＯＫ
								pm_Move = True
							Else
								'１度でも未入力チェックをしている場合
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
								'メッセージ出力あり
								pm_Msg_Flg = True
								'移動ＮＧ
								pm_Move = False
							End If
							
						Case CHK_ERR_ELSE
							'その他エラー時
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
							'メッセージ出力あり
							pm_Msg_Flg = True
							'移動ＮＧ
							pm_Move = False
							
					End Select
				Case CHK_FROM_ALL_CHK
					
					Select Case pm_Err_Rtn
						Case CHK_ERR_NOT_INPUT
							'必須入力で未入力
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
							'メッセージ出力あり
							pm_Msg_Flg = True
							'移動ＮＧ
							pm_Move = False
							
						Case CHK_ERR_ELSE
							'その他エラー時
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
							'メッセージ出力あり
							pm_Msg_Flg = True
							'移動ＮＧ
							pm_Move = False
							
					End Select
					
			End Select
			
		End If
		
		'チェック関数呼出元処理をクリア
		pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_ALL_DEFAULT
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_HD_BMNCD
	'   概要：  部門コードのﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :画面項目情報
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All　　　　　      :全構造体
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_BMNCD(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Mst_Inf As TYPE_DB_MEIMTC
		Dim Mst_Inf_Clr As TYPE_DB_MEIMTC
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_HD_BMNCD = Retn_Code
			Exit Function
		End If
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True

        '20190701 CHG START
        'Call DB_MEIMTC_Clear(Mst_Inf)
        Call InitDataCommon("MEIMTC")
        '20190701 CHG END

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			UODDL71_MEIMTC_Inf.DATKB = Mst_Inf_Clr.DATKB
			UODDL71_MEIMTC_Inf.MEICDA = Mst_Inf_Clr.MEICDA 'コード１
			UODDL71_MEIMTC_Inf.MEINMA = Mst_Inf_Clr.MEINMA '名称１
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgUODDL71_E_001
			Else
				'マスタチェック
				If DSPMEIC_SEARCH(pc_Bmncd_Keycode, Input_Value, GV_UNYDate, Mst_Inf) = 0 Then
					'論理削除チェック
					If Mst_Inf.DATKB = gc_strDATKB_DEL Then
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgUODDL71_E_003
					Else
						'ＯＫ
						Retn_Code = CHK_OK
						pm_Chk_Move = True
						UODDL71_MEIMTC_Inf.DATKB = Mst_Inf.DATKB
						UODDL71_MEIMTC_Inf.MEICDA = Mst_Inf.MEICDA 'コード１
						'''' UPD 2010/03/16  FKS) T.Yamamoto    Start    連絡票№CF09122201
						'                    UODDL71_MEIMTC_Inf.MEINMA = Mst_Inf.MEINMA      '名称１
						UODDL71_MEIMTC_Inf.MEINMA = Mst_Inf.MEINMC '名称３
						'''' UPD 2010/03/16  FKS) T.Yamamoto    End
					End If
					'該当データ無し
				Else
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgUODDL71_E_002
				End If
			End If
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		F_Chk_HD_BMNCD = Retn_Code
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_HD_TIKCD
	'   概要：  部門コードのﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :画面項目情報
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All　　　　　      :全構造体
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_TIKCD(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Mst_Inf As TYPE_DB_MEIMTC
		Dim Mst_Inf_Clr As TYPE_DB_MEIMTC
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_HD_TIKCD = Retn_Code
			Exit Function
		End If
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
        pm_Chk_Move = True

        '20190701 CHG START
        'Call DB_MEIMTC_Clear(Mst_Inf)
        Call InitDataCommon("MEIMTC")
        '20190701 CHG END

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			UODDL71_MEIMTC_Inf.DATKB = Mst_Inf_Clr.DATKB
			UODDL71_MEIMTC_Inf.MEICDA = Mst_Inf_Clr.MEICDA 'コード１
			UODDL71_MEIMTC_Inf.MEINMA = Mst_Inf_Clr.MEINMA '名称１
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgUODDL71_E_001
			Else
				'マスタチェック
				If DSPMEIC_SEARCH(pc_Tikcd_Keycode, Input_Value, GV_UNYDate, Mst_Inf) = 0 Then
					'論理削除チェック
					If Mst_Inf.DATKB = gc_strDATKB_DEL Then
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgUODDL71_E_003
					Else
						'ＯＫ
						Retn_Code = CHK_OK
						pm_Chk_Move = True
						UODDL71_MEIMTC_Inf.DATKB = Mst_Inf.DATKB
						UODDL71_MEIMTC_Inf.MEICDA = Mst_Inf.MEICDA 'コード１
						UODDL71_MEIMTC_Inf.MEINMA = Mst_Inf.MEINMA '名称１
					End If
					'該当データ無し
				Else
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgUODDL71_E_002
				End If
			End If
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		F_Chk_HD_TIKCD = Retn_Code
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_HD_EIGCD
	'   概要：  部門コードのﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :画面項目情報
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All　　　　　      :全構造体
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_EIGCD(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Mst_Inf As TYPE_DB_MEIMTC
		Dim Mst_Inf_Clr As TYPE_DB_MEIMTC
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_HD_EIGCD = Retn_Code
			Exit Function
		End If
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True

        '20190701 CHG START
        'Call DB_MEIMTC_Clear(Mst_Inf)
        Call InitDataCommon("MEIMTC")
        '20190701 CHG END

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			UODDL71_MEIMTC_Inf.DATKB = Mst_Inf_Clr.DATKB
			UODDL71_MEIMTC_Inf.MEICDA = Mst_Inf_Clr.MEICDA 'コード１
			UODDL71_MEIMTC_Inf.MEINMA = Mst_Inf_Clr.MEINMA '名称１
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgUODDL71_E_001
			Else
				'マスタチェック
				If DSPMEIC_SEARCH(pc_Eigcd_Keycode, Input_Value, GV_UNYDate, Mst_Inf) = 0 Then
					'論理削除チェック
					If Mst_Inf.DATKB = gc_strDATKB_DEL Then
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgUODDL71_E_003
					Else
						'ＯＫ
						Retn_Code = CHK_OK
						pm_Chk_Move = True
						UODDL71_MEIMTC_Inf.DATKB = Mst_Inf.DATKB
						UODDL71_MEIMTC_Inf.MEICDA = Mst_Inf.MEICDA 'コード１
						UODDL71_MEIMTC_Inf.MEINMA = Mst_Inf.MEINMA '名称１
					End If
					'該当データ無し
				Else
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgUODDL71_E_002
				End If
			End If
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		F_Chk_HD_EIGCD = Retn_Code
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_Item_Detail
	'   概要：  各項目の画面表示
	'   引数：　pm_Dsp_Sub_Inf      :画面情報
	'           pm_Mode             :モード
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_Item_Detail(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		
		If pm_All.Dsp_Base.FormCtl.Name = "FR_SSSMAIN" Then
			Exit Function
		End If
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)

        'UPGRADE_ISSUE: Control HD_EIGCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'UPGRADE_ISSUE: Control HD_TIKCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'UPGRADE_ISSUE: Control HD_BMNCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

        'change 20190403 END saiki
        'Select Case pm_Dsp_Sub_Inf.Ctl.Name
        '    'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        '    Case pm_All.Dsp_Base.FormCtl.HD_BMNCD.NAME
        '        '部門コードによる画面表示
        '        Call F_Dsp_HD_BMNCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

        '    Case pm_All.Dsp_Base.FormCtl.HD_TIKCD.NAME
        '        '地区区分による画面表示
        '        Call F_Dsp_HD_TIKCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

        '    Case pm_All.Dsp_Base.FormCtl.HD_EIGCD.NAME
        '        '営業所コードによる画面表示
        '        Call F_Dsp_HD_EIGCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
        '        'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

        'End Select

        Select Case pm_Dsp_Sub_Inf.Ctl.Name
            Case UODDL71.HD_BMNCD.Name
                '部門コードによる画面表示
                Call F_Dsp_HD_BMNCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

            Case UODDL71.HD_TIKCD.Name
                '地区区分による画面表示
                Call F_Dsp_HD_TIKCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

            Case UODDL71.HD_EIGCD.Name
                '営業所コードによる画面表示
                Call F_Dsp_HD_EIGCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

        End Select
        'change 20190403 END saiki

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_DSP_BD_Inf
    '   概要：  ボディ部の画面表示
    '   引数：　pm_Dsp_Sub_Inf      :画面情報
    '           pm_Mode             :モード
    '           pm_all              :全構造体
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_DSP_BD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim intCnt As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'データ編集
			Call F_SET_BD_DATA(pm_All)
			
			'        'フォーカス位置設定
			'        Call F_Init_Cursor_Set(pm_All)
		End If
		
		'復元内容、前回内容を退避
		Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_HD_BMNCD_Inf
	'   概要：  部門コードによる画面表示
	'   引数：  pm_Dsp_Sub_Inf      :画面情報
	'           pm_Mode             :モード
	'           pm_all              :全構造体
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_BMNCD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		
		If pm_Mode = DSP_SET Then
			'表示
			pv_JYOKEN_INPUT = False
			
			'部門コードが変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

                'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
                '【部門名】
                'UPGRADE_ISSUE: Control HD_BMNNM は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'change 20190405 START saiki
                'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_BMNNM.Tag)

                Trg_Index = CShort(UODDL71.HD_BMNNM.Tag)
                'change 20190405 END saiki

                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(UODDL71_MEIMTC_Inf.MEINMA, pm_All.Dsp_Sub_Inf(Trg_Index), False)

                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				pv_JYOKEN_INPUT = True
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
            'クリア
            'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
            '【部門名】
            'UPGRADE_ISSUE: Control HD_BMNNM は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            'change 20190405 START saiki
            'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_BMNNM.Tag)
            Trg_Index = CShort(UODDL71.HD_BMNNM.Tag)
            'change 20190405 END saiki
            Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_HD_TIKCD_Inf
	'   概要：  地区区分による画面表示
	'   引数：  pm_Dsp_Sub_Inf      :画面情報
	'           pm_Mode             :モード
	'           pm_all              :全構造体
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_TIKCD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		
		If pm_Mode = DSP_SET Then
			'表示
			pv_JYOKEN_INPUT = False
			
			'地区区分が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

                'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
                '【地区名】
                'UPGRADE_ISSUE: Control HD_TIKNM は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'change 20190408 START saiki
                'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_TIKNM.Tag)
                Trg_Index = CShort(UODDL71.HD_TIKNM.Tag)
                'change 20190408 END saiki
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(UODDL71_MEIMTC_Inf.MEINMA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				pv_JYOKEN_INPUT = True
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
            'クリア
            'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
            '【地区名】
            'UPGRADE_ISSUE: Control HD_TIKNM は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            'change 20190408 START saiki
            'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_TIKNM.Tag)
            Trg_Index = CShort(UODDL71.HD_TIKNM.Tag)
            'change 20190408 END saiki
            Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_HD_EIGCD_Inf
	'   概要：  営業所コードによる画面表示
	'   引数：  pm_Dsp_Sub_Inf      :画面情報
	'           pm_Mode             :モード
	'           pm_all              :全構造体
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_EIGCD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		
		If pm_Mode = DSP_SET Then
			'表示
			pv_JYOKEN_INPUT = False
			
			'営業所コードが変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

                'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
                '【営業所名】
                'UPGRADE_ISSUE: Control HD_EIGNM は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'change 20190325 START saiki
                'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_EIGNM.Tag)
                Trg_Index = CShort(UODDL71.HD_EIGNM.Tag)
                'change 20190325 END saiki
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(UODDL71_MEIMTC_Inf.MEINMA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				pv_JYOKEN_INPUT = True
                'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

                '復元内容、前回内容を退避
                Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
            End If
		Else
            'クリア
            'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
            '【営業所名】
            'UPGRADE_ISSUE: Control HD_EIGNM は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            'change 20190325 START saiki
            'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_EIGNM.Tag)
            Trg_Index = CShort(UODDL71.HD_EIGNM.Tag)
            'change 20190325 END saiki
            Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Item_Chk
	'   概要：  各項目のﾁｪｯｸﾙｰﾁﾝ制御
	'   引数：　pm_Dsp_Sub_Inf      :画面情報
	'           pm_Process          :チェック関数呼出元
	'           pm_Chk_Move_Flg     :各項目のチェックフラグ
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Item_Chk(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Process As String, ByRef pm_Chk_Move_Flg As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Rtn_Chk As Short
		
		'各ﾁｪｯｸ関数と同じ戻値
		Rtn_Chk = CHK_OK
		pm_Chk_Move_Flg = True
		
		If pm_All.Dsp_Base.FormCtl.Name = "FR_SSSMAIN" Then
			F_Ctl_Item_Chk = Rtn_Chk
			Exit Function
		End If

        '①基本入力内容のチェック
        'UPGRADE_ISSUE: Control HD_EIGCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'UPGRADE_ISSUE: Control HD_TIKCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'UPGRADE_ISSUE: Control HD_BMNCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'change 20190325 START saiki
        'Select Case pm_Dsp_Sub_Inf.Ctl.Name
        '    'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ

        '    Case pm_All.Dsp_Base.FormCtl.HD_BMNCD.NAME
        '        'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
        '        Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
        '        '部門コードのﾁｪｯｸ
        '        Rtn_Chk = F_Chk_HD_BMNCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

        '    Case pm_All.Dsp_Base.FormCtl.HD_TIKCD.NAME
        '        Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
        '        '地区区分のﾁｪｯｸ
        '        Rtn_Chk = F_Chk_HD_TIKCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

        '    Case pm_All.Dsp_Base.FormCtl.HD_EIGCD.NAME
        '        Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
        '        '営業所コードのﾁｪｯｸ
        '        Rtn_Chk = F_Chk_HD_EIGCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

        'End Select

        Select Case pm_Dsp_Sub_Inf.Ctl.Name
            'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ

            Case "HD_BMNCD"
                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '部門コードのﾁｪｯｸ
                Rtn_Chk = F_Chk_HD_BMNCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

            Case "HD_TIKCD"
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '地区区分のﾁｪｯｸ
                Rtn_Chk = F_Chk_HD_TIKCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

            Case "HD_EIGCD"
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '営業所コードのﾁｪｯｸ
                Rtn_Chk = F_Chk_HD_EIGCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

        End Select
        'change 20190325 END saiki
        'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

        F_Ctl_Item_Chk = Rtn_Chk

    End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Head_Chk
	'   概要：  ﾍｯﾀﾞ部のﾁｪｯｸﾙｰﾁﾝ制御
	'   引数：　pm_all      :全構造体
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Head_Chk(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		'======================= 変更部分 2006.06.12 Start =================================
		Dim Dsp_Mode As Short
		'======================= 変更部分 2006.06.12 End =================================
		
		'各ﾁｪｯｸ関数と同じ戻値
		Rtn_Chk = CHK_OK
		
		'ヘッダ部の最終項目まで各項目のﾁｪｯｸを行う
		For Index_Wk = 1 To pm_All.Dsp_Base.Head_Lst_Idx
			
			'各項目ﾁｪｯｸを全体ﾁｪｯｸとして呼出
			Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Index_Wk), CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All)
			
			'======================= 変更部分 2006.06.12 Start =================================
			If Rtn_Chk = CHK_OK Then
				'チェックＯＫ時
				'取得内容表示
				Dsp_Mode = DSP_SET
			Else
				'チェックＮＧ時
				'取得内容クリア
				Dsp_Mode = DSP_CLR
			End If
			
			'取得内容表示/クリア
			Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Index_Wk), Dsp_Mode, pm_All)
			'======================= 変更部分 2006.06.12 End =================================
			
			'チェックＮＧ
			If Rtn_Chk <> CHK_OK Then
				
				'ﾁｪｯｸ後移動なし
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
				
				F_Ctl_Head_Chk = Rtn_Chk
				Exit Function
			End If
		Next 
		
		'関連ﾁｪｯｸ
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		If Rtn_Chk = CHK_OK And pm_All.Dsp_Base.Head_Ok_Flg = False Then
			'チェックＯＫでかつ
			'ヘッダ部のチェックが初めての場合
			'１行目のボディ部を準備最終行として開放する
			pm_All.Dsp_Body_Inf.Row_Inf(1).Status = BODY_ROW_STATE_LST_ROW
			'フッタ部を開放する
			Call F_Foot_In_Ready(pm_All)
			'チェックＯＫ
			pm_All.Dsp_Base.Head_Ok_Flg = True
		End If
		
		F_Ctl_Head_Chk = Rtn_Chk
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_CS_JUC_URI_BMN
	'   概要：  受注／売上画面呼出（部門別総括表）
	'   引数：  pm_Dsp_Sub_Inf      :画面情報
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_JUC_URI_BMN(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim RtnCode As Short
		Dim Wk_GetuKi As String
		' 2007/01/16  ADD START  KUMEDA
		Dim Wk_NENGETU As String
		' 2007/01/16  ADD END
		
		'明細ページ数設定
		MinPageNum = 1
		MaxPageNum = 1
		NowPageNum = 0
		
		' 2007/01/16  ADD START  KUMEDA
		Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
		' 2007/01/16  ADD END
		
		If gv_UODDL71_GETU_KI = "1" Then
			'当月
			' 2007/01/16  CHG START  KUMEDA
			'        Wk_GetuKi = "当月"
			Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2)
			' 2007/01/16  CHG END
		Else
			'当期
			' 2007/01/16  CHG START  KUMEDA
			'        Wk_GetuKi = "当期"
			Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2) & "　～　"
			Wk_GetuKi = Wk_GetuKi & Left(GV_UNYDate, 4) & "/" & Mid(GV_UNYDate, 5, 2)
			' 2007/01/16  CHG END
		End If

        'change 20190329 START saiki
        'UPGRADE_ISSUE: Control CS_JUC_URI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'Select Case pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Caption
        '	Case "受　注"
        '		gv_UODDL71_JUC_URI = "1"

        '		'キャプション変更
        '		' 2007/01/16  CHG START  KUMEDA
        '		'            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "　受注"
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(11).Caption = "受　　注"
        '		' 2007/01/16  CHG END
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(4).Caption = "受注数"
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(5).Caption = "受注金額"
        '		'UPGRADE_ISSUE: Control CS_JUC_URI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Caption = "売　上"
        '		'ADD START FKS)INABA 2010/10/05 ****************************************
        '		'連絡票№CF10100501
        '		'UPGRADE_ISSUE: Control lab_uri は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.lab_uri.Visible = False
        '		'ADD  END  FKS)INABA 2010/10/05 ****************************************
        '		'データ取得
        '		RtnCode = F_GET_BD_DATA_BMN_SOUKATU_JUC(gv_UODDL71_GETU_KI, pm_All)

        '	Case "売　上"
        '		gv_UODDL71_JUC_URI = "2"

        '		'キャプション変更
        '		' 2007/01/16  CHG START  KUMEDA
        '		'            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "　売上"
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(11).Caption = "売　　上"
        '		' 2007/01/16  CHG END
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(4).Caption = "売上数"
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(5).Caption = "売上金額"
        '		'UPGRADE_ISSUE: Control CS_JUC_URI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Caption = "受　注"

        '		'ADD START FKS)INABA 2010/10/05 ****************************************
        '		'連絡票№CF10100501
        '		'UPGRADE_ISSUE: Control lab_uri は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.lab_uri.Visible = True
        '		'ADD  END  FKS)INABA 2010/10/05 ****************************************
        '		'データ取得
        '		RtnCode = F_GET_BD_DATA_BMN_SOUKATU_URI(gv_UODDL71_GETU_KI, pm_All)

        '      End Select

        'UPGRADE_ISSUE: Control CS_JUC_URI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'change start 20190805 kuwahara
        'Select Case UODDL71_fpr.btnF6.Text
        '    Case "(F6)" & vbCrLf & "受　注"
        Select Case Judge1
            Case 0
                'change end 20190805 kuwhara
                gv_UODDL71_JUC_URI = "1"

                'キャプション変更
                ' 2007/01/16  CHG START  KUMEDA
                '            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "　受注"
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL71_fpr._FM_Panel3D1_3.Text = Wk_GetuKi
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL71_fpr._FM_Panel3D1_11.Text = "受　　注"
                ' 2007/01/16  CHG END
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL71_fpr._FM_Panel3D1_4.Text = "受注数"
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL71_fpr._FM_Panel3D1_5.Text = "受注金額"
                'UPGRADE_ISSUE: Control CS_JUC_URI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                'change start 20190805 kuwahara
                'UODDL71_fpr.btnF6.Text = "(F6)" & vbCrLf & "売　上"
                'Judge1 = 1
                'change end 20190805 kuwahara

                'ADD START FKS)INABA 2010/10/05 ****************************************
                '連絡票№CF10100501
                'UPGRADE_ISSUE: Control lab_uri は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL71_fpr.lab_uri.Visible = False
                'ADD  END  FKS)INABA 2010/10/05 ****************************************
                'データ取得
                RtnCode = F_GET_BD_DATA_BMN_SOUKATU_JUC(gv_UODDL71_GETU_KI, pm_All)

                'change start 20190805 kuwahara
                'Case "(F6)" & vbCrLf & "売　上"
            Case 1
                'change end 20190805 kuwahara
                gv_UODDL71_JUC_URI = "2"

                'キャプション変更
                ' 2007/01/16  CHG START  KUMEDA
                '            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "　売上"
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL71_fpr._FM_Panel3D1_3.Text = Wk_GetuKi
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL71_fpr._FM_Panel3D1_11.Text = "売　　上"
                ' 2007/01/16  CHG END
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL71_fpr._FM_Panel3D1_4.Text = "売上数"
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL71_fpr._FM_Panel3D1_5.Text = "売上金額"
                'UPGRADE_ISSUE: Control CS_JUC_URI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                'change start 20190805 kuwahara
                'UODDL71_fpr.btnF6.Text = "(F6)" & vbCrLf & "受　注"
                'Judge1 = 0
                'change end 20190805 kuwahara

                'ADD START FKS)INABA 2010/10/05 ****************************************
                '連絡票№CF10100501
                'UPGRADE_ISSUE: Control lab_uri は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL71_fpr.lab_uri.Visible = True
                'ADD  END  FKS)INABA 2010/10/05 ****************************************
                'データ取得
                RtnCode = F_GET_BD_DATA_BMN_SOUKATU_URI(gv_UODDL71_GETU_KI, pm_All)

        End Select
        'change 20190329 END saiki

        If RtnCode = 0 Then
			'出力できる明細データが無い
			Exit Function
		Else
			'現在のページ数初期化
			NowPageNum = 1
			
			'最上明細ｲﾝﾃﾞｯｸｽ初期化
			pm_All.Dsp_Body_Inf.Cur_Top_Index = 1

            '明細を画面に編集
            'UPGRADE_ISSUE: Control CS_JUC_URI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            'change 20190325 START saiki
            'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Tag)
            Trg_Index = CShort(UODDL71_fpr.btnF1.Tag)
            'change 20190329 END saiki
            Call F_DSP_BD_Inf(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_SET, pm_All)
		End If
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_CS_GETU_KI_BMN
	'   概要：  当月／当期画面呼出（部門別総括表）
	'   引数：  pm_Dsp_Sub_Inf      :画面情報
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_GETU_KI_BMN(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim RtnCode As Short
		Dim Wk_GetuKi As String
		' 2007/01/16  ADD START  KUMEDA
		Dim Wk_NENGETU As String
		' 2007/01/16  ADD END
		
		'明細ページ数設定
		MinPageNum = 1
		MaxPageNum = 1
		NowPageNum = 0

        'UPGRADE_ISSUE: Control CS_GETU_KI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '      'change 20190329 START saiki
        'Select Case pm_All.Dsp_Base.FormCtl.CS_GETU_KI.Caption
        '    Case "当　月"
        '        gv_UODDL71_GETU_KI = "1"
        '        ' 2007/01/16  CHG START  KUMEDA
        '        '            Wk_GetuKi = "当月"
        '        Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
        '        Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2)
        '        ' 2007/01/16  CHG END

        '        'キャプション変更
        '        'UPGRADE_ISSUE: Control CS_GETU_KI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '        pm_All.Dsp_Base.FormCtl.CS_GETU_KI.Caption = "累　計"

        '    Case "累　計"
        '        gv_UODDL71_GETU_KI = "2"
        '        ' 2007/01/16  CHG START  KUMEDA
        '        '            Wk_GetuKi = "当期"
        '        Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
        '        Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2) & "　～　"
        '        Wk_GetuKi = Wk_GetuKi & Left(GV_UNYDate, 4) & "/" & Mid(GV_UNYDate, 5, 2)
        '        ' 2007/01/16  CHG END

        '        'キャプション変更
        '        'UPGRADE_ISSUE: Control CS_GETU_KI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '        pm_All.Dsp_Base.FormCtl.CS_GETU_KI.Caption = "当　月"

        'End Select

        'Select Case gv_UODDL71_JUC_URI
        '    Case "1"
        '        '受注
        '        'キャプション変更
        '        ' 2007/01/16  CHG START  KUMEDA
        '        '            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "　受注"
        '        'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '        pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi
        '        'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '        pm_All.Dsp_Base.FormCtl.FM_Panel3D1(11).Caption = "受　　注"
        '        ' 2007/01/16  CHG END
        '        'ADD START FKS)INABA 2010/10/05 ****************************************
        '        '連絡票№CF10100501
        '        'UPGRADE_ISSUE: Control lab_uri は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '        pm_All.Dsp_Base.FormCtl.lab_uri.Visible = False
        '        'ADD  END  FKS)INABA 2010/10/05 ****************************************

        '        'データ取得
        '        RtnCode = F_GET_BD_DATA_BMN_SOUKATU_JUC(gv_UODDL71_GETU_KI, pm_All)
        '    Case "2"
        '        '売上
        '        'キャプション変更
        '        ' 2007/01/16  CHG START  KUMEDA
        '        '            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "　売上"
        '        'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '        pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi
        '        'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '        pm_All.Dsp_Base.FormCtl.FM_Panel3D1(11).Caption = "売　　上"
        '        ' 2007/01/16  CHG END
        '        'ADD START FKS)INABA 2010/10/05 ****************************************
        '        '連絡票№CF10100501
        '        'UPGRADE_ISSUE: Control lab_uri は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '        pm_All.Dsp_Base.FormCtl.lab_uri.Visible = True
        '        'ADD  END  FKS)INABA 2010/10/05 ****************************************

        '        'データ取得
        '        RtnCode = F_GET_BD_DATA_BMN_SOUKATU_URI(gv_UODDL71_GETU_KI, pm_All)
        'End Select

        'change start 20190805 kuwahara
        'Select Case UODDL71_fpr.btnF7.Text
        'Case "(F7)" & vbCrLf & "当　月"
        Select Case Judge2
            Case 0
                'change end 20190805 kuwahara
                gv_UODDL71_GETU_KI = "1"
                ' 2007/01/16  CHG START  KUMEDA
                '            Wk_GetuKi = "当月"
                Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
                Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2)
                ' 2007/01/16  CHG END

                'キャプション変更
                'UPGRADE_ISSUE: Control CS_GETU_KI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'change stat 20190805 kuwahara
                'UODDL71_fpr.btnF7.Text = "(F7)" & vbCrLf & "累　計"
                'Judge2 = 1
                'change end 20190805 kuwahara

                'change start 20190805 kuwahara
                'Case "(F7)" & vbCrLf & "累　計"
            Case 1
                'change end 20190805 kuwahara
                gv_UODDL71_GETU_KI = "2"
                ' 2007/01/16  CHG START  KUMEDA
                '            Wk_GetuKi = "当期"
                Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
                Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2) & "　～　"
                Wk_GetuKi = Wk_GetuKi & Left(GV_UNYDate, 4) & "/" & Mid(GV_UNYDate, 5, 2)
                ' 2007/01/16  CHG END

                'キャプション変更
                'UPGRADE_ISSUE: Control CS_GETU_KI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'change start 20190805 kuwahara
                'UODDL71_fpr.btnF7.Text = "(F7)" & vbCrLf & "当　月"
                'Judge2 = 0
                'change end 20190805 kuwahara
        End Select

        Select Case gv_UODDL71_JUC_URI
            Case "1"
                '受注
                'キャプション変更
                ' 2007/01/16  CHG START  KUMEDA
                '            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "　受注"
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

                'change 20190329 START saiki
                'UODDL71_fpr.FM_Panel3D1(3).Text = Wk_GetuKi
                ''UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'UODDL71_fpr.FM_Panel3D1(11).Text = "受　　注"

                UODDL71_fpr._FM_Panel3D1_3.Text = Wk_GetuKi
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL71_fpr._FM_Panel3D1_11.Text = "受　　注"
                'change 20190329 END saiki

                ' 2007/01/16  CHG END
                'ADD START FKS)INABA 2010/10/05 ****************************************
                '連絡票№CF10100501
                'UPGRADE_ISSUE: Control lab_uri は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL71_fpr.lab_uri.Visible = False
                'ADD  END  FKS)INABA 2010/10/05 ****************************************

                'データ取得
                RtnCode = F_GET_BD_DATA_BMN_SOUKATU_JUC(gv_UODDL71_GETU_KI, pm_All)
            Case "2"
                '売上
                'キャプション変更

                'change 20190329 START saiki
                '' 2007/01/16  CHG START  KUMEDA
                ''            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "　売上"
                ''UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'UODDL71_fpr.FM_Panel3D1(3).Text = Wk_GetuKi
                ''UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'UODDL71_fpr.FM_Panel3D1(11).Text = "売　　上"
                '' 2007/01/16  CHG END


                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL71_fpr._FM_Panel3D1_3.Text = Wk_GetuKi
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL71_fpr._FM_Panel3D1_11.Text = "売　　上"
                'change 20190401 END saiki

                'ADD START FKS)INABA 2010/10/05 ****************************************
                '連絡票№CF10100501
                'UPGRADE_ISSUE: Control lab_uri は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL71_fpr.lab_uri.Visible = True
                'ADD  END  FKS)INABA 2010/10/05 ****************************************

                'データ取得
                RtnCode = F_GET_BD_DATA_BMN_SOUKATU_URI(gv_UODDL71_GETU_KI, pm_All)
        End Select
        'change 20190329 END saiki

        If RtnCode = 0 Then
            '出力できる明細データが無い
            Exit Function
        Else
            '現在のページ数初期化
            NowPageNum = 1
			
			'最上明細ｲﾝﾃﾞｯｸｽ初期化
			pm_All.Dsp_Body_Inf.Cur_Top_Index = 1

            '明細を画面に編集
            'UPGRADE_ISSUE: Control CS_GETU_KI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            'change 20190329 START saiki
            'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CS_GETU_KI.Tag)
            Trg_Index = CShort(UODDL71_fpr.btnF11.Tag)
            'change 20190329 END saiki
            Call F_DSP_BD_Inf(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_SET, pm_All)
		End If
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_CS_SOUKATU_BMN
	'   概要：  機種別総括表画面呼出（部門別総括表）
	'   引数：  pm_Dsp_Sub_Inf      :画面情報
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_SOUKATU_BMN(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Row_Cnt As Short
		Dim Row_Index As Short
		Dim Div_Kind As String
		Dim Div_Code As String
		
		Div_Kind = ""
		Div_Code = ""

        'delete 20190325 START saiki
        For Row_Cnt = 1 To pm_All.Dsp_Base.Dsp_Body_Cnt
            'オプションボタンが選択されている場合
            'UPGRADE_ISSUE: Control BD_SELECTB は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。

            'change 20190402 START saiki
            'If pm_All.Dsp_Base.FormCtl.BD_SELECTB(Row_Cnt).Value = True Then
            If UODDL71_fpr.BD_SELECTB(Row_Cnt).Checked = True Then
                'change 20190402 END saiki
                'Dsp_Body_Inf.Row_Infの行ＮＯへ変換
                Row_Index = pm_All.Dsp_Body_Inf.Cur_Top_Index + Row_Cnt - 1

                '選択データのコードを取得
                With pm_All.Dsp_Body_Inf.Row_Inf(Row_Index).Bus_Inf
                    Div_Kind = .DIVISION
                    Div_Code = .DIVCODE
                End With

                Exit For
            End If

        Next


        If Div_Code = "" Then
            '選択されていない場合
            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgUODDL71_E_008, pm_All)

            '初期ﾌｫｰｶｽ位置設定
            Call F_Init_Cursor_Set(pm_All)

            Exit Function
        Else
            '選択されている場合
            Select Case Div_Kind
				Case "1"
					gv_UODDL71_BMNCD = Div_Code
					gv_UODDL71_TIKCD = ""
					gv_UODDL71_EIGCD = ""
				Case "2"
					gv_UODDL71_BMNCD = ""
					gv_UODDL71_TIKCD = Div_Code
					gv_UODDL71_EIGCD = ""
				Case "3"
					gv_UODDL71_BMNCD = ""
					gv_UODDL71_TIKCD = ""
					gv_UODDL71_EIGCD = Div_Code
				Case "99"
					' 2007/01/17  CHG START  KUMEDA
					'                gv_UODDL71_BMNCD = ""
					gv_UODDL71_BMNCD = "9"
					' 2007/01/17  CHG END
					gv_UODDL71_TIKCD = ""
					gv_UODDL71_EIGCD = ""
			End Select
		End If
		
		'当画面（部門別総括表）を非表示
		FR_SSSMAIN.Hide()
		
		'機種別総括表を表示
		gv_bolUODDL71_Active = True
        'UPGRADE_ISSUE: Load ステートメント はサポートされていません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' をクリックしてください。
        'change 20190325 START saiki
        'Load(FR_SSSMAIN1)
        'FR_SSSMAIN1.Show()


        'UODDL71.ShowDialog()
        UODDL71.Show()
        'Change 20190325 END saiki


    End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_CS_SAIYOMI_BMN
	'   概要：  再読込（部門別総括表）
	'   引数：  pm_Dsp_Sub_Inf      :画面情報
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_SAIYOMI_BMN(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim RtnCode As Short
		Dim Wk_GetuKi As String
		
		'明細ページ数設定
		MinPageNum = 1
		MaxPageNum = 1
		NowPageNum = 0
		
		Select Case gv_UODDL71_JUC_URI
			Case "1"
				'受注
				'データ取得
				RtnCode = F_GET_BD_DATA_BMN_SOUKATU_JUC(gv_UODDL71_GETU_KI, pm_All)
			Case "2"
				'売上
				'データ取得
				RtnCode = F_GET_BD_DATA_BMN_SOUKATU_URI(gv_UODDL71_GETU_KI, pm_All)
		End Select
		
		If RtnCode = 0 Then
			'出力できる明細データが無い
			Exit Function
		Else
			'現在のページ数初期化
			NowPageNum = 1
			
			'最上明細ｲﾝﾃﾞｯｸｽ初期化
			pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
			
			'明細を画面に編集
			'UPGRADE_ISSUE: Control CS_GETU_KI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            'delete 20190325 START saiki
            'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CS_GETU_KI.Tag)
            'delete 20190325 END saiki
			Call F_DSP_BD_Inf(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_SET, pm_All)
		End If
	End Function
	
	' 2007/01/12  ADD START  KUMEDA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_CS_SAIYOMI_KSY
	'   概要：  再読込（機種別総括表）
	'   引数：  pm_Dsp_Sub_Inf      :画面情報
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_SAIYOMI_KSY(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim RtnCode As Short
		Dim Wk_GetuKi As String
		' 2007/01/16  ADD START  KUMEDA
		Dim Wk_NENGETU As String
		' 2007/01/16  ADD END
		
		'明細ページ数設定
		MinPageNum = 1
		MaxPageNum = 1
		NowPageNum = 0
		' 2007/01/16  ADD START  KUMEDA
		Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
		' 2007/01/16  ADD END
		
		If gv_UODDL71_GETU_KI = "1" Then
			'当月
			' 2007/01/16  CHG START  KUMEDA
			'        Wk_GetuKi = "当月"
			Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2)
			' 2007/01/16  CHG END
		Else
			'当期
			' 2007/01/16  CHG START  KUMEDA
			'        Wk_GetuKi = "当期"
			Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2) & "　～　"
			Wk_GetuKi = Wk_GetuKi & Left(GV_UNYDate, 4) & "/" & Mid(GV_UNYDate, 5, 2)
			' 2007/01/16  CHG END
		End If
        'delete 20190325 START saiki
        ''UPGRADE_ISSUE: Control HD_BMNCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'gv_UODDL71_BMNCD = Trim(pm_All.Dsp_Base.FormCtl.HD_BMNCD.Text)
        ''UPGRADE_ISSUE: Control HD_TIKCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'gv_UODDL71_TIKCD = Trim(pm_All.Dsp_Base.FormCtl.HD_TIKCD.Text)
        ''UPGRADE_ISSUE: Control HD_EIGCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '      gv_UODDL71_EIGCD = Trim(pm_All.Dsp_Base.FormCtl.HD_EIGCD.Text)
        'delete 20190325 END saiki
		' 2007/01/17  ADD START  KUMEDA
		If Trim(gv_UODDL71_BMNCD) = "9" Then
			gv_UODDL71_BMNCD = " "
		End If
		If Trim(gv_UODDL71_TIKCD) = "99" Then
			gv_UODDL71_TIKCD = "  "
		End If
		If Trim(gv_UODDL71_EIGCD) = "9" Then
			gv_UODDL71_EIGCD = " "
		End If
        ' 2007/01/17  ADD END
        'delete 20190325 START saiki
        'UPGRADE_ISSUE: Control CS_JUC_URI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'Select Case pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Caption
        '	Case "売　上"

        '		'受注データ取得
        '		RtnCode = F_GET_BD_DATA_KIS_SOUKATU_JUC(gv_UODDL71_GETU_KI, pm_All)

        '	Case "受　注"

        '		'売上データ取得
        '		RtnCode = F_GET_BD_DATA_KIS_SOUKATU_URI(gv_UODDL71_GETU_KI, pm_All)

        'End Select
        'delete 20190325 END saiki

        'add 20190719 START hou
        Select Case gv_UODDL71_JUC_URI
            Case "1"
                '受注データ取得
                RtnCode = F_GET_BD_DATA_KIS_SOUKATU_JUC(gv_UODDL71_GETU_KI, pm_All)
            Case "2"

                '売上データ取得
                RtnCode = F_GET_BD_DATA_KIS_SOUKATU_URI(gv_UODDL71_GETU_KI, pm_All)
        End Select
        'add 20190719 END hou

        If RtnCode = 0 Then
			'出力できる明細データが無い
			Exit Function
		Else
			'現在のページ数初期化
			NowPageNum = 1
			
			'最上明細ｲﾝﾃﾞｯｸｽ初期化
			pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
			
			'明細を画面に編集
			'UPGRADE_ISSUE: Control CS_JUC_URI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            'delete 20190325 START saiki
            'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Tag)
            'delete 20190325 END saiki
			Call F_DSP_BD_Inf(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_SET, pm_All)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_CS_SAIYOMI_MEI
	'   概要：  再読込（機種別総括表）
	'   引数：  pm_Dsp_Sub_Inf      :画面情報
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_SAIYOMI_MEI(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim RtnCode As Short
		Dim Wk_GetuKi As String
		' 2007/01/16  ADD START  KUMEDA
		Dim Wk_NENGETU As String
		' 2007/01/16  ADD END
		
		'明細ページ数設定
		MinPageNum = 1
		MaxPageNum = 1
		NowPageNum = 0
		' 2007/01/16  ADD START  KUMEDA
		Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
		' 2007/01/16  ADD END
		
		If gv_UODDL71_GETU_KI = "1" Then
			'当月
			' 2007/01/16  CHG START  KUMEDA
			'        Wk_GetuKi = "当月"
			Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2)
			' 2007/01/16  CHG END
		Else
			'当期
			' 2007/01/16  CHG START  KUMEDA
			'        Wk_GetuKi = "当期"
			Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2) & "　～　"
			Wk_GetuKi = Wk_GetuKi & Left(GV_UNYDate, 4) & "/" & Mid(GV_UNYDate, 5, 2)
			' 2007/01/16  CHG END
		End If
        'delete 20190325 START saiki
        ''UPGRADE_ISSUE: Control HD_BMNCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'gv_UODDL71_BMNCD = Trim(pm_All.Dsp_Base.FormCtl.HD_BMNCD.Text)
        ''UPGRADE_ISSUE: Control HD_TIKCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'gv_UODDL71_TIKCD = Trim(pm_All.Dsp_Base.FormCtl.HD_TIKCD.Text)
        ''UPGRADE_ISSUE: Control HD_EIGCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '      gv_UODDL71_EIGCD = Trim(pm_All.Dsp_Base.FormCtl.HD_EIGCD.Text)
        'delete 20190325 END saiki
		' 2007/01/17  ADD START  KUMEDA
		If Trim(gv_UODDL71_BMNCD) = "9" Then
			gv_UODDL71_BMNCD = " "
		End If
		If Trim(gv_UODDL71_TIKCD) = "99" Then
			gv_UODDL71_TIKCD = "  "
		End If
		If Trim(gv_UODDL71_EIGCD) = "9" Then
			gv_UODDL71_EIGCD = " "
		End If
        ' 2007/01/17  ADD END
        'delete 20190325 START saiki
        'UPGRADE_ISSUE: Control CS_JUC_URI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'Select Case pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Caption
        '	Case "売　上"

        '		'受注データ取得
        '		RtnCode = F_GET_BD_DATA_KIS_MEISAI_JUC(gv_UODDL71_GETU_KI, pm_All)

        '	Case "受　注"

        '		'売上データ取得
        '		RtnCode = F_GET_BD_DATA_KIS_MEISAI_URI(gv_UODDL71_GETU_KI, pm_All)

        'End Select
        'delete 20190325 END saiki
        'add start 20190806 kuwahara
        Select Case Judge1
            Case 0

                '受注データ取得
                RtnCode = F_GET_BD_DATA_KIS_MEISAI_JUC(gv_UODDL71_GETU_KI, pm_All)

            Case 1

                '売上データ取得
                RtnCode = F_GET_BD_DATA_KIS_MEISAI_URI(gv_UODDL71_GETU_KI, pm_All)

        End Select
        'add end 20190806 kuwahara
        If RtnCode = 0 Then
			'出力できる明細データが無い
			Exit Function
		Else
			'現在のページ数初期化
			NowPageNum = 1
			
			'最上明細ｲﾝﾃﾞｯｸｽ初期化
			pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
			
			'明細を画面に編集
			'UPGRADE_ISSUE: Control CS_JUC_URI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            'delete 20190325 START saiki
            'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Tag)
            'delete 20190325 END saiki
			Call F_DSP_BD_Inf(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_SET, pm_All)
		End If
		
	End Function
	' 2007/01/12  ADD END
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_CS_JUC_URI_KIS
	'   概要：  受注／売上画面呼出（機種別総括表）
	'   引数：  pm_Dsp_Sub_Inf      :画面情報
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_JUC_URI_KIS(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim RtnCode As Short
		Dim Wk_GetuKi As String
		' 2007/01/16  ADD START  KUMEDA
		Dim Wk_NENGETU As String
		' 2007/01/16  ADD END
		
		'明細ページ数設定
		MinPageNum = 1
		MaxPageNum = 1
		NowPageNum = 0
		' 2007/01/16  ADD START  KUMEDA
		Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
		' 2007/01/16  ADD END
		
		If gv_UODDL71_GETU_KI = "1" Then
			'当月
			' 2007/01/16  CHG START  KUMEDA
			'        Wk_GetuKi = "当月"
			Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2)
			' 2007/01/16  CHG END
		Else
			'当期
			' 2007/01/16  CHG START  KUMEDA
			'        Wk_GetuKi = "当期"
			Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2) & "　～　"
			Wk_GetuKi = Wk_GetuKi & Left(GV_UNYDate, 4) & "/" & Mid(GV_UNYDate, 5, 2)
			' 2007/01/16  CHG END
		End If
        'change 20190403 START saiki
        ''UPGRADE_ISSUE: Control CS_JUC_URI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'Select Case pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Caption
        '    Case "受　注"
        '        gv_UODDL71_JUC_URI = "1"

        '        'キャプション変更
        '        ' 2007/01/16  CHG START  KUMEDA
        '        '            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "　受注"
        '        'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '        pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi
        '        'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '        pm_All.Dsp_Base.FormCtl.FM_Panel3D1(11).Caption = "受　　注"
        '        ' 2007/01/16  CHG END
        '        'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '        pm_All.Dsp_Base.FormCtl.FM_Panel3D1(4).Caption = "受注数"
        '        'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '        pm_All.Dsp_Base.FormCtl.FM_Panel3D1(5).Caption = "受注金額"
        '        'UPGRADE_ISSUE: Control CS_JUC_URI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '        pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Caption = "売　上"
        '        'ADD START FKS)INABA 2010/10/05 ****************************************
        '        '連絡票№CF10100501
        '        'UPGRADE_ISSUE: Control lab_uri は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '        pm_All.Dsp_Base.FormCtl.lab_uri.Visible = False
        '        'ADD  END  FKS)INABA 2010/10/05 ****************************************

        '        'データ取得
        '        RtnCode = F_GET_BD_DATA_KIS_SOUKATU_JUC(gv_UODDL71_GETU_KI, pm_All)

        '    Case "売　上"
        '        gv_UODDL71_JUC_URI = "2"

        '        'キャプション変更
        '        ' 2007/01/16  CHG START  KUMEDA
        '        '            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "　売上"
        '        'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '        pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi
        '        'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '        pm_All.Dsp_Base.FormCtl.FM_Panel3D1(11).Caption = "売　　上"
        '        ' 2007/01/16  CHG END
        '        'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '        pm_All.Dsp_Base.FormCtl.FM_Panel3D1(4).Caption = "売上数"
        '        'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '        pm_All.Dsp_Base.FormCtl.FM_Panel3D1(5).Caption = "売上金額"
        '        'UPGRADE_ISSUE: Control CS_JUC_URI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '        pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Caption = "受　注"
        '        'ADD START FKS)INABA 2010/10/05 ****************************************
        '        '連絡票№CF10100501
        '        'UPGRADE_ISSUE: Control lab_uri は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '        pm_All.Dsp_Base.FormCtl.lab_uri.Visible = True
        '        'ADD  END  FKS)INABA 2010/10/05 ****************************************

        '        'データ取得
        '        RtnCode = F_GET_BD_DATA_KIS_SOUKATU_URI(gv_UODDL71_GETU_KI, pm_All)

        'End Select


        'UPGRADE_ISSUE: Control CS_JUC_URI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'change start 20190805 kuwahara
        'Select Case UODDL71.btnF6.Text
        'Case "(F6)" & vbCrLf & "受　注"
        Select Case Judge1
            Case 0
                'change end 20190805 kuwahara
                gv_UODDL71_JUC_URI = "1"

            'キャプション変更
            ' 2007/01/16  CHG START  KUMEDA
            '            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "　受注"
            'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            UODDL71._FM_Panel3D1_3.Text = Wk_GetuKi
            'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            UODDL71._FM_Panel3D1_11.Text = "受　　注"
            ' 2007/01/16  CHG END
            'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            UODDL71._FM_Panel3D1_4.Text = "受注数"
            'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            UODDL71._FM_Panel3D1_5.Text = "受注金額"
                'UPGRADE_ISSUE: Control CS_JUC_URI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'change start 20190805 kuwahara
                'UODDL71.btnF6.Text = "(F6)" & vbCrLf & "売　上"
                'Judge1 = 1
                'change end 20190805 kuwahara
                'ADD START FKS)INABA 2010/10/05 ****************************************
                '連絡票№CF10100501
                'UPGRADE_ISSUE: Control lab_uri は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL71.lab_uri.Visible = False
            'ADD  END  FKS)INABA 2010/10/05 ****************************************

            'データ取得
            RtnCode = F_GET_BD_DATA_KIS_SOUKATU_JUC(gv_UODDL71_GETU_KI, pm_All)

                'change start 20190805 kuwahara
                'Case "(F6)" & vbCrLf & "売　上"
            Case 1
                gv_UODDL71_JUC_URI = "2"

                'キャプション変更
                ' 2007/01/16  CHG START  KUMEDA
                '            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "　売上"
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL71._FM_Panel3D1_3.Text = Wk_GetuKi
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL71._FM_Panel3D1_11.Text = "売　　上"
                ' 2007/01/16  CHG END
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL71._FM_Panel3D1_4.Text = "売上数"
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL71._FM_Panel3D1_5.Text = "売上金額"
                'UPGRADE_ISSUE: Control CS_JUC_URI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'change start 20190805 kuwahara
                'UODDL71.btnF6.Text = "(F6)" & vbCrLf & "受　注"
                'Judge1 = 0
                'change end 20190805 kuwahara
                'ADD START FKS)INABA 2010/10/05 ****************************************
                '連絡票№CF10100501
                'UPGRADE_ISSUE: Control lab_uri は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL71.lab_uri.Visible = True
                'ADD  END  FKS)INABA 2010/10/05 ****************************************

                'データ取得
                RtnCode = F_GET_BD_DATA_KIS_SOUKATU_URI(gv_UODDL71_GETU_KI, pm_All)

        End Select
        'change 20190403 END saiki
        If RtnCode = 0 Then
            '出力できる明細データが無い
            Exit Function
        Else
            '現在のページ数初期化
            NowPageNum = 1
			
			'最上明細ｲﾝﾃﾞｯｸｽ初期化
			pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
			
			'明細を画面に編集
			'UPGRADE_ISSUE: Control CS_JUC_URI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            'delete 20190325 START saiki
            'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Tag)
            'delete 20190325 END saiki
			Call F_DSP_BD_Inf(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_SET, pm_All)
		End If
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_CS_GETU_KI_KIS
	'   概要：  当月／当期画面呼出（機種別総括表）
	'   引数：  pm_Dsp_Sub_Inf      :画面情報
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_GETU_KI_KIS(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim RtnCode As Short
		Dim Wk_GetuKi As String
		' 2007/01/16  ADD START  KUMEDA
		Dim Wk_NENGETU As String
		' 2007/01/16  ADD END
		
		'明細ページ数設定
		MinPageNum = 1
		MaxPageNum = 1
		NowPageNum = 0
        'change 20190403 START saiki
        'UPGRADE_ISSUE: Control CS_GETU_KI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'Select Case pm_All.Dsp_Base.FormCtl.CS_GETU_KI.Caption
        '	Case "当　月"
        '		gv_UODDL71_GETU_KI = "1"
        '		' 2007/01/16  CHG START  KUMEDA
        '		'            Wk_GetuKi = "当月"
        '		Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
        '		Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2)
        '		' 2007/01/16  CHG END

        '		'キャプション変更
        '		'UPGRADE_ISSUE: Control CS_GETU_KI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.CS_GETU_KI.Caption = "累　計"

        '	Case "累　計"
        '		gv_UODDL71_GETU_KI = "2"
        '		' 2007/01/16  CHG START  KUMEDA
        '		'            Wk_GetuKi = "当期"
        '		Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
        '		Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2) & "　～　"
        '		Wk_GetuKi = Wk_GetuKi & Left(GV_UNYDate, 4) & "/" & Mid(GV_UNYDate, 5, 2)
        '		' 2007/01/16  CHG END

        '		'キャプション変更
        '		'UPGRADE_ISSUE: Control CS_GETU_KI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.CS_GETU_KI.Caption = "当　月"

        'End Select

        'Select Case gv_UODDL71_JUC_URI
        '	Case "1"
        '		'受注
        '		'キャプション変更
        '		' 2007/01/16  CHG START  KUMEDA
        '		'            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "　受注"
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(11).Caption = "受　　注"
        '		' 2007/01/16
        '		'ADD START FKS)INABA 2010/10/05 ****************************************
        '		'連絡票№CF10100501
        '		'UPGRADE_ISSUE: Control lab_uri は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.lab_uri.Visible = False
        '		'ADD  END  FKS)INABA 2010/10/05 ****************************************

        '		'データ取得
        '		RtnCode = F_GET_BD_DATA_KIS_SOUKATU_JUC(gv_UODDL71_GETU_KI, pm_All)
        '	Case "2"
        '		'売上
        '		'キャプション変更
        '		' 2007/01/16  CHG START  KUMEDA
        '		'            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "　売上"
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(11).Caption = "売　　上"
        '		' 2007/01/16  CHG END
        '		'ADD START FKS)INABA 2010/10/05 ****************************************
        '		'連絡票№CF10100501
        '		'UPGRADE_ISSUE: Control lab_uri は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.lab_uri.Visible = True
        '		'ADD  END  FKS)INABA 2010/10/05 ****************************************

        '		'データ取得
        '		RtnCode = F_GET_BD_DATA_KIS_SOUKATU_URI(gv_UODDL71_GETU_KI, pm_All)
        'End Select


        'UPGRADE_ISSUE: Control CS_GETU_KI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'change start 20190805 kuwahara
        'Select Case UODDL71.btnF7.Text
        'Case "(F7)" & vbCrLf & "当　月"
        Select Case Judge2
            Case 0
                'change end 20190805 kuwahara
                gv_UODDL71_GETU_KI = "1"

                Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
            Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2)

                'キャプション変更
                'UPGRADE_ISSUE: Control CS_GETU_KI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'UODDL71.btnF7.Text = "(F7)" & vbCrLf & "累　計"
                'Judge2 = 1
                'change end 20190805 kuwahara

                'change start 20190805 kuwahara
                'Case "(F7)" & vbCrLf & "累　計"
            Case 1
                'change end 20190805 kuwahara
                gv_UODDL71_GETU_KI = "2"

                Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
                Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2) & "　～　"
                Wk_GetuKi = Wk_GetuKi & Left(GV_UNYDate, 4) & "/" & Mid(GV_UNYDate, 5, 2)

                'キャプション変更
                'UPGRADE_ISSUE: Control CS_GETU_KI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'change start 20190805 kuwahara
                'UODDL71.btnF7.Text = "(F7)" & vbCrLf & "当　月"
                'Judge2 = 0
                'change end 20190805　kuwahara

        End Select

        Select Case gv_UODDL71_JUC_URI
            Case "1"
                '受注
                'キャプション変更

                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL71._FM_Panel3D1_3.Text = Wk_GetuKi
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL71._FM_Panel3D1_11.Text = "受　　注"

                'UPGRADE_ISSUE: Control lab_uri は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL71.lab_uri.Visible = False

                'データ取得
                RtnCode = F_GET_BD_DATA_KIS_SOUKATU_JUC(gv_UODDL71_GETU_KI, pm_All)
            Case "2"
                '売上
                'キャプション変更
                ' 2007/01/16  CHG START  KUMEDA
                '            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "　売上"
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL71._FM_Panel3D1_3.Text = Wk_GetuKi
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL71._FM_Panel3D1_11.Text = "売　　上"
                'UPGRADE_ISSUE: Control lab_uri は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL71.lab_uri.Visible = True

                'データ取得
                RtnCode = F_GET_BD_DATA_KIS_SOUKATU_URI(gv_UODDL71_GETU_KI, pm_All)
        End Select
        'change 20190403 END saiki

        If RtnCode = 0 Then
			'出力できる明細データが無い
			Exit Function
		Else
			'現在のページ数初期化
			NowPageNum = 1
			
			'最上明細ｲﾝﾃﾞｯｸｽ初期化
			pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
			
			'明細を画面に編集
			'UPGRADE_ISSUE: Control CS_GETU_KI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            'delete 20190325 START saiki
            'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CS_GETU_KI.Tag)
            'delete 20190325 END saiki
			Call F_DSP_BD_Inf(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_SET, pm_All)
		End If
		
	End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_CS_BMNSOU_KIS
    '   概要：  部門別総括表画面呼出（機種別総括表）
    '   引数：  pm_Dsp_Sub_Inf      :画面情報
    '           pm_all              :全構造体
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Ctl_CS_BMNSOU_KIS(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
        '機種別総括表非表示
        '20190718 CHG START
        'FR_SSSMAIN1.Hide()
        UODDL71.Hide()
        '20190718 CHG END

        'delete 20190325 START saiki
        '' 2007/01/18  ADD START  KUMEDA
        ''UPGRADE_ISSUE: Control HD_BMNCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'gv_UODDL71_BMNCD = Trim(pm_All.Dsp_Base.FormCtl.HD_BMNCD.Text)
        ''UPGRADE_ISSUE: Control HD_TIKCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'gv_UODDL71_TIKCD = Trim(pm_All.Dsp_Base.FormCtl.HD_TIKCD.Text)
        ''UPGRADE_ISSUE: Control HD_EIGCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'gv_UODDL71_EIGCD = Trim(pm_All.Dsp_Base.FormCtl.HD_EIGCD.Text)
        'delete 20190325 END saiki
        gv_bolUODDL71_Active = True
		' 2007/01/18  ADD END
		
		'部門別総括表表示
		FR_SSSMAIN.Show()
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_CS_MEISAI_KIS
	'   概要：  機種明細表画面呼出（機種別総括表）
	'   引数：  pm_Dsp_Sub_Inf      :画面情報
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_MEISAI_KIS(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
        '当画面（機種別総括表）を非表示
        '20190718 CHG START
        'FR_SSSMAIN1.Hide()
        UODDL71.Hide()
        '20190718 CHG END
        'change 20190325 START saiki
        '' 2007/01/17  ADD START  KUMEDA
        ''UPGRADE_ISSUE: Control HD_BMNCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'gv_UODDL71_BMNCD = Trim(pm_All.Dsp_Base.FormCtl.HD_BMNCD.Text)
        ''UPGRADE_ISSUE: Control HD_TIKCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'gv_UODDL71_TIKCD = Trim(pm_All.Dsp_Base.FormCtl.HD_TIKCD.Text)
        ''UPGRADE_ISSUE: Control HD_EIGCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'gv_UODDL71_EIGCD = Trim(pm_All.Dsp_Base.FormCtl.HD_EIGCD.Text)
        '' 2007/01/17  ADD END

        ' 2007/01/17  ADD START  KUMEDA
        'UPGRADE_ISSUE: Control HD_BMNCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        gv_UODDL71_BMNCD = Trim(UODDL71.HD_BMNCD.Text)
        'UPGRADE_ISSUE: Control HD_TIKCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        gv_UODDL71_TIKCD = Trim(UODDL71.HD_TIKCD.Text)
        'UPGRADE_ISSUE: Control HD_EIGCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        gv_UODDL71_EIGCD = Trim(UODDL71.HD_EIGCD.Text)
        ' 2007/01/17  ADD END
        'change 20190325 END saiki

        '機種別総括表を表示
        gv_bolUODDL71_Active = True
        'UPGRADE_ISSUE: Load ステートメント はサポートされていません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' をクリックしてください。
        'change 20190325 START saiki
        'Load(FR_SSSMAIN2)
        'FR_SSSMAIN2.ShowDialog()
        'change 20190325 END saiki
        FR_SSSMAIN2.Show()
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_CS_JUC_URI_MEI
	'   概要：  受注／売上画面呼出（機種明細表）
	'   引数：  pm_Dsp_Sub_Inf      :画面情報
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_JUC_URI_MEI(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim RtnCode As Short
		Dim Wk_GetuKi As String
		' 2007/01/16  ADD START  KUMEDA
		Dim Wk_NENGETU As String
		' 2007/01/16  ADD END
		
		'明細ページ数設定
		MinPageNum = 1
		MaxPageNum = 1
		NowPageNum = 0
		' 2007/01/16  ADD START  KUMEDA
		Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
		' 2007/01/16  ADD END
		
		If gv_UODDL71_GETU_KI = "1" Then
			'当月
			' 2007/01/16  CHG START  KUMEDA
			'        Wk_GetuKi = "当月"
			Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2)
			' 2007/01/16  CHG END
		Else
			'当期
			' 2007/01/16  CHG START  KUMEDA
			'        Wk_GetuKi = "当期"
			Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2) & "　～　"
			Wk_GetuKi = Wk_GetuKi & Left(GV_UNYDate, 4) & "/" & Mid(GV_UNYDate, 5, 2)
			' 2007/01/16  CHG END
		End If
        'change start 20190806 kuwahara
        'UPGRADE_ISSUE: Control CS_JUC_URI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'Select Case pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Caption
        '	Case "受　注"
        '		gv_UODDL71_JUC_URI = "1"

        '		'キャプション変更
        '		' 2007/01/16  CHG START  KUMEDA
        '		'            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "　受注"
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(11).Caption = "受　　注"
        '		' 2007/01/16  CHG END
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(4).Caption = "受注数"
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(5).Caption = "受注金額"
        '		'UPGRADE_ISSUE: Control CS_JUC_URI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Caption = "売　上"
        '		'ADD START FKS)INABA 2010/10/05 ****************************************
        '		'連絡票№CF10100501
        '		'UPGRADE_ISSUE: Control lab_uri は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.lab_uri.Visible = False
        '		'ADD  END  FKS)INABA 2010/10/05 ****************************************

        '		'データ取得
        '		RtnCode = F_GET_BD_DATA_KIS_MEISAI_JUC(gv_UODDL71_GETU_KI, pm_All)

        '	Case "売　上"
        '		gv_UODDL71_JUC_URI = "2"

        '		'キャプション変更
        '		' 2007/01/16  CHG START  KUMEDA
        '		'            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "　売上"
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(11).Caption = "売　　上"
        '		' 2007/01/16  CHG END
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(4).Caption = "売上数"
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(5).Caption = "売上金額"
        '		'UPGRADE_ISSUE: Control CS_JUC_URI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Caption = "受　注"
        '		'ADD START FKS)INABA 2010/10/05 ****************************************
        '		'連絡票№CF10100501
        '		'UPGRADE_ISSUE: Control lab_uri は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.lab_uri.Visible = True
        '		'ADD  END  FKS)INABA 2010/10/05 ****************************************

        '		'データ取得
        '		RtnCode = F_GET_BD_DATA_KIS_MEISAI_URI(gv_UODDL71_GETU_KI, pm_All)

        'End Select

        Select Case Judge1
            Case 0
                gv_UODDL71_JUC_URI = "1"

                'キャプション変更
                ' 2007/01/16  CHG START  KUMEDA
                '            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "　受注"
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL712._FM_Panel3D1_3.Text = Wk_GetuKi
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL712._FM_Panel3D1_11.Text = "受　　注"
                ' 2007/01/16  CHG END
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL712._FM_Panel3D1_4.Text = "受注数"
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL712._FM_Panel3D1_5.Text = "受注金額"
                'UPGRADE_ISSUE: Control CS_JUC_URI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'ADD START FKS)INABA 2010/10/05 ****************************************
                '連絡票№CF10100501
                'UPGRADE_ISSUE: Control lab_uri は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL712.lab_uri.Visible = False
                'ADD  END  FKS)INABA 2010/10/05 ****************************************

                'データ取得
                RtnCode = F_GET_BD_DATA_KIS_MEISAI_JUC(gv_UODDL71_GETU_KI, pm_All)

            Case 1
                gv_UODDL71_JUC_URI = "2"

                'キャプション変更
                ' 2007/01/16  CHG START  KUMEDA
                '            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "　売上"
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL712._FM_Panel3D1_3.Text = Wk_GetuKi
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL712._FM_Panel3D1_11.Text = "売　　上"
                ' 2007/01/16  CHG END
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL712._FM_Panel3D1_4.Text = "売上数"
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL712._FM_Panel3D1_5.Text = "売上金額"
                'UPGRADE_ISSUE: Control CS_JUC_URI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'ADD START FKS)INABA 2010/10/05 ****************************************
                '連絡票№CF10100501
                'UPGRADE_ISSUE: Control lab_uri は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL712.lab_uri.Visible = True
                'ADD  END  FKS)INABA 2010/10/05 ****************************************

                'データ取得
                RtnCode = F_GET_BD_DATA_KIS_MEISAI_URI(gv_UODDL71_GETU_KI, pm_All)

        End Select
        'change end 20190806 kuwahara
        If RtnCode = 0 Then
			'出力できる明細データが無い
			Exit Function
		Else
			'現在のページ数初期化
			NowPageNum = 1
			
			'最上明細ｲﾝﾃﾞｯｸｽ初期化
			pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
			
			'明細を画面に編集
			'UPGRADE_ISSUE: Control CS_JUC_URI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            'delete 20190325 START saiki
            'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Tag)
            'delete 20190325 END saiki
			Call F_DSP_BD_Inf(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_SET, pm_All)
		End If
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_CS_GETU_KI_MEI
	'   概要：  当月／当期画面呼出（機種明細表）
	'   引数：  pm_Dsp_Sub_Inf      :画面情報
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_GETU_KI_MEI(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim RtnCode As Short
		Dim Wk_GetuKi As String
		' 2007/01/16  ADD START  KUMEDA
		Dim Wk_NENGETU As String
		' 2007/01/16  ADD END
		
		'明細ページ数設定
		MinPageNum = 1
		MaxPageNum = 1
		NowPageNum = 0
        'change start 20190806 kuwahara
        'UPGRADE_ISSUE: Control CS_GETU_KI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'Select Case pm_All.Dsp_Base.FormCtl.CS_GETU_KI.Caption
        '	Case "当　月"
        '		gv_UODDL71_GETU_KI = "1"
        '		' 2007/01/16  CHG START  KUMEDA
        '		'            Wk_GetuKi = "当月"
        '		Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
        '		Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2)
        '		' 2007/01/16  CHG END

        '		'キャプション変更
        '		'UPGRADE_ISSUE: Control CS_GETU_KI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.CS_GETU_KI.Caption = "累　計"

        '	Case "累　計"
        '		gv_UODDL71_GETU_KI = "2"
        '		' 2007/01/16  CHG START  KUMEDA
        '		'            Wk_GetuKi = "当期"
        '		Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
        '		Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2) & "　～　"
        '		Wk_GetuKi = Wk_GetuKi & Left(GV_UNYDate, 4) & "/" & Mid(GV_UNYDate, 5, 2)
        '		' 2007/01/16  CHG END

        '		'キャプション変更
        '		'UPGRADE_ISSUE: Control CS_GETU_KI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.CS_GETU_KI.Caption = "当　月"

        'End Select

        'Select Case gv_UODDL71_JUC_URI
        '	Case "1"
        '		'受注
        '		'キャプション変更
        '		' 2007/01/16  CHG START  KUMEDA
        '		'            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "　受注"
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(11).Caption = "受　　注"
        '		' 2007/01/16  CHG END
        '		'ADD START FKS)INABA 2010/10/05 ****************************************
        '		'連絡票№CF10100501
        '		'UPGRADE_ISSUE: Control lab_uri は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.lab_uri.Visible = False
        '		'ADD  END  FKS)INABA 2010/10/05 ****************************************

        '		'データ取得
        '		RtnCode = F_GET_BD_DATA_KIS_MEISAI_JUC(gv_UODDL71_GETU_KI, pm_All)
        '	Case "2"
        '		'売上
        '		'キャプション変更
        '		' 2007/01/16  CHG START  KUMEDA
        '		'            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "　売上"
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(11).Caption = "売　　上"
        '		' 2007/01/16  CHG END
        '		'ADD START FKS)INABA 2010/10/05 ****************************************
        '		'連絡票№CF10100501
        '		'UPGRADE_ISSUE: Control lab_uri は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		pm_All.Dsp_Base.FormCtl.lab_uri.Visible = True
        '		'ADD  END  FKS)INABA 2010/10/05 ****************************************

        '		'データ取得
        '		RtnCode = F_GET_BD_DATA_KIS_MEISAI_URI(gv_UODDL71_GETU_KI, pm_All)
        'End Select

        Select Case Judge2
            Case 0
                gv_UODDL71_GETU_KI = "1"
                ' 2007/01/16  CHG START  KUMEDA
                '            Wk_GetuKi = "当月"
                Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
                Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2)
                ' 2007/01/16  CHG END


            Case 1
                gv_UODDL71_GETU_KI = "2"
                ' 2007/01/16  CHG START  KUMEDA
                '            Wk_GetuKi = "当期"
                Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
                Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2) & "　～　"
                Wk_GetuKi = Wk_GetuKi & Left(GV_UNYDate, 4) & "/" & Mid(GV_UNYDate, 5, 2)
                ' 2007/01/16  CHG END

        End Select

        Select Case gv_UODDL71_JUC_URI
            Case "1"
                '受注
                'キャプション変更
                ' 2007/01/16  CHG START  KUMEDA
                '            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "　受注"
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL712._FM_Panel3D1_3.Text = Wk_GetuKi
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL712._FM_Panel3D1_11.Text = "受　　注"
                ' 2007/01/16  CHG END
                'ADD START FKS)INABA 2010/10/05 ****************************************
                '連絡票№CF10100501
                'UPGRADE_ISSUE: Control lab_uri は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL712.lab_uri.Visible = False
                'ADD  END  FKS)INABA 2010/10/05 ****************************************

                'データ取得
                RtnCode = F_GET_BD_DATA_KIS_MEISAI_JUC(gv_UODDL71_GETU_KI, pm_All)
            Case "2"
                '売上
                'キャプション変更
                ' 2007/01/16  CHG START  KUMEDA
                '            UODDL712.FM_Panel3D1(3).Caption = Wk_GetuKi & "　売上"
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL712._FM_Panel3D1_3.Text = Wk_GetuKi
                'UPGRADE_ISSUE: Control FM_Panel3D1 は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL712._FM_Panel3D1_11.Text = "売　　上"
                ' 2007/01/16  CHG END
                'ADD START FKS)INABA 2010/10/05 ****************************************
                '連絡票№CF10100501
                'UPGRADE_ISSUE: Control lab_uri は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                UODDL712.lab_uri.Visible = True
                'ADD  END  FKS)INABA 2010/10/05 ****************************************

                'データ取得
                RtnCode = F_GET_BD_DATA_KIS_MEISAI_URI(gv_UODDL71_GETU_KI, pm_All)
        End Select

        'change end 20190806 kuwahara
        If RtnCode = 0 Then
			'出力できる明細データが無い
			Exit Function
		Else
			'現在のページ数初期化
			NowPageNum = 1
			
			'最上明細ｲﾝﾃﾞｯｸｽ初期化
			pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
			
			'明細を画面に編集
			'UPGRADE_ISSUE: Control CS_GETU_KI は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            'delete 20190325 START saiki
            'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CS_GETU_KI.Tag)
            'delete 20190325 END saiki
			Call F_DSP_BD_Inf(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_SET, pm_All)
		End If
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_CS_BMNSOU_MEI
	'   概要：  部門別総括表画面呼出（機種明細表）
	'   引数：  pm_Dsp_Sub_Inf      :画面情報
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_BMNSOU_MEI(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
        '機種明細表非表示
        '20190718 CHG START
        'FR_SSSMAIN2.Hide()
        UODDL712.Hide()
        '20190718 CHG END

        '      'delete 20190325 START saiki
        '' 2007/01/18  ADD START  KUMEDA
        ''UPGRADE_ISSUE: Control HD_BMNCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'gv_UODDL71_BMNCD = Trim(pm_All.Dsp_Base.FormCtl.HD_BMNCD.Text)
        ''UPGRADE_ISSUE: Control HD_TIKCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'gv_UODDL71_TIKCD = Trim(pm_All.Dsp_Base.FormCtl.HD_TIKCD.Text)
        ''UPGRADE_ISSUE: Control HD_EIGCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'gv_UODDL71_EIGCD = Trim(pm_All.Dsp_Base.FormCtl.HD_EIGCD.Text)
        'delete 20190325 END saiki
        gv_bolUODDL71_Active = True
		' 2007/01/18  ADD END
		
		'部門別総括表表示
		FR_SSSMAIN.Show()
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_CS_SOUKATU_MEI
	'   概要：  機種別総括表画面呼出（機種明細表）
	'   引数：  pm_Dsp_Sub_Inf      :画面情報
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_SOUKATU_MEI(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
        '機種明細表非表示
        '20190718 CHG START
        'FR_SSSMAIN2.Hide()
        UODDL712.Hide()
        '20190718 CHG END

        'delete 20190325 START saiki
        '' 2007/01/18  ADD START  KUMEDA
        ''UPGRADE_ISSUE: Control HD_BMNCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'gv_UODDL71_BMNCD = Trim(pm_All.Dsp_Base.FormCtl.HD_BMNCD.Text)
        ''UPGRADE_ISSUE: Control HD_TIKCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'gv_UODDL71_TIKCD = Trim(pm_All.Dsp_Base.FormCtl.HD_TIKCD.Text)
        ''UPGRADE_ISSUE: Control HD_EIGCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'gv_UODDL71_EIGCD = Trim(pm_All.Dsp_Base.FormCtl.HD_EIGCD.Text)
        'delete 20190325 END saiki
        gv_bolUODDL71_Active = True
        ' 2007/01/18  ADD END

        '機種別総括表表示
        '20190718 CHG START
        'FR_SSSMAIN1.Show()
        UODDL71.Show()
        '20190718 CHG END

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_CS_BMNCD
    '   概要：  対象項目の部門検索ﾎﾞﾀﾝの制御
    '   引数：  pm_Dsp_Sub_Inf      :画面情報
    '           pm_all              :全構造体
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'change 20190405 START saiki
    'Public Function F_Ctl_CS_BMNCD(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
    Public Function F_Ctl_CS_BMNCD(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All, ByRef UODDL As Integer) As Short
        'change 20190405 END saiki

        Dim Trg_Index As Short
        Dim Dsp_Value As Object
        Dim Move_Flg As Boolean
        Dim Rtn_Chk As Short
        Dim Dsp_Mode As Short
        Dim Chk_Move_Flg As Boolean
        Dim Next_Focus As Short

        '割当ｲﾝﾃﾞｯｸｽ取得
        'UPGRADE_ISSUE: Control HD_BMNCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'change 20190325 START saiki
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_BMNCD.Tag)
        If UODDL = 711 Then
            Trg_Index = CShort(UODDL71.HD_BMNCD.Tag)
        Else
            Trg_Index = CShort(UODDL712.HD_BMNCD.Tag)
        End If
        'change 20190325 END saiki
        Next_Focus = Trg_Index

        'ﾌｫｰｶｽを部門コードへ移動
        If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
            ' 2006/11/28  ADD START  KUMEDA
            If pm_All.Dsp_Base.FormCtl.ActiveControl Is Nothing Then
                Exit Function
            End If
            ' 2006/11/28  ADD END

            '現在のActiveコントロールの選択状態解除
            'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(pm_All.Dsp_Base.FormCtl.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
            'ﾌｫｰｶｽ移動
            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
            '項目色設定
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

            gv_bolUODDL71_LF_Enable = False

            '======================= 変更部分 2006.06.12 Start =================================
            'Windowsに処理を返す
            System.Windows.Forms.Application.DoEvents()
            '======================= 変更部分 2006.06.12 End =================================

            '部門検索画面を呼び出す
            WLSMEIC_KEYCD = pc_Bmncd_Keycode
            WLSMEIC_TKDT = GV_UNYDate
            WLS_MEI4.ShowDialog()
            WLS_MEI4.Close()

            gv_bolUODDL71_LF_Enable = True

            If WLSMEIC_RTNMEICDA <> "" Then
                '検索ＯＫ
                '画面に編集
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(WLSMEIC_RTNMEICDA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

                'チェック
                '各項目のﾁｪｯｸﾙｰﾁﾝ
                Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)

                If Rtn_Chk = CHK_OK Then
                    'チェックＯＫ時
                    '取得内容表示
                    Dsp_Mode = DSP_SET
                Else
                    'チェックＮＧ時
                    '取得内容クリア
                    Dsp_Mode = DSP_CLR
                End If
                '取得内容表示/クリア
                Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)

                'ADD 20190408 START saiki
                If UODDL = 711 Then
                    UODDL71.HD_EIGCD.Text = ""
                    UODDL71.HD_EIGNM.Text = ""
                    UODDL71.HD_TIKCD.Text = ""
                    UODDL71.HD_TIKNM.Text = ""
                    gv_UODDL71_BMNCD = UODDL71.HD_BMNCD.Text
                    gv_bolUODDL71_Active = True

                Else
                    UODDL712.HD_EIGCD.Text = ""
                    UODDL712.HD_EIGNM.Text = ""
                    UODDL712.HD_TIKCD.Text = ""
                    UODDL712.HD_TIKNM.Text = ""

                End If


                'ADD 20190408 END saiki

                If Chk_Move_Flg = True Then
                    'ﾁｪｯｸ後移動あり
                    Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
                Else

                    'ﾌｫｰｶｽ移動
                    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                    '項目色設定
                    Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
                End If
            End If
        Else
            'ﾁｪｯｸ後移動なし
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
            '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
        End If

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_CS_TIKCD
    '   概要：  対象項目の地区検索ﾎﾞﾀﾝの制御
    '   引数：  pm_Dsp_Sub_Inf      :画面情報
    '           pm_all              :全構造体
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'change 20190405 START saiki
    'Public Function F_Ctl_CS_TIKCD(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
    Public Function F_Ctl_CS_TIKCD(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All, ByRef UODDL As Integer) As Short
        'change 20190405 END saiki

        Dim Trg_Index As Short
        Dim Dsp_Value As Object
        Dim Move_Flg As Boolean
        Dim Rtn_Chk As Short
        Dim Dsp_Mode As Short
        Dim Chk_Move_Flg As Boolean
        Dim Next_Focus As Short

        '割当ｲﾝﾃﾞｯｸｽ取得
        'UPGRADE_ISSUE: Control HD_TIKCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'change 20190325 START saiki
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_TIKCD.Tag)
        If UODDL = 711 Then
            Trg_Index = CShort(UODDL71.HD_TIKCD.Tag)
        Else
            Trg_Index = CShort(UODDL712.HD_TIKCD.Tag)
        End If
        'change 20190325 END saiki
        Next_Focus = Trg_Index

        'ﾌｫｰｶｽを地区区分へ移動
        If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
            ' 2006/11/28  ADD START  KUMEDA
            If pm_All.Dsp_Base.FormCtl.ActiveControl Is Nothing Then
                Exit Function
            End If
            ' 2006/11/28  ADD END

            '現在のActiveコントロールの選択状態解除
            'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(pm_All.Dsp_Base.FormCtl.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
            'ﾌｫｰｶｽ移動
            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
            '項目色設定
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

            gv_bolUODDL71_LF_Enable = False

            '======================= 変更部分 2006.06.12 Start =================================
            'Windowsに処理を返す
            System.Windows.Forms.Application.DoEvents()
            '======================= 変更部分 2006.06.12 End =================================

            '地区検索画面を呼び出す
            WLSMEIC_KEYCD = pc_Tikcd_Keycode
            WLSMEIC_TKDT = GV_UNYDate
            WLS_MEI4.ShowDialog()
            WLS_MEI4.Close()

            gv_bolUODDL71_LF_Enable = True

            If WLSMEIC_RTNMEICDA <> "" Then
                '検索ＯＫ
                '画面に編集
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(WLSMEIC_RTNMEICDA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

                'チェック
                '各項目のﾁｪｯｸﾙｰﾁﾝ
                Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)

                If Rtn_Chk = CHK_OK Then
                    'チェックＯＫ時
                    '取得内容表示
                    Dsp_Mode = DSP_SET
                Else
                    'チェックＮＧ時
                    '取得内容クリア
                    Dsp_Mode = DSP_CLR
                End If
                '取得内容表示/クリア
                Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)


                If Chk_Move_Flg = True Then
                    'ﾁｪｯｸ後移動あり
                    Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
                Else

                    'ﾌｫｰｶｽ移動
                    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                    '項目色設定
                    Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
                End If


                'ADD 20190408 START saiki
                If UODDL = 711 Then
                    UODDL71.HD_BMNCD.Text = ""
                    UODDL71.HD_BMNNM.Text = ""
                    UODDL71.HD_EIGCD.Text = ""
                    UODDL71.HD_EIGNM.Text = ""


                Else
                    UODDL712.HD_BMNCD.Text = ""
                    UODDL712.HD_BMNNM.Text = ""
                    UODDL712.HD_EIGCD.Text = ""
                    UODDL712.HD_EIGNM.Text = ""
                    gv_UODDL71_BMNCD = ""
                    gv_UODDL71_TIKCD = UODDL712.HD_TIKCD.Text
                    gv_bolUODDL71_Active = True

                End If
                'ADD 20190408 END saiki
            End If
        Else
            'ﾁｪｯｸ後移動なし
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
            '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
        End If

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_CS_EIGCD
    '   概要：  対象項目の営業所検索ﾎﾞﾀﾝの制御
    '   引数：  pm_Dsp_Sub_Inf      :画面情報
    '           pm_all              :全構造体
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Public Function F_Ctl_CS_EIGCD(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
    Public Function F_Ctl_CS_EIGCD(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All, ByRef UODDL As Integer) As Short

        Dim Trg_Index As Short
        Dim Dsp_Value As Object
        Dim Move_Flg As Boolean
        Dim Rtn_Chk As Short
        Dim Dsp_Mode As Short
        Dim Chk_Move_Flg As Boolean
        Dim Next_Focus As Short

        '割当ｲﾝﾃﾞｯｸｽ取得
        'UPGRADE_ISSUE: Control HD_EIGCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'change 20190325 START saiki
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_EIGCD.Tag)
        If UODDL = 711 Then
            Trg_Index = CShort(UODDL71.HD_EIGCD.Tag)
        Else
            Trg_Index = CShort(UODDL712.HD_EIGCD.Tag)
        End If
        'change 20190325 END saiki
        Next_Focus = Trg_Index

        'ﾌｫｰｶｽを営業所コードへ移動
        If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
            ' 2006/11/28  ADD START  KUMEDA
            If pm_All.Dsp_Base.FormCtl.ActiveControl Is Nothing Then
                Exit Function
            End If
            ' 2006/11/28  ADD END

            '現在のActiveコントロールの選択状態解除
            'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(pm_All.Dsp_Base.FormCtl.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
            'ﾌｫｰｶｽ移動
            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
            '項目色設定
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

            gv_bolUODDL71_LF_Enable = False

            '======================= 変更部分 2006.06.12 Start =================================
            'Windowsに処理を返す
            System.Windows.Forms.Application.DoEvents()
            '======================= 変更部分 2006.06.12 End =================================

            '営業所検索画面を呼び出す
            WLSMEIC_KEYCD = pc_Eigcd_Keycode
            WLSMEIC_TKDT = GV_UNYDate
            WLS_MEI4.ShowDialog()
            WLS_MEI4.Close()

            gv_bolUODDL71_LF_Enable = True

            If WLSMEIC_RTNMEICDA <> "" Then
                '検索ＯＫ
                '画面に編集
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(WLSMEIC_RTNMEICDA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

                'チェック
                '各項目のﾁｪｯｸﾙｰﾁﾝ
                Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)

                If Rtn_Chk = CHK_OK Then
                    'チェックＯＫ時
                    '取得内容表示
                    Dsp_Mode = DSP_SET
                Else
                    'チェックＮＧ時
                    '取得内容クリア
                    Dsp_Mode = DSP_CLR
                End If
                '取得内容表示/クリア
                Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)

                'ADD 20190408 START saiki
                If UODDL = 711 Then
                    UODDL71.HD_BMNCD.Text = ""
                    UODDL71.HD_BMNNM.Text = ""
                    UODDL71.HD_TIKCD.Text = ""
                    UODDL71.HD_TIKNM.Text = ""
                Else
                    UODDL712.HD_BMNCD.Text = ""
                    UODDL712.HD_BMNNM.Text = ""
                    UODDL712.HD_TIKCD.Text = ""
                    UODDL712.HD_TIKNM.Text = ""
                    gv_UODDL71_EIGCD = UODDL712.HD_EIGCD.Text
                    gv_bolUODDL71_Active = True
                End If

                'ADD 20190408 END saiki

                If Chk_Move_Flg = True Then
                    'ﾁｪｯｸ後移動あり
                    Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
                Else

                    'ﾌｫｰｶｽ移動
                    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                    '項目色設定
                    Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
                End If
            End If
        Else
            'ﾁｪｯｸ後移動なし
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
            '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
        End If

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_CS
    '   概要：  検索画面表示
    '   引数：　pm_All          :全構造体
    '   戻値：　なし
    '   備考：  検索画面表示イメージをクリックした際の処理
    '           フォーカスは入力コントロールにあるままの状態
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'change start 20190806 kuwahara
    'Public Function F_Ctl_CS(ByRef pm_All As Cls_All) As Short
    Public Function F_Ctl_CS(ByRef pm_All As Cls_All, ByRef UODDL As Integer) As Short
        'change end 20190806 kuwahara

        Dim Cursor_Index As Short
        Dim Trg_Index As Short

        '現在のフォーカス取得コントロールのインデックス
        Cursor_Index = pm_All.Dsp_Base.Cursor_Idx
        'UPGRADE_ISSUE: Control HD_EIGCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'UPGRADE_ISSUE: Control HD_TIKCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'UPGRADE_ISSUE: Control HD_BMNCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'change start 20190806 kuwahara
        '	Case CShort(pm_All.Dsp_Base.FormCtl.HD_BMNCD.Tag)
        '		'部門
        '		'UPGRADE_ISSUE: Control CS_BMNCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CS_BMNCD.Tag)
        '		Call F_Ctl_CS_BMNCD(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

        '	Case CShort(pm_All.Dsp_Base.FormCtl.HD_TIKCD.Tag)
        '		'地区
        '		'UPGRADE_ISSUE: Control CS_TIKCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CS_TIKCD.Tag)
        '		Call F_Ctl_CS_TIKCD(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

        '	Case CShort(pm_All.Dsp_Base.FormCtl.HD_EIGCD.Tag)
        '		'営業所
        '		'UPGRADE_ISSUE: Control CS_EIGCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '		Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CS_EIGCD.Tag)
        '		Call F_Ctl_CS_EIGCD(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        'add start 20190806 kuwahara
        If UODDL = 711 Then

                Select Case Cursor_Index
                    Case CShort(UODDL71.HD_BMNCD.Tag)
                        '部門
                        'UPGRADE_ISSUE: Control CS_BMNCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        Trg_Index = CShort(FR_SSSMAIN1.CS_BMNCD.Tag)
                        Call SSSMAIN0001.F_Ctl_CS_BMNCD(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, UODDL)

                    Case CShort(UODDL71.HD_TIKCD.Tag)
                        '地区
                        'UPGRADE_ISSUE: Control CS_TIKCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        Trg_Index = CShort(FR_SSSMAIN1.CS_TIKCD.Tag)
                        Call SSSMAIN0001.F_Ctl_CS_TIKCD(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, UODDL)

                    Case CShort(UODDL71.HD_EIGCD.Tag)
                        '営業所
                        'UPGRADE_ISSUE: Control CS_EIGCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        Trg_Index = CShort(FR_SSSMAIN1.CS_EIGCD.Tag)
                        Call SSSMAIN0001.F_Ctl_CS_EIGCD(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, UODDL)
                End Select

            Else
                Select Case Cursor_Index

                    Case CShort(UODDL712.HD_BMNCD.Tag)
                        '部門
                        'UPGRADE_ISSUE: Control CS_BMNCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        Trg_Index = CShort(FR_SSSMAIN1.CS_BMNCD.Tag)
                        Call SSSMAIN0001.F_Ctl_CS_BMNCD(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, UODDL)

                    Case CShort(UODDL712.HD_TIKCD.Tag)
                        '地区
                        'UPGRADE_ISSUE: Control CS_TIKCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        Trg_Index = CShort(FR_SSSMAIN1.CS_TIKCD.Tag)
                        Call SSSMAIN0001.F_Ctl_CS_TIKCD(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, UODDL)

                    Case CShort(UODDL712.HD_EIGCD.Tag)
                        '営業所
                        'UPGRADE_ISSUE: Control CS_EIGCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                        Trg_Index = CShort(FR_SSSMAIN1.CS_EIGCD.Tag)
                        Call SSSMAIN0001.F_Ctl_CS_EIGCD(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, UODDL)
                End Select

            End If
        'add end 20190806 kuwahara

        'change end 20190806 kuwahara
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Foot_In_Ready
    '   概要：  フッタ部の入力準備
    '   引数：　pm_All      : 全構造体
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Foot_In_Ready(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
        'delete 20190325 START saiki
		'フッタ部内で処理
        'For Index_Wk = pm_All.Dsp_Base.Foot_Fst_Idx To pm_All.Dsp_Base.Item_Cnt
        '	'UPGRADE_ISSUE: Control TX_Dummy は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '	Select Case pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.Name
        '		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        '		Case pm_All.Dsp_Base.FormCtl.TX_Dummy.NAME
        '			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
        '			'初期状態で入力可能なｺﾝﾄﾛｰﾙ
        '			'入力可能
        '			Call CF_Set_Item_Focus_Ctl(True, pm_All.Dsp_Sub_Inf(Index_Wk))
        '	End Select
        'Next 
        'delete 20190325 END saiki
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_MN_Enabled
	'   概要：  メニュー使用可否制御
	'   引数：　pm_All        : 全構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_MN_Enabled(ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Wk_Index As Short
		
		F_Ctl_MN_Enabled = 9
        'delete 20190325 START saiki
        ''メニューボタンイメージの可視制御
        ''終了ボタン
        ''UPGRADE_ISSUE: Control CM_EndCm は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CM_EndCm.Tag)
        ''UPGRADE_ISSUE: Control MN_EndCm は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '      Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.MN_EndCm.Tag)
        'delete 20190325 END saiki
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'    '実行ボタン
		'    Trg_Index = CInt(pm_All.Dsp_Base.FormCtl.CM_Execute.Tag)
		'    Wk_Index = CInt(pm_All.Dsp_Base.FormCtl.MN_Execute.Tag)
		'    pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'    '検索画面表示ボタン
		'    Trg_Index = CInt(pm_All.Dsp_Base.FormCtl.CM_SLIST.Tag)
		'    Wk_Index = CInt(pm_All.Dsp_Base.FormCtl.MN_Slist.Tag)
		'    pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'    '明細部クリアボタン
		'    Trg_Index = CInt(pm_All.Dsp_Base.FormCtl.CM_SELECTCM.Tag)
		'    Wk_Index = CInt(pm_All.Dsp_Base.FormCtl.MN_SELECTCM.Tag)
		'    pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
        '前頁ボタン
        'delete 20190325 START saiki
        ''UPGRADE_ISSUE: Control CM_PREV は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CM_PREV.Tag)
        ''UPGRADE_ISSUE: Control MN_PREV は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.MN_PREV.Tag)
        'pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
        ''次頁ボタン
        ''UPGRADE_ISSUE: Control CM_NEXTCM は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CM_NEXTCM.Tag)
        ''UPGRADE_ISSUE: Control MN_NEXTCM は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '      Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.MN_NEXTCM.Tag)
        'delete 20190325 END saiki
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		
		F_Ctl_MN_Enabled = 0
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_PageButton_Enabled
	'Invalid_string_refer_to_original_code
	'   引数：　pm_All           : 全構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_PageButton_Enabled(ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Wk_Index As Short
		
		F_Ctl_PageButton_Enabled = 9
        'delete 20190325 START saiki
		'前頁
		'UPGRADE_ISSUE: Control MN_PREV は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.MN_PREV.Tag)
        'delete 20190325 END saiki
		If NowPageNum > MinPageNum Then
			pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
		Else
			pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
        End If
        'delete 20190325 START saiki
		'次頁
		'UPGRADE_ISSUE: Control MN_NEXTCM は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.MN_NEXTCM.Tag)
        'delete 20190325 END saiki
		If NowPageNum < MaxPageNum Then
			pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
		Else
			pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
		End If

        'delete 20190325 START saiki
        ''前頁ボタン
        ''UPGRADE_ISSUE: Control CM_PREV は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CM_PREV.Tag)
        ''UPGRADE_ISSUE: Control MN_PREV は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.MN_PREV.Tag)
        'pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
        ''次頁ボタン
        ''UPGRADE_ISSUE: Control CM_NEXTCM は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CM_NEXTCM.Tag)
        ''UPGRADE_ISSUE: Control MN_NEXTCM は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '      Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.MN_NEXTCM.Tag)
        'delete 20190325 END saiki
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		
		F_Ctl_PageButton_Enabled = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Inp_Item_Focus_Ctl
	'   概要：  入力コントロールの使用可否制御
	'   引数：　pm_Value              :設定値
	'           pm_All                :全構造体
	'   戻値：　処理結果
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Inp_Item_Focus_Ctl(ByRef pm_Value As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		
		F_Set_Inp_Item_Focus_Ctl = 9
        'delete 20190325 START saiki
        ''部門
        ''UPGRADE_ISSUE: Control HD_BMNCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_BMNCD.Tag)
        'Call CF_Set_Item_Focus_Ctl(pm_Value, pm_All.Dsp_Sub_Inf(Trg_Index))
        ''地区
        ''UPGRADE_ISSUE: Control HD_TIKCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_TIKCD.Tag)
        'Call CF_Set_Item_Focus_Ctl(pm_Value, pm_All.Dsp_Sub_Inf(Trg_Index))
        ''営業所
        ''UPGRADE_ISSUE: Control HD_EIGCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_EIGCD.Tag)
        'Call CF_Set_Item_Focus_Ctl(pm_Value, pm_All.Dsp_Sub_Inf(Trg_Index))
        ''ダミー
        ''UPGRADE_ISSUE: Control TX_Dummy は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.TX_Dummy.Tag)
        'Call CF_Set_Item_Focus_Ctl(Not pm_Value, pm_All.Dsp_Sub_Inf(Trg_Index))
        'delete 20190325 END saiki
		If pm_Value = True Then
			'ページ情報（現在ページ、最大ページ等の退避変数）をクリア
			'明細ページ数初期化
			MinPageNum = 1
			MaxPageNum = 1
			NowPageNum = 0
		End If
		
		F_Set_Inp_Item_Focus_Ctl = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Init_Clr_Dsp
	'   概要：  各画面の項目を初期化
	'   引数：　pm_Index    :オブジェクトのインデックス
	'   戻値：  なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Clr_Dsp(ByRef pm_Index As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		Dim Wk_Index_S As Short
		Dim Wk_Index_E As Short
		Dim Wk_Mode As Short
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		If pm_Index = -1 Then
			Wk_Index_S = 1
			Wk_Index_E = pm_All.Dsp_Base.Item_Cnt
			pm_All.Dsp_Base.Head_Ok_Flg = False
			Wk_Mode = ITM_ALL_CLR
		Else
			Wk_Index_S = pm_Index
			Wk_Index_E = pm_Index
			Wk_Mode = ITM_ALL_ONLY
		End If
		
		For Index_Wk = Wk_Index_S To Wk_Index_E
			
			'共通初期化
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Index_Wk), Wk_Mode, pm_All)
			
			'全体初期化の場合
			If Wk_Mode = ITM_ALL_CLR Then
				'ボディ部以降の項目を全ﾌｫｰｶｽなしとする
				If Index_Wk > pm_All.Dsp_Base.Head_Lst_Idx Then
					Call CF_Set_Item_Focus_Ctl(False, pm_All.Dsp_Sub_Inf(Index_Wk))
				End If
			End If
			
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			
		Next 
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Init_Clr_Dsp_Body
	'   概要：  各画面のボディ項目を初期化
	'   引数：　pm_Bd_Index     :明細行インデックス
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Clr_Dsp_Body(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Index_Bd_Wk As Short
		Dim Wk_Bd_Index_S As Short
		Dim Wk_Bd_Index_E As Short
		Dim Wk_Mode As Short
		Dim Wk_Index As Short
		Dim Wk_Row As Short
		
		If pm_Bd_Index = -1 Then
			Wk_Bd_Index_S = 1
			Wk_Bd_Index_E = pm_All.Dsp_Base.Dsp_Body_Cnt
			
			'画面ボディ情報
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(pm_All.Dsp_Base.Dsp_Body_Cnt)
			
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'        'スクロール初期化
			'        '最大値
			'        Call CF_Set_VScrl_Max(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'        '最小値
			'        Call CF_Set_VScrl_Min(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'        '最大ｽｸﾛｰﾙ量
			'        Call CF_Set_VScrl_LargeChange(pm_All.Dsp_Base.Dsp_Body_Cnt - 1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'        '最小ｽｸﾛｰﾙ量
			'        Call CF_Set_VScrl_SmallChange(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'        '初期値
			'        Call CF_Set_Item_Direct(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			Wk_Mode = BODY_ALL_CLR
		Else
			Wk_Bd_Index_S = pm_Bd_Index
			Wk_Bd_Index_E = pm_Bd_Index
			Wk_Mode = BODY_ALL_ONLY
		End If
		
		For Index_Bd_Wk = Wk_Bd_Index_S To Wk_Bd_Index_E
			
			'共通初期化
			Call CF_Init_Clr_Dsp_Body(Index_Bd_Wk, Wk_Mode, pm_All)
			
			'配列０の初期情報を対象行にコピー
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Init_Row_Inf, pm_All.Dsp_Body_Inf.Row_Inf(Index_Bd_Wk))
			
			'全体初期化の場合
			If Wk_Mode = BODY_ALL_CLR Then
				'全行初期状態
				pm_All.Dsp_Body_Inf.Row_Inf(Index_Bd_Wk).Status = BODY_ROW_STATE_DEFAULT
			End If
			
			'個別初期化
			''Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'        '以下のｺﾝﾄﾛｰﾙは明細部分のｺﾝﾄﾛｰﾙであればなんでもＯＫです
			'        '(対象の明細の番号情報だけが必要、)
			'        Wk_Index = CInt(BD_LINNO(Index_Bd_Wk).Tag)
			''Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			'        'Dsp_Body_Infの行ＮＯに変換
			'        Wk_Row = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
			''Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'        'Dsp_Body_Infに値を初期値を設定
			'        Call F_F_Init_Dsp_Body(Wk_Row, pm_All)
			''Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			
		Next 
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Init_Cursor_Set
	'   概要：  画面初期状態時のフォーカス位置設定
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Cursor_Set(ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
        'delete 20190325 START saiki
        ''Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        ''各画面個別設定(必ずDSP_SUB_INF.Detail.Focus_Ctl=Trueの項目！！)
        ''ダミーにフォーカス設定
        ''割当ｲﾝﾃﾞｯｸｽ取得
        'If pm_All.Dsp_Base.FormCtl.Name = "FR_SSSMAIN" Then
        '	'UPGRADE_ISSUE: Control TX_Dummy は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '	Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.TX_Dummy.Tag)
        'Else
        '	'UPGRADE_ISSUE: Control HD_BMNCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        '	Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_BMNCD.Tag)
        'End If
        'delete 20190325 END saiki
		'ﾌｫｰｶｽ移動
		Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
		'選択状態の設定（初期選択）
		Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
		'項目色設定
		' 2006/12/18  CHG START  KUMEDA
		'    Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
		Call CF_Set_Item_Color_MEISAI(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
		' 2006/12/18  CHG END
		
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
	End Function
	
	'======================= 変更部分 2006.06.26 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_MN_Cmn_DE_Focus
	'   概要：  メニューの明細初期化／明細削除／明細復元時のフォーカス制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_Cmn_DE_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Row As Short, ByRef pm_All As Cls_All) As Boolean
		
		Dim Trg_Index As Short
		Dim Move_Flg As Boolean
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		
		'画面明細の行と同一の明細をインデックスを取得
		Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_Row, pm_All)
		
		If Trg_Index > 0 Then
			If Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) Then
				'移動先が同じ場合
				'選択状態の設定（初期選択）
				Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
				'項目色設定
				Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
				
			Else
				'同一項目の１つ前からENTキー押下と同様に次の項目へ
				Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Trg_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
			End If
			
		Else
			'入力可能な最初のインデックスを取得
			Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Row, pm_All)
			If Focus_Ctl_Ok_Fst_Idx > 0 Then
				'同一項目の１つ前からENTキー押下と同様に次の項目へ
				Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
			End If
		End If
		
	End Function
	'======================= 変更部分 2006.06.26 End =================================
	
	'======================= 変更部分 2006.06.26 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_MN_ClearDE
	'   概要：  メニューの明細初期化の制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_ClearDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Index As Short
		Dim Row_Wk As Short
		
		'画面の内容を退避
		Call CF_Body_Bkup(pm_All)
		
		'Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		'共通の明細初期化
		If CF_Cmn_Ctl_MN_ClearDE(Bd_Index, pm_All) = True Then
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'業務の初期値を編集
			Call F_Init_Dsp_Body(Bd_Index, pm_All)
			
			'行Ｎｏ採番処理
			Call F_Edi_Saiban_No(pm_All)
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			
			'画面表示
			Call CF_Body_Dsp(pm_All)
			
			'元の画面の行に移動
			Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index
			
			'フォーカス決定
			Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
			
		End If
		
	End Function
	'======================= 変更部分 2006.06.26 End =================================
	
	'======================= 変更部分 2006.06.26 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_MN_DeleteDE
	'   概要：  メニューの明細削除の制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_DeleteDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Index As Short
		Dim Row_Inf_Max_S As Short
		Dim Row_Inf_Max_E As Short
		Dim Bd_Index_Wk As Short
		Dim Row_Wk As Short
		
		'画面の内容を退避
		Call CF_Body_Bkup(pm_All)
		
		'Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		'共通の明細削除
		Call CF_Cmn_Ctl_MN_DeleteDE(Bd_Index, pm_All, Row_Inf_Max_S, Row_Inf_Max_E)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'行を追加された後に
		'初期値を追加した行に対してループ内で１行ずつ行う
		'ここでの行は、Dsp_Body_Infの行！！
		For Bd_Index_Wk = Row_Inf_Max_S To Row_Inf_Max_E
			Call F_Init_Dsp_Body(Bd_Index_Wk, pm_All)
		Next 
		
		'行Ｎｏ採番処理
		Call F_Edi_Saiban_No(pm_All)
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'画面表示
		Call CF_Body_Dsp(pm_All)
		
		'元の画面の行に移動
		Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index
		
		'フォーカス決定
		Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
		
	End Function
	'======================= 変更部分 2006.06.26 End =================================
	
	'======================= 変更部分 2006.06.26 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_MN_InsertDE
	'   概要：  メニューの明細挿入の制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_InsertDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Index As Short
		Dim Bd_Index_Wk As Short
		Dim Ins_Bd_Index As Short
		Dim Row_Wk As Short
		
		'画面の内容を退避
		Call CF_Body_Bkup(pm_All)
		
		'Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		'共通の明細挿入
		If CF_Cmn_Ctl_MN_InsertDE(Bd_Index, Ins_Bd_Index, pm_All) = True Then
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'業務の初期値を編集
			Call F_Init_Dsp_Body(Ins_Bd_Index, pm_All)
			
			'行Ｎｏ採番処理
			Call F_Edi_Saiban_No(pm_All)
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			
			'対象行を画面に表示
			Call CF_Body_Dsp_Trg_Row(pm_All, Ins_Bd_Index)
			
			'追加行に移動
			Row_Wk = CF_Idx_To_Bd_Idx(Ins_Bd_Index, pm_All)
			
			'フォーカス決定
			Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
			
		End If
		
	End Function
	'======================= 変更部分 2006.06.26 End =================================
	
	'======================= 変更部分 2006.06.26 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_MN_UnDoDe
	'   概要：  メニューの明細復元の制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_UnDoDe(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Index As Short
		Dim Row_Inf_Max_S As Short
		Dim Row_Inf_Max_E As Short
		Dim Bd_Index_Wk As Short
		Dim Row_Wk As Short
		
		'画面の内容を退避
		Call CF_Body_Bkup(pm_All)
		
		'Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		'共通の明細復元
		If CF_Cmn_Ctl_MN_UnDoDe(pm_All, Row_Inf_Max_S, Row_Inf_Max_E) = True Then
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'行を追加された後に
			'初期値を追加した行に対してループ内で１行ずつ行う
			'ここでの行は、Dsp_Body_Infの行！！
			For Bd_Index_Wk = Row_Inf_Max_S To Row_Inf_Max_E
				Call F_Init_Dsp_Body(Bd_Index_Wk, pm_All)
			Next 
			
			'行Ｎｏ採番処理
			Call F_Edi_Saiban_No(pm_All)
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			
			'画面表示
			Call CF_Body_Dsp(pm_All)
			
			'元の画面の行に移動
			Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index
			
			'フォーカス決定
			Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
			
		End If
		
	End Function
	'======================= 変更部分 2006.06.26 Start =================================
	
	'======================= 変更部分 2006.07.02 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_MN_Paste
	'   概要：  貼り付け
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_Paste(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Clip_Value As String
		Dim Paste_Value As String
		
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Wk_SelStart As Short
		Dim Wk_SelLength As Short
		Dim Wk_EditMoji As String
		Dim Wk_CurMoji As String
		Dim Wk_DspMoji As String
		
		'ｸﾘｯﾌﾟﾎﾞｰﾄﾞから内容取得
		'UPGRADE_ISSUE: Clipboard メソッド Clipboard.GetText はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
		Clip_Value = My.Computer.Clipboard.GetText()
		'入力文字可能を取り出す
		Paste_Value = CF_Get_Input_Ok_Item(Clip_Value, pm_Dsp_Sub_Inf)
		
		'貼り付け内容がない場合、処理中断
		If Paste_Value = "" Then
			Exit Function
		End If
        'change 20190725 START hou
        '      '現在のﾃｷｽﾄ上の選択状態を取得
        '      'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '      Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
        Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
        Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
        '      'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '      Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
        Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
        'change 20190725 END hou
        Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
		'現在の値を取得
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Wk_CurMoji = CF_Get_Input_Ok_Item(CF_Get_Item_Value(pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf)
		
		If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
			'詰文字が左詰の場合
			
			'文字編集
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Wk_EditMoji = CF_Cnv_Dsp_Item(Paste_Value, pm_Dsp_Sub_Inf, False)
			
			'編集後のSelStartを決定
			'右端へ移動
			Wk_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
			Wk_SelLength = 0
		Else
			'詰文字が左詰以外の場合
			
			If Act_SelLength = 0 Then
				'選択なしの場合(挿入状態)
				'文字編集
				Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Paste_Value & Mid(Wk_CurMoji, Act_SelStart + 1)
			Else
				'一部選択
				If Act_SelLength >= 2 Then
					'２文字以上選択している場合は
					'選択文字より後ろの文字もつける
					'文字編集
					Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Paste_Value & Mid(Wk_CurMoji, Act_SelStart + Act_SelLength + 1)
				Else
					'１文字以下選択している場合は
					'選択文字以降は入れ換え
					'文字編集
					Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Paste_Value
					
				End If
				
			End If
			
			'編集後のSelStartを決定
			'左端へ移動
			Wk_SelStart = 0
			Wk_SelLength = 1
			
		End If
		
		Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
			Case IN_TYP_DATE
				'日付の場合、入力形式が決まっている場合
				'日付入力形式の桁数だけ取得
				Wk_EditMoji = Left(Wk_EditMoji, Len(IN_FMT_DATE))
			Case IN_TYP_YYYYMM
				'年月の場合、入力形式が決まっている場合
				'日付入力形式の桁数だけ取得
				Wk_EditMoji = Left(Wk_EditMoji, Len(IN_FMT_YYYMM))
			Case IN_TYP_HHMM
				'時刻の場合、入力形式が決まっている場合
				'日付入力形式の桁数だけ取得
				Wk_EditMoji = Left(Wk_EditMoji, Len(IN_FMT_HHMM))
			Case Else
				
		End Select
		
		'編集後の文字を表示形式に変換
		'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, False)
		
		'ﾁｪﾝｼﾞｲﾍﾞﾝﾄを起こさずに編集
		Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
        'change start 20190805 kuwahara
        '編集後のSelStartを決定
        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
        ''編集後のSelLengthを決定
        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
        'change end 20190805 kuwahara
        '明細入力後の後処理
        Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
	End Function
	'======================= 変更部分 2006.07.02 End =================================
	
	'======================= 変更部分 2006.06.26 Start =================================
	'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Edi_Saiban_No
	'   概要：  全明細の行ＮＯを設定する
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Edi_Saiban_No(ByRef pm_All As Cls_All) As Short
		Dim Wk_Index As Short
		Dim Bd_Index As Short
		
		
	End Function
	'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
	'======================= 変更部分 2006.06.26 End =================================
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_WLS_Close
	'   概要：  各検索画面クローズ処理
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_WLS_Close() As Short
		
		F_Ctl_WLS_Close = 9
		
		'名称
		WLS_MEI4.Close()
		'UPGRADE_NOTE: オブジェクト WLS_MEI4 をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
		WLS_MEI4 = Nothing
		
		F_Ctl_WLS_Close = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_Hardcopy_SSSMAIN
	'   概要：  ハードコピー画面呼出し後処理
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Hardcopy_SSSMAIN(ByRef pm_All As Cls_All) As Short 'Generated.
		If AE_MsgLibrary(PP_SSSMAIN, "Hardcopy") Then AE_Hardcopy_SSSMAIN = Cn_CuCurrent : Exit Function
		On Error Resume Next
		System.Windows.Forms.Application.DoEvents()
		pm_All.Dsp_Base.FormCtl.Cursor = System.Windows.Forms.Cursors.WaitCursor
		'UPGRADE_ISSUE: Form メソッド Dsp_Base.FormCtl.PrintForm はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        'delete 20190325 START saiki
        'pm_All.Dsp_Base.FormCtl.PrintForm()
        'delete 20190325 END saiki
		pm_All.Dsp_Base.FormCtl.Cursor = System.Windows.Forms.Cursors.Arrow
		If Err.Number <> 0 Then
			If AE_MsgLibrary(PP_SSSMAIN, "HardcopyError") Then AE_Hardcopy_SSSMAIN = Cn_CuCurrent : Exit Function
		End If
		On Error GoTo 0
		AE_Hardcopy_SSSMAIN = Cn_CuCurrent
	End Function
	
	'□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□
	
	' 2007/01/18  ADD START  KUMEDA
	Public Function setSELECTB(ByRef pINDEX As Short, ByRef pm_All As Cls_All) As Object
		Dim Data_Row As Short
		Dim Index_Cnt As Short
		
		For Index_Cnt = 1 To pm_All.Dsp_Base.Dsp_Body_Cnt * MaxPageNum
			pm_All.Dsp_Body_Inf.Row_Inf(Index_Cnt).Bus_Inf.Selected = CStr(False)
		Next Index_Cnt
		
		Data_Row = (NowPageNum - 1) * pm_All.Dsp_Base.Dsp_Body_Cnt + pINDEX
		pm_All.Dsp_Body_Inf.Row_Inf(Data_Row).Bus_Inf.Selected = CStr(True)
		
	End Function
	'2007/01/18  ADD END
    'delete 20190325 START saiki
    ''ADD 20150710 START C2-20150708-01
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ''   名称：  Sub F_Ctl_LAB_EXC
    ''   概要：  ジョブ実行中メッセージ制御
    ''   引数：  pm_all              :全構造体
    ''   戻値：　なし
    ''   備考：
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Public Sub F_Ctl_LAB_EXC(ByRef pm_All As Cls_All)

    '	Dim intRet As Short
    '	Dim strMsg As String

    '	'排他チェック
    '       intRet = AE_Execute_PLSQL_EXCTBZ("C", strMsg)

    '       Select Case intRet
    '           Case 0
    '               '排他なし
    '               'UPGRADE_ISSUE: Control lab_exc は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
    '               pm_All.Dsp_Base.FormCtl.lab_exc.Visible = False
    '           Case 1
    '               '排他エラー
    '               'UPGRADE_ISSUE: Control lab_exc は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
    '               pm_All.Dsp_Base.FormCtl.lab_exc.Visible = True
    '           Case Else
    '               '異常終了
    '               MsgBox("排他チェック処理エラー：" & strMsg, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, SSS_PrgNm)
    '               End
    '       End Select


    'End Sub
    'ADD 20150710 END C2-20150708-01
    'delete 20190325 END saiki
End Module