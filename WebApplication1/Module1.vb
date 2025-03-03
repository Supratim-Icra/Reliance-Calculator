
Imports System.IO

Imports NPOI.HSSF.UserModel
Imports NPOI.SS.UserModel
Imports NPOI.SS.Util
Imports NPOI.XSSF.UserModel

''' <summary>
''' Date change to check git conflict management
''' bbbbbbbbbbbbbbbbbbbbb
''' </summary>
Module Module1
    Public Function fmt(ByVal s As String) As String
        s = s.Replace("/", "-")
        Dim sc(2) As String
        If InStr(s, "-") > 0 Then
            s = CDate(s)
            fmt = s
        Else
            sc = Split(s, "/")
            fmt = sc(1) & "/" & sc(0) & "/" & sc(2)
        End If
    End Function

    Public Function SplitCustom(ByVal s As String, ByVal seperatar As Char) As String()
        seperatar = "-"
        Return s.ToString().Split(seperatar)
    End Function

    Public Function SplitDateSTP(ByVal s As Date, ByVal seperatar As Char) As String()
        Dim sc(2) As String
        Dim scRnt(2) As String
        s = Format(CDate(s), "dd/MM/yyyy")
        sc = Split(s, "-")
        scRnt(0) = sc(1)
        scRnt(1) = sc(0)
        scRnt(2) = sc(2)
        Return scRnt
    End Function

    '<System.Runtime.CompilerServices.Extension()> _
    'Public Function CDateSTP(ByVal obj As Expression) As String
    '    Return String.Concat("<strong>", HttpUtility.HtmlEncode(InputValue), "</strong>")
    'End Function

    ''MM dd yyyy to convert dd MM yyyy''
    Public Function CDateSTP(ByVal obj As String) As Date
        Dim objRtn = obj.ToString().Replace("/", "-").Split("-")
        Return CDate(objRtn(1) & "/" & objRtn(0) & "/" & objRtn(2))
    End Function

    Public Function XIRR(ByVal array1_comma_sep, ByVal array2_comma_sep) As String
        Dim ff_arr1() As Date
        Dim ff_arr2() As Double

        Dim sp1 As Object
        Dim sp2 As Object
        Dim j As Integer
        Dim j1 As Integer
        Dim period As Integer
        Dim xirr1, xirr2, xirr3, xirr4, xirr5, xirr6, xirr7, xirr8, xirr10, xirr20 As Double
        Dim xirrsum As Double
        Dim n1
        Dim x1 As Long
        Try

            XIRR = "0"

            If Trim(array1_comma_sep) <> "" And Trim(array2_comma_sep) <> "" Then
                sp1 = Split(array1_comma_sep, ",")
                sp2 = Split(array2_comma_sep, ",")

                j1 = 0
                For j = 0 To UBound(sp1)
                    ''commented on 28 oct 14
                    'sp1(j) = cdates(sp1(j))
                    If IsDate(sp1(j)) And IsNumeric(sp2(j)) Then
                        j1 = j1 + 1
                        ReDim Preserve ff_arr1(j1)
                        ReDim Preserve ff_arr2(j1)

                        ff_arr1(j1 - 1) = sp1(j)
                        ff_arr2(j1 - 1) = sp2(j)
                    End If
                Next
            Else
                Exit Function
            End If

            xirrsum = 0
            xirr4 = 0
            xirr5 = 0
            xirr6 = 0

            For x1 = 0 To UBound(ff_arr1) - 1
                xirrsum = ff_arr2(x1) + xirrsum
            Next

            If xirrsum < 0 Then
                For xirr1 = -99 To 0 Step 0.2
                    xirr20 = 0
                    For xirr10 = 0 To UBound(ff_arr1) - 1
                        'If ff_arr1(xirr10) <> "" Then
                        If xirr10 = 0 Then
                            'n1 = CDate(ff_arr1(xirr10)) - CDate(ff_arr1(0))
                            n1 = Math.Abs(DateDiff(DateInterval.Day, CDate(ff_arr1(xirr10)), CDate(ff_arr1(0))))
                            xirr20 = ff_arr2(xirr10) / (1 + (xirr1 / 100)) ^ (n1 / 365)
                        Else
                            'n1 = CDate(ff_arr1(xirr10)) - CDate(ff_arr1(0))
                            n1 = Math.Abs(DateDiff(DateInterval.Day, CDate(ff_arr1(xirr10)), CDate(ff_arr1(0))))
                            xirr20 = xirr20 + (ff_arr2(xirr10) / (1 + (xirr1 / 100)) ^ (n1 / 365))
                        End If
                        'Else
                        '    Exit For
                        'End If
                    Next

                    xirr4 = xirr20
                    If xirr4 < 0 Then
                        xirr4 = xirr4 * -1
                    End If

                    If xirr1 <> -99 Then
                        If xirr5 > xirr4 Then
                            xirr5 = xirr4
                            xirr6 = xirr1
                        End If
                    Else
                        xirr5 = xirr4
                    End If
                Next
            End If

            If xirrsum > 0 Then
                For xirr1 = 0 To 500 Step 0.5
                    '//ch = ch + 1
                    xirr20 = 0
                    For xirr10 = 0 To UBound(ff_arr1) - 1
                        'If ff_arr1(xirr10) <> "" Then
                        If xirr10 = 0 Then
                            'n1 = CDate(ff_arr1(xirr10)) - CDate(ff_arr1(0))
                            n1 = Math.Abs(DateDiff(DateInterval.Day, CDate(ff_arr1(xirr10)), CDate(ff_arr1(0))))
                            xirr20 = ff_arr2(xirr10) / (1 + (xirr1 / 100)) ^ (n1 / 365)
                        Else
                            'n1 = CDate(ff_arr1(xirr10)) - CDate(ff_arr1(0))
                            n1 = Math.Abs(DateDiff(DateInterval.Day, CDate(ff_arr1(xirr10)), CDate(ff_arr1(0))))
                            xirr20 = xirr20 + (ff_arr2(xirr10) / (1 + (xirr1 / 100)) ^ (n1 / 365))
                        End If
                        'Else
                        '    Exit For
                        'End If
                    Next

                    xirr4 = xirr20
                    If xirr4 < 0 Then
                        xirr4 = xirr4 * -1
                    End If

                    If xirr1 <> 0 Then
                        If xirr5 > xirr4 Then
                            xirr5 = xirr4
                            xirr6 = xirr1
                        End If
                    Else
                        xirr5 = xirr4
                    End If
                Next
            End If

            If xirrsum = 0 Then
                xirr6 = 0
                GoTo z
            End If

            xirr4 = 0
            xirr7 = xirr6 - 0.5
            xirr8 = xirr6 + 0.5

            For xirr1 = xirr7 To xirr8 Step 0.01
                '//ch = ch + 1
                xirr20 = 0
                For xirr10 = 0 To UBound(ff_arr1) - 1
                    'If ff_arr1(xirr10) <> "" Then
                    If xirr10 = 0 Then
                        'n1 = CDate(ff_arr1(xirr10)) - CDate(ff_arr1(0))
                        n1 = Math.Abs(DateDiff(DateInterval.Day, CDate(ff_arr1(xirr10)), CDate(ff_arr1(0))))
                        xirr20 = ff_arr2(xirr10) / (1 + (xirr1 / 100)) ^ (n1 / 365)
                    Else
                        'n1 = CDate(ff_arr1(xirr10)) - CDate(ff_arr1(0))
                        n1 = Math.Abs(DateDiff(DateInterval.Day, CDate(ff_arr1(xirr10)), CDate(ff_arr1(0))))
                        xirr20 = xirr20 + (ff_arr2(xirr10) / (1 + (xirr1 / 100)) ^ (n1 / 365))
                    End If
                    'Else
                    '    Exit For
                    'End If
                Next

                xirr4 = xirr20

                If xirr4 < 0 Then
                    xirr4 = xirr4 * -1
                End If

                If xirr1 <> xirr7 Then
                    If xirr5 > xirr4 Then
                        xirr5 = xirr4
                        xirr6 = xirr1
                    End If
                End If
            Next
z:
            XIRR = xirr6
        Catch e1 As Exception
            'showMsgBox("Problem In XIRR Calculation:" & e1.ToString)
        Finally
        End Try
    End Function

    Public Function cdates(ByVal dt As String) As String 'input dd/MM/yyyy ,  'output: MM/dd/yyyy
        Try
            dt = dt.Replace("-", "/")
            cdates = Split(dt, "/")(1) & "/" & Split(dt, "/")(0) & "/" & Split(dt, "/")(2)
        Catch e1 As Exception
        End Try
    End Function

    Public Function cdatesSql(ByVal dt As String) As String 'input dd-MMM-yyyy ,  'output: dd MMM yyyy
        Try

            cdatesSql = dt.Replace("-", " ")
        Catch e1 As Exception
        End Try
    End Function
    'Public Function cdatesSTP(ByVal dt As String) As String 'input dd/MM/yyyy ,  'output: MM/dd/yyyy
    '    Try
    '        cdatesSTP = Split(dt, "/")(1) & "/" & Split(dt, "/")(0) & "/" & Split(dt, "/")(2)
    '    Catch e1 As Exception
    '    End Try
    'End Function


    Public Sub SaveToExcel_SWP(ByVal Response As HttpResponse, ByVal dgrid As DataGrid, ByVal p1 As String, ByVal p2 As String, ByVal sch As String, ByVal bmark As String, ByVal Notes As String)
        Dim stringWrite As System.IO.StringWriter
        Dim htmlWrite As System.Web.UI.HtmlTextWriter

        Dim stringWrite2 As System.IO.StringWriter
        Dim htmlWrite2 As System.Web.UI.HtmlTextWriter

        Dim Filename As String
        Dim font_Size As Integer = 8
        Dim address1 As String
        Dim Returns As String
        Dim Xirr As String

        Dim imagePath As String
        Dim imagePath1 As String

        Dim Sch_Name As String
        Dim B_Mark As String
        Dim disclaimer As String
        Dim disclaimer1 As String
        disclaimer1 = "Disclaimer :"

        'disclaimer = "Risk factors: The above compilation is not intended as advice. The information therein is furnished without liability for any inaccuracy.This compilation does not entitle any person to any claim in respect of any liability or consequence of anything done, or omitted to be done, by any such person in reliance upon the contents thereof.This is not an offer for invitation for subscriptions to units of Reliance Mutual Fund schemes. For further details please refer to offer document and load structure before investing. Past performance may or may not be sustained in future. Generated by icraonline.com "
        'disclaimer = "NAM India/NIMF/Trustees does not take the responsibility, liability and undertake the authenticity of the figures calculated on the basis of calculator provided herein for calculations towards prospective investments.Developed and Maintained by ICRA Analytics Ltd. The data content provided is obtained from sources considered to be authentic and reliable. However, ICRA Analytics Ltd. is not responsible for any error or inaccuracy or for any losses suffered on account of information."
        disclaimer = "<div style='text-align:justify'>
                    <p class='txt2' style='font-size: 13px; text-align: justify; line-height: 16px;'>Copyright 2017 Nippon India Mutual Fund. All Rights Reserved.<br>

                       Nippon India Mutual Fund does not take the responsibility, liability and undertake the authenticity of the figures calculated on the basis of calculator provided herein for calculations towards prospective investments.Developed and Maintained by ICRA Analytics Limited. The data content provided is obtained from sources considered to be authentic and reliable. However, ICRA Analytics Limited is not responsible for any error or inaccuracy or for any losses suffered on account of information.</p>
                            <p class='txt2' style='font-size: 13px; text-align: justify; line-height: 16px;'>The Calculators/Tools/Planners are designed to assist you in determining the appropriate amount. These Calculators/Tools/Planners alone are not sufficient and should not be used for the development or implementation of an investment strategy. The investor is advised to consult his or her financial advisor prior to arriving at any investment decision.
                                                        </p>
                    </div>"

        If dgrid.Items.Count < 1 Then
            Exit Sub
        End If

        '//data grid formatting before exporting
        dgrid.Font.Name = "Arial"
        dgrid.Font.Size = System.Web.UI.WebControls.FontUnit.Point(8)
        dgrid.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid
        dgrid.HeaderStyle.BackColor = System.Drawing.Color.Red
        dgrid.HeaderStyle.ForeColor = System.Drawing.Color.White
        dgrid.HeaderStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
        dgrid.HeaderStyle.Wrap = False
        dgrid.HeaderStyle.Font.Bold = True
        dgrid.GridLines = GridLines.Both
        dgrid.BorderColor = System.Drawing.Color.LightGray
        dgrid.BorderWidth = New Unit(1, UnitType.Pixel)
        'dgrid.Items(0).Width = New Unit(CDbl(770))

        Filename = "NipponIndiaSWP" & ".xls"

        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=" & Filename)
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.xls"
        stringWrite = New System.IO.StringWriter
        '//write image

        'imagePath = HttpContext.Current.Session("BaseUrl") & "/" & "images/rmf_logo01.gif"
        'imagePath = HttpContext.Current.Server.MapPath("~") & "/" & "images/rmf-logo.gif"
        'imagePath = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "") & "\images\rmf-logo.gif"
        imagePath = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "") & "\images\reliance-mutual-fund.png"

        Response.Write("<img  src='" & imagePath & "' width='410' height='55' border='0'>")
        Response.Write("<br>")
        Response.Write("<br>")

        Sch_Name = "Scheme " & " : " & sch
        B_Mark = "Benchmark Index " & " : " & bmark

        Response.Write("<b><font size='1.5' face='verdana' color='#000000'>" & "" & Sch_Name & "" & " </font></b> ")
        Response.Write("<br>")
        Response.Write("<b><font size='1.5' face='verdana' color='#000000'>" & "" & B_Mark & "" & " </font></b> ")
        Response.Write("<br>")

        ''imagePath1 = "http://localhost/RelianceSIP/images/toplinks01_bg.gif"
        ''Response.Write("<IMG  src='" & imagePath1 & "' width='755' height='20' border='0'>")
        Response.Write("<br>")

        Response.Write("<font size=1 face=Arial>")
        htmlWrite = New HtmlTextWriter(stringWrite)
        dgrid.RenderControl(htmlWrite)
        Response.Write(stringWrite.ToString())


        Response.Write("<br>")
        Returns = "Abs.Return : " & p1
        Xirr = "Yield(Scheme) : " & p2

        Response.Write("<br>")
        'Response.Write("<b><font size=1.5 face=verdana color=#000000>" & "" & Returns & "" & " </font></b> ")
        Response.Write("<b><div width ='600px' style='font-family:Arial; color:black; font-size:14px;'>" & Returns & "</div></b>")
        Response.Write("<br>")
        'Response.Write("<b><font size=1.5 face=verdana color=#000000>" & "" & Xirr & "" & " </font></b> ")
        Response.Write("<b><div width ='600px' style='font-family:Arial; color:black; font-size:14px;'>" & Xirr & "</div></b>")

        '//Vishal to Save chart image in excel'
        ''commented by syed
        'Dim chartImagePath As String
        'If HttpContext.Current.Session("SWP_Chart_Image") <> "" Then
        '    chartImagePath = HttpContext.Current.Session("BaseUrl") & "/" & "WebCharts/" & HttpContext.Current.Session("SWP_Chart_Image") & ".png"
        '    Response.Write("<IMG  src='" & chartImagePath & "' width='450' height='250' border='0'>")
        '    Response.Write("<br>")
        'End If
        '' end commented by syed
        '' add by syed
        If HttpContext.Current.Session("All_Chart_Image") <> "" Then
            'chartImagePath = HttpContext.Current.Session("BaseUrl") & "/" & "WebCharts/" & HttpContext.Current.Session("SWP_Chart_Image") & ".png"
            Response.Write("<img  src='" & HttpContext.Current.Session("All_Chart_Image") & "' width='700' height='420' border='0'>")
            Response.Write("<br>")
        End If

        Response.Write("<b><div width ='600px' style='font-family:Arial; color:black; font-size:14px;'>" & Notes & "</div></b>")

        'Response.Write("<br><b><left><font size=1.5 face=verdana color=#ff0000> " & disclaimer1 & "</font></left></b>")
        Response.Write("<b><div width ='600px' style='font-family:Arial; color:red; font-size:14px;'>" & disclaimer1 & "</div></b>")
        'Response.Write("<table align=top><tr height=9 style='height:9.0pt'><td colspan=3 rowspan=5 height=54 class=xl40 width=700 style='height:60.0pt;width:700pt'><font size=1 face=Arial color='black'>" & disclaimer & "</font></td></tr></table>")
        Response.Write("<div width='600px' style='font-family:Arial; color:black; font-size:15px;'>" & disclaimer & "</div>")



        Response.End()
    End Sub

    Public Sub SaveToExcel_SIP(ByVal Response As HttpResponse, ByVal dgrid As DataGrid, ByVal p1 As String, ByVal p2 As String, ByVal p3 As String, ByVal sch As String, ByVal bmark As String, ByVal Ent_Load As String, ByVal Notes As String)
        Dim stringWrite As System.IO.StringWriter
        Dim htmlWrite As System.Web.UI.HtmlTextWriter

        Dim stringWrite2 As System.IO.StringWriter
        Dim htmlWrite2 As System.Web.UI.HtmlTextWriter
        Dim dgrid1 As New DataGrid
        Dim Filename As String
        Dim font_Size As Integer = 8
        Dim address1 As String
        Dim Returns As String
        Dim Xirr As String
        Dim Xirr1 As String
        Dim Sch_Name As String
        Dim B_Mark As String
        Dim E_Load As String
        Dim i As Integer


        Dim disclaimer As String
        Dim disclaimer1 As String
        disclaimer1 = "Disclaimer :"

        'disclaimer = "Risk factors: The above compilation is not intended as advice. The information therein is furnished without liability for any inaccuracy.This compilation does not entitle any person to any claim in respect of any liability or consequence of anything done, or omitted to be done, by any such person in reliance upon the contents thereof.This is not an offer for invitation for subscriptions to units of Reliance Mutual Fund schemes. For further details please refer to offer document and load structure before investing. Past performance may or may not be sustained in future. Generated by icraonline.com "
        disclaimer = "<div style='text-align:justify'>
                    <p class='txt2' style='font-size: 13px; text-align: justify; line-height: 16px;'>Copyright 2017 Nippon India Mutual Fund. All Rights Reserved.<br>

                       Nippon India Mutual Fund does not take the responsibility, liability and undertake the authenticity of the figures calculated on the basis of calculator provided herein for calculations towards prospective investments.Developed and Maintained by ICRA Analytics Limited. The data content provided is obtained from sources considered to be authentic and reliable. However, ICRA Analytics Limited is not responsible for any error or inaccuracy or for any losses suffered on account of information.</p>
                            <p class='txt2' style='font-size: 13px; text-align: justify; line-height: 16px;'>The Calculators/Tools/Planners are designed to assist you in determining the appropriate amount. These Calculators/Tools/Planners alone are not sufficient and should not be used for the development or implementation of an investment strategy. The investor is advised to consult his or her financial advisor prior to arriving at any investment decision.
                                                        </p>
                    </div>"

        Dim imagePath As String
        Dim imagePath1 As String

        If dgrid.Items.Count < 1 Then
            Exit Sub
        End If

        '//data grid formatting before exporting
        dgrid.Font.Name = "Arial"
        dgrid.Font.Size = System.Web.UI.WebControls.FontUnit.Point(8)
        dgrid.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid
        dgrid.HeaderStyle.BackColor = System.Drawing.Color.Red
        dgrid.HeaderStyle.ForeColor = System.Drawing.Color.White
        dgrid.HeaderStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
        dgrid.HeaderStyle.Wrap = False
        dgrid.HeaderStyle.Font.Bold = True
        dgrid.GridLines = GridLines.Both
        dgrid.BorderColor = System.Drawing.Color.LightGray

        dgrid.BorderWidth = New Unit(1, UnitType.Pixel)
        dgrid.Items(0).Width = New Unit(CDbl(200))
        '''For i = 0 To ColCount - 1
        '''    dgrid.Items(i).Width = New Unit(CDbl(100))
        '''Next

        'dgrid.Width = New Unit(CDbl(170))

        Filename = "NipponIndiaSIP" & ".xls"

        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=" & Filename)
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.xls"
        stringWrite = New System.IO.StringWriter
        '//write image

        ''imagePath = HttpContext.Current.Session("BaseUrl") & "/" & "images/rmf_logo01.gif" ''commented by syed
        imagePath = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "") & "\images\reliance-mutual-fund.png"

        Response.Write("<IMG  src='" & imagePath & "' width='410' height='55' border='0'>")
        Response.Write("<br>")

        '''imagePath1 = "http://localhost/RelianceSIP/images/toplinks01_bg.gif"
        '''Response.Write("<IMG  src='" & imagePath1 & "' width='720' height='20' border='0'>")
        Response.Write("<br>")
        Response.Write("<br>")

        Sch_Name = "Scheme " & " : " & sch
        B_Mark = "Benchmark Index " & " : " & bmark
        E_Load = "Entry Load " & " : " & Ent_Load

        Response.Write("<b><font size='1.5' face='verdana' color='#000000'>" & "" & Sch_Name & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & "" & " </b> </font>")
        Response.Write("<b><font size='1.5' face='verdana' color='#000000'>" & "" & E_Load & "" & " </b> </font>")
        Response.Write("<br>")
        Response.Write("<b><font size='1.5' face='verdana' color='#000000'>" & "" & B_Mark & "" & " </b> </font>")
        Response.Write("<br>")
        Response.Write("<br>")




        'Response.Write("<font size=1 face=Arial>")
        htmlWrite = New HtmlTextWriter(stringWrite)
        dgrid.RenderControl(htmlWrite)
        Response.Write(stringWrite.ToString())


        ' Response.Write("<br>")
        Returns = "Abs. Return (Scheme): " & p1
        Xirr = "Yield (Scheme): " & p2
        Xirr1 = "Yield (Index): " & p3

        Response.Write("<br>")
        Response.Write("<b><font size='1.5' face='verdana' color='#000000'>" & "" & Returns & "" & " </b> </font>")
        Response.Write("<br>")
        Response.Write("<b><font size='1.5' face='verdana' color='#000000'>" & "" & Xirr & "" & " </b> </font>")

        Response.Write("<br>")
        Response.Write("<b><font size='1.5' face='verdana' color='#000000'>" & "" & Xirr1 & "" & " </b> </font>")
        stringWrite2 = New System.IO.StringWriter

        '//Vishal to Save chart image in excel'
        Dim chartImagePath As String
        'If HttpContext.Current.Session("SIP_Chart_Image") <> "" Then
        '    chartImagePath = HttpContext.Current.Session("BaseUrl") & "/" & "WebCharts/" & HttpContext.Current.Session("SIP_Chart_Image") & ".png"
        '    Response.Write("<IMG  src='" & chartImagePath & "' width='450' height='250' border='0'>")
        '    Response.Write("<br>")
        'End If
        '//SIP_Chart_Image
        ''start syed
        If HttpContext.Current.Session("All_Chart_Image") <> "" Then
            'chartImagePath = HttpContext.Current.Session("BaseUrl") & "/" & "WebCharts/" & HttpContext.Current.Session("All_Chart_Image") & ".png"
            Response.Write("<IMG  src='" & HttpContext.Current.Session("All_Chart_Image") & "' width='700' height='420' border='0'>")
            Response.Write("<br>")
        End If

        ''end syed

        Response.Write("<b><div width ='600px' style='font-family:Arial; color:black; font-size:14px;'>" & Notes & "</div></b>")

        Response.Write("<br><b><left><font size='1.5' face='verdana' color='#ff0000'> " & disclaimer1 & "</font></left></b>")
        Response.Write("<br>")
        'Response.Write("<table align=top><tr height=9 style='height:9.0pt'><td colspan=6 rowspan=5 height=54 class=xl40 width=450 style='height:54.0pt;width:700pt'><font size=1 face=Arial color='black'>" & disclaimer & "</font></TD></tr><table>")
        Response.Write("<div width='600px' style='font-family:Arial; color:black; font-size:15px;'>" & disclaimer & "</div>")

        Response.End()
    End Sub


    Public Sub SaveToExcel_SIP2(ByVal Response As HttpResponse, ByVal dgrid As DataGrid, ByVal p1 As String, ByVal p2 As String, ByVal p3 As String, ByVal sch As String, ByVal bmark As String, ByVal Ent_Load As String, ByVal Notes As String)

        Dim workbook As New XSSFWorkbook()

        Dim sheet As XSSFSheet = workbook.CreateSheet("SIP Report")

        For i As Integer = 0 To 12
            sheet.SetColumnWidth(i, 20 * 256)
        Next

        'Set Header Style
        Dim Style As XSSFCellStyle = workbook.CreateCellStyle()
        Dim headerFont As XSSFFont = workbook.CreateFont
        headerFont.FontName = "Calibri"
        headerFont.IsBold = True
        headerFont.FontHeight = 12
        Style.SetFont(headerFont)


        sheet.DisplayGridlines = False

        Dim AllCellStyleEven As XSSFCellStyle = CType(workbook.CreateCellStyle(), XSSFCellStyle)
        AllCellStyleEven.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin
        AllCellStyleEven.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
        AllCellStyleEven.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin
        AllCellStyleEven.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin
        Dim colorToFillEven As XSSFColor = New XSSFColor(New Byte() {255, 230, 230})
        AllCellStyleEven.SetFillForegroundColor(colorToFillEven)
        AllCellStyleEven.FillPattern = FillPattern.SolidForeground
        AllCellStyleEven.Alignment = HorizontalAlignment.Center
        AllCellStyleEven.VerticalAlignment = VerticalAlignment.Center


        Dim AllCellStyleOdd As XSSFCellStyle = CType(workbook.CreateCellStyle(), XSSFCellStyle)
        AllCellStyleOdd.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin
        AllCellStyleOdd.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
        AllCellStyleOdd.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin
        AllCellStyleOdd.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin
        Dim colorToFillOdd As XSSFColor = New XSSFColor(New Byte() {255, 255, 255})
        AllCellStyleOdd.SetFillForegroundColor(colorToFillOdd)
        AllCellStyleOdd.FillPattern = FillPattern.SolidForeground
        AllCellStyleOdd.Alignment = HorizontalAlignment.Center
        AllCellStyleOdd.VerticalAlignment = VerticalAlignment.Center


        Dim headerStyle As XSSFCellStyle = CType(workbook.CreateCellStyle(), XSSFCellStyle)
        Dim colorToFill As New XSSFColor(New Byte() {255, 0, 0})
        Dim back As New XSSFColor(New Byte() {255, 0, 0})
        headerStyle.SetFillForegroundColor(colorToFill)
        Dim font As IFont = workbook.CreateFont()
        font.Color = IndexedColors.White.Index
        font.Boldweight = FontBoldWeight.Bold

        headerStyle.SetFont(font)
        headerStyle.FillPattern = FillPattern.SolidForeground
        headerStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin
        headerStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
        headerStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin
        headerStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin
        headerStyle.Alignment = HorizontalAlignment.Center
        headerStyle.VerticalAlignment = VerticalAlignment.Center


        ' Create Row and add Logo
        Dim logoPath As String
        Dim GraphImgPath As String

        logoPath = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "") & "/images/reliance-mutual-fund.png"
        'logoPath = HttpContext.Current.Server.MapPath("~/images/reliance-mutual-fund.png".Replace("\", "/"))

        If Not String.IsNullOrEmpty(logoPath) Then

            Dim patriarch As XSSFDrawing = CType(sheet.CreateDrawingPatriarch(), XSSFDrawing)
            Dim anchor As XSSFClientAnchor
            anchor = New XSSFClientAnchor(0, 0, 0, 255, 0, 0, 0, 3)

            anchor.AnchorType = AnchorType.DontMoveAndResize

            Dim picture As XSSFPicture = CType(patriarch.CreatePicture(anchor, LoadImage(logoPath, workbook, PictureType.PNG)), XSSFPicture)

            Dim x1 As Double = 3
            Dim y1 As Double = 1
            picture.Resize(x1, y1)
            picture.LineStyle = LineStyle.None

        End If

        Dim ProfileRow As IRow = sheet.CreateRow(5)
        ProfileRow.CreateCell(0).SetCellValue("Scheme Name      : ")
        ProfileRow.CreateCell(1).SetCellValue(sch)
        ProfileRow.GetCell(0).CellStyle = Style
        ProfileRow.GetCell(1).CellStyle = Style

        ProfileRow = sheet.CreateRow(6)
        ProfileRow.CreateCell(0).SetCellValue("Entry Load            : ")
        ProfileRow.CreateCell(1).SetCellValue(Ent_Load)
        ProfileRow.GetCell(0).CellStyle = Style
        ProfileRow.GetCell(1).CellStyle = Style

        ProfileRow = sheet.CreateRow(7)
        ProfileRow.CreateCell(0).SetCellValue("Benchmark Index : ")
        ProfileRow.CreateCell(1).SetCellValue(bmark)
        ProfileRow.GetCell(0).CellStyle = Style
        ProfileRow.GetCell(1).CellStyle = Style

        Dim HeaderList As String() = New String(6) {}
        HeaderList(0) = "Date"
        HeaderList(1) = "Nav"
        HeaderList(2) = "Units"
        HeaderList(3) = "CashFlow(scheme)"
        HeaderList(4) = "Amount"
        HeaderList(5) = "SIP Value"
        HeaderList(6) = "Index Value"



        'Header creation in the Excel
        Dim headerRow As IRow = sheet.CreateRow(9)
        Dim itrCol As Int16 = 0

        For Each col As String In HeaderList
            Dim cell As ICell = headerRow.CreateCell(itrCol)
            cell.SetCellValue(col)
            cell.CellStyle = headerStyle
            'AutoFitColumn(sheet, itrCol)
            itrCol = itrCol + 1
        Next
        Dim itrRow As Int16 = 10
        Dim flag As Int16 = 0
        For Each row As DataGridItem In dgrid.Items
            Dim DataRow As IRow = sheet.CreateRow(itrRow)

            itrCol = 0
            flag = 0

            For Each cell As TableCell In row.Cells
                If (flag <> 4 AndAlso flag <> 7) Then
                    Dim datacell As ICell = DataRow.CreateCell(itrCol)
                    datacell.SetCellValue(If(cell.Text = "&nbsp;", "", cell.Text))
                    'AutoFitColumn(sheet, itrCol)
                    If (itrRow Mod 2 = 0) Then
                        datacell.CellStyle = AllCellStyleEven
                    Else
                        datacell.CellStyle = AllCellStyleOdd
                    End If

                    itrCol = itrCol + 1
                End If
                flag = flag + 1

            Next

            itrRow = itrRow + 1

        Next

        itrRow = itrRow + 1

        Dim PercentageData As IRow = sheet.CreateRow(itrRow)
        PercentageData.CreateCell(0).SetCellValue("Abs. Return (Scheme): ")
        PercentageData.CreateCell(1).SetCellValue(p1)
        'PercentageData.GetCell(0).CellStyle = AllCellStyleEven
        'PercentageData.GetCell(1).CellStyle = AllCellStyleEven

        itrRow = itrRow + 1
        PercentageData = sheet.CreateRow(itrRow)
        PercentageData.CreateCell(0).SetCellValue("Yield (Scheme)             : ")
        PercentageData.CreateCell(1).SetCellValue(p2)
        'PercentageData.GetCell(0).CellStyle = AllCellStyleEven
        'PercentageData.GetCell(1).CellStyle = AllCellStyleEven

        itrRow = itrRow + 1
        PercentageData = sheet.CreateRow(itrRow)
        PercentageData.CreateCell(0).SetCellValue("Yield (Index)                  : ")
        PercentageData.CreateCell(1).SetCellValue(p3)
        'PercentageData.GetCell(0).CellStyle = AllCellStyleEven
        'PercentageData.GetCell(1).CellStyle = AllCellStyleEven
        'AutoFitColumn(sheet, 0)
        'AutoFitColumn(sheet, 1)
        itrRow = itrRow + 2


        If HttpContext.Current.Session("All_Chart_Image") <> "" Then
            GraphImgPath = HttpContext.Current.Session("All_Chart_Image")
        End If


        If (Not String.IsNullOrEmpty(GraphImgPath)) Then
            Dim patriarch As XSSFDrawing = CType(sheet.CreateDrawingPatriarch(), XSSFDrawing)
            Dim anchor As XSSFClientAnchor
            anchor = New XSSFClientAnchor(0, 0, 0, 255, 0, itrRow, 0, itrRow + 12)

            anchor.AnchorType = AnchorType.DontMoveAndResize

            Dim picture As XSSFPicture = CType(patriarch.CreatePicture(anchor, LoadImage(GraphImgPath, workbook, PictureType.PNG)), XSSFPicture)

            Dim x1 As Double = 6
            Dim y1 As Double = 1.75
            picture.Resize(x1, y1)
            picture.LineStyle = LineStyle.None
        End If

        itrRow = itrRow + 13 + 8

        Dim _Notes As String = Notes

        Dim IndexOfSplitString As Int16 = _Notes.IndexOf("Yield")

        Dim TagName1 As String = "</u>"
        Dim TagName2 As String = "</p>"

        Dim note As IRow = sheet.CreateRow(itrRow)
        note.CreateCell(0).SetCellValue("Notes         : ")
        note.GetCell(0).CellStyle = Style
        Dim array As String() = Notes.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
        Dim sortNote As String = array(1).TrimStart(TagName1.ToCharArray()).TrimEnd(TagName2.ToCharArray()).Trim()
        note.CreateCell(1).SetCellValue(sortNote.Substring(0, IndexOfSplitString - 17))
        itrRow = itrRow + 1

        note = sheet.CreateRow(itrRow)
        note.CreateCell(1).SetCellValue(sortNote.Substring(IndexOfSplitString - 17))
        itrRow = itrRow + 1


        Dim Disclaimer As IRow = sheet.CreateRow(itrRow)
        Disclaimer.CreateCell(0).SetCellValue("Disclaimer :")
        Disclaimer.GetCell(0).CellStyle = Style
        Disclaimer.CreateCell(1).SetCellValue("Copyright 2017 Nippon India Mutual Fund. All Rights Reserved.")
        itrRow = itrRow + 1

        Disclaimer = sheet.CreateRow(itrRow)
        Disclaimer.CreateCell(1).SetCellValue("Nippon India Mutual Fund does not take the responsibility, liability and undertake the authenticity of the figures calculated on the basis of calculator provided herein for calculations towards prospective investments.Developed and Maintained by")
        itrRow = itrRow + 1



        Dim HyperLinkStyle As XSSFCellStyle = CType(workbook.CreateCellStyle(), XSSFCellStyle)
        Dim HyperLinkFont As IFont = workbook.CreateFont()
        HyperLinkFont.Color = IndexedColors.Blue.Index
        HyperLinkFont.Underline = FontUnderlineType.Single
        HyperLinkStyle.SetFont(HyperLinkFont)
        Disclaimer = sheet.CreateRow(itrRow)
        Disclaimer.CreateCell(1).SetCellValue("ICRA Analytics Limited")
        Dim createHelper As XSSFCreationHelper = CType(workbook.GetCreationHelper(), XSSFCreationHelper)
        Dim link As XSSFHyperlink = CType(createHelper.CreateHyperlink(HyperlinkType.Url), XSSFHyperlink)
        link.Address = "https://www.icraanalytics.com/"
        Disclaimer.GetCell(1).Hyperlink = link
        Disclaimer.GetCell(1).CellStyle = HyperLinkStyle
        itrRow = itrRow + 1



        Disclaimer = sheet.CreateRow(itrRow)
        Disclaimer.CreateCell(1).SetCellValue("The data content provided is obtained from sources considered to be authentic and reliable. However, ICRA Analytics Limited is not responsible for any error or inaccuracy or for any losses suffered on account of information.")
        itrRow = itrRow + 1

        Disclaimer = sheet.CreateRow(itrRow)
        Disclaimer.CreateCell(1).SetCellValue("The Calculators/Tools/Planners are designed to assist you in determining the appropriate amount. These Calculators/Tools/Planners alone are not sufficient and shouldn’t be used for the development or implementation of an investment strategy.")
        itrRow = itrRow + 1

        Disclaimer = sheet.CreateRow(itrRow)
        Disclaimer.CreateCell(1).SetCellValue("The investor is advised to consult his or her financial advisor prior to arriving at any investment decision.")
        itrRow = itrRow + 1

        Using memoryStream As New MemoryStream()
            workbook.Write(memoryStream)
            Response.Clear()
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.AddHeader("Content-Disposition", "attachment; filename = NipponIndiaSIP.xlsx")
            Response.BinaryWrite(memoryStream.ToArray())
            Response.End()


        End Using




    End Sub

    Public Sub SaveToExcel_SWP2(ByVal Response As HttpResponse, ByVal dgrid As DataGrid, ByVal p1 As String, ByVal p2 As String, ByVal sch As String, ByVal bmark As String, ByVal Notes As String)
        Dim workbook As New XSSFWorkbook()

        Dim sheet As XSSFSheet = workbook.CreateSheet("SWP Report")

        For i As Integer = 0 To 12
            sheet.SetColumnWidth(i, 20 * 256)
        Next

        'Set Header Style
        Dim Style As XSSFCellStyle = workbook.CreateCellStyle()
        Dim headerFont As XSSFFont = workbook.CreateFont
        headerFont.FontName = "Calibri"
        headerFont.IsBold = True
        headerFont.FontHeight = 12
        Style.SetFont(headerFont)


        sheet.DisplayGridlines = False

        Dim AllCellStyleEven As XSSFCellStyle = CType(workbook.CreateCellStyle(), XSSFCellStyle)
        AllCellStyleEven.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin
        AllCellStyleEven.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
        AllCellStyleEven.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin
        AllCellStyleEven.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin
        Dim colorToFillEven As XSSFColor = New XSSFColor(New Byte() {255, 230, 230})
        AllCellStyleEven.SetFillForegroundColor(colorToFillEven)
        AllCellStyleEven.FillPattern = FillPattern.SolidForeground
        AllCellStyleEven.Alignment = HorizontalAlignment.Center
        AllCellStyleEven.VerticalAlignment = VerticalAlignment.Center


        Dim AllCellStyleOdd As XSSFCellStyle = CType(workbook.CreateCellStyle(), XSSFCellStyle)
        AllCellStyleOdd.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin
        AllCellStyleOdd.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
        AllCellStyleOdd.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin
        AllCellStyleOdd.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin
        Dim colorToFillOdd As XSSFColor = New XSSFColor(New Byte() {255, 255, 255})
        AllCellStyleOdd.SetFillForegroundColor(colorToFillOdd)
        AllCellStyleOdd.FillPattern = FillPattern.SolidForeground
        AllCellStyleOdd.Alignment = HorizontalAlignment.Center
        AllCellStyleOdd.VerticalAlignment = VerticalAlignment.Center


        Dim headerStyle As XSSFCellStyle = CType(workbook.CreateCellStyle(), XSSFCellStyle)
        Dim colorToFill As New XSSFColor(New Byte() {255, 0, 0})
        Dim back As New XSSFColor(New Byte() {255, 0, 0})
        headerStyle.SetFillForegroundColor(colorToFill)
        Dim font As IFont = workbook.CreateFont()
        font.Color = IndexedColors.White.Index
        font.Boldweight = FontBoldWeight.Bold

        headerStyle.SetFont(font)
        headerStyle.FillPattern = FillPattern.SolidForeground
        headerStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin
        headerStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
        headerStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin
        headerStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin
        headerStyle.Alignment = HorizontalAlignment.Center
        headerStyle.VerticalAlignment = VerticalAlignment.Center


        ' Create Row and add Logo
        Dim logoPath As String
        Dim GraphImgPath As String

        logoPath = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "") & "/images/reliance-mutual-fund.png"

        If Not String.IsNullOrEmpty(logoPath) Then

            Dim patriarch As XSSFDrawing = CType(sheet.CreateDrawingPatriarch(), XSSFDrawing)
            Dim anchor As XSSFClientAnchor
            anchor = New XSSFClientAnchor(0, 0, 0, 255, 0, 0, 0, 3)

            anchor.AnchorType = AnchorType.DontMoveAndResize

            Dim picture As XSSFPicture = CType(patriarch.CreatePicture(anchor, LoadImage(logoPath, workbook, PictureType.PNG)), XSSFPicture)

            Dim x1 As Double = 3
            Dim y1 As Double = 1
            picture.Resize(x1, y1)
            picture.LineStyle = LineStyle.None

        End If

        Dim ProfileRow As IRow = sheet.CreateRow(5)
        ProfileRow.CreateCell(0).SetCellValue("Scheme Name       : ")
        ProfileRow.CreateCell(1).SetCellValue(sch)
        ProfileRow.GetCell(0).CellStyle = Style
        ProfileRow.GetCell(1).CellStyle = Style
        'ProfileRow.CreateCell(3).SetCellValue("Entry Load : ")
        'ProfileRow.CreateCell(4).SetCellValue(Ent_Load)
        'ProfileRow.GetCell(4).CellStyle = Style

        Dim ProfileRow2 As IRow = sheet.CreateRow(6)
        ProfileRow2.CreateCell(0).SetCellValue("Benchmark Index : ")
        ProfileRow2.CreateCell(1).SetCellValue(bmark)
        ProfileRow2.GetCell(0).CellStyle = Style
        ProfileRow2.GetCell(1).CellStyle = Style

        Dim HeaderList As String() = New String(8) {}
        HeaderList(0) = "Date"
        HeaderList(1) = "Amount Invested"
        HeaderList(2) = "Amount Withdrawn"
        HeaderList(3) = "NAV"
        HeaderList(4) = "Unit Sold"
        HeaderList(5) = "Balance Units"
        HeaderList(6) = "Amount Withdrawn till date"
        HeaderList(7) = "Value of Balance Units"
        HeaderList(8) = "Index Value"



        'Header creation in the Excel
        Dim headerRow As IRow = sheet.CreateRow(8)
        Dim itrCol As Int16 = 0

        For Each col As String In HeaderList
            Dim cell As ICell = headerRow.CreateCell(itrCol)
            cell.SetCellValue(col)
            cell.CellStyle = headerStyle
            'AutoFitColumn(sheet, itrCol)
            itrCol = itrCol + 1
        Next
        Dim itrRow As Int16 = 9
        Dim flag As Int16 = 0
        For Each row As DataGridItem In dgrid.Items
            Dim DataRow As IRow = sheet.CreateRow(itrRow)

            itrCol = 0
            flag = 0

            For Each cell As TableCell In row.Cells
                If (flag <> 10 AndAlso flag <> 9) Then
                    Dim datacell As ICell = DataRow.CreateCell(itrCol)
                    datacell.SetCellValue(If(cell.Text = "&nbsp;", "", cell.Text))
                    'AutoFitColumn(sheet, itrCol)
                    If (itrRow Mod 2 = 0) Then
                        datacell.CellStyle = AllCellStyleEven
                    Else
                        datacell.CellStyle = AllCellStyleOdd
                    End If

                    itrCol = itrCol + 1
                End If
                flag = flag + 1

            Next

            itrRow = itrRow + 1

        Next

        itrRow = itrRow + 1

        Dim PercentageData As IRow = sheet.CreateRow(itrRow)
        PercentageData.CreateCell(0).SetCellValue("Abs. Return (Scheme): ")
        PercentageData.CreateCell(1).SetCellValue(p1)
        'AutoFitColumn(sheet, 1)
        'PercentageData.GetCell(0).CellStyle = AllCellStyleEven
        'PercentageData.GetCell(1).CellStyle = AllCellStyleEven

        itrRow = itrRow + 1
        PercentageData = sheet.CreateRow(itrRow)
        PercentageData.CreateCell(0).SetCellValue("Yield (Scheme)              : ")
        PercentageData.CreateCell(1).SetCellValue(p2)
        'PercentageData.GetCell(0).CellStyle = AllCellStyleEven
        'PercentageData.GetCell(1).CellStyle = AllCellStyleEven

        'itrRow = itrRow + 1
        'PercentageData = sheet.CreateRow(itrRow)
        'PercentageData.CreateCell(0).SetCellValue("Yield (Index): ")
        'PercentageData.CreateCell(1).SetCellValue(p3)
        'PercentageData.GetCell(0).CellStyle = AllCellStyleEven
        'PercentageData.GetCell(1).CellStyle = AllCellStyleEven
        'AutoFitColumn(sheet, 0)
        'AutoFitColumn(sheet, 1)
        itrRow = itrRow + 2


        If HttpContext.Current.Session("All_Chart_Image") <> "" Then
            GraphImgPath = HttpContext.Current.Session("All_Chart_Image")
        End If

        If (Not String.IsNullOrEmpty(GraphImgPath)) Then
            Dim patriarch As XSSFDrawing = CType(sheet.CreateDrawingPatriarch(), XSSFDrawing)
            Dim anchor As XSSFClientAnchor
            anchor = New XSSFClientAnchor(0, 0, 0, 255, 0, itrRow, 0, itrRow + 12)

            anchor.AnchorType = AnchorType.DontMoveAndResize

            Dim picture As XSSFPicture = CType(patriarch.CreatePicture(anchor, LoadImage(GraphImgPath, workbook, PictureType.PNG)), XSSFPicture)

            Dim x1 As Double = 6
            Dim y1 As Double = 1.75
            picture.Resize(x1, y1)
            picture.LineStyle = LineStyle.None
        End If

        itrRow = itrRow + 13 + 8

        Dim _Notes As String = Notes

        Dim IndexOfSplitString As Int16 = _Notes.IndexOf("Yield")

        Dim TagName1 As String = "</u>"
        Dim TagName2 As String = "</p>"

        Dim note As IRow = sheet.CreateRow(itrRow)
        note.CreateCell(0).SetCellValue("Notes         : ")
        note.GetCell(0).CellStyle = Style
        Dim array As String() = Notes.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
        Dim sortNote As String = array(1).TrimStart(TagName1.ToCharArray()).TrimEnd(TagName2.ToCharArray()).Trim()
        note.CreateCell(1).SetCellValue(sortNote.Substring(0, IndexOfSplitString - 17))
        itrRow = itrRow + 1

        note = sheet.CreateRow(itrRow)
        note.CreateCell(1).SetCellValue(sortNote.Substring(IndexOfSplitString - 17))
        itrRow = itrRow + 1


        Dim Disclaimer As IRow = sheet.CreateRow(itrRow)
        Disclaimer.CreateCell(0).SetCellValue("Disclaimer :")
        Disclaimer.GetCell(0).CellStyle = Style
        Disclaimer.CreateCell(1).SetCellValue("Copyright 2017 Nippon India Mutual Fund. All Rights Reserved.")
        itrRow = itrRow + 1

        Disclaimer = sheet.CreateRow(itrRow)
        Disclaimer.CreateCell(1).SetCellValue("Nippon India Mutual Fund does not take the responsibility, liability and undertake the authenticity of the figures calculated on the basis of calculator provided herein for calculations towards prospective investments.Developed and Maintained by")
        itrRow = itrRow + 1



        Dim HyperLinkStyle As XSSFCellStyle = CType(workbook.CreateCellStyle(), XSSFCellStyle)
        Dim HyperLinkFont As IFont = workbook.CreateFont()
        HyperLinkFont.Color = IndexedColors.Blue.Index
        HyperLinkFont.Underline = FontUnderlineType.Single
        HyperLinkStyle.SetFont(HyperLinkFont)
        Disclaimer = sheet.CreateRow(itrRow)
        Disclaimer.CreateCell(1).SetCellValue("ICRA Analytics Limited")
        Dim createHelper As XSSFCreationHelper = CType(workbook.GetCreationHelper(), XSSFCreationHelper)
        Dim link As XSSFHyperlink = CType(createHelper.CreateHyperlink(HyperlinkType.Url), XSSFHyperlink)
        link.Address = "https://www.icraanalytics.com/"
        Disclaimer.GetCell(1).Hyperlink = link
        Disclaimer.GetCell(1).CellStyle = HyperLinkStyle
        itrRow = itrRow + 1



        Disclaimer = sheet.CreateRow(itrRow)
        Disclaimer.CreateCell(1).SetCellValue("The data content provided is obtained from sources considered to be authentic and reliable. However, ICRA Analytics Limited is not responsible for any error or inaccuracy or for any losses suffered on account of information.")
        itrRow = itrRow + 1

        Disclaimer = sheet.CreateRow(itrRow)
        Disclaimer.CreateCell(1).SetCellValue("The Calculators/Tools/Planners are designed to assist you in determining the appropriate amount. These Calculators/Tools/Planners alone are not sufficient and shouldn’t be used for the development or implementation of an investment strategy.")
        itrRow = itrRow + 1

        Disclaimer = sheet.CreateRow(itrRow)
        Disclaimer.CreateCell(1).SetCellValue("The investor is advised to consult his or her financial advisor prior to arriving at any investment decision.")
        itrRow = itrRow + 1

        Using memoryStream As New MemoryStream()
            workbook.Write(memoryStream)
            Response.Clear()
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.AddHeader("Content-Disposition", "attachment; filename = NipponIndiaSWP.xlsx")
            Response.BinaryWrite(memoryStream.ToArray())
            Response.End()


        End Using
    End Sub
    Public Function AutoFitColumn(ByVal sheetName As ISheet, ByVal columnIndex As Integer) As Boolean
        Try
            sheetName.AutoSizeColumn(columnIndex)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    'Public Function LoadImage(path As String, wb As XSSFWorkbook, pictureType As PictureType) As Int32

    '    If wb IsNot Nothing Then

    '        Return wb.AddPicture(GetImageData(path), pictureType)
    '    Else
    '        Return -1
    '    End If


    'End Function



    'Public Function GetImageData(imagePath As String) As Byte()
    '    Dim ImageData As Byte() = Nothing
    '    Try

    '        imagePath = imagePath.Replace("\", "/")

    '        Dim webClient As New System.Net.WebClient()
    '        Dim ImgData As Byte() = webClient.DownloadData(imagePath)


    '        Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(New System.IO.MemoryStream(ImgData))
    '        Using ms As New MemoryStream()
    '            img.Save(ms, img.RawFormat)

    '            ImageData = ms.ToArray()
    '        End Using

    '    Catch ex As Exception

    '    End Try

    '    Return ImageData

    'End Function

    Public Function LoadImage(path As String, wb As XSSFWorkbook, pictureType As PictureType) As Int32
        Try
            If wb IsNot Nothing Then
                Dim imageData As Byte() = GetImageData(path)
                If imageData IsNot Nothing Then
                    Return wb.AddPicture(imageData, pictureType)
                Else
                    Return -1
                End If
            End If
        Catch ex As Exception

        End Try
        Return -1
    End Function

    Public Function GetImageData(imagePath As String) As Byte()
        Dim ImageData As Byte() = Nothing
        Try
            imagePath = imagePath.Replace("\", "/")
            Dim webClient As New System.Net.WebClient()
            'Dim ImgData As Byte() = webClient.DownloadData(imagePath)
            Dim ImgData As Byte()

            Dim domain As String = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "")
            imagePath = imagePath.Replace(domain, "")
            imagePath = HttpContext.Current.Server.MapPath("~" + imagePath.Replace("\", "/"))

            If imagePath.StartsWith("http://") OrElse imagePath.StartsWith("https://") Then
                ImgData = webClient.DownloadData(imagePath)
            Else
                ImgData = System.IO.File.ReadAllBytes(imagePath)
            End If

            Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(New System.IO.MemoryStream(ImgData))
            Using ms As New MemoryStream()
                img.Save(ms, img.RawFormat)
                ImageData = ms.ToArray()
            End Using
        Catch ex As Exception
            ImageData = Nothing
        End Try
        Return ImageData
    End Function


    Public Sub SaveToExcel_STP2(ByVal Response As HttpResponse, ByVal dgrid As DataGrid, ByVal dgrid2 As DataGrid, ByVal p1 As String, ByVal p2 As String, ByVal p3 As String, ByVal L1 As String, ByVal L2 As String, ByVal rs As String, ByVal period As String, ByVal Notes As String)
        Dim workbook As New XSSFWorkbook()

        Dim sheet As XSSFSheet = workbook.CreateSheet("STP Report")
        For i As Integer = 0 To 12
            sheet .SetColumnWidth (i, 20*256)
        Next
        'Set Header Style
        Dim Style As XSSFCellStyle = workbook.CreateCellStyle()
        Dim headerFont As XSSFFont = workbook.CreateFont
        headerFont.FontName = "Calibri"
        headerFont.IsBold = True
        headerFont.FontHeight = 12
        Style.SetFont(headerFont)


        sheet.DisplayGridlines = False

        Dim AllCellStyleEven As XSSFCellStyle = CType(workbook.CreateCellStyle(), XSSFCellStyle)
        AllCellStyleEven.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin
        AllCellStyleEven.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
        AllCellStyleEven.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin
        AllCellStyleEven.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin
        Dim colorToFillEven As XSSFColor = New XSSFColor(New Byte() {255, 230, 230})
        AllCellStyleEven.SetFillForegroundColor(colorToFillEven)
        AllCellStyleEven.FillPattern = FillPattern.SolidForeground
        AllCellStyleEven.Alignment = HorizontalAlignment.Center
        AllCellStyleEven.VerticalAlignment = VerticalAlignment.Center


        Dim AllCellStyleOdd As XSSFCellStyle = CType(workbook.CreateCellStyle(), XSSFCellStyle)
        AllCellStyleOdd.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin
        AllCellStyleOdd.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
        AllCellStyleOdd.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin
        AllCellStyleOdd.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin
        Dim colorToFillOdd As XSSFColor = New XSSFColor(New Byte() {255, 255, 255})
        AllCellStyleOdd.SetFillForegroundColor(colorToFillOdd)
        AllCellStyleOdd.FillPattern = FillPattern.SolidForeground
        AllCellStyleOdd.Alignment = HorizontalAlignment.Center
        AllCellStyleOdd.VerticalAlignment = VerticalAlignment.Center


        Dim headerStyle As XSSFCellStyle = CType(workbook.CreateCellStyle(), XSSFCellStyle)
        Dim colorToFill As New XSSFColor(New Byte() {255, 0, 0})
        Dim back As New XSSFColor(New Byte() {255, 0, 0})
        headerStyle.SetFillForegroundColor(colorToFill)
        Dim font As IFont = workbook.CreateFont()
        font.Color = IndexedColors.White.Index
        font.Boldweight = FontBoldWeight.Bold

        headerStyle.SetFont(font)
        headerStyle.FillPattern = FillPattern.SolidForeground
        headerStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin
        headerStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
        headerStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin
        headerStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin
        headerStyle.Alignment = HorizontalAlignment.Center
        headerStyle.VerticalAlignment = VerticalAlignment.Center

        ' Create Row and add Logo
        Dim logoPath As String
        Dim GraphImgPath As String

        logoPath = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "") & "/images/reliance-mutual-fund.png"

        If Not String.IsNullOrEmpty(logoPath) Then

            Dim patriarch As XSSFDrawing = CType(sheet.CreateDrawingPatriarch(), XSSFDrawing)
            Dim anchor As XSSFClientAnchor
            anchor = New XSSFClientAnchor(0, 0, 0, 255, 0, 0, 0, 3)

            anchor.AnchorType = AnchorType.DontMoveAndResize

            Dim picture As XSSFPicture = CType(patriarch.CreatePicture(anchor, LoadImage(logoPath, workbook, PictureType.PNG)), XSSFPicture)

            Dim x1 As Double = 3
            Dim y1 As Double = 1
            picture.Resize(x1, y1)
            picture.LineStyle = LineStyle.None

        End If

        Dim TransAmt As String = "Rs." & rs & "/- To be Transferred " & " " & period

        Dim ProfileRow As IRow = sheet.CreateRow(5)
        ProfileRow.CreateCell(0).SetCellValue("STP              : ")
        ProfileRow.CreateCell(1).SetCellValue(TransAmt)
        ProfileRow.GetCell(0).CellStyle = Style
        ProfileRow.GetCell(1).CellStyle = Style

        ProfileRow = sheet.CreateRow(6)
        ProfileRow.CreateCell(0).SetCellValue("Transferor  :  ")
        ProfileRow.CreateCell(1).SetCellValue(L1)
        ProfileRow.GetCell(0).CellStyle = Style
        ProfileRow.GetCell(1).CellStyle = Style

        ProfileRow = sheet.CreateRow(7)
        ProfileRow.CreateCell(0).SetCellValue("Transferee  :  ")
        ProfileRow.CreateCell(1).SetCellValue(L2)
        ProfileRow.GetCell(0).CellStyle = Style
        ProfileRow.GetCell(1).CellStyle = Style


        Dim HeaderList As String() = New String(6) {}
        HeaderList(0) = "Date"
        HeaderList(1) = "NAV"
        HeaderList(2) = "Units"
        HeaderList(3) = "Cumulative Units"
        HeaderList(4) = "CashFlow"
        HeaderList(5) = "Dividend"
        HeaderList(6) = "Index Value"

        Dim HeaderList2 As String() = New String(3) {}
        HeaderList2(0) = "Date"
        HeaderList2(1) = "NAV"
        HeaderList2(2) = "Units"
        HeaderList2(3) = "Cumulative Units"



        ' First Header creation in the Excel
        Dim headerRow As IRow = sheet.CreateRow(9)
        Dim itrCol As Int16 = 0

        For Each col As String In HeaderList
            Dim cell As ICell = headerRow.CreateCell(itrCol)
            cell.SetCellValue(col)
            cell.CellStyle = headerStyle
            'AutoFitColumn(sheet, itrCol)
            itrCol = itrCol + 1
        Next
        Dim itrRow As Int16 = 10
        Dim flag As Int16 = 0
        For Each row As DataGridItem In dgrid.Items
            Dim DataRow As IRow = sheet.CreateRow(itrRow)

            itrCol = 0
            flag = 0

            For Each cell As TableCell In row.Cells
                If (flag <> 10 AndAlso flag <> 9 AndAlso flag <> 7 AndAlso flag <> 4) Then
                    Dim datacell As ICell = DataRow.CreateCell(itrCol)
                    datacell.SetCellValue(If(cell.Text = "&nbsp;", "", cell.Text))
                    'AutoFitColumn(sheet, itrCol)
                    If (itrRow Mod 2 = 0) Then
                        datacell.CellStyle = AllCellStyleEven
                    Else
                        datacell.CellStyle = AllCellStyleOdd
                    End If

                    itrCol = itrCol + 1
                End If
                flag = flag + 1

            Next

            itrRow = itrRow + 1

        Next

        itrRow = itrRow + 1


        ' second Header creation in the Excel
        headerRow = sheet.CreateRow(itrRow)
        itrCol = 0

        For Each col As String In HeaderList2
            Dim cell As ICell = headerRow.CreateCell(itrCol)
            cell.SetCellValue(col)
            cell.CellStyle = headerStyle
            'AutoFitColumn(sheet, itrCol)
            itrCol = itrCol + 1
        Next
        itrRow = itrRow + 1
        flag = 0
        For Each row As DataGridItem In dgrid2.Items
            Dim DataRow As IRow = sheet.CreateRow(itrRow)

            itrCol = 0
            flag = 0

            For Each cell As TableCell In row.Cells
                If (flag <> 8 AndAlso flag <> 7 AndAlso flag <> 6 AndAlso flag <> 5 AndAlso flag <> 4) Then
                    Dim datacell As ICell = DataRow.CreateCell(itrCol)
                    datacell.SetCellValue(If(cell.Text = "&nbsp;", "", cell.Text))
                    'AutoFitColumn(sheet, itrCol)
                    If (itrRow Mod 2 = 0) Then
                        datacell.CellStyle = AllCellStyleEven
                    Else
                        datacell.CellStyle = AllCellStyleOdd
                    End If

                    itrCol = itrCol + 1
                End If
                flag = flag + 1

            Next

            itrRow = itrRow + 1

        Next

        itrRow = itrRow + 1

        Dim Returns As String = "Value of balance units in transferor scheme :  " & p1
        Dim Returns1 As String = "Value of Accumulated units in transferee scheme :  " & p2
        Dim XIRR As String = "Hence Yield from STP investment is (%) :  " & p3

        Dim PercentageData As IRow = sheet.CreateRow(itrRow)
        PercentageData.CreateCell(0).SetCellValue(Returns)
        itrRow = itrRow + 1

        PercentageData = sheet.CreateRow(itrRow)
        PercentageData.CreateCell(0).SetCellValue(Returns1)
        itrRow = itrRow + 1

        PercentageData = sheet.CreateRow(itrRow)
        PercentageData.CreateCell(0).SetCellValue(XIRR)


        itrRow = itrRow + 2


        If HttpContext.Current.Session("All_Chart_Image") <> "" Then
            GraphImgPath = HttpContext.Current.Session("All_Chart_Image")
        End If

        If (Not String.IsNullOrEmpty(GraphImgPath)) Then
            Dim patriarch As XSSFDrawing = CType(sheet.CreateDrawingPatriarch(), XSSFDrawing)
            Dim anchor As XSSFClientAnchor
            anchor = New XSSFClientAnchor(0, 0, 0, 255, 0, itrRow, 0, itrRow + 12)

            anchor.AnchorType = AnchorType.DontMoveAndResize

            Dim picture As XSSFPicture = CType(patriarch.CreatePicture(anchor, LoadImage(GraphImgPath, workbook, PictureType.PNG)), XSSFPicture)

            Dim x1 As Double = 6
            Dim y1 As Double = 1.75
            picture.Resize(x1, y1)
            picture.LineStyle = LineStyle.None
        End If

        itrRow = itrRow + 13 + 8

        Dim _Notes As String = Notes

        Dim IndexOfSplitString As Int16 = _Notes.IndexOf("Yield")

        Dim TagName1 As String = "</u>"
        Dim TagName2 As String = "</p>"

        Dim note As IRow = sheet.CreateRow(itrRow)
        note.CreateCell(0).SetCellValue("Notes         : ")
        note.GetCell(0).CellStyle = Style
        Dim array As String() = Notes.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
        Dim sortNote As String = array(1).TrimStart(TagName1.ToCharArray()).TrimEnd(TagName2.ToCharArray()).Trim()
        note.CreateCell(1).SetCellValue(sortNote.Substring(0, IndexOfSplitString - 17))
        itrRow = itrRow + 1

        note = sheet.CreateRow(itrRow)
        note.CreateCell(1).SetCellValue(sortNote.Substring(IndexOfSplitString - 17))
        itrRow = itrRow + 1


        Dim Disclaimer As IRow = sheet.CreateRow(itrRow)
        Disclaimer.CreateCell(0).SetCellValue("Disclaimer :")
        Disclaimer.GetCell(0).CellStyle = Style
        Disclaimer.CreateCell(1).SetCellValue("Copyright 2017 Nippon India Mutual Fund. All Rights Reserved.")
        itrRow = itrRow + 1

        Disclaimer = sheet.CreateRow(itrRow)
        Disclaimer.CreateCell(1).SetCellValue("Nippon India Mutual Fund does not take the responsibility, liability and undertake the authenticity of the figures calculated on the basis of calculator provided herein for calculations towards prospective investments.Developed and Maintained by")
        itrRow = itrRow + 1



        Dim HyperLinkStyle As XSSFCellStyle = CType(workbook.CreateCellStyle(), XSSFCellStyle)
        Dim HyperLinkFont As IFont = workbook.CreateFont()
        HyperLinkFont.Color = IndexedColors.Blue.Index
        HyperLinkFont.Underline = FontUnderlineType.Single
        HyperLinkStyle.SetFont(HyperLinkFont)
        Disclaimer = sheet.CreateRow(itrRow)
        Disclaimer.CreateCell(1).SetCellValue("ICRA Analytics Limited")
        Dim createHelper As XSSFCreationHelper = CType(workbook.GetCreationHelper(), XSSFCreationHelper)
        Dim link As XSSFHyperlink = CType(createHelper.CreateHyperlink(HyperlinkType.Url), XSSFHyperlink)
        link.Address = "https://www.icraanalytics.com/"
        Disclaimer.GetCell(1).Hyperlink = link
        Disclaimer.GetCell(1).CellStyle = HyperLinkStyle
        itrRow = itrRow + 1



        Disclaimer = sheet.CreateRow(itrRow)
        Disclaimer.CreateCell(1).SetCellValue("The data content provided is obtained from sources considered to be authentic and reliable. However, ICRA Analytics Limited is not responsible for any error or inaccuracy or for any losses suffered on account of information.")
        itrRow = itrRow + 1

        Disclaimer = sheet.CreateRow(itrRow)
        Disclaimer.CreateCell(1).SetCellValue("The Calculators/Tools/Planners are designed to assist you in determining the appropriate amount. These Calculators/Tools/Planners alone are not sufficient and shouldn’t be used for the development or implementation of an investment strategy.")
        itrRow = itrRow + 1

        Disclaimer = sheet.CreateRow(itrRow)
        Disclaimer.CreateCell(1).SetCellValue("The investor is advised to consult his or her financial advisor prior to arriving at any investment decision.")
        itrRow = itrRow + 1

        Using memoryStream As New MemoryStream()
            workbook.Write(memoryStream)
            Response.Clear()
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.AddHeader("Content-Disposition", "attachment; filename = NipponIndiaSTP.xlsx")
            Response.BinaryWrite(memoryStream.ToArray())
            Response.End()


        End Using
    End Sub


    Public Sub SaveToExcel_STP(ByVal Response As HttpResponse, ByVal dgrid As DataGrid, ByVal dgrid2 As DataGrid, ByVal p1 As String, ByVal p2 As String, ByVal p3 As String, ByVal L1 As String, ByVal L2 As String, ByVal rs As String, ByVal period As String, ByVal Notes As String)
        Dim stringWrite As System.IO.StringWriter
        Dim htmlWrite As System.Web.UI.HtmlTextWriter

        Dim stringWrite2 As System.IO.StringWriter
        Dim htmlWrite2 As System.Web.UI.HtmlTextWriter

        Dim Filename As String
        Dim font_Size As Integer = 8
        Dim address1 As String
        Dim Returns As String
        Dim Returns1 As String
        Dim Xirr As String
        'Dim Xirr As String
        Dim ToShc As String
        Dim FromSch As String
        Dim TransAmt As String
        Dim imagePath As String
        Dim imagePath1 As String
        Dim disclaimer As String
        Dim disclaimer1 As String
        disclaimer1 = "Disclaimer :"

        'disclaimer = "Risk factors: The above compilation is not intended as advice. The information therein is furnished without liability for any inaccuracy.This compilation does not entitle any person to any claim in respect of any liability or consequence of anything done, or omitted to be done, by any such person in reliance upon the contents thereof.This is not an offer for invitation for subscriptions to units of Reliance Mutual Fund schemes. For further details please refer to offer document and load structure before investing. Past performance may or may not be sustained in future. Generated by icraonline.com "
        disclaimer = "<div style='text-align:justify'>
                    <p class='txt2' style='font-size: 13px; text-align: justify; line-height: 16px;'>Copyright 2017 Nippon India Mutual Fund. All Rights Reserved.<br><br>

                       Nippon India Mutual Fund does not take the responsibility, liability and undertake the authenticity of the figures calculated on the basis of calculator provided herein for calculations towards prospective investments.Developed and Maintained by ICRA Analytics Limited. The data content provided is obtained from sources considered to be authentic and reliable. However, ICRA Analytics Limited is not responsible for any error or inaccuracy or for any losses suffered on account of information.</p>
                            <p class='txt2' style='font-size: 13px; text-align: justify; line-height: 16px;'>The Calculators/Tools/Planners are designed to assist you in determining the appropriate amount. These Calculators/Tools/Planners alone are not sufficient and should not be used for the development or implementation of an investment strategy. The investor is advised to consult his or her financial advisor prior to arriving at any investment decision.
                                                        </p>
                    </div>"

        If dgrid.Items.Count < 1 Then
            Exit Sub
        End If

        '//data grid formatting before exporting
        dgrid.Font.Name = "Arial"
        dgrid.Font.Size = System.Web.UI.WebControls.FontUnit.Point(8)
        dgrid.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid
        dgrid.HeaderStyle.BackColor = System.Drawing.Color.Red
        dgrid.HeaderStyle.ForeColor = System.Drawing.Color.White
        dgrid.HeaderStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
        dgrid.HeaderStyle.Wrap = False
        dgrid.HeaderStyle.Font.Bold = True
        dgrid.GridLines = GridLines.Both
        dgrid.BorderColor = System.Drawing.Color.LightGray
        dgrid.BorderWidth = New Unit(1, UnitType.Pixel)
        'dgrid.Items(0).Width = New Unit(CDbl(740))
        'dgrid.Items(0).Height = New Unit(CDbl(30))
        'dgrid.Items(0).Width = 770

        dgrid2.Font.Name = "Arial"
        dgrid2.Font.Size = System.Web.UI.WebControls.FontUnit.Point(8)
        dgrid2.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid
        dgrid2.HeaderStyle.BackColor = System.Drawing.Color.Red
        dgrid2.HeaderStyle.ForeColor = System.Drawing.Color.White
        dgrid2.HeaderStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
        dgrid2.HeaderStyle.Wrap = False
        dgrid2.HeaderStyle.Font.Bold = True
        dgrid2.GridLines = GridLines.Both
        dgrid2.BorderColor = System.Drawing.Color.LightGray
        dgrid2.BorderWidth = New Unit(1, UnitType.Pixel)


        Filename = "NipponIndiaSTP" & ".xls"

        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=" & Filename)
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.xls"
        stringWrite = New System.IO.StringWriter
        '//write image

        'imagePath = HttpContext.Current.Session("BaseUrl") & "/" & "images/rmf_logo01.gif"
        'imagePath = HttpContext.Current.Server.MapPath("~") & "/" & "images/rmf-logo.gif"
        imagePath = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "") & "\images\reliance-mutual-fund.png"

        Response.Write("<IMG  src='" & imagePath & "' width='410' height='55' border='0'>")
        Response.Write("<br>")

        '''imagePath1 = "http://localhost/RelianceSIP/images/toplinks01_bg.gif"
        '''Response.Write("<IMG  src='" & imagePath1 & "' width='755' height='20' border='0'>")
        Response.Write("<br>")
        'Response.Write("<br>")
        TransAmt = "STP :" & "Rs." & rs & "/- To be Tranferred " & " " & period
        ToShc = "Transferor  :" & L1
        FromSch = "Transferee  :" & L2
        Response.Write("<b><font size=1.5 face=verdana color=#000000>" & "" & TransAmt & "" & " </b> </font>")
        Response.Write("<br>")
        Response.Write("<b><font size=1.5 face=verdana color=#000000>" & "" & ToShc & "" & " </b> </font>")
        Response.Write("<br>")
        Response.Write("<b><font size=1.5 face=verdana color=#000000>" & "" & FromSch & "" & " </b> </font>")
        Response.Write("<br>")
        Response.Write("<br>")
        Response.Write("<font size=1 face=Arial>")
        htmlWrite = New HtmlTextWriter(stringWrite)
        dgrid.RenderControl(htmlWrite)
        Response.Write(stringWrite.ToString())

        Response.Write("<br>")

        '//Export summary report

        stringWrite2 = New System.IO.StringWriter
        htmlWrite2 = New HtmlTextWriter(stringWrite2)
        Response.Write("<br>")
        htmlWrite = New HtmlTextWriter(stringWrite)
        dgrid2.RenderControl(htmlWrite2)
        Response.Write(stringWrite2.ToString())


        Response.Write("<br>")
        Returns = "Value of balance units in transferor scheme : " & p1
        Returns1 = "Value of Accumulated units in transferee scheme : " & p2
        Xirr = "Hence Yield from STP investment is (%) :" & p3

        Response.Write("<br>")
        'Response.Write("<b><font size=1.5 face=verdana color=#000000>" & "" & Returns & "" & " </b> </font>")
        Response.Write("<b><div width ='600px' style='font-family:Arial; color:black; font-size:15px;'>" & Returns & "</div></b>")
        Response.Write("<br>")
        'Response.Write("<b><font size=1.5 face=verdana color=#000000>" & "" & Returns1 & "" & " </b> </font>")
        Response.Write("<b><div width ='600px' style='font-family:Arial; color:black; font-size:15px;'>" & Returns1 & "</div></b>")
        Response.Write("<br>")
        'Response.Write("<b><font size=1.5 face=verdana color=#000000>" & "" & Xirr & "" & " </b> </font>")
        Response.Write("<b><div width ='600px' style='font-family:Arial; color:black; font-size:15px;'>" & Xirr & "</div></b>")

        '//Vishal to Save chart image in excel'
        ''commented by syed
        'Dim chartImagePath As String
        'If HttpContext.Current.Session("STP_Chart_Image") <> "" Then
        '    chartImagePath = HttpContext.Current.Session("BaseUrl") & "/" & "WebCharts/" & HttpContext.Current.Session("STP_Chart_Image") & ".png"
        '    Response.Write("<IMG  src='" & chartImagePath & "' width='450' height='250' border='0'>")
        '    Response.Write("<br>")
        'End If
        '' end commented
        If HttpContext.Current.Session("All_Chart_Image") <> "" Then
            'chartImagePath = HttpContext.Current.Session("BaseUrl") & "/" & "WebCharts/" & HttpContext.Current.Session("STP_Chart_Image") & ".png"
            Response.Write("<IMG  src='" & HttpContext.Current.Session("All_Chart_Image") & "' width='700' height='420' border='0'>")
            Response.Write("<br>")
        End If
        ''HttpContext.Current.Session("SIP_Chart_Image")
        'Response.Write("<br><b><left><font size=1.5 face=verdana color=#ff0000> " & disclaimer1 & "</font></left></b>")
        Response.Write("<br>")
        Response.Write("<b><div width ='600px' style='font-family:Arial; color:black; font-size:14px;'>" & Notes & "</div></b>")

        Response.Write("<br>")
        Response.Write("<b><div width ='600px' style='font-family:Arial; color:red; font-size:14px;'>" & disclaimer1 & "</div></b>")
        Response.Write("<table align='top'><tr  style='vertical-align:top' height=9 style='height:9.0pt'><td colspan=6 rowspan=5 height=54 class=xl40 width=400 style='height:60.0pt;width:700pt'><font size=2 face=Arial color='black'>" & disclaimer & "</font></TD></tr><table>")

        'Response.Write("<div width='600px' style='font-family:Arial; color:black; font-size:15px;'>" & disclaimer & "</div>")
        'Response.Write("<div width='300px' style='font-family:Arial; color:black; font-size:13px;'>" & disclaimer & "</div>")
        Response.End()
    End Sub

    Public Sub SaveToExcel_RETURNS(ByVal Response As HttpResponse, ByVal dgrid As DataGrid, Optional ByVal p1 As String = "", Optional ByVal p2 As String = "", Optional ByVal p3 As String = "", Optional ByVal sch As String = "", Optional ByVal bmark As String = "", Optional ByVal Ent_Load As String = "", Optional ByVal FROM_DATE As String = "", Optional ByVal TO_DATE As String = "")
        Dim stringWrite As System.IO.StringWriter
        Dim htmlWrite As System.Web.UI.HtmlTextWriter

        Dim stringWrite2 As System.IO.StringWriter
        Dim htmlWrite2 As System.Web.UI.HtmlTextWriter
        Dim dgrid1 As New DataGrid
        Dim Filename As String
        Dim font_Size As Integer = 8
        Dim address1 As String
        Dim Returns As String
        Dim Xirr As String
        Dim Xirr1 As String
        Dim Sch_Name As String
        Dim B_Mark As String
        Dim E_Load As String
        Dim i As Integer


        Dim disclaimer As String
        Dim disclaimer1 As String
        disclaimer1 = "Disclaimer :"

        'disclaimer = "Risk factors: The above compilation is not intended as advice. The information therein is furnished without liability for any inaccuracy.This compilation does not entitle any person to any claim in respect of any liability or consequence of anything done, or omitted to be done, by any such person in reliance upon the contents thereof.This is not an offer for invitation for subscriptions to units of Reliance Mutual Fund schemes. For further details please refer to offer document and load structure before investing. Past performance may or may not be sustained in future. Generated by icraonline.com "
        disclaimer = "<div style='text-align:justify'>
                    <p class='txt2' style='font-size: 13px; text-align: justify; line-height: 16px;'>Copyright 2017 Nippon India Mutual Fund. All Rights Reserved.<br>

                       Nippon India Mutual Fund does not take the responsibility, liability and undertake the authenticity of the figures calculated on the basis of calculator provided herein for calculations towards prospective investments.Developed and Maintained by ICRA Analytics Limited. The data content provided is obtained from sources considered to be authentic and reliable. However, ICRA Analytics Limited is not responsible for any error or inaccuracy or for any losses suffered on account of information.</p>
                            <p class='txt2' style='font-size: 13px; text-align: justify; line-height: 16px;'>The Calculators/Tools/Planners are designed to assist you in determining the appropriate amount. These Calculators/Tools/Planners alone are not sufficient and should not be used for the development or implementation of an investment strategy. The investor is advised to consult his or her financial advisor prior to arriving at any investment decision.
                                                        </p>
                    </div>"

        Dim imagePath As String
        Dim imagePath1 As String

        If dgrid.Items.Count < 1 Then
            Exit Sub
        End If

        '//data grid formatting before exporting
        dgrid.Font.Name = "Arial"
        dgrid.Font.Size = System.Web.UI.WebControls.FontUnit.Point(8)
        dgrid.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid
        dgrid.HeaderStyle.BackColor = System.Drawing.Color.Red
        dgrid.HeaderStyle.ForeColor = System.Drawing.Color.White
        dgrid.HeaderStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
        dgrid.HeaderStyle.Wrap = False
        dgrid.HeaderStyle.Font.Bold = True
        dgrid.GridLines = GridLines.Both
        dgrid.BorderColor = System.Drawing.Color.LightGray
        dgrid.BorderWidth = New Unit(1, UnitType.Pixel)
        dgrid.Items(0).Width = New Unit(CDbl(200))
        '''For i = 0 To ColCount - 1
        '''    dgrid.Items(i).Width = New Unit(CDbl(100))
        '''Next

        'dgrid.Width = New Unit(CDbl(170))

        Filename = "NipponIndiaLumsum" & ".xls"

        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=" & Filename)
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.xls"
        stringWrite = New System.IO.StringWriter
        '//write image

        'imagePath = HttpContext.Current.Session("BaseUrl") & "/" & "images/rmf_logo01.gif"
        'imagePath = HttpContext.Current.Server.MapPath("~") & "/" & "images/rmf-logo.gif"
        imagePath = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "") & "\images\reliance-mutual-fund.png"

        Response.Write("<IMG  src='" & imagePath & "'width='410' height='55' border='0'>")

        Response.Write("<br>")

        '''imagePath1 = "http://localhost/RelianceSIP/images/toplinks01_bg.gif"
        '''Response.Write("<IMG  src='" & imagePath1 & "' width='720' height='20' border='0'>")
        Response.Write("<br>")
        Response.Write("<br>")

        Sch_Name = "Scheme " & " : " & sch
        B_Mark = "Benchmark Index " & " : " & bmark
        E_Load = "Entry Load " & " : " & Ent_Load

        Response.Write("<b><font size='1.5' face='verdana' color='#000000'>" & "" & Sch_Name & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & "" & " </b> </font>")
        'Response.Write("<b><font size=1 face=verdana color=#000000>" & "" & E_Load & "" & " </b> </font>")
        Response.Write("<br>")
        Response.Write("<b><font size='1.5' face='verdana' color='#000000'>" & "" & B_Mark & "" & " </b> </font>")
        Response.Write("<br>")
        '//PRINT FROM DATE AND TO_DATE
        If FROM_DATE <> "" And TO_DATE <> "" Then
            Response.Write("<b><font size='1.5' face='verdana' color='#000000'>Returns for period " & FROM_DATE & " to " & TO_DATE & " </b> </font><br>")
        End If
        Response.Write("<br>")




        'Response.Write("<font size=1 face=Arial>")
        htmlWrite = New HtmlTextWriter(stringWrite)
        dgrid.RenderControl(htmlWrite)
        Response.Write(stringWrite.ToString())


        ' Response.Write("<br>")
        Returns = "Abs. Return (Scheme): " & p1
        Xirr = "Yield (Scheme): " & p2
        Xirr1 = "Yield (Index): " & p3

        Response.Write("<br>")
        '''Response.Write("<b><font size=1 face=verdana color=#000000>" & "" & Returns & "" & " </b> </font>")
        '''Response.Write("<br>")
        '''Response.Write("<b><font size=1 face=verdana color=#000000>" & "" & Xirr & "" & " </b> </font>")

        '''Response.Write("<br>")
        '''Response.Write("<b><font size=1 face=verdana color=#000000>" & "" & Xirr1 & "" & " </b> </font>")
        stringWrite2 = New System.IO.StringWriter

        '//Vishal to Save chart image in excel'
        Dim chartImagePath As String
        ''commented by syed
        'If HttpContext.Current.Session("All_Chart_Image") <> "" Then
        '    chartImagePath = HttpContext.Current.Session("BaseUrl") & "/" & "WebCharts/" & HttpContext.Current.Session("All_Chart_Image") & ".png"
        '    Response.Write("<IMG  src='" & chartImagePath & "' width='450' height='250' border='0'>")
        '    Response.Write("<br>")
        'End If


        Response.Write("<br><b><left><font size='1.5' face='verdana' color='#ff0000'> " & disclaimer1 & "</font></left></b>")
        Response.Write("<br>")
        'Response.Write("<table align=top  width=1000 height=40><tr height=40 width=1000 ><td rowspan=6 height=40  width=1000 ><font size=1 face=Arial color='black'>" & disclaimer & "</font></TD></tr><table>")

        'Response.Write("<table align=top><tr height=9 style='height:9.0pt'><td colspan=6 rowspan=5 height=54 class=xl40 width=450 style='height:54.0pt;width:450pt'><font size=1 face=Arial color='black'>" & disclaimer & "</font></TD></tr><table>")
        Response.Write("<div width='600px' style='font-family:Arial; color:black; font-size:15px;'>" & disclaimer & "</div>")

        Response.End()
    End Sub

    Public Sub SaveToExcel_RETURNS2(ByVal Response As HttpResponse, ByVal dgrid As DataGrid, Optional ByVal p1 As String = "", Optional ByVal p2 As String = "", Optional ByVal p3 As String = "", Optional ByVal sch As String = "", Optional ByVal bmark As String = "", Optional ByVal Ent_Load As String = "", Optional ByVal FROM_DATE As String = "", Optional ByVal TO_DATE As String = "")
        Dim workbook As New XSSFWorkbook()

        Dim sheet As XSSFSheet = workbook.CreateSheet("Lumsum Report")

        For i As Integer = 0 To 12
            sheet.SetColumnWidth(i, 20 * 256)
        Next

        'Set Header Style
        Dim Style As XSSFCellStyle = workbook.CreateCellStyle()
        Dim headerFont As XSSFFont = workbook.CreateFont
        headerFont.FontName = "Calibri"
        headerFont.IsBold = True
        headerFont.FontHeight = 12
        Style.SetFont(headerFont)


        sheet.DisplayGridlines = False

        Dim AllCellStyleEven As XSSFCellStyle = CType(workbook.CreateCellStyle(), XSSFCellStyle)
        AllCellStyleEven.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin
        AllCellStyleEven.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
        AllCellStyleEven.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin
        AllCellStyleEven.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin
        Dim colorToFillEven As XSSFColor = New XSSFColor(New Byte() {255, 230, 230})
        AllCellStyleEven.SetFillForegroundColor(colorToFillEven)
        AllCellStyleEven.FillPattern = FillPattern.SolidForeground
        AllCellStyleEven.Alignment = HorizontalAlignment.Center
        AllCellStyleEven.VerticalAlignment = VerticalAlignment.Center


        Dim AllCellStyleOdd As XSSFCellStyle = CType(workbook.CreateCellStyle(), XSSFCellStyle)
        AllCellStyleOdd.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin
        AllCellStyleOdd.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
        AllCellStyleOdd.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin
        AllCellStyleOdd.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin
        Dim colorToFillOdd As XSSFColor = New XSSFColor(New Byte() {255, 255, 255})
        AllCellStyleOdd.SetFillForegroundColor(colorToFillOdd)
        AllCellStyleOdd.FillPattern = FillPattern.SolidForeground
        AllCellStyleOdd.Alignment = HorizontalAlignment.Center
        AllCellStyleOdd.VerticalAlignment = VerticalAlignment.Center


        Dim headerStyle As XSSFCellStyle = CType(workbook.CreateCellStyle(), XSSFCellStyle)
        Dim colorToFill As New XSSFColor(New Byte() {255, 0, 0})
        Dim back As New XSSFColor(New Byte() {255, 0, 0})
        headerStyle.SetFillForegroundColor(colorToFill)
        Dim font As IFont = workbook.CreateFont()
        font.Color = IndexedColors.White.Index
        font.Boldweight = FontBoldWeight.Bold

        headerStyle.SetFont(font)
        headerStyle.FillPattern = FillPattern.SolidForeground
        headerStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin
        headerStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
        headerStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin
        headerStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin
        headerStyle.Alignment = HorizontalAlignment.Center
        headerStyle.VerticalAlignment = VerticalAlignment.Center


        ' Create Row and add Logo
        Dim logoPath As String
        Dim GraphImgPath As String

        logoPath = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "") & "/images/reliance-mutual-fund.png"

        If Not String.IsNullOrEmpty(logoPath) Then

            Dim patriarch As XSSFDrawing = CType(sheet.CreateDrawingPatriarch(), XSSFDrawing)
            Dim anchor As XSSFClientAnchor
            anchor = New XSSFClientAnchor(0, 0, 0, 255, 0, 0, 0, 3)

            anchor.AnchorType = AnchorType.DontMoveAndResize

            Dim picture As XSSFPicture = CType(patriarch.CreatePicture(anchor, LoadImage(logoPath, workbook, PictureType.PNG)), XSSFPicture)

            Dim x1 As Double = 3
            Dim y1 As Double = 1
            picture.Resize(x1, y1)
            picture.LineStyle = LineStyle.None

        End If

        Dim itrRow As Int16 = 5

        Dim ProfileRow As IRow = sheet.CreateRow(itrRow)
        ProfileRow.CreateCell(0).SetCellValue("Scheme Name      : ")
        ProfileRow.CreateCell(1).SetCellValue(sch)
        ProfileRow.GetCell(0).CellStyle = Style
        ProfileRow.GetCell(1).CellStyle = Style
        itrRow = itrRow + 1

        If (Not String.IsNullOrEmpty(Ent_Load)) Then

            ProfileRow = sheet.CreateRow(itrRow)
            ProfileRow.CreateCell(0).SetCellValue("Entry Load            : ")
            ProfileRow.CreateCell(1).SetCellValue(Ent_Load)
            ProfileRow.GetCell(0).CellStyle = Style
            ProfileRow.GetCell(1).CellStyle = Style
            itrRow = itrRow + 1
        End If

        ProfileRow = sheet.CreateRow(itrRow)
        ProfileRow.CreateCell(0).SetCellValue("Benchmark Index : ")
        ProfileRow.CreateCell(1).SetCellValue(bmark)
        ProfileRow.GetCell(0).CellStyle = Style
        ProfileRow.GetCell(1).CellStyle = Style
        itrRow = itrRow + 1


        If FROM_DATE <> "" And TO_DATE <> "" Then
            ProfileRow = sheet.CreateRow(itrRow)
            ProfileRow.CreateCell(0).SetCellValue("Returns for period " & FROM_DATE & " to " & TO_DATE & " ")
            ProfileRow.GetCell(0).CellStyle = Style
            itrRow = itrRow + 1
        End If

        Dim HeaderList As String() = New String(3) {}
        HeaderList(0) = "Scheme Return"
        HeaderList(1) = "Index Return"
        HeaderList(2) = "Value of Investment"
        HeaderList(3) = "Gain From Investment"




        'Header creation in the Excel
        itrRow = itrRow + 1
        Dim headerRow As IRow = sheet.CreateRow(itrRow)
        Dim itrCol As Int16 = 0

        For Each col As String In HeaderList
            Dim cell As ICell = headerRow.CreateCell(itrCol)
            cell.SetCellValue(col)
            cell.CellStyle = headerStyle
            'AutoFitColumn(sheet, itrCol)
            itrCol = itrCol + 1
        Next

        Dim flag As Int16 = 0
        For Each row As DataGridItem In dgrid.Items
            itrRow = itrRow + 1
            Dim DataRow As IRow = sheet.CreateRow(itrRow)

            itrCol = 0
            flag = 0

            For Each cell As TableCell In row.Cells

                Dim datacell As ICell = DataRow.CreateCell(itrCol)
                datacell.SetCellValue(If(cell.Text = "&nbsp;", "", cell.Text))
                'AutoFitColumn(sheet, itrCol)
                If (itrRow Mod 2 = 0) Then
                    datacell.CellStyle = AllCellStyleEven
                Else
                    datacell.CellStyle = AllCellStyleOdd
                End If

                itrCol = itrCol + 1
                flag = flag + 1

            Next


            itrRow = itrRow + 1

        Next

        itrRow = itrRow + 1

        If (Not String.IsNullOrEmpty(p1) AndAlso Not String.IsNullOrEmpty(p2) AndAlso String.IsNullOrEmpty(p3)) Then
            Dim PercentageData As IRow = sheet.CreateRow(itrRow)
            PercentageData.CreateCell(0).SetCellValue("Abs. Return (Scheme) ")
            PercentageData.CreateCell(1).SetCellValue(p1)
            'PercentageData.GetCell(0).CellStyle = AllCellStyleEven
            'PercentageData.GetCell(1).CellStyle = AllCellStyleEven

            itrRow = itrRow + 1
            PercentageData = sheet.CreateRow(itrRow)
            PercentageData.CreateCell(0).SetCellValue("Yield (Scheme)              ")
            PercentageData.CreateCell(1).SetCellValue(p2)
            'PercentageData.GetCell(0).CellStyle = AllCellStyleEven
            'PercentageData.GetCell(1).CellStyle = AllCellStyleEven

            itrRow = itrRow + 1
            PercentageData = sheet.CreateRow(itrRow)
            PercentageData.CreateCell(0).SetCellValue("Yield (Index)                   ")
            PercentageData.CreateCell(1).SetCellValue(p3)
            'PercentageData.GetCell(0).CellStyle = AllCellStyleEven
            'PercentageData.GetCell(1).CellStyle = AllCellStyleEven
            'AutoFitColumn(sheet, 0)
            'AutoFitColumn(sheet, 1)
            itrRow = itrRow + 2
        End If




        'If HttpContext.Current.Session("All_Chart_Image") <> "" Then
        '    GraphImgPath = HttpContext.Current.Session("All_Chart_Image")
        'End If

        'If (Not String.IsNullOrEmpty(GraphImgPath)) Then
        '    Dim patriarch As XSSFDrawing = CType(sheet.CreateDrawingPatriarch(), XSSFDrawing)
        '    Dim anchor As XSSFClientAnchor
        '    anchor = New XSSFClientAnchor(0, 0, 0, 255, 0, itrRow, 0, itrRow + 12)

        '    anchor.AnchorType = AnchorType.DontMoveAndResize

        '    Dim picture As XSSFPicture = CType(patriarch.CreatePicture(anchor, LoadImage(GraphImgPath, workbook, PictureType.PNG)), XSSFPicture)

        '    Dim x1 As Double = 6
        '    Dim y1 As Double = 1.75
        '    picture.Resize(x1, y1)
        '    picture.LineStyle = LineStyle.None
        'End If

        'itrRow = itrRow + 13 + 8

        'Dim _Notes As String = Notes

        'Dim IndexOfSplitString As Int16 = _Notes.IndexOf("Yield")

        'Dim TagName1 As String = "</u>"
        'Dim TagName2 As String = "</p>"

        'Dim note As IRow = sheet.CreateRow(itrRow)
        'note.CreateCell(0).SetCellValue("Notes          ")
        'note.GetCell(0).CellStyle = Style
        'Dim array As String() = Notes.Split("".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
        'Dim sortNote As String = array(1).TrimStart(TagName1.ToCharArray()).TrimEnd(TagName2.ToCharArray()).Trim()
        'note.CreateCell(1).SetCellValue(sortNote.Substring(0, IndexOfSplitString - 17))
        'itrRow = itrRow + 1

        'note = sheet.CreateRow(itrRow)
        'note.CreateCell(1).SetCellValue(sortNote.Substring(IndexOfSplitString - 17))
        'itrRow = itrRow + 1


        Dim Disclaimer As IRow = sheet.CreateRow(itrRow)
        Disclaimer.CreateCell(0).SetCellValue("Disclaimer ")
        Disclaimer.GetCell(0).CellStyle = Style
        Disclaimer.CreateCell(1).SetCellValue("Copyright 2017 Nippon India Mutual Fund. All Rights Reserved.")
        itrRow = itrRow + 1

        Disclaimer = sheet.CreateRow(itrRow)
        Disclaimer.CreateCell(1).SetCellValue("Nippon India Mutual Fund does Not take the responsibility, liability And undertake the authenticity of the figures calculated on the basis of calculator provided herein for calculations towards prospective investments.Developed And Maintained by")
        itrRow = itrRow + 1



        Dim HyperLinkStyle As XSSFCellStyle = CType(workbook.CreateCellStyle(), XSSFCellStyle)
        Dim HyperLinkFont As IFont = workbook.CreateFont()
        HyperLinkFont.Color = IndexedColors.Blue.Index
        HyperLinkFont.Underline = FontUnderlineType.Single
        HyperLinkStyle.SetFont(HyperLinkFont)
        Disclaimer = sheet.CreateRow(itrRow)
        Disclaimer.CreateCell(1).SetCellValue("ICRA Analytics Limited")
        Dim createHelper As XSSFCreationHelper = CType(workbook.GetCreationHelper(), XSSFCreationHelper)
        Dim link As XSSFHyperlink = CType(createHelper.CreateHyperlink(HyperlinkType.Url), XSSFHyperlink)
        link.Address = "https//www.icraanalytics.com/"
        Disclaimer.GetCell(1).Hyperlink = link
        Disclaimer.GetCell(1).CellStyle = HyperLinkStyle
        itrRow = itrRow + 1



        Disclaimer = sheet.CreateRow(itrRow)
        Disclaimer.CreateCell(1).SetCellValue("The data content provided Is obtained from sources considered to be authentic And reliable. However, ICRA Analytics Limited Is Not responsible for any error Or inaccuracy Or for any losses suffered on account of information.")
        itrRow = itrRow + 1

        Disclaimer = sheet.CreateRow(itrRow)
        Disclaimer.CreateCell(1).SetCellValue("The Calculators/Tools/Planners are designed to assist you in determining the appropriate amount. These Calculators/Tools/Planners alone are Not sufficient And shouldn't be used for the development or implementation of an investment strategy.")
        itrRow = itrRow + 1

        Disclaimer = sheet.CreateRow(itrRow)
        Disclaimer.CreateCell(1).SetCellValue("The investor is advised to consult his or her financial advisor prior to arriving at any investment decision.")
        itrRow = itrRow + 1

        Using memoryStream As New MemoryStream()
            workbook.Write(memoryStream)
            Response.Clear()
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.AddHeader("Content-Disposition", "attachment; filename = NipponIndiaLumsum.xlsx")
            Response.BinaryWrite(memoryStream.ToArray())
            Response.End()


        End Using

    End Sub



End Module



