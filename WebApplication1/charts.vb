Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Text.RegularExpressions
Imports WebChart
Imports System.Drawing

Module charts_WebCharts
    Public min, max, mean As Double
    Public xCount As Double
    Public ageInDays As Double
    ''Public Const scolor As String = "0000cd,f08080,9400d3,3cb371,ff4500,ffa07a,708090,87cefa,000000,00ff7f,d"
    Public Const scolor As String = "ffd700,4682b4,d6143C,228b22,8b008b,00fa9a,ffb4a5,1e90ff,db7093,808080,daa520,708090,f4a460,bc8f8f,c0c0c0,ffff00,20b2aa,da70d6,ff1493,d8bfd8,5f9ea0,ff6347"
    Public selectedSchemeList As String
    Public selectedIndexList As String
    Public retColStartIndex As Integer


    Public Function ClearHTMLTags(ByVal strHTML)
        Dim regExObj 'As Regex
        Dim strTagLess
        Try
            strTagLess = strHTML
            regExObj = New Regex("<[^>]*>")
            'this pattern mathces any html tag
            strTagLess = regExObj.Replace(strTagLess, "")

            regExObj = New Regex("&nbsp;")
            strTagLess = regExObj.Replace(strTagLess, "")
            regExObj = Nothing
            ClearHTMLTags = strTagLess
        Catch e1 As Exception
        Finally
        End Try
    End Function
    Sub showChart(ByRef sipChart As WebChart.ChartControl, ByVal dtable As DataTable)
        Dim ds As DataSet = GetDataSet(dtable)
        Dim view As DataView = ds.Tables(0).DefaultView
        Dim SeriesCount As Integer
        Dim i As Integer
        Dim rnd As Random
        Dim cCOLOR As New Color
        Dim sAlpha, sRed, sGreen, sBlue As Integer



        rnd = New Random(50)

        Dim min1, max1, mean1 As Double

        '//assign data series
        sAlpha = 255 : sRed = 0 : sGreen = 0 : sBlue = 0
        Dim chart() As SmoothLineChart
        SeriesCount = ds.Tables(0).Columns.Count
        xCount = ds.Tables(0).Rows.Count
        ReDim Preserve chart(SeriesCount)

        sipChart.Legend.Position = LegendPosition.Right
        sipChart.Legend.Width = 30
        For i = 1 To SeriesCount - 1
            chart(i) = New SmoothLineChart

            'sRed = rnd.Next Mod 255
            'sGreen = rnd.Next Mod 255
            'sBlue = rnd.Next Mod 255

            sRed = Int32.Parse(Mid(Split(scolor, ",")(i - 1), 1, 2), Globalization.NumberStyles.HexNumber)
            sGreen = Int32.Parse(Mid(Split(scolor, ",")(i - 1), 3, 2), Globalization.NumberStyles.HexNumber)
            sBlue = Int32.Parse(Mid(Split(scolor, ",")(i - 1), 5, 2), Globalization.NumberStyles.HexNumber)
            chart(i).Line.Color = cCOLOR.FromArgb(sAlpha, sRed, sGreen, sBlue)
            chart(i).Fill.Color = cCOLOR.FromArgb(sAlpha, sRed, sGreen, sBlue)
            chart(i).Line.Width = 2

            chart(i).Legend = Left(view.Table.Columns(i).ColumnName, InStr(view.Table.Columns(i).ColumnName, "_") - 1)
            chart(i).DataSource = view
            chart(i).DataXValueField = view.Table.Columns(0).ColumnName
            chart(i).DataYValueField = view.Table.Columns(i).ColumnName
            chart(i).DataBind()
            sipChart.Charts.Add(chart(i))
            chart(i).ShowLineMarkers = False
            chart(i).GetMinMaxMeanValue(min1, max1, mean1)
            If i = 1 Then
                min = min1
                max = max1
                mean = mean1
            Else
                min = IIf(min1 < min, min1, min)
                max = IIf(max1 > max, max1, max)
                mean = IIf(mean1 < mean1, mean1, mean1)
            End If

        Next
        configureAxis(sipChart)
        ConfigureColors(sipChart)
        sipChart.Height = New Unit(298)
        sipChart.Width = New Unit(544)
        sipChart.RedrawChart()

        sipChart.Visible = True
    End Sub
    Private Function GetDataSet(ByVal table As DataTable) As DataSet
        Dim i As Integer
        Dim j As Integer
        Dim seriesIndex As Integer = 0
        Dim ds As New DataSet
        Dim index_names() As String
        Dim sch_names() As String

        sch_names = Split(selectedSchemeList, ",")
        index_names = Split(selectedIndexList, ",")

        retColStartIndex = table.Columns.IndexOf("Nav_ret")
        '''For i = 0 To retColStartIndex - 1
        '''    table.Columns.RemoveAt(0)
        '''Next
        ''table.Columns.RemoveAt(table.Columns.IndexOf("Scheme"))
        ''table.Columns.RemoveAt(table.Columns.IndexOf("Nav"))
        If selectedSchemeList <> "" Then
            For i = 0 To UBound(sch_names)
                table.Columns.RemoveAt(table.Columns.IndexOf(Trim(sch_names(i))))
            Next
        End If

        For i = 0 To UBound(index_names)
            If table.Columns.IndexOf(Trim(index_names(i))) > 0 Then
                table.Columns.RemoveAt(table.Columns.IndexOf(Trim(index_names(i))))
            End If
            If table.Columns.IndexOf(Trim(index_names(i) & "_open")) > 0 Then
                table.Columns.RemoveAt(table.Columns.IndexOf(Trim(index_names(i) & "_open")))
            End If
            If table.Columns.IndexOf(Trim(index_names(i) & "_high")) > 0 Then
                table.Columns.RemoveAt(table.Columns.IndexOf(Trim(index_names(i) & "_high")))
            End If
            If table.Columns.IndexOf(Trim(index_names(i) & "_low")) > 0 Then
                table.Columns.RemoveAt(table.Columns.IndexOf(Trim(index_names(i) & "_low")))
            End If
        Next
        '//format date
        For i = 0 To table.Rows.Count - 1
            If ageInDays < 180 Then
                If IsDate(fmt(table.Rows(i)(0))) Then
                    table.Rows(i)(0) = Format(CDate(fmt(Trim(table.Rows(i)(0)))), "dd-MMM-yy")
                End If
            ElseIf ageInDays > 180 Then
                If IsDate(fmt(table.Rows(i)(0))) Then
                    table.Rows(i)(0) = Format(CDate(fmt(Trim(table.Rows(i)(0)))), "MMM-yy")
                End If
            End If
        Next

        '//
        For i = 1 To table.Rows.Count - 1
            For j = 1 To table.Columns.Count - 1
                If IsDBNull(table.Rows(i)(j)) Then
                    table.Rows(i)(j) = table.Rows(i - 1)(j)
                    table.Rows(i)(j) = IIf(IsDBNull(table.Rows(i)(j)), table.Rows(i - 1)(j), table.Rows(i)(j))
                End If
            Next
        Next

        ds.Tables.Add(table)
        Return ds
    End Function
    Sub ConfigureColors(ByRef sipChart As WebChart.ChartControl)
        sipChart.ForeColor = Color.Gray
        ''sipChart.Background.Color = Color.FromArgb(Int32.Parse("CCE1FF", Globalization.NumberStyles.HexNumber))
        ''sipChart.Background.Color = Color.FromArgb(Int32.Parse("CC", Globalization.NumberStyles.HexNumber), Int32.Parse("E1", Globalization.NumberStyles.HexNumber), Int32.Parse("FF", Globalization.NumberStyles.HexNumber))
        'commented by syed
        'sipChart.Background.Color = Color.DarkBlue
        'sipChart.Background.Color = Color.White
        sipChart.Background.Type = InteriorType.Solid
        sipChart.GridLines = GridLines.Horizontal


        sipChart.Background.ForeColor = Color.Yellow
        sipChart.Background.EndPoint = New Point(500, 350)
        'sipChart.Legend.Width = 0
        'changed by syed

        'sipChart.Legend.Width = 100
        'sipChart.Legend.
        'changed by syed
        'sipChart.Legend.Background.Color = Color.White
        sipChart.Legend.Background.Color = System.Drawing.ColorTranslator.FromHtml("#eaedf2")

        sipChart.Legend.Border.DashStyle = Drawing2D.DashStyle.Solid

        sipChart.YAxisFont.ForeColor = Color.Black
        sipChart.XAxisFont.ForeColor = Color.Black

        'sipChart.ChartTitle.Text = "NAV vs Index"
        'sipChart.ChartTitle.ForeColor = Color.Tomato

        sipChart.Border.Color = System.Drawing.ColorTranslator.FromHtml("#eaedf2")
        sipChart.BorderStyle = BorderStyle.None
    End Sub
    Sub configureAxis(ByVal sipChart As WebChart.ChartControl, Optional ByVal XInterval As Double = 12, Optional ByVal YInterval As Double = 100, Optional ByVal gtype As String = "SIP")
        '''''If XInterval > 12 Then
        '''''    sipChart.XTicksInterval = Math.Round((xCount / 12))
        '''''    sipChart.XValuesInterval = Math.Round((xCount / 12))
        '''''Else
        '''''    sipChart.XTicksInterval = Math.Round((xCount))
        '''''    sipChart.XValuesInterval = Math.Round((xCount))
        '''''End If

        '//x axis marking font
        sipChart.XAxisFont.StringFormat.Alignment = StringAlignment.Far
        '//y axis marking font
        sipChart.YAxisFont.StringFormat.Alignment = StringAlignment.Near
        sipChart.YAxisFont.StringFormat.FormatFlags = StringFormatFlags.DisplayFormatControl

        sipChart.XTicksInterval = 1
        sipChart.XValuesInterval = 1


        '''''''sipChart.YCustomStart = min
        ''''''Dim i As Integer
        ''''''Dim multiplier As Integer = 10
        ''''''Dim LastValue As Integer = 100
        ''''''For i = 1 To 10
        ''''''    If max < (LastValue * multiplier) / 2 Then
        ''''''        max = LastValue * multiplier / 2
        ''''''        Exit For
        ''''''    End If
        ''''''    If max < (LastValue * multiplier) Then
        ''''''        max = LastValue * multiplier
        ''''''        Exit For
        ''''''    End If
        ''''''Next
        sipChart.YCustomEnd = max

        'sipChart.YCustomEnd = max + 5
        'sipChart.YValuesInterval = Math.Round((max - min) / 10) + 1
        Dim INTERVAL_NUMBER As Integer
        Dim INTERVAL_MULTIPLICANT As Integer
        If gtype = "SIP" Then
            sipChart.YCustomStart = 0
            INTERVAL_NUMBER = Math.Round(max / YInterval)
            INTERVAL_MULTIPLICANT = 1
            INTERVAL_MULTIPLICANT = INTERVAL_NUMBER / 10
            sipChart.YValuesInterval = YInterval * INTERVAL_MULTIPLICANT

            '''''If Math.Round(max / YInterval) > 20 Then
            '''''    sipChart.YValuesInterval = YInterval * 3
            '''''ElseIf Math.Round(max / YInterval) > 10 Then
            '''''    sipChart.YValuesInterval = YInterval * 2
            '''''Else
            '''''    sipChart.YValuesInterval = YInterval
            '''''End If
        ElseIf gtype = "SWP" Then
            sipChart.YCustomStart = 0

            INTERVAL_NUMBER = Math.Round(max / YInterval)
            INTERVAL_MULTIPLICANT = 1
            INTERVAL_MULTIPLICANT = INTERVAL_NUMBER / 10
            sipChart.YValuesInterval = YInterval * INTERVAL_MULTIPLICANT


            '''''If INTERVAL_NUMBER > 20 Then
            '''''    sipChart.YValuesInterval = YInterval * 3
            '''''ElseIf INTERVAL_NUMBER > 10 Then
            '''''    sipChart.YValuesInterval = YInterval * 2
            '''''Else
            '''''    sipChart.YValuesInterval = YInterval
            '''''End If
        Else
            sipChart.YCustomStart = 0
            INTERVAL_NUMBER = Math.Round(max / YInterval)
            INTERVAL_MULTIPLICANT = 1
            INTERVAL_MULTIPLICANT = INTERVAL_NUMBER / 10
            sipChart.YValuesInterval = YInterval * INTERVAL_MULTIPLICANT


            ''sipChart.YValuesInterval = (max - min) / 8

            '''If Math.Round(max / YInterval) > 20 Then
            '''    sipChart.YValuesInterval = YInterval * 3
            '''ElseIf Math.Round(max / YInterval) > 10 Then
            '''    sipChart.YValuesInterval = YInterval * 2
            '''Else
            '''    sipChart.YValuesInterval = YInterval
            '''End If
        End If


        sipChart.ShowYValues = True
        sipChart.ShowXValues = True
    End Sub
    Public Sub formatTable4Chart(ByRef dtChart As DataTable, Optional ByVal removeBlankRows As Boolean = True, Optional ByVal removeBottomRows As Integer = 0, Optional ByVal removeEndColumns As Integer = 0, Optional ByVal clearHtml As Boolean = False, Optional ByVal removeBlanknDash As Boolean = True, Optional ByVal removeNamedColumn As String = "", Optional ByVal keepNamedColumn As String = "", Optional ByVal ADD_IDENTITY_COLUMN As Boolean = True)
        Dim i, j As Integer
        Dim deleted As Integer
        Dim deleteCurrentRow As Boolean
        Try
            If removeEndColumns > 0 And dtChart.Columns.Count > 0 Then  '//remove end columns 
                For i = 0 To dtChart.Columns.Count - 1 - deleted
                    If removeEndColumns = 0 Then
                        Exit For
                    End If
                    dtChart.Columns.RemoveAt(dtChart.Columns.Count - 1)
                    removeEndColumns = removeEndColumns - 1
                    '''If (i - deleted) > 1 Then
                    '''    dtChart.Columns.RemoveAt(i - deleted)
                    '''    deleted = deleted + 1
                    '''    removeEndColumns = removeEndColumns - 1
                    '''End If
                Next
            End If
            '//remove named column
            If removeNamedColumn <> "" Then
                Dim columnName() As String
                columnName = Split(removeNamedColumn, ",")
                For i = 0 To UBound(columnName)
                    If dtChart.Columns.IndexOf(Trim(columnName(i))) >= 0 Then
                        dtChart.Columns.RemoveAt(dtChart.Columns.IndexOf(Trim(columnName(i))))
                    End If
                Next
            End If

            '//keep this column remove all other
            ''''If keepNamedColumn <> "" Then
            ''''    Dim columnName2Keep() As String
            ''''    columnName2Keep = Split(keepNamedColumn, ",")
            ''''    For i = 0 To UBound(columnName2Keep)
            ''''        If dtChart.Columns.IndexOf(Trim(columnName2Keep(i))) > 0 Then
            ''''            'dtChart.Columns.RemoveAt(dtChart.Columns.IndexOf(Trim(columnName2Keep(i))))
            ''''        Else
            ''''            dtChart.Columns.RemoveAt(dtChart.Columns.IndexOf(Trim(columnName2Keep(i))))
            ''''        End If
            ''''    Next
            ''''End If

            deleted = 0
            If removeBottomRows > 0 And dtChart.Rows.Count > 0 Then  '//remove bottom rows 
                For i = dtChart.Rows.Count - 1 To 0 Step -1
                    dtChart.Rows.RemoveAt(i)
                    removeBottomRows = removeBottomRows - 1
                    If removeBottomRows = 0 Then
                        Exit For
                    End If
                Next
            End If


            If dtChart.Rows.Count > 0 Then '//clear html tags 
                For i = 0 To dtChart.Rows.Count - 1
                    For j = 0 To dtChart.Columns.Count - 1
                        If Not IsDBNull(dtChart.Rows(i)(j)) Then
                            If clearHtml Then
                                dtChart.Rows(i)(j) = ClearHTMLTags(dtChart.Rows(i)(j))
                            End If
                            If removeBlanknDash Then
                                If dtChart.Rows(i)(j) = "" Or dtChart.Rows(i)(j) = "-" Then
                                    'dtChart.Rows(i)(j) = System.Type.GetType("System.DBNull")
                                    dtChart.Rows(i)(j) = System.DBNull.Value
                                End If
                                If Not IsDBNull(dtChart.Rows(i)(j)) Then
                                    If InStr(dtChart.Rows(i)(j), "%") > 0 Then '//remove % sign
                                        dtChart.Rows(i)(j) = Trim(Replace(dtChart.Rows(i)(j), "%", ""))
                                    End If
                                End If
                            End If
                        End If
                    Next
                Next
            End If

            If dtChart.Rows.Count > 0 Then '//remove blank rows
                For i = 0 To dtChart.Rows.Count - 1 - deleted
                    deleteCurrentRow = True
                    For j = 0 To dtChart.Columns.Count - 1
                        If Not IsDBNull(dtChart.Rows(i - deleted)(j)) Then
                            deleteCurrentRow = False
                            Exit For
                        End If
                    Next
                    If deleteCurrentRow Then
                        dtChart.Rows.RemoveAt(i - deleted)
                        deleted = deleted + 1
                        removeBottomRows = removeBottomRows - 1
                    End If
                Next
            End If
            '//ADD  IDENTITTY COLUMN IN BEGINING
            If ADD_IDENTITY_COLUMN Then
                dtChart.Columns(0).ColumnName = "ID"
                For i = 0 To dtChart.Rows.Count - 1
                    dtChart.Rows(i)(0) = i + 1
                Next
            End If
        Catch e1 As Exception
        Finally
        End Try
    End Sub
    Public Sub drawChart(ByRef sipChart As WebChart.ChartControl, ByVal dtable As DataTable, Optional ByVal gType As String = "SIP", Optional ByVal YInterval As Double = 100, Optional ByVal XInterval As Double = 12, Optional ByVal SeriesName As String = "", Optional ByVal DateOnX As Boolean = False, Optional ByVal showLegend As Boolean = True, Optional ByVal hideXAxis As Boolean = False)
        '//enter validation for data avaiable       
        Try
            'Dim ds As DataSet = GetDataSet(dtable)
            Dim ds As New DataSet
            ds.Tables.Add(dtable)
            Dim view As DataView = ds.Tables(0).DefaultView
            Dim SeriesCount As Integer
            Dim i As Integer
            Dim rnd As Random
            Dim cCOLOR As New Color
            Dim sAlpha, sRed, sGreen, sBlue As Integer



            rnd = New Random(50)

            Dim min1, max1, mean1 As Double

            '//assign data series
            sAlpha = 255 : sRed = 0 : sGreen = 0 : sBlue = 0
            Dim chart() As SmoothLineChart
            SeriesCount = ds.Tables(0).Columns.Count
            xCount = ds.Tables(0).Rows.Count
            ReDim Preserve chart(SeriesCount)
            For i = 1 To SeriesCount - 1
                chart(i) = New SmoothLineChart

                'sRed = rnd.Next Mod 255
                'sGreen = rnd.Next Mod 255
                'sBlue = rnd.Next Mod 255

                sRed = Int32.Parse(Mid(Split(scolor, ",")(i - 1), 1, 2), Globalization.NumberStyles.HexNumber)
                sGreen = Int32.Parse(Mid(Split(scolor, ",")(i - 1), 3, 2), Globalization.NumberStyles.HexNumber)
                sBlue = Int32.Parse(Mid(Split(scolor, ",")(i - 1), 5, 2), Globalization.NumberStyles.HexNumber)
                chart(i).Line.Color = cCOLOR.FromArgb(sAlpha, sRed, sGreen, sBlue)
                chart(i).Fill.Color = cCOLOR.FromArgb(sAlpha, sRed, sGreen, sBlue)
                chart(i).Line.Width = 2

                'chart(i).Legend = Left(view.Table.Columns(i).ColumnName, InStr(view.Table.Columns(i).ColumnName, "_") - 1)
                chart(i).Legend = view.Table.Columns(i).ColumnName
                chart(i).DataSource = view
                chart(i).DataXValueField = view.Table.Columns(0).ColumnName
                chart(i).DataYValueField = view.Table.Columns(i).ColumnName
                chart(i).DataLabels.Position = DataLabelPosition.Bottom




                chart(i).DataBind()
                sipChart.Charts.Add(chart(i))
                chart(i).ShowLineMarkers = False
                chart(i).GetMinMaxMeanValue(min1, max1, mean1)
                If i = 1 Then
                    min = min1
                    max = max1
                    mean = mean1
                Else
                    min = IIf(min1 < min, min1, min)
                    max = IIf(max1 > max, max1, max)
                    mean = IIf(mean1 < mean1, mean1, mean1)
                End If

            Next
            configureAxis(sipChart, XInterval, YInterval, gType)
            ConfigureColors(sipChart)
            sipChart.Legend.Position = LegendPosition.Right
            sipChart.Height = New Unit(298)
            sipChart.Width = New Unit(710)
            sipChart.RedrawChart()
            sipChart.Visible = True
            '//put the chart in session
            HttpContext.Current.Session("SIP_Chart_Image") = ""
            HttpContext.Current.Session("SWP_Chart_Image") = ""
            HttpContext.Current.Session("STP_Chart_Image") = ""
            If dtable.Rows.Count > 1 Then
                If gType = "SIP" Then
                    HttpContext.Current.Session("SIP_Chart_Image") = sipChart.ImageID()
                ElseIf gType = "SWP" Then
                    HttpContext.Current.Session("SWP_Chart_Image") = sipChart.ImageID()
                Else
                    HttpContext.Current.Session("STP_Chart_Image") = sipChart.ImageID()
                End If
            End If
        Catch e1 As Exception
        Finally
        End Try
    End Sub
End Module
