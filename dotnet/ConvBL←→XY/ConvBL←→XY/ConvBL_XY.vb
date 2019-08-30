''' <summary>
''' BLとXYの相互変換ライブラリ
''' </summary>
''' <remarks></remarks>
Public Class ConvBL_XY

    Const PI# = 3.14159265358979    'π(パイ)
    Const RD# = PI / 180            'ラジアン/度
    Const M0# = 0.9999              '座標系原点における縮尺係数

    '世界測地系
    Const PA# = 6378137             ' A 長半径
    Const PF# = 298.257222101       ' F "逆"扁平率 (F=1/f)
    Const PE1# = (2 * PF - 1) ^ (1 / 2) / PF                'e1 第一離心率
    Const PE2# = (2 * PF - 1) ^ (1 / 2) / (PF - 1)          'e2 第二離心率

    '日本測地系
    Const PA_J# = 6377397.155       ' A 長半径
    Const PF_J# = 299.152813        ' F "逆"扁平率 (F=1/f)
    Const PE1_J# = (2 * PF_J - 1) ^ (1 / 2) / PF_J          'e1 第一離心率
    Const PE2_J# = (2 * PF_J - 1) ^ (1 / 2) / (PF_J - 1)    'e2 第二離心率


    '----------------------------------------------------------
    ' 内部処理用関数 (諸公式と値取得)
    '----------------------------------------------------------
    'A 長半径
    Private Function getA(ByVal jp As Boolean) As Double
        If jp Then getA = PA_J Else getA = PA
    End Function

    'F 地球の逆扁平率
    Private Function getF(ByVal jp As Boolean) As Double
        If jp Then getF = PF_J Else getF = PF
    End Function

    'e1 第一離心率
    Private Function getE1(ByVal jp As Boolean) As Double
        If jp Then getE1 = PE1_J Else getE1 = PE1
    End Function

    'e2 第二離心率
    Private Function getE2(ByVal jp As Boolean) As Double
        If jp Then getE2 = PE2_J Else getE2 = PE2
    End Function

    'N 卯酉線曲率半径 (N = a/W)
    Private Function getRN(r1#, ByVal jp As Boolean) As Double
        getRN = getA(jp) / (1 - getE1(jp) ^ 2 * Math.Sin(r1) ^ 2) ^ (1 / 2)
    End Function

    'M 子午線曲率半径 (M = a*(1-e1^2)/W^3)
    Private Function getRM(r1#, ByVal jp As Boolean) As Double
        Dim e1#
        e1 = getE1(jp)
        getRM = getA(jp) * (1 - e1 ^ 2) / (1 - e1 ^ 2 * Math.Sin(r1) ^ 2) ^ (3 / 2)
    End Function

    'S 赤道から緯度までの子午線弧長計算
    Private Function getL(r1#, ByVal jp As Boolean) As Double
        Dim a#, e1#, la#, lb#, lc#, ld#, le#, lf#, lg#, lh#, li#
        Dim b1#, b2#, b3#, b4#, b5#, b6#, b7#, b8#, b9#

        e1 = getE1(jp)
        a = getA(jp)

        li = 765765 / 7516192768.0# * e1 ^ 16
        lh = 45045 / 117440512 * e1 ^ 14 + 765765 / 469762048 * e1 ^ 16
        lg = 3003 / 2097152 * e1 ^ 12 + 315315 / 58720256 * e1 ^ 14 + 11486475 / 939524096 * e1 ^ 16
        lf = 693 / 131072 * e1 ^ 10 + 9009 / 524288 * e1 ^ 12 + 4099095 / 117440512 * e1 ^ 14 + 26801775 / 469762048 * e1 ^ 16
        le = 315 / 16384 * e1 ^ 8 + 3465 / 65536 * e1 ^ 10 + 99099 / 1048576 * e1 ^ 12 + 4099095 / 29360128 * e1 ^ 14 + 348423075 / 1879048192 * e1 ^ 16
        ld = 35 / 512 * e1 ^ 6 + 315 / 2048 * e1 ^ 8 + 31185 / 131072 * e1 ^ 10 + 165165 / 524288 * e1 ^ 12 + 45090045 / 117440512 * e1 ^ 14 + 209053845 / 469762048 * e1 ^ 16
        lc = 15 / 64 * e1 ^ 4 + 105 / 256 * e1 ^ 6 + 2205 / 4096 * e1 ^ 8 + 10395 / 16384 * e1 ^ 10 + 1486485 / 2097152 * e1 ^ 12 + 45090045 / 58720256 * e1 ^ 14 + 766530765 / 939524096 * e1 ^ 16
        lb = 3 / 4 * e1 ^ 2 + 15 / 16 * e1 ^ 4 + 525 / 512 * e1 ^ 6 + 2205 / 2048 * e1 ^ 8 + 72765 / 65536 * e1 ^ 10 + 297297 / 262144 * e1 ^ 12 + 135270135 / 117440512 * e1 ^ 14 + 547521975 / 469762048 * e1 ^ 16
        la = 1 + 3 / 4 * e1 ^ 2 + 45 / 64 * e1 ^ 4 + 175 / 256 * e1 ^ 6 + 11025 / 16384 * e1 ^ 8 + 43659 / 65536 * e1 ^ 10 + 693693 / 1048576 * e1 ^ 12 + 19324305 / 29360128 * e1 ^ 14 + 4927697775.0# / 7516192768.0# * e1 ^ 16

        b1 = a * (1 - e1 ^ 2) * la
        b2 = a * (1 - e1 ^ 2) * (-lb / 2)
        b3 = a * (1 - e1 ^ 2) * (lc / 4)
        b4 = a * (1 - e1 ^ 2) * (-ld / 6)
        b5 = a * (1 - e1 ^ 2) * (le / 8)
        b6 = a * (1 - e1 ^ 2) * (-lf / 10)
        b7 = a * (1 - e1 ^ 2) * (lg / 12)
        b8 = a * (1 - e1 ^ 2) * (-lh / 14)
        b9 = a * (1 - e1 ^ 2) * (li / 16)

        getL = b1 * r1 + b2 * Math.Sin(2 * r1) + b3 * Math.Sin(4 * r1) + b4 * Math.Sin(6 * r1) + b5 * Math.Sin(8 * r1) + b6 * Math.Sin(10 * r1) + b7 * Math.Sin(12 * r1) + b8 * Math.Sin(14 * r1) + b9 * Math.Sin(16 * r1)
    End Function

    '座標系原点 (lm:= 1緯度,2経度)
    Private Function getJgd(ByVal no%, ByVal lm%)

        Dim ret As Object = Nothing

        If lm = 1 Then      '緯度
            Select Case no
                Case Is = 1 : ret = 33 * RD
                Case Is = 2 : ret = 33 * RD
                Case Is = 3 : ret = 36 * RD
                Case Is = 4 : ret = 33 * RD
                Case Is = 5 : ret = 36 * RD
                Case Is = 6 : ret = 36 * RD
                Case Is = 7 : ret = 36 * RD
                Case Is = 8 : ret = 36 * RD
                Case Is = 9 : ret = 36 * RD
                Case Is = 10 : ret = 40 * RD
                Case Is = 11 : ret = 44 * RD
                Case Is = 12 : ret = 44 * RD
                Case Is = 13 : ret = 44 * RD
                Case Is = 14 : ret = 26 * RD
                Case Is = 15 : ret = 26 * RD
                Case Is = 16 : ret = 26 * RD
                Case Is = 17 : ret = 26 * RD
                Case Is = 18 : ret = 20 * RD
                Case Is = 19 : ret = 26 * RD
            End Select

        ElseIf lm = 2 Then  '経度
            Select Case no
                Case Is = 1 : ret = (129 + 30 / 60) * RD
                Case Is = 2 : ret = 131 * RD
                Case Is = 3 : ret = (132 + 10 / 60) * RD
                Case Is = 4 : ret = (133 + 30 / 60) * RD
                Case Is = 5 : ret = (134 + 20 / 60) * RD
                Case Is = 6 : ret = 136 * RD
                Case Is = 7 : ret = (137 + 10 / 60) * RD
                Case Is = 8 : ret = (138 + 30 / 60) * RD
                Case Is = 9 : ret = (139 + 50 / 60) * RD
                Case Is = 10 : ret = (140 + 50 / 60) * RD
                Case Is = 11 : ret = (140 + 15 / 60) * RD
                Case Is = 12 : ret = (142 + 15 / 60) * RD
                Case Is = 13 : ret = (144 + 15 / 60) * RD
                Case Is = 14 : ret = 142 * RD
                Case Is = 15 : ret = (127 + 30 / 60) * RD
                Case Is = 16 : ret = 124 * RD
                Case Is = 17 : ret = 131 * RD
                Case Is = 18 : ret = 136 * RD
                Case Is = 19 : ret = 154 * RD
            End Select

        Else                '説明
            Select Case no
                Case Is = 1 : getJgd = "長崎県、鹿児島県"
                Case Is = 2 : getJgd = "福岡県、佐賀県、熊本県、大分県、宮崎県、鹿児島県"
                Case Is = 3 : getJgd = "山口県、島根県、広島県"
                Case Is = 4 : getJgd = "香川県、愛媛県、徳島県、高知県"
                Case Is = 5 : getJgd = "兵庫県、鳥取県、岡山県"
                Case Is = 6 : getJgd = "京都府、大阪府、福井県、滋賀県、三重県、和歌山県"
                Case Is = 7 : getJgd = "石川県、富山県、岐阜県、愛知県"
                Case Is = 8 : getJgd = "新潟県、長野県、山梨県、静岡県"
                Case Is = 9 : getJgd = "東京都、福島県、栃木県、茨城県、千葉県、群馬県、神奈川県"
                Case Is = 10 : getJgd = "青森県、秋田県、山形県、岩手県、宮城県"
                Case Is = 11 : getJgd = "北海道（小樽市、函館市他）"
                Case Is = 12 : getJgd = "北海道（札幌、旭川市他）"
                Case Is = 13 : getJgd = "北海道（北見市、帯広市他）"
                Case Is = 14 : getJgd = "東京都（北緯２８度から南）"
                Case Is = 15 : getJgd = "沖縄県（東経１２６度より東）"
                Case Is = 16 : getJgd = "沖縄県（東経１２６度より西）"
                Case Is = 17 : getJgd = "沖縄県（東経１３０度より東）"
                Case Is = 18 : getJgd = "東京都（北緯２８度から南、１４０度３０分より西）"
                Case Is = 19 : getJgd = "東京都（北緯２８度から南、１４３度より東）"
            End Select

        End If

        Return ret

    End Function


    '----------------------------------------------------------
    ' フォーマット変換
    '----------------------------------------------------------
    'ラジアンを度に変換
    ''' <summary>
    ''' ラジアンを度に変換
    ''' </summary>
    ''' <param name="r">ラジアン</param>
    ''' <returns>度</returns>
    ''' <remarks></remarks>
    Private Function Apg_rad2deg(ByVal r#) As Double
        Apg_rad2deg = r / RD
    End Function

    '度(分秒)をラジアンに変換
    ''' <summary>
    ''' 度(分秒)をラジアンに変換
    ''' </summary>
    ''' <param name="d">度</param>
    ''' <returns>ラジアン</returns>
    ''' <remarks></remarks>
    Private Function Apg_deg2rad(ByVal d#) As Double
        Apg_deg2rad = d * RD
    End Function

    'dd.ddからddmmss.ss形式に変換
    'div:= 区切り文字 (省略可) dig:= 小数点以下の桁数 (省略時2)
    ''' <summary>
    ''' dd.ddからddmmss.ss形式に変換
    ''' </summary>
    ''' <param name="d">dd.dd</param>
    ''' <param name="div">区切り文字</param>
    ''' <param name="dig">桁数</param>
    ''' <returns>ddmmss.ss</returns>
    ''' <remarks></remarks>
    Function Apg_deg2dms(ByVal d#, ByVal div$, ByVal dig%) As Object
        Dim dd#, mm#, ss#, tmp#, s$
        tmp = d : s = ""
        If d < 0 Then tmp = tmp * -1 : s = "-"
        tmp = ShishaGonew(tmp * 3600, dig)    '先に丸め
        dd = Int(tmp / 3600)
        mm = Int(tmp / 60 - dd * 60)
        ss = tmp - dd * 3600 - mm * 60

        Apg_deg2dms = s & dd & div & Format(mm, "00") & div & Format(ss, "00" & IIf(dig = 0, "", "." & Strings.StrDup(dig, "0")))
    End Function

    'ddmmss.ssからdd.dd形式に変換する
    'div:= 区切り文字 (省略可)
    ''' <summary>
    ''' ddmmss.ssからdd.dd形式に変換する
    ''' </summary>
    ''' <param name="str">ddmmss.ss</param>
    ''' <param name="div">区切り文字</param>
    ''' <returns>dd.dd</returns>
    ''' <remarks></remarks>
    Function Apg_dms2deg(ByVal str$, ByVal div$) As Double
        Dim ret As Double
        Dim n As Integer
        Dim tmp
        Dim a(2)

        tmp = str : n = 1
        If Left(tmp, 1) = "-" Then tmp = Replace(tmp, "-", "", , 1) : n = -1
        If div = "" Then
            tmp = CDbl(tmp)
            a(0) = Int(tmp / 10000)
            a(1) = Int((tmp - a(0) * 10000) / 100)
            a(2) = tmp - a(0) * 10000 - a(1) * 100
        Else
            a = Split(tmp, div)
            If UBound(a) = 3 Then a(2) = a(2) & "." & a(3)
        End If
        ret = (Val(a(0)) + Val(a(1)) / 60 + Val(a(2)) / 3600) * n

        Apg_dms2deg = ret
    End Function

    ''' <summary>
    ''' ラジアンから度、度分秒に変換
    ''' </summary>
    ''' <param name="val">ラジアン</param>
    ''' <param name="f">1：ラジアンそのまま　2：度　3：度分秒</param>
    ''' <returns>f=1：ラジアンそのまま　2：度　3：度分秒</returns>
    ''' <remarks></remarks>
    Function App_RadTo(ByVal val#, ByVal f%)

        Dim ret As Double

        Select Case f
            Case Is = 1 : ret = val              'ラジアン
            Case Is = 2 : ret = Apg_rad2deg(val) '度
            Case Is = 3 : ret = CDbl(Apg_deg2dms(Apg_rad2deg(val), "", 10))  'dddmmss.ss(数値)
        End Select

        Return ret

    End Function

    ''' <summary>
    ''' 度、度分秒からラジアンに変換
    ''' </summary>
    ''' <param name="val">度（ddd.dd）または　度分秒（dddmmss.ss）</param>
    ''' <param name="f">入力が1：ラジアンそのまま　2：度　3：度分秒</param>
    ''' <returns>ラジアン</returns>
    ''' <remarks></remarks>
    Function App_ToRad(ByVal val#, ByVal f%)

        Dim ret#

        Select Case f
            Case Is = 1 : ret = val              'ラジアン
            Case Is = 2 : ret = Apg_deg2rad(val) '度
            Case Is = 3 : ret = Apg_deg2rad(Apg_dms2deg(val, ""))    'dddmmss.ss
        End Select

        Return ret

    End Function
    '----------------------------------------------------------
    ' 座標変換
    '----------------------------------------------------------
    '緯経度(ラジアン)をXY座標に変換
    ''' <summary>
    ''' 緯経度(ラジアン)をXY座標に変換
    ''' </summary>
    ''' <param name="r1">求点緯度（rad）</param>
    ''' <param name="r2">求点経度（rad）</param>
    ''' <param name="r1_0">原点緯度（rad）</param>
    ''' <param name="r2_0">原点経度（rad）</param>
    ''' <param name="x">求点Xが格納されます</param>
    ''' <param name="y">求点Yが格納されます</param>
    ''' <param name="jp">世界測地系：False　日本測地系：True</param>
    ''' <remarks></remarks>
    Sub Apg_rad2xy(ByVal r1#, ByVal r2#, ByVal r1_0#, ByVal r2_0#, ByRef x#, ByRef y#, ByVal jp As Boolean)
        Dim ls#, ln#, cd#, td#, n2#, r2_d#, e2#
        Dim x1#, x2#, x3#, x4#, y1#, y2#, y3#, y4#

        '定数
        e2 = getE2(jp)

        '赤道から緯度までの子午線弧長計算
        ls = getL(r1, jp) - getL(r1_0, jp)
        ln = getRN(r1, jp)

        '座標計算
        r2_d = r2 - r2_0
        td = Math.Tan(r1)
        cd = Math.Cos(r1)
        n2 = e2 ^ 2 * cd ^ 2

        x1 = ls + 1 / 2 * ln * cd ^ 2 * td * r2_d ^ 2
        x2 = 1 / 24 * ln * cd ^ 4 * td * (5 - td ^ 2 + 9 * n2 + 4 * n2 ^ 2) * r2_d ^ 4
        x3 = -1 / 720 * ln * cd ^ 6 * td * (-61 + 58 * td ^ 2 - td ^ 4 - 270 * n2 + 330 * td ^ 2 * n2) * r2_d ^ 6
        x4 = -1 / 40320 * ln * cd ^ 8 * td * (-1385 + 3111 * td ^ 2 - 543 * td ^ 4 + td ^ 6) * r2_d ^ 8
        x = (x1 + x2 + x3 + x4) * M0

        y1 = ln * cd * r2_d
        y2 = -1 / 6 * ln * cd ^ 3 * (-1 + td ^ 2 - n2) * r2_d ^ 3
        y3 = -1 / 120 * ln * cd ^ 5 * (-5 + 18 * td ^ 2 - td ^ 4 - 14 * n2 + 58 * td ^ 2 * n2) * r2_d ^ 5
        y4 = -1 / 5040 * ln * cd ^ 7 * (-61 + 479 * td ^ 2 - 179 * td ^ 4 + td ^ 6) * r2_d ^ 7
        y = (y1 + y2 + y3 + y4) * M0

    End Sub

    'XY座標を緯経度(ラジアン)に変換
    ''' <summary>
    ''' XY座標を緯経度(ラジアン)に変換
    ''' </summary>
    ''' <param name="x">求点X</param>
    ''' <param name="y">求点Y</param>
    ''' <param name="r1_0">原点緯度（rad）</param>
    ''' <param name="r2_0">原点経度（rad）</param>
    ''' <param name="r1">求点緯度（rad）が格納されます</param>
    ''' <param name="r2">求点経度（rad）が格納されます</param>
    ''' <param name="jp">世界測地系：False　日本測地系：True</param>
    ''' <remarks></remarks>
    Sub Apg_xy2rad(ByVal x#, ByVal y#, ByVal r1_0#, ByVal r2_0#, ByRef r1#, ByRef r2#, ByVal jp As Boolean)

        Dim aa#, e1#, e2#
        Dim xr#, xm#, xs#, xa#, xb#, i%
        Dim zn#, zt#, zz#, zr1#, zr2#
        'Dim xr0#, xe#

        '定数
        aa = getA(jp)
        e1 = getE1(jp)
        e2 = getE2(jp)

        '子午線弧長からの緯度計算
        xm = getL(r1_0, jp) + x / M0
        xr = r1_0                           '初回は原点緯度を代入
        'xe = deg2rad(0, 0, (2 / 100000))    '反復チェック

        For i = 0 To 20
            xs = getL(xr, jp)   '赤道からの子午線弧長
            xa = 2 * (xs - xm) * (1 - e1 ^ 2 * Math.Sin(xr) ^ 2) ^ (3 / 2)
            xb = 3 * e1 ^ 2 * (xs - xm) * Math.Sin(xr) * Math.Cos(xr) * (1 - e1 ^ 2 * Math.Sin(xr) ^ 2) ^ (1 / 2) - 2 * aa * (1 - e1 ^ 2)
            xr = xr + xa / xb
            'If Abs(xr - xr0) < xe Then Exit For
            'xr0 = xr
        Next

        '緯経度の算出
        zn = getRN(xr, jp)
        zt = Math.Tan(xr)
        zz = e2 ^ 2 * Math.Cos(xr) ^ 2

        zr1 = xr - (1 / 2 / zn ^ 2 * zt * (1 + zz) * (y / M0) ^ 2)
        zr1 = zr1 + 1 / 24 / zn ^ 4 * zt * (5 + 3 * zt ^ 2 + 6 * zz - 6 * zt ^ 2 * zz - 3 * zz ^ 2 - 9 * zt ^ 2 * zz ^ 2) * (y / M0) ^ 4
        zr1 = zr1 - 1 / 720 / zn ^ 6 * zt * (61 + 90 * zt ^ 2 + 45 * zt ^ 4 + 107 * zz - 162 * zt ^ 2 * zz - 45 * zt ^ 4 * zz) * (y / M0) ^ 6
        zr1 = zr1 + 1 / 40320 / zn ^ 8 * zt * (1385 + 3633 * zt ^ 2 + 4095 * zt ^ 4 + 1575 * zt ^ 6) * (y / M0) ^ 8
        zr2 = r2_0 + 1 / zn / Math.Cos(xr) * (y / M0)
        zr2 = zr2 - 1 / 6 / zn ^ 3 / Math.Cos(xr) * (1 + 2 * zt ^ 2 + zz) * (y / M0) ^ 3
        zr2 = zr2 + 1 / 120 / zn ^ 5 / Math.Cos(xr) * (5 + 28 * zt ^ 2 + 24 * zt ^ 4 + 6 * zz + 8 * zt ^ 2 * zz) * (y / M0) ^ 5
        zr2 = zr2 - 1 / 5040 / zn ^ 7 / Math.Cos(xr) * (61 + 662 * zt ^ 2 + 1320 * zt ^ 4 + 720 * zt ^ 6) * (y / M0) ^ 7

        r1 = zr1
        r2 = zr2
    End Sub

    '座標系原点の情報 (opt:= 0説明,1緯度,2経度,3緯経度)
    ''' <summary>
    ''' 座標系原点の情報
    ''' </summary>
    ''' <param name="no">座標系</param>
    ''' <param name="opt">0説明,1緯度,2経度</param>
    ''' <returns>座標系原点の情報(opt = 0：説明,1：緯度,2：経度</returns>
    ''' <remarks></remarks>
    Function Get_GENTEN(ByVal no%, ByVal opt%) As Object
        'If opt = 3 Then

        '    Dim arry As New ArrayList
        '    'Apg_JGD = Array(getJgd(no, 1), getJgd(no, 2))
        '    arry.Add(getJgd(no, 1))
        '    arry.Add(getJgd(no, 2))
        '    Get_GENTEN = arry

        'Else
        Get_GENTEN = getJgd(no, opt)
        'End If
    End Function

    'm 緯度とy座標から縮尺係数を算出
    ''' <summary>
    ''' m 緯度とy座標から縮尺係数を算出
    ''' </summary>
    ''' <param name="r1">緯度（rad）</param>
    ''' <param name="y">Y座標</param>
    ''' <param name="jp">世界測地系：False　日本測地系：True</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Apg_ScaleFactor(ByVal r1#, ByVal y#, ByVal jp As Boolean) As Double
        Dim nm#
        nm = getRN(r1, jp) * getRM(r1, jp)
        Apg_ScaleFactor = M0 * (1 + y ^ 2 / (2 * nm * M0 ^ 2) + y ^ 4 / (24 * nm ^ 2 * M0 ^ 4))
    End Function


    '----------------------------------------------------------
    '互換用
    'Sub PROB_ido_to_xy(ByVal r1#, ByVal r2#, ByVal r1_0#, ByVal r2_0#, x#, y#, ByVal in_no%)
    '    Call Apg_rad2xy(r1, r2, r1_0, r2_0, x, y, False)
    'End Sub

    'Sub PROB_kijyun(r1#, r2#, ByVal i_kijyun%)
    '    r1 = getJgd(i_kijyun, 1)
    '    r2 = getJgd(i_kijyun, 2)
    'End Sub

    ''' <summary>
    ''' 四捨五入します。
    ''' </summary>
    ''' <param name="dValue">丸め対象の倍精度浮動小数点数。</param>
    ''' <param name="iDigits">有効桁数</param>
    ''' <returns>四捨五入された数値。</returns>
    ''' <remarks></remarks>
    Public Shared Function ShishaGonew(ByVal dValue As Double, ByVal iDigits As Integer) As Double
        Dim dCoef As Double = System.Math.Pow(10, iDigits)

        If dValue > 0 Then
            Return System.Math.Floor((dValue * dCoef) + 0.5) / dCoef
        Else
            Return System.Math.Ceiling((dValue * dCoef) - 0.5) / dCoef
        End If
    End Function

End Class
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         