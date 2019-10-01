Option Strict Off
Option Explicit On
Module HINFP61_IEV
	
	Public Const SSS_MAX_DB As Short = 20
	Public DB_PARA(SSS_MAX_DB) As TYPE_DB_PARA
	Public Const SSS_PrgId As String = "HINFP61"
	Public Const SSS_PrgNm As String = "商品マスタ一括抽出            "
	Public Const SSS_FraId As String = "ET1"
	
	Sub Init_Fil() 'Generated.
	End Sub
	
	Sub SetBuf(ByVal Fno As Short) 'Generated.
	End Sub
	
	Sub ResetBuf(ByVal Fno As Short) 'Generated.
	End Sub
	
	Function RecordFromObject(ByVal Fno As Short) As Short 'Generated.
	End Function
	
	Function ObjectFromRecord(ByVal Fno As Short) As Short 'Generated.
	End Function
End Module