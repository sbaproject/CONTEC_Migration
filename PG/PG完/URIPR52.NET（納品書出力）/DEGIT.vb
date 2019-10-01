Option Strict Off
Option Explicit On
Module DEGIT_O51
	'
	'スロット名      :チェックデジット付加 共通ユニット・オプショナルスロット
	'ユニット名      :DEGIT.O51
	'記述者          :Standard Library
	'作成日付        :2006/10/26
	'使用プログラム  :
	'
	Function GET_DEGIT(ByVal pOrgNo As String, Optional ByVal pStatCode As String = "", Optional ByVal pStopCode As String = "") As String
		
		''''Dim strAry(102)     As String
		''''Dim lngCode128      As Long
		''''Dim lngI            As Long
		''''Dim lngJ            As Long
		''''Dim strChar         As String
		''''Dim strDegit        As String
		''''Dim strOrgNo        As String
		''''
		''''strOrgNo = Trim(pOrgNo)
		''''
		''''strAry(0) = " "
		''''strAry(1) = "!"
		''''strAry(2) = """"
		''''strAry(3) = "#"
		''''strAry(4) = "$"
		''''strAry(5) = "%"
		''''strAry(6) = "&"
		''''strAry(7) = "'"
		''''strAry(8) = "("
		''''strAry(9) = ")"
		''''
		''''strAry(10) = "*"
		''''strAry(11) = "+"
		''''strAry(12) = ","
		''''strAry(13) = "-"
		''''strAry(14) = "."
		''''strAry(15) = "/"
		''''strAry(16) = "0"
		''''strAry(17) = "1"
		''''strAry(18) = "2"
		''''strAry(19) = "3"
		''''
		''''strAry(20) = "4"
		''''strAry(21) = "5"
		''''strAry(22) = "6"
		''''strAry(23) = "7"
		''''strAry(24) = "8"
		''''strAry(25) = "9"
		''''strAry(26) = ":"
		''''strAry(27) = ";"
		''''strAry(28) = "<"
		''''strAry(29) = "="
		''''
		''''strAry(30) = ">"
		''''strAry(31) = "?"
		''''strAry(32) = "@"
		''''strAry(33) = "A"
		''''strAry(34) = "B"
		''''strAry(35) = "C"
		''''strAry(36) = "D"
		''''strAry(37) = "E"
		''''strAry(38) = "F"
		''''strAry(39) = "G"
		''''
		''''strAry(40) = "H"
		''''strAry(41) = "I"
		''''strAry(42) = "J"
		''''strAry(43) = "K"
		''''strAry(44) = "L"
		''''strAry(45) = "M"
		''''strAry(46) = "N"
		''''strAry(47) = "O"
		''''strAry(48) = "P"
		''''strAry(49) = "Q"
		''''
		''''strAry(50) = "R"
		''''strAry(51) = "S"
		''''strAry(52) = "T"
		''''strAry(53) = "U"
		''''strAry(54) = "V"
		''''strAry(55) = "W"
		''''strAry(56) = "X"
		''''strAry(57) = "Y"
		''''strAry(58) = "Z"
		''''strAry(59) = "["
		''''
		''''strAry(60) = "\"
		''''strAry(61) = "]"
		''''strAry(62) = "^"
		''''strAry(63) = "_"
		''''strAry(64) = """"
		''''strAry(65) = "a"
		''''strAry(66) = "b"
		''''strAry(67) = "c"
		''''strAry(68) = "d"
		''''strAry(69) = "e"
		''''
		''''strAry(70) = "f"
		''''strAry(71) = "g"
		''''strAry(72) = "h"
		''''strAry(73) = "i"
		''''strAry(74) = "j"
		''''strAry(75) = "k"
		''''strAry(76) = "l"
		''''strAry(77) = "m"
		''''strAry(78) = "n"
		''''strAry(79) = "o"
		''''
		''''strAry(80) = "p"
		''''strAry(81) = "q"
		''''strAry(82) = "r"
		''''strAry(83) = "s"
		''''strAry(84) = "t"
		''''strAry(85) = "u"
		''''strAry(86) = "v"
		''''strAry(87) = "w"
		''''strAry(88) = "x"
		''''strAry(89) = "y"
		''''
		''''strAry(90) = "z"
		''''strAry(91) = "{"
		''''strAry(92) = "|"
		''''strAry(93) = "}"
		''''strAry(94) = "~"
		''''strAry(95) = "DEL"
		''''strAry(96) = "FNC3"
		''''strAry(97) = "FNC2"
		''''strAry(98) = "SHIFT"
		''''strAry(99) = "CODEC"
		''''
		''''strAry(100) = "FNC4"
		''''strAry(101) = "CODEA"
		''''strAry(102) = "FNC1"
		''''
		''''lngCode128 = 104
		''''
		''''For lngI = 1 To Len(strOrgNo)
		''''    strChar = Mid(strOrgNo, lngI, 1)
		''''    For lngJ = 1 To UBound(strAry)
		''''        If strChar = strAry(lngJ) Then
		''''            lngCode128 = lngCode128 + (lngJ * lngI)
		''''            Exit For
		''''        End If
		''''    Next
		''''Next
		''''
		''''strDegit = strAry(lngCode128 Mod 103)
		''''
		''''GET_DEGIT = pStatCode & Trim(strOrgNo) & strDegit & pStopCode
		GET_DEGIT = pOrgNo
		
	End Function
End Module