Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Web.Services
Imports System.IO
Imports System.Web.Hosting


Public Class SIPCalculator
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Dim Sqlcon As SqlConnection
    Dim sqlcon1 As SqlConnection
    Dim sqlcon2 As SqlConnection
    Dim sqlcon3 As SqlConnection
    Dim Sqlrd As SqlDataReader
    Dim sqlrd1 As SqlDataReader
    Dim rdSTP As SqlDataReader
    Dim rdSTP1 As SqlDataReader

    Dim sqlrd2 As SqlDataReader
    Dim sqlrd3 As SqlDataReader
    Dim Sqlcom As SqlCommand
    Dim strsql As String
    Dim strsqls As String
    Dim getXirr As Double
    Dim constr As String
    Dim Ipdt As New DataTable
    Dim Iprw As DataRow
    Dim Ipcol As DataColumn
    Dim i As Integer = 0
    Dim ClntCode As String
    Dim sch_codes As String
    Dim scheme_codes() As String
    Dim mut_code As String
    Dim disply_sch_code As String
    Dim disply_sch_code_STPFrom As String
    Dim disply_sch_code_STPTo As String
    Dim disply_sch_code_SWP As String
    Dim disply_sch_code_RETURNS As String
    Dim Reminder As Integer
    Dim valReminder As Integer
    Dim disply_ind_code As String
    Dim Scheme_Not_to_Display_Index As String

    Protected WithEvents PSipDisclamer As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents PSwpDisclamer As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents PStpDisclamer As System.Web.UI.HtmlControls.HtmlTableCell

    Protected WithEvents SIPPDFValue As System.Web.UI.WebControls.HiddenField

    Protected WithEvents tr_STPdate As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents txtwtramt As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label27 As System.Web.UI.WebControls.Label
    Protected WithEvents txtwinamt As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label30 As System.Web.UI.WebControls.Label
    Protected WithEvents txtwvaldate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label29 As System.Web.UI.WebControls.Label
    Protected WithEvents txtwtdt As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label31 As System.Web.UI.WebControls.Label
    Protected WithEvents txtwfrdt As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label32 As System.Web.UI.WebControls.Label
    Protected WithEvents ddwbnmark As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label24 As System.Web.UI.WebControls.Label
    Protected WithEvents ddwscname As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label26 As System.Web.UI.WebControls.Label
    Protected WithEvents tblSIP As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Label25 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlsipbnmark As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddscheme As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    Protected WithEvents txtinstall As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtfromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label14 As System.Web.UI.WebControls.Label
    Protected WithEvents txtTdate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label16 As System.Web.UI.WebControls.Label
    Protected WithEvents Label15 As System.Web.UI.WebControls.Label
    Protected WithEvents txtvalason As System.Web.UI.WebControls.TextBox
    Protected WithEvents tblSWP As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents rbwcorp As System.Web.UI.WebControls.RadioButton
    Protected WithEvents tblSTP As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents txtiniamt As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents ddperiod As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents ddtrfrom As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents ddtrto As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents ddbnmark As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtMess As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents tblSTP1 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents L2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtyldinv As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label22 As System.Web.UI.WebControls.Label
    Protected WithEvents txtyield As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label21 As System.Web.UI.WebControls.Label
    Protected WithEvents txtacc As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label19 As System.Web.UI.WebControls.Label
    Protected WithEvents txtbal As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label20 As System.Web.UI.WebControls.Label
    Protected WithEvents Dstp1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Dstp As System.Web.UI.WebControls.DataGrid
    Protected WithEvents L1 As System.Web.UI.WebControls.Label
    Protected WithEvents tblSIP1 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Label17 As System.Web.UI.WebControls.Label
    Protected WithEvents Label18 As System.Web.UI.WebControls.Label
    Protected WithEvents Label23 As System.Web.UI.WebControls.Label
    Protected WithEvents txtxsch As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtxind As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtonttm As System.Web.UI.WebControls.TextBox
    Protected WithEvents Gsp As System.Web.UI.WebControls.DataGrid
    Protected WithEvents tblSWP1 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Label33 As System.Web.UI.WebControls.Label
    Protected WithEvents txtwyield As System.Web.UI.WebControls.TextBox
    Protected WithEvents Dgswp As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Table17 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Period As System.Web.UI.WebControls.Label
    Protected WithEvents Label28 As System.Web.UI.WebControls.Label
    Protected WithEvents rbwind As System.Web.UI.WebControls.RadioButton
    Protected WithEvents ddwperiod As System.Web.UI.WebControls.DropDownList
    Protected WithEvents tblSWP_rdo As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents ddPeriod_SIP As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rbcapital As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbfixed As System.Web.UI.WebControls.RadioButton
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents txtvalue As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents txttodt As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents txtfrdt As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label34 As System.Web.UI.WebControls.Label
    Protected WithEvents ddSWPDate As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label35 As System.Web.UI.WebControls.Label
    Protected WithEvents ddSIPdate As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label36 As System.Web.UI.WebControls.Label
    Protected WithEvents ddSTPDate As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmdcalc As System.Web.UI.WebControls.Button
    Protected WithEvents cmdexp1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents cmdreset As System.Web.UI.WebControls.ImageButton
    Protected WithEvents cmdexp As System.Web.UI.WebControls.ImageButton
    Protected WithEvents cmdrs1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnwexport As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnwreset As System.Web.UI.WebControls.ImageButton
    Protected WithEvents cmdSWP As System.Web.UI.WebControls.ImageButton
    'Protected WithEvents cmdshow As System.Web.UI.WebControls.Button
    Protected WithEvents Label37 As System.Web.UI.WebControls.Label
    Protected WithEvents txtSIP_EntryLoad As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label41 As System.Web.UI.WebControls.Label
    Protected WithEvents txtSWP_EntryLoad As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label42 As System.Web.UI.WebControls.Label
    Protected WithEvents txtwAbsRet As System.Web.UI.WebControls.TextBox
    Protected WithEvents Image1 As System.Web.UI.WebControls.Image
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents Siplb As System.Web.UI.WebControls.Label
    Protected WithEvents Stplb As System.Web.UI.WebControls.Label
    Protected WithEvents ddPlan As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label44 As System.Web.UI.WebControls.Label
    Protected WithEvents Label45 As System.Web.UI.WebControls.Label
    Protected WithEvents ddwbnmark1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlsipbnmark1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddbnmark1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txttranamt As System.Web.UI.WebControls.TextBox
    Protected WithEvents rbindivd As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbcorp As System.Web.UI.WebControls.RadioButton
    Protected WithEvents Table12 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents chkChart_SWP As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkChart_SIP As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Checkbox1 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkChart_STP As System.Web.UI.WebControls.CheckBox
    Protected WithEvents cmdSIP As System.Web.UI.WebControls.ImageButton
    Protected WithEvents cmdSTP As System.Web.UI.WebControls.ImageButton
    'commented by syed
    'Protected WithEvents sipChart As WebChart.ChartControl 
    Protected WithEvents tblChart As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Label38 As System.Web.UI.WebControls.Label
    Protected WithEvents Label39 As System.Web.UI.WebControls.Label
    Protected WithEvents Label40 As System.Web.UI.WebControls.Label
    Protected WithEvents Label43 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label46 As System.Web.UI.WebControls.Label
    Protected WithEvents Dropdownlist4 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label47 As System.Web.UI.WebControls.Label
    Protected WithEvents Dropdownlist5 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label48 As System.Web.UI.WebControls.Label
    Protected WithEvents Label49 As System.Web.UI.WebControls.Label
    Protected WithEvents Label50 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox5 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label51 As System.Web.UI.WebControls.Label
    Protected WithEvents CalReturn As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents CalReturn1 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents txtRetInsAmt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRetFdt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRetTodt As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnRetReset As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ddRetbnmark As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddRetbnmark1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddRetscname As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmdReturn As System.Web.UI.WebControls.ImageButton
    Protected WithEvents DgReturn As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label52 As System.Web.UI.WebControls.Label
    Protected WithEvents Label53 As System.Web.UI.WebControls.Label
    Protected WithEvents Label54 As System.Web.UI.WebControls.Label
    Protected WithEvents Label55 As System.Web.UI.WebControls.Label
    Protected WithEvents Label56 As System.Web.UI.WebControls.Label
    Protected WithEvents Label57 As System.Web.UI.WebControls.Label
    Protected WithEvents lblschdt1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblschdt2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblinddt1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblinddt2 As System.Web.UI.WebControls.Label
    Protected WithEvents btnRetExport As System.Web.UI.WebControls.ImageButton
    Protected WithEvents STPdt As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents hdChartData As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdIsGraphExist As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents HdGraphImgPath As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdIEVersion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents PDFSWP As System.Web.UI.HtmlControls.HtmlContainerControl
    Protected WithEvents PDFSIP As System.Web.UI.HtmlControls.HtmlContainerControl
    Protected WithEvents PDFSTP As System.Web.UI.HtmlControls.HtmlContainerControl
    Protected WithEvents PDFLUMPSUM As System.Web.UI.HtmlControls.HtmlContainerControl


    ''HdGraphImgPath hdIEVersion
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Dim ColCount As Integer

    <WebMethod()>
    Public Shared Sub setNPSChartimg(baseimg As String, ieVersion As String)



        If HttpContext.Current.Session("IsChartExist") <> True Then
            Return
        End If
        Dim appPath As String = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "") & "\"
        Dim localImgPath As String = "WebCharts\"
        If String.IsNullOrEmpty(HttpContext.Current.Session("All_Chart_Image")) = False Then
            Return
        Else
            If ((ieVersion.Contains("9")) Or (ieVersion.Contains("8"))) Then
                '' do not delete , will on once client will satify with don net charting
                'localImgPath = System.IO.Path.Combine(appPath, localImgPath & HttpContext.Current.Session("All_Chart_Image_Ie8"))
                'HttpContext.Current.Session("All_Chart_Image") = localImgPath
                Return
            End If
        End If
        appPath = HttpContext.Current.Request.PhysicalApplicationPath
        Dim appPath4xl As String = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "") & "\"
        Dim allFiles = IO.Directory.GetFiles(HttpContext.Current.Server.MapPath("~") & "WebCharts\", "*Rel_img*")
        For Each f In allFiles
            If IO.File.GetCreationTime(f) < DateTime.Now.AddMinutes(-30) Then
                File.Delete(f)
            End If
        Next

        Dim data As Byte() = System.Convert.FromBase64String(baseimg.Replace("data:image/png;base64,", ""))
        localImgPath = System.IO.Path.Combine(appPath, localImgPath)
        Dim localImgPath4xl As String = appPath4xl & "WebCharts\"
        Dim guid As Guid = Guid.NewGuid()
        Dim imgPath As String = System.IO.Path.Combine(localImgPath & guid.ToString("N").Replace("-", "") & "Rel_img.jpg")
        Dim imgPath4xl As String = System.IO.Path.Combine(localImgPath4xl & guid.ToString("N").Replace("-", "") & "Rel_img.jpg")
        Using image As System.Drawing.Image = System.Drawing.Image.FromStream(New MemoryStream(data))
            image.Save(imgPath, System.Drawing.Imaging.ImageFormat.Jpeg)
        End Using
        HttpContext.Current.Session("All_Chart_Image") = imgPath4xl
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Put user code to initialize the page here
        constr = ConfigurationSettings.AppSettings("connectionStrings").ToString
        mut_code = ConfigurationSettings.AppSettings("Mutfund").ToString
        disply_ind_code = ConfigurationSettings.AppSettings("IndexNot2Display").ToString
        ''disply_sch_code = ConfigurationSettings.AppSettings("SchemeNot2Display").ToString
        disply_sch_code = ConfigurationSettings.AppSettings("Scheme2Display").ToString
        disply_sch_code_STPFrom = ConfigurationSettings.AppSettings("Scheme2DisplaySTPFrom").ToString
        disply_sch_code_STPTo = ConfigurationSettings.AppSettings("Scheme2DisplaySTPTo").ToString
        disply_sch_code_SWP = ConfigurationSettings.AppSettings("Scheme2DisplaySWP").ToString
        disply_sch_code_RETURNS = ConfigurationSettings.AppSettings("Scheme2DisplayRETURNS").ToString
        Scheme_Not_to_Display_Index = ConfigurationSettings.AppSettings("SchemeNot2DisplayIndex").ToString
        Siplb.Text = "SIP"
        Stplb.Text = "STP"
        Session("BaseUrl") = ConfigurationSettings.AppSettings("BaseUrl").ToString

        '//vishal for client side validation
        cmdSIP.Attributes.Add("onclick", "javascript:return validate_SIP();")
        cmdSWP.Attributes.Add("onclick", "javascript:return validate_SWP();")

        cmdReturn.Attributes.Add("onclick", "javascript:return validate_RETURNS();")
        cmdSIP.Attributes.Add("onMouseOver", "javascript:return wordage('Click on Show for SIP Report');")
        cmdSWP.Attributes.Add("onMouseOver", "javascript:return wordage('Click on Show for SWP Report');")
        If rbcapital.Checked = False Then
            cmdSTP.Attributes.Add("onclick", "javascript:return validate_STP();")
        Else
            cmdSTP.Attributes.Add("onclick", "javascript:return validate_STP_New();")
        End If
        cmdSTP.Attributes.Add("onMouseOver", "javascript:return wordage('Click on Show for STP Report');")

        cmdReturn.Attributes.Add("onMouseOver", "javascript:return wordage('Click on Show for RETURNS Report');")
        'cmdSIP.Attributes.Add("onMouseout", "javascript:return clear();")

        If Not IsPostBack Then
            If Request.Browser.Browser = "IE" Then
                hdIEVersion.Value = Request.Browser.Version
            End If

            Sqlcon = New SqlConnection(constr)
            Sqlcon.Open()

            strsql = "Select sch_code,sch_name from Scheme_info where mut_code in ('" & Replace(mut_code, ",", "','") & "') and sch_code  in ('" & Replace(disply_sch_code, ",", "','") & "') and nav_check<>'red' order by sch_name"
            Sqlcom = New SqlCommand(strsql, Sqlcon)
            Sqlrd = Sqlcom.ExecuteReader
            If Sqlrd.Read Then
                'ddtrfrom.Items.Clear()
                ddscheme.Items.Clear()
                'ddRetscname.Items.Clear()
                'ddwscname.Items.Clear()
                'ddtrfrom.Items.Add(New ListItem("--"))
                ddscheme.Items.Add(New ListItem("--"))
                ' ddRetscname.Items.Add(New ListItem("--"))
                Do
                    '  ddtrfrom.Items.Add(New ListItem(Sqlrd(1), Sqlrd(0)))
                    ddscheme.Items.Add(New ListItem(Sqlrd(1), Sqlrd(0)))
                    'ddRetscname.Items.Add(New ListItem(Sqlrd(1), Sqlrd(0)))
                    'ddwscname.Items.Add(New ListItem(Sqlrd(1), Sqlrd(0)))
                Loop While Sqlrd.Read
            End If
            Sqlcon.Close()
            Sqlcon.Dispose()
            Sqlcon = New SqlConnection(constr)
            Sqlcon.Open()
            strsql = "Select ind_name,ind_code from ind_info order by ind_name"
            Sqlcom = New SqlCommand(strsql, Sqlcon)
            Sqlrd = Sqlcom.ExecuteReader
            i = 1
            If Sqlrd.Read Then
                ddlsipbnmark.Items.Clear()
                ddbnmark.Items.Clear()
                ddwbnmark.Items.Clear()
                ddlsipbnmark1.Items.Clear()
                ddbnmark1.Items.Clear()
                ddwbnmark1.Items.Clear()
                ddRetbnmark.Items.Clear()
                ddRetbnmark1.Items.Clear()

                ddlsipbnmark.Items.Add(New ListItem("--"))
                ddbnmark.Items.Add(New ListItem("--"))
                ddwbnmark.Items.Add(New ListItem("--"))
                ddwbnmark1.Items.Add(New ListItem("--"))
                ddlsipbnmark1.Items.Add(New ListItem("--"))
                ddbnmark1.Items.Add(New ListItem("--"))

                ddRetbnmark.Items.Add(New ListItem("--"))
                ddRetbnmark1.Items.Add(New ListItem("--"))

                Do
                    '''ddlsipbnmark.Items.Add(New ListItem(Sqlrd(0) & " # " & Sqlrd(1), i))
                    '''ddbnmark.Items.Add(New ListItem(Sqlrd(0) & " # " & Sqlrd(1), i))
                    '''ddwbnmark.Items.Add(New ListItem(Sqlrd(0) & " # " & Sqlrd(1), i))
                    ddlsipbnmark.Items.Add(New ListItem(Sqlrd(0), i))
                    ddlsipbnmark1.Items.Add(New ListItem(Sqlrd(1), i))
                    ddbnmark.Items.Add(New ListItem(Sqlrd(0), i))
                    ddbnmark1.Items.Add(New ListItem(Sqlrd(1), i))
                    ddwbnmark.Items.Add(New ListItem(Sqlrd(0), i))
                    ddwbnmark1.Items.Add(New ListItem(Sqlrd(1), i))

                    ddRetbnmark.Items.Add(New ListItem(Sqlrd(0), i))
                    ddRetbnmark1.Items.Add(New ListItem(Sqlrd(1), i))
                    i += 1
                Loop While Sqlrd.Read
            End If
            Sqlcon.Close()
            Sqlcon.Dispose()

            '*********  For  Fill SWP Scheme From DDL\-   "--Manish--"

            Sqlcon = New SqlConnection(constr)
            Sqlcon.Open()
            strsql = "Select sch_code,sch_name from Scheme_info where mut_code in ('" & Replace(mut_code, ",", "','") & "') and sch_code  in ('" & Replace(disply_sch_code_SWP, ",", "','") & "') and nav_check<>'red' order by sch_name"
            Sqlcom = New SqlCommand(strsql, Sqlcon)
            Sqlrd = Sqlcom.ExecuteReader
            If Sqlrd.Read Then
                ddwscname.Items.Clear()
                ddwscname.Items.Add(New ListItem("--"))

                Do
                    ddwscname.Items.Add(New ListItem(Sqlrd(1), Sqlrd(0)))

                Loop While Sqlrd.Read
            End If
            Sqlcon.Close()
            Sqlcon.Dispose()


            '***END

            '*********  For STP Fill Scheme  From DDL\-   "--Manish--"

            Sqlcon = New SqlConnection(constr)
            Sqlcon.Open()
            strsql = "Select sch_code,sch_name from Scheme_info where mut_code in ('" & Replace(mut_code, ",", "','") & "') and sch_code  in ('" & Replace(disply_sch_code_STPFrom, ",", "','") & "') and nav_check<>'red' order by sch_name"
            Sqlcom = New SqlCommand(strsql, Sqlcon)
            Sqlrd = Sqlcom.ExecuteReader
            If Sqlrd.Read Then
                ddtrfrom.Items.Clear()
                ddtrfrom.Items.Add(New ListItem("--"))

                ddtrto.Items.Clear()
                ddtrto.Items.Add(New ListItem("--"))
                Do
                    ddtrfrom.Items.Add(New ListItem(Sqlrd(1), Sqlrd(0)))

                Loop While Sqlrd.Read
            End If
            Sqlcon.Close()
            Sqlcon.Dispose()


            '***END


            '*********  For RETURNS/LUMPSUM  Scheme  From DDL\-   "--Manish--"

            Sqlcon = New SqlConnection(constr)
            Sqlcon.Open()
            strsql = "Select sch_code,sch_name from Scheme_info where mut_code in ('" & Replace(mut_code, ",", "','") & "') and sch_code  in ('" & Replace(disply_sch_code_RETURNS, ",", "','") & "') and nav_check<>'red' order by sch_name"
            Sqlcom = New SqlCommand(strsql, Sqlcon)
            Sqlrd = Sqlcom.ExecuteReader
            If Sqlrd.Read Then
                ddRetscname.Items.Clear()
                ddRetscname.Items.Add(New ListItem("--"))

                Do
                    'ddtrfrom.Items.Add(New ListItem(Sqlrd(1), Sqlrd(0)))
                    ddRetscname.Items.Add(New ListItem(Sqlrd(1), Sqlrd(0)))

                Loop While Sqlrd.Read
            End If
            Sqlcon.Close()
            Sqlcon.Dispose()


            '***END

            '*********  For STP date    "--Manish--"
            If txtfrdt.Text <> "" Then
                If Split(txtfrdt.Text, "/")(1) = 1 Or Split(txtfrdt.Text, "/")(1) = 3 Or Split(txtfrdt.Text, "/")(1) = 5 Or Split(txtfrdt.Text, "/")(1) = 7 Or Split(txtfrdt.Text, "/")(1) = 8 Or Split(txtfrdt.Text, "/")(1) = 10 Or Split(txtfrdt.Text, "/")(1) = 12 Then
                    STPdt.Items.Clear()
                    STPdt.Items.Add("--")
                    For i = 1 To 31
                        STPdt.Items.Add(i)
                    Next
                ElseIf Split(txtfrdt.Text, "/")(1) = 4 Or Split(txtfrdt.Text, "/")(1) = 6 Or Split(txtfrdt.Text, "/")(1) = 9 Or Split(txtfrdt.Text, "/")(1) = 11 Then
                    STPdt.Items.Clear()
                    STPdt.Items.Add("--")
                    For i = 1 To 30
                        STPdt.Items.Add(i)
                    Next
                ElseIf Split(txtfrdt.Text, "/")(1) = 2 Then
                    STPdt.Items.Clear()
                    STPdt.Items.Add("--")
                    Math.DivRem(CInt(Split(txtfrdt.Text, "/")(2)), 4, Reminder)
                    If Reminder <> 0 Then
                        For i = 1 To 28
                            STPdt.Items.Add(i)
                        Next
                    Else
                        For i = 1 To 29
                            STPdt.Items.Add(i)
                        Next
                    End If
                End If
            Else
                STPdt.Items.Clear()
                STPdt.Items.Add("--")
            End If
        End If
        '***END

        i = 0
        If ddPlan.SelectedItem.Text = "SIP" Then
            tblSIP.Visible = True
            tblSIP1.Visible = False
            tblSTP.Visible = False
            tblSTP1.Visible = False
            tblSWP.Visible = False
            tblSWP1.Visible = False
            Label25.Visible = True
            ddlsipbnmark.Visible = True
            tblSWP_rdo.Visible = False
            Label18.Visible = True
            txtxind.Visible = True
            tblChart.Visible = False
            cmdexp.Enabled = False
            CalReturn.Visible = False
            CalReturn1.Visible = False
        ElseIf ddPlan.SelectedItem.Text = "SWP" Then
            tblSWP1.Visible = False
            btnwexport.Enabled = False
            tblChart.Visible = False
            CalReturn.Visible = False
            CalReturn1.Visible = False
        ElseIf ddPlan.SelectedItem.Text = "STP" Then
            tblSTP1.Visible = False
            cmdexp1.Enabled = False
            tblChart.Visible = False
            CalReturn.Visible = False
            CalReturn1.Visible = False
        ElseIf ddPlan.SelectedItem.Text = "LUMPSUM INVESTMENT" Then
            'CalReturn.Visible = False
            CalReturn1.Visible = False
            tblChart.Visible = False
            tblSIP.Visible = False
            tblSIP1.Visible = False
            tblSTP.Visible = False
            tblSTP1.Visible = False
            tblSWP.Visible = False
            tblSWP1.Visible = False
            btnRetExport.Enabled = False
        End If
        'Jscript()
    End Sub

    Private Sub ddtrfrom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddtrfrom.SelectedIndexChanged
        Try
            hdChartData.Value = "0"
            If ddtrfrom.SelectedItem.Text <> "--" Then
                mut_code = ConfigurationSettings.AppSettings("Mutfund").ToString
                disply_sch_code_STPFrom = ConfigurationSettings.AppSettings("Scheme2DisplaySTPFrom").ToString
                strsql = "Select sch_code,sch_name from Scheme_info where mut_code in ('" & Replace(mut_code, ",", "','") & "') and sch_code in  ('" & Replace(disply_sch_code_STPFrom, ",", "','") & "') order by sch_name"

                Sqlcon = New SqlConnection(constr)
                Sqlcon.Open()
                'strsql = "Select sch_code,sch_name from Scheme_info where Nav_check <> 'Red' And sch_code not in ('" & ddtrfrom.SelectedItem.Value & "') and  mut_code in ('" & Replace(mut_code, ",", "','") & "') and sch_code not in ('" & Replace(disply_sch_code_STPFrom, ",", "','") & "') order by sch_name"
                strsql = "Select sch_code,sch_name from Scheme_info where Nav_check <> 'Red' And sch_code not in ('" & ddtrfrom.SelectedItem.Value & "') and  mut_code in ('" & Replace(mut_code, ",", "','") & "') and sch_code  in ('" & Replace(disply_sch_code_STPTo, ",", "','") & "') order by sch_name"
                Sqlcom = New SqlCommand(strsql, Sqlcon)
                Sqlrd = Sqlcom.ExecuteReader
                If Sqlrd.Read Then
                    ddtrto.Items.Clear()
                    ddtrto.Items.Add(New ListItem("--"))
                    Do
                        ddtrto.Items.Add(New ListItem(Sqlrd(1), Sqlrd(0)))
                    Loop While Sqlrd.Read
                End If
                Sqlcon.Close()
                Sqlcon.Dispose()
            End If
            'HttpContext.Current.Session("STP_Chart_Image")
            'Call drawChart(sipChart, Session("ChartData_SIP1"), "STP", Session("yinterval"))
            tblChart.Visible = False
            tblSTP1.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ddtrto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddtrto.SelectedIndexChanged
        Try
            ''commented by 31 Oct 2014
            'Dim Eq_flag As Boolean

            'strsql = "Select nature from Scheme_info where mut_code in ('" & Replace(mut_code, ",", "','") & "') and sch_code='" & ddtrto.SelectedItem.Value & "'"
            'Sqlcon = New SqlConnection(constr)
            'Sqlcon.Open()
            'Sqlcom = New SqlCommand(strsql, Sqlcon)
            'Sqlrd = Sqlcom.ExecuteReader
            'If Sqlrd.Read Then
            '    If LCase(Sqlrd(0)) = LCase("equity") Then
            '        Eq_flag = True
            '    End If
            'End If
            'strsql = "" : Sqlcon.Close() : Sqlrd.Close() : Sqlcom.Dispose()

            'If Eq_flag = True Then
            '    For i = 0 To ddbnmark.Items.Count - 1
            '        If ddbnmark.Items(i).Text = ConfigurationSettings.AppSettings("EQUITYSCHEME").ToString() Then
            '            ddbnmark.SelectedIndex = i
            '            ddbnmark1.SelectedIndex = i
            '            Exit For
            '        End If
            '    Next i
            'Else
            '    strsql = "Select ind_name,ind_code from ind_info where ind_code=(Select distinct top 1 ind_code from schemeindex where sch_code='" & ddtrto.SelectedItem.Value & "' and ind_code not in ('" & Replace(disply_ind_code, ",", "','") & "'))"
            '    Sqlcon = New SqlConnection(constr)
            '    Sqlcon.Open()
            '    Sqlcom = New SqlCommand(strsql, Sqlcon)
            '    Sqlrd = Sqlcom.ExecuteReader
            '    If Sqlrd.Read Then
            '        For i = 0 To ddbnmark.Items.Count
            '            If ddbnmark.Items(i).Text = Sqlrd(0) Then
            '                ddbnmark.SelectedIndex = i
            '                ddbnmark1.SelectedIndex = i
            '                Exit For
            '            End If
            '        Next i
            '    End If
            'End If
            ''end

            hdChartData.Value = "0"
            'Comment for TRI
            'strsql = "Select ind_name,ind_code from ind_info where ind_code=(Select distinct top 1 ind_code from schemeindex where sch_code='" & ddtrto.SelectedItem.Value & "' and ind_code not in ('" & Replace(disply_ind_code, ",", "','") & "'))"

            If Scheme_Not_to_Display_Index.Split(",").Where(Function(c) c = ddtrto.SelectedItem.Value).Any() = False Then

                strsql = "Select ind_name,ind_code from ind_info where REPLACE(ind_name,' ','')= REPLACE((Select ind_name from ind_info where ind_code=(Select distinct top 1 ind_code from schemeindex where sch_code='" & ddtrto.SelectedItem.Value & "' and ind_code not in ('" & Replace(disply_ind_code, ",", "','") & "')))+ ' TRI',' ','')"
                Sqlcon = New SqlConnection(constr)
                Sqlcon.Open()
                Sqlcom = New SqlCommand(strsql, Sqlcon)
                Sqlrd = Sqlcom.ExecuteReader
                If Sqlrd.Read Then
                    For i = 0 To ddbnmark.Items.Count
                        If ddbnmark.Items(i).Text = Sqlrd(0) Then
                            ddbnmark.SelectedIndex = i
                            ddbnmark1.SelectedIndex = i
                            Exit For
                        End If
                    Next i
                Else
                    strsql = "Select ind_name,ind_code from ind_info where ind_code=(Select distinct top 1 ind_code from schemeindex where sch_code='" & ddtrto.SelectedItem.Value & "' and ind_code not in ('" & Replace(disply_ind_code, ",", "','") & "'))"
                    Sqlcon = New SqlConnection(constr)
                    Sqlcon.Open()
                    Sqlcom = New SqlCommand(strsql, Sqlcon)
                    Sqlrd = Sqlcom.ExecuteReader
                    If Sqlrd.Read Then
                        For i = 0 To ddbnmark.Items.Count
                            If ddbnmark.Items(i).Text = Sqlrd(0) Then
                                ddbnmark.SelectedIndex = i
                                ddbnmark1.SelectedIndex = i
                                Exit For
                            End If
                        Next i
                    End If
                End If
            Else
                ddbnmark.SelectedIndex = 0
            End If
            tblSTP1.Visible = False
            tblChart.Visible = False
            'Call drawChart(sipChart, Session("ChartData_SIP1"), "STP", Session("yinterval"))

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ddwscname_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddwscname.SelectedIndexChanged
        ''commented by 31 Oct 2014
        'Dim Eq_flag As Boolean

        'strsql = "Select nature from Scheme_info where mut_code in ('" & Replace(mut_code, ",", "','") & "') and sch_code='" & ddwscname.SelectedItem.Value & "'"
        'Sqlcon = New SqlConnection(constr)
        'Sqlcon.Open()
        'Sqlcom = New SqlCommand(strsql, Sqlcon)
        'Sqlrd = Sqlcom.ExecuteReader
        'If Sqlrd.Read Then
        '    If LCase(Sqlrd(0)) = LCase("equity") Then
        '        Eq_flag = True
        '    End If
        'End If
        'strsql = "" : Sqlcon.Close() : Sqlrd.Close() : Sqlcom.Dispose()


        'If Eq_flag = True Then
        '    For i = 0 To ddwbnmark.Items.Count - 1
        '        If ddwbnmark.Items(i).Text = ConfigurationSettings.AppSettings("EQUITYSCHEME").ToString() Then
        '            ddwbnmark.SelectedIndex = i
        '            ddwbnmark1.SelectedIndex = i
        '            Exit For
        '        End If
        '    Next i
        'Else
        '    strsql = "Select ind_name,ind_code from ind_info where ind_code=(Select distinct top 1 ind_code from schemeindex where sch_code='" & ddwscname.SelectedItem.Value & "' and ind_code not in ('" & Replace(disply_ind_code, ",", "','") & "'))"
        '    Sqlcon = New SqlConnection(constr)
        '    Sqlcon.Open()
        '    Sqlcom = New SqlCommand(strsql, Sqlcon)
        '    Sqlrd = Sqlcom.ExecuteReader

        '    If Sqlrd.Read Then
        '        For i = 0 To ddwbnmark.Items.Count
        '            If ddwbnmark.Items(i).Text = Sqlrd(0) Then
        '                ddwbnmark.SelectedIndex = i
        '                ddwbnmark1.SelectedIndex = i
        '                Exit For
        '            End If
        '        Next i
        '    End If
        'End If
        '' end 
        'hdIsGraphExist.Value = "0"

        'Comment for TRI changes
        'strsql = "Select ind_name,ind_code from ind_info where ind_code=(Select distinct top 1 ind_code from schemeindex where sch_code='" & ddwscname.SelectedItem.Value & "' and ind_code not in ('" & Replace(disply_ind_code, ",", "','") & "'))"

        If Scheme_Not_to_Display_Index.Split(",").Where(Function(c) c = ddwscname.SelectedItem.Value).Any() = False Then
            strsql = "Select ind_name,ind_code from ind_info where REPLACE(ind_name,' ','')= REPLACE((Select ind_name from ind_info where ind_code=(Select distinct top 1 ind_code from schemeindex where sch_code='" & ddwscname.SelectedItem.Value & "' and ind_code not in ('" & Replace(disply_ind_code, ",", "','") & "')))+ ' TRI',' ','')"
            Sqlcon = New SqlConnection(constr)
            Sqlcon.Open()
            Sqlcom = New SqlCommand(strsql, Sqlcon)
            Sqlrd = Sqlcom.ExecuteReader

            If Sqlrd.Read Then
                For i = 0 To ddwbnmark.Items.Count
                    If ddwbnmark.Items(i).Text = Sqlrd(0) Then
                        ddwbnmark.SelectedIndex = i
                        ddwbnmark1.SelectedIndex = i
                        Exit For
                    End If
                Next i
            Else
                strsql = "Select ind_name,ind_code from ind_info where ind_code=(Select distinct top 1 ind_code from schemeindex where sch_code='" & ddwscname.SelectedItem.Value & "' and ind_code not in ('" & Replace(disply_ind_code, ",", "','") & "'))"
                Sqlcon = New SqlConnection(constr)
                Sqlcon.Open()
                Sqlcom = New SqlCommand(strsql, Sqlcon)
                Sqlrd = Sqlcom.ExecuteReader
                If Sqlrd.Read Then
                    For i = 0 To ddwbnmark.Items.Count
                        If ddwbnmark.Items(i).Text = Sqlrd(0) Then
                            ddwbnmark.SelectedIndex = i
                            ddwbnmark1.SelectedIndex = i
                            Exit For
                        End If
                    Next i
                End If
            End If
        Else
            ddwbnmark.SelectedIndex = 0
        End If
        tblSWP1.Visible = False
        tblChart.Visible = False
    End Sub

#Region "Radio Button events"
    Private Sub rbindivd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If rbindivd.Checked = True Then
            rbcorp.Checked = False
        End If
    End Sub

    Private Sub rbcorp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If rbcorp.Checked = True Then
            rbindivd.Checked = False
        End If
    End Sub

    Private Sub rbcapital_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbcapital.CheckedChanged
        If rbcapital.Checked = True Then
            rbfixed.Checked = False
            ddperiod.Items.Clear()
            ddperiod.Items.Add("--")
            ddperiod.Items.Add("Monthly")
            ddperiod.Items.Add("Quarterly")
            Label7.Visible = False
            txttranamt.Visible = False
            hdIsGraphExist.Value = 0
            STPdt.Visible = False
            'hdIsGraphExist.Value = "0"
            ddSTPDate.Visible = True
            tr_STPdate.Visible = False
        Else
            tr_STPdate.Visible = True
        End If


    End Sub

    Private Sub rbfixed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbfixed.CheckedChanged
        If rbfixed.Checked = True Then
            rbcapital.Checked = False
            ddperiod.Items.Clear()
            ddperiod.Items.Add("--")
            ddperiod.Items.Add("Weekly")
            ddperiod.Items.Add("Fortnightly")
            ddperiod.Items.Add("Monthly")
            ddperiod.Items.Add("Quarterly")
            hdIsGraphExist.Value = 0

            Label7.Visible = True
            txttranamt.Visible = True
            If ddperiod.SelectedItem.Text = "Monthly" Or ddperiod.SelectedItem.Text = "Monthly" Then
                STPdt.Visible = True
            End If
            tr_STPdate.Visible = True
        End If
    End Sub

    Private Sub rbwind_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbwind.CheckedChanged
        If rbwind.Checked = True Then
            rbwcorp.Checked = False
        Else
            rbwind.Checked = True
        End If
    End Sub

    Private Sub rbwcorp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbwcorp.CheckedChanged
        If rbwcorp.Checked = True Then
            rbwind.Checked = False
        Else
            rbwcorp.Checked = True
        End If
    End Sub
#End Region

#Region "Button Events"
    '    Private Sub cmdsh1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsh1.Click
    '        Dim frdt As Date
    '        Dim todt As Date
    '        Dim FNav As Double = 0
    '        Dim LNav As Double = 0
    '        Dim Valdt As Date
    '        Dim CalcDt As Date
    '        Dim TempDt As Date
    '        Dim ColArr() As String
    '        Dim Colstr As String
    '        Dim Amt As Double = 0
    '        Dim Temp As Double = 0
    '        Dim TempUnits As Double = 0
    '        Dim IndUnits As Double = 0
    '        Dim TempNav As Double = 0
    '        Dim currentIndex As Double = 0
    '        Dim j As Integer = 0
    '        Dim k As Integer = 0
    '        Dim m As Integer = 0
    '        Dim Arrcount As Integer = 0
    '        Dim DivDt() As Date
    '        Dim DivArr() As Double
    '        Dim BonDt() As Date
    '        Dim BonArr() As String
    '        Dim NewNav As Double
    '        Dim PerUnitDiv As Double = 0
    '        Dim DtArr() As Date
    '        Dim CashFl() As Double
    '        Dim CashFlInd() As Double
    '        Dim TotNav As Double = 0
    '        Dim PrdVal As Integer = 0
    '        Dim strdt(2) As String
    '        Dim Tempdtstr(2) As String
    '        Dim FDate As Date
    '        Dim LDate As Date
    '        Dim benchmark() As String
    '        Dim scheme_code As String
    '        Dim plan_code As String

    '        Try
    '            scheme_code = ""
    '            plan_code = ""

    '            If ddPlan.SelectedItem.Text = "--" Then
    '                Response.Write("<script>alert(""Please Select Any Plan.."")</script>")
    '                Exit Sub
    '            End If
    '            If ddscheme.SelectedItem.Text = "--" Then
    '                Response.Write("<script>alert(""Please Select Any Scheme.."")</script>")
    '                Exit Sub
    '            End If

    '            ''''If ddlsipbnmark.SelectedItem.Text = "--" Then
    '            ''''    txtMess.Value = "Please Select Any BenchMark.."
    '            ''''    Exit Sub
    '            ''''Else
    '            ''''    benchmark = Split(ddlsipbnmark.SelectedItem.Text, "#")
    '            ''''End If

    '            If Val(txtinstall.Text) = 0 Then
    '                Response.Write("<script>alert(""Installment Amount Cannot Be Blank.."")</script>")
    '                Exit Sub
    '            End If

    '            For i = 1 To Len(txtfromDate.Text)
    '                If Mid(Trim(txtfromDate.Text), i, 1) = "/" Then
    '                    k += 1
    '                End If
    '            Next i
    '            If k <> 2 Then
    '                Response.Write("<script>alert(""Please Enter From Date in proper format.."")</script>")
    '                Exit Sub
    '            End If
    '            i = 0
    '            k = 0

    '            For i = 1 To Len(txtTdate.Text)
    '                If Mid(Trim(txtTdate.Text), i, 1) = "/" Then
    '                    k += 1
    '                End If
    '            Next i
    '            If k <> 2 Then
    '                Response.Write("<script>alert(""Please Enter To Date in proper format.."")</script>")
    '                Exit Sub
    '            End If
    '            i = 0
    '            k = 0

    '            For i = 1 To Len(txtvalason.Text)
    '                If Mid(Trim(txtvalason.Text), i, 1) = "/" Then
    '                    k += 1
    '                End If
    '            Next i
    '            If k <> 2 Then
    '                Response.Write("<script>alert(""Please Value as on Date in proper format.."")</script>")
    '                Exit Sub
    '            End If
    '            i = 0
    '            k = 0

    '            If IsDate(fmt(Trim(txtfromDate.Text))) = False Or IsDate(fmt(Trim(txtTdate.Text))) = False Or IsDate(fmt(Trim(txtvalason.Text))) = False Then
    '                Response.Write("<script>alert(""Please Enter The Dates in Proper Formats (dd/mm/yyyy).."")</script>")
    '                Exit Sub
    '            End If


    '            todt = Split(Trim(txtTdate.Text), "/")(1) & "/" & Split(Trim(txtTdate.Text), "/")(0) & "/" & Split(Trim(txtTdate.Text), "/")(2)
    '            frdt = Split(Trim(txtfromDate.Text), "/")(1) & "/" & Split(Trim(txtfromDate.Text), "/")(0) & "/" & Split(Trim(txtfromDate.Text), "/")(2)
    '            Valdt = Split(Trim(txtvalason.Text), "/")(1) & "/" & Split(Trim(txtvalason.Text), "/")(0) & "/" & Split(Trim(txtvalason.Text), "/")(2)

    '            If IsDate(frdt) = False Or IsDate(todt) = False Or IsDate(Valdt) = False Then
    '                Response.Write("<script>alert(""Please Enter The Dates in Proper Formats (dd/mm/yyyy).."")</script>")
    '                Exit Sub
    '            End If

    '            If CDate(todt) <= frdt Then
    '                Response.Write("<script>alert(""From Date cannot be Greater than To Date.."")</script>")
    '                Exit Sub
    '            End If
    '            If CDate(Valdt) < todt Then
    '                Response.Write("<script>alert(""To Date cannot be Greater than Value as on Date.."")</script>")
    '                Exit Sub
    '            End If

    '            If ddPeriod_SIP.SelectedItem.Text = "Fortnightly" Then
    '                PrdVal = 15
    '            ElseIf ddPeriod_SIP.SelectedItem.Text = "Monthly" Then
    '                PrdVal = 1
    '            ElseIf ddPeriod_SIP.SelectedItem.Text = "Quarterly" Then
    '                PrdVal = 3
    '            End If

    '            Dim SIP_date As Integer
    '            If ddSIPdate.SelectedItem.Text = "02nd" Then
    '                SIP_date = 2
    '            ElseIf ddSIPdate.SelectedItem.Text = "10th" Then
    '                SIP_date = 10
    '            ElseIf ddSIPdate.SelectedItem.Text = "20th" Then
    '                SIP_date = 20
    '            ElseIf ddSIPdate.SelectedItem.Text = "28th" Then
    '                SIP_date = 28
    '            End If

    '            tblSIP1.Visible = True

    '            'PrdVal = 1
    '            Amt = Trim(txtinstall.Text)
    '            Temp = Amt
    '            'changes by Jayendra on 060607
    '            ''''Colstr = "Date#Nav#Units#CashFlow(scheme)#CashFlow(Index)#Amount#SIP Value#Index Value"
    '            Colstr = "Date#NAV#Units#CashFlow(scheme)#Amount#SIP Value"
    '            'end 060607
    '            ColArr = Split(Colstr, "#")
    '            ''''For i = 0 To 7
    '            For i = 0 To 5
    '                Ipcol = New DataColumn
    '                Ipcol.ColumnName = ColArr(i)
    '                Ipdt.Columns.Add(Ipcol)
    '            Next i
    '            Gsp.HeaderStyle.ForeColor = Color.White

    '            'changes by Jayendra on 060607        
    '            scheme_code = Split(ddscheme.SelectedItem.Value, "#")(0)
    '            plan_code = Split(ddscheme.SelectedItem.Value, "#")(1)
    '            'end 060607

    '            'strsql = "Select dateadd(d,276,date),(divid_pt-53)/76,(dividend-53)/76 from div_rec_adv where sch_code='" & ddscheme.SelectedItem.Value & "' And dateadd(d,276,date)>='" & frdt & "' And dateadd(d,276,date)<='" & todt & "' order by dateadd(d,276,date)"

    '            'changes by Jayendra on 060607
    '            '''''strsql = "Select dateadd(d,276,rmf_todt),(rmf_divpercent-53)/76,(rmf_divrate-53)/76 from div_dets where rmf_scheme='" & ddscheme.SelectedItem.Value & "' And dateadd(d,276,rmf_todt)>='" & frdt & "' And dateadd(d,276,rmf_todt)<='" & todt & "' order by dateadd(d,276,rmf_todt)"
    '            strsql = "Select rmf_todt,rmf_divpercent,rmf_divrate from div_dets where rmf_scheme='" & scheme_code & "' and rmf_plan='" & plan_code & "' And rmf_todt>='" & frdt & "' And rmf_todt<='" & todt & "' order by rmf_todt"
    '            'end 060607

    '            sqlcon1 = New SqlConnection(constr)
    '            sqlcon1.Open()
    '            Sqlcom = New SqlCommand(strsql, sqlcon1)
    '            sqlrd1 = Sqlcom.ExecuteReader
    '            If sqlrd1.Read Then
    '                Do
    '                    If IsDBNull(sqlrd1(0)) = False Then
    '                        ReDim Preserve DivArr(m)
    '                        ReDim Preserve DivDt(m)
    '                        DivDt(m) = sqlrd1(0)
    '                        DivArr(m) = sqlrd1(1)
    '                        m += 1
    '                    ElseIf IsDBNull(sqlrd1(1)) = False Then
    '                        ReDim Preserve BonArr(k)
    '                        ReDim Preserve BonDt(k)
    '                        BonDt(k) = sqlrd1(0)
    '                        BonArr(k) = sqlrd1(2)
    '                        k += 1
    '                    End If
    '                Loop While sqlrd1.Read
    '            End If
    '            sqlcon1.Close()
    '            sqlcon1.Dispose()

    '            m = 0
    '            j = 0
    '            k = 0
    '            Arrcount = 0
    '            IndUnits = 0
    '            strdt = Split(Trim(txtfromDate.Text), "/")
    '            Sqlcon = New SqlConnection(constr)
    '            Sqlcon.Open()
    '            'strsql = "Select dateadd(d,276,[date]),(Nav_rs-53)/76 from nav_rec_rel where sch_code='" & ddscheme.SelectedItem.Value & "' And dateadd(d,276,[date]) >='" & frdt & "' And dateadd(d,276,[date])<='" & todt & "' order by dateadd(d,276,[date])"

    '            'changes by Jayendra on 060607
    '            ''''strsql = "Select dateadd(d,276,rmf_todt),(rmf_nav-53)/76 from nav_reg where rmf_scheme='" & ddscheme.SelectedItem.Value & "' And dateadd(d,276,rmf_todt) >='" & frdt & "' And dateadd(d,276,rmf_todt)<='" & todt & "' order by dateadd(d,276,rmf_todt)"
    '            strsql = "Select rmf_todt,rmf_nav from nav_reg where rmf_scheme='" & scheme_code & "' and rmf_plan='" & plan_code & "' And rmf_todt >='" & frdt & "' And rmf_todt<='" & todt & "' order by rmf_todt"
    '            'end 060607

    '            Sqlcom = New SqlCommand(strsql, Sqlcon)
    '            Sqlrd = Sqlcom.ExecuteReader
    '            If Sqlrd.Read Then
    '                Do
    'AfterDiv:
    '                    If j = 0 Then
    '                        CalcDt = Sqlrd(0)
    '                        Iprw = Ipdt.NewRow
    '                        Iprw(0) = Format(CDate(Sqlrd(0)), "dd/MM/yyyy")
    '                        CalcDt = Sqlrd(0)
    '                        ReDim Preserve DtArr(Arrcount)
    '                        DtArr(Arrcount) = Sqlrd(0)
    '                        TempDt = Sqlrd(0)
    '                        Iprw(1) = Math.Round(Sqlrd(1), 4)
    '                        FNav = Sqlrd(1)
    '                        FDate = Sqlrd(0)
    '                        Iprw(2) = Math.Round(Amt / Sqlrd(1), 4)
    '                        TotNav = TotNav + Math.Round(Amt / Sqlrd(1), 4)
    '                        Iprw(3) = Amt * -1
    '                        ReDim Preserve CashFl(Arrcount)
    '                        CashFl(Arrcount) = Iprw(3)
    '                        ''''Iprw(4) = Amt * -1
    '                        ''''ReDim Preserve CashFlInd(Arrcount)
    '                        ''''CashFlInd(Arrcount) = Iprw(4)
    '                        ''''TempUnits = Math.Round(TempUnits + Math.Round(Amt / Sqlrd(1), 4), 4)
    '                        ''''Iprw(5) = Math.Round(Temp, 2)
    '                        ''''If Temp = Amt Then
    '                        ''''    Iprw(6) = Math.Round(Temp, 2)
    '                        ''''Else
    '                        ''''    Iprw(6) = Math.Round(Sqlrd(1) * TempUnits, 2)
    '                        ''''End If
    '                        Iprw(4) = Math.Round(Temp, 2)
    '                        TempUnits = Math.Round(TempUnits + Math.Round(Amt / Sqlrd(1), 4), 4)
    '                        If Temp = Amt Then
    '                            Iprw(5) = Math.Round(Temp, 2)
    '                        Else
    '                            Iprw(5) = Math.Round(Sqlrd(1) * TempUnits, 2)
    '                        End If
    '                        ''''strsql = "Select Top 10 (ind_val-53)/76 from Ind_rec where Ind_code in(Select distinct ind_code from schemeindex where sch_code='" & ddscheme.SelectedItem.Value & "' and  ind_code ='" & benchmark(1) & "') And dateadd(d,276,dt1)>='" & Sqlrd(0) & "' order by dateadd(d,276,dt1)"
    '                        ''''sqlcon1 = New SqlConnection(constr)
    '                        ''''sqlcon1.Open()
    '                        ''''Sqlcom = New SqlCommand(strsql, sqlcon1)
    '                        ''''sqlrd1 = Sqlcom.ExecuteReader
    '                        ''''If sqlrd1.Read Then
    '                        ''''    TempNav = Math.Round(Math.Round(Amt / sqlrd1(0), 4), 4)
    '                        ''''    IndUnits = IndUnits + Math.Round(Math.Round(Amt / sqlrd1(0), 4), 4)
    '                        ''''    currentIndex = Math.Round(sqlrd1(0), 4)
    '                        ''''End If
    '                        ''''sqlcon1.Close()
    '                        ''''sqlcon1.Dispose()
    '                        ''''If Temp = Amt Then
    '                        ''''    Iprw(7) = Math.Round(Temp, 2)
    '                        ''''Else
    '                        ''''    Iprw(7) = Math.Round(currentIndex * IndUnits, 2)
    '                        ''''End If

    '                        Ipdt.Rows.Add(Iprw)
    '                        Temp = Temp + Amt
    '                        j += 1
    '                        Arrcount += 1

    '                        '**change as on 110607
    '                        If Split(Sqlrd(0), "/")(1) < SIP_date Then
    '                            CalcDt = CDate(Split(Sqlrd(0), "/")(0) & "/" & SIP_date & "/" & Split(Sqlrd(0), "/")(2))      'DateAdd(DateInterval.Month, PrdVal, CalcDt)
    '                        Else
    '                            CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
    '                            Tempdtstr = Split(CalcDt, "/")
    '                            CalcDt = CDate(Tempdtstr(0) & "/" & SIP_date & "/" & Tempdtstr(2))
    '                        End If
    '                        ''If Split(Sqlrd(0), "/")(1) < 10 Then
    '                        ''    CalcDt = CDate(Split(Sqlrd(0), "/")(0) & "/" & 10 & "/" & Split(Sqlrd(0), "/")(2))      'DateAdd(DateInterval.Month, PrdVal, CalcDt)
    '                        ''Else
    '                        ''    CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
    '                        ''    Tempdtstr = Split(CalcDt, "/")
    '                        ''    CalcDt = CDate(Tempdtstr(0) & "/" & 10 & "/" & Tempdtstr(2))
    '                        ''End If
    '                        '**end 110607

    '                    ElseIf Sqlrd(0) >= CalcDt And CalcDt <= todt Then
    '                        If IsNothing(DivArr) = False Then
    '                            If m <= UBound(DivDt) Then
    '                                If DivDt(m) >= TempDt And DivDt(m) <= CalcDt Then
    '                                    'strsql = "Select (A.Nav_rs-53)/76,(B.face_val-53)/76 from nav_rec_rel A,Scheme_Info B where A.sch_code=B.sch_code And A.sch_code='" & ddscheme.SelectedItem.Value & "' And dateadd(d,276,A.date)='" & DivDt(m) & "'"

    '                                    'changes by Jayendra on 060607
    '                                    ''''strsql = "Select (A.rmf_nav-53)/76,(B.face_val-53)/76 from nav_reg A,Scheme_Info B where A.rmf_scheme=B.sch_code And A.rmf_scheme='" & ddscheme.SelectedItem.Value & "' And dateadd(d,276,A.rmf_todt)='" & DivDt(m) & "'"
    '                                    'strsql = "Select (A.rmf_nav-53)/76,(B.face_val-53)/76 from nav_reg A,Scheme_Info B where A.rmf_scheme=B.sch_code And A.rmf_scheme='" & scheme_code & "' and A.rmf_plan='" & plan_code & "'  And dateadd(d,276,A.rmf_todt)='" & DivDt(m) & "'"
    '                                    strsql = "Select rmf_nav from nav_reg where rmf_scheme='" & scheme_code & "' and rmf_plan='" & plan_code & "'  And rmf_todt='" & DivDt(m) & "'"
    '                                    'end 060607
    '                                    sqlcon1 = New SqlConnection(constr)
    '                                    sqlcon1.Open()
    '                                    Sqlcom = New SqlCommand(strsql, sqlcon1)
    '                                    sqlrd1 = Sqlcom.ExecuteReader
    '                                    If sqlrd1.Read Then
    '                                        Iprw = Ipdt.NewRow
    '                                        PerUnitDiv = (DivArr(m) * Face_Value(ddscheme.SelectedItem.Value)) / 100
    '                                        PerUnitDiv = PerUnitDiv * TempUnits
    '                                        PerUnitDiv = PerUnitDiv / sqlrd1(0)
    '                                        TempUnits = Math.Round(TempUnits + PerUnitDiv, 4)
    '                                        Iprw(0) = "<B>" & Format(CDate(DivDt(m)), "dd/MM/yyyy") & "</B>"

    '                                        ReDim Preserve DtArr(Arrcount)
    '                                        DtArr(Arrcount) = Sqlrd(0)
    '                                        Iprw(1) = "<B>" & Math.Round(sqlrd1(0), 4) & "</B>"
    '                                        Iprw(2) = "<B>" & Math.Round(PerUnitDiv, 4) & "</B>"
    '                                        TotNav = TotNav + Math.Round(PerUnitDiv, 4)
    '                                        Iprw(3) = "<B>" & "0" & "</B>"
    '                                        ReDim Preserve CashFl(Arrcount)
    '                                        CashFl(Arrcount) = 0
    '                                        ''''Iprw(4) = "<B>" & "0" & "</B>"
    '                                        ''''ReDim Preserve CashFlInd(Arrcount)
    '                                        ''''CashFlInd(Arrcount) = 0
    '                                        Ipdt.Rows.Add(Iprw)
    '                                    End If
    '                                    sqlcon1.Close()
    '                                    sqlcon1.Dispose()
    '                                    m += 1
    '                                    PerUnitDiv = 0
    '                                    Arrcount += 1
    '                                    GoTo AfterDiv
    '                                End If
    '                            End If
    '                        ElseIf IsNothing(BonArr) = False Then
    '                            If k <= UBound(BonDt) Then
    '                                If BonDt(k) >= TempDt And BonDt(k) <= CalcDt Then
    '                                    Iprw = Ipdt.NewRow
    '                                    PerUnitDiv = (TempUnits * Split(BonArr(k), ":")(0)) / Split(BonArr(k), ":")(1)
    '                                    TempUnits = Math.Round(TempUnits + PerUnitDiv, 4)
    '                                    Iprw(0) = "<B>" & Format(CDate(BonDt(m)), "dd/MM/yyyy") & "</B>"
    '                                    ReDim Preserve DtArr(Arrcount)
    '                                    DtArr(Arrcount) = Sqlrd(0)
    '                                    Iprw(2) = "<B>" & Math.Round(PerUnitDiv, 4) & "</B>"
    '                                    TotNav = TotNav + Math.Round(PerUnitDiv, 4)
    '                                    Iprw(3) = "<B>" & "0" & "</B>"
    '                                    ReDim Preserve CashFl(Arrcount)
    '                                    CashFl(Arrcount) = 0
    '                                    ''''Iprw(4) = "<B>" & "0" & "</B>"
    '                                    ''''ReDim Preserve CashFlInd(Arrcount)
    '                                    ''''CashFlInd(Arrcount) = 0
    '                                    k += 1
    '                                    PerUnitDiv = 0
    '                                    Ipdt.Rows.Add(Iprw)
    '                                    Arrcount += 1
    '                                    GoTo AfterDiv
    '                                End If
    '                            End If
    '                        End If
    '                        Iprw = Ipdt.NewRow
    '                        Iprw(0) = Format(CDate(Sqlrd(0)), "dd/MM/yyyy")

    '                        LDate = Sqlrd(0)
    '                        CalcDt = Sqlrd(0)
    '                        ReDim Preserve DtArr(Arrcount)
    '                        DtArr(Arrcount) = Sqlrd(0)
    '                        TempDt = Sqlrd(0)
    '                        Iprw(1) = Math.Round(Sqlrd(1), 4)
    '                        LNav = Sqlrd(1)
    '                        Iprw(2) = Math.Round(Amt / Sqlrd(1), 4)
    '                        TotNav = TotNav + Math.Round(Amt / Sqlrd(1), 4)
    '                        Iprw(3) = Amt * -1
    '                        ReDim Preserve CashFl(Arrcount)
    '                        CashFl(Arrcount) = Iprw(3)
    '                        ''''Iprw(4) = Amt * -1
    '                        ''''ReDim Preserve CashFlInd(Arrcount)
    '                        ''''CashFlInd(Arrcount) = Iprw(4)
    '                        ''''TempUnits = Math.Round(TempUnits + Math.Round(Amt / Sqlrd(1), 4), 4)
    '                        ''''Iprw(5) = Math.Round(Temp, 2)
    '                        ''''If Temp = Amt Then
    '                        ''''    Iprw(6) = Math.Round(Temp, 2)
    '                        ''''Else
    '                        ''''    Iprw(6) = Math.Round(Sqlrd(1) * TempUnits, 2)
    '                        ''''End If
    '                        TempUnits = Math.Round(TempUnits + Math.Round(Amt / Sqlrd(1), 4), 4)
    '                        Iprw(4) = Math.Round(Temp, 2)
    '                        If Temp = Amt Then
    '                            Iprw(5) = Math.Round(Temp, 2)
    '                        Else
    '                            Iprw(5) = Math.Round(Sqlrd(1) * TempUnits, 2)
    '                        End If

    '                        ''''strsql = "Select Top 10 (ind_val-53)/76 from Ind_rec where Ind_code in(Select distinct ind_code from schemeindex where sch_code='" & ddscheme.SelectedItem.Value & "' and  ind_code ='" & benchmark(1) & "') And dateadd(d,276,dt1)>='" & Sqlrd(0) & "' order by dateadd(d,276,dt1)"
    '                        ''''sqlcon1 = New SqlConnection(constr)
    '                        ''''sqlcon1.Open()
    '                        ''''Sqlcom = New SqlCommand(strsql, sqlcon1)
    '                        ''''sqlrd1 = Sqlcom.ExecuteReader
    '                        ''''If sqlrd1.Read Then
    '                        ''''    TempNav = Math.Round(Math.Round(Amt / sqlrd1(0), 4), 4)
    '                        ''''    IndUnits = IndUnits + Math.Round(Math.Round(Amt / sqlrd1(0), 4), 4)
    '                        ''''    currentIndex = Math.Round(sqlrd1(0), 4)
    '                        ''''End If
    '                        ''''sqlcon1.Close()
    '                        ''''sqlcon1.Dispose()
    '                        ''''If Temp = Amt Then
    '                        ''''    Iprw(7) = Math.Round(Temp, 2)
    '                        ''''Else
    '                        ''''    Iprw(7) = Math.Round(currentIndex * IndUnits, 2)
    '                        ''''End If
    '                        ''''If Temp = Amt Then
    '                        ''''    Iprw(5) = Math.Round(Temp, 2)
    '                        ''''Else
    '                        ''''    Iprw(5) = Math.Round(currentIndex * IndUnits, 2)
    '                        ''''End If

    '                        Ipdt.Rows.Add(Iprw)
    '                        Temp = Temp + Amt
    '                        j += 1
    '                        Arrcount += 1

    '                        '** changed on 110607
    '                        If Split(Sqlrd(0), "/")(1) < SIP_date Then
    '                            CalcDt = CDate(Split(Sqlrd(0), "/")(0) & "/" & SIP_date & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
    '                        Else
    '                            CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
    '                            Tempdtstr = Split(CalcDt, "/")
    '                            CalcDt = CDate(Tempdtstr(0) & "/" & SIP_date & "/" & Tempdtstr(2))
    '                        End If

    '                        ''If Split(Sqlrd(0), "/")(1) < 10 Then
    '                        ''    CalcDt = CDate(Split(Sqlrd(0), "/")(0) & "/" & 10 & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
    '                        ''Else
    '                        ''    CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
    '                        ''    Tempdtstr = Split(CalcDt, "/")
    '                        ''    CalcDt = CDate(Tempdtstr(0) & "/" & 10 & "/" & Tempdtstr(2))
    '                        ''End If

    '                    End If
    '                Loop While Sqlrd.Read
    '            End If
    '            Sqlcon.Close()
    '            Sqlcon.Dispose()
    '            TotNav = TotNav

    '            'Checking for the same date nav and index

    '            'strsql = "Select Top 10 (ind_val-53)/76,dateadd(d,276,dt1) from Ind_rec where Ind_code in(Select distinct ind_code from schemeindex where sch_code='" & ddscheme.SelectedItem.Value & "' and  ind_code ='" & benchmark(1) & "') And dateadd(d,276,dt1)>='" & fmt(txtvalason.Text) & "' order by dateadd(d,276,dt1)"
    '            'sqlcon1 = New SqlConnection(constr)
    '            'sqlcon1.Open()
    '            'Sqlcom = New SqlCommand(strsql, sqlcon1)
    '            'sqlrd1 = Sqlcom.ExecuteReader
    '            'If sqlrd1.Read Then
    '            '    Do
    '            '        'strsql = "Select (Nav_rs-53)/76,dateadd(d,276,date) from nav_rec_rel where sch_code='" & ddscheme.SelectedItem.Value & "' And dateadd(d,276,date)='" & sqlrd1(1) & "'"

    '            '        'changes by Jayendra on 060607
    '            '        ''''strsql = "Select (rmf_nav-53)/76,dateadd(d,276,rmf_todt) from nav_reg where rmf_scheme='" & ddscheme.SelectedItem.Value & "' And dateadd(d,276,rmf_todt)='" & sqlrd1(1) & "'"
    '            '        strsql = "Select (rmf_nav-53)/76,dateadd(d,276,rmf_todt) from nav_reg where rmf_scheme='" & scheme_code & "' and rmf_plan='" & plan_code & "' And dateadd(d,276,rmf_todt)='" & sqlrd1(1) & "'"
    '            '        'end 060607
    '            '        Sqlcon = New SqlConnection(constr)
    '            '        Sqlcon.Open()
    '            '        Sqlcom = New SqlCommand(strsql, Sqlcon)
    '            '        Sqlrd = Sqlcom.ExecuteReader
    '            '        If Sqlrd.Read Then
    '            '            If IsDBNull(Sqlrd(0)) = False Then
    '            '                TotNav = TotNav * Sqlrd(0)
    '            '                Iprw = Ipdt.NewRow
    '            '                Iprw(0) = Format(CDate(Sqlrd(1)), "dd/MM/yyyy")
    '            '                LDate = Sqlrd(1)
    '            '                Iprw(1) = Sqlrd(0)
    '            '                LNav = Sqlrd(0)
    '            '                ''''Iprw(5) = Math.Round(TotNav, 2)
    '            '                Iprw(4) = Math.Round(TotNav, 2)
    '            '                Ipdt.Rows.Add(Iprw)
    '            '                ''''IndUnits = IndUnits * sqlrd1(0)
    '            '                Exit Do
    '            '            End If
    '            '        End If
    '            '        Sqlcon.Close()
    '            '        Sqlcon.Dispose()
    '            '    Loop While sqlrd1.Read
    '            'End If
    '            sqlcon1.Close()
    '            sqlcon1.Dispose()

    '            Session("SIP") = Ipdt
    '            Gsp.DataSource = Ipdt
    '            Gsp.DataBind()
    '            Gsp.Visible = True

    '            Dim Dt As String = ""
    '            Dim cashflw As String = ""
    '            Dim cashindx As String = ""

    '            If IsNothing(DtArr) = False Then
    '                For i = 0 To UBound(DtArr)
    '                    If Dt = "" Then
    '                        Dt = Format(DtArr(i), "dd/MM/yyyy")
    '                    Else
    '                        Dt = Dt & "," & Format(DtArr(i), "dd/MM/yyyy")
    '                    End If
    '                    If cashflw = "" Then
    '                        cashflw = CashFl(i)
    '                    Else
    '                        cashflw = cashflw & "," & CashFl(i)
    '                    End If
    '                    ''''If cashindx = "" Then
    '                    ''''    cashindx = CashFlInd(i)
    '                    ''''Else
    '                    ''''    cashindx = cashindx & "," & CashFlInd(i)
    '                    ''''End If
    '                Next i
    '            End If

    '            Dt = Dt & "," & CDate(fmt(txtvalason.Text))
    '            cashflw = cashflw & "," & TotNav
    '            getXirr = XIRR(Dt, cashflw)
    '            txtxsch.Text = Math.Round(getXirr, 2)

    '            'If Sqlcon.State = ConnectionState.Open Then
    '            '    Sqlcon.Close()
    '            'End If
    '            'Sqlcon = New SqlConnection(constr)
    '            'Sqlcon.Open()
    '            'Sqlcom = New SqlCommand("xirrs", Sqlcon)
    '            'Dt = Dt & "," & CDate(fmt(txtvalason.Text))
    '            'cashflw = cashflw & "," & TotNav
    '            ''''cashindx = cashindx & "," & IndUnits
    '            'With Sqlcom

    '            '    .CommandType = CommandType.StoredProcedure
    '            '    .Parameters.Add("@dstr", SqlDbType.VarChar, 5000).Value = Dt
    '            '    .Parameters.Add("@astr", SqlDbType.VarChar, 5000).Value = cashflw
    '            '    .Parameters.Add("@xirrx", SqlDbType.Float).Direction = ParameterDirection.Output
    '            '    .ExecuteNonQuery()
    '            'End With
    '            'getXirr = Math.Round(Sqlcom.Parameters("@xirrx").Value, 2)
    '            'Sqlcom.Dispose() : Sqlcon.Close() : Sqlcon.Dispose()
    '            'txtxsch.Text = getXirr

    '            'If Sqlcon.State = ConnectionState.Open Then
    '            '    Sqlcon.Close()
    '            'End If

    '            ''''Sqlcon = New SqlConnection(constr)
    '            ''''Sqlcon.Open()
    '            ''''Sqlcom = New SqlCommand("xirrs", Sqlcon)
    '            ''''With Sqlcom
    '            ''''    .CommandType = CommandType.StoredProcedure
    '            ''''    .Parameters.Add("@dstr", SqlDbType.VarChar, 5000).Value = Dt
    '            ''''    .Parameters.Add("@astr", SqlDbType.VarChar, 5000).Value = cashindx
    '            ''''    .Parameters.Add("@xirrx", SqlDbType.Float).Direction = ParameterDirection.Output
    '            ''''    .ExecuteNonQuery()
    '            ''''End With
    '            ''''getXirr = Math.Round(Sqlcom.Parameters("@xirrx").Value, 2)
    '            ''''Sqlcom.Dispose() : Sqlcon.Close() : Sqlcon.Dispose()
    '            ''''txtxind.Text = getXirr

    '            txtonttm.Text = Math.Round((Math.Pow((LNav / FNav), 365 / DateDiff(DateInterval.Day, FDate, LDate)) - 1) * 100, 4)
    '            'cmdexp.Attributes.Add("onClick", "javascript:newexports('Gsp','Gsp',0,'" & txtxsch.Text & "','" & txtxind.Text & "','" & txtonttm.Text & "',' ','" & ddscheme.SelectedItem.Text & "');return false;")
    '            cmdexp.Attributes.Add("onClick", "javascript:newexports('Gsp','Gsp',2,'" & txtxsch.Text & "',' ','" & txtonttm.Text & "',' ','" & ddscheme.SelectedItem.Text & "');return false;")
    '        Catch ex As Exception

    '        End Try
    '    End Sub

    'Private Sub btnwshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnwshow.Click
    '    Dim x As Integer = 0
    '    Dim i As Integer = 0
    '    Dim j As Integer = 0
    '    Dim frdt As Date
    '    Dim todt As Date
    '    Dim Valdt As Date
    '    Dim PrdVal As Integer = 1
    '    Dim Amt As Double
    '    Dim Temp As Double
    '    'Dim Colstr As String = "Date#Nav#Units#CashFlow#Amount#SWP Value#Index Value"
    '    Dim Colstr As String = "Date#Nav#Units#CashFlow#Amount#SWP Value"
    '    Dim ColArr() As String
    '    Dim Ipcol As DataColumn
    '    Dim CalcDt As Date
    '    Dim DtArr() As Date
    '    Dim CshFlow() As Double
    '    Dim Arrcount As Integer = 0
    '    Dim Tempdtstr() As String
    '    Dim TrueFlg As Boolean = False
    '    Dim chkdate As Date
    '    Dim Pl As Integer = 0
    '    Dim LastUnits As Double = 0
    '    Dim LastCash As Double = 0
    '    Dim TempNav As Double = 0
    '    Dim currentIndex As Double = 0
    '    Dim rowcount As Integer = 0
    '    Dim Temptotal As Double = 0
    '    Dim prev_idx_value As Double
    '    Dim prev_idx As Double
    '    Dim sip_amount As Double
    '    Dim tmp_idx As Double

    '    'changes by Jayendra on 060607        
    '    Dim scheme_code As String
    '    Dim plan_code As String

    '    Try
    '        scheme_code = ""
    '        plan_code = ""
    '        'end 060607



    '        If ddPlan.SelectedItem.Text = "--" Then
    '            Response.Write("<script>alert(""Please Select Any Plan.."")</script>")
    '            Exit Sub
    '        End If
    '        If ddwscname.SelectedItem.Text = "--" Then
    '            Response.Write("<script>alert(""Please Select Scheme.."")</script>")
    '            Exit Sub
    '        End If
    '        ''''If ddwbnmark.SelectedItem.Text = "--" Then
    '        ''''    txtMess.Value = "Please Select Benchmark.."
    '        ''''    Exit Sub
    '        ''''End If
    '        If Val(txtwinamt.Text) = 0 Then
    '            Response.Write("<script>alert(""Initial Amount Cannot Be Blank.."")</script>")
    '            Exit Sub
    '        End If
    '        If Val(txtwtramt.Text) = 0 Then
    '            Response.Write("<script>alert(""Withdrawl Amount Cannot Be Blank.."")</script>")
    '            Exit Sub
    '        End If
    '        If txtwfrdt.Text = "" Or txtwtdt.Text = "" Or txtwvaldate.Text = "" Then
    '            Response.Write("<script>alert(""From Date / To Date / Value As on Date Can Not be Blank.."")</script>")
    '            Exit Sub
    '        End If

    '        ''''If rbwind.Checked = False And rbwcorp.Checked = False Then
    '        ''''    txtMess.Value = "Please Select Option for Dividend (Individual/Corporate)  .."
    '        ''''    Exit Sub
    '        ''''End If
    '        For i = 1 To Len(txtwfrdt.Text)
    '            If Mid(Trim(txtwfrdt.Text), i, 1) = "/" Then
    '                x += 1
    '            End If
    '        Next i
    '        If x <> 2 Then
    '            Response.Write("<script>alert(""Please Enter From Date in proper format.."")</script>")
    '            Exit Sub
    '        End If
    '        i = 0
    '        x = 0

    '        For i = 1 To Len(txtwtdt.Text)
    '            If Mid(Trim(txtwtdt.Text), i, 1) = "/" Then
    '                x += 1
    '            End If
    '        Next i
    '        If x <> 2 Then
    '            Response.Write("<script>alert(""Please Enter To Date in proper format.."")</script>")
    '            Exit Sub
    '        End If
    '        i = 0
    '        x = 0

    '        For i = 1 To Len(txtwvaldate.Text)
    '            If Mid(Trim(txtwvaldate.Text), i, 1) = "/" Then
    '                x += 1
    '            End If
    '        Next i
    '        If x <> 2 Then
    '            Response.Write("<script>alert(""Please Value as on Date in proper format.."")</script>")
    '            Exit Sub
    '        End If
    '        i = 0
    '        x = 0

    '        If IsDate(fmt(Trim(txtwfrdt.Text))) = False Or IsDate(fmt(Trim(txtwtdt.Text))) = False Or IsDate(fmt(Trim(txtwvaldate.Text))) = False Then
    '            txtMess.Value = "Please Enter The Dates in Proper Formats (dd/mm/yyyy).."
    '            Response.Write("<script>alert(""Please Value as on Date in proper format.."")</script>")
    '            Exit Sub
    '        End If
    '        Ipdt = New DataTable
    '        frdt = Split(Trim(txtwfrdt.Text), "/")(1) & "/" & Split(Trim(txtwfrdt.Text), "/")(0) & "/" & Split(Trim(txtwfrdt.Text), "/")(2)
    '        todt = Split(Trim(txtwtdt.Text), "/")(1) & "/" & Split(Trim(txtwtdt.Text), "/")(0) & "/" & Split(Trim(txtwtdt.Text), "/")(2)
    '        Valdt = Split(Trim(txtwvaldate.Text), "/")(1) & "/" & Split(Trim(txtwvaldate.Text), "/")(0) & "/" & Split(Trim(txtwvaldate.Text), "/")(2)


    '        If Val(txtwinamt.Text) < Val(txtwtramt.Text) Then
    '            Response.Write("<script>alert(""Withdrawl Amount cannot be Greater than Initial Amount.."")</script>")
    '            Exit Sub
    '        End If
    '        If CDate(todt) <= frdt Then
    '            Response.Write("<script>alert(""From Date cannot be Greater than To Date.."")</script>")
    '            Exit Sub
    '        End If
    '        If CDate(Valdt) < todt Then
    '            Response.Write("<script>alert(""To Date cannot be Greater than Value as on Date.."")</script>")
    '            Exit Sub
    '        End If

    '        If ddwperiod.SelectedItem.Text = "Fortnightly" Then
    '            PrdVal = 15
    '        ElseIf ddwperiod.SelectedItem.Text = "Monthly" Then
    '            PrdVal = 1
    '        ElseIf ddwperiod.SelectedItem.Text = "Quarterly" Then
    '            PrdVal = 3
    '        End If

    '        tblSWP1.Visible = True

    '        Dim SWP_date As Integer
    '        If ddSWPDate.SelectedItem.Text = "02nd" Then
    '            SWP_date = 2
    '        ElseIf ddSWPDate.SelectedItem.Text = "10th" Then
    '            SWP_date = 10
    '        ElseIf ddSWPDate.SelectedItem.Text = "20th" Then
    '            SWP_date = 20
    '        ElseIf ddSWPDate.SelectedItem.Text = "28th" Then
    '            SWP_date = 28
    '        End If

    '        'PrdVal = 1
    '        Amt = Trim(txtwinamt.Text)
    '        Temp = Amt

    '        ColArr = Split(Colstr, "#")
    '        ''''For i = 0 To 6
    '        For i = 0 To 5
    '            Ipcol = New DataColumn
    '            Ipcol.ColumnName = ColArr(i)
    '            Ipdt.Columns.Add(Ipcol)
    '        Next i
    '        Dgswp.HeaderStyle.ForeColor = Color.White

    '        prev_idx_value = Val(txtwinamt.Text)
    '        prev_idx = 1
    '        sip_amount = Val(txtwtramt.Text)

    '        'changes by Jayendra on 060607        
    '        scheme_code = Split(ddwscname.SelectedItem.Value, "#")(0)
    '        plan_code = Split(ddwscname.SelectedItem.Value, "#")(1)
    '        'end 060607

    '        Temptotal = Val(txtwtramt.Text)
    '        Sqlcon = New SqlConnection(constr)
    '        Sqlcon.Open()
    '        'changes by Jayendra on 060607
    '        ''''strsql = "Select dateadd(d,276,rmf_todt),(rmf_nav-53)/76 from nav_reg where rmf_scheme ='" & ddwscname.SelectedItem.Value & "' And dateadd(d,276,rmf_todt) >='" & frdt & "' And dateadd(d,276,rmf_todt)<='" & todt & "' order by dateadd(d,276,rmf_todt)"
    '        strsql = "Select rmf_todt,rmf_nav from nav_reg where rmf_scheme ='" & scheme_code & "' and rmf_plan='" & plan_code & "' And rmf_todt >='" & frdt & "' And rmf_todt<='" & todt & "' order by rmf_todt"
    '        'end 060607
    '        Sqlcom = New SqlCommand(strsql, Sqlcon)
    '        Sqlrd = Sqlcom.ExecuteReader
    '        If Sqlrd.Read Then
    '            chkdate = Sqlrd(0)

    '            '**change as on 110607
    '            'If Split(Sqlrd(0), "/")(1) < 10 Then
    '            '    chkdate = CDate(Split(Sqlrd(0), "/")(0) & "/" & 10 & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
    '            'Else
    '            '    chkdate = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
    '            '    Tempdtstr = Split(chkdate, "/")
    '            '    chkdate = CDate(Tempdtstr(0) & "/" & 10 & "/" & Tempdtstr(2))
    '            'End If
    '            If Split(Sqlrd(0), "/")(1) < SWP_date Then
    '                chkdate = CDate(Split(Sqlrd(0), "/")(0) & "/" & SWP_date & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
    '            Else
    '                chkdate = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
    '                Tempdtstr = Split(chkdate, "/")
    '                chkdate = CDate(Tempdtstr(0) & "/" & SWP_date & "/" & Tempdtstr(2))
    '            End If

    '            Do
    '                If j = 0 Then
    '                    If Sqlrd(0) >= chkdate And chkdate <= todt Then
    '                        Iprw = Ipdt.NewRow
    '                        Iprw(0) = Format(CDate(Sqlrd(0)), "dd/MM/yyyy")
    '                        CalcDt = Sqlrd(0)
    '                        ReDim Preserve DtArr(Arrcount)
    '                        DtArr(Arrcount) = Sqlrd(0)
    '                        Iprw(1) = Math.Round(Sqlrd(1), 4)
    '                        Iprw(2) = Math.Round(Amt / Sqlrd(1), 4)
    '                        Iprw(3) = Amt * -1
    '                        ReDim Preserve CshFlow(Arrcount)
    '                        CshFlow(Arrcount) = Iprw(3)
    '                        Iprw(4) = Amt
    '                        Iprw(5) = Amt
    '                        ''''Iprw(6) = Amt
    '                        ''''strsql = "Select Top 10 (ind_val-53)/76 from Ind_rec where Ind_code=(Select distinct ind_code from schemeindex where sch_code='" & ddwscname.SelectedItem.Value & "') And dateadd(d,276,dt1)>='" & Sqlrd(0) & "' order by dateadd(d,276,dt1)"
    '                        ''''sqlcon1 = New SqlConnection(constr)
    '                        ''''sqlcon1.Open()
    '                        ''''Sqlcom = New SqlCommand(strsql, sqlcon1)
    '                        ''''sqlrd1 = Sqlcom.ExecuteReader
    '                        ''''If sqlrd1.Read Then
    '                        ''''    prev_idx = sqlrd1(0)
    '                        ''''End If
    '                        ''''sqlcon1.Close()
    '                        ''''sqlcon1.Dispose()
    '                        Ipdt.Rows.Add(Iprw)
    '                        Temp = Temp + Amt
    '                        j += 1
    '                        rowcount += 1
    '                        Arrcount += 1

    '                        'changes on 110607
    '                        ''If Split(Sqlrd(0), "/")(1) < 10 Then
    '                        ''    CalcDt = CDate(Split(Sqlrd(0), "/")(0) & "/" & 10 & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
    '                        ''Else
    '                        ''    CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
    '                        ''    Tempdtstr = Split(CalcDt, "/")
    '                        ''    CalcDt = CDate(Tempdtstr(0) & "/" & 10 & "/" & Tempdtstr(2))
    '                        ''End If
    '                        If Split(Sqlrd(0), "/")(1) < SWP_date Then
    '                            CalcDt = CDate(Split(Sqlrd(0), "/")(0) & "/" & SWP_date & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
    '                        Else
    '                            CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
    '                            Tempdtstr = Split(CalcDt, "/")
    '                            CalcDt = CDate(Tempdtstr(0) & "/" & SWP_date & "/" & Tempdtstr(2))
    '                        End If
    '                        '* end 110607

    '                    End If
    '                ElseIf Sqlrd(0) >= CalcDt And CalcDt <= todt Then

    '                    Iprw = Ipdt.NewRow
    '                    Iprw(0) = Format(CDate(Sqlrd(0)), "dd/MM/yyyy")
    '                    CalcDt = Sqlrd(0)
    '                    ReDim Preserve DtArr(Arrcount)
    '                    DtArr(Arrcount) = Sqlrd(0)
    '                    If Temptotal <= Amt Then
    '                        Iprw(1) = Math.Round(Sqlrd(1), 4)
    '                        Iprw(2) = Math.Round((Ipdt.Rows(rowcount - 1).Item(2)) - (Val(txtwtramt.Text) / Sqlrd(1)), 4)
    '                        LastUnits = Iprw(2)
    '                        Iprw(3) = Val(txtwtramt.Text)
    '                        ReDim Preserve CshFlow(Arrcount)
    '                        CshFlow(Arrcount) = Iprw(3)
    '                        Iprw(4) = Amt - Temptotal
    '                        Temptotal = Temptotal + Val(txtwtramt.Text)
    '                        Iprw(5) = Math.Round(Iprw(1) * Iprw(2), 2)

    '                        ''''strsql = "Select Top 10 (ind_val-53)/76 from Ind_rec where Ind_code=(Select distinct ind_code from schemeindex where sch_code='" & ddwscname.SelectedItem.Value & "') And dateadd(d,276,dt1)>='" & Sqlrd(0) & "' order by dateadd(d,276,dt1)"
    '                        ''''sqlcon1 = New SqlConnection(constr)
    '                        ''''sqlcon1.Open()
    '                        ''''Sqlcom = New SqlCommand(strsql, sqlcon1)
    '                        ''''sqlrd1 = Sqlcom.ExecuteReader
    '                        ''''If sqlrd1.Read Then
    '                        ''''    tmp_idx = sqlrd1(0)
    '                        ''''    Iprw(6) = Math.Round(((prev_idx_value / prev_idx) - (sip_amount / tmp_idx)) * tmp_idx, 2)
    '                        ''''    prev_idx_value = Iprw(6)
    '                        ''''    prev_idx = tmp_idx
    '                        ''''Else
    '                        ''''    Iprw(6) = 0
    '                        ''''End If
    '                        ''''sqlcon1.Close()
    '                        ''''sqlcon1.Dispose()
    '                    End If
    '                    Ipdt.Rows.Add(Iprw)
    '                    Temp = Temp + Amt
    '                    j += 1
    '                    Arrcount += 1
    '                    rowcount += 1

    '                    '**changes on 110607
    '                    ''If Split(Sqlrd(0), "/")(1) < 10 Then
    '                    ''    CalcDt = CDate(Split(Sqlrd(0), "/")(0) & "/" & 10 & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
    '                    ''Else
    '                    ''    CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
    '                    ''    Tempdtstr = Split(CalcDt, "/")
    '                    ''    CalcDt = CDate(Tempdtstr(0) & "/" & 10 & "/" & Tempdtstr(2))
    '                    ''End If
    '                    If Split(Sqlrd(0), "/")(1) < SWP_date Then
    '                        CalcDt = CDate(Split(Sqlrd(0), "/")(0) & "/" & SWP_date & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
    '                    Else
    '                        CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
    '                        Tempdtstr = Split(CalcDt, "/")
    '                        CalcDt = CDate(Tempdtstr(0) & "/" & SWP_date & "/" & Tempdtstr(2))
    '                    End If
    '                    '** end 110607
    '                End If

    '            Loop While Sqlrd.Read
    '        End If
    '        Sqlcon.Close()
    '        Sqlcon.Dispose()

    '        'Checking for the same date nav and index
    '        ''''strsql = "Select Top 10 (ind_val-53)/76,dateadd(d,276,dt1) from Ind_rec where Ind_code=(Select distinct ind_code from schemeindex where sch_code='" & ddwscname.SelectedItem.Value & "') And dateadd(d,276,dt1)>='" & fmt(txtwvaldate.Text) & "' order by dateadd(d,276,dt1)"
    '        ''''sqlcon1 = New SqlConnection(constr)
    '        ''''sqlcon1.Open()
    '        ''''Sqlcom = New SqlCommand(strsql, sqlcon1)
    '        ''''sqlrd1 = Sqlcom.ExecuteReader
    '        ''''If sqlrd1.Read Then
    '        ''''    Do
    '        ''''        'changes by Jayendra on 060607
    '        ''''        ''''strsql = "Select (rmf_nav-53)/76,dateadd(d,276,rmf_todt) from nav_reg where rmf_scheme ='" & ddwscname.SelectedItem.Value & "' And dateadd(d,276,rmf_todt)='" & sqlrd1(1) & "'"
    '        ''''        strsql = "Select (rmf_nav-53)/76,dateadd(d,276,rmf_todt) from nav_reg where rmf_scheme ='" & scheme_code & "' and rmf_plan='" & plan_code & "' And dateadd(d,276,rmf_todt)='" & sqlrd1(1) & "'"
    '        ''''        'end 060607
    '        ''''        Sqlcon = New SqlConnection(constr)
    '        ''''        Sqlcon.Open()
    '        ''''        Sqlcom = New SqlCommand(strsql, Sqlcon)
    '        ''''        Sqlrd = Sqlcom.ExecuteReader
    '        ''''        If Sqlrd.Read Then
    '        ''''            If IsDBNull(Sqlrd(0)) = False Then
    '        ''''                Iprw = Ipdt.NewRow
    '        ''''                Iprw(0) = Format(CDate(Sqlrd(1)), "dd/MM/yyyy")
    '        ''''                Iprw(1) = Sqlrd(0)
    '        ''''                Iprw(2) = LastUnits
    '        ''''                Iprw(3) = Math.Round(Iprw(1) * Iprw(2), 2)
    '        ''''                LastCash = Iprw(3)
    '        ''''                Ipdt.Rows.Add(Iprw)
    '        ''''                Exit Do
    '        ''''            End If
    '        ''''        End If
    '        ''''        Sqlcon.Close()
    '        ''''        Sqlcon.Dispose()
    '        ''''    Loop While sqlrd1.Read
    '        ''''End If
    '        ''''sqlcon1.Close()
    '        ''''sqlcon1.Dispose()

    '        Dgswp.DataSource = Ipdt
    '        Dgswp.DataBind()
    '        Dgswp.Visible = True

    '        Dim Dt As String = ""
    '        Dim cashflw As String = ""
    '        Dim cashindx As String = ""

    '        If IsNothing(CshFlow) = False Then
    '            For i = 0 To UBound(CshFlow)
    '                If Dt = "" Then
    '                    Dt = Format(DtArr(i), "dd/MM/yyyy")
    '                Else
    '                    Dt = Dt & "," & Format(DtArr(i), "dd/MM/yyyy")
    '                End If
    '                If cashflw = "" Then
    '                    cashflw = CshFlow(i)
    '                Else
    '                    cashflw = cashflw & "," & CshFlow(i)
    '                End If
    '                'If cashindx = "" Then
    '                '    cashindx = CashFlInd(i)
    '                'Else
    '                '    cashindx = cashindx & "," & CashFlInd(i)
    '                'End If
    '            Next i
    '        End If

    '        If Sqlcon.State = ConnectionState.Open Then
    '            Sqlcon.Close()
    '        End If

    '        Dt = Dt & "," & CDate(fmt(txtwvaldate.Text))
    '        cashflw = cashflw & "," & (LastCash) * -1
    '        getXirr = XIRR(Dt, cashflw)
    '        txtwyield.Text = Math.Round(getXirr, 2)

    '        ''Sqlcon = New SqlConnection(constr)
    '        ''Sqlcon.Open()
    '        ''Sqlcom = New SqlCommand("xirrs", Sqlcon)
    '        ''Dt = Dt & "," & CDate(fmt(txtwvaldate.Text))
    '        ''cashflw = cashflw & "," & (LastCash) * -1
    '        '''cashindx = cashindx & "," & IndUnits
    '        ''With Sqlcom

    '        ''    .CommandType = CommandType.StoredProcedure
    '        ''    .Parameters.Add("@dstr", SqlDbType.VarChar, 5000).Value = Dt
    '        ''    .Parameters.Add("@astr", SqlDbType.VarChar, 5000).Value = cashflw
    '        ''    .Parameters.Add("@xirrx", SqlDbType.Float).Direction = ParameterDirection.Output
    '        ''    .ExecuteNonQuery()
    '        ''End With
    '        ''getXirr = Math.Round(Sqlcom.Parameters("@xirrx").Value, 2)
    '        ''Sqlcom.Dispose() : Sqlcon.Close() : Sqlcon.Dispose()
    '        ''txtwyield.Text = getXirr

    '        btnwexport.Attributes.Add("onClick", "javascript:newexports('Dgswp','Dgswp',0,'" & Val(txtwyield.Text) & "','','','','" & ddwscname.SelectedItem.Text & "');return false;")

    '        Dgswp.DataSource = Ipdt
    '        Dgswp.DataBind()
    '        Dgswp.Visible = True
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub cmdrs1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            tblSIP.Visible = True
            tblSIP1.Visible = False
            tblSTP.Visible = False
            tblSTP1.Visible = False
            tblSWP.Visible = False
            tblSWP1.Visible = False
            Label25.Visible = True
            ddlsipbnmark.Visible = True
            tblSWP_rdo.Visible = False
            Label18.Visible = True
            txtxind.Visible = True
            ddscheme.SelectedIndex = 0
            txtfromDate.Text = ""
            txtTdate.Text = ""
            txtinstall.Text = ""
            txtvalason.Text = ""
            hdIsGraphExist.Value = 1
            ''''ddscheme.SelectedIndex = 0
            ''''ddSIPdate.SelectedIndex = 0
            ddPeriod_SIP.SelectedIndex = 0
            ddlsipbnmark.SelectedIndex = 0

            ''''txtfromDate.Text = ""
            ''''txtTdate.Text = ""
            ''''txtinstall.Text = ""
            ''''txtvalason.Text = ""
            Gsp.Columns.Clear()
        Catch ex As Exception

        End Try
    End Sub

    '    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
    '        Dim frdt As Date
    '        Dim todt As Date
    '        Dim Valdt As Date
    '        Dim Colstr As String
    '        Dim ColArr() As String
    '        Dim m As Integer = 0
    '        Dim j As Integer = 0
    '        Dim k As Integer = 0
    '        Dim x As Integer = 0
    '        Dim Periodcty As String
    '        Dim PrdVal As Integer = 0
    '        Dim CalcDt As Date
    '        Dim Amt As Double = 0
    '        Dim Temp As Double = 0
    '        Dim CashFlow As Double = 0
    '        Dim CumUnts As Double = 0
    '        Dim NewUnts As Double = 0
    '        Dim Indexval As String
    '        Dim IndexArr() As Double
    '        Dim ValueAfter() As Double
    '        Dim CashInd As Double = 0
    '        Dim IniIndex As Double = 0
    '        Dim Rowcounter As Integer = 0
    '        Dim TotNav As Double = 0
    '        Dim DtArr() As Date
    '        Dim Currval() As Double
    '        Dim Rowcount As Integer = 0
    '        Dim FinalUnts As Double = 0
    '        Dim UntsRdmd As Double = 0
    '        Dim TotUnits As Double = 0
    '        Dim X1units As Double = 0
    '        Dim X1Nav As Double = 0
    '        Dim X1Date As Date
    '        Dim X2Date As Date
    '        Dim X2Nav As Double = 0
    '        Dim Tempdtstr(2) As String
    '        Dim Pl As Integer = 0
    '        Dim chkdate As Date
    '        Dim TrueFlg As Boolean = False
    '        Dim NewFlg As Boolean = False
    '        Dim TranDtArr() As Date

    '        'changes by Jayendra on 060607        
    '        Dim scheme_code_from As String
    '        Dim plan_code_from As String
    '        Dim scheme_code_to As String
    '        Dim plan_code_to As String

    '        Try
    '            scheme_code_from = ""
    '            plan_code_from = ""
    '            scheme_code_to = ""
    '            plan_code_to = ""
    '            'end 060607                
    '            Dim STP_date As Integer
    '            STP_date = 10
    '            If ddSTPDate.SelectedItem.Text = "02nd" Then
    '                STP_date = 2
    '            ElseIf ddSTPDate.SelectedItem.Text = "10th" Then
    '                STP_date = 10
    '            ElseIf ddSTPDate.SelectedItem.Text = "20th" Then
    '                STP_date = 20
    '            ElseIf ddSTPDate.SelectedItem.Text = "28th" Then
    '                STP_date = 28
    '            End If

    '            If ddPlan.SelectedItem.Text = "--" Then
    '                Response.Write("<script>alert(""Please Select Any Plan.."")</script>")
    '                Exit Sub
    '            End If
    '            If ddperiod.SelectedItem.Text = "--" Then
    '                Response.Write("<script>alert(""Please Select Any Periodicity.."")</script>")
    '                Exit Sub
    '            End If
    '            If ddtrfrom.SelectedItem.Text = "--" Then
    '                Response.Write("<script>alert(""Please Select Transfer From Scheme.."")</script>")
    '                Exit Sub
    '            End If
    '            If ddtrto.SelectedItem.Text = "--" Then
    '                Response.Write("<script>alert(""Please Select Transfer To Scheme.."")</script>")
    '                Exit Sub
    '            End If
    '            ''''If ddbnmark.SelectedItem.Text = "--" Then
    '            ''''    Response.Write("<script>alert(""Please Select Transfer To Scheme.."")</script>")
    '            ''''    Exit Sub
    '            ''''End If
    '            If Val(txtiniamt.Text) = 0 Then
    '                Response.Write("<script>alert(""Installment Amount Cannot Be Blank.."")</script>")
    '                Exit Sub
    '            End If
    '            If rbfixed.Checked = True Then
    '                If Val(txttranamt.Text) = 0 Then
    '                    Response.Write("<script>alert(""Transfer Amount Cannot Be Blank.."")</script>")
    '                    Exit Sub
    '                End If
    '            End If
    '            If txtfrdt.Text = "" Or txttodt.Text = "" Then
    '                Response.Write("<script>alert(""From Date / To Date Can Not be Blank.."")</script>")
    '                Exit Sub
    '            End If
    '            If Val(txtvalue.Text) = 0 Then
    '                Response.Write("<script>alert(""Please Enter Value As on Date.."")</script>")
    '                Exit Sub
    '            End If
    '            ''''If rbcapital.Checked = False And rbfixed.Checked = False Then
    '            ''''    Response.Write("<script>alert(""Please Select Option Capital Transfer/Fixed Transfer options .."")</script>")
    '            ''''    Exit Sub
    '            ''''End If
    '            ''''If rbindivd.Checked = False And rbcorp.Checked = False Then
    '            ''''    Response.Write("<script>alert(""Please Select Option for Dividend (Individual/Corporate)  .."")</script>")
    '            ''''    Exit Sub
    '            ''''End If
    '            ''''If rbcapital.Checked = True Then
    '            ''''    Call fillcapital()
    '            ''''    Exit Sub
    '            ''''End If
    '            For i = 1 To Len(txtfrdt.Text)
    '                If Mid(Trim(txtfrdt.Text), i, 1) = "/" Then
    '                    x += 1
    '                End If
    '            Next i
    '            If x <> 2 Then
    '                Response.Write("<script>alert(""Please Enter From Date in proper format.."")</script>")
    '                Exit Sub
    '            End If
    '            i = 0
    '            x = 0

    '            For i = 1 To Len(txttodt.Text)
    '                If Mid(Trim(txttodt.Text), i, 1) = "/" Then
    '                    x += 1
    '                End If
    '            Next i
    '            If x <> 2 Then
    '                Response.Write("<script>alert(""Please Enter To Date in proper format.."")</script>")
    '                Exit Sub
    '            End If
    '            i = 0
    '            x = 0

    '            For i = 1 To Len(txtvalue.Text)
    '                If Mid(Trim(txtvalue.Text), i, 1) = "/" Then
    '                    x += 1
    '                End If
    '            Next i
    '            If x <> 2 Then
    '                Response.Write("<script>alert(""Please Value as on Date in proper format.."")</script>")
    '                Exit Sub
    '            End If
    '            i = 0
    '            x = 0

    '            If IsDate(fmt(Trim(txtfrdt.Text))) = False Or IsDate(fmt(Trim(txttodt.Text))) = False Or IsDate(fmt(Trim(txtvalue.Text))) = False Then
    '                Response.Write("<script>alert(""Please Enter The Dates in Proper Formats (dd/mm/yyyy).."")</script>")
    '                Exit Sub
    '            End If
    '            Ipdt = New DataTable
    '            todt = Split(Trim(txttodt.Text), "/")(1) & "/" & Split(Trim(txttodt.Text), "/")(0) & "/" & Split(Trim(txttodt.Text), "/")(2)
    '            frdt = Split(Trim(txtfrdt.Text), "/")(1) & "/" & Split(Trim(txtfrdt.Text), "/")(0) & "/" & Split(Trim(txtfrdt.Text), "/")(2)
    '            Valdt = Split(Trim(txtvalue.Text), "/")(1) & "/" & Split(Trim(txtvalue.Text), "/")(0) & "/" & Split(Trim(txtvalue.Text), "/")(2)


    '            If Val(txtiniamt.Text) < Val(txttranamt.Text) Then
    '                Response.Write("<script>alert(""Transfer Amount cannot be Greater than Initial Amount.."")</script>")
    '                Exit Sub
    '            End If
    '            If CDate(todt) <= frdt Then
    '                Response.Write("<script>alert(""From Date cannot be Greater than To Date.."")</script>")
    '                Exit Sub
    '            End If
    '            If CDate(Valdt) < todt Then
    '                Response.Write("<script>alert(""To Date cannot be Greater than Value as on Date.."")</script>")
    '                Exit Sub
    '            End If

    '            tblSTP1.Visible = True

    '            L1.Text = "Transfer From :"
    '            L2.Text = "Transfer To :"
    '            L1.Text = L1.Text & " " & ddtrfrom.SelectedItem.Text
    '            L2.Text = L2.Text & " " & ddtrto.SelectedItem.Text

    '            Periodcty = ddperiod.SelectedItem.Text
    '            If Periodcty = "Fortnightly" Then
    '                PrdVal = 15
    '            ElseIf Periodcty = "Monthly" Then
    '                PrdVal = 1
    '            ElseIf Periodcty = "Quarterly" Then
    '                PrdVal = 3
    '            End If

    '            Amt = Trim(txtiniamt.Text)
    '            Temp = Trim(txttranamt.Text)
    '            CashFlow = Temp
    '            'changes by Jayendra on 060607
    '            ''''Colstr = "Date#Nav#Units#Current Value#CashFlow#Dividend#Index Value#Value After Transfer#Units Redeemed#Closing Units"
    '            Colstr = "Date#NAV#Units#Current Value#CashFlow#Dividend#Value After Transfer#Units Redeemed#Closing Units"
    '            ColArr = Split(Colstr, "#")
    '            ''''For i = 0 To 9
    '            For i = 0 To 8
    '                Ipcol = New DataColumn
    '                Ipcol.ColumnName = ColArr(i)
    '                Ipdt.Columns.Add(Ipcol)
    '            Next i
    '            'Dstp.HeaderStyle.BackColor = Color.CornflowerBlue
    '            Dstp.HeaderStyle.ForeColor = Color.White

    '            m = 0
    '            j = 0
    '            k = 0
    '            x = 0
    '            Rowcounter = 0

    '            ''''Indexval = Split(ddbnmark.SelectedItem.Text, " # ")(1)
    '            '''''''GRID ONE'''''''''''''''''''''''''''''''
    '            Sqlcon = New SqlConnection(constr)
    '            Sqlcon.Open()
    '            'changes by Jayendra on 060607        
    '            scheme_code_from = Split(ddtrfrom.SelectedItem.Value, "#")(0)
    '            plan_code_from = Split(ddtrfrom.SelectedItem.Value, "#")(1)
    '            scheme_code_to = Split(ddtrto.SelectedItem.Value, "#")(0)
    '            plan_code_to = Split(ddtrto.SelectedItem.Value, "#")(1)
    '            'end 060607

    '            'strsql = "Select dateadd(d,276,[date]),(Nav_rs-53)/76 from nav_rec_rel where sch_code='" & ddtrfrom.SelectedItem.Value & "' And dateadd(d,276,[date]) >='" & frdt & "' And dateadd(d,276,[date])<='" & todt & "' order by dateadd(d,276,[date])"

    '            'changes by Jayendra on 060607
    '            ''''strsql = "Select dateadd(d,276,rmf_todt),(rmf_nav-53)/76 from nav_reg where rmf_scheme='" & ddtrfrom.SelectedItem.Value & "' And dateadd(d,276,rmf_todt) >='" & frdt & "' And dateadd(d,276,rmf_todt)<='" & todt & "' order by dateadd(d,276,rmf_todt)"
    '            strsql = "Select rmf_todt,rmf_nav from nav_reg where rmf_scheme='" & scheme_code_from & "' and rmf_plan='" & plan_code_from & "' And rmf_todt >='" & frdt & "' And rmf_todt<='" & todt & "' order by rmf_todt"
    '            'end 060607
    '            Sqlcom = New SqlCommand(strsql, Sqlcon)
    '            Sqlrd = Sqlcom.ExecuteReader
    '            CalcDt = frdt
    '            If Sqlrd.Read Then
    '                chkdate = Sqlrd(0)
    '                Do
    '                    If Sqlrd(0) >= chkdate And chkdate <= todt Then
    '                        For Pl = 0 To 3
    '                            sqlcon3 = New SqlConnection(constr)
    '                            sqlcon3.Open()
    '                            'changes by Jayendra on 060607
    '                            ''''strsqls = "Select dateadd(d,276,rmf_todt),(rmf_nav-53)/76 from nav_reg where rmf_scheme='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,rmf_todt) ='" & chkdate & "'"
    '                            strsqls = "Select rmf_todt,rmf_nav from nav_reg where rmf_scheme='" & scheme_code_to & "' and rmf_plan='" & plan_code_to & "' And rmf_todt ='" & chkdate & "'"
    '                            'end 060607

    '                            Sqlcom = New SqlCommand(strsqls, sqlcon3)
    '                            sqlrd3 = Sqlcom.ExecuteReader
    '                            If sqlrd3.Read Then
    '                                TrueFlg = True
    '                                GoTo ContNext
    '                            Else
    '                                chkdate = DateAdd(DateInterval.Day, 1, chkdate)
    '                                TrueFlg = False
    '                            End If
    '                            sqlcon3.Close()
    '                            sqlcon3.Dispose()
    '                        Next Pl
    '                        If ddperiod.SelectedItem.Text <> "Fortnightly" Then
    '                            ''If Split(Sqlrd(0), "/")(1) < 10 Then
    '                            ''    chkdate = CDate(Split(Sqlrd(0), "/")(0) & "/" & 10 & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
    '                            ''Else
    '                            ''    chkdate = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
    '                            ''    Tempdtstr = Split(chkdate, "/")
    '                            ''    chkdate = CDate(Tempdtstr(0) & "/" & 10 & "/" & Tempdtstr(2))
    '                            ''End If
    '                            If Split(Sqlrd(0), "/")(1) < STP_date Then
    '                                chkdate = CDate(Split(Sqlrd(0), "/")(0) & "/" & STP_date & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
    '                            Else
    '                                chkdate = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
    '                                Tempdtstr = Split(chkdate, "/")
    '                                chkdate = CDate(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
    '                            End If
    '                        Else
    '                            chkdate = DateAdd(DateInterval.Day, PrdVal, chkdate)
    '                        End If
    '                    End If
    '                    If TrueFlg = False Then
    '                        GoTo NextDate
    '                    End If
    'ContNext:
    '                    NewFlg = True
    '                    If j = 0 Then
    '                        Iprw = Ipdt.NewRow
    '                        Iprw(0) = Format(CDate(Sqlrd(0)), "dd/MM/yyyy")
    '                        CalcDt = Sqlrd(0)
    '                        X1Date = Sqlrd(0)
    '                        ReDim Preserve DtArr(Rowcount)
    '                        DtArr(Rowcount) = Sqlrd(0)
    '                        Iprw(1) = Math.Round(Sqlrd(1), 4)
    '                        X1Nav = Sqlrd(1)
    '                        Iprw(2) = Math.Round(Amt / Sqlrd(1), 4)
    '                        ReDim Preserve Currval(Rowcount)
    '                        Currval(Rowcount) = Math.Round(Iprw(1) * Iprw(2), 2)
    '                        X1units = (Math.Round(Amt / Sqlrd(1), 4)) * -1
    '                        FinalUnts = Iprw(2)
    '                        TotUnits = TotUnits + FinalUnts
    '                        Iprw(4) = Amt * -1
    '                        CashInd = Iprw(4)
    '                        sqlcon1 = New SqlConnection(constr)
    '                        sqlcon1.Open()
    '                        strsql = "Select ind_val from ind_rec where ind_code='" & Indexval & "' And dt1='" & Sqlrd(0) & "'"
    '                        Sqlcom = New SqlCommand(strsql, sqlcon1)
    '                        sqlrd1 = Sqlcom.ExecuteReader
    '                        If sqlrd1.Read Then
    '                            'changes by Jayendra on 060607
    '                            ''''Iprw(6) = Math.Round(sqlrd1(0), 2)
    '                            ''''ReDim Preserve IndexArr(m)
    '                            ''''IniIndex = Iprw(6)
    '                            ''''IndexArr(m) = Iprw(6)
    '                            ''''m += 1
    '                        End If
    '                        sqlcon1.Close()
    '                        sqlcon1.Dispose()

    '                        Ipdt.Rows.Add(Iprw)
    '                        If ddperiod.SelectedItem.Text <> "Fortnightly" Then
    '                            'CalcDt = DateAdd(DateInterval.Month, PrdVal, CalcDt)
    '                            ''If Split(Sqlrd(0), "/")(1) < 10 Then
    '                            ''    CalcDt = CDate(Split(Sqlrd(0), "/")(0) & "/" & 10 & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
    '                            ''Else
    '                            ''    CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
    '                            ''    Tempdtstr = Split(CalcDt, "/")
    '                            ''    CalcDt = CDate(Tempdtstr(0) & "/" & 10 & "/" & Tempdtstr(2))
    '                            ''End If
    '                            If Split(Sqlrd(0), "/")(1) < STP_date Then
    '                                CalcDt = CDate(Split(Sqlrd(0), "/")(0) & "/" & STP_date & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
    '                            Else
    '                                CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
    '                                Tempdtstr = Split(CalcDt, "/")
    '                                CalcDt = CDate(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
    '                            End If
    '                        Else
    '                            CalcDt = DateAdd(DateInterval.Day, PrdVal, CalcDt)
    '                        End If
    '                        Rowcount += 1
    '                        chkdate = CalcDt
    '                        TrueFlg = False
    '                    ElseIf Sqlrd(0) >= CalcDt And CalcDt <= todt Then
    '                        Iprw = Ipdt.NewRow
    '                        Rowcounter += 1
    '                        Iprw(0) = Format(CDate(Sqlrd(0)), "dd/MM/yyyy")
    '                        CalcDt = Sqlrd(0)
    '                        ReDim Preserve DtArr(Rowcount)
    '                        DtArr(Rowcount) = Sqlrd(0)
    '                        Iprw(1) = Math.Round(Sqlrd(1), 4)
    '                        If Temp <= Amt Then
    '                            If (Amt - Temp) < 0 Then
    '                                If j = 1 Then
    '                                    Iprw(2) = Ipdt.Rows(Rowcounter - 1).Item(2)
    '                                ElseIf IsDBNull(Ipdt.Rows(Rowcounter - 1).Item(8)) = False Then
    '                                    Iprw(2) = Math.Round(Ipdt.Rows(Rowcounter - 1).Item(2) - Ipdt.Rows(Rowcounter - 1).Item(8))
    '                                Else
    '                                    Iprw(2) = Math.Round(Ipdt.Rows(Rowcounter - 1).Item(2))
    '                                End If
    '                                FinalUnts = Iprw(2)
    '                                TotUnits = TotUnits + FinalUnts
    '                                Iprw(3) = Math.Round(Iprw(1) * Iprw(2), 2)
    '                                ReDim Preserve Currval(Rowcount)
    '                                Currval(Rowcount) = Math.Round(Iprw(1) * Iprw(2), 4)
    '                                Iprw(4) = Math.Round((Amt - (Temp - CashFlow)), 4)
    '                                sqlcon1 = New SqlConnection(constr)
    '                                sqlcon1.Open()
    '                                If rbindivd.Checked = True Then
    '                                    'strsql = "Select sum((divid_pt-53)/76) from div_rec_adv where sch_code='" & ddtrfrom.SelectedItem.Value & "' And dateadd(d,276,date)>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And dateadd(d,276,date)<='" & fmt(Iprw(0)) & "'"

    '                                    'changes by Jayendra on 060607
    '                                    ''''strsql = "Select sum((rmf_divpercent-53)/76) from div_dets where rmf_scheme='" & ddtrfrom.SelectedItem.Value & "' And dateadd(d,276,rmf_todt)>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And dateadd(d,276,rmf_todt)<='" & fmt(Iprw(0)) & "'"
    '                                    strsql = "Select sum(rmf_divpercent) from div_dets where rmf_scheme='" & scheme_code_from & "' and rmf_plan='" & plan_code_from & "' And rmf_todt>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And rmf_todt<='" & fmt(Iprw(0)) & "'"
    '                                    'end 060607
    '                                ElseIf rbcorp.Checked = True Then
    '                                    'strsql = "Select sum((dividend-53)/76) from div_rec_adv where sch_code='" & ddtrfrom.SelectedItem.Value & "' And dateadd(d,276,date)>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And dateadd(d,276,date)<='" & fmt(Iprw(0)) & "'"

    '                                    'changes by Jayendra on 060607
    '                                    ''''strsql = "Select sum((rmf_divrate-53)/76) from div_dets where rmf_scheme='" & ddtrfrom.SelectedItem.Value & "' And dateadd(d,276,rmf_todt)>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And dateadd(d,276,rmf_todt)<='" & fmt(Iprw(0)) & "'"
    '                                    strsql = "Select sum(rmf_divrate) from div_dets where rmf_scheme='" & scheme_code_to & "' and rmf_plan='" & plan_code_to & "' And rmf_todt>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And rmf_todt<='" & fmt(Iprw(0)) & "'"
    '                                    'end 060607
    '                                End If
    '                                Sqlcom = New SqlCommand(strsql, sqlcon1)
    '                                sqlrd1 = Sqlcom.ExecuteReader
    '                                If sqlrd1.Read Then
    '                                    If IsDBNull(sqlrd1(0)) = False Then
    '                                        Iprw(5) = sqlrd1(0)
    '                                    Else
    '                                        Iprw(5) = 0
    '                                    End If
    '                                End If
    '                                sqlcon1.Close()
    '                                sqlcon1.Dispose()
    '                                ''''sqlcon1 = New SqlConnection(constr)
    '                                ''''sqlcon1.Open()
    '                                ''''strsql = "Select (ind_val-53)/76 from ind_rec where ind_code='" & Indexval & "' And dateadd(d,276,dt1)='" & Sqlrd(0) & "'"
    '                                ''''Sqlcom = New SqlCommand(strsql, sqlcon1)
    '                                ''''sqlrd1 = Sqlcom.ExecuteReader
    '                                ''''If sqlrd1.Read Then
    '                                ''''    ReDim Preserve IndexArr(m)
    '                                'changes by Jayendra on 060607
    '                                ''''Iprw(6) = Math.Round(sqlrd1(0), 2)
    '                                ''''IndexArr(m) = Iprw(6)
    '                                ''''m += 1
    '                                ''''End If
    '                                sqlcon1.Close()
    '                                sqlcon1.Dispose()
    '                                'changes by Jayendra on 060607
    '                                ''''Iprw(7) = Math.Round(Iprw(3) - Iprw(4), 2)
    '                                Iprw(6) = Math.Round(Iprw(3) - Iprw(4), 2)
    '                                ReDim Preserve ValueAfter(x)
    '                                'changes by Jayendra on 060607
    '                                ''''ValueAfter(x) = Iprw(7)
    '                                ValueAfter(x) = Iprw(6)
    '                                x += 1

    '                                'changes by Jayendra on 060607
    '                                ''''Iprw(8) = Math.Round(Iprw(4) / Iprw(1), 4)
    '                                ''''UntsRdmd = Iprw(8)
    '                                ''''Iprw(9) = Math.Round(Iprw(7) / Iprw(1), 4)
    '                                Iprw(7) = Math.Round(Iprw(4) / Iprw(1), 4)
    '                                UntsRdmd = Iprw(8)
    '                                Iprw(8) = Math.Round(Iprw(6) / Iprw(1), 4)
    '                            Else
    '                                If j = 1 Then
    '                                    Iprw(2) = Ipdt.Rows(Rowcounter - 1).Item(2)
    '                                ElseIf IsDBNull(Ipdt.Rows(Rowcounter - 1).Item(8)) = False Then
    '                                    Iprw(2) = Math.Round(Ipdt.Rows(Rowcounter - 1).Item(2) - Ipdt.Rows(Rowcounter - 1).Item(8))
    '                                Else
    '                                    Iprw(2) = (Ipdt.Rows(Rowcounter - 1).Item(2))
    '                                End If
    '                                FinalUnts = Iprw(2)
    '                                TotUnits = TotUnits + FinalUnts
    '                                Iprw(3) = Math.Round(Iprw(1) * Iprw(2), 2)
    '                                ReDim Preserve Currval(Rowcount)
    '                                Currval(Rowcount) = Math.Round(Iprw(1) * Iprw(2), 4)
    '                                Iprw(4) = CashFlow
    '                                sqlcon1 = New SqlConnection(constr)
    '                                sqlcon1.Open()
    '                                If rbindivd.Checked = True Then
    '                                    'changes by Jayendra on 060607
    '                                    ''''strsql = "Select sum((rmf_divpercent-53)/76) from div_dets where rmf_scheme='" & ddtrfrom.SelectedItem.Value & "' And dateadd(d,276,rmf_todt)>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And dateadd(d,276,rmf_todt)<='" & fmt(Iprw(0)) & "'"
    '                                    strsql = "Select sum(rmf_divpercent) from div_dets where rmf_scheme='" & scheme_code_from & "' and rmf_plan='" & plan_code_from & "' And rmf_todt>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And rmf_todt<='" & fmt(Iprw(0)) & "'"
    '                                    'end 060607
    '                                ElseIf rbcorp.Checked = True Then
    '                                    'changes by Jayendra on 060607
    '                                    ''''strsql = "Select sum((rmf_divrate-53)/76) from div_dets where rmf_scheme='" & ddtrfrom.SelectedItem.Value & "' And dateadd(d,276,rmf_todt)>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And dateadd(d,276,rmf_todt)<='" & fmt(Iprw(0)) & "'"
    '                                    strsql = "Select sum(rmf_divrate) from div_dets where rmf_scheme='" & scheme_code_from & "' and rmf_plan='" & plan_code_from & "' And rmf_todt>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And rmf_todt<='" & fmt(Iprw(0)) & "'"
    '                                    'end 060607
    '                                End If
    '                                Sqlcom = New SqlCommand(strsql, sqlcon1)
    '                                sqlrd1 = Sqlcom.ExecuteReader
    '                                If sqlrd1.Read Then
    '                                    If IsDBNull(sqlrd1(0)) = False Then
    '                                        Iprw(5) = sqlrd1(0)
    '                                    Else
    '                                        Iprw(5) = 0
    '                                    End If
    '                                End If
    '                                sqlcon1.Close()
    '                                sqlcon1.Dispose()
    '                                ''''sqlcon1 = New SqlConnection(constr)
    '                                ''''sqlcon1.Open()
    '                                ''''strsql = "Select (ind_val-53)/76 from ind_rec where ind_code='" & Indexval & "' And dateadd(d,276,dt1)='" & Sqlrd(0) & "'"
    '                                ''''Sqlcom = New SqlCommand(strsql, sqlcon1)
    '                                ''''sqlrd1 = Sqlcom.ExecuteReader
    '                                ''''If sqlrd1.Read Then
    '                                'changes by Jayendra on 060607
    '                                ''''ReDim Preserve IndexArr(m)
    '                                ''''Iprw(6) = Math.Round(sqlrd1(0), 2)
    '                                ''''IndexArr(m) = Iprw(6)
    '                                ''''m += 1
    '                                ''''End If
    '                                sqlcon1.Close()
    '                                sqlcon1.Dispose()
    '                                'changes by Jayendra on 060607
    '                                ''''Iprw(7) = Math.Round(Iprw(3) - Iprw(4), 2)
    '                                Iprw(6) = Math.Round(Iprw(3) - Iprw(4), 2)
    '                                ReDim Preserve ValueAfter(x)
    '                                'changes by Jayendra on 060607
    '                                ''''ValueAfter(x) = Iprw(7)                            
    '                                ''''Iprw(8) = Math.Round(Iprw(4) / Iprw(1), 4)
    '                                ''''UntsRdmd = Iprw(8)
    '                                ''''Iprw(9) = Math.Round(Iprw(7) / Iprw(1), 4)
    '                                ValueAfter(x) = Iprw(6)
    '                                x += 1
    '                                Iprw(7) = Math.Round(Iprw(4) / Iprw(1), 4)
    '                                UntsRdmd = Iprw(7)
    '                                Iprw(8) = Math.Round(Iprw(6) / Iprw(1), 4)
    '                            End If
    '                            Temp = Temp + CashFlow
    '                        End If
    '                        Ipdt.Rows.Add(Iprw)
    '                        If ddperiod.SelectedItem.Text <> "Fortnightly" Then
    '                            'CalcDt = DateAdd(DateInterval.Month, PrdVal, CalcDt)

    '                            ''If Split(Sqlrd(0), "/")(1) < 10 Then
    '                            ''    CalcDt = CDate(Split(Sqlrd(0), "/")(0) & "/" & 10 & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
    '                            ''Else
    '                            ''    CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
    '                            ''    Tempdtstr = Split(CalcDt, "/")
    '                            ''    CalcDt = CDate(Tempdtstr(0) & "/" & 10 & "/" & Tempdtstr(2))
    '                            ''End If
    '                            If Split(Sqlrd(0), "/")(1) < STP_date Then
    '                                CalcDt = CDate(Split(Sqlrd(0), "/")(0) & "/" & STP_date & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
    '                            Else
    '                                CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
    '                                Tempdtstr = Split(CalcDt, "/")
    '                                CalcDt = CDate(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
    '                            End If
    '                        Else
    '                            CalcDt = DateAdd(DateInterval.Day, PrdVal, CalcDt)
    '                        End If
    '                        Rowcount += 1
    '                        chkdate = CalcDt
    '                        TrueFlg = False
    '                    End If
    '                    j += 1
    'NextDate:
    '                Loop While Sqlrd.Read
    '            Else
    '                Exit Sub
    '            End If
    '            Sqlcon.Close()
    '            Sqlcon.Dispose()

    '            If NewFlg = False Then
    '                Dstp1.DataSource = Ipdt
    '                Dstp1.DataBind()
    '                Dstp1.Visible = True
    '                Dstp.DataSource = Ipdt
    '                Dstp.DataBind()
    '                Dstp.Visible = True
    '                Exit Sub
    '            End If
    '            'changes by Jayendra on 060607
    '            ''''strsql = "Select (rmf_nav-53)/76,dateadd(d,276,rmf_todt) from nav_reg where rmf_scheme='" & ddtrfrom.SelectedItem.Value & "' And dateadd(d,276,rmf_todt)>'" & fmt(txtvalue.Text) & "' order by dateadd(d,276,rmf_todt)"
    '            strsql = "Select rmf_nav,rmf_todt from nav_reg where rmf_scheme='" & scheme_code_from & "' and rmf_plan='" & plan_code_from & "' And rmf_todt < '" & fmt(txtvalue.Text) & "' order by rmf_todt"
    '            'end 060607
    '            sqlcon1 = New SqlConnection(constr)
    '            sqlcon1.Open()
    '            Sqlcom = New SqlCommand(strsql, sqlcon1)
    '            sqlrd1 = Sqlcom.ExecuteReader
    '            If sqlrd1.Read Then
    '                Do
    '                    If IsDBNull(sqlrd1(0)) = False Then
    '                        Iprw = Ipdt.NewRow
    '                        Iprw(0) = Format(CDate(sqlrd1(1)), "dd/MM/yyyy")
    '                        X2Date = sqlrd1(1)
    '                        Iprw(1) = Math.Round(sqlrd1(0), 4)
    '                        X2Nav = sqlrd1(0)
    '                        'TotUnits = Math.Round(TotUnits * sqlrd1(0), 4)
    '                        Iprw(2) = Math.Round(FinalUnts - UntsRdmd, 4)
    '                        Iprw(3) = Math.Round(Iprw(1) * Iprw(2), 4)
    '                        Temp = Iprw(3)
    '                        txtbal.Text = Iprw(3)
    '                        Ipdt.Rows.Add(Iprw)
    '                        Exit Do
    '                    End If
    '                Loop While sqlrd1.Read

    '            End If
    '            sqlcon1.Close()
    '            sqlcon1.Dispose()
    '            Session("SIP") = Ipdt
    '            'Gsp.DataSource = Ipdt
    '            'Gsp.DataBind()
    '            'Gsp.Visible = True
    '            Session("S1") = Ipdt
    '            Dstp.DataSource = Ipdt
    '            Dstp.DataBind()
    '            Dstp.Visible = True

    '            '''''--------------GRID TWO-----------------------------
    '            Ipdt = New DataTable
    '            Rowcounter = 0
    '            Rowcount = 0
    '            ' TotUnits = 0
    '            ' ReDim DtArr(0)
    '            ReDim Currval(0)

    '            'changes by Jayendra on 060607
    '            ''''Colstr = "Date#Nav#Units#Cumulative Units#Dividend#Current Value#Investment In Index#Cumulative Amount#Value Of Investments"
    '            'Colstr = "Date#NAV#Units#Cumulative Units#Dividend#Current Value#Cumulative Amount#Value Of Investments"
    '            Colstr = "Date#NAV#Units#Cumulative Units"
    '            ColArr = Split(Colstr, "#")
    '            ''''For i = 0 To 8
    '            For i = 0 To 3
    '                Ipcol = New DataColumn
    '                Ipcol.ColumnName = ColArr(i)
    '                Ipdt.Columns.Add(Ipcol)
    '            Next i
    '            j = 0
    '            m = 0
    '            x = 0
    '            TotUnits = 0
    '            CalcDt = frdt
    '            'Dstp1.HeaderStyle.BackColor = Color.CornflowerBlue
    '            Dstp1.HeaderStyle.ForeColor = Color.White
    '            Sqlcon = New SqlConnection(constr)
    '            Sqlcon.Open()
    '            'changes by Jayendra on 060607
    '            ''''strsql = "Select dateadd(d,276,rmf_todt),(rmf_nav-53)/76 from nav_reg where rmf_scheme='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,rmf_todt) >='" & frdt & "' And dateadd(d,276,rmf_todt)<='" & todt & "' order by dateadd(d,276,rmf_todt)"
    '            strsql = "Select rmf_todt,rmf_nav from nav_reg where rmf_scheme='" & scheme_code_to & "' and rmf_plan='" & plan_code_to & "' And rmf_todt >='" & frdt & "' And rmf_todt<='" & todt & "' order by rmf_todt"
    '            'end 060607
    '            Sqlcom = New SqlCommand(strsql, Sqlcon)
    '            Sqlrd = Sqlcom.ExecuteReader
    '            CalcDt = frdt
    '            If ddperiod.SelectedItem.Text <> "Fortnightly" Then
    '                CalcDt = DateAdd(DateInterval.Month, PrdVal, CalcDt)
    '                Tempdtstr = Split(CalcDt, "/")

    '                ''CalcDt = CDate(Tempdtstr(0) & "/" & 10 & "/" & Tempdtstr(2))
    '                CalcDt = CDate(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
    '            Else
    '                CalcDt = DateAdd(DateInterval.Day, PrdVal, CalcDt)
    '            End If
    '            If Sqlrd.Read Then
    '                Do
    '                    If j = 0 And Sqlrd(0) >= CalcDt And CalcDt <= todt Then
    '                        Iprw = Ipdt.NewRow
    '                        CumUnts = 0
    '                        Iprw(0) = Format(CDate(Sqlrd(0)), "dd/MM/yyyy")
    '                        CalcDt = Sqlrd(0)
    '                        ''Iprw(5) = Amt
    '                        'changes by Jayendra on 060607
    '                        ''''Iprw(6) = Amt
    '                        'end 060607
    '                        Ipdt.Rows.Add(Iprw)
    '                        m += 1
    '                        Iprw = Ipdt.NewRow
    '                        Rowcounter += 1
    '                        Iprw(0) = Format(CDate(Sqlrd(0)), "dd/MM/yyyy")
    '                        ReDim Preserve DtArr(Rowcount)
    '                        DtArr(Rowcount) = Sqlrd(0)
    '                        Iprw(1) = Math.Round(Sqlrd(1), 4)
    '                        Iprw(2) = Math.Round(CashFlow / Sqlrd(1), 4)
    '                        TotUnits = TotUnits + Iprw(2)
    '                        NewUnts = Math.Round(CashFlow / Sqlrd(1), 4)
    '                        Iprw(3) = CumUnts + NewUnts
    '                        CumUnts = CumUnts + NewUnts
    '                        ''sqlcon1 = New SqlConnection(constr)
    '                        ''sqlcon1.Open()
    '                        ''If rbindivd.Checked Then
    '                        ''    'changes by Jayendra on 060607
    '                        ''    ''''strsql = "Select sum((rmf_divpercent-53)/76) from div_dets where rmf_scheme='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,rmf_todt)>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And dateadd(d,276,rmf_todt)<='" & fmt(Iprw(0)) & "'"
    '                        ''    strsql = "Select sum(rmf_divpercent) from div_dets where rmf_scheme='" & scheme_code_to & "' and rmf_plan='" & plan_code_to & "' And rmf_todt>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And rmf_todt<='" & fmt(Iprw(0)) & "'"
    '                        ''    'end 060607
    '                        ''ElseIf rbcorp.Checked = True Then
    '                        ''    'changes by Jayendra on 060607
    '                        ''    ''''strsql = "Select sum((rmf_divrate-53)/76) from div_dets where rmf_scheme='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,rmf_todt)>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And dateadd(d,276,rmf_todt)<='" & fmt(Iprw(0)) & "'"
    '                        ''    strsql = "Select sum(rmf_divrate) from div_dets where rmf_scheme='" & scheme_code_to & "' and rmf_plan='" & plan_code_to & "' And rmf_todt>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And rmf_todt<='" & fmt(Iprw(0)) & "'"
    '                        ''    'end 060607
    '                        ''End If
    '                        ''Sqlcom = New SqlCommand(strsql, sqlcon1)
    '                        ''sqlrd1 = Sqlcom.ExecuteReader
    '                        ''If sqlrd1.Read Then
    '                        ''    If IsDBNull(sqlrd1(0)) = False Then
    '                        ''        Iprw(4) = sqlrd1(0)
    '                        ''    Else
    '                        ''        Iprw(4) = 0
    '                        ''    End If
    '                        ''End If
    '                        sqlcon1.Close()
    '                        sqlcon1.Dispose()
    '                        'Iprw(5) = Math.Round(CumUnts * Sqlrd(1), 2)
    '                        Ipdt.Rows.Add(Iprw)
    '                        If ddperiod.SelectedItem.Text <> "Fortnightly" Then

    '                            ''If Split(Sqlrd(0), "/")(1) < 10 Then
    '                            ''    CalcDt = CDate(Split(Sqlrd(0), "/")(0) & "/" & 10 & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
    '                            ''Else
    '                            ''    CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
    '                            ''    Tempdtstr = Split(CalcDt, "/")
    '                            ''    CalcDt = CDate(Tempdtstr(0) & "/" & 10 & "/" & Tempdtstr(2))
    '                            ''End If
    '                            If Split(Sqlrd(0), "/")(1) < STP_date Then
    '                                CalcDt = CDate(Split(Sqlrd(0), "/")(0) & "/" & STP_date & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
    '                            Else
    '                                CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
    '                                Tempdtstr = Split(CalcDt, "/")
    '                                CalcDt = CDate(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
    '                            End If
    '                        Else
    '                            CalcDt = DateAdd(DateInterval.Day, PrdVal, CalcDt)
    '                        End If
    '                        'changes by Jayendra on 060607
    '                        ''''If m <= UBound(IndexArr) Then
    '                        ''''Iprw(6) = Math.Round(((CashFlow * IndexArr(m)) / IniIndex), 2)
    '                        ''''End If
    '                        ''''Iprw(7) = Iprw(5)
    '                        'Iprw(6) = Iprw(5)
    '                        If IsNothing(ValueAfter) = False Then
    '                            'If x <= UBound(ValueAfter) Then
    '                            '    ''''Iprw(8) = Math.Round(Iprw(7) + ValueAfter(x), 2)
    '                            '    Iprw(7) = Math.Round(Iprw(6) + ValueAfter(x), 2)
    '                            '    x += 1
    '                            'End If
    '                            '''''Currval(Rowcount) = Iprw(8)
    '                            'Currval(Rowcount) = Iprw(7)
    '                            'ReDim Preserve Currval(Rowcount)
    '                        End If
    '                        Rowcount += 1
    '                        m += 1
    '                        j += 1
    '                    ElseIf Sqlrd(0) >= CalcDt And CalcDt <= todt Then
    '                        Iprw = Ipdt.NewRow
    '                        Rowcounter += 1
    '                        Iprw(0) = Format(CDate(Sqlrd(0)), "dd/MM/yyyy")
    '                        CalcDt = Sqlrd(0)
    '                        ReDim Preserve DtArr(Rowcount)
    '                        If IsDBNull(Iprw(0)) = False Then
    '                            DtArr(Rowcount) = Sqlrd(0)
    '                        End If

    '                        Iprw(1) = Math.Round(Sqlrd(1), 4)
    '                        'If m <= UBound(IndexArr) Then
    '                        Iprw(2) = Math.Round(CashFlow / Sqlrd(1), 4)
    '                        TotUnits = TotUnits + Iprw(2)
    '                        NewUnts = Math.Round(CashFlow / Sqlrd(1), 4)
    '                        Iprw(3) = CumUnts + NewUnts
    '                        CumUnts = CumUnts + NewUnts
    '                        'sqlcon1 = New SqlConnection(constr)
    '                        'sqlcon1.Open()

    '                        '    If rbindivd.Checked Then
    '                        '        'changes by Jayendra on 060607
    '                        '        ''''strsql = "Select sum((rmf_divpercent-53)/76) from div_dets where rmf_scheme='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,rmf_todt)>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And dateadd(d,276,rmf_todt)<='" & fmt(Iprw(0)) & "'"
    '                        '        strsql = "Select sum((rmf_divpercent-53)/76) from div_dets where rmf_scheme='" & scheme_code_to & "' and rmf_plan='" & plan_code_to & "' And dateadd(d,276,rmf_todt)>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And dateadd(d,276,rmf_todt)<='" & fmt(Iprw(0)) & "'"
    '                        '        'end 060607
    '                        '    ElseIf rbcorp.Checked = True Then
    '                        '        'changes by Jayendra on 060607
    '                        '        ''''strsql = "Select sum((rmf_divrate-53)/76) from div_dets where rmf_scheme='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,rmf_todt)>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And dateadd(d,276,rmf_todt)<='" & fmt(Iprw(0)) & "'"
    '                        '        strsql = "Select sum((rmf_divrate-53)/76) from div_dets where rmf_scheme='" & scheme_code_to & "' and rmf_plan='" & plan_code_to & "' And dateadd(d,276,rmf_todt)>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And dateadd(d,276,rmf_todt)<='" & fmt(Iprw(0)) & "'"
    '                        '        'end 060607
    '                        '    End If
    '                        'Sqlcom = New SqlCommand(strsql, sqlcon1)
    '                        'sqlrd1 = Sqlcom.ExecuteReader
    '                        'If sqlrd1.Read Then
    '                        'If IsDBNull(sqlrd1(0)) = False Then
    '                        'Iprw(4) = sqlrd1(0)
    '                        'Else
    '                        'Iprw(4) = 0
    '                        'End If
    '                        'End If
    '                    sqlcon1.Close()
    '                    sqlcon1.Dispose()
    '                    '    Iprw(5) = Math.Round(CumUnts * Sqlrd(1), 2)
    '                    '    ' ReDim Preserve Currval(Rowcount)
    '                    '    'Currval(Rowcount) = Iprw(5)
    '                    '    Iprw(6) = Math.Round(((CashFlow * IndexArr(m)) / IniIndex), 2)
    '                    '    Iprw(7) = Iprw(5)
    '                    '    If x <= UBound(ValueAfter) Then
    '                    '        Iprw(8) = Math.Round(Iprw(7) + ValueAfter(x), 2)
    '                    '        x += 1
    '                    '    End If
    '                    '    ReDim Preserve Currval(Rowcount)
    '                    '    Currval(Rowcount) = Iprw(8)
    '                    'End If
    '                    If ddperiod.SelectedItem.Text <> "Fortnightly" Then
    '                        CalcDt = DateAdd(DateInterval.Month, PrdVal, CalcDt)

    '                        ''If Split(Sqlrd(0), "/")(1) < 10 Then
    '                        ''    CalcDt = CDate(Split(Sqlrd(0), "/")(0) & "/" & 10 & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
    '                        ''Else
    '                        ''    CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
    '                        ''    Tempdtstr = Split(CalcDt, "/")
    '                        ''    CalcDt = CDate(Tempdtstr(0) & "/" & 10 & "/" & Tempdtstr(2))
    '                        ''End If
    '                        If Split(Sqlrd(0), "/")(1) < STP_date Then
    '                            CalcDt = CDate(Split(Sqlrd(0), "/")(0) & "/" & STP_date & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
    '                        Else
    '                            CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
    '                            Tempdtstr = Split(CalcDt, "/")
    '                            CalcDt = CDate(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
    '                        End If
    '                    Else
    '                        CalcDt = DateAdd(DateInterval.Day, PrdVal, CalcDt)
    '                    End If
    '                    Ipdt.Rows.Add(Iprw)
    '                    m += 1
    '                    Rowcount += 1
    '                        End If
    '                Loop While Sqlrd.Read
    '            End If
    '            Sqlcon.Close()
    '            Sqlcon.Dispose()
    '            'changes by Jayendra on 060607
    '            ''''strsql = "Select (rmf_nav-53)/76,dateadd(d,276,rmf_todt) from nav_reg where rmf_scheme='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,rmf_todt)>='" & fmt(txtvalue.Text) & "' order by dateadd(d,276,rmf_todt)"
    '            strsql = "Select rmf_nav,rmf_todt from nav_reg where rmf_scheme='" & scheme_code_to & "' and rmf_plan='" & plan_code_to & "' And rmf_todt <= '" & fmt(txtvalue.Text) & "' order by rmf_todt"
    '            'end 060607
    '            sqlcon1 = New SqlConnection(constr)
    '            sqlcon1.Open()
    '            Sqlcom = New SqlCommand(strsql, sqlcon1)
    '            sqlrd1 = Sqlcom.ExecuteReader
    '            If sqlrd1.Read Then
    '                Do
    '                    If IsDBNull(sqlrd1(0)) = False Then
    '                        Iprw = Ipdt.NewRow
    '                        Iprw(0) = Format(CDate(sqlrd1(1)), "dd/MM/yyyy")
    '                        Iprw(1) = Math.Round(sqlrd1(0), 4)
    '                        TotUnits = Math.Round(TotUnits * sqlrd1(0), 4)
    '                        Iprw(3) = CumUnts
    '                        txtacc.Text = Iprw(3)
    '                        Ipdt.Rows.Add(Iprw)
    '                        Exit Do
    '                    End If
    '                Loop While sqlrd1.Read

    '            End If
    '            sqlcon1.Close()
    '            sqlcon1.Dispose()

    '            '''''''''''XIRRSSSSSSS CALCULATION''''''''''''''''''''''
    '            Dim Dt As String = ""
    '            Dim cashflw As String = ""
    '            Dim cashindx As String = ""

    '            If IsNothing(DtArr) = False And IsNothing(Currval) = False Then
    '                For i = 0 To UBound(Currval)
    '                    If Dt = "" Then
    '                        Dt = Format(DtArr(i), "dd/MM/yyyy")
    '                    Else
    '                        Dt = Dt & "," & Format(DtArr(i), "dd/MM/yyyy")
    '                    End If
    '                    If cashflw = "" Then
    '                        'cashflw = Currval(i) * -1
    '                        cashflw = Trim(txttranamt.Text) * -1
    '                    Else
    '                        'cashflw = cashflw & "," & (Currval(i) * -1)
    '                        cashflw = cashflw & "," & (Trim(txttranamt.Text) * -1)
    '                    End If
    '                    If cashindx = "" Then
    '                        cashindx = Currval(i)
    '                    Else
    '                        cashindx = cashindx & "," & Currval(i)
    '                    End If
    '                Next i
    '            Else
    '                txtyield.Text = ""
    '                txtyldinv.Text = ""
    '                GoTo noxi
    '            End If

    '            Dt = Dt & "," & CDate(fmt(txtvalue.Text))
    '            cashflw = cashflw & "," & TotUnits
    '            getXirr = XIRR(Dt, cashflw)
    '            txtyield.Text = Math.Round(getXirr, 2)

    '            ''Dt = Dt & "," & CDate(fmt(txtvalue.Text))
    '            ''cashflw = cashflw & "," & TotUnits
    '            ''If Sqlcon.State = ConnectionState.Open Then
    '            ''    Sqlcon.Close()
    '            ''End If
    '            ''Sqlcon = New SqlConnection(constr)
    '            ''Sqlcon.Open()
    '            ''Sqlcom = New SqlCommand("xirrs", Sqlcon)
    '            ''With Sqlcom

    '            ''    .CommandType = CommandType.StoredProcedure
    '            ''    .Parameters.Add("@dstr", SqlDbType.VarChar, 5000).Value = Dt
    '            ''    .Parameters.Add("@astr", SqlDbType.VarChar, 5000).Value = cashflw
    '            ''    .Parameters.Add("@xirrx", SqlDbType.Float).Direction = ParameterDirection.Output
    '            ''    .ExecuteNonQuery()
    '            ''End With
    '            ''getXirr = Math.Round(Sqlcom.Parameters("@xirrx").Value, 2)
    '            ''Sqlcom.Dispose() : Sqlcon.Close() : Sqlcon.Dispose()
    '            ''txtyield.Text = getXirr

    '            Dt = ""
    '            cashflw = ""
    '            Dt = X1Date & "," & X2Date
    '            cashflw = (X1Nav * X1units) & "," & (X2Nav * X1units) * -1
    '            getXirr = XIRR(Dt, cashflw)
    '            txtyldinv.Text = Math.Round(getXirr, 2)

    '            'cashindx = cashindx & "," & TotNav
    '            ''If Sqlcon.State = ConnectionState.Open Then
    '            ''    Sqlcon.Close()
    '            ''End If
    '            ''Sqlcon = New SqlConnection(constr)
    '            ''Sqlcon.Open()
    '            ''Sqlcom = New SqlCommand("xirrs", Sqlcon)
    '            ''With Sqlcom

    '            ''    .CommandType = CommandType.StoredProcedure
    '            ''    .Parameters.Add("@dstr", SqlDbType.VarChar, 5000).Value = Dt
    '            ''    .Parameters.Add("@astr", SqlDbType.VarChar, 5000).Value = cashflw
    '            ''    .Parameters.Add("@xirrx", SqlDbType.Float).Direction = ParameterDirection.Output
    '            ''    .ExecuteNonQuery()
    '            ''End With
    '            ''getXirr = Math.Round(Sqlcom.Parameters("@xirrx").Value, 2)
    '            ''Sqlcom.Dispose() : Sqlcon.Close() : Sqlcon.Dispose()
    '            ''txtyldinv.Text = getXirr
    'noxi:
    '            Session("S2") = Ipdt
    '            Session("SFROM") = ddtrfrom.SelectedItem.Text
    '            Session("STO") = ddtrto.SelectedItem.Text
    '            Dstp1.DataSource = Ipdt
    '            Dstp1.DataBind()
    '            Dstp1.Visible = True

    '            cmdexp1.Attributes.Add("onClick", "javascript:newexports('Dstp','Dstp1',1,'" & txtbal.Text & "','" & txtacc.Text & "','" & txtyield.Text & "','" & txtyldinv.Text & "','" & ddtrfrom.SelectedItem.Text & "','" & ddtrto.SelectedItem.Text & "');return false;")
    '        Catch ex As Exception

    '        End Try

    '    End Sub

    '    Private Sub cmdreset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) handler
    Private Sub cmdreset_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdreset.Click
        Try
            tblSIP.Visible = False
            tblSIP1.Visible = False
            tblSTP.Visible = True
            tblSTP1.Visible = False
            tblSWP.Visible = False
            tblSWP1.Visible = False
            Label10.Visible = True
            ddbnmark.Visible = True
            Table12.Visible = True
            txtfrdt.Text = ""
            txttodt.Text = ""
            txtvalue.Text = ""
            txtiniamt.Text = ""
            txttranamt.Text = ""
            ddperiod.SelectedIndex = 0
            ddtrfrom.SelectedIndex = 0
            ddtrto.SelectedIndex = 0
            ddbnmark.SelectedIndex = 0
            hdIsGraphExist.Value = 0
            rbindivd.Checked = False
            rbcorp.Checked = False
            If rbfixed.Checked = True Then
                txttranamt.Visible = True
                Label7.Visible = True
            End If
            Dstp.Columns.Clear()
            Dstp1.Columns.Clear()
            STPdt.Items.Clear()
            STPdt.Items.Add("--")
            For i = 1 To 31
                STPdt.Items.Add(i)
            Next
        Catch ex As Exception

        End Try
    End Sub



#End Region

#Region "Private sub/functions"
    Private Sub fillcapital()
        Dim frdt As Date
        Dim todt As Date
        Dim Valdt As Date
        Dim Periodcty As String
        Dim PrdVal As Integer = 0
        Dim CalcDt As Date
        Dim Amt As Double = 0
        Dim Indexval As String
        Dim IndexArr() As Double
        Dim ValueAfter() As Double
        Dim CashInd As Double = 0
        Dim IniIndex As Double = 0
        Dim Rowcounter As Integer = 0
        Dim Colstr As String
        Dim ColArr() As String
        Dim m As Integer = 0
        Dim j As Integer = 0
        Dim k As Integer = 0
        Dim x As Integer = 0
        Dim CashFlow As Double = 0
        Dim CumUnts As Double = 0
        Dim NewUnts As Double = 0
        Dim Temp As Double = 0
        Dim TempUnits As Double = 0
        Dim Tempamt As Double = 0
        Dim TempDiv As Double = 0
        Dim TransAmt() As Double
        Dim X1Nav As Double = 0
        Dim X1units As Double = 0
        Dim X1Date As Date
        Dim X2Date As Date
        Dim X2Nav As Double = 0
        Dim Rowcount As Integer = 0
        Dim DtArr() As Date
        Dim Currval() As Double
        Dim TotuUnits As Double = 0
        Dim Tempdtstr(2) As String
        Dim NewFlg As Boolean = False
        Dim chkdate As Date
        Dim Pl As Integer = 0
        Dim TrueFlg As Boolean = False
        Dim BalUnits As Double = 0
        Dim LastNav As Double = 0
        Dim CumUnits As Double = 0
        Dim T2LastNav As Double = 0
        Dim STP_date As Integer
        Dim CashF() As Double
        Dim CashFl() As Double
        Dim CashFl1() As Double
        Dim CashFl2() As Double
        Dim stp_cashflw_grd1 As Double
        Dim stp_cashflw_grd2 As Double
        Dim dt_as_on_1 As String
        Dim dt_as_on_2 As String


        STP_date = 10
        If ddSTPDate.SelectedItem.Text = "02nd" Then
            STP_date = 2
        ElseIf ddSTPDate.SelectedItem.Text = "10th" Then
            STP_date = 10
        ElseIf ddSTPDate.SelectedItem.Text = "20th" Then
            STP_date = 20
        ElseIf ddSTPDate.SelectedItem.Text = "28th" Then
            STP_date = 28
        End If

        todt = Split(Trim(txttodt.Text), "/")(1) & "/" & Split(Trim(txttodt.Text), "/")(0) & "/" & Split(Trim(txttodt.Text), "/")(2)
        frdt = Split(Trim(txtfrdt.Text), "/")(1) & "/" & Split(Trim(txtfrdt.Text), "/")(0) & "/" & Split(Trim(txtfrdt.Text), "/")(2)
        Valdt = Split(Trim(txtvalue.Text), "/")(1) & "/" & Split(Trim(txtvalue.Text), "/")(0) & "/" & Split(Trim(txtvalue.Text), "/")(2)

        If IsDate(frdt) = False Or IsDate(todt) = False Or IsDate(Valdt) = False Then
            txtMess.Value = "Please Enter The Dates in Proper Formats (dd/mm/yyyy).."
            Exit Sub
        End If
        If CDate(todt) <= frdt Then
            txtMess.Value = "From Date cannot be Greater than To Date.."
            Exit Sub
        End If
        If CDate(Valdt) < todt Then
            txtMess.Value = "To Date cannot be Greater than Value as on Date.."
            Exit Sub
        End If
        L1.Text = "Transfer From :"
        L2.Text = "Transfer To :"
        L1.Text = L1.Text & " " & ddtrfrom.SelectedItem.Text
        L2.Text = L2.Text & " " & ddtrto.SelectedItem.Text

        Periodcty = ddperiod.SelectedItem.Text
        If Periodcty = "Fortnightly" Then
            PrdVal = 15
        ElseIf Periodcty = "Monthly" Then
            PrdVal = 1
        ElseIf Periodcty = "Quarterly" Then
            PrdVal = 3
        End If

        Amt = Trim(txtiniamt.Text)
        'Temp = Trim(txttranamt.Text)
        CashFlow = Temp
        Colstr = "Date#Nav#Units Balance#Current Value#Transfer Amount#Dividend/Bonus#Index Value#Value After Transfer#Units Redeemed#Closing Units"
        ColArr = Split(Colstr, "#")
        For i = 0 To 9
            Ipcol = New DataColumn
            Ipcol.ColumnName = ColArr(i)
            Ipdt.Columns.Add(Ipcol)
        Next i
        ' Dstp.HeaderStyle.BackColor = Color.CornflowerBlue
        Dstp.HeaderStyle.ForeColor = Color.White

        m = 0
        j = 0
        k = 0
        x = 0
        Rowcounter = 0
        Rowcount = 0
        TotuUnits = 0

        'Indexval = Split(ddbnmark.SelectedItem.Text, " # ")(1)
        Indexval = ddbnmark1.SelectedItem.Text
        '''''''GRID ONE'''''''''''''''''''''''''''''''
        Sqlcon = New SqlConnection(constr)
        Sqlcon.Open()
        strsql = "Select dateadd(d,276,date),(nav_rs-53)/76 from nav_rec where sch_code='" & ddtrfrom.SelectedItem.Value & "' And dateadd(d,276,date) >='" & frdt & "' And dateadd(d,276,date)<='" & todt & "' order by dateadd(d,276,date)"
        Sqlcom = New SqlCommand(strsql, Sqlcon)
        Sqlrd = Sqlcom.ExecuteReader
        CalcDt = frdt
        If Sqlrd.Read Then
            chkdate = Sqlrd(0)
            Do
                If Sqlrd(0) >= chkdate And chkdate <= todt Then
                    For Pl = 0 To 3
                        sqlcon3 = New SqlConnection(constr)
                        sqlcon3.Open()
                        strsqls = "Select dateadd(d,276,date),(nav_rs-53)/76 from nav_rec where sch_code='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date) ='" & chkdate & "'"
                        Sqlcom = New SqlCommand(strsqls, sqlcon3)
                        sqlrd3 = Sqlcom.ExecuteReader
                        If sqlrd3.Read Then
                            TrueFlg = True
                            GoTo ContNext
                        Else
                            chkdate = DateAdd(DateInterval.Day, 1, chkdate)
                            TrueFlg = False
                        End If
                        sqlcon3.Close()
                        sqlcon3.Dispose()
                    Next Pl
                    If ddperiod.SelectedItem.Text <> "Fortnightly" Then
                        If Split(Sqlrd(0), "/")(1) < STP_date Then
                            CalcDt = CDate(Split(Sqlrd(0), "/")(0) & "/" & STP_date & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
                        Else
                            CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
                            Tempdtstr = Split(CalcDt, "/")
                            CalcDt = CDate(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                        End If
                    Else
                        CalcDt = DateAdd(DateInterval.Day, PrdVal, CalcDt)
                    End If
                End If
                If TrueFlg = False Then
                    GoTo NextDate
                End If
ContNext:
                NewFlg = True
                If j = 0 Then
                    Iprw = Ipdt.NewRow
                    Iprw(0) = Format(CDate(Sqlrd(0)), "dd/MM/yyyy")
                    CalcDt = Sqlrd(0)
                    ReDim Preserve DtArr(Rowcount)
                    DtArr(Rowcount) = Sqlrd(0)
                    X1Date = Sqlrd(0)
                    Iprw(1) = Sqlrd(1)
                    LastNav = Sqlrd(1)
                    X1Nav = Sqlrd(1)
                    Iprw(2) = Math.Round(Amt / Sqlrd(1), 4)
                    X1units = (Math.Round(Amt / Sqlrd(1), 4)) * -1
                    TotuUnits = TotuUnits + Iprw(2)
                    Iprw(3) = Math.Round(Amt, 2)

                    ReDim Preserve CashF(Rowcount)
                    CashF(0) = Iprw(3) * -1


                    BalUnits = Iprw(3)
                    Iprw(4) = 0
                    Iprw(5) = 0
                    ReDim Preserve TransAmt(x)
                    TransAmt(x) = Iprw(4)
                    x += 1
                    'Tempamt = Amt / Sqlrd(1)
                    TempUnits = Math.Round(TempUnits + Math.Round(Amt / Sqlrd(1), 4), 4)
                    CashInd = Iprw(4)
                    sqlcon1 = New SqlConnection(constr)
                    sqlcon1.Open()
                    strsql = "Select (ind_val-53)/76 from ind_rec where ind_code='" & Indexval & "' And dateadd(d,276,dt1)='" & Sqlrd(0) & "'"
                    Sqlcom = New SqlCommand(strsql, sqlcon1)
                    sqlrd1 = Sqlcom.ExecuteReader
                    If sqlrd1.Read Then
                        Iprw(6) = Math.Round(sqlrd1(0), 2)
                        ReDim Preserve IndexArr(m)
                        IniIndex = Iprw(6)
                        IndexArr(m) = Iprw(6)
                        m += 1
                    End If
                    sqlcon1.Close()
                    sqlcon1.Dispose()

                    Ipdt.Rows.Add(Iprw)
                    If ddperiod.SelectedItem.Text <> "Fortnightly" Then
                        If Split(Sqlrd(0), "/")(1) <= STP_date Then
                            chkdate = CDate(Split(Sqlrd(0), "/")(0) & "/" & STP_date & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)

                            If ddperiod.SelectedItem.Text = "Monthly" Then
                                If Day(chkdate) <= STP_date Then
                                    chkdate = DateAdd(DateInterval.Month, 1, chkdate)
                                End If
                            End If
                            If ddperiod.SelectedItem.Text = "Quarterly" Then
                                If Day(chkdate) <= STP_date Then
                                    chkdate = DateAdd(DateInterval.Month, 3, chkdate)
                                End If
                            End If
                        Else
                            chkdate = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
                            Tempdtstr = Split(chkdate, "/")
                            chkdate = CDate(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                        End If
                    Else
                        chkdate = DateAdd(DateInterval.Day, PrdVal, chkdate)
                    End If
                    stp_cashflw_grd1 = Math.Round(Iprw(1) * Iprw(3), 4)
                    Rowcount += 1
                ElseIf Sqlrd(0) >= CalcDt And CalcDt <= todt Then
                    Iprw = Ipdt.NewRow
                    Rowcounter += 1
                    Iprw(0) = Format(CDate(Sqlrd(0)), "dd/MM/yyyy")
                    CalcDt = Sqlrd(0)
                    ReDim Preserve DtArr(Rowcount)
                    DtArr(Rowcount) = Sqlrd(0)
                    Iprw(1) = Sqlrd(1)
                    LastNav = Sqlrd(1)
                    sqlcon1 = New SqlConnection(constr)
                    sqlcon1.Open()
                    Tempamt = Amt / Ipdt.Rows(Rowcounter - 1).Item(1)
                    If rbindivd.Checked = True Then
                        strsql = "Select (divid_pt-53)/76,dateadd(d,276,date) from div_rec  where sch_code='" & ddtrfrom.SelectedItem.Value & "' And dateadd(d,276,date)>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And dateadd(d,276,date)<'" & fmt(Iprw(0)) & "'"
                    ElseIf rbcorp.Checked = True Then
                        strsql = "Select (divid_pt_corp-53)/76,dateadd(d,276,date) from div_rec_adv where sch_code='" & ddtrfrom.SelectedItem.Value & "' And dateadd(d,276,date)>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And dateadd(d,276,date)<'" & fmt(Iprw(0)) & "'"
                    End If
                    Sqlcom = New SqlCommand(strsql, sqlcon1)
                    sqlrd1 = Sqlcom.ExecuteReader
                    If sqlrd1.Read Then
                        Do
                            TempDiv = TempDiv + sqlrd1(0)
                            sqlcon2 = New SqlConnection(constr)
                            sqlcon2.Open()
                            ''strsql = "Select (A.rmf_nav-53)/76,(B.face_val-53)/76 from nav_reg A," & _
                            ''         "Scheme_Info B where A.rmf_scheme=B.sch_code And A.rmf_scheme='BM051' And" & _
                            ''         " dateadd(d,276,A.rmf_todt)='" & sqlrd1(2) & "'"
                            'strsql = "Select (nav_rs-53)/76 from nav_rec where sch_code='BM051' And " & _
                            '         " dateadd(d,276,date)='" & sqlrd1(2) & "'"

                            strsql = "Select (nav_rs-53)/76 from nav_rec where sch_code='" & ddtrfrom.SelectedItem.Value & "' And  dateadd(d,276,date)='" & sqlrd1(2) & "'"


                            Sqlcom = New SqlCommand(strsql, sqlcon2)
                            sqlrd2 = Sqlcom.ExecuteReader
                            If sqlrd2.Read Then
                                Tempamt = Tempamt + ((((sqlrd1(0) * Face_Value(" & ddtrfrom.SelectedItem.Value & ")) / 100) * Tempamt) / sqlrd2(0))
                            End If
                            sqlcon2.Close()
                            sqlcon2.Dispose()
                        Loop While sqlrd1.Read
                    End If
                    sqlcon1.Close()
                    sqlcon1.Dispose()
                    If TempDiv <> 0 Then
                        Ipdt.Rows(Rowcounter - 1).Item(5) = Math.Round(TempDiv, 4)
                    Else
                        Ipdt.Rows(Rowcounter - 1).Item(5) = 0
                    End If
                    Iprw(2) = Math.Round(Tempamt, 4)
                    TotuUnits = TotuUnits + Iprw(2)
                    Iprw(3) = Math.Round(Iprw(1) * Iprw(2), 2)
                    BalUnits = Iprw(3)
                    If Iprw(3) - Amt > 0 Then
                        Iprw(4) = Math.Round((Iprw(3) - Amt), 4)
                    Else
                        Iprw(4) = 0
                    End If
                    ReDim Preserve TransAmt(x)
                    TransAmt(x) = Iprw(4)
                    sqlcon1 = New SqlConnection(constr)
                    sqlcon1.Open()
                    strsql = "Select (ind_val-53)/76 from ind_rec where ind_code='" & Indexval & "' And dateadd(d,276,dt1)='" & Sqlrd(0) & "'"
                    Sqlcom = New SqlCommand(strsql, sqlcon1)
                    sqlrd1 = Sqlcom.ExecuteReader
                    If sqlrd1.Read Then
                        ReDim Preserve IndexArr(m)
                        Iprw(6) = Math.Round(sqlrd1(0), 2)
                        IndexArr(m) = Iprw(6)
                        m += 1
                    Else
                        Iprw(6) = 0
                    End If
                    sqlcon1.Close()
                    sqlcon1.Dispose()
                    Iprw(7) = Math.Round(Iprw(3) - Iprw(4), 2)
                    ReDim Preserve ValueAfter(x)
                    ValueAfter(x) = Iprw(7)
                    x += 1
                    Iprw(8) = Math.Round(Iprw(4) / Iprw(1), 4)
                    Iprw(9) = Math.Round(Iprw(2) - Iprw(8), 4)
                    Tempamt = 0
                    Ipdt.Rows.Add(Iprw)
                    If ddperiod.SelectedItem.Text <> "Fortnightly" Then
                        If Split(Sqlrd(0), "/")(1) < STP_date Then
                            CalcDt = CDate(Split(Sqlrd(0), "/")(0) & "/" & STP_date & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
                        Else
                            CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
                            Tempdtstr = Split(CalcDt, "/")
                            CalcDt = CDate(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                        End If
                    Else
                        CalcDt = DateAdd(DateInterval.Day, PrdVal, CalcDt)
                    End If
                    stp_cashflw_grd1 = Math.Round(Iprw(1) * Iprw(3), 4)
                    Rowcount += 1
                End If
                j += 1
NextDate:
            Loop While Sqlrd.Read
        End If
        Sqlcon.Close()
        Sqlcon.Dispose()

        If NewFlg = False Then
            Dstp1.DataSource = Ipdt
            Dstp1.DataBind()
            Dstp1.Visible = True
            Dstp.DataSource = Ipdt
            Dstp.DataBind()
            Dstp.Visible = True
            Exit Sub
        End If

        strsql = "Select (nav_rs-53)/76,dateadd(d,276,date) from nav_rec where sch_code='" & ddtrfrom.SelectedItem.Value & "' And dateadd(d,276,date)>'" & fmt(txtvalue.Text) & "' order by dateadd(d,276,date)"
        sqlcon1 = New SqlConnection(constr)
        sqlcon1.Open()
        Sqlcom = New SqlCommand(strsql, sqlcon1)
        sqlrd1 = Sqlcom.ExecuteReader
        If sqlrd1.Read Then
            Do
                If IsDBNull(sqlrd1(0)) = False Then
                    Iprw = Ipdt.NewRow
                    Iprw(0) = Format(CDate(sqlrd1(1)), "dd/MM/yyyy")
                    X2Date = sqlrd1(1)
                    Iprw(1) = sqlrd1(0)
                    LastNav = Iprw(1)
                    X2Nav = sqlrd1(0)
                    Iprw(2) = Math.Round(Amt / sqlrd1(0), 4)
                    BalUnits = Iprw(2)
                    Iprw(3) = Math.Round(Iprw(1) * Iprw(2), 4)
                    txtbal.Text = Iprw(3)
                    ReDim Preserve CashF(Rowcount)
                    CashF(1) = Iprw(3)

                    '******** Manish
                    'txtbal.Text = Math.Round(BalUnits * Iprw(1), 2)
                    '*********END 
                    Ipdt.Rows.Add(Iprw)
                    dt_as_on_1 = Iprw(0)
                    Exit Do
                End If
            Loop While sqlrd1.Read

        End If
        Session("S1") = Ipdt
        Dstp.DataSource = Ipdt
        Dstp.DataBind()
        Dstp.Visible = True
        Rowcount = 0
        '''''--------------GRID TWO-----------------------------
        Ipdt = New DataTable
        Rowcounter = 0

        Colstr = "Date#Nav#Units#Cumulative Units#Dividend#Cumulative Value#Investment In Index#Value#Total"
        ColArr = Split(Colstr, "#")
        For i = 0 To 8
            Ipcol = New DataColumn
            Ipcol.ColumnName = ColArr(i)
            Ipdt.Columns.Add(Ipcol)
        Next i
        j = 0
        m = 0
        x = 0

        CalcDt = frdt
        ' Dstp1.HeaderStyle.BackColor = Color.CornflowerBlue
        Dstp1.HeaderStyle.ForeColor = Color.White
        Sqlcon = New SqlConnection(constr)
        Sqlcon.Open()
        strsql = "Select dateadd(d,276,date),(nav_rs-53)/76 from nav_rec where sch_code='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date) >='" & frdt & "' And dateadd(d,276,date)<='" & todt & "' order by dateadd(d,276,date)"
        Sqlcom = New SqlCommand(strsql, Sqlcon)
        Sqlrd = Sqlcom.ExecuteReader
        CalcDt = frdt
        If Sqlrd.Read Then
            Do
                If j = 0 Then
                    Iprw = Ipdt.NewRow
                    CumUnts = 0
                    Iprw(0) = Format(CDate(Sqlrd(0)), "dd/MM/yyyy")
                    CalcDt = Sqlrd(0)
                    DtArr(0) = Iprw(0)
                    Iprw(5) = Amt

                    Iprw(6) = Amt
                    Ipdt.Rows.Add(Iprw)
                    Iprw = Ipdt.NewRow
                    Rowcounter += 1
                    Iprw(0) = Format(CDate(Sqlrd(0)), "dd/MM/yyyy")
                    Iprw(1) = Sqlrd(1)
                    T2LastNav = Sqlrd(1)
                    Iprw(2) = Math.Round(TransAmt(m) / Sqlrd(1), 4)
                    CumUnits = Iprw(2)
                    NewUnts = Math.Round(TransAmt(m) / Sqlrd(1), 4)
                    CumUnts = CumUnts + NewUnts
                    Iprw(3) = Math.Round(CumUnts, 4)
                    sqlcon1 = New SqlConnection(constr)
                    sqlcon1.Open()

                    '''If rbindivd.Checked = True Then
                    '''    strsql = "Select (divid_pt-53)/76,dateadd(d,276,date) from div_rec  where sch_code='" & ddtrfrom.SelectedItem.Value & "' And dateadd(d,276,date)>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And dateadd(d,276,date)<'" & fmt(Iprw(0)) & "'"
                    '''ElseIf rbcorp.Checked = True Then
                    '''    strsql = "Select (divid_pt_corp-53)/76,dateadd(d,276,date) from div_rec_adv where sch_code='" & ddtrfrom.SelectedItem.Value & "' And dateadd(d,276,date)>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And dateadd(d,276,date)<'" & fmt(Iprw(0)) & "'"
                    '''End If



                    If rbindivd.Checked Then
                        strsql = "Select sum((divid_pt_corp-53)/76) from div_rec_adv where sch_code='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date)>='" & Format(CDate(Ipdt.Rows(Rowcounter - 1).Item(0)), "MM/dd/yyyy") & "' And dateadd(d,276,date)<='" & Format(CDate(Iprw(0)), "MM/dd/yyyy") & "'"
                    ElseIf rbcorp.Checked = True Then
                        strsql = "Select sum((divid_pt_corp-53)/76) from div_rec_adv where sch_code='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date)>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And dateadd(d,276,date)<='" & fmt(Iprw(0)) & "'"
                    End If
                    Sqlcom = New SqlCommand(strsql, sqlcon1)
                    sqlrd1 = Sqlcom.ExecuteReader
                    If sqlrd1.Read Then
                        If IsDBNull(sqlrd1(0)) = False Then
                            Iprw(4) = sqlrd1(0)
                        Else
                            Iprw(4) = 0
                        End If
                    End If
                    sqlcon1.Close()
                    sqlcon1.Dispose()
                    Iprw(5) = Math.Round(Iprw(1) * Iprw(3), 2)

                    Ipdt.Rows.Add(Iprw)
                    If ddperiod.SelectedItem.Text <> "Fortnightly" Then
                        If Split(Sqlrd(0), "/")(1) < STP_date Then
                            CalcDt = CDate(Split(Sqlrd(0), "/")(0) & "/" & STP_date & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
                        Else
                            CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
                            Tempdtstr = Split(CalcDt, "/")
                            CalcDt = CDate(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                        End If
                    Else
                        CalcDt = DateAdd(DateInterval.Day, PrdVal, CalcDt)
                    End If
                    stp_cashflw_grd2 = Iprw(1) * Iprw(3)
                    If m <= UBound(IndexArr) Then
                        If IniIndex = 0 Then
                            Iprw(6) = 0
                        Else
                            Iprw(6) = Math.Round(((Amt * IndexArr(m)) / IniIndex), 2)
                        End If
                    End If
                    Iprw(7) = Iprw(5)
                    If IsNothing(ValueAfter) = False Then
                        If x <= UBound(ValueAfter) Then
                            Iprw(8) = Math.Round(Iprw(6) + ValueAfter(x), 2)
                            x += 1
                            ReDim Preserve Currval(Rowcount)
                            Currval(Rowcount) = Iprw(8)
                        End If
                    End If

                    m += 1
                    Rowcount += 1
                ElseIf Sqlrd(0) >= CalcDt And CalcDt <= todt Then
                    Iprw = Ipdt.NewRow
                    Rowcounter += 1
                    Iprw(0) = Format(CDate(Sqlrd(0)), "dd/MM/yyyy")
                    CalcDt = Sqlrd(0)
                    Iprw(1) = Sqlrd(1)
                    T2LastNav = Sqlrd(1)
                    ''''If m <= UBound(IndexArr) Then
                    ''''    If m <= UBound(TransAmt) Then
                    If m <= UBound(TransAmt) Then
                        If m <= UBound(TransAmt) Then
                            Iprw(2) = Math.Round(TransAmt(m) / Sqlrd(1), 4)
                            CumUnits = Iprw(2)
                            NewUnts = Math.Round(TransAmt(m) / Sqlrd(1), 4)
                            CumUnts = CumUnts + NewUnts
                            Iprw(3) = Math.Round(CumUnts, 4)
                        End If
                        sqlcon1 = New SqlConnection(constr)
                        sqlcon1.Open()

                        '''If rbindivd.Checked Then
                        '''    strsql = "Select sum((divid_pt -53)/76) from div_rec  where sch_code ='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date)>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And dateadd(d,276,date)<='" & fmt(Iprw(0)) & "'"
                        '''ElseIf rbcorp.Checked = True Then
                        '''    strsql = "Select sum((divid_pt_corp-53)/76) from div_rec_adv where sch_code='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date)>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And dateadd(d,276,date)<='" & fmt(Iprw(0)) & "'"
                        '''End If


                        '*******MANISH*********
                        '''''If rbindivd.Checked Then
                        '''''    strsql = "Select sum((divid_pt -53)/76) from div_rec  where sch_code ='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date)>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And dateadd(d,276,date)<='" & fmt(Iprw(0)) & "'"
                        '''''ElseIf rbcorp.Checked = True Then
                        '''''    strsql = "Select sum((divid_pt_corp-53)/76) from div_rec_adv where sch_code='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date)>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And dateadd(d,276,date)<='" & fmt(Iprw(0)) & "'"
                        '''''End If

                        If rbindivd.Checked Then
                            strsql = "Select sum((divid_pt_corp-53)/76) from div_rec_adv where sch_code='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date)>='" & Format(CDate(Ipdt.Rows(Rowcounter - 1).Item(0)), "MM/dd/yyyy") & "' And dateadd(d,276,date)<='" & Format(CDate(Iprw(0)), "MM/dd/yyyy") & "'"
                        ElseIf rbcorp.Checked = True Then
                            strsql = "Select sum((divid_pt_corp-53)/76) from div_rec_adv where sch_code='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date)>='" & Format(CDate(Ipdt.Rows(Rowcounter - 1).Item(0)), "MM/dd/yyyy") & "' And dateadd(d,276,date)<='" & Format(CDate(Iprw(0)), "MM/dd/yyyy") & "'"
                        End If

                        Sqlcom = New SqlCommand(strsql, sqlcon1)
                        sqlrd1 = Sqlcom.ExecuteReader
                        If sqlrd1.Read Then
                            If IsDBNull(sqlrd1(0)) = False Then
                                Iprw(4) = sqlrd1(0)
                            Else
                                Iprw(4) = 0
                            End If
                        End If
                        sqlcon1.Close()
                        sqlcon1.Dispose()
                        Iprw(5) = Math.Round(Iprw(1) * Iprw(3), 2)

                        If m <= UBound(TransAmt) Then
                            If IniIndex = 0 Then
                                Iprw(6) = 0
                            Else
                                Iprw(6) = Math.Round(((Amt * IndexArr(m)) / IniIndex), 2)
                            End If
                        End If
                        Iprw(7) = Iprw(5)
                        If IsNothing(ValueAfter) = False Then
                            If x <= UBound(ValueAfter) Then
                                Iprw(8) = Math.Round(Iprw(6) + ValueAfter(x), 2)
                                x += 1
                                ReDim Preserve Currval(Rowcount)
                                Currval(Rowcount) = Iprw(8)
                            End If
                        End If
                    End If
                    If ddperiod.SelectedItem.Text <> "Fortnightly" Then
                        If Split(Sqlrd(0), "/")(1) < STP_date Then
                            CalcDt = CDate(Split(Sqlrd(0), "/")(0) & "/" & STP_date & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
                        Else
                            CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
                            Tempdtstr = Split(CalcDt, "/")
                            CalcDt = CDate(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                        End If
                    Else
                        CalcDt = DateAdd(DateInterval.Day, PrdVal, CalcDt)
                    End If
                    Ipdt.Rows.Add(Iprw)
                    m += 1
                    Rowcount += 1
                End If
                j += 1
            Loop While Sqlrd.Read
        End If
        Sqlcon.Close()
        Sqlcon.Dispose()

        strsql = "Select (nav_rs-53)/76,dateadd(d,276,date) from nav_rec where sch_code ='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date)>'" & fmt(txtvalue.Text) & "' order by dateadd(d,276,date)"
        sqlcon1 = New SqlConnection(constr)
        sqlcon1.Open()
        Sqlcom = New SqlCommand(strsql, sqlcon1)
        sqlrd1 = Sqlcom.ExecuteReader
        If sqlrd1.Read Then
            Do
                If IsDBNull(sqlrd1(0)) = False Then
                    Iprw = Ipdt.NewRow
                    Iprw(0) = Format(CDate(sqlrd1(1)), "dd/MM/yyyy")
                    Iprw(1) = sqlrd1(0)
                    Iprw(3) = CumUnts
                    ReDim Preserve CashF(Rowcount)
                    CashF(2) = Iprw(3)
                    dt_as_on_2 = Iprw(0)
                    txtacc.Text = Math.Round(CumUnts * Iprw(1), 4)
                    Ipdt.Rows.Add(Iprw)
                    stp_cashflw_grd2 = Math.Round(Iprw(1) * Iprw(3), 4)
                    Exit Do
                End If
            Loop While sqlrd1.Read

        End If

        '''''''''''XIRRSSSSSSS CALCULATION''''''''''''''''''''''
        Dim Dt As String = ""
        Dim cashflw As String = ""
        Dim cashindx As String = ""

        ''''''''''''***************MANISH 

        '''''''''''If IsNothing(DtArr) = False And IsNothing(Currval) = False Then
        '''''''''''    For i = 0 To UBound(Currval)
        '''''''''''        If Dt = "" Then
        '''''''''''            Dt = DtArr(i)
        '''''''''''        Else
        '''''''''''            Dt = Dt & "," & DtArr(i)
        '''''''''''        End If
        '''''''''''        If cashflw = "" Then
        '''''''''''            cashflw = Currval(i) * -1
        '''''''''''        Else
        '''''''''''            cashflw = cashflw & "," & (Currval(i) * -1)
        '''''''''''        End If
        '''''''''''        If cashindx = "" Then
        '''''''''''            cashindx = Currval(i)
        '''''''''''        Else
        '''''''''''            cashindx = cashindx & "," & Currval(i)
        '''''''''''        End If
        '''''''''''    Next i
        '''''''''''Else
        '''''''''''    txtyldinv.Text = ""
        '''''''''''    txtyield.Text = ""
        '''''''''''    GoTo noxirr
        '''''''''''End If

        '''''''''''Dt = Dt & "," & CDate(fmt(txtvalue.Text))
        '''''''''''cashflw = cashflw & "," & TotuUnits
        '''''''''''cashindx = cashindx & "," & TotNav
        '''''''''''Dt = X1Date & "," & X2Date
        '''''''''''cashflw = Val(txtiniamt.Text) * -1 & "," & ((LastNav * BalUnits) + (T2LastNav * CumUnts))

        '''''''''''If Sqlcon.State = ConnectionState.Open Then
        '''''''''''    Sqlcon.Close()
        '''''''''''End If
        '''''''''''Sqlcon = New SqlConnection(constr)
        '''''''''''Sqlcon.Open()
        '''''''''''Sqlcom = New SqlCommand("xirrs", Sqlcon)
        '''''''''''With Sqlcom

        '''''''''''    .CommandType = CommandType.StoredProcedure
        '''''''''''    .Parameters.Add("@dstr", SqlDbType.VarChar, 5000).Value = Dt
        '''''''''''    .Parameters.Add("@astr", SqlDbType.VarChar, 5000).Value = cashflw
        '''''''''''    .Parameters.Add("@xirrx", SqlDbType.Float).Direction = ParameterDirection.Output
        '''''''''''    .ExecuteNonQuery()
        '''''''''''End With
        '''''''''''getXirr = Math.Round(Sqlcom.Parameters("@xirrx").Value, 2)
        '''''''''''Sqlcom.Dispose() : Sqlcon.Close() : Sqlcon.Dispose()
        '''''''''''txtyield.Text = getXirr

        ''''''''''''************END

        ReDim Preserve CashFl(Rowcount - 1)
        CashFl(Rowcount - 1) = stp_cashflw_grd1 + stp_cashflw_grd2

        ReDim Preserve IndexArr(Rowcount - 1)
        IndexArr(Rowcount - 1) = stp_cashflw_grd1 + stp_cashflw_grd2




        '**************  MANISH  ****************

        If IsNothing(DtArr) = False Then
            For i = 0 To UBound(DtArr)
                If Dt = "" Then
                    Dt = Format(DtArr(i), "dd/MM/yyyy")
                Else
                    If CashFl(i) <> 0 Then
                        Dt = Dt & "," & Format(DtArr(i), "dd/MM/yyyy")
                    End If
                End If
            Next i
        End If
        If IsNothing(CashFl) = False Then
            For i = 0 To UBound(CashFl)
                If cashflw = "" Then
                    cashflw = CashFl(i)
                Else
                    If CashFl(i) <> 0 Then
                        cashflw = cashflw & "," & CashFl(i)
                    End If
                End If
            Next i
        End If

        If IsNothing(IndexArr) = False Then
            For i = 0 To UBound(IndexArr)
                If cashindx = "" Then
                    cashindx = IndexArr(i)
                Else
                    If CashFl(i) <> 0 Then
                        cashindx = cashindx & "," & IndexArr(i)
                    End If
                End If
            Next i
        End If
        Dt = cdates(CDate(DtArr(0))) & "," & cdates(CDate(dt_as_on_1)) & "," & cdates(CDate(dt_as_on_2))
        cashflw = CashF(0) & "," & CashF(1) & "," & CashF(2)
        getXirr = XIRR(Dt, cashflw)
        txtyield.Text = Math.Round(getXirr, 2)
        getXirr = XIRR(Dt, cashindx)
        txtyldinv.Text = Math.Round(getXirr, 2)


        '***************    END    ***********





        '''''''''''''''''''''''If IsNothing(DtArr) = False Then
        '''''''''''''''''''''''    For i = 0 To UBound(DtArr)
        '''''''''''''''''''''''        If Dt = "" Then
        '''''''''''''''''''''''            Dt = Format(DtArr(i), "dd/MM/yyyy")
        '''''''''''''''''''''''        Else
        '''''''''''''''''''''''            Dt = Dt & "," & Format(DtArr(i), "dd/MM/yyyy")
        '''''''''''''''''''''''        End If
        '''''''''''''''''''''''    Next i
        '''''''''''''''''''''''End If
        '''''''''''''''''''''''If IsNothing(CashFl) = False Then
        '''''''''''''''''''''''    For i = 0 To UBound(CashFl)
        '''''''''''''''''''''''        If cashflw = "" Then
        '''''''''''''''''''''''            cashflw = CashFl(i)
        '''''''''''''''''''''''        Else
        '''''''''''''''''''''''            cashflw = cashflw & "," & CashFl(i)
        '''''''''''''''''''''''        End If
        '''''''''''''''''''''''    Next i
        '''''''''''''''''''''''End If

        '''''''''''''''''''''''If IsNothing(IndexArr) = False Then
        '''''''''''''''''''''''    For i = 0 To UBound(IndexArr)
        '''''''''''''''''''''''        If cashindx = "" Then
        '''''''''''''''''''''''            cashindx = IndexArr(i)
        '''''''''''''''''''''''        Else
        '''''''''''''''''''''''            cashindx = cashindx & "," & IndexArr(i)
        '''''''''''''''''''''''        End If
        '''''''''''''''''''''''    Next i
        '''''''''''''''''''''''End If

        '''''''''''''''''''''''getXirr = XIRR(Dt, cashflw)
        '''''''''''''''''''''''txtyield.Text = Math.Round(getXirr, 2)
        '''''''''''''''''''''''getXirr = XIRR(Dt, cashindx)
        '''''''''''''''''''''''txtyldinv.Text = Math.Round(getXirr, 2)

        ''        Dt = ""
        ''        cashflw = ""
        ''        Dt = X1Date & "," & X2Date
        ''        cashflw = (X1Nav * X1units) & "," & (X2Nav * X1units) * -1
        ''        'cashindx = cashindx & "," & TotNav
        ''        If Sqlcon.State = ConnectionState.Open Then
        ''            Sqlcon.Close()
        ''        End If
        ''        Sqlcon = New SqlConnection(constr)
        ''        Sqlcon.Open()
        ''        Sqlcom = New SqlCommand("xirrs", Sqlcon)
        ''        With Sqlcom

        ''            .CommandType = CommandType.StoredProcedure
        ''            .Parameters.Add("@dstr", SqlDbType.VarChar, 5000).Value = Dt
        ''            .Parameters.Add("@astr", SqlDbType.VarChar, 5000).Value = cashflw
        ''            .Parameters.Add("@xirrx", SqlDbType.Float).Direction = ParameterDirection.Output
        ''            .ExecuteNonQuery()
        ''        End With
        ''        getXirr = Math.Round(Sqlcom.Parameters("@xirrx").Value, 2)
        ''        Sqlcom.Dispose() : Sqlcon.Close() : Sqlcon.Dispose()
        ''        txtyldinv.Text = getXirr
        'noxirr:
        Session("S2") = Ipdt
        Session("SFROM") = ddtrfrom.SelectedItem.Text
        Session("STO") = ddtrto.SelectedItem.Text
        Dstp1.DataSource = Ipdt
        Dstp1.DataBind()
        Dstp1.Visible = True
        'cmdexp1.Attributes.Add("onClick", "javascript:newexports('Dstp','Dstp1',1,'" & txtbal.Text & "','" & txtacc.Text & "','" & txtyield.Text & "',' ','" & ddtrfrom.SelectedItem.Text & "','" & ddtrto.SelectedItem.Text & "');return false;")
    End Sub

    Private Sub Jscript()
        txtwinamt.Attributes.Add("OnChange", "return ValidateAmount1();")
        txtwtramt.Attributes.Add("OnChange", "return ValidateAmount2();")
        txtinstall.Attributes.Add("OnChange", "return ValidateAmount3();")
        'txtiniamt.Attributes.Add("OnChange", "return ValidateAmount4();")
        'txttranamt.Attributes.Add("OnChange", "return ValidateAmount5();")
        txtSIP_EntryLoad.Attributes.Add("OnChange", "return ValidateAmount6();")
        txtSWP_EntryLoad.Attributes.Add("OnChange", "return ValidateAmount7();")
    End Sub

    Private Function Face_Value(ByVal sch_code As String) As Double
        Dim scheme As Boolean
        scheme_codes = Split(sch_codes, ",")
        scheme = False

        For i = 0 To UBound(scheme_codes)
            If sch_code = scheme_codes(i) Then
                scheme = True
                Exit For
            End If
        Next

        Face_Value = 0.0
        If scheme = True Then
            Face_Value = 1000.0
        Else
            Face_Value = 10.0
        End If
        scheme = False
    End Function


#End Region

    ''Private Sub cmdSTP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Private Overloads Sub cmdSTP_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdSTP.Click

        '//new procedure that calculate both fixed and capital         
        If txtfrdt.Text <> "" Then
            If STPdt.Visible = True Then
                If Trim(STPdt.SelectedItem.Text) = "--" Then
                    Response.Write("<script>alert(""STP date cannot be blank"")</script>")
                    Exit Sub
                Else
                    If Split(txtfrdt.Text, "/")(1) = 4 Or Split(txtfrdt.Text, "/")(1) = 6 Or Split(txtfrdt.Text, "/")(1) = 9 Or Split(txtfrdt.Text, "/")(1) = 11 Then
                        If CInt(STPdt.SelectedItem.Text) > 30 Then
                            Response.Write("<script>alert(""STP date cannot be greater than 30.."")</script>")
                            Exit Sub
                        End If
                    ElseIf Split(txtfrdt.Text, "/")(1) = 2 Then
                        Math.DivRem(CInt(Split(txtfrdt.Text, "/")(2)), 4, Reminder)
                        If Reminder <> 0 Then
                            If CInt(STPdt.SelectedItem.Text) > 28 Then
                                Response.Write("<script>alert(""STP date cannot be greater than 28.."")</script>")
                                Exit Sub
                            End If
                        Else
                            If CInt(STPdt.SelectedItem.Text) > 29 Then
                                Response.Write("<script>alert(""STP date cannot be greater than 28.."")</script>")
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If
        End If

        If rbcapital.Checked = False Then
            cmdSTP.Attributes.Add("onclick", "javascript:return validate_STP();")
        Else
            cmdSTP.Attributes.Add("onclick", "javascript:return validate_STP_New();")
        End If

        Call executeSTP()
        SetHtmlSTP()
        Exit Sub

#Region "Commented"
        '''''''''        Dim frdt As Date
        '''''''''        Dim todt As Date
        '''''''''        Dim Valdt As Date
        '''''''''        Dim Colstr As String
        '''''''''        Dim ColArr() As String
        '''''''''        Dim m As Integer = 0
        '''''''''        Dim j As Integer = 0
        '''''''''        Dim k As Integer = 0
        '''''''''        Dim x As Integer = 0
        '''''''''        Dim Periodcty As String
        '''''''''        Dim PrdVal As Integer = 0
        '''''''''        Dim CalcDt As Date
        '''''''''        Dim Amt As Double = 0
        '''''''''        Dim Temp As Double = 0
        '''''''''        Dim Transfer_Amt As Double = 0
        '''''''''        Dim CashFlow As Double = 0
        '''''''''        Dim CumUnts As Double = 0
        '''''''''        Dim NewUnts As Double = 0
        '''''''''        Dim Indexval As String
        '''''''''        Dim IndexArr() As Double
        '''''''''        Dim ValueAfter() As Double
        '''''''''        Dim CashInd As Double = 0
        '''''''''        Dim IniIndex As Double = 0
        '''''''''        Dim Rowcounter As Integer = 0
        '''''''''        Dim TotNav As Double = 0
        '''''''''        Dim IndUnits As Double = 0
        '''''''''        Dim TempNav As Double = 0
        '''''''''        Dim currentIndex As Double = 0
        '''''''''        Dim DtArr() As Date
        '''''''''        Dim Currval() As Double
        '''''''''        Dim Rowcount As Integer = 0
        '''''''''        Dim FinalUnts As Double = 0
        '''''''''        Dim UntsRdmd As Double = 0
        '''''''''        Dim TotUnits As Double = 0
        '''''''''        Dim X1units As Double = 0
        '''''''''        Dim X1Nav As Double = 0
        '''''''''        Dim X1Date As Date
        '''''''''        Dim X2Date As Date
        '''''''''        Dim X2Nav As Double = 0
        '''''''''        Dim Tempdtstr(2) As String
        '''''''''        Dim Pl As Integer = 0
        '''''''''        Dim chkdate As Date
        '''''''''        Dim TrueFlg As Boolean = False
        '''''''''        'Dim NewFlg As Boolean = False
        '''''''''        Dim TranDtArr() As Date
        '''''''''        Dim STP_date As Integer
        '''''''''        Dim cuml_units As Double
        '''''''''        Dim dg1_last_date As String
        '''''''''        Dim stp_cashflw_grd1 As Double
        '''''''''        Dim stp_cashflw_grd2 As Double
        '''''''''        Dim CashFl() As Double
        '''''''''        Dim CashFl1() As Double
        '''''''''        Dim CashFl2() As Double
        '''''''''        Dim dt_as_on_1 As String
        '''''''''        Dim dt_as_on_2 As String


        '''''''''        Dim Fixed_Transfer As Boolean
        '''''''''        '//vishal for capital apprecitin
        '''''''''        Dim cash_transfer_capital() As Double



        '''''''''        rbindivd.Checked = True

        '''''''''        Try

        '''''''''            Ipdt.Clear()
        '''''''''            Dstp.Columns.Clear()
        '''''''''            Dstp1.Columns.Clear()

        '''''''''            STP_date = 10
        '''''''''            If ddSTPDate.SelectedItem.Text = "02nd" Then
        '''''''''                'STP_date = 2
        '''''''''                STP_date = 1
        '''''''''            ElseIf ddSTPDate.SelectedItem.Text = "10th" Then
        '''''''''                STP_date = 10
        '''''''''            ElseIf ddSTPDate.SelectedItem.Text = "20th" Then
        '''''''''                STP_date = 20
        '''''''''            ElseIf ddSTPDate.SelectedItem.Text = "28th" Then
        '''''''''                STP_date = 28
        '''''''''            End If

        '''''''''            If ddPlan.SelectedItem.Text = "--" Then
        '''''''''                'txtMess.Value = "Please Select Any Plan.."
        '''''''''                Response.Write("<script>alert(""Please Select Any Plan.."")</script>")
        '''''''''                Exit Sub
        '''''''''            End If

        '''''''''            If ddtrfrom.SelectedItem.Text = "--" Then
        '''''''''                'txtMess.Value = "Please Select Transfer From Scheme.."
        '''''''''                Response.Write("<script>alert(""Please Select Transfer From Scheme.."")</script>")
        '''''''''                Exit Sub
        '''''''''            End If
        '''''''''            If ddtrto.SelectedItem.Text = "--" Then
        '''''''''                'txtMess.Value = "Please Select Transfer To Scheme.."
        '''''''''                Response.Write("<script>alert(""Please Select Transfer To Scheme.."")</script>")
        '''''''''                Exit Sub
        '''''''''            End If
        '''''''''            If ddbnmark.SelectedItem.Text = "--" Then
        '''''''''                'txtMess.Value = "Please Select Transfer To Scheme.."
        '''''''''                Response.Write("<script>alert(""Please Select Transfer To Scheme.."")</script>")
        '''''''''                Exit Sub
        '''''''''            End If
        '''''''''            If Val(txtiniamt.Text) = 0 Then
        '''''''''                'txtMess.Value = "Installment Amount Cannot Be Blank.."
        '''''''''                Response.Write("<script>alert(""Initial amount cannot be Blank.."")</script>")
        '''''''''                Exit Sub
        '''''''''            End If

        '''''''''            If Val(txtiniamt.Text) < 10000 Then
        '''''''''                'txtMess.Value = "Installment Amount Cannot Be Blank.."
        '''''''''                Response.Write("<script>alert(""Initial amount cannot be less than 10,000/- Rs."")</script>")
        '''''''''                Exit Sub
        '''''''''            End If

        '''''''''            Fixed_Transfer = False
        '''''''''            If rbfixed.Checked = True Then
        '''''''''                Fixed_Transfer = True
        '''''''''                If Val(txttranamt.Text) = 0 Then
        '''''''''                    'txtMess.Value = "Transfer Amount Cannot Be Blank.."
        '''''''''                    Response.Write("<script>alert(""Transfer amount cannot be blank.."")</script>")
        '''''''''                    Exit Sub
        '''''''''                End If
        '''''''''            End If

        '''''''''            Fixed_Transfer = False
        '''''''''            If rbfixed.Checked = True Then
        '''''''''                Fixed_Transfer = True
        '''''''''            ElseIf rbcapital.Checked = True Then
        '''''''''                Fixed_Transfer = False
        '''''''''            End If

        '''''''''            If txtfrdt.Text = "" Or txttodt.Text = "" Then
        '''''''''                'txtMess.Value = "From Date / To Date Can Not be Blank.."
        '''''''''                Response.Write("<script>alert(""From Date / To Date Can Not be Blank.."")</script>")
        '''''''''                Exit Sub
        '''''''''            End If
        '''''''''            If Val(txtvalue.Text) = 0 Then
        '''''''''                'txtMess.Value = "Please Enter Value As on Date.."
        '''''''''                Response.Write("<script>alert(""Please Enter Value As on Date.."")</script>")
        '''''''''                Exit Sub
        '''''''''            End If

        '''''''''            If ddperiod.SelectedItem.Text = "--" Then
        '''''''''                'txtMess.Value = "Please Select Any Periodicity.."
        '''''''''                Response.Write("<script>alert(""Please Select Any Periodicity.."")</script>")
        '''''''''                Exit Sub
        '''''''''            End If
        '''''''''            If rbcapital.Checked = False And rbfixed.Checked = False Then
        '''''''''                'txtMess.Value = "Please Select Option Capital Transfer/Fixed Transfer options .."
        '''''''''                Response.Write("<script>alert(""Please Select Option Capital Transfer/Fixed Transfer options .."")</script>")
        '''''''''                Exit Sub
        '''''''''            End If
        '''''''''            If rbindivd.Checked = False And rbcorp.Checked = False Then
        '''''''''                'txtMess.Value = "Please Select Option for Dividend (Individual/Corporate)  .."
        '''''''''                Response.Write("<script>alert(""Please Select Option for Dividend (Individual/Corporate)  .."")</script>")
        '''''''''                Exit Sub
        '''''''''            End If

        '''''''''            If Fixed_Transfer = False Then
        '''''''''                Call fillcapital()
        '''''''''                Dstp.Visible = True
        '''''''''                Dstp1.Visible = True
        '''''''''                Exit Sub
        '''''''''            End If
        '''''''''            For i = 1 To Len(txtfrdt.Text)
        '''''''''                If Mid(Trim(txtfrdt.Text), i, 1) = "/" Then
        '''''''''                    x += 1
        '''''''''                End If
        '''''''''            Next i
        '''''''''            If x <> 2 Then
        '''''''''                'txtMess.Value = "Please Enter From Date in proper format.."
        '''''''''                Response.Write("<script>alert(""Please Enter From Date in proper format.."")</script>")
        '''''''''                Exit Sub
        '''''''''            End If
        '''''''''            i = 0
        '''''''''            x = 0

        '''''''''            For i = 1 To Len(txttodt.Text)
        '''''''''                If Mid(Trim(txttodt.Text), i, 1) = "/" Then
        '''''''''                    x += 1
        '''''''''                End If
        '''''''''            Next i
        '''''''''            If x <> 2 Then
        '''''''''                'txtMess.Value = "Please Enter To Date in proper format.."
        '''''''''                Response.Write("<script>alert(""Please Enter To Date in proper format.."")</script>")
        '''''''''                Exit Sub
        '''''''''            End If
        '''''''''            i = 0
        '''''''''            x = 0

        '''''''''            For i = 1 To Len(txtvalue.Text)
        '''''''''                If Mid(Trim(txtvalue.Text), i, 1) = "/" Then
        '''''''''                    x += 1
        '''''''''                End If
        '''''''''            Next i
        '''''''''            If x <> 2 Then
        '''''''''                'txtMess.Value = "Please Value as on Date in proper format.."
        '''''''''                Response.Write("<script>alert(""Please Value as on Date in proper format.."")</script>")
        '''''''''                Exit Sub
        '''''''''            End If
        '''''''''            i = 0
        '''''''''            x = 0

        '''''''''            If IsDate(fmt(Trim(txtfrdt.Text))) = False Or IsDate(fmt(Trim(txttodt.Text))) = False Or IsDate(fmt(Trim(txtvalue.Text))) = False Then
        '''''''''                'txtMess.Value = "Please Enter The Dates in Proper Formats (dd/mm/yyyy).."
        '''''''''                Response.Write("<script>alert(""Please Enter The Dates in Proper Formats (dd/mm/yyyy).."")</script>")
        '''''''''                Exit Sub
        '''''''''            End If
        '''''''''            Ipdt = New DataTable
        '''''''''            todt = Split(Trim(txttodt.Text), "/")(1) & "/" & Split(Trim(txttodt.Text), "/")(0) & "/" & Split(Trim(txttodt.Text), "/")(2)
        '''''''''            frdt = Split(Trim(txtfrdt.Text), "/")(1) & "/" & Split(Trim(txtfrdt.Text), "/")(0) & "/" & Split(Trim(txtfrdt.Text), "/")(2)
        '''''''''            Valdt = Split(Trim(txtvalue.Text), "/")(1) & "/" & Split(Trim(txtvalue.Text), "/")(0) & "/" & Split(Trim(txtvalue.Text), "/")(2)


        '''''''''            If Val(txtiniamt.Text) < Val(txttranamt.Text) Then
        '''''''''                'txtMess.Value = "Transfer Amount cannot be Greater than Initial Amount.."
        '''''''''                Response.Write("<script>alert(""Transfer Amount cannot be Greater than Initial Amount.."")</script>")
        '''''''''                Exit Sub
        '''''''''            End If
        '''''''''            If CDate(todt) <= frdt Then
        '''''''''                'txtMess.Value = "From Date cannot be Greater than To Date.."
        '''''''''                Response.Write("<script>alert(""From Date cannot be Greater than To Date.."")</script>")
        '''''''''                Exit Sub
        '''''''''            End If
        '''''''''            If CDate(Valdt) < todt Then
        '''''''''                'txtMess.Value = "To Date cannot be Greater than Value as on Date.."
        '''''''''                Response.Write("<script>alert(""To Date cannot be Greater than Value as on Date.."")</script>")
        '''''''''                Exit Sub
        '''''''''            End If

        '''''''''            tblSTP1.Visible = True
        '''''''''            L1.Text = "Transfer From :"
        '''''''''            L2.Text = "Transfer To :"
        '''''''''            L1.Text = L1.Text & " " & ddtrfrom.SelectedItem.Text
        '''''''''            L2.Text = L2.Text & " " & ddtrto.SelectedItem.Text

        '''''''''            Periodcty = ddperiod.SelectedItem.Text
        '''''''''            If Periodcty = "Weekly" Then
        '''''''''                PrdVal = 7
        '''''''''            ElseIf Periodcty = "Fortnightly" Then
        '''''''''                PrdVal = 15
        '''''''''            ElseIf Periodcty = "Monthly" Then
        '''''''''                PrdVal = 1
        '''''''''            ElseIf Periodcty = "Quarterly" Then
        '''''''''                PrdVal = 3
        '''''''''            End If

        '''''''''            If Periodcty = "Monthly" Then
        '''''''''                If Val(txttranamt.Text) < 1000 Then
        '''''''''                    Response.Write("<script>alert(""Transfer amount cannot be less than 1000/- Rs."")</script>")
        '''''''''                    Exit Sub
        '''''''''                End If
        '''''''''                If Val(txttranamt.Text) > 1000 Then
        '''''''''                    Dim val1 As Integer
        '''''''''                    val1 = Val(txttranamt.Text)
        '''''''''                    If val1 Mod 100 <> 0 Then
        '''''''''                        Response.Write("<script>alert(""Please enter transfer amount in multiples of Rs.100/- only"")</script>")
        '''''''''                        Exit Sub
        '''''''''                    End If
        '''''''''                End If

        '''''''''            End If

        '''''''''            If Periodcty = "Quarterly" Then
        '''''''''                If Val(txttranamt.Text) < 3000 Then
        '''''''''                    Response.Write("<script>alert(""Transfer amount cannot be less than Rs.3000/-"")</script>")
        '''''''''                    Exit Sub
        '''''''''                End If
        '''''''''                If Val(txttranamt.Text) > 3000 Then
        '''''''''                    Dim val1 As Integer
        '''''''''                    val1 = Val(txttranamt.Text)
        '''''''''                    If val1 Mod 100 <> 0 Then
        '''''''''                        Response.Write("<script>alert(""Please enter transfer amount in multiples of Rs.100/- only"")</script>")
        '''''''''                        Exit Sub
        '''''''''                    End If
        '''''''''                End If

        '''''''''            End If


        '''''''''            Amt = Trim(txtiniamt.Text)
        '''''''''            Temp = Trim(txttranamt.Text)
        '''''''''            Transfer_Amt = Temp
        '''''''''            CashFlow = Temp
        '''''''''            ''Colstr = "Date#NAV#Units#Cumulative Units#CashFlow#Dividend"
        '''''''''            Colstr = "Date#NAV#Units#Cumulative Units#Current Value#CashFlow#Dividend#Index#Index Value#Value After Transfer#Units Redeemed"
        '''''''''            ColArr = Split(Colstr, "#")
        '''''''''            For i = 0 To 10
        '''''''''                Ipcol = New DataColumn
        '''''''''                Ipcol.ColumnName = ColArr(i)
        '''''''''                Ipdt.Columns.Add(Ipcol)
        '''''''''            Next i
        '''''''''            Dstp.HeaderStyle.ForeColor = Color.White

        '''''''''            m = 0
        '''''''''            j = 0
        '''''''''            k = 0
        '''''''''            x = 0
        '''''''''            Rowcounter = 0
        '''''''''            'Indexval = Split(ddbnmark.SelectedItem.Text, " # ")(1)
        '''''''''            Indexval = ddbnmark1.SelectedItem.Text
        '''''''''            Sqlcon = New SqlConnection(constr)
        '''''''''            Sqlcon.Open()
        '''''''''            strsql = "Select dateadd(d,276,[date]),(Nav_rs-53)/76 from nav_rec where sch_code='" & ddtrfrom.SelectedItem.Value & "' And dateadd(d,276,[date]) >='" & frdt & "' And dateadd(d,276,[date])<='" & todt & "' order by dateadd(d,276,[date])"
        '''''''''            Sqlcom = New SqlCommand(strsql, Sqlcon)
        '''''''''            Sqlrd = Sqlcom.ExecuteReader
        '''''''''            CalcDt = frdt
        '''''''''            If Sqlrd.Read Then
        '''''''''                chkdate = Sqlrd(0)
        '''''''''                Do
        '''''''''                    If Sqlrd(0) >= chkdate And chkdate <= todt Then
        '''''''''                        sqlcon3 = New SqlConnection(constr)
        '''''''''                        sqlcon3.Open()
        '''''''''                        strsqls = "Select dateadd(d,276,[date]),(Nav_rs-53)/76 from nav_rec where sch_code='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,[date]) ='" & Sqlrd(0) & "'"
        '''''''''                        Sqlcom = New SqlCommand(strsqls, sqlcon3)
        '''''''''                        sqlrd3 = Sqlcom.ExecuteReader
        '''''''''                        If sqlrd3.Read Then
        '''''''''                            TrueFlg = True
        '''''''''                            GoTo ContNext
        '''''''''                        Else
        '''''''''                            chkdate = DateAdd(DateInterval.Day, 1, chkdate)
        '''''''''                            TrueFlg = False
        '''''''''                        End If
        '''''''''                        sqlcon3.Close()
        '''''''''                        sqlcon3.Dispose()

        '''''''''                        If ddperiod.SelectedItem.Text <> "Fortnightly" Then
        '''''''''                            If Split(Sqlrd(0), "/")(1) <= STP_date Then
        '''''''''                                chkdate = CDate(Split(Sqlrd(0), "/")(0) & "/" & STP_date & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)

        '''''''''                                If ddperiod.SelectedItem.Text = "Monthly" Then
        '''''''''                                    If Day(chkdate) <= STP_date Then
        '''''''''                                        chkdate = DateAdd(DateInterval.Month, 1, chkdate)
        '''''''''                                    End If
        '''''''''                                End If
        '''''''''                                If ddperiod.SelectedItem.Text = "Quarterly" Then
        '''''''''                                    If Day(chkdate) <= STP_date Then
        '''''''''                                        chkdate = DateAdd(DateInterval.Month, 3, chkdate)
        '''''''''                                    End If
        '''''''''                                End If
        '''''''''                            Else
        '''''''''                                chkdate = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
        '''''''''                                Tempdtstr = Split(chkdate, "/")
        '''''''''                                chkdate = CDate(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
        '''''''''                            End If
        '''''''''                        Else
        '''''''''                            chkdate = DateAdd(DateInterval.Day, PrdVal, chkdate)
        '''''''''                        End If
        '''''''''                    End If
        '''''''''                    If TrueFlg = False Then
        '''''''''                        GoTo NextDate
        '''''''''                    End If
        '''''''''ContNext:
        '''''''''                    If j = 0 Then
        '''''''''                        Iprw = Ipdt.NewRow
        '''''''''                        Iprw(0) = Format(CDate(Sqlrd(0)), "dd-MMM-yyyy")
        '''''''''                        CalcDt = Sqlrd(0)
        '''''''''                        X1Date = Sqlrd(0)
        '''''''''                        ReDim Preserve DtArr(Rowcount)
        '''''''''                        DtArr(Rowcount) = Sqlrd(0)
        '''''''''                        Iprw(1) = Math.Round(Sqlrd(1), 4)
        '''''''''                        X1Nav = Sqlrd(1)
        '''''''''                        Iprw(2) = Math.Round(Amt / Sqlrd(1), 4)
        '''''''''                        X1units = (Math.Round(Amt / Sqlrd(1), 4)) * -1
        '''''''''                        If IsDBNull(Iprw(2)) = True Then
        '''''''''                            FinalUnts = 0
        '''''''''                        Else
        '''''''''                            FinalUnts = Iprw(2)
        '''''''''                        End If
        '''''''''                        TotUnits = TotUnits + FinalUnts
        '''''''''                        Iprw(3) = Math.Round(Amt / Sqlrd(1), 4)
        '''''''''                        ReDim Preserve Currval(Rowcount)
        '''''''''                        Currval(Rowcount) = Math.Round(Iprw(1) * Iprw(3), 2)
        '''''''''                        cuml_units = Iprw(3)
        '''''''''                        Iprw(5) = Amt * -1
        '''''''''                        ReDim Preserve CashFl(Rowcount)
        '''''''''                        CashFl(Rowcount) = Iprw(5)
        '''''''''                        CashInd = Iprw(5)
        '''''''''                        sqlcon1 = New SqlConnection(constr)
        '''''''''                        sqlcon1.Open()
        '''''''''                        strsql = "Select top 1 (ind_val-53)/76,dt1  from ind_rec where ind_code='" & Indexval & "' And dateadd(d,276,dt1)<='" & Sqlrd(0) & "' order by dt1 desc "
        '''''''''                        Sqlcom = New SqlCommand(strsql, sqlcon1)
        '''''''''                        sqlrd1 = Sqlcom.ExecuteReader
        '''''''''                        If sqlrd1.Read Then

        '''''''''                            ReDim Preserve IndexArr(m)
        '''''''''                            Iprw(7) = Math.Round(sqlrd1(0), 2)
        '''''''''                            currentIndex = sqlrd1(0)
        '''''''''                            IndUnits = Math.Round(Math.Round(Amt / sqlrd1(0), 4), 4)
        '''''''''                            Iprw(8) = Math.Round(currentIndex * IndUnits, 2)
        '''''''''                            IndexArr(m) = Iprw(8)
        '''''''''                            IniIndex = Iprw(7)
        '''''''''                            m += 1
        '''''''''                        End If
        '''''''''                        sqlcon1.Close()
        '''''''''                        sqlcon1.Dispose()
        '''''''''                        Ipdt.Rows.Add(Iprw)

        '''''''''                        If ddperiod.SelectedItem.Text <> "Fortnightly" Then
        '''''''''                            If Split(Sqlrd(0), "/")(1) < STP_date Then
        '''''''''                                CalcDt = CDate(Split(Sqlrd(0), "/")(0) & "/" & STP_date & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
        '''''''''                            Else
        '''''''''                                CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
        '''''''''                                Tempdtstr = Split(CalcDt, "/")
        '''''''''                                CalcDt = CDate(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
        '''''''''                            End If
        '''''''''                        Else
        '''''''''                            CalcDt = DateAdd(DateInterval.Day, PrdVal, CalcDt)
        '''''''''                        End If
        '''''''''                        ' stp_cashflw_grd1 = Math.Round(Iprw(1) * Iprw(3), 4)
        '''''''''                        Rowcount += 1
        '''''''''                        chkdate = CalcDt
        '''''''''                        TrueFlg = False
        '''''''''                        'NewFlg = False
        '''''''''                    ElseIf Sqlrd(0) >= CalcDt And CalcDt <= todt Then
        '''''''''                        Iprw = Ipdt.NewRow
        '''''''''                        Rowcounter += 1
        '''''''''                        Iprw(0) = Format(CDate(Sqlrd(0)), "dd-MMM-yyyy")
        '''''''''                        CalcDt = Sqlrd(0)
        '''''''''                        ReDim Preserve DtArr(Rowcount)
        '''''''''                        DtArr(Rowcount) = Sqlrd(0)
        '''''''''                        If cuml_units - Math.Round(CashFlow / Sqlrd(1), 4) > 0.0 Then
        '''''''''                            Iprw(1) = Math.Round(Sqlrd(1), 4)
        '''''''''                            If Temp <= Amt Then
        '''''''''                                If (Amt - Temp) < 0.0 Then
        '''''''''                                    Iprw(2) = Math.Round(CashFlow / Sqlrd(1), 4)
        '''''''''                                    'If j = 1 Then
        '''''''''                                    '    Iprw(2) = Ipdt.Rows(Rowcounter - 1).Item(2)
        '''''''''                                    'ElseIf IsDBNull(Ipdt.Rows(Rowcounter - 1).Item(9)) = False Then
        '''''''''                                    '    Iprw(2) = Math.Round(Ipdt.Rows(Rowcounter - 1).Item(2) - Ipdt.Rows(Rowcounter - 1).Item(9))
        '''''''''                                    'Else
        '''''''''                                    '    Iprw(2) = Math.Round(Ipdt.Rows(Rowcounter - 1).Item(2))
        '''''''''                                    'End If
        '''''''''                                    If IsDBNull(Iprw(2)) = True Then
        '''''''''                                        FinalUnts = 0
        '''''''''                                    Else
        '''''''''                                        FinalUnts = Iprw(2)
        '''''''''                                    End If
        '''''''''                                    Iprw(3) = cuml_units - Iprw(2)
        '''''''''                                    cuml_units = cuml_units - Iprw(2)
        '''''''''                                    ReDim Preserve Currval(Rowcount)
        '''''''''                                    Currval(Rowcount) = Math.Round(Iprw(1) * Iprw(3), 4)

        '''''''''                                    Iprw(5) = Math.Round((Amt - (Temp - CashFlow)), 4)
        '''''''''                                    ReDim Preserve CashFl(Rowcount)
        '''''''''                                    CashFl(Rowcount) = Iprw(5) - CashFlow

        '''''''''                                    sqlcon1 = New SqlConnection(constr)
        '''''''''                                    sqlcon1.Open()

        '''''''''                                    If rbindivd.Checked = True Then
        '''''''''                                        strsql = "Select sum((divid_pt-53)/76) from div_rec_adv where sch_code='" & ddtrfrom.SelectedItem.Value & "' And dateadd(d,276,date)>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And dateadd(d,276,date)<='" & fmt(Iprw(0)) & "'"
        '''''''''                                    ElseIf rbcorp.Checked = True Then
        '''''''''                                        strsql = "Select sum((divid_pt_corp-53)/76) from div_rec_adv where sch_code='" & ddtrfrom.SelectedItem.Value & "' And dateadd(d,276,date)>='" & fmt(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And dateadd(d,276,date)<='" & fmt(Iprw(0)) & "'"
        '''''''''                                    End If
        '''''''''                                    Sqlcom = New SqlCommand(strsql, sqlcon1)
        '''''''''                                    sqlrd1 = Sqlcom.ExecuteReader
        '''''''''                                    If sqlrd1.Read Then
        '''''''''                                        If IsDBNull(sqlrd1(0)) = False Then
        '''''''''                                            Iprw(6) = sqlrd1(0)
        '''''''''                                        Else
        '''''''''                                            Iprw(6) = 0
        '''''''''                                        End If
        '''''''''                                    End If
        '''''''''                                    sqlcon1.Close()
        '''''''''                                    sqlcon1.Dispose()
        '''''''''                                    sqlcon1 = New SqlConnection(constr)
        '''''''''                                    sqlcon1.Open()
        '''''''''                                    strsql = "Select top 1 (ind_val-53)/76,dt1 from ind_rec where ind_code='" & Indexval & "' And dateadd(d,276,dt1)<='" & Sqlrd(0) & "' order by dt1 desc"
        '''''''''                                    Sqlcom = New SqlCommand(strsql, sqlcon1)
        '''''''''                                    sqlrd1 = Sqlcom.ExecuteReader
        '''''''''                                    If sqlrd1.Read Then
        '''''''''                                        ReDim Preserve IndexArr(m)
        '''''''''                                        Iprw(7) = Math.Round(sqlrd1(0), 2)
        '''''''''                                        currentIndex = sqlrd1(0)
        '''''''''                                        IndUnits = IndUnits - Math.Round(Math.Round(Transfer_Amt / sqlrd1(0), 4), 4)
        '''''''''                                        Iprw(8) = Math.Round(currentIndex * IndUnits, 2)
        '''''''''                                        IndexArr(m) = Iprw(8)
        '''''''''                                        m += 1
        '''''''''                                        ''''TempNav = Math.Round(Math.Round(Amt / sqlrd1(0), 4), 4)
        '''''''''                                        ''''IndUnits = IndUnits + Math.Round(Math.Round(Amt / sqlrd1(0), 4), 4)
        '''''''''                                        ''''currentIndex = Math.Round(sqlrd1(0), 4)
        '''''''''                                    End If
        '''''''''                                    sqlcon1.Close()
        '''''''''                                    sqlcon1.Dispose()
        '''''''''                                    Iprw(9) = Math.Round(Iprw(4) - Iprw(5), 2)
        '''''''''                                    ReDim Preserve ValueAfter(x)
        '''''''''                                    ValueAfter(x) = Iprw(9)
        '''''''''                                    x += 1
        '''''''''                                    Iprw(10) = Math.Round(Iprw(5) / Iprw(1), 4)
        '''''''''                                    If IsDBNull(Iprw(9)) = True Then
        '''''''''                                        UntsRdmd = 0
        '''''''''                                    Else
        '''''''''                                        UntsRdmd = Iprw(9)
        '''''''''                                    End If
        '''''''''                                    ' Iprw(10) = = Math.Round(Iprw(9) / Iprw(1), 4)
        '''''''''                                Else
        '''''''''                                    If (Amt - Temp) <> 0.0 Then
        '''''''''                                        Iprw(2) = Math.Round(CashFlow / Sqlrd(1), 4)
        '''''''''                                        'If j = 1 Then
        '''''''''                                        '    Iprw(2) = Ipdt.Rows(Rowcounter - 1).Item(2)
        '''''''''                                        'ElseIf IsDBNull(Ipdt.Rows(Rowcounter - 1).Item(9)) = False Then
        '''''''''                                        '    Iprw(2) = Math.Round(Ipdt.Rows(Rowcounter - 1).Item(2) - Ipdt.Rows(Rowcounter - 1).Item(9))
        '''''''''                                        'Else
        '''''''''                                        '    Iprw(2) = (Ipdt.Rows(Rowcounter - 1).Item(2))
        '''''''''                                        'End If
        '''''''''                                        If IsDBNull(Iprw(2)) = True Then
        '''''''''                                            FinalUnts = 0
        '''''''''                                        Else
        '''''''''                                            FinalUnts = Iprw(2)
        '''''''''                                        End If
        '''''''''                                        TotUnits = TotUnits + FinalUnts
        '''''''''                                        Iprw(3) = cuml_units - Iprw(2)
        '''''''''                                        cuml_units = cuml_units - Iprw(2)
        '''''''''                                        Iprw(4) = Math.Round(Iprw(1) * Iprw(3), 2)
        '''''''''                                        ReDim Preserve Currval(Rowcount)
        '''''''''                                        Currval(Rowcount) = Math.Round(Iprw(1) * Iprw(3), 4)
        '''''''''                                        Iprw(5) = CashFlow
        '''''''''                                        ReDim Preserve CashFl(Rowcount)
        '''''''''                                        CashFl(Rowcount) = Iprw(5) - CashFlow

        '''''''''                                        sqlcon1 = New SqlConnection(constr)
        '''''''''                                        sqlcon1.Open()

        '''''''''                                        If rbindivd.Checked = True Then
        '''''''''                                            strsql = "Select sum((divid_pt -53)/76) from div_rec_adv where sch_code='" & ddtrfrom.SelectedItem.Value & "' And date >='" & Format(CDate(Ipdt.Rows(Rowcounter - 1).Item(0)), "MM/dd/yyyy") & "' And date<='" & Format(CDate(Iprw(0)), "MM/dd/yyyy") & "'"
        '''''''''                                        ElseIf rbcorp.Checked = True Then
        '''''''''                                            strsql = "Select sum((divid_pt_corp -53)/76) from div_rec_adv where sch_code='" & ddtrfrom.SelectedItem.Value & "' And date>='" & Format(CDate(Ipdt.Rows(Rowcounter - 1).Item(0)), "MM/dd/yyyy") & "' And date<='" & Format(CDate(Iprw(0)), "MM/dd/yyyy") & "'"
        '''''''''                                        End If
        '''''''''                                        Sqlcom = New SqlCommand(strsql, sqlcon1)
        '''''''''                                        sqlrd1 = Sqlcom.ExecuteReader
        '''''''''                                        If sqlrd1.Read Then
        '''''''''                                            If IsDBNull(sqlrd1(0)) = False Then
        '''''''''                                                Iprw(6) = sqlrd1(0)
        '''''''''                                            Else
        '''''''''                                                Iprw(6) = ""
        '''''''''                                            End If
        '''''''''                                        End If
        '''''''''                                        sqlcon1.Close()
        '''''''''                                        sqlcon1.Dispose()
        '''''''''                                        sqlcon1 = New SqlConnection(constr)
        '''''''''                                        sqlcon1.Open()
        '''''''''                                        strsql = "Select top 1 (ind_val-53)/76,dt1 from ind_rec where ind_code='" & Indexval & "' And dateadd(d,276,dt1)<='" & Sqlrd(0) & "' order by dt1 desc"
        '''''''''                                        Sqlcom = New SqlCommand(strsql, sqlcon1)
        '''''''''                                        sqlrd1 = Sqlcom.ExecuteReader
        '''''''''                                        If sqlrd1.Read Then
        '''''''''                                            ReDim Preserve IndexArr(m)
        '''''''''                                            Iprw(7) = Math.Round(sqlrd1(0), 2)
        '''''''''                                            currentIndex = sqlrd1(0)
        '''''''''                                            IndUnits = IndUnits - Math.Round(Math.Round(Transfer_Amt / sqlrd1(0), 4), 4)
        '''''''''                                            Iprw(8) = Math.Round(currentIndex * IndUnits, 2)
        '''''''''                                            IndexArr(m) = Iprw(8)
        '''''''''                                            m += 1
        '''''''''                                        End If
        '''''''''                                        sqlcon1.Close()
        '''''''''                                        sqlcon1.Dispose()
        '''''''''                                        Iprw(9) = Math.Round(Iprw(4) - Iprw(5), 2)
        '''''''''                                        ReDim Preserve ValueAfter(x)
        '''''''''                                        ValueAfter(x) = Iprw(9)
        '''''''''                                        x += 1
        '''''''''                                        Iprw(10) = Math.Round(Iprw(5) / Iprw(1), 4)
        '''''''''                                        If IsDBNull(Iprw(9)) = True Then
        '''''''''                                            UntsRdmd = 0
        '''''''''                                        Else
        '''''''''                                            UntsRdmd = Iprw(9)
        '''''''''                                        End If
        '''''''''                                        ' Iprw(10) = = Math.Round( Iprw(9)  / Iprw(1), 4)

        '''''''''                                        txtbal.Text = Math.Round(cuml_units * Iprw(1), 2)
        '''''''''                                        dg1_last_date = CStr(Iprw(0))
        '''''''''                                    End If
        '''''''''                                End If
        '''''''''                                Temp = Temp + CashFlow
        '''''''''                                'stp_cashflw_grd1 = Math.Round(CDbl(Iprw(1)) * CDbl(Iprw(3)), 4)
        '''''''''                            End If
        '''''''''                        Else
        '''''''''                            ReDim Preserve CashFl(Rowcount)
        '''''''''                            CashFl(Rowcount) = 0
        '''''''''                        End If

        '''''''''                        Ipdt.Rows.Add(Iprw)
        '''''''''                        If ddperiod.SelectedItem.Text <> "Fortnightly" Then
        '''''''''                            If Split(Sqlrd(0), "/")(1) < STP_date Then
        '''''''''                                CalcDt = CDate(Split(Sqlrd(0), "/")(0) & "/" & STP_date & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
        '''''''''                            Else
        '''''''''                                CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
        '''''''''                                Tempdtstr = Split(CalcDt, "/")
        '''''''''                                CalcDt = CDate(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
        '''''''''                            End If
        '''''''''                        Else
        '''''''''                            CalcDt = DateAdd(DateInterval.Day, PrdVal, CalcDt)
        '''''''''                        End If
        '''''''''                        Rowcount += 1
        '''''''''                        chkdate = CalcDt
        '''''''''                        TrueFlg = False
        '''''''''                        'NewFlg = False
        '''''''''                    End If
        '''''''''                    j += 1
        '''''''''NextDate:
        '''''''''                Loop While Sqlrd.Read

        '''''''''            Else
        '''''''''                Exit Sub
        '''''''''            End If

        '''''''''            Sqlcon.Close()
        '''''''''            Sqlcon.Dispose()

        '''''''''            Sqlcon = New SqlConnection(constr)
        '''''''''            Sqlcon.Open()
        '''''''''            'strsql = "Select rmf_todt,rmf_nav from nav_reg where rmf_scheme='" & scheme_code_from & "' and rmf_plan='" & plan_code_from & "' And rmf_todt<'" & Valdt & "' order by rmf_todt"
        '''''''''            strsql = "Select (nav_rs-53)/76,dateadd(d,276,[date]) from nav_rec where sch_code='" & ddtrfrom.SelectedItem.Value & "' And dateadd(d,276,[date])>='" & fmt(txtvalue.Text) & "' order by dateadd(d,276,[date])"
        '''''''''            Sqlcom = New SqlCommand(strsql, Sqlcon)
        '''''''''            Sqlrd = Sqlcom.ExecuteReader
        '''''''''            If Sqlrd.Read Then
        '''''''''                ''Iprw = Ipdt.NewRow
        '''''''''                ''ReDim Preserve DtArr(Rowcount)
        '''''''''                ''ReDim Preserve CashFl(Rowcount)
        '''''''''                ''Do
        '''''''''                ''    Iprw(0) = Format(CDate(Sqlrd(0)), "dd-MMM-yyyy")
        '''''''''                ''    'Iprw(1) = Math.Round(Sqlrd(1) + (Sqlrd(1) * Val(txtSIP_EntryLoad.Text) / 100), 4)
        '''''''''                ''Loop While Sqlrd.Read
        '''''''''                ''DtArr(Rowcount) = Format(CDate(Iprw(0)), "MM/dd/yyyy")
        '''''''''                ''CashFl(Rowcount) = 0
        '''''''''                '''Iprw(2) = Math.Round(cuml_units, 4)
        '''''''''                '''Iprw(3) = Math.Round(Iprw(1) * Iprw(2), 2)
        '''''''''                ''Ipdt.Rows.Add(Iprw)
        '''''''''                ''Rowcount += 1
        '''''''''                Do
        '''''''''                    If IsDBNull(Sqlrd(0)) = False Then
        '''''''''                        Iprw = Ipdt.NewRow
        '''''''''                        Iprw(0) = Format(CDate(Sqlrd(1)), "dd-MMM-yyyy")
        '''''''''                        X2Date = Sqlrd(1)
        '''''''''                        Iprw(1) = Sqlrd(0)
        '''''''''                        X2Nav = Sqlrd(0)
        '''''''''                        'TotUnits = Math.Round(TotUnits * sqlrd1(0), 4)

        '''''''''                        ''''If (FinalUnts - UntsRdmd) < 0 Then
        '''''''''                        ''''    'Iprw(2) = Math.Round(Sqlrd(0) * cuml_units, 4)
        '''''''''                        ''''Else
        '''''''''                        ''''    Iprw(2) = Math.Round(FinalUnts - UntsRdmd, 4)
        '''''''''                        ''''End If

        '''''''''                        'Iprw(3) = Math.Round(Val(UBound(Currval)) / Sqlrd(0), 2)
        '''''''''                        Iprw(3) = Math.Round(cuml_units, 2)
        '''''''''                        Iprw(4) = Math.Round(Iprw(3) * Sqlrd(0), 4)
        '''''''''                        Temp = Iprw(4)
        '''''''''                        'txtbal.Text = Iprw(4)
        '''''''''                        txtbal.Text = Math.Round(cuml_units * Iprw(1), 2)
        '''''''''                        dt_as_on_1 = Iprw(0)
        '''''''''                        Ipdt.Rows.Add(Iprw)
        '''''''''                        Exit Do
        '''''''''                    End If
        '''''''''                Loop While Sqlrd.Read
        '''''''''            End If
        '''''''''            Dim dtFrom As DataTable
        '''''''''            dtFrom = Ipdt.Copy
        '''''''''            Session("SIP") = Ipdt
        '''''''''            Session("S1") = Ipdt
        '''''''''            Dstp.DataSource = Ipdt
        '''''''''            Dstp.DataBind()
        '''''''''            Dstp.Visible = True


        '''''''''            '''''--------------GRID TWO-----------------------------
        '''''''''            '''''--------------GRID TWO-----------------------------
        '''''''''            Ipdt = New DataTable
        '''''''''            Rowcounter = 0
        '''''''''            Rowcount = 0
        '''''''''            ReDim Currval(0)

        '''''''''            'Colstr = "Date#NAV#Units#Cumulative Units"
        '''''''''            Colstr = "Date#NAV#Units#Cumulative Units#Dividend#Current Value#Investment In Index#Cumulative Amount#Value Of Investments"
        '''''''''            ColArr = Split(Colstr, "#")
        '''''''''            For i = 0 To 8
        '''''''''                Ipcol = New DataColumn
        '''''''''                Ipcol.ColumnName = ColArr(i)
        '''''''''                Ipdt.Columns.Add(Ipcol)
        '''''''''            Next i
        '''''''''            j = 0
        '''''''''            m = 0
        '''''''''            x = 0
        '''''''''            TotUnits = 0
        '''''''''            CalcDt = frdt
        '''''''''            Dstp1.HeaderStyle.ForeColor = Color.White
        '''''''''            Sqlcon = New SqlConnection(constr)
        '''''''''            Sqlcon.Open()
        '''''''''            strsql = "Select dateadd(d,276,date),(nav_rs-53)/76 from nav_rec where sch_code='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,[date]) >='" & frdt & "' And date<='" & todt & "' order by dateadd(d,276,[date])"
        '''''''''            Sqlcom = New SqlCommand(strsql, Sqlcon)
        '''''''''            Sqlrd = Sqlcom.ExecuteReader
        '''''''''            CalcDt = frdt
        '''''''''            If ddperiod.SelectedItem.Text <> "Fortnightly" Then
        '''''''''                CalcDt = DateAdd(DateInterval.Month, PrdVal, CalcDt)
        '''''''''                Tempdtstr = Split(CalcDt, "/")
        '''''''''                CalcDt = CDate(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
        '''''''''            Else
        '''''''''                CalcDt = DateAdd(DateInterval.Day, PrdVal, CalcDt)
        '''''''''            End If
        '''''''''            If Sqlrd.Read Then
        '''''''''                Do
        '''''''''                    If j = 0 And Sqlrd(0) >= CalcDt And CalcDt <= todt Then
        '''''''''                        Iprw = Ipdt.NewRow
        '''''''''                        Iprw(0) = Format(CDate(Sqlrd(0)), "dd/MM/yyyy")
        '''''''''                        CalcDt = Sqlrd(0)
        '''''''''                        Iprw(5) = Amt
        '''''''''                        Iprw(6) = Amt
        '''''''''                        Ipdt.Rows.Add(Iprw)
        '''''''''                        CumUnts = 0
        '''''''''                        m += 1
        '''''''''                        Iprw = Ipdt.NewRow
        '''''''''                        Rowcounter += 1
        '''''''''                        Iprw(0) = Format(CDate(Sqlrd(0)), "dd-MMM-yyyy")
        '''''''''                        ReDim Preserve DtArr(Rowcount)
        '''''''''                        DtArr(Rowcount) = Sqlrd(0)
        '''''''''                        Iprw(1) = Math.Round(Sqlrd(1), 4)
        '''''''''                        Iprw(2) = Math.Round(CashFlow / Sqlrd(1), 4)
        '''''''''                        TotUnits = TotUnits + Iprw(2)
        '''''''''                        NewUnts = Math.Round(CashFlow / Sqlrd(1), 4)
        '''''''''                        Iprw(3) = CumUnts + NewUnts
        '''''''''                        CumUnts = CumUnts + NewUnts
        '''''''''                        sqlcon1 = New SqlConnection(constr)
        '''''''''                        sqlcon1.Open()
        '''''''''                        If rbindivd.Checked Then
        '''''''''                            strsql = "Select sum((divid_pt-53)/76) from div_rec_adv where sch_code='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date)>='" & Format(CDate(Ipdt.Rows(Rowcounter - 1).Item(0)), "MM/dd/yyyy") & "' And dateadd(d,276,date)<='" & Format(CDate(Iprw(0)), "MM/dd/yyyy") & "'"
        '''''''''                        ElseIf rbcorp.Checked = True Then
        '''''''''                            strsql = "Select sum((divid_pt_corp-53)/76) from div_rec_adv where sch_code='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date)>='" & Format(CDate(Ipdt.Rows(Rowcounter - 1).Item(0)), "MM/dd/yyyy") & "' And dateadd(d,276,date)<='" & Format(CDate(Iprw(0)), "MM/dd/yyyy") & "'"
        '''''''''                        End If
        '''''''''                        Sqlcom = New SqlCommand(strsql, sqlcon1)
        '''''''''                        sqlrd1 = Sqlcom.ExecuteReader
        '''''''''                        If sqlrd1.Read Then
        '''''''''                            If IsDBNull(sqlrd1(0)) = False Then
        '''''''''                                Iprw(4) = sqlrd1(0)
        '''''''''                            Else
        '''''''''                                Iprw(4) = 0
        '''''''''                            End If
        '''''''''                        End If
        '''''''''                        sqlcon1.Close()
        '''''''''                        sqlcon1.Dispose()
        '''''''''                        Iprw(5) = Math.Round(CumUnts * Sqlrd(1), 2)

        '''''''''                        Ipdt.Rows.Add(Iprw)
        '''''''''                        If ddperiod.SelectedItem.Text <> "Fortnightly" Then
        '''''''''                            If Split(Sqlrd(0), "/")(1) < STP_date Then
        '''''''''                                CalcDt = CDate(Split(Sqlrd(0), "/")(0) & "/" & STP_date & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
        '''''''''                            Else
        '''''''''                                CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
        '''''''''                                Tempdtstr = Split(CalcDt, "/")
        '''''''''                                CalcDt = CDate(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
        '''''''''                            End If
        '''''''''                        Else
        '''''''''                            CalcDt = DateAdd(DateInterval.Day, PrdVal, CalcDt)
        '''''''''                        End If
        '''''''''                        stp_cashflw_grd2 = Iprw(1) * Iprw(3)
        '''''''''                        If m <= UBound(IndexArr) Then
        '''''''''                            Iprw(6) = Math.Round(((CashFlow * IndexArr(m)) / IniIndex), 2)
        '''''''''                        End If
        '''''''''                        Iprw(7) = Iprw(5)
        '''''''''                        If IsNothing(ValueAfter) = False Then
        '''''''''                            If x <= UBound(ValueAfter) Then
        '''''''''                                Iprw(8) = Math.Round(Iprw(7) + ValueAfter(x), 2)
        '''''''''                                x += 1
        '''''''''                            End If
        '''''''''                            Currval(Rowcount) = Iprw(8)
        '''''''''                            ReDim Preserve Currval(Rowcount)
        '''''''''                        End If
        '''''''''                        Rowcount += 1
        '''''''''                        m += 1
        '''''''''                        j += 1
        '''''''''                    ElseIf Sqlrd(0) >= CalcDt And CalcDt <= todt Then
        '''''''''                        If Sqlrd(0) <= CDate(dg1_last_date) Then
        '''''''''                            Iprw = Ipdt.NewRow
        '''''''''                            Rowcounter += 1
        '''''''''                            Iprw(0) = Format(CDate(Sqlrd(0)), "dd-MMM-yyyy")
        '''''''''                            CalcDt = Sqlrd(0)
        '''''''''                            ReDim Preserve DtArr(Rowcount)
        '''''''''                            If IsDBNull(Iprw(0)) = False Then
        '''''''''                                DtArr(Rowcount) = Sqlrd(0)
        '''''''''                            End If

        '''''''''                            Iprw(1) = Math.Round(Sqlrd(1), 4)
        '''''''''                            If m <= UBound(IndexArr) Then
        '''''''''                                Iprw(2) = Math.Round(CashFlow / Sqlrd(1), 4)
        '''''''''                                TotUnits = TotUnits + Iprw(2)
        '''''''''                                NewUnts = Math.Round(CashFlow / Sqlrd(1), 4)
        '''''''''                                Iprw(3) = CumUnts + NewUnts
        '''''''''                                CumUnts = CumUnts + NewUnts

        '''''''''                                sqlcon1 = New SqlConnection(constr)
        '''''''''                                sqlcon1.Open()
        '''''''''                                If rbindivd.Checked Then
        '''''''''                                    strsql = "Select sum((divid_pt-53)/76) from div_rec_adv where sch_code='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date)>='" & Format(CDate(Ipdt.Rows(Rowcounter - 1).Item(0)), "MM/dd/yyyy") & "' And dateadd(d,276,date)<='" & Format(CDate(Iprw(0)), "MM/dd/yyyy") & "'"
        '''''''''                                ElseIf rbcorp.Checked = True Then
        '''''''''                                    strsql = "Select sum((divid_pt_corp-53)/76) from div_rec_adv where sch_code='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date)>='" & Format(CDate(Ipdt.Rows(Rowcounter - 1).Item(0)), "MM/dd/yyyy") & "' And dateadd(d,276,date)<='" & Format(CDate(Iprw(0)), "MM/dd/yyyy") & "'"
        '''''''''                                End If
        '''''''''                                Sqlcom = New SqlCommand(strsql, sqlcon1)
        '''''''''                                sqlrd1 = Sqlcom.ExecuteReader
        '''''''''                                If sqlrd1.Read Then
        '''''''''                                    If IsDBNull(sqlrd1(0)) = False Then
        '''''''''                                        Iprw(4) = sqlrd1(0)
        '''''''''                                    Else
        '''''''''                                        Iprw(4) = 0
        '''''''''                                    End If
        '''''''''                                End If
        '''''''''                                sqlcon1.Close()
        '''''''''                                sqlcon1.Dispose()
        '''''''''                                Iprw(5) = Math.Round(CumUnts * Sqlrd(1), 2)
        '''''''''                                Iprw(6) = Math.Round(((CashFlow * IndexArr(m)) / IniIndex), 2)
        '''''''''                                Iprw(7) = Iprw(5)
        '''''''''                                If x <= UBound(ValueAfter) Then
        '''''''''                                    Iprw(8) = Math.Round(Iprw(7) + ValueAfter(x), 2)
        '''''''''                                    x += 1
        '''''''''                                End If
        '''''''''                                ReDim Preserve Currval(Rowcount)
        '''''''''                                Currval(Rowcount) = Iprw(8)
        '''''''''                                txtacc.Text = Math.Round(Iprw(3) * Iprw(1), 2)
        '''''''''                            End If
        '''''''''                            If ddperiod.SelectedItem.Text <> "Fortnightly" Then
        '''''''''                                If Split(Sqlrd(0), "/")(1) < STP_date Then
        '''''''''                                    CalcDt = CDate(Split(Sqlrd(0), "/")(0) & "/" & STP_date & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
        '''''''''                                Else
        '''''''''                                    CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
        '''''''''                                    Tempdtstr = Split(CalcDt, "/")
        '''''''''                                    CalcDt = CDate(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
        '''''''''                                End If
        '''''''''                            Else
        '''''''''                                CalcDt = DateAdd(DateInterval.Day, PrdVal, CalcDt)
        '''''''''                            End If

        '''''''''                            Ipdt.Rows.Add(Iprw)
        '''''''''                            m += 1
        '''''''''                            Rowcount += 1
        '''''''''                        End If
        '''''''''                        'stp_cashflw_grd2 = Math.Round(CDbl(Iprw(1)) * CDbl(Iprw(3)), 4)
        '''''''''                    End If

        '''''''''                Loop While Sqlrd.Read
        '''''''''            End If
        '''''''''            Sqlcon.Close()
        '''''''''            Sqlcon.Dispose()

        '''''''''            strsql = ""
        '''''''''            strsql = "Select (nav_rs-53)/76,dateadd(d,276,date) from nav_rec where sch_code ='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date)>='" & CDate(cdates(txtvalue.Text)) & "' order by dateadd(d,276,date)"
        '''''''''            sqlcon1 = New SqlConnection(constr)
        '''''''''            sqlcon1.Open()
        '''''''''            Sqlcom = New SqlCommand(strsql, sqlcon1)
        '''''''''            sqlrd1 = Sqlcom.ExecuteReader
        '''''''''            If sqlrd1.Read Then
        '''''''''                Do
        '''''''''                    If IsDBNull(sqlrd1(0)) = False Then
        '''''''''                        Iprw = Ipdt.NewRow
        '''''''''                        Iprw(0) = Format(CDate(sqlrd1(1)), "dd-MMM-yyyy")
        '''''''''                        Iprw(1) = sqlrd1(0)
        '''''''''                        Iprw(3) = CumUnts
        '''''''''                        txtacc.Text = Math.Round(CumUnts * Iprw(1), 2)
        '''''''''                        Ipdt.Rows.Add(Iprw)
        '''''''''                        dt_as_on_2 = Iprw(0)
        '''''''''                        Exit Do
        '''''''''                    End If
        '''''''''                Loop While sqlrd1.Read

        '''''''''            End If

        '''''''''            '''''''''''XIRRSSSSSSS CALCULATION''''''''''''''''''''''
        '''''''''            Dim Dt As String = ""
        '''''''''            Dim cashflw As String = ""
        '''''''''            Dim cashindx As String = ""

        '''''''''            ReDim Preserve CashFl(Rowcount - 1)
        '''''''''            CashFl(Rowcount - 1) = stp_cashflw_grd1 + stp_cashflw_grd2

        '''''''''            ReDim Preserve IndexArr(Rowcount - 1)
        '''''''''            'If Rowcount <> 0 Then
        '''''''''            IndexArr(Rowcount - 1) = stp_cashflw_grd1 + stp_cashflw_grd2
        '''''''''            'End If

        '''''''''            If IsNothing(DtArr) = False Then
        '''''''''                For i = 0 To UBound(DtArr)
        '''''''''                    If Dt = "" Then
        '''''''''                        Dt = Format(DtArr(i), "dd/MM/yyyy")
        '''''''''                    Else
        '''''''''                        If CashFl(i) <> 0 Then
        '''''''''                            Dt = Dt & "," & Format(DtArr(i), "dd/MM/yyyy")
        '''''''''                        End If
        '''''''''                    End If
        '''''''''                Next i
        '''''''''            End If
        '''''''''            If IsNothing(CashFl) = False Then
        '''''''''                For i = 0 To UBound(CashFl)
        '''''''''                    If cashflw = "" Then
        '''''''''                        cashflw = CashFl(i)
        '''''''''                    Else
        '''''''''                        If CashFl(i) <> 0 Then
        '''''''''                            cashflw = cashflw & "," & CashFl(i)
        '''''''''                        End If
        '''''''''                    End If
        '''''''''                Next i
        '''''''''            End If

        '''''''''            If IsNothing(IndexArr) = False Then
        '''''''''                For i = 0 To UBound(IndexArr)
        '''''''''                    If cashindx = "" Then
        '''''''''                        cashindx = IndexArr(i)
        '''''''''                    Else
        '''''''''                        If CashFl(i) <> 0 Then
        '''''''''                            cashindx = cashindx & "," & IndexArr(i)
        '''''''''                        End If
        '''''''''                    End If
        '''''''''                Next i
        '''''''''            End If
        '''''''''            '//or xirr consider first from date
        '''''''''            DtArr(0) = frdt

        '''''''''            Dt = cdates(CDate(DtArr(0))) & "," & cdates(CDate(dt_as_on_1))
        '''''''''            cashflw = CashFl(0) & "," & Val((Val(txtacc.Text) + Val(txtbal.Text)))
        '''''''''            getXirr = XIRR(Dt, cashflw)
        '''''''''            txtyield.Text = Math.Round(getXirr, 2)
        '''''''''            getXirr = XIRR(Dt, cashindx)
        '''''''''            txtyldinv.Text = Math.Round(getXirr, 2)
        '''''''''            'Dt = ""
        '''''''''            'cashflw = ""
        '''''''''            'Dt = X1Date & "," & X2Date
        '''''''''            'cashflw = (X1Nav * X1units) & "," & (X2Nav * X1units) * -1
        '''''''''            'cashflw = CStr(stp_cashflw_grd1 + stp_cashflw_grd2)
        '''''''''            'getXirr = XIRR(Dt, cashflw)
        '''''''''            'txtyldinv.Text = Math.Round(getXirr, 2)
        '''''''''            'txtyield.Text = Math.Round(getXirr, 2)
        '''''''''            'noxi:
        '''''''''            Session("S2") = Ipdt
        '''''''''            Session("SFROM") = ddtrfrom.SelectedItem.Text
        '''''''''            Session("STO") = ddtrto.SelectedItem.Text
        '''''''''            Dstp1.DataSource = Ipdt
        '''''''''            Dstp1.DataBind()
        '''''''''            Dstp1.Visible = True
        '''''''''            '//charting vishal
        '''''''''            tblChart.Visible = False
        '''''''''            HttpContext.Current.Session("STP_Chart_Image") = ""
        '''''''''            If chkChart_STP.Checked = True Then
        '''''''''                Dim datatbl_stp As DataTable
        '''''''''                ''Call formatTable4Chart(datatbl_stp, True, 1, 0, True, , "Nav,Units,CashFlow,CashFlow(Index),Index", "Amount,SWP Value,Index Value")
        '''''''''                '//create table for STP chart and fill date
        '''''''''                datatbl_stp = getDataTable4STP_chart(dtFrom, Ipdt.Copy)
        '''''''''                Session("ChartData_SIP") = datatbl_stp
        '''''''''                Call drawChart(sipChart, datatbl_stp, "STP", CDbl(txttranamt.Text))
        '''''''''                tblChart.Visible = True
        '''''''''            End If
        '''''''''            'cmdexp1.Attributes.Add("onClick", "javascript:newexports('Dstp','Dstp1',1,'" & txtbal.Text & "','" & txtacc.Text & "','" & txtyield.Text & "','" & txtyldinv.Text & "','" & ddtrfrom.SelectedItem.Text & "','" & ddtrto.SelectedItem.Text & "');return false;")
        '''''''''            'cmdexp1.Attributes.Add("onClick", "javascript:newexports('Dstp','Dstp1',1,'" & txtbal.Text & "','" & txtacc.Text & "','" & txtyield.Text & "',' ','" & ddtrfrom.SelectedItem.Text & "','" & ddtrto.SelectedItem.Text & "');return false;")
        '''''''''        Catch ex As Exception

        '''''''''        End Try
#End Region

    End Sub

    ''Private Sub cmdSIP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Private Overloads Sub cmdSIP_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdSIP.Click

        Dim frdt As Date
        Dim todt As Date
        Dim FNav As Double = 0
        Dim LNav As Double = 0
        Dim Valdt As Date
        Dim CalcDt As Date
        Dim TempDt As Date
        Dim ColArr() As String
        Dim Colstr As String
        Dim Amt As Double = 0
        Dim Temp As Double = 0
        Dim TempUnits As Double = 0
        Dim IndUnits As Double = 0
        Dim TempNav As Double = 0
        Dim currentIndex As Double = 0
        Dim j As Integer = 0
        Dim k As Integer = 0
        Dim m As Integer = 0
        Dim Arrcount As Integer = 0
        Dim DivDt() As Date
        Dim DivArr() As Double
        Dim BonDt() As Date
        Dim BonArr() As String
        Dim NewNav As Double
        Dim PerUnitDiv As Double = 0
        Dim DtArr() As Date
        Dim CashFl() As Double
        Dim CashFlInd() As Double
        Dim TotNav As Double = 0

        Dim Pre_Nav As Double = 0
        Dim PrdVal As Integer = 0
        Dim strdt(2) As String
        Dim Tempdtstr(2) As String
        Dim FDate As Date
        Dim LDate As Date
        Dim benchmark As String
        Dim cuml_units As Double
        Dim sip_amt As Double
        Dim Entry_Load As Double


        cmdSIP.Attributes.Add("onclick", "javascript:return validate_SIP();")

        Try
            cuml_units = 0
            sip_amt = 0.0

            If ddPlan.SelectedItem.Text = "--" Then
                Response.Write("<script>alert(""Please Select Plan.."")</script>")
                Exit Sub
            End If
            If ddscheme.SelectedItem.Text = "--" Then
                Response.Write("<script>alert(""Please Select Scheme.."")</script>")
                Exit Sub
            End If

            If ddlsipbnmark.SelectedItem.Text = "--" Then
                ''txtMess.Value = "Please Select Any BenchMark.."
                Response.Write("<script>alert(""Please Select BenchMark Index "")</script>")
                Exit Sub
            Else
                'benchmark = Split(ddlsipbnmark.SelectedItem.Text, " # ")
                benchmark = ddlsipbnmark1.SelectedItem.Text
            End If


            If ddPeriod_SIP.SelectedItem.Text = "--" Then
                'txtMess.Value = "Please Select Any Periodicity.."
                Response.Write("<script>alert(""Please Select Periodicity.."")</script>")
                Exit Sub
            End If

            If Val(txtinstall.Text) = 0 Then
                Response.Write("<script>alert(""Installment Amount Cannot Be Blank."")</script>")
                Exit Sub
            End If

            If (Val(txtinstall.Text) Mod 1) > 0 Then
                Response.Write("<script>alert(""Installment amount cannot be fractional."")</script>")
                Exit Sub
            End If

            For i = 1 To Len(txtfromDate.Text)
                If Mid(Trim(txtfromDate.Text), i, 1) = "/" Then
                    k += 1
                End If
            Next i
            If k <> 2 Then
                Response.Write("<script>alert(""Please Enter From Date in proper format.."")</script>")
                Exit Sub
            End If
            i = 0
            k = 0

            For i = 1 To Len(txtTdate.Text)
                If Mid(Trim(txtTdate.Text), i, 1) = "/" Then
                    k += 1
                End If
            Next i
            If k <> 2 Then
                Response.Write("<script>alert(""Please Enter To Date in proper format.."")</script>")
                Exit Sub
            End If
            i = 0
            k = 0

            For i = 1 To Len(txtvalason.Text)
                If Mid(Trim(txtvalason.Text), i, 1) = "/" Then
                    k += 1
                End If
            Next i
            If k <> 2 Then
                Response.Write("<script>alert(""Please Value as on Date in proper format.."")</script>")
                Exit Sub
            End If
            i = 0
            k = 0

            If IsDate(fmt(Trim(txtfromDate.Text))) = False Or IsDate(fmt(Trim(txtTdate.Text))) = False Or IsDate(fmt(Trim(txtvalason.Text))) = False Then
                Response.Write("<script>alert(""Please Enter The Dates in Proper Formats (dd/mm/yyyy).."")</script>")
                Exit Sub
            End If

            todt = txtTdate.Text.Replace("/", "-")
            frdt = txtfromDate.Text.Replace("/", "-")
            Valdt = txtvalason.Text.Replace("/", "-")
            ''commented on 28 oct 14
            'todt = Split(Trim(txtTdate.Text), "/")(1) & "/" & Split(Trim(txtTdate.Text), "/")(0) & "/" & Split(Trim(txtTdate.Text), "/")(2)
            'frdt = Split(Trim(txtfromDate.Text), "/")(1) & "/" & Split(Trim(txtfromDate.Text), "/")(0) & "/" & Split(Trim(txtfromDate.Text), "/")(2)
            'Valdt = Split(Trim(txtvalason.Text), "/")(1) & "/" & Split(Trim(txtvalason.Text), "/")(0) & "/" & Split(Trim(txtvalason.Text), "/")(2)
            ''end 
            If IsDate(frdt) = False Or IsDate(todt) = False Or IsDate(Valdt) = False Then
                Response.Write("<script>alert(""Please Enter The Dates in Proper Formats (dd/mm/yyyy).."")</script>")
                Exit Sub
            End If

            If frdt >= DateTime.Today Or todt >= DateTime.Today Or Valdt >= DateTime.Today Then
                Response.Write("<script>alert(""Date should be less than today"")</script>")
                Exit Sub
            End If

            If CDate(todt) <= frdt Then
                Response.Write("<script>alert(""From Date Should be less than To Date.."")</script>")
                Exit Sub
            End If
            If CDate(Valdt) < todt Then
                Response.Write("<script>alert(""To Date cannot be Greater than Value as on Date.."")</script>")
                Exit Sub
            End If

            'If ddPeriod_SIP.SelectedItem.Text = "Fortnightly" Then
            'PrdVal = 15
            If ddPeriod_SIP.SelectedItem.Text = "Monthly" Then
                PrdVal = 1
            ElseIf ddPeriod_SIP.SelectedItem.Text = "Quarterly" Then
                PrdVal = 3


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''' added for daily
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'ElseIf ddPeriod_SIP.SelectedItem.Text = "Daily" Then
                '    PrdVal = 1
            End If
            ' **********  Manish  *********



            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''' entry load is to be removed as per client request 30Jul2010
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'If CDbl(txtinstall.Text) < 20000000 Then
            '    Entry_Load = 2.25
            'ElseIf CDbl(txtinstall.Text) >= 20000000 And CDbl(txtinstall.Text) <= 50000000 Then
            '    Entry_Load = 1.25
            'ElseIf CDbl(txtinstall.Text) > 50000000 Then
            '    Entry_Load = 0
            'End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''' entry load is to be removed as per client request 30Jul2010
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            Entry_Load = 0

            Session("Entry_Load1") = Entry_Load
            '  *******     END      *****
            Dim datediffVal As Integer
            If ddPeriod_SIP.SelectedItem.Text = "Quarterly" Then
                If Val(txtinstall.Text) <= 1500 And Val(txtinstall.Text) > 500 Then
                    datediffVal = DateDiff(DateInterval.Quarter, frdt, todt)
                    If datediffVal < 4 Then
                        Response.Write("<script>alert(""Minimum Period of Investment should be 4 Quarters."")</script>")
                        Exit Sub
                    End If
                ElseIf Val(txtinstall.Text) = 500 Then

                    datediffVal = DateDiff(DateInterval.Quarter, frdt, todt)
                    If datediffVal < 12 Then
                        Response.Write("<script>alert(""Minimum Period of Investment should be 12 Quarters."")</script>")
                        Exit Sub
                    End If
                End If
            ElseIf ddPeriod_SIP.SelectedItem.Text = "Monthly" Then
                If Val(txtinstall.Text) = 100 Then
                    datediffVal = DateDiff(DateInterval.Month, frdt, todt)
                    If datediffVal < 60 Then
                        Response.Write("<script>alert(""Minimum Period of Investment should be 60 Months."")</script>")
                        Exit Sub
                    End If
                ElseIf Val(txtinstall.Text) = 500 Then
                    datediffVal = DateDiff(DateInterval.Month, frdt, todt)
                    If datediffVal < 12 Then
                        Response.Write("<script>alert(""Minimum Period of Investment should be 12 Months."")</script>")
                        Exit Sub
                    End If
                ElseIf Val(txtinstall.Text) = 1000 Then
                    datediffVal = DateDiff(DateInterval.Month, frdt, todt)
                    If datediffVal < 6 Then
                        Response.Write("<script>alert(""Minimum Period of Investment should be 6 Months."")</script>")
                        Exit Sub
                    End If
                End If
            End If


            If ddPeriod_SIP.SelectedItem.Text = "Monthly" Then
                If Val(txtinstall.Text) < 100 Then
                    Response.Write("<script>alert(""Installment Amount Can't Be Less Then 100/- Rs. .."")</script>")
                    Exit Sub
                End If
            End If


            Dim SIP_date As Integer
            ''change  30062017
            SIP_date = ddSIPdate.SelectedItem.Value
            'If ddSIPdate.SelectedItem.Text = "02nd" Then
            '    SIP_date = 2
            'ElseIf ddSIPdate.SelectedItem.Text = "07th" Then
            '    SIP_date = 7
            'ElseIf ddSIPdate.SelectedItem.Text = "10th" Then
            '    SIP_date = 10
            'ElseIf ddSIPdate.SelectedItem.Text = "18th" Then
            '    SIP_date = 18
            'ElseIf ddSIPdate.SelectedItem.Text = "23rd" Then
            '    SIP_date = 23
            'ElseIf ddSIPdate.SelectedItem.Text = "28th" Then
            '    SIP_date = 28
            'End If

            tblSIP1.Visible = True

            'ind_code = ddlsipbnmark.SelectedItem.Text
            'ind_code1 = Split(ind_code, "#")

            Amt = Trim(txtinstall.Text)
            Temp = Amt

            ''Colstr = "Date#NAV#Units#CashFlow#Amount#SIP Value"
            Colstr = "Date#NAV#Units#CashFlow(scheme)#CashFlow(Index)#Amount#SIP Value#Index#Index Value"
            ColArr = Split(Colstr, "#")
            For i = 0 To 8
                Ipcol = New DataColumn
                Ipcol.ColumnName = ColArr(i)
                Ipdt.Columns.Add(Ipcol)
            Next i


            Gsp.HeaderStyle.ForeColor = Color.White

            strsql = "Select dateadd(d,276,date),(divid_pt-53)/76,(dividend-53)/76 from div_rec_adv where sch_code='" & ddscheme.SelectedItem.Value & "' And dateadd(d,276,date)>='" & frdt.ToString("dd MMM yyyy") & "' And dateadd(d,276,date)<='" & todt.ToString("dd MMM yyyy") & "' order by dateadd(d,276,date)"
            ''commented on 28 oct 14
            'strsql = "Select dateadd(d,276,date),(divid_pt-53)/76,(dividend-53)/76 from div_rec_adv where sch_code='" & ddscheme.SelectedItem.Value & "' And dateadd(d,276,date)>='" & frdt & "' And dateadd(d,276,date)<='" & todt & "' order by dateadd(d,276,date)"
            'end
            sqlcon1 = New SqlConnection(constr)
            sqlcon1.Open()
            Sqlcom = New SqlCommand(strsql, sqlcon1)
            sqlrd1 = Sqlcom.ExecuteReader
            If sqlrd1.Read Then
                Do
                    If IsDBNull(m) = False Then
                        ReDim Preserve DivArr(m)
                        ReDim Preserve DivDt(m)
                        DivDt(m) = sqlrd1(0)
                        DivArr(m) = sqlrd1(1)
                        m += 1
                    ElseIf IsDBNull(sqlrd1(1)) = False Then
                        ReDim Preserve BonArr(k)
                        ReDim Preserve BonDt(k)
                        BonDt(k) = sqlrd1(0)
                        BonArr(k) = sqlrd1(2)
                        k += 1
                    End If
                Loop While sqlrd1.Read
            End If
            sqlcon1.Close()
            sqlcon1.Dispose()
            m = 0
            j = 0
            k = 0
            Arrcount = 0
            IndUnits = 0
            strdt = SplitCustom(Trim(txtfromDate.Text), "/")
            Sqlcon = New SqlConnection(constr)
            Sqlcon.Open()

            ''strsql = "Select rmf_todt,rmf_nav from nav_reg where rmf_scheme='" & scheme_code & "' and rmf_plan='" & plan_code & "' And rmf_todt >='" & frdt & "' And rmf_todt<='" & todt & "' order by rmf_todt"
            'strsql = "Select dateadd(d,276,[date]),(Nav_rs-53)/76 from nav_rec where sch_code='" & ddscheme.SelectedItem.Value & "' And dateadd(d,276,[date]) >='" & frdt & "' And dateadd(d,276,[date])<='" & todt & "' order by dateadd(d,276,[date])"
            strsql = "Select dateadd(d,276,[date]),(Nav_rs-53)/76 from nav_rec where sch_code='" & ddscheme.SelectedItem.Value & "' And dateadd(d,276,[date]) >='" & frdt.ToString("dd MMM yyyy") & "' And dateadd(d,276,[date]) <= (Select top 1 dateadd(d,276,[date]) from nav_rec where sch_code='" & ddscheme.SelectedItem.Value & "' And dateadd(d,276,[date])>='" & todt.ToString("dd MMM yyyy") & "' order by dateadd(d,276,[date])) order by dateadd(d,276,[date])"

            ''commented on 28 oct 14
            'strsql = "Select dateadd(d,276,[date]),(Nav_rs-53)/76 from nav_rec where sch_code='" & ddscheme.SelectedItem.Value & "' And dateadd(d,276,[date]) >='" & frdt & "' And dateadd(d,276,[date]) <= (Select top 1 dateadd(d,276,[date]) from nav_rec where sch_code='" & ddscheme.SelectedItem.Value & "' And dateadd(d,276,[date])>='" & todt & "' order by dateadd(d,276,[date])) order by dateadd(d,276,[date])"
            'Select top 1 dateadd(d,276,dt1) from nav_rec where sch_code='" & ddscheme.SelectedItem.Value & "' And dateadd(d,276,[date])>='" & todt & "' order by dateadd(d,276,dt1) 
            Sqlcom = New SqlCommand(strsql, Sqlcon)
            Sqlrd = Sqlcom.ExecuteReader
            If Sqlrd.Read Then
                Do
AfterDiv:
                    If j = 0 Then
                        CalcDt = Sqlrd(0)
                        Iprw = Ipdt.NewRow
                        Iprw(0) = Format(CDate(Sqlrd(0)), "dd-MMM-yyyy")
                        CalcDt = Sqlrd(0)
                        ReDim Preserve DtArr(Arrcount)
                        DtArr(Arrcount) = Sqlrd(0)
                        TempDt = Sqlrd(0)
                        Iprw(1) = Math.Round(Sqlrd(1) + (Sqlrd(1) * Entry_Load / 100), 4)
                        FNav = Sqlrd(1)
                        FDate = Sqlrd(0)
                        Iprw(2) = Math.Round(Amt / (Sqlrd(1) + (Sqlrd(1) * Entry_Load / 100)), 4)
                        cuml_units = Iprw(2)
                        TotNav = TotNav + Math.Round(Amt / (Sqlrd(1) + (Sqlrd(1) * Entry_Load / 100)), 4)
                        Iprw(3) = Amt * -1
                        ReDim Preserve CashFl(Arrcount)
                        CashFl(Arrcount) = Iprw(3)
                        Iprw(4) = Amt * -1
                        ReDim Preserve CashFlInd(Arrcount)
                        CashFlInd(Arrcount) = Iprw(4)
                        Iprw(5) = Math.Round(Temp, 2)
                        TempUnits = Math.Round(TempUnits + Math.Round(Amt / (Sqlrd(1) + (Sqlrd(1) * Entry_Load / 100)), 4), 4)
                        If Temp = Amt Then
                            Iprw(6) = Math.Round(Temp, 2)
                        Else
                            Iprw(6) = Math.Round(Sqlrd(1) * TempUnits, 2)
                        End If
                        strsql = "Select (ind_val-53)/76 from Ind_rec where ind_code ='" & benchmark & "' And dateadd(d,276,dt1)>='" & Sqlrd.GetDateTime(0).ToString("dd MMM yyyy") & "' order by dateadd(d,276,dt1)"
                        sqlcon1 = New SqlConnection(constr)
                        sqlcon1.Open()
                        Sqlcom = New SqlCommand(strsql, sqlcon1)
                        sqlrd1 = Sqlcom.ExecuteReader
                        If sqlrd1.Read Then
                            TempNav = Math.Round(Math.Round(Amt / sqlrd1(0), 4), 4)
                            IndUnits = IndUnits + Math.Round(Math.Round(Amt / sqlrd1(0), 4), 4)
                            currentIndex = Math.Round(sqlrd1(0), 4)
                        End If
                        sqlcon1.Close()
                        sqlcon1.Dispose()
                        If Temp = Amt Then
                            Iprw(7) = currentIndex
                            Iprw(8) = Math.Round(Temp, 2)
                        Else
                            Iprw(7) = currentIndex
                            Iprw(8) = Math.Round(currentIndex * IndUnits, 2)
                        End If
                        Ipdt.Rows.Add(Iprw)
                        Temp = Temp + Amt
                        j += 1
                        Arrcount += 1
                        If ddPeriod_SIP.SelectedItem.Text <> "Fortnightly" Then
                            If SplitCustom(Sqlrd(0), "-")(0) < SIP_date Then
                                CalcDt = CDate(SIP_date & "-" & SplitCustom(Sqlrd(0), "-")(1) & "-" & SplitCustom(Sqlrd(0), "-")(2)) ''today
                                ''commented on 28 oct 14
                                'If Split(Sqlrd(0), "/")(1) < SIP_date Then
                                '    CalcDt = CDate(Split(Sqlrd(0), "/")(0) & "/" & SIP_date & "/" & Split(Sqlrd(0), "/")(2))      'DateAdd(DateInterval.Month, PrdVal, CalcDt)
                                ''end
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                ''''''''''''''''''''''''''''''' chnaged for daily '''''''''''''''''''''''''''''''
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                'If ddPeriod_SIP.SelectedItem.Text = "Daily" Then
                                '    If Day(CalcDt) <= SIP_date Then
                                '        CalcDt = DateAdd(DateInterval.Day, 1, CalcDt)
                                '    End If
                                'End If
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                                If ddPeriod_SIP.SelectedItem.Text = "Monthly" Then
                                    If Day(CalcDt) <= SIP_date Then
                                        CalcDt = DateAdd(DateInterval.Month, 1, CalcDt)
                                    End If
                                End If
                                If ddPeriod_SIP.SelectedItem.Text = "Quarterly" Then
                                    If Day(CalcDt) <= SIP_date Then
                                        CalcDt = DateAdd(DateInterval.Month, 3, CalcDt)
                                    End If
                                End If
                            Else
                                CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
                                Tempdtstr = SplitCustom(CalcDt, "/")
                                CalcDt = CDate(SIP_date & "/" & Tempdtstr(1) & "/" & Tempdtstr(2)) ''today

                                ''''commented on 28 oct 14
                                'CalcDt = CDate(Tempdtstr(0) & "/" & SIP_date & "/" & Tempdtstr(2))

                            End If
                        Else
                            CalcDt = DateAdd(DateInterval.Day, PrdVal, CalcDt)
                        End If
                    ElseIf Sqlrd(0) >= CalcDt And CalcDt <= todt Then
                        If IsNothing(DivArr) = False Then
                            If m <= UBound(DivDt) Then
                                If DivDt(m) >= TempDt And DivDt(m) <= CalcDt Then
                                    strsql = "Select (A.Nav_rs-53)/76,(B.face_val-53)/76 from nav_rec A,Scheme_Info B where A.sch_code=B.sch_code And A.sch_code='" & ddscheme.SelectedItem.Value & "' And dateadd(d,276,A.date)='" & DivDt(m).ToString("dd MMM yyyy") & "'"
                                    sqlcon1 = New SqlConnection(constr)
                                    sqlcon1.Open()
                                    Sqlcom = New SqlCommand(strsql, sqlcon1)
                                    sqlrd1 = Sqlcom.ExecuteReader
                                    If sqlrd1.Read Then
                                        Iprw = Ipdt.NewRow
                                        PerUnitDiv = (DivArr(m) * sqlrd1(1)) / 100
                                        PerUnitDiv = PerUnitDiv * TempUnits
                                        PerUnitDiv = PerUnitDiv / sqlrd1(0)
                                        TempUnits = Math.Round(TempUnits + PerUnitDiv, 4)
                                        Iprw(0) = "<B>" & Format(CDate(DivDt(m)), "dd/MMM/yyyy") & "</B>"

                                        ReDim Preserve DtArr(Arrcount)
                                        DtArr(Arrcount) = Sqlrd(0)
                                        Iprw(1) = "<B>" & sqlrd1(0) & "</B>"
                                        Iprw(2) = "<B>" & Math.Round(PerUnitDiv, 4) & "</B>"
                                        TotNav = TotNav + Math.Round(PerUnitDiv, 4)
                                        Iprw(3) = "<B>" & "0" & "</B>"
                                        ReDim Preserve CashFl(Arrcount)
                                        CashFl(Arrcount) = 0
                                        Iprw(5) = "<B>" & "0" & "</B>"
                                        ReDim Preserve CashFlInd(Arrcount)
                                        CashFlInd(Arrcount) = 0
                                        '//dont add dividend row 
                                        ''Ipdt.Rows.Add(Iprw)
                                    End If
                                    sqlcon1.Close()
                                    sqlcon1.Dispose()
                                    m += 1
                                    PerUnitDiv = 0
                                    Arrcount += 1
                                    GoTo AfterDiv
                                End If
                            End If
                        ElseIf IsNothing(BonArr) = False Then
                            If k <= UBound(BonDt) Then
                                If BonDt(k) >= TempDt And BonDt(k) <= CalcDt Then
                                    Iprw = Ipdt.NewRow
                                    PerUnitDiv = (TempUnits * Split(BonArr(k), ":")(0)) / Split(BonArr(k), ":")(1)
                                    TempUnits = Math.Round(TempUnits + PerUnitDiv, 4)
                                    Iprw(0) = "<B>" & Format(CDate(BonDt(m)), "dd/MM/yyyy") & "</B>"
                                    ReDim Preserve DtArr(Arrcount)
                                    DtArr(Arrcount) = Sqlrd(0)
                                    Iprw(2) = "<B>" & Math.Round(PerUnitDiv, 4) & "</B>"
                                    TotNav = TotNav + Math.Round(PerUnitDiv, 4)
                                    Iprw(3) = "<B>" & "0" & "</B>"
                                    ReDim Preserve CashFl(Arrcount)
                                    CashFl(Arrcount) = 0
                                    Iprw(5) = "<B>" & "0" & "</B>"
                                    ReDim Preserve CashFlInd(Arrcount)
                                    CashFlInd(Arrcount) = 0
                                    k += 1
                                    PerUnitDiv = 0
                                    Ipdt.Rows.Add(Iprw)
                                    Arrcount += 1
                                    GoTo AfterDiv
                                End If
                            End If
                        End If
                        Iprw = Ipdt.NewRow
                        Iprw(0) = Format(CDate(Sqlrd(0)), "dd-MMM-yyyy")
                        LDate = Sqlrd(0)
                        CalcDt = Sqlrd(0)
                        ReDim Preserve DtArr(Arrcount)
                        If IsDBNull(Iprw(0)) = False Then
                            DtArr(Arrcount) = Sqlrd(0)
                        End If
                        TempDt = Sqlrd(0)
                        Iprw(1) = Math.Round(Sqlrd(1) + (Sqlrd(1) * Entry_Load / 100), 4)
                        LNav = Iprw(1)
                        cuml_units = cuml_units + (Amt / (Sqlrd(1) + (Sqlrd(1) * Entry_Load / 100)))
                        Iprw(2) = Math.Round(cuml_units, 4)
                        TotNav = TotNav + Math.Round(Amt / Sqlrd(1), 4)
                        Iprw(3) = Amt * -1
                        ReDim Preserve CashFl(Arrcount)
                        CashFl(Arrcount) = Iprw(3)
                        Iprw(4) = Amt * -1
                        ReDim Preserve CashFlInd(Arrcount)
                        CashFlInd(Arrcount) = Iprw(4)
                        Iprw(5) = Math.Round(Temp, 2)
                        TempUnits = Math.Round(TempUnits + Math.Round(Amt / Sqlrd(1), 4), 4)
                        If Temp = Amt Then
                            Iprw(6) = Math.Round(Temp, 2)
                        Else
                            Iprw(6) = Math.Round(Iprw(1) * Iprw(2), 2)
                        End If
                        strsql = "Select Top 10 (ind_val-53)/76 from Ind_rec where ind_code ='" & benchmark & "' And dateadd(d,276,dt1)>='" & Sqlrd.GetDateTime(0).ToString("dd MMM yyyy") & "' order by dateadd(d,276,dt1)"
                        sqlcon1 = New SqlConnection(constr)
                        sqlcon1.Open()
                        Sqlcom = New SqlCommand(strsql, sqlcon1)
                        sqlrd1 = Sqlcom.ExecuteReader
                        If sqlrd1.Read Then
                            TempNav = Math.Round(Math.Round(Amt / sqlrd1(0), 4), 4)
                            IndUnits = IndUnits + Math.Round(Math.Round(Amt / sqlrd1(0), 4), 4)
                            currentIndex = Math.Round(sqlrd1(0), 4)
                        End If
                        sqlcon1.Close()
                        sqlcon1.Dispose()
                        If Temp = Amt Then
                            Iprw(7) = currentIndex
                            Iprw(8) = Math.Round(Temp, 2)
                        Else
                            Iprw(7) = currentIndex
                            Iprw(8) = Math.Round(currentIndex * IndUnits, 2)
                        End If
                        Ipdt.Rows.Add(Iprw)
                        Temp = Temp + Amt
                        If ddPeriod_SIP.SelectedItem.Text <> "Fortnightly" Then
                            If SplitCustom(Sqlrd(0), "/")(0) < SIP_date Then
                                CalcDt = CDate(SIP_date & "/" & SplitCustom(Sqlrd(0), "/")(1) & "/" & SplitCustom(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
                                ''commented on 28 oct 14
                                'CalcDt = CDate(SplitCustom(Sqlrd(0), "/")(0) & "/" & SIP_date & "/" & SplitCustom(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)

                            Else
                                CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
                                Tempdtstr = SplitCustom(CalcDt, "/")
                                CalcDt = CDate(SIP_date & "/" & Tempdtstr(1) & "/" & Tempdtstr(2))

                                ''commented on 28 oct 14
                                'CalcDt = CDate(Tempdtstr(0) & "/" & SIP_date & "/" & Tempdtstr(2))
                            End If
                        Else
                            CalcDt = DateAdd(DateInterval.Day, PrdVal, CalcDt)
                        End If
                        'txtacc.Text = Math.Round(Iprw(3) * Iprw(1), 2)
                        'Ipdt.Rows.Add(Iprw)
                        'm += 1
                        j += 1
                        Arrcount += 1
                    End If
                Loop While Sqlrd.Read
            End If
            Sqlcon.Close()
            Sqlcon.Dispose()

            '''''''''''strsql = "Select (ind_val-53)/76,dateadd(d,276,dt1) from Ind_rec where Ind_code in(Select distinct ind_code from schemeindex where sch_code='" & ddscheme.SelectedItem.Value & "' and  ind_code ='" & benchmark(1) & "') And dateadd(d,276,dt1)>='" & fmt(txtvalason.Text) & "' order by dateadd(d,276,dt1)"
            ''''''''strsql = "Select (ind_val-53)/76,dateadd(d,276,dt1) from Ind_rec where Ind_code='" & benchmark(1) & "'  And dateadd(d,276,dt1)<='" & fmt(txtvalason.Text) & "' order by dateadd(d,276,dt1)"
            '''''''''strsql = "Select (ind_val-53)/76,dateadd(d,276,dt1) from Ind_rec where Ind_code='" & benchmark(1) & "'  And dateadd(d,276,dt1)<='" & fmt(txtvalason.Text) & "' And dateadd(d,276,dt1)>='" & fmt(txtfromDate.Text) & "' order by dateadd(d,276,dt1)"
            ''''''''sqlcon1 = New SqlConnection(constr)
            ''''''''sqlcon1.Open()
            ''''''''Sqlcom = New SqlCommand(strsql, sqlcon1)
            ''''''''sqlrd1 = Sqlcom.ExecuteReader
            ''''''''If sqlrd1.Read Then
            ''''''''    Do
            ''''''''        strsql = "Select (Nav_rs-53)/76,dateadd(d,276,date) from nav_rec where sch_code='" & ddscheme.SelectedItem.Value & "' And dateadd(d,276,date)='" & sqlrd1(1) & "'"
            ''''''''        Sqlcon = New SqlConnection(constr)
            ''''''''        Sqlcon.Open()
            ''''''''        Sqlcom = New SqlCommand(strsql, Sqlcon)
            ''''''''        Sqlrd = Sqlcom.ExecuteReader
            ''''''''        If Sqlrd.Read Then
            ''''''''            If IsDBNull(Sqlrd(0)) = False Then
            ''''''''                TotNav = TotNav * Sqlrd(0)
            ''''''''                Iprw = Ipdt.NewRow
            ''''''''                Iprw(0) = Format(CDate(Sqlrd(1)), "dd/MM/yyyy")
            ''''''''                LDate = Sqlrd(1)
            ''''''''                Iprw(1) = Sqlrd(0)
            ''''''''                LNav = Sqlrd(0)
            ''''''''                Iprw(5) = Math.Round(TotNav, 2)
            ''''''''                Ipdt.Rows.Add(Iprw)
            ''''''''                IndUnits = IndUnits * sqlrd1(0)
            ''''''''                Exit Do
            ''''''''            End If
            ''''''''        End If
            ''''''''        Sqlcon.Close()
            ''''''''        Sqlcon.Dispose()
            ''''''''    Loop While sqlrd1.Read
            ''''''''End If

            '//vishal first calcualte the previous value
            Dim lastAvail_Date As String
            Dim lastAvail_PresentValue As String
            lastAvail_Date = fmt(txtvalason.Text)
            strsql = "Select top 1 (ind_val-53)/76,dateadd(d,276,dt1) from Ind_rec where Ind_code='" & benchmark & "'  And dateadd(d,276,dt1)<='" & Date.Parse(txtvalason.Text).ToString("dd MMM yyyy") & "' order by dateadd(d,276,dt1) desc "
            ''commented on 28 oct 14
            'strsql = "Select top 1 (ind_val-53)/76,dateadd(d,276,dt1) from Ind_rec where Ind_code='" & benchmark & "'  And dateadd(d,276,dt1)<='" & fmt(txtvalason.Text) & "' order by dateadd(d,276,dt1) desc "
            sqlcon1 = New SqlConnection(constr)
            sqlcon1.Open()
            Sqlcom = New SqlCommand(strsql, sqlcon1)
            sqlrd1 = Sqlcom.ExecuteReader
            If sqlrd1.Read Then
                If IsDBNull(sqlrd1) = False Then
                    lastAvail_PresentValue = sqlrd1(0)
                    lastAvail_PresentValue = lastAvail_PresentValue * IndUnits
                    lastAvail_Date = sqlrd1(1)
                End If
            End If
            Sqlcon.Close()
            Sqlcon.Dispose()


            '**************MANISH**************
            Dim Dt_As_On As String
            Dim Value_As_On As String
            ''Dt_As_On = fmt(txtvalason.Text)
            '''strsql = "Select (ind_val-53)/76,dateadd(d,276,dt1) from Ind_rec where Ind_code in(Select distinct ind_code from schemeindex where sch_code='" & ddscheme.SelectedItem.Value & "' and  ind_code ='" & benchmark(1) & "') And dateadd(d,276,dt1)>='" & fmt(txtvalason.Text) & "' order by dateadd(d,276,dt1)"
            strsql = "Select top 1 (ind_val-53)/76,dateadd(d,276,dt1) from Ind_rec where Ind_code='" & benchmark & "'  And dateadd(d,276,dt1)>='" & Date.Parse(txtvalason.Text).ToString("dd MMM yyyy") & "' order by dateadd(d,276,dt1) "
            ''commented on 28 oct 14
            'strsql = "Select top 1 (ind_val-53)/76,dateadd(d,276,dt1) from Ind_rec where Ind_code='" & benchmark & "'  And dateadd(d,276,dt1)>='" & fmt(txtvalason.Text) & "' order by dateadd(d,276,dt1) "
            'strsql = "Select (ind_val-53)/76,dateadd(d,276,dt1) from Ind_rec where Ind_code='" & benchmark(1) & "'  And dateadd(d,276,dt1)<='" & fmt(txtvalason.Text) & "' And dateadd(d,276,dt1)>='" & fmt(txtfromDate.Text) & "' order by dateadd(d,276,dt1)"
            sqlcon1 = New SqlConnection(constr)
            sqlcon1.Open()
            Sqlcom = New SqlCommand(strsql, sqlcon1)
            sqlrd1 = Sqlcom.ExecuteReader
            If sqlrd1.Read Then
                If IsDBNull(sqlrd1) = False Then
                    Value_As_On = sqlrd1(0)
                    Value_As_On = Value_As_On * IndUnits
                    Dt_As_On = sqlrd1(1)
                End If
            End If
            Sqlcon.Close()
            Sqlcon.Dispose()

            '//vishal if value as on date is not available then ,keep last available present value 
            If Dt_As_On = "" And Value_As_On = "" Then
                Dt_As_On = lastAvail_Date
                Value_As_On = lastAvail_PresentValue
            End If

            'strsql = "Select top 1 (Nav_rs-53)/76,dateadd(d,276,date) from nav_rec where sch_code='" & ddscheme.SelectedItem.Value & "' And dateadd(d,276,date)<='" & Dt_As_On & "' order by dateadd(d,276,date) desc"
            If ddPeriod_SIP.SelectedItem.Text = "Monthly" Then
                strsql = "Select top 1 (Nav_rs-53)/76,dateadd(d,276,date) from nav_rec where sch_code='" & ddscheme.SelectedItem.Value & "' And dateadd(d,276,date)<='" & Date.Parse(txtvalason.Text).ToString("dd MMM yyyy") & "' order by dateadd(d,276,date) desc"
            ElseIf ddPeriod_SIP.SelectedItem.Text = "Quarterly" Then
                strsql = "Select top 1 (Nav_rs-53)/76,dateadd(d,276,date) from nav_rec where sch_code='" & ddscheme.SelectedItem.Value & "' And dateadd(d,276,date)<='" & Date.Parse(txtvalason.Text).ToString("dd MMM yyyy") & "' order by dateadd(d,276,date) desc"

            Else
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''CHANGED FOR DAILY (ELSE CONDINITON ADDED. PREVIOUSLY IT WAS NOT THERE)
                ''''''''''''''''''''''' comment it if want to remove daily...
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                strsql = "Select top 1 (Nav_rs-53)/76,dateadd(d,276,date) from nav_rec where sch_code='" & ddscheme.SelectedItem.Value & "' And dateadd(d,276,date)>='" & Date.Parse(txtvalason.Text).ToString("dd MMM yyyy") & "' order by dateadd(d,276,date) "
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If
            Sqlcon = New SqlConnection(constr)
            Sqlcon.Open()
            Sqlcom = New SqlCommand(strsql, Sqlcon)
            Sqlrd = Sqlcom.ExecuteReader
            If Sqlrd.Read Then
                If IsDBNull(Sqlrd(0)) = False Then

                    Pre_Nav = Iprw(2)
                    Iprw = Ipdt.NewRow
                    'Iprw(0) = Format(CDate(Sqlrd(1)), "dd/MM/yyyy")
                    Iprw(0) = Format(CDate(Sqlrd(1)), "dd-MMM-yyyy")
                    'Dt_As_On = Format(CDate(Sqlrd(0)), "dd-MMM-yyyy")
                    LDate = Sqlrd(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''''Changed for DAILY (else Part is original. Remove IF condition if not required DAILY Option)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If ddPeriod_SIP.SelectedItem.Text = "Daily" Then
                        Iprw(1) = Math.Round(Sqlrd(0) + (Sqlrd(0) * Entry_Load / 100), 4)       ''Sqlrd(0)
                        '''Pre_Nav = Math.Round(Sqlrd(0) + (Sqlrd(0) * Entry_Load / 100), 4)
                        TotNav = Pre_Nav * Iprw(1)          'Sqlrd(0)
                    Else
                        Iprw(1) = Sqlrd(0)
                        TotNav = Pre_Nav * Sqlrd(0)
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Iprw(2) = Pre_Nav
                    Iprw(3) = Math.Round(TotNav, 2)
                    LNav = Sqlrd(0)
                    'Iprw(5) = Math.Round(TotNav, 2)
                    Ipdt.Rows.Add(Iprw)
                    'IndUnits = IndUnits * sqlrd1(0)
                    IndUnits = IndUnits * Value_As_On

                End If
            End If
            Sqlcon.Close()
            Sqlcon.Dispose()

            sip_amt = Iprw(3)

            TotNav = TotNav
            Session("SIP") = Ipdt
            'Ipdt.Columns.Remove(Ipcol.ColumnName.Remove(7, "Index"))

            Gsp.DataSource = Ipdt
            Gsp.DataBind()


            Gsp.Visible = True
            cmdexp.Enabled = True

            'Ipdt.ExtendedProperties.Remove(7)

            Dim Dt As String = ""
            Dim cashflw As String = ""
            Dim cashindx As String = ""

            If IsNothing(DtArr) = False Then
                For i = 0 To UBound(DtArr)
                    If Dt = "" Then
                        Dt = Format(DtArr(i), "dd/MM/yyyy")
                    Else
                        If CashFl(i) <> 0 Then
                            Dt = Dt & "," & Format(DtArr(i), "dd/MM/yyyy")
                        End If
                    End If
                    If cashflw = "" Then
                        cashflw = CashFl(i)
                    Else
                        If CashFl(i) <> 0 Then
                            cashflw = cashflw & "," & CashFl(i)
                        End If
                    End If
                    If cashindx = "" Then
                        cashindx = CashFlInd(i)
                    Else
                        If CashFlInd(i) <> 0 Then
                            cashindx = cashindx & "," & CashFlInd(i)
                        End If
                    End If
                Next i
            End If
            If Sqlcon.State = ConnectionState.Open Then
                Sqlcon.Close()
            End If
            Dt = Dt & "," & Format(CDate(LDate), "dd/MM/yyyy")
            cashflw = cashflw & "," & TotNav
            cashindx = cashindx & "," & Value_As_On

            getXirr = XIRR(Dt, cashflw)
            txtxsch.Text = Math.Round(getXirr, 2) & "%"
            '------Manish 03/07/2007
            If (sip_amt - (Temp - Amt)) = 0 Then
                txtonttm.Text = 0
            Else
                txtonttm.Text = Math.Round((sip_amt - (Temp - Amt)) * 100 / (Temp - Amt), 2) & "%"
                ''''''''''''''txtonttm.Text = Math.Round((sip_amt - (Temp - Amt)) * 100 / (Temp), 2) & "%"

            End If
            '-----END

            getXirr = XIRR(Dt, cashindx)
            txtxind.Text = Math.Round(getXirr, 2) & "%"
            '//charting vishal
            tblChart.Visible = False
            HttpContext.Current.Session("SIP_Chart_Image") = ""
            If chkChart_SIP.Checked = True Then
                Dim datatbl_sip As DataTable
                datatbl_sip = Ipdt.Copy
                Call formatTable4Chart(datatbl_sip, True, 1, 0, True, , "Nav,Units,CashFlow(scheme),CashFlow(Index),Index", "Amount,SIP Value,Index Value")
                Session("ChartData_SIP") = datatbl_sip
                'Add by syed
                hdIsGraphExist.Value = 1
                hdChartData.Value = "SIP"
                'end add by syed
                'commented by syed
                Dim sipChart As WebChart.ChartControl = New WebChart.ChartControl
                Call drawChart(sipChart, datatbl_sip, "SIP", CDbl(txtinstall.Text))
                HdGraphImgPath.Value = HttpContext.Current.Session("SIP_Chart_Image")
                HttpContext.Current.Session("All_Chart_Image") = ""
                HttpContext.Current.Session("All_Chart_Image_Ie8") = HttpContext.Current.Session("SIP_Chart_Image") + ".png"
                HttpContext.Current.Session("IsChartExist") = True
                tblChart.Visible = True
                'hdIsGraphExist.Value = "1"
            Else
                hdChartData.Value = "0"
                'hdIsGraphExist.Value = "0"
                HttpContext.Current.Session("IsChartExist") = False
            End If



            'If DateDiff(DateInterval.Day, FDate, LDate) > 365 Then
            '    txtonttm.Text = Math.Round((Math.Pow((LNav / FNav), 365 / DateDiff(DateInterval.Day, FDate, LDate)) - 1) * 100, 4) & "%"
            'Else
            '    txtonttm.Text = Math.Round((LNav - FNav) * 100 / FNav, 4) & "%"
            'End If

            'cmdexp.Attributes.Add("onClick", "javascript:newexports('Gsp','Gsp',2,'" & txtxsch.Text & "','" & txtxind.Text & "','" & txtonttm.Text & "',' ','" & ddscheme.SelectedItem.Text & "');return false;")


            PSipDisclamer.InnerHtml = "<p><u>Note:</u> Past performance may or may not be sustained in future. It is assumed that a SIP of " + txtinstall.Text + " each executed on " + ddSIPdate.SelectedItem.Text + " of every " + ddPeriod_SIP.SelectedItem.Text.Substring(0, ddPeriod_SIP.SelectedItem.Text.Length - 2).ToLower() + " including the first installment in the selected scheme. Yield of Scheme and Benchmark are annualized and cumulative investment return for cash flows resulting out of uniform and " + ddPeriod_SIP.SelectedItem.Text.ToLower() + " subscriptions have been worked out using XIRR calculation. Load has not been taken into consideration.</p>"
        Catch ex As Exception
            Gsp.Visible = False
            txtonttm.Text = ""
            tblChart.Visible = False
            tblSIP1.Visible = False
            txtxsch.Text = ""
            txtxind.Text = ""
            cmdexp.Enabled = False
            Response.Write("<script>alert(""Error on fetching report. Please contact Nippon India Mutual Fund team."" )</script>")
        Finally
            SetHtmlSIP()


        End Try
    End Sub
    'Add by syed


    '<System.Web.Services.WebMethod(EnableSession:=True)>

    <WebMethod>
    Public Shared Function getChartData4Stp(Type As String) As List(Of GraphData4Spt)
        Dim data As DataTable

        data = HttpContext.Current.Session("ChartData_SIP")

        Dim _list As List(Of GraphData4Spt) = New List(Of GraphData4Spt)
        Dim obj As GraphData4Spt
        If Not data Is Nothing Then
            For Each _data As DataRow In data.Rows
                obj = New GraphData4Spt
                obj.ID = _data("ID")
                If Type = "STP" Then
                    If Not IsDBNull(_data("Cumulative_Amount")) Then
                        obj.Cumulative_Amount = _data("Cumulative_Amount")
                    End If
                End If
                If Not IsDBNull(_data("Investment_In_Index")) Then
                    obj.Investment_In_Index = _data("Investment_In_Index")
                End If
                _list.Add(obj)
            Next
        End If


        Return _list

    End Function

    <WebMethod>
    Public Shared Function getChartData(Type As String) As List(Of GraphData)
        Dim data As DataTable

        data = HttpContext.Current.Session("ChartData_SIP")

        Dim _list As List(Of GraphData) = New List(Of GraphData)
        Dim obj As GraphData
        For Each _data As DataRow In data.Rows
            obj = New GraphData
            obj.ID = _data("ID")
            If Not IsDBNull(_data("Amount")) Then
                obj.Amount = _data("Amount")
            End If
            If Type = "SIP" Then
                If Not IsDBNull(_data("SIP Value")) Then
                    obj.Ret_Value = _data("SIP Value")
                End If

            End If
            If Type = "SWP" Then
                If Not IsDBNull(_data("SWP Value")) Then
                    obj.Ret_Value = _data("SWP Value")
                End If
            End If

            If Type = "STP" Then
                If Not IsDBNull(_data("STP Value")) Then
                    obj.Ret_Value = _data("STP Value")
                End If
            End If
            If Not IsDBNull(_data("Index Value")) Then
                obj.Index_Value = _data("Index Value")
            End If

            _list.Add(obj)
        Next
        Return _list

    End Function


    'end by syed


    ''''Private Sub cmdSWP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Private Overloads Sub cmdSWP_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdSWP.Click
        Dim x As Integer = 0
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim frdt As Date
        Dim todt As Date
        Dim Valdt As Date
        Dim PrdVal As Integer = 1
        Dim Amt As Double
        Dim Temp As Double
        'Dim Colstr As String = "Date#NAV#Units#CashFlow#Amount#SWP Value#Index#Index Value"
        Dim Colstr As String = "Date#Amount Invested#Amount Withdrawn#NAV#Unit Sold#Balance Units#Amount Withdrawn till date#Value of Balance Units#Index Value#Amount#Index"
        Dim ColArr() As String
        Dim Ipcol As DataColumn
        Dim CalcDt As Date
        Dim DtArr() As Date
        Dim CshFlow() As Double
        Dim Arrcount As Integer = 0
        Dim Tempdtstr(2) As String
        Dim TrueFlg As Boolean = False
        Dim chkdate As Date
        Dim Pl As Integer = 0
        Dim LastUnits As Double = 0
        Dim LastCash As Double = 0
        Dim TempNav As Double = 0
        Dim currentIndex As Double = 0
        Dim rowcount As Integer = 0
        Dim Temptotal As Double = 0
        Dim prev_idx_value As Double
        Dim prev_idx As Double
        Dim sip_amount As Double
        Dim tmp_idx As Double
        Dim swp_amt As Double
        Dim amt_swp As Double
        Dim Balance_Unit As Double

        Dim ind_code As String
        Dim ind_code1() As String
        Dim AmtWidrlTillDate As Double
        cmdSWP.Attributes.Add("onclick", "javascript:return validate_SWP();")
        Ipdt.Rows.Clear()
        Dgswp.Columns.Clear()
        Try
            swp_amt = 0.0
            amt_swp = 0.0

            If ddPlan.SelectedItem.Text = "--" Then
                Response.Write("<script>alert(""Please Select Plan.."")</script>")
                Exit Sub
            End If
            If ddwscname.SelectedItem.Text = "--" Then
                Response.Write("<script>alert(""Please Select Scheme.."")</script>")
                Exit Sub
            End If
            If ddwbnmark.SelectedItem.Text = "--" Then
                'txtMess.Value = "Please Select Benchmark.."
                Response.Write("<script>alert(""Please Select Benchmark Index.."")</script>")
                Exit Sub
            End If
            If Val(txtwinamt.Text) = 0 Then
                Response.Write("<script>alert(""Initial Amount Cannot Be Blank.."")</script>")
                Exit Sub
            End If

            If (Val(txtwinamt.Text) Mod 1) > 0 Then
                Response.Write("<script>alert(""Initial amount cannot be fractional."")</script>")
                Exit Sub
            End If

            If Val(txtwtramt.Text) = 0 Then
                Response.Write("<script>alert(""Withdrawal Amount Cannot Be Blank.."")</script>")
                Exit Sub
            End If

            If (Val(txtwtramt.Text) Mod 1) > 0 Then
                Response.Write("<script>alert(""Withdrawal amount cannot be fractional."")</script>")
                Exit Sub
            End If

            If txtwfrdt.Text = "" Or txtwtdt.Text = "" Or txtwvaldate.Text = "" Then
                Response.Write("<script>alert(""From Date / To Date / Value As on Date Can Not be Blank.."")</script>")
                Exit Sub
            End If

            For i = 1 To Len(txtwfrdt.Text)
                If Mid(Trim(txtwfrdt.Text), i, 1) = "/" Then
                    x += 1
                End If
            Next i

            If x <> 2 Then
                Response.Write("<script>alert(""Please Enter From Date in proper format.."")</script>")
                Exit Sub
            End If
            i = 0
            x = 0

            For i = 1 To Len(txtwtdt.Text)
                If Mid(Trim(txtwtdt.Text), i, 1) = "/" Then
                    x += 1
                End If
            Next i
            If x <> 2 Then
                Response.Write("<script>alert(""Please Enter To Date in proper format.."")</script>")
                Exit Sub
            End If
            i = 0
            x = 0

            For i = 1 To Len(txtwvaldate.Text)
                If Mid(Trim(txtwvaldate.Text), i, 1) = "/" Then
                    x += 1
                End If
            Next i
            If x <> 2 Then
                Response.Write("<script>alert(""Please Value as on Date in proper format.."")</script>")
                Exit Sub
            End If
            i = 0
            x = 0

            If IsDate(fmt(Trim(txtwfrdt.Text))) = False Or IsDate(fmt(Trim(txtwtdt.Text))) = False Or IsDate(fmt(Trim(txtwvaldate.Text))) = False Then
                txtMess.Value = "Please Enter The Dates in Proper Formats (dd/mm/yyyy).."
                Response.Write("<script>alert(""Please Value as on Date in proper format.."")</script>")
                Exit Sub
            End If

            Ipdt = New DataTable
            frdt = Trim(txtwfrdt.Text).Replace("/", "-")
            todt = Trim(txtwtdt.Text).Replace("/", "-")
            Valdt = Trim(txtwvaldate.Text).Replace("/", "-")








            ''---commented on 28 oct 14
            'frdt = Split(Trim(txtwfrdt.Text), "/")(1) & "/" & Split(Trim(txtwfrdt.Text), "/")(0) & "/" & Split(Trim(txtwfrdt.Text), "/")(2)
            'todt = Split(Trim(txtwtdt.Text), "/")(1) & "/" & Split(Trim(txtwtdt.Text), "/")(0) & "/" & Split(Trim(txtwtdt.Text), "/")(2)
            'Valdt = Split(Trim(txtwvaldate.Text), "/")(1) & "/" & Split(Trim(txtwvaldate.Text), "/")(0) & "/" & Split(Trim(txtwvaldate.Text), "/")(2)
            ''----end

            If Val(txtwinamt.Text) < Val(txtwtramt.Text) Then
                '    Response.Write("<script>alert(""Withdrawal amount cannot be greater than initial amount.."")</script>")
                Exit Sub
            End If
            If Val(txtwtramt.Text) < 500 Then
                Response.Write("<script>alert(""Minimum withdrawal amount should be Rs.500/- and in multiples of Rs.100/- thereafter"")</script>")
                Exit Sub
            End If
            If Val(txtwtramt.Text) > 500 Then
                Dim val1 As Integer
                val1 = Val(txtwtramt.Text)
                If val1 Mod 100 <> 0 Then
                    Response.Write("<script>alert(""Please enter withdrawal amount  in multiples of Rs.100/-"")</script>")
                    Exit Sub
                End If
            End If
            If CDate(todt) <= frdt Then
                Response.Write("<script>alert(""From_date should be less than than to_Date.."")</script>")
                Exit Sub
            End If
            If CDate(Valdt) < todt Then
                Response.Write("<script>alert(""To_date cannot be greater than value as on Date.."")</script>")
                Exit Sub
            End If

            If ddwperiod.SelectedItem.Text = "Fortnightly" Then
                PrdVal = 15
            ElseIf ddwperiod.SelectedItem.Text = "Monthly" Then
                PrdVal = 1
            ElseIf ddwperiod.SelectedItem.Text = "Quarterly" Then
                PrdVal = 3
            End If

            tblSWP1.Visible = True

            Dim SWP_date As Integer
            If ddSWPDate.SelectedItem.Text = "01st" Then
                SWP_date = 1
            ElseIf ddSWPDate.SelectedItem.Text = "08th" Then
                SWP_date = 8
            ElseIf ddSWPDate.SelectedItem.Text = "15th" Then
                SWP_date = 15
            ElseIf ddSWPDate.SelectedItem.Text = "22nd" Then
                SWP_date = 22
            End If

            ind_code = ddwbnmark1.SelectedItem.Text
            'ind_code1 = Split(ind_code, "#")


            Amt = Trim(txtwinamt.Text)
            Temp = Amt

            ColArr = Split(Colstr, "#")
            For i = 0 To 10
                Ipcol = New DataColumn
                Ipcol.ColumnName = ColArr(i)
                Ipdt.Columns.Add(Ipcol)
            Next i
            Dgswp.HeaderStyle.ForeColor = Color.White

            prev_idx_value = Val(txtwinamt.Text)
            prev_idx = 1
            sip_amount = Val(txtwtramt.Text)
            Temptotal = Val(txtwtramt.Text)
            Sqlcon = New SqlConnection(constr)
            Sqlcon.Open()
            strsql = "Select dateadd(d,276,date),(nav_rs-53)/76 from nav_rec where sch_code='" & ddwscname.SelectedItem.Value & "' And dateadd(d,276,date) >='" & frdt.ToString("dd MMM yyyy") & "' And dateadd(d,276,date)<='" & todt.ToString("dd MMM yyyy") & "' order by dateadd(d,276,date)"
            ''commented on 28 oct 14
            'strsql = "Select dateadd(d,276,date),(nav_rs-53)/76 from nav_rec where sch_code='" & ddwscname.SelectedItem.Value & "' And dateadd(d,276,date) >='" & frdt & "' And dateadd(d,276,date)<='" & todt & "' order by dateadd(d,276,date)"

            Sqlcom = New SqlCommand(strsql, Sqlcon)
            Sqlrd = Sqlcom.ExecuteReader
            If Sqlrd.Read Then
                chkdate = Sqlrd(0)
                'If Split(Sqlrd(0), "/")(1) < SWP_date Then
                '    chkdate = CDate(Split(Sqlrd(0), "/")(0) & "/" & SWP_date & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
                'Else
                '    chkdate = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
                '    Tempdtstr = Split(chkdate, "/")
                '    chkdate = CDate(Tempdtstr(0) & "/" & SWP_date & "/" & Tempdtstr(2))
                'End If
                Do
                    If j = 0 Then
                        If Sqlrd(0) >= chkdate And chkdate <= todt Then
                            Iprw = Ipdt.NewRow
                            Iprw(0) = Format(CDate(Sqlrd(0)), "dd-MMM-yyyy")
                            chkdate = Sqlrd(0)
                            ReDim Preserve DtArr(Arrcount)
                            DtArr(Arrcount) = Sqlrd(0)
                            Iprw(3) = Math.Round(Sqlrd(1) - (Sqlrd(1) * Val(txtSWP_EntryLoad.Text) / 100), 4) 'done
                            Iprw(5) = Math.Round(Amt / (Sqlrd(1) - (Sqlrd(1) * Val(txtSWP_EntryLoad.Text) / 100)), 4) 'done
                            Balance_Unit = Iprw(5) 'new march

                            LastUnits = Iprw(5) 'new

                            Iprw(2) = Amt * -1 'done
                            Iprw(1) = Amt 'new syed
                            ReDim Preserve CshFlow(Arrcount)
                            CshFlow(Arrcount) = Iprw(2) 'done
                            Iprw(9) = Amt 'done
                            Iprw(7) = Amt 'done
                            Iprw(8) = Amt 'done
                            'strsql = "Select Top 10 (ind_val-53)/76 from Ind_rec where Ind_code=(Select distinct ind_code from schemeindex where sch_code='" & ddwscname.SelectedItem.Value & "') And dateadd(d,276,dt1)>='" & Sqlrd(0) & "' order by dateadd(d,276,dt1)"
                            strsql = "Select Top 10 (ind_val-53)/76 from Ind_rec where Ind_code='" & Trim(ind_code) & "' And dateadd(d,276,dt1)>='" & Sqlrd.GetDateTime(0).ToString("dd MMM yyyy") & "' order by dateadd(d,276,dt1)"
                            ''commented on 28 oct 14
                            ''strsql = "Select Top 10 (ind_val-53)/76 from Ind_rec where Ind_code='" & Trim(ind_code) & "' And dateadd(d,276,dt1)>='" & Sqlrd(0) & "' order by dateadd(d,276,dt1)"
                            sqlcon1 = New SqlConnection(constr)
                            sqlcon1.Open()
                            Sqlcom = New SqlCommand(strsql, sqlcon1)
                            sqlrd1 = Sqlcom.ExecuteReader
                            If sqlrd1.Read Then
                                prev_idx = sqlrd1(0)
                                Iprw(10) = Math.Round(prev_idx, 4) 'done
                            End If
                            sqlcon1.Close()
                            sqlcon1.Dispose()
                            Iprw(2) = Nothing
                            Ipdt.Rows.Add(Iprw)
                            Temp = Temp + Amt
                            j += 1
                            rowcount += 1
                            Arrcount += 1

                            If ddwperiod.SelectedItem.Text <> "Fortnightly" Then
                                If SplitCustom(Sqlrd(0), "-")(0) <= SWP_date Then
                                    chkdate = CDate(SWP_date & "-" & SplitCustom(Sqlrd(0), "-")(1) & "-" & SplitCustom(Sqlrd(0), "-")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)

                                    If ddwperiod.SelectedItem.Text = "Monthly" Then
                                        If Day(chkdate) <= SWP_date Then
                                            chkdate = DateAdd(DateInterval.Month, 1, chkdate)
                                        End If
                                    End If
                                    If ddwperiod.SelectedItem.Text = "Quarterly" Then
                                        If Day(chkdate) <= SWP_date Then
                                            chkdate = DateAdd(DateInterval.Month, 3, chkdate)
                                        End If
                                    End If
                                Else
                                    chkdate = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
                                    Tempdtstr = SplitCustom(chkdate, "-")
                                    chkdate = CDate(SWP_date & "/" & Tempdtstr(1) & "/" & Tempdtstr(2))

                                    ''''commented on 28 oct 14
                                    'chkdate = CDate(Tempdtstr(0) & "/" & SWP_date & "/" & Tempdtstr(2))
                                End If
                            Else
                                chkdate = DateAdd(DateInterval.Day, PrdVal, chkdate)
                            End If
                        End If

                    ElseIf Sqlrd(0) >= chkdate And chkdate <= todt Then

                        Iprw = Ipdt.NewRow
                        Iprw(0) = Format(CDate(Sqlrd(0)), "dd-MMM-yyyy")
                        chkdate = Sqlrd(0)
                        ReDim Preserve DtArr(Arrcount)
                        DtArr(Arrcount) = Sqlrd(0)
                        Dim CurrNav = Math.Round(Sqlrd(1) - (Sqlrd(1) * Val(txtSWP_EntryLoad.Text) / 100), 4)
                        Dim WtrAmt = Val(txtwtramt.Text)
                        'If Temptotal < Amt Then
                        If Balance_Unit * CurrNav > 0 Then
                            If Balance_Unit * CurrNav < WtrAmt Then
                                WtrAmt = Math.Round(Balance_Unit * CurrNav, 4)
                            End If
                            Iprw(3) = Math.Round(Sqlrd(1) - (Sqlrd(1) * Val(txtSWP_EntryLoad.Text) / 100), 4) 'done
                            Iprw(5) = Math.Round((Ipdt.Rows(rowcount - 1).Item(5)) - (WtrAmt / (Sqlrd(1) - (Sqlrd(1) * Val(txtSWP_EntryLoad.Text) / 100))), 4) 'done
                            Balance_Unit = Iprw(5) 'new march
                            Iprw(4) = Math.Round(LastUnits - Iprw(5), 4) 'new feb
                            'prev_unit = Iprw(5) 'new feb

                            LastUnits = Iprw(5) 'done
                            Iprw(2) = WtrAmt 'done
                            Iprw(6) = IIf(String.IsNullOrEmpty(Convert.ToString(Iprw(2))), 0, ((Val(txtwtramt.Text) * (j - 1)) + WtrAmt)) 'new feb
                            AmtWidrlTillDate = Iprw(6)
                            ReDim Preserve CshFlow(Arrcount)
                            CshFlow(Arrcount) = Iprw(2) 'done
                            Iprw(9) = Amt - Temptotal 'done
                            Temptotal = Temptotal + WtrAmt
                            Iprw(7) = Math.Round(Iprw(3) * Iprw(5), 2) 'done
                            strsql = "Select Top 10 (ind_val-53)/76 from Ind_rec where Ind_code='" & Trim(ind_code) & "' And dateadd(d,276,dt1)>='" & Sqlrd.GetDateTime(0).ToString("dd MMM yyyy") & "' order by dateadd(d,276,dt1)"
                            sqlcon1 = New SqlConnection(constr)
                            sqlcon1.Open()
                            Sqlcom = New SqlCommand(strsql, sqlcon1)
                            sqlrd1 = Sqlcom.ExecuteReader
                            If sqlrd1.Read Then
                                tmp_idx = sqlrd1(0)
                                Iprw(10) = Math.Round(tmp_idx, 4) 'done
                                Iprw(8) = Math.Round(((prev_idx_value / prev_idx) - (WtrAmt / tmp_idx)) * tmp_idx, 2) 'done
                                prev_idx_value = Iprw(8) 'done
                                prev_idx = tmp_idx
                            Else
                                Iprw(8) = 0 'done
                            End If
                            sqlcon1.Close()
                            sqlcon1.Dispose()
                            amt_swp = Iprw(9) 'done
                            swp_amt = Iprw(7) 'done
                        End If
                        Ipdt.Rows.Add(Iprw)
                        Temp = Temp + Amt
                        j += 1
                        Arrcount += 1
                        rowcount += 1

                        If ddwperiod.SelectedItem.Text <> "Fortnightly" Then
                            If SplitCustom(Sqlrd(0), "-")(0) < SWP_date Then
                                chkdate = CDate(SWP_date & "/" & SplitCustom(Sqlrd(0), "/")(1) & "/" & SplitCustom(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
                            Else
                                chkdate = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
                                Tempdtstr = SplitCustom(chkdate, "/")
                                chkdate = CDate(SWP_date & "/" & Tempdtstr(1) & "/" & Tempdtstr(2))
                            End If
                        Else
                            chkdate = DateAdd(DateInterval.Day, PrdVal, chkdate)
                        End If
                    End If
                Loop While Sqlrd.Read
            End If
            Sqlcon.Close()
            Sqlcon.Dispose()

            '''''''''strsql = "Select Top 10 (ind_val-53)/76,dateadd(d,276,dt1) from Ind_rec where Ind_code=(Select distinct ind_code from schemeindex where sch_code='" & ddwscname.SelectedItem.Value & "') And dateadd(d,276,dt1)>='" & fmt(txtwvaldate.Text) & "' order by dateadd(d,276,dt1)"
            '''''''''sqlcon1 = New SqlConnection(constr)
            '''''''''sqlcon1.Open()
            '''''''''Sqlcom = New SqlCommand(strsql, sqlcon1)
            '''''''''sqlrd1 = Sqlcom.ExecuteReader
            '''''''''If sqlrd1.Read Then
            '''''''''    Do
            '''''''''        strsql = "Select dateadd(d,276,date),(nav_rs-53)/76 from nav_rec where sch_code ='" & ddwscname.SelectedItem.Value & "' And dateadd(d,276,date)='" & sqlrd1(1) & "'"
            '''''''''        Sqlcon = New SqlConnection(constr)
            '''''''''        Sqlcon.Open()
            '''''''''        Sqlcom = New SqlCommand(strsql, Sqlcon)
            '''''''''        Sqlrd = Sqlcom.ExecuteReader
            '''''''''        If Sqlrd.Read Then
            '''''''''            If IsDBNull(Sqlrd(0)) = False Then
            '''''''''                Iprw = Ipdt.NewRow
            '''''''''                Iprw(0) = Format(CDate(Sqlrd(0)), "dd-MMM-yyyy")
            '''''''''                Iprw(1) = Math.Round(Sqlrd(1) - (Sqlrd(1) * Val(txtSWP_EntryLoad.Text) / 100), 4)
            '''''''''                Exit Do
            '''''''''            End If
            '''''''''        End If
            '''''''''        Sqlcon.Close()
            '''''''''        Sqlcon.Dispose()
            '''''''''    Loop While sqlrd1.Read
            '''''''''    ReDim Preserve DtArr(Arrcount)
            '''''''''    DtArr(Arrcount) = Format(CDate(Iprw(0)), "MM/dd/yyyy")
            '''''''''    Iprw(2) = Math.Round(LastUnits, 4)
            '''''''''    Iprw(3) = Math.Round(Iprw(1) * Iprw(2), 2)
            '''''''''    ReDim Preserve CshFlow(Arrcount)
            '''''''''    CshFlow(Arrcount) = Iprw(3)
            '''''''''    LastCash = Iprw(3)
            '''''''''    Ipdt.Rows.Add(Iprw)
            '''''''''    Arrcount += 1
            '''''''''End If
            '''''''''sqlcon1.Close()
            '''''''''sqlcon1.Dispose()


            '****vishal calculate present vaule as per last available date b4 as on date
            Dim lastAvail_Date As String
            Dim lastAvail_PresentValue As String
            lastAvail_Date = fmt(txtwvaldate.Text)
            strsql = "Select Top 1 (ind_val-53)/76,dateadd(d,276,dt1) from Ind_rec where Ind_code='" & Trim(ind_code) & "' And dateadd(d,276,dt1)<='" & Date.Parse(txtwvaldate.Text).ToString("dd MMM yyyy") & "' order by dateadd(d,276,dt1) desc"
            sqlcon1 = New SqlConnection(constr)
            sqlcon1.Open()
            Sqlcom = New SqlCommand(strsql, sqlcon1)
            sqlrd1 = Sqlcom.ExecuteReader
            sqlcon1 = New SqlConnection(constr)
            sqlcon1.Open()
            Sqlcom = New SqlCommand(strsql, sqlcon1)
            sqlrd1 = Sqlcom.ExecuteReader
            If sqlrd1.Read Then
                If IsDBNull(sqlrd1) = False Then
                    lastAvail_PresentValue = sqlrd1(0)
                    lastAvail_Date = sqlrd1(1)
                End If
            End If
            sqlcon1.Close()
            sqlcon1.Dispose()


            '********** MANISH **********
            Dim swp_dt_as_on As String
            Dim swp_dt_as_on_value As String
            strsql = "Select Top 1 (ind_val-53)/76,dateadd(d,276,dt1) from Ind_rec where Ind_code='" & Trim(ind_code) & "' And dateadd(d,276,dt1)<='" & Date.Parse(txtwvaldate.Text).ToString("dd MMM yyyy") & "' order by dateadd(d,276,dt1) desc"
            sqlcon1 = New SqlConnection(constr)
            sqlcon1.Open()
            Sqlcom = New SqlCommand(strsql, sqlcon1)
            sqlrd1 = Sqlcom.ExecuteReader
            If sqlrd1.Read Then
                If IsDBNull(sqlrd1) = False Then
                    swp_dt_as_on_value = sqlrd1(0)
                    swp_dt_as_on = sqlrd1(1)
                End If
            End If
            sqlcon1.Close()
            sqlcon1.Dispose()

            '//vishal if value as on date is not available then ,keep last available present value 
            If swp_dt_as_on = "" And swp_dt_as_on_value = "" Then
                swp_dt_as_on = lastAvail_Date
                swp_dt_as_on_value = lastAvail_PresentValue
            End If





            'strsql = "Select top 1 dateadd(d,276,date),(nav_rs-53)/76 from nav_rec where sch_code ='" & ddwscname.SelectedItem.Value & "' And dateadd(d,276,date)='" & swp_dt_as_on & "' order by dateadd(d,276,date) desc"
            'commented by syed less than equal with latest index date, because some index declared on sunday and monday but corrosponding scheme does't declare nav on that day
            'strsql = "Select top 1 dateadd(d,276,date),(nav_rs-53)/76 from nav_rec where sch_code ='" & ddwscname.SelectedItem.Value & "' And dateadd(d,276,date)='" & swp_dt_as_on & "' order by dateadd(d,276,date) "
            strsql = "Select top 1 dateadd(d,276,date),(nav_rs-53)/76 from nav_rec where sch_code ='" & ddwscname.SelectedItem.Value & "' And dateadd(d,276,date)<='" & Date.Parse(swp_dt_as_on).ToString("dd MMM yyyy") & "' order by dateadd(d,276,date) desc"

            Sqlcon = New SqlConnection(constr)
            Sqlcon.Open()
            Sqlcom = New SqlCommand(strsql, Sqlcon)
            Sqlrd = Sqlcom.ExecuteReader
            If Sqlrd.Read Then
                If IsDBNull(Sqlrd(0)) = False Then
                    Iprw = Ipdt.NewRow
                    Iprw(0) = Format(CDate(Sqlrd(0)), "dd-MMM-yyyy")
                    Iprw(3) = Math.Round(Sqlrd(1) - (Sqlrd(1) * Val(txtSWP_EntryLoad.Text) / 100), 4) 'done

                End If
            End If
            Sqlcon.Close()
            Sqlcon.Dispose()

            ReDim Preserve DtArr(Arrcount)
            DtArr(Arrcount) = Format(CDate(Iprw(0)), "dd/MM/yyyy")
            ''commented on 28 oct 14
            ''DtArr(Arrcount) = Format(CDate(Iprw(0)), "MM/dd/yyyy")

            Iprw(5) = Math.Round(LastUnits, 4) 'done
            Iprw(2) = Math.Round(Iprw(3) * Iprw(5), 2) 'done
            swp_amt = Iprw(2) 'new feb
            ReDim Preserve CshFlow(Arrcount)
            CshFlow(Arrcount) = Iprw(2) 'done
            LastCash = Iprw(2) 'done
            Ipdt.Rows.Add(Iprw)
            Arrcount += 1

            sqlcon1.Close()
            sqlcon1.Dispose()

            'Ipdt.Columns.RemoveAt(9) 'new feb
            'Ipdt.Columns.RemoveAt(9) 'new feb

            Dgswp.DataSource = Ipdt
            Dgswp.DataBind()
            Dgswp.Visible = True

            Dim Dt As String = ""
            Dim cashflw As String = ""
            Dim cashindx As String = ""

            If IsNothing(CshFlow) = False Then
                For i = 0 To UBound(CshFlow)
                    If Dt = "" Then
                        Dt = Format(DtArr(i), "dd/MM/yyyy")
                    Else
                        If CshFlow(i) <> 0 Then
                            Dt = Dt & "," & Format(DtArr(i), "dd/MM/yyyy")
                        End If
                    End If
                    If cashflw = "" Then
                        cashflw = CshFlow(i)
                    Else
                        If CshFlow(i) <> 0 Then
                            cashflw = cashflw & "," & CshFlow(i)
                        End If
                    End If
                Next i
            End If

            If Sqlcon.State = ConnectionState.Open Then
                Sqlcon.Close()
            End If

            'Dt = Dt & "," & CDate(fmt(txtwvaldate.Text))
            'cashflw = cashflw & "," & (LastCash) * -1
            getXirr = XIRR(Dt, cashflw)

            '---------MANISH
            'If (swp_amt - amt_swp) = 0 Then
            '    txtwAbsRet.Text = 0
            'Else
            '    'txtwAbsRet.Text = Math.Round((swp_amt - amt_swp) * 100 / amt_swp, 2) & "%"

            '    txtwAbsRet.Text = Math.Round((swp_amt - amt_swp) * 100 / Trim(txtwinamt.Text), 2) & "%"
            'End If

            txtwAbsRet.Text = Math.Round((swp_amt + AmtWidrlTillDate - Trim(txtwinamt.Text)) * 100 / Trim(txtwinamt.Text), 2) & "%"

            txtwyield.Text = Math.Round(getXirr, 2) & "%"


            Dgswp.DataSource = Ipdt
            Dgswp.DataBind()
            Dgswp.Visible = True
            btnwexport.Enabled = True

            '//charting vishal
            tblChart.Visible = False
            HttpContext.Current.Session("SWP_Chart_Image") = ""
            'HttpContext.Current.Session("SIP_Chart_Image") = ""
            If chkChart_SWP.Checked = True Then
                Dim datatbl_swp As DataTable
                datatbl_swp = Ipdt.Copy
                'Call formatTable4Chart(datatbl_swp, True, 1, 0, True, , "Nav,Units,CashFlow,CashFlow(Index),Index", "Amount,SWP Value,Index Value")
                Call formatTable4Chart(datatbl_swp, True, 1, 0, True,
                                       , "Amount Invested,Amount Withdrawn,Amount Invested,NAV,Unit Sold,Balance Units,Amount Withdrawn till date,Index")

                Session("ChartData_SIP") = datatbl_swp

                datatbl_swp.Columns("Value of Balance Units").ColumnName = "SWP Value" 'new feb
                hdIsGraphExist.Value = 1
                'Add by syed

                hdChartData.Value = "SWP"
                'End ny syed

                Dim sipChart As WebChart.ChartControl = New WebChart.ChartControl
                Call drawChart(sipChart, datatbl_swp, "SWP", CDbl(txtwtramt.Text))
                'add by syed
                HdGraphImgPath.Value = HttpContext.Current.Session("SWP_Chart_Image")
                HttpContext.Current.Session("All_Chart_Image") = ""
                HttpContext.Current.Session("All_Chart_Image_Ie8") = HttpContext.Current.Session("SWP_Chart_Image") + ".png"
                HttpContext.Current.Session("IsChartExist") = True
                ''end
                tblChart.Visible = True
                'hdIsGraphExist.Value = "1"
            Else
                hdChartData.Value = "0"
                HttpContext.Current.Session("IsChartExist") = False

                'hdIsGraphExist.Value = "0"
            End If

            'btnwexport.Attributes.Add("onClick", "javascript:newexports('Dgswp','Dgswp',2,'" & Val(txtwyield.Text) & "',' ','" & txtwAbsRet.Text & "',' ','" & ddwscname.SelectedItem.Text & "');return false;")
            'btnwexport.Attributes.Add("onClick", "javascript:newexports('Dgswp','Dgswp',2,'" & txtwyield.Text & "',' ','" & txtwAbsRet.Text & "',' ','" & ddwscname.SelectedItem.Text & "');return false;")

            '//charting vishal
            If chkChart_SWP.Checked = True Then
                tblChart.Visible = True
            End If

            ''PSwpDisclamer



            PSwpDisclamer.InnerHtml = "<p><u>Note:</u> Past performance may or may not be sustained in future. It is assumed that a SWP of " + txtwtramt.Text + " each executed on " + ddSWPDate.SelectedItem.Text + " of every " + ddwperiod.SelectedItem.Text.Substring(0, ddwperiod.SelectedItem.Text.Length - 2).ToLower() + " including the first withdrawal from the selected scheme. Yield of Scheme is annualized and cumulative investment return for cash flows resulting out of uniform and " + ddwperiod.SelectedItem.Text.ToLower() + " withdrawal have been worked out using XIRR calculation. Load has not been taken into consideration.</p>"

        Catch ex As Exception
            Ipdt.Rows.Clear()
            Dgswp.Visible = False
            tblChart.Visible = False
            txtwyield.Text = ""
            txtwAbsRet.Text = ""
            tblSWP1.Visible = False
            btnwexport.Enabled = False
            Response.Write("<script>alert(""Error on fetching report. Please contact Nippon India Mutual Fund team."" )</script>")
        Finally
            SetHtmlSWP()

        End Try
    End Sub

    Private Sub ddscheme_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddscheme.SelectedIndexChanged
        'hdIsGraphExist.Value = "0"
        'Dim Eq_flag As Boolean
        ''Add by syed
        hdChartData.Value = 0
        '' end add syed
        '''commented by 31 Oct 2014
        'strsql = "Select nature from Scheme_info where mut_code in ('" & Replace(mut_code, ",", "','") & "') and sch_code='" & ddscheme.SelectedItem.Value & "'"
        'Sqlcon = New SqlConnection(constr)
        'Sqlcon.Open()
        'Sqlcom = New SqlCommand(strsql, Sqlcon)
        'Sqlrd = Sqlcom.ExecuteReader
        'If Sqlrd.Read Then
        '    If LCase(Sqlrd(0)) = LCase("equity") Then
        '        Eq_flag = True
        '    End If
        'End If
        'strsql = "" : Sqlcon.Close() : Sqlrd.Close() : Sqlcom.Dispose()

        'If Eq_flag = True Then
        '    For i = 0 To ddlsipbnmark.Items.Count - 1
        '        If ddlsipbnmark.Items(i).Text = ConfigurationSettings.AppSettings("EQUITYSCHEME").ToString() Then
        '            ddlsipbnmark.SelectedIndex = i
        '            ddlsipbnmark1.SelectedIndex = i
        '            Exit For
        '        End If
        '    Next i
        'Else
        '    strsql = "Select ind_name,ind_code from ind_info where ind_code=(Select distinct top 1 ind_code from schemeindex where sch_code='" & ddscheme.SelectedItem.Value & "' and ind_code not in ('" & Replace(disply_ind_code, ",", "','") & "'))"
        '    Sqlcon = New SqlConnection(constr)
        '    Sqlcon.Open()
        '    Sqlcom = New SqlCommand(strsql, Sqlcon)
        '    Sqlrd = Sqlcom.ExecuteReader
        '    If Sqlrd.Read Then
        '        For i = 0 To ddlsipbnmark.Items.Count
        '            If ddlsipbnmark.Items(i).Text = Sqlrd(0) Then
        '                ddlsipbnmark.SelectedIndex = i
        '                ddlsipbnmark1.SelectedIndex = i
        '                Exit For
        '            End If
        '        Next i
        '    End If
        'End If
        ''end commented by 31 Oct 2014


        'comment for TRI change
        'strsql = "Select ind_name,ind_code from ind_info where ind_code=(Select distinct top 1 ind_code from schemeindex where sch_code='" & ddscheme.SelectedItem.Value & "' and ind_code not in ('" & Replace(disply_ind_code, ",", "','") & "'))"



        If Scheme_Not_to_Display_Index.Split(",").Where(Function(c) c = ddscheme.SelectedItem.Value).Any() = False Then
            strsql = "Select ind_name,ind_code from ind_info where REPLACE(ind_name,' ','')= REPLACE((Select ind_name from ind_info where ind_code=(Select distinct top 1 ind_code from schemeindex where sch_code='" & ddscheme.SelectedItem.Value & "' and ind_code not in ('" & Replace(disply_ind_code, ",", "','") & "')))+ ' TRI',' ','')"
            Sqlcon = New SqlConnection(constr)
            Sqlcon.Open()
            Sqlcom = New SqlCommand(strsql, Sqlcon)
            Sqlrd = Sqlcom.ExecuteReader
            If Sqlrd.Read Then
                For i = 0 To ddlsipbnmark.Items.Count
                    If ddlsipbnmark.Items(i).Text = Sqlrd(0) Then
                        ddlsipbnmark.SelectedIndex = i
                        ddlsipbnmark1.SelectedIndex = i
                        Exit For
                    End If
                Next i
            Else
                strsql = "Select ind_name,ind_code from ind_info where ind_code=(Select distinct top 1 ind_code from schemeindex where sch_code='" & ddscheme.SelectedItem.Value & "' and ind_code not in ('" & Replace(disply_ind_code, ",", "','") & "'))"
                Sqlcon = New SqlConnection(constr)
                Sqlcon.Open()
                Sqlcom = New SqlCommand(strsql, Sqlcon)
                Sqlrd = Sqlcom.ExecuteReader
                If Sqlrd.Read Then
                    For i = 0 To ddlsipbnmark.Items.Count
                        If ddlsipbnmark.Items(i).Text = Sqlrd(0) Then
                            ddlsipbnmark.SelectedIndex = i
                            ddlsipbnmark1.SelectedIndex = i
                            Exit For
                        End If
                    Next i
                End If
            End If
        Else
            ddlsipbnmark.SelectedIndex = 0
        End If
    End Sub

    ''Private Sub btnwexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Private Overloads Sub btnwexport_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnwexport.Click
        If Dgswp.Items.Count < 1 Then
            Response.Write("<script>alert(""No Data To Save Please Try Again"")</script>")
        Else
            Call SaveToExcel_SWP2(Response, Dgswp, txtwAbsRet.Text, txtwyield.Text, ddwscname.SelectedItem.Text, ddwbnmark.SelectedItem.Text, PSwpDisclamer.InnerHtml)
        End If
    End Sub


    ''Private Sub cmdexp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Private Overloads Sub cmdexp_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdexp.Click
        If Gsp.Items.Count < 1 Then
            Response.Write("<script>alert(""No Data To Save Please Try Again"")</script>")
        Else
            Call SaveToExcel_SIP2(Response, Gsp, txtonttm.Text, txtxsch.Text, txtxind.Text, ddscheme.SelectedItem.Text, ddlsipbnmark.SelectedItem.Text, Session("Entry_Load1"), PSipDisclamer.InnerHtml)
        End If
    End Sub

    Protected Sub SetHtmlSIP()
        Dim stringWrite As System.IO.StringWriter
        Dim htmlWrite As System.Web.UI.HtmlTextWriter
        Dim HtmlContent As String
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
        Dim dt As New DataTable()

        Dim dgrid As DataGrid

        Dim disclaimer As String
        Dim disclaimer1 As String
        Dim Notes As String

        Notes = PSipDisclamer.InnerText

        'Notes = Notes.Replace("first", "             first")
        'Notes = Notes.Replace("out", "   out")


        disclaimer1 = "Disclaimer :"

        'disclaimer = "NAM India/NIMF/Trustees does not take the responsibility, liability and undertake the authenticity of the figures calculated on the basis of calculator provided herein for calculations towards prospective investments.Developed and Maintained by ICRA Analytics Ltd. The data content provided is obtained from sources considered to be authentic and reliable. However, ICRA Analytics Ltd. is not responsible for any error or inaccuracy or for any losses suffered on account of information."
        disclaimer = "<table class='' cellspacing='0' cellpadding='0' width='950px'
                                    align='center' border='0' style='width 950px !important'>
                                    <tr>
                                        <td colspan='2'>
                                            <table cellspacing='0' cellpadding='0' width='950px'
                                                border='0'>
                                                <tr>
                                                    <td class='txt2' style='font-size 12px; text-align: justify;
                                                        line-height:  16px;'>Copyright 2017 Nippon India Mutual
                                                        Fund. All Rights Reserved.
                                                    </td>
                                                    <td class='txt2'>
                                                        <!--Developed by <a href='http//www.icraonline.com' target='_blank' style='COLOR: #939498'>
												ICRA Online Ltd.</a>-->
                                                    </td>
                                                </tr>
                                            </table>
                                            <table cellspacing='0' cellpadding='0' width='100%'
                                                align='center' border='0'>
                                                <tr>
                                                    <td style='font-size 12px; text-align: justify; color: #939498;
                                                        line-height:  16px;'>
                                                        <p>
                                                            Nippon India Mutual Fund does not take the responsibility,
                                                            liability and undertake the
                                                        authenticity of the figures calculated on the basis of
                                                            calculator provided herein
                                                        for calculations towards prospective investments.Developed
                                                            and Maintained by <a href='http//www.icraanalytics.com'
                                                                target='_blank' style='color: #939498'><b>ICRA Analytics Limited</b></a> The data
                                                        content provided is obtained from sources considered to
                                                            be authentic and reliable.
                                                        However, ICRA Analytics Limited is not responsible for any error
                                                            or inaccuracy or for
                                                        any losses suffered on account of information.
                                                        </p>
                                                        <p>
                                                            The Calculators/Tools/Planners are designed to assist
                                                            you in determining the appropriate amount. These Calculators/Tools/Planners
                                                            alone are not sufficient and shouldn’t be used for
                                                            the development or implementation of an investment
                                                            strategy. The investor is advised to consult his or
                                                            her financial advisor prior to arriving at any investment
                                                            decision.
                                                        </p>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>"
        Dim imagePath As String
        Dim imagePath1 As String

        'For Each item As DataGridItem In Gsp.Items
        '    Dim dr As DataRow = dt.NewRow()
        '    For s As Integer = 1 To item.Cells.Count
        '        dr(s) = item.Cells(s).Text

        '    Next
        '    dt.Rows.Add(dr)
        'Next

        'dgrid.DataSource = dt
        'dgrid.DataBind()


        dgrid = Gsp

        If dgrid.Items.Count < 1 Then
            Exit Sub
        End If

        '//data grid formatting before exporting
        'dgrid.Font.Name = "Arial"
        'dgrid.Font.Size = System.Web.UI.WebControls.FontUnit.Point(8)
        'dgrid.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid
        'dgrid.BorderWidth = New Unit(2, UnitType.Pixel)

        'dgrid.HeaderStyle.BackColor = System.Drawing.Color.Red
        'dgrid.HeaderStyle.ForeColor = System.Drawing.Color.White
        'dgrid.HeaderStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
        'dgrid.HeaderStyle.Wrap = False
        'dgrid.HeaderStyle.Font.Bold = True
        'dgrid.GridLines = GridLines.Both
        'dgrid.BorderColor = System.Drawing.Color.Gray



        'dgrid.Items(0).Width = New Unit(CDbl(200))

        stringWrite = New System.IO.StringWriter

        imagePath = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "") & "\images\reliance-mutual-fund.png"

        HtmlContent = "<div id='PDFSIP1'><img  src='" & imagePath & "' width='550' height='70' border='0'>"
        HtmlContent += "<br>"

        HtmlContent += "<br>"
        HtmlContent += "<br>"

        Sch_Name = "Scheme " & " : " & "&nbsp;&nbsp;" & ddscheme.SelectedItem.Text
        B_Mark = "Benchmark Index " & " : " & "&nbsp;&nbsp;" & ddlsipbnmark.SelectedItem.Text
        E_Load = "Entry Load " & " : " & "&nbsp;&nbsp;" & Session("Entry_Load1")

        HtmlContent += "<b><font size='3' face='verdana' color='#000000'>" & "" & Sch_Name & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & "" & " </font></b> "
        HtmlContent += "<b><font size='3' face='verdana' color='#000000'>" & "" & E_Load & "" & "</font> </b> "
        HtmlContent += "<br>"
        HtmlContent += "<b><font size='3' face='verdana' color='#000000'>" & "" & B_Mark & "" & " </font></b> "
        HtmlContent += "<br>"
        HtmlContent += "<br>"
        HtmlContent += "<br>"
        HtmlContent += "<br>"
        HtmlContent += "<br>"




        'HtmlContent += "<font size='1' face='Arial'>"
        htmlWrite = New HtmlTextWriter(stringWrite)
        dgrid.RenderControl(htmlWrite)
        HtmlContent += stringWrite.ToString()


        Returns = "Abs. Return (Scheme): " & txtonttm.Text
        Xirr = "Yield (Scheme): " & txtxsch.Text
        Xirr1 = "Yield (Index): " & txtxind.Text

        HtmlContent += "<br>"
        HtmlContent += "<b><font size='3' face='verdana' color='#000000'>" & "" & Returns & "" & "</font> </b> "
        HtmlContent += "<br>"
        HtmlContent += "<b><font size='3' face='verdana' color='#000000'>" & "" & Xirr & "" & " </font></b> "

        HtmlContent += "<br>"
        HtmlContent += "<b><font size='3' face='verdana' color='#000000'>" & "" & Xirr1 & "" & " </font></b> "
        stringWrite2 = New System.IO.StringWriter

        Dim chartImagePath As String

        If HttpContext.Current.Session("All_Chart_Image") <> "" Then
            HtmlContent += "<img  src='" & HttpContext.Current.Session("All_Chart_Image") & "' width='700' height='420' border='0'>"
            HtmlContent += "<br>"
        End If

        HtmlContent += "<br><div id='sipNotes'>" & Notes & "</div>"

        HtmlContent += "<br><b><left><font size='3' face='verdana' color='#ff0000'> " & disclaimer1 & "</font></left></b>"
        HtmlContent += "<br>"
        HtmlContent += "<table align='top'><tr height='9' style='height:9.0pt'><td colspan='3' rowspan='5' height='54' class='xl40' width='450' style='height:54.0pt;width:700pt'><font size='2' face='Arial' color='black'>" & disclaimer & "</font></td></tr><table>"

        PDFSIP.InnerHtml = HtmlContent
    End Sub

    Protected Sub SetHtmlSWP()

        Dim stringWrite As System.IO.StringWriter
        Dim htmlWrite As System.Web.UI.HtmlTextWriter
        Dim dgrid As DataGrid

        Dim HtmlContent As String

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

        Dim Notes As String

        Notes = PSwpDisclamer.InnerHtml


        disclaimer1 = "Disclaimer :"

        disclaimer = "<table class='' cellspacing='0' cellpadding='0' width='950px'
                                    align='center' border='0' style='width 950px !important'>
                                    <tr>
                                        <td colspan='2'>
                                            <table cellspacing='0' cellpadding='0' width='950px'
                                                border='0'>
                                                <tr>
                                                    <td class='txt2' style='font-size 12px; text-align: justify;
                                                        line-height:  16px;'>Copyright 2017 Nippon India Mutual
                                                        Fund. All Rights Reserved.
                                                    </td>
                                                    <td class='txt2'>
                                                        <!--Developed by <a href='http//www.icraonline.com' target='_blank' style='COLOR: #939498'>
												ICRA Online Ltd.</a>-->
                                                    </td>
                                                </tr>
                                            </table>
                                            <table cellspacing='0' cellpadding='0' width='100%'
                                                align='center' border='0'>
                                                <tr>
                                                    <td style='font-size 12px; text-align: justify; color: #939498;
                                                        line-height:  16px;'>
                                                        <p>
                                                            Nippon India Mutual Fund does not take the responsibility,
                                                            liability and undertake the
                                                        authenticity of the figures calculated on the basis of
                                                            calculator provided herein
                                                        for calculations towards prospective investments.Developed
                                                            and Maintained by <a href='http//www.icraanalytics.com'
                                                                target='_blank' style='color: #939498'><b>ICRA Analytics Limited</b></a> The data
                                                        content provided is obtained from sources considered to
                                                            be authentic and reliable.
                                                        However, ICRA Analytics Limited is not responsible for any error
                                                            or inaccuracy or for
                                                        any losses suffered on account of information.
                                                        </p>
                                                        <p>
                                                            The Calculators/Tools/Planners are designed to assist
                                                            you in determining the appropriate amount. These Calculators/Tools/Planners
                                                            alone are not sufficient and shouldn’t be used for
                                                            the development or implementation of an investment
                                                            strategy. The investor is advised to consult his or
                                                            her financial advisor prior to arriving at any investment
                                                            decision.
                                                        </p>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>"

        dgrid = Dgswp

        If dgrid.Items.Count < 1 Then
            Exit Sub
        End If

        '//data grid formatting before exporting
        'dgrid.Font.Name = "Arial"
        'dgrid.Font.Size = System.Web.UI.WebControls.FontUnit.Point(8)
        'dgrid.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid
        'dgrid.BorderWidth = New Unit(2, UnitType.Pixel)
        'dgrid.HeaderStyle.BackColor = System.Drawing.Color.Red
        'dgrid.HeaderStyle.ForeColor = System.Drawing.Color.White
        'dgrid.HeaderStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
        'dgrid.HeaderStyle.Wrap = False
        'dgrid.HeaderStyle.Font.Bold = True
        'dgrid.GridLines = GridLines.Both
        'dgrid.BorderColor = System.Drawing.Color.Gray

        stringWrite = New System.IO.StringWriter

        imagePath = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "") & "\images\reliance-mutual-fund.png"

        HtmlContent = "<div id='PDFSWP1'><img  src='" & imagePath & "' width='550' height='70' border='0'>"
        HtmlContent += "<br>"
        HtmlContent += "<br>"

        Sch_Name = "Scheme " & " : " & "&nbsp;&nbsp;" & ddwscname.SelectedItem.Text
        B_Mark = "Benchmark Index " & " : " & "&nbsp;&nbsp;" & ddwbnmark.SelectedItem.Text

        HtmlContent += "<b><font size='3' face='verdana' color='#000000'>" & "" & Sch_Name & "" & " </font></b> "
        HtmlContent += "<br>"
        HtmlContent += "<b><font size='3' face='verdana' color='#000000'>" & "" & B_Mark & "" & " </font></b> "
        HtmlContent += "<br>"
        HtmlContent += "<br>"
        HtmlContent += "<br>"
        HtmlContent += "<br>"
        HtmlContent += "<br>"


        'HtmlContent += "<font size='1' face='Arial'>"
        htmlWrite = New HtmlTextWriter(stringWrite)
        dgrid.RenderControl(htmlWrite)
        HtmlContent += stringWrite.ToString()


        HtmlContent += "<br>"
        Returns = "Abs.Return : " & txtwAbsRet.Text
        Xirr = "Yield(Scheme) : " & txtwyield.Text

        HtmlContent += "<br>"
        HtmlContent += "<b><font size='3' face='verdana' color='#000000'>" & "" & Returns & "" & " </font></b> "
        HtmlContent += "<br>"
        HtmlContent += "<b><font size='3' face='verdana' color='#000000'>" & "" & Xirr & "" & " </font></b> "

        If HttpContext.Current.Session("All_Chart_Image") <> "" Then
            HtmlContent += "<img  src='" & HttpContext.Current.Session("All_Chart_Image") & "' width='700' height='420' border='0'>"
            HtmlContent += "<br>"
        End If

        HtmlContent += "<br><div>" & Notes & "</div>"

        HtmlContent += "<br><b><left><font size='3' face='verdana' color='#ff0000'> " & disclaimer1 & "</font></left></b>"
        HtmlContent += "<table align='top'><tr height='9' style='height:9.0pt'><td colspan='3' rowspan='5' height='54' class='xl40' width='450' style='height:54.0pt;width:700pt'><font size='2' face='Arial' color='black'>" & disclaimer & "</font></td></tr><table>"


        PDFSWP.InnerHtml = HtmlContent

    End Sub

    Protected Sub SetHtmlSTP()
        Dim stringWrite As System.IO.StringWriter
        Dim htmlWrite As System.Web.UI.HtmlTextWriter
        Dim dgrid1 As DataGrid
        Dim dgrid2 As DataGrid
        Dim stringWrite2 As System.IO.StringWriter
        Dim htmlWrite2 As System.Web.UI.HtmlTextWriter
        Dim HtmlContent As String
        Dim Filename As String
        Dim font_Size As Integer = 8
        Dim address1 As String
        Dim Returns As String
        Dim Returns1 As String
        Dim Xirr As String
        Dim ToShc As String
        Dim FromSch As String
        Dim TransAmt As String
        Dim imagePath As String
        Dim imagePath1 As String
        Dim disclaimer As String
        Dim disclaimer1 As String

        Dim Notes As String

        Notes = PStpDisclamer.InnerHtml



        disclaimer1 = "Disclaimer :"
        dgrid1 = Dstp
        dgrid2 = Dstp1
        disclaimer = "<table class='' cellspacing='0' cellpadding='0' width='950px'
                                    align='center' border='0' style='width 950px !important'>
                                    <tr>
                                        <td colspan='2'>
                                            <table cellspacing='0' cellpadding='0' width='950px'
                                                border='0'>
                                                <tr>
                                                    <td class='txt2' style='font-size 12px; text-align: justify;
                                                        line-height:  16px;'>Copyright 2017 Nippon India Mutual
                                                        Fund. All Rights Reserved.
                                                    </td>
                                                    <td class='txt2'>
                                                        <!--Developed by <a href='http//www.icraonline.com' target='_blank' style='COLOR: #939498'>
												ICRA Online Ltd.</a>-->
                                                    </td>
                                                </tr>
                                            </table>
                                            <table cellspacing='0' cellpadding='0' width='100%'
                                                align='center' border='0'>
                                                <tr>
                                                    <td style='font-size 12px; text-align: justify; color: #939498;
                                                        line-height:  16px;'>
                                                        <p>
                                                            Nippon India Mutual Fund does not take the responsibility,
                                                            liability and undertake the
                                                        authenticity of the figures calculated on the basis of
                                                            calculator provided herein
                                                        for calculations towards prospective investments.Developed
                                                            and Maintained by <a href='http//www.icraanalytics.com'
                                                                target='_blank' style='color: #939498'><b>ICRA Analytics Limited</b></a> The data
                                                        content provided is obtained from sources considered to
                                                            be authentic and reliable.
                                                        However, ICRA Analytics Limited is not responsible for any error
                                                            or inaccuracy or for
                                                        any losses suffered on account of information.
                                                        </p>
                                                        <p>
                                                            The Calculators/Tools/Planners are designed to assist
                                                            you in determining the appropriate amount. These Calculators/Tools/Planners
                                                            alone are not sufficient and shouldn’t be used for
                                                            the development or implementation of an investment
                                                            strategy. The investor is advised to consult his or
                                                            her financial advisor prior to arriving at any investment
                                                            decision.
                                                        </p>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>"
        If dgrid1.Items.Count < 1 Then
            Exit Sub
        End If

        '//data grid formatting before exporting
        'dgrid1.Font.Name = "Arial"
        'dgrid1.Font.Size = System.Web.UI.WebControls.FontUnit.Point(8)
        'dgrid1.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid
        'dgrid1.BorderWidth = New Unit(2, UnitType.Pixel)
        'dgrid1.HeaderStyle.BackColor = System.Drawing.Color.Red
        'dgrid1.HeaderStyle.ForeColor = System.Drawing.Color.White
        'dgrid1.HeaderStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
        'dgrid1.HeaderStyle.Wrap = False
        'dgrid1.HeaderStyle.Font.Bold = True
        'dgrid1.GridLines = GridLines.Both
        'dgrid1.BorderColor = System.Drawing.Color.Gray

        'dgrid2.Font.Name = "Arial"
        'dgrid2.Font.Size = System.Web.UI.WebControls.FontUnit.Point(8)
        'dgrid2.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid
        'dgrid2.BorderWidth = New Unit(2, UnitType.Pixel)
        'dgrid2.HeaderStyle.BackColor = System.Drawing.Color.Red
        'dgrid2.HeaderStyle.ForeColor = System.Drawing.Color.White
        'dgrid2.HeaderStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
        'dgrid2.HeaderStyle.Wrap = False
        'dgrid2.HeaderStyle.Font.Bold = True
        'dgrid2.GridLines = GridLines.Both
        'dgrid2.BorderColor = System.Drawing.Color.Gray

        stringWrite = New System.IO.StringWriter

        imagePath = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "") & "\images\reliance-mutual-fund.png"

        HtmlContent = "<div id='PDFSTP1'><img  src='" & imagePath & "' width='550' height='70' border='0'>"
        HtmlContent += "<br>"

        HtmlContent += "<br>"
        TransAmt = "STP :" & "&nbsp;&nbsp;" & "Rs." & txttranamt.Text & "/- To be Transferred " & " " & ddperiod.SelectedItem.Text
        ToShc = "Transferor  :" & "&nbsp;&nbsp;&nbsp;&nbsp; " & ddtrfrom.SelectedItem.Text
        FromSch = "Transferee  :" & "&nbsp;&nbsp;&nbsp;&nbsp; " & ddtrto.SelectedItem.Text
        HtmlContent += "<b><font size='3' face='verdana' color='#000000'>" & "" & TransAmt & "" & " </b> </font>"
        HtmlContent += "<br>"
        HtmlContent += "<b><font size='3' face='verdana' color='#000000'>" & "" & ToShc & "" & " </b> </font>"
        HtmlContent += "<br>"
        HtmlContent += "<b><font size='3' face='verdana' color='#000000'>" & "" & FromSch & "" & " </b> </font>"
        'HtmlContent += "<font size='1' face='Arial'>"
        HtmlContent += "<br>"
        HtmlContent += "<br>"
        HtmlContent += "<br>"

        htmlWrite = New HtmlTextWriter(stringWrite)
        dgrid1.RenderControl(htmlWrite)
        HtmlContent += stringWrite.ToString()

        HtmlContent += "<br>"

        '//Export summary report

        stringWrite2 = New System.IO.StringWriter
        htmlWrite2 = New HtmlTextWriter(stringWrite2)
        HtmlContent += "<br>"
        htmlWrite = New HtmlTextWriter(stringWrite)
        dgrid2.RenderControl(htmlWrite2)
        HtmlContent += stringWrite2.ToString()


        HtmlContent += "<br>"
        Returns = "Value of balance units in transferor scheme : " & "&nbsp;&nbsp;&nbsp;&nbsp;" & txtbal.Text
        Returns1 = "Value of Accumulated units in transferee scheme : " & "&nbsp;&nbsp;&nbsp;&nbsp;" & txtacc.Text
        Xirr = "Hence Yield from STP investment is (%) :" & "&nbsp;&nbsp;&nbsp;&nbsp;" & txtyield.Text

        HtmlContent += "<br>"
        HtmlContent += "<b><font size='3' face='verdana' color='#000000'>" & "" & Returns & "" & " </b> </font>"
        HtmlContent += "<br>"
        HtmlContent += "<b><font size='3' face='verdana' color='#000000'>" & "" & Returns1 & "" & " </b> </font>"
        HtmlContent += "<br>"
        HtmlContent += "<b><font size='3' face='verdana' color='#000000'>" & "" & Xirr & "" & " </b> </font>"

        If HttpContext.Current.Session("All_Chart_Image") <> "" Then
            HtmlContent += "<img  src='" & HttpContext.Current.Session("All_Chart_Image") & "' width='700' height='420' border='0'>"
            HtmlContent += "<br>"
        End If

        HtmlContent += "<br>"
        HtmlContent += "<br><div>" & Notes & "</div>"

        HtmlContent += "<br><b><left><font size='3' face='verdana' color='#ff0000'> " & disclaimer1 & "</font></left></b>"
        HtmlContent += "<table align='top'><tr height='9' style='height:9.0pt'><td colspan='3' rowspan='5' height='54' class='xl40' width='450' style='height:54.0pt;width:700pt'><font size='2' face='Arial' color='black'>" & disclaimer & "</font></td></tr><table>"
        PDFSTP.InnerHtml = HtmlContent

    End Sub

    Protected Sub SetHtmlLUMPSUM()
        Dim stringWrite As System.IO.StringWriter
        Dim htmlWrite As System.Web.UI.HtmlTextWriter
        Dim dgrid As DataGrid
        Dim stringWrite2 As System.IO.StringWriter
        Dim htmlWrite2 As System.Web.UI.HtmlTextWriter
        Dim HtmlContent As String
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

        dgrid = DgReturn


        Dim disclaimer As String
        Dim disclaimer1 As String
        disclaimer1 = "Disclaimer :"

        disclaimer = "<table class='' cellspacing='0' cellpadding='0' width='950px'
                                    align='center' border='0' style='width 950px !important'>
                                    <tr>
                                        <td colspan='2'>
                                            <table cellspacing='0' cellpadding='0' width='950px'
                                                border='0'>
                                                <tr>
                                                    <td class='txt2' style='font-size 12px; text-align: justify;
                                                        line-height:  16px;'>Copyright 2017 Nippon India Mutual
                                                        Fund. All Rights Reserved.
                                                    </td>
                                                    <td class='txt2'>
                                                        <!--Developed by <a href='http//www.icraonline.com' target='_blank' style='COLOR: #939498'>
												ICRA Online Ltd.</a>-->
                                                    </td>
                                                </tr>
                                            </table>
                                            <table cellspacing='0' cellpadding='0' width='100%'
                                                align='center' border='0'>
                                                <tr>
                                                    <td style='font-size 12px; text-align: justify; color: #939498;
                                                        line-height:  16px;'>
                                                        <p>
                                                            Nippon India Mutual Fund does not take the responsibility,
                                                            liability and undertake the
                                                        authenticity of the figures calculated on the basis of
                                                            calculator provided herein
                                                        for calculations towards prospective investments.Developed
                                                            and Maintained by <a href='http//www.icraanalytics.com'
                                                                target='_blank' style='color: #939498'><b>ICRA Analytics Limited</b></a> The data
                                                        content provided is obtained from sources considered to
                                                            be authentic and reliable.
                                                        However, ICRA Analytics Limited is not responsible for any error
                                                            or inaccuracy or for
                                                        any losses suffered on account of information.
                                                        </p>
                                                        <p>
                                                            The Calculators/Tools/Planners are designed to assist
                                                            you in determining the appropriate amount. These Calculators/Tools/Planners
                                                            alone are not sufficient and shouldn’t be used for
                                                            the development or implementation of an investment
                                                            strategy. The investor is advised to consult his or
                                                            her financial advisor prior to arriving at any investment
                                                            decision.
                                                        </p>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>"
        Dim imagePath As String
        Dim imagePath1 As String

        If dgrid.Items.Count < 1 Then
            Exit Sub
        End If

        '//data grid formatting before exporting
        'dgrid.Font.Name = "Arial"
        'dgrid.Font.Size = System.Web.UI.WebControls.FontUnit.Point(8)
        'dgrid.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid
        'dgrid.BorderWidth = New Unit(2, UnitType.Pixel)
        'dgrid.HeaderStyle.BackColor = System.Drawing.Color.Red
        'dgrid.HeaderStyle.ForeColor = System.Drawing.Color.White
        'dgrid.HeaderStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
        'dgrid.HeaderStyle.Wrap = False
        'dgrid.HeaderStyle.Font.Bold = True
        'dgrid.GridLines = GridLines.Both
        'dgrid.BorderColor = System.Drawing.Color.Gray
        'dgrid.Items(0).Width = New Unit(CDbl(200))

        stringWrite = New System.IO.StringWriter

        imagePath = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "") & "\images\reliance-mutual-fund.png"

        HtmlContent = "<div id='PDFLUMPSUM1'><img  src='" & imagePath & "' width='550' height='70' border='0'>"

        HtmlContent += "<br>"

        HtmlContent += "<br>"
        HtmlContent += "<br>"

        Sch_Name = "Scheme " & " : " & "&nbsp;&nbsp;" & ddRetscname.SelectedItem.Text
        B_Mark = "Benchmark Index " & " : " & "&nbsp;&nbsp;" & ddRetbnmark.SelectedItem.Text
        E_Load = "Entry Load " & " : " & ""

        HtmlContent += "<b><font size='3' face='verdana' color='#000000'>" & "" & Sch_Name & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & "" & " </font></b>"
        'Response.Write("<b><font size=1 face=verdana color=#000000>" & "" & E_Load & "" & " </b> </font>")
        HtmlContent += "<br>"
        HtmlContent += "<b><font size='3' face='verdana' color='#000000'>" & "" & B_Mark & "" & " </font></b>"
        HtmlContent += "<br>"
        '//PRINT FROM DATE AND TO_DATE
        If Format(CDate(txtRetFdt.Text), "dd-MMM-yyyy") <> "" And Format(CDate(txtRetTodt.Text), "dd-MMM-yyyy") <> "" Then
            HtmlContent += "<b><font size='3' face='verdana' color='#000000'>Returns for period " & Format(CDate(txtRetFdt.Text), "dd-MMM-yyyy") & " to " & Format(CDate(txtRetTodt.Text), "dd-MMM-yyyy") & " </font></b><br>"
        End If
        HtmlContent += "<br>"
        HtmlContent += "<br>"
        HtmlContent += "<br>"
        HtmlContent += "<br>"




        'HtmlContent += "<font size='1' face='Arial'>"
        htmlWrite = New HtmlTextWriter(stringWrite)
        dgrid.RenderControl(htmlWrite)
        HtmlContent += stringWrite.ToString()


        ' Response.Write("<br>")
        'Returns = "Abs. Return (Scheme): " & p1
        'Xirr = "Yield (Scheme): " & p2
        'Xirr1 = "Yield (Index): " & p3

        HtmlContent += "<br>"
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


        HtmlContent += "<br><b><left><font size='3' face='verdana' color='#ff0000'> " & disclaimer1 & "</font></left></b>"
        HtmlContent += "<br>"
        'Response.Write("<table align=top  width=1000 height=40><tr height=40 width=1000 ><td rowspan=6 height=40  width=1000 ><font size=1 face=Arial color='black'>" & disclaimer & "</font></TD></tr><table>")

        'HtmlContent += "<div><left><font size='1' face='Arial' color='black'>" & disclaimer & "</font></left></div></div></div>"
        HtmlContent += "<table align='top'><tr height='9' style='height:9.0pt'><td colspan='3' rowspan='5' height='54' class='xl40' width='450' style='height:54.0pt;width:700pt'><font size='2' face='Arial' color='black'>" & disclaimer & "</font></td></tr><table>"


        PDFLUMPSUM.InnerHtml = HtmlContent

    End Sub


    Private Sub ddwbnmark_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddwbnmark.SelectedIndexChanged
        ddwbnmark1.SelectedIndex = ddwbnmark.SelectedIndex
    End Sub


    Private Sub Gsp_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles Gsp.ItemDataBound
        e.Item.Cells(4).Visible = False '//cash flow index
        e.Item.Cells(7).Visible = False '//index 
        'ColCount = e.Item.Cells.Count
        'Session("ColCount") = ColCount
    End Sub

    Private Sub Dgswp_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles Dgswp.ItemDataBound
        'e.Item.Cells(6).Visible = False '//index 
        e.Item.Cells(9).Visible = False 'new feb
        e.Item.Cells(10).Visible = False 'new feb
    End Sub

    Private Sub Dstp_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles Dstp.ItemDataBound
        e.Item.Cells(4).Visible = False '//current value
        e.Item.Cells(7).Visible = False '//index
        e.Item.Cells(9).Visible = False '//value after transfer
        e.Item.Cells(10).Visible = False '//unit redeemed
    End Sub

    ''Private Sub btnwreset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Private Overloads Sub btnwreset_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnwreset.Click
        Try

            tblSIP.Visible = False
            tblSIP1.Visible = False
            tblSTP.Visible = False
            tblSTP1.Visible = False
            tblSWP.Visible = True
            tblSWP1.Visible = False
            Label24.Visible = True
            ddwbnmark.Visible = True
            ddwscname.SelectedIndex = 0
            txtwinamt.Text = ""
            ddwperiod.SelectedIndex = 0
            txtwfrdt.Text = ""
            txtwtdt.Text = ""
            txtwvaldate.Text = ""
            txtwtramt.Text = ""
            btnwexport.Enabled = False
            ddwbnmark.SelectedIndex = 0
            ddwbnmark1.SelectedIndex = 0
            hdIsGraphExist.Value = 0
            Dgswp.Columns.Clear()
        Catch ex As Exception

        End Try
    End Sub

    ''Private Sub cmdexp1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Private Overloads Sub cmdexp1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdexp1.Click

        If Dstp.Items.Count < 1 Then
            Response.Write("<script>alert(""No Data To Save Please Try Again"")</script>")
        Else
            Call SaveToExcel_STP2(Response, Dstp, Dstp1, txtbal.Text, txtacc.Text, txtyield.Text, ddtrfrom.SelectedItem.Text, ddtrto.SelectedItem.Text, txttranamt.Text, ddperiod.SelectedItem.Text, PStpDisclamer.InnerHtml)
        End If
    End Sub

    Private Sub ddlsipbnmark_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlsipbnmark.SelectedIndexChanged
        ddlsipbnmark1.SelectedIndex = ddlsipbnmark.SelectedIndex
        'Call drawChart(sipChart, Session("ChartData_SIP1"), "STP", Session("yinterval"))
    End Sub

    Private Sub ddbnmark_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddbnmark.SelectedIndexChanged
        ddbnmark1.SelectedIndex = ddbnmark.SelectedIndex
        'Call drawChart(sipChart, Session("ChartData_SIP1"), "STP", Session("yinterval"))
    End Sub

    Private Sub ddperiod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddperiod.SelectedIndexChanged
        hdChartData.Value = "0"

        If ddperiod.SelectedItem.Text = "Monthly" Or ddperiod.SelectedItem.Text = "Quarterly" Then
            ddSTPDate.Visible = False
            If rbcapital.Checked Then
                STPdt.Visible = False
                ''  tr_STPdate.Visible = False
                Exit Sub
            Else
                STPdt.Visible = True
                '' tr_STPdate.Visible = True
            End If
            'STPdt.Visible = True
            '*********  For STP date    "--Manish--"
            If txtfrdt.Text <> "" Then
                If Split(txtfrdt.Text, "/")(1) = 1 Or Split(txtfrdt.Text, "/")(1) = 3 Or Split(txtfrdt.Text, "/")(1) = 5 Or Split(txtfrdt.Text, "/")(1) = 7 Or Split(txtfrdt.Text, "/")(1) = 8 Or Split(txtfrdt.Text, "/")(1) = 10 Or Split(txtfrdt.Text, "/")(1) = 12 Then
                    STPdt.Items.Clear()
                    STPdt.Items.Add("--")
                    For i = 1 To 31
                        STPdt.Items.Add(i)
                    Next
                ElseIf Split(txtfrdt.Text, "/")(1) = 4 Or Split(txtfrdt.Text, "/")(1) = 6 Or Split(txtfrdt.Text, "/")(1) = 9 Or Split(txtfrdt.Text, "/")(1) = 11 Then
                    STPdt.Items.Clear()
                    STPdt.Items.Add("--")
                    For i = 1 To 30
                        STPdt.Items.Add(i)
                    Next
                ElseIf Split(txtfrdt.Text, "/")(1) = 2 Then
                    STPdt.Items.Clear()
                    STPdt.Items.Add("--")
                    Math.DivRem(CInt(Split(txtfrdt.Text, "/")(2)), 4, Reminder)
                    If Reminder <> 0 Then
                        For i = 1 To 28
                            STPdt.Items.Add(i)
                        Next
                    Else
                        For i = 1 To 29
                            STPdt.Items.Add(i)
                        Next
                    End If
                End If
            Else
                STPdt.Items.Clear()
                STPdt.Items.Add("--")
                For i = 1 To 31
                    STPdt.Items.Add(i)
                Next
            End If
            '***END
        Else
            STPdt.Visible = False
            ddSTPDate.Visible = True
        End If
    End Sub
    Private Function getDataTable4STP_chart(ByVal dtFrom As DataTable, ByVal dtTo As DataTable) As DataTable
        Dim dtSTPChart As New DataTable
        Dim i As Integer
        Dim InitialAmt As Double
        Dim initIndex_unit As Double
        Dim cumulative_amt As Double
        Dim invtInIndex As Double
        Dim navFrom_Index As Integer, navTo_Index As Integer
        Dim cUnitFrom_Index As Integer, cUnitTO_Index As Integer
        Dim cIndexUnit_Index As Integer
        Dim IndexValue_Index As Integer
        Dim Cashflow_index As Integer
        Dim cUnit_From As Double, cUnit_to As Double
        Dim Nav_From As Double, Nav_To As Double

        '//set the indices
        If dtFrom.Columns.IndexOf("nav") >= 0 Then
            navFrom_Index = dtFrom.Columns.IndexOf("nav")
        End If
        '''''If dtFrom.Columns.IndexOf("units") >= 0 Then
        '''''    cUnitFrom_Index = dtFrom.Columns.IndexOf("units")
        '''''End If
        If dtFrom.Columns.IndexOf("Cumulative Units") >= 0 Then
            cUnitFrom_Index = dtFrom.Columns.IndexOf("Cumulative Units")
        End If

        If dtTo.Columns.IndexOf("nav") >= 0 Then
            navTo_Index = dtTo.Columns.IndexOf("nav")
        End If
        ''''If dtTo.Columns.IndexOf("units") >= 0 Then
        ''''    cUnitTO_Index = dtTo.Columns.IndexOf("units")
        ''''End If
        If dtTo.Columns.IndexOf("Cumulative Units") >= 0 Then
            cUnitTO_Index = dtTo.Columns.IndexOf("Cumulative Units")
        End If
        If dtFrom.Columns.IndexOf("Index") >= 0 Then
            IndexValue_Index = dtFrom.Columns.IndexOf("Index")
        End If
        If dtFrom.Columns.IndexOf("Cashflow") >= 0 Then
            Cashflow_index = dtFrom.Columns.IndexOf("Cashflow")
        End If


        Ipcol = New DataColumn
        Ipcol.ColumnName = "ID"
        Ipcol.DataType = System.Type.GetType("System.Int16")
        dtSTPChart.Columns.Add(Ipcol)
        Ipcol = New DataColumn
        Ipcol.ColumnName = "Cumulative_Amount"
        dtSTPChart.Columns.Add(Ipcol)
        Ipcol = New DataColumn
        Ipcol.ColumnName = "Investment_In_Index"
        dtSTPChart.Columns.Add(Ipcol)
        Dim dtrow As DataRow
        For i = 0 To dtFrom.Rows.Count - 1
            If i = 0 Then '//get initial amount
                If Not IsDBNull(dtFrom.Rows(i)(Cashflow_index)) Then
                    InitialAmt = dtFrom.Rows(i)(Cashflow_index) * -1
                End If
                If Not IsDBNull(dtFrom.Rows(i)(IndexValue_Index)) Then
                    initIndex_unit = dtFrom.Rows(i)(IndexValue_Index)
                End If
            End If
            cUnit_From = IIf(Not IsDBNull(dtFrom.Rows(i)(cUnitFrom_Index)), dtFrom.Rows(i)(cUnitFrom_Index), cUnit_From)
            Nav_From = IIf(Not IsDBNull(dtFrom.Rows(i)(navFrom_Index)), dtFrom.Rows(i)(navFrom_Index), Nav_From)
            If i <= dtTo.Rows.Count - 1 Then
                cUnit_to = IIf(Not IsDBNull(dtTo.Rows(i)(cUnitTO_Index)), dtTo.Rows(i)(cUnitTO_Index), cUnit_to)
                Nav_To = IIf(Not IsDBNull(dtTo.Rows(i)(navTo_Index)), dtTo.Rows(i)(navTo_Index), Nav_To)
            End If

            'cumulative_amt = dtFrom.Rows(i)(navFrom_Index) * dtFrom.Rows(i)(cUnitFrom_Index) + dtTo.Rows(i)(navTo_Index) * dtTo.Rows(i)(cUnitTO_Index)
            cumulative_amt = (cUnit_From * Nav_From) + (cUnit_to * Nav_To)

            If Not IsDBNull(dtFrom.Rows(i)(IndexValue_Index)) Then
                invtInIndex = InitialAmt * dtFrom.Rows(i)(IndexValue_Index) / initIndex_unit
            End If
            '//insert row in table
            dtrow = dtSTPChart.NewRow
            dtrow(0) = i + 1 '//identity column
            dtrow(1) = cumulative_amt
            dtrow(2) = invtInIndex
            dtSTPChart.Rows.Add(dtrow)
        Next i
        Return dtSTPChart
    End Function

    Private Sub Dstp1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles Dstp1.ItemDataBound
        e.Item.Cells(4).Visible = False '//divided
        e.Item.Cells(5).Visible = False '//current value
        e.Item.Cells(6).Visible = False '//investment in index
        e.Item.Cells(7).Visible = False '//cum. amount
        e.Item.Cells(8).Visible = False '//value of investment
    End Sub
    Private Sub executeSTP()
        Dim BalanceDate As Date = Nothing
        Dim frdt As Date
        Dim todt As Date
        Dim Valdt As Date
        Dim Colstr As String
        Dim ColArr() As String
        Dim m As Integer = 0
        Dim j As Integer = 0
        Dim k As Integer = 0
        Dim x As Integer = 0
        Dim Periodcty As String
        Dim PrdVal As Integer = 0
        Dim CalcDt As Date
        Dim Amt As Double = 0
        Dim Temp As Double = 0
        Dim Transfer_Amt As Double = 0
        Dim CashFlow As Double = 0
        Dim CumUnts As Double = 0
        Dim NewUnts As Double = 0
        Dim Indexval As String
        Dim IndexArr() As Double
        Dim ValueAfter() As Double
        Dim CashInd As Double = 0
        Dim IniIndex As Double = 0
        Dim Rowcounter As Integer = 0
        Dim TotNav As Double = 0
        Dim IndUnits As Double = 0
        Dim TempNav As Double = 0
        Dim currentIndex As Double = 0
        Dim DtArr() As Date
        Dim Currval() As Double
        Dim Rowcount As Integer = 0
        Dim FinalUnts As Double = 0
        Dim UntsRdmd As Double = 0
        Dim TotUnits As Double = 0
        Dim X1units As Double = 0
        Dim X1Nav As Double = 0
        Dim X1Date As Date
        Dim X2Date As Date
        Dim X2Nav As Double = 0
        Dim Tempdtstr(2) As String
        Dim Pl As Integer = 0
        Dim chkdate As Date
        Dim TrueFlg As Boolean = False
        'Dim NewFlg As Boolean = False
        Dim TranDtArr() As Date
        Dim STP_date As Integer
        Dim STP_date1 As Integer
        Dim cuml_units As Double
        Dim dg1_last_date As String
        Dim stp_cashflw_grd1 As Double
        Dim stp_cashflw_grd2 As Double
        Dim CashFl() As Double
        Dim CashFl1() As Double
        Dim CashFl2() As Double
        Dim dt_as_on_1 As String
        Dim dt_as_on_2 As String

        Dim Fixed_Transfer As Boolean
        '//vishal for capital apprecitin
        Dim cash_flow_capital() As Double
        Dim cash_flow_date() As Date
        Dim cash_flow_count As Integer

        rbindivd.Checked = True
        Try

            Ipdt.Clear()
            Dstp.Columns.Clear()
            Dstp1.Columns.Clear()



            If ddPlan.SelectedItem.Text = "--" Then
                Response.Write("<script>alert(""Please Select Plan.."")</script>")
                Exit Sub
            End If

            If ddtrfrom.SelectedItem.Text = "--" Then
                Response.Write("<script>alert(""Please Select Transfer From Scheme.."")</script>")
                Exit Sub
            End If
            If ddtrto.SelectedItem.Text = "--" Then
                Response.Write("<script>alert(""Please Select Transfer To Scheme.."")</script>")
                Exit Sub
            End If
            If ddbnmark.SelectedItem.Text = "--" Then
                Response.Write("<script>alert(""Please Select Benchmark.."")</script>")
                Exit Sub
            End If
            If Val(txtiniamt.Text) = 0 Then
                Response.Write("<script>alert(""Initial amount cannot be Blank.."")</script>")
                Exit Sub
            End If

            If (Val(txtiniamt.Text) Mod 1) > 0 Then
                Response.Write("<script>alert(""Initial amount cannot be fractional."")</script>")
                Exit Sub
            End If

            Fixed_Transfer = False
            If rbfixed.Checked = True Then
                Fixed_Transfer = True
                If Val(txttranamt.Text) = 0 Then
                    Response.Write("<script>alert(""Transfer amount cannot be blank.."")</script>")
                    Exit Sub
                End If
            End If

            If (Val(txttranamt.Text) Mod 1) > 0 Then
                Response.Write("<script>alert(""Transfer amount cannot be fractional."")</script>")
                Exit Sub
            End If

            Fixed_Transfer = False
            If rbfixed.Checked = True Then
                Fixed_Transfer = True
            ElseIf rbcapital.Checked = True Then
                Fixed_Transfer = False
            End If

            If txtfrdt.Text = "" Or txttodt.Text = "" Then
                Response.Write("<script>alert(""From Date / To Date Can Not be Blank.."")</script>")
                Exit Sub
            End If
            If Val(txtvalue.Text) = 0 Then
                Response.Write("<script>alert(""Please Enter Value As on Date.."")</script>")
                Exit Sub
            End If

            If ddperiod.SelectedItem.Text = "--" Then
                Response.Write("<script>alert(""Please Select Periodicity.."")</script>")
                Exit Sub
            End If
            If rbcapital.Checked = False And rbfixed.Checked = False Then
                Response.Write("<script>alert(""Please Select Option Capital Transfer/Fixed Transfer options .."")</script>")
                Exit Sub
            End If
            If rbindivd.Checked = False And rbcorp.Checked = False Then
                Response.Write("<script>alert(""Please Select Option for Dividend (Individual/Corporate)  .."")</script>")
                Exit Sub
            End If

            For i = 1 To Len(txtfrdt.Text)
                If Mid(Trim(txtfrdt.Text), i, 1) = "/" Then
                    x += 1
                End If
            Next i
            If x <> 2 Then
                Response.Write("<script>alert(""Please Enter From Date in proper format.."")</script>")
                Exit Sub
            End If
            i = 0
            x = 0

            For i = 1 To Len(txttodt.Text)
                If Mid(Trim(txttodt.Text), i, 1) = "/" Then
                    x += 1
                End If
            Next i
            If x <> 2 Then
                Response.Write("<script>alert(""Please Enter To Date in proper format.."")</script>")
                Exit Sub
            End If
            i = 0
            x = 0

            For i = 1 To Len(txtvalue.Text)
                If Mid(Trim(txtvalue.Text), i, 1) = "/" Then
                    x += 1
                End If
            Next i
            If x <> 2 Then
                Response.Write("<script>alert(""Please Value as on Date in proper format.."")</script>")
                Exit Sub
            End If
            i = 0
            x = 0

            If IsDate(fmt(Trim(txtfrdt.Text))) = False Or IsDate(fmt(Trim(txttodt.Text))) = False Or IsDate(fmt(Trim(txtvalue.Text))) = False Then
                Response.Write("<script>alert(""Please Enter The Dates in Proper Formats (dd/mm/yyyy).."")</script>")
                Exit Sub
            End If



            Ipdt = New DataTable
            todt = Trim(txttodt.Text)
            frdt = Trim(txtfrdt.Text)
            Valdt = Trim(txtvalue.Text)

            ''today
            'todt = Split(Trim(txttodt.Text), "/")(1) & "/" & Split(Trim(txttodt.Text), "/")(0) & "/" & Split(Trim(txttodt.Text), "/")(2)
            'frdt = Split(Trim(txtfrdt.Text), "/")(1) & "/" & Split(Trim(txtfrdt.Text), "/")(0) & "/" & Split(Trim(txtfrdt.Text), "/")(2)
            'Valdt = Split(Trim(txtvalue.Text), "/")(1) & "/" & Split(Trim(txtvalue.Text), "/")(0) & "/" & Split(Trim(txtvalue.Text), "/")(2)

            'Jayendra as on 03Jan09
            If frdt < GetStartDate(ddtrfrom.SelectedItem.Value) Then
                Response.Write("<script>alert(""From date cannot be less than From Scheme inception date"")</script>")
                Exit Sub
            End If

            If frdt < GetStartDate(ddtrto.SelectedItem.Value) And todt < GetStartDate(ddtrto.SelectedItem.Value) Then
                Response.Write("<script>alert(""From date cannot be less than To Scheme inception date"")</script>")
                Exit Sub
            End If
            'till here 

            If Fixed_Transfer Then
                If Val(txtiniamt.Text) < Val(txttranamt.Text) Then
                    Response.Write("<script>alert(""Transfer Amount cannot be Greater than Initial Amount.."")</script>")
                    Exit Sub
                End If
                If CDate(todt) <= frdt Then
                    Response.Write("<script>alert(""From Date should be less than To Date.."")</script>")
                    Exit Sub
                End If
                If CDate(Valdt) < todt Then
                    Response.Write("<script>alert(""To Date cannot be Greater than Value as on Date.."")</script>")
                    Exit Sub
                End If

            End If


            STP_date = 10
            If ddSTPDate.SelectedItem.Text = "02nd" Then
                STP_date = SplitDateSTP(txtfrdt.Text, "/")(0)
                If rbcapital.Checked = False Then
                    If ddperiod.SelectedItem.Text = "Monthly" Or ddperiod.SelectedItem.Text = "Quarterly" Then
                        STP_date = STPdt.SelectedItem.Text
                    End If
                Else
                    STP_date = 1
                End If
            ElseIf ddSTPDate.SelectedItem.Text = "10th" Then
                STP_date = 10
            ElseIf ddSTPDate.SelectedItem.Text = "20th" Then
                STP_date = 20
            ElseIf ddSTPDate.SelectedItem.Text = "28th" Then
                STP_date = 28
            End If


            tblSTP1.Visible = True
            L1.Text = "Transfer From :"
            L2.Text = "Transfer To :"
            L1.Text = L1.Text & " " & ddtrfrom.SelectedItem.Text
            L2.Text = L2.Text & " " & ddtrto.SelectedItem.Text

            Periodcty = ddperiod.SelectedItem.Text
            If Periodcty = "Weekly" Then
                PrdVal = 7
            ElseIf Periodcty = "Fortnightly" Then
                PrdVal = 15
            ElseIf Periodcty = "Monthly" Then
                PrdVal = 1

            ElseIf Periodcty = "Quarterly" Then
                PrdVal = 3
            End If
            If Fixed_Transfer Then
                If Periodcty = "Monthly" Then
                    If Val(txttranamt.Text) < 1000 Then
                        Response.Write("<script>alert(""Transfer amount cannot be less than 1000/- Rs."")</script>")
                        Exit Sub
                    End If
                    If Val(txttranamt.Text) > 1000 Then
                        Dim val1 As Integer
                        val1 = Val(txttranamt.Text)
                        If val1 Mod 100 <> 0 Then
                            Response.Write("<script>alert(""Please enter transfer amount in multiples of Rs.100/- only"")</script>")
                            Exit Sub
                        End If
                    End If
                End If
                If Periodcty = "Quarterly" Then
                    If Val(txttranamt.Text) < 3000 Then
                        Response.Write("<script>alert(""Transfer amount cannot be less than Rs.3000/-"")</script>")
                        Exit Sub
                    End If
                    If Val(txttranamt.Text) > 3000 Then
                        Dim val1 As Integer
                        val1 = Val(txttranamt.Text)
                        If val1 Mod 100 <> 0 Then
                            Response.Write("<script>alert(""Please enter transfer amount in multiples of Rs.100/- only"")</script>")
                            Exit Sub
                        End If
                    End If
                End If
            End If

            Amt = Trim(txtiniamt.Text)
            Temp = 0
            Temp = IIf(Fixed_Transfer, Trim(txttranamt.Text), 0)
            Transfer_Amt = Temp
            CashFlow = Temp
            Dim CashFlowOrginal = CashFlow
            Colstr = "Date#NAV#Units#Cumulative Units#Current Value#CashFlow#Dividend#Index#Index Value#Value After Transfer#Units Redeemed"
            ColArr = Split(Colstr, "#")
            For i = 0 To 10
                Ipcol = New DataColumn
                Ipcol.ColumnName = ColArr(i)
                Ipdt.Columns.Add(Ipcol)
            Next i
            Dstp.HeaderStyle.ForeColor = Color.White

            m = 0
            j = 0
            k = 0
            x = 0
            cash_flow_count = 0
            Rowcounter = 0

            Indexval = ddbnmark1.SelectedItem.Text
            'by Jayendra 10/01/2009 removes = condition for todt
            If frdt < GetStartDate(ddtrto.SelectedItem.Value) Then
                strsql = "Select dateadd(d,276,[date]),(Nav_rs-53)/76 from nav_rec where sch_code='" & ddtrfrom.SelectedItem.Value & "' And dateadd(d,276,[date]) >='" & GetStartDate(ddtrto.SelectedItem.Value) & "' And dateadd(d,276,[date])<'" & todt.ToString("dd MMM yyyy") & "' order by dateadd(d,276,[date])"
            Else
                strsql = "Select dateadd(d,276,[date]),(Nav_rs-53)/76 from nav_rec where sch_code='" & ddtrfrom.SelectedItem.Value & "' And dateadd(d,276,[date]) >='" & frdt.ToString("dd MMM yyyy") & "' And dateadd(d,276,[date])<'" & todt.ToString("dd MMM yyyy") & "' order by dateadd(d,276,[date])"
            End If
            'till here

            Sqlcon = New SqlConnection(constr)
            If Sqlcon.State = ConnectionState.Open Then
                Sqlcon.Close()
            End If
            Sqlcon.Open()
            Sqlcom = New SqlCommand(strsql, Sqlcon)
            rdSTP = Sqlcom.ExecuteReader

            'stp new
            Dim DtSqlrd As DataTable = New DataTable
            DtSqlrd.Load(rdSTP)
            Sqlcon.Close()

            ''store nav_rac
            Dim DtNavRecSch1 As DataTable = New DataTable
            Dim DtNavRecInd As DataTable = New DataTable
            Dim DtDivRecAdv As DataTable = New DataTable

            If DtSqlrd.Rows.Count > 0 Then
                sqlcon3 = New SqlConnection(constr)
                sqlcon3.Open()
                strsqls = "Select dateadd(d,276,[date]),(Nav_rs-53)/76 from nav_rec where sch_code='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,[date]) >='" & Convert.ToDateTime(DtSqlrd.Rows(0)(0)).ToString("dd MMM yyyy") & "'"
                Sqlcom = New SqlCommand(strsqls, sqlcon3)
                sqlrd3 = Sqlcom.ExecuteReader
                DtNavRecSch1.Load(sqlrd3)
                sqlcon3.Close()
                sqlcon3.Dispose()

                sqlcon1 = New SqlConnection(constr)
                sqlcon1.Open()
                strsql = "Select (ind_val-53)/76, dateadd(d,276,dt1)  from ind_rec where ind_code='" & Indexval & "' And dateadd(d,276,dt1)>='" & Convert.ToDateTime(DtSqlrd.Rows(0)(0)).ToString("dd MMM yyyy") & "' order by dt1 desc "
                Sqlcom = New SqlCommand(strsql, sqlcon1)
                sqlrd1 = Sqlcom.ExecuteReader
                DtNavRecInd.Load(sqlrd1)
                sqlcon1.Close()
                sqlcon1.Dispose()


                sqlcon1 = New SqlConnection(constr)
                sqlcon1.Open()
                If rbindivd.Checked = True Then
                    strsql = "Select (divid_pt -53)/76,date from div_rec_adv where sch_code='" & ddtrfrom.SelectedItem.Value & "' And date >='" & Convert.ToDateTime(DtSqlrd.Rows(0)(0)).ToString("dd MMM yyyy") & "'"
                ElseIf rbcorp.Checked = True Then
                    strsql = "Select (divid_pt_corp -53)/76,date from div_rec_adv where sch_code='" & ddtrfrom.SelectedItem.Value & "' And date>='" & Convert.ToDateTime(DtSqlrd.Rows(0)(0)).ToString("dd MMM yyyy") & "'"
                End If
                Sqlcom = New SqlCommand(strsql, sqlcon1)
                sqlrd1 = Sqlcom.ExecuteReader
                DtDivRecAdv.Load(sqlrd1)
                sqlcon1.Close()
                sqlcon1.Dispose()


            End If
            'end
            CalcDt = frdt
            If DtSqlrd.Rows.Count > 0 Then
                'chkdate = Sqlrd(0)
                For Each sqlrd As DataRow In DtSqlrd.Rows
                    chkdate = sqlrd(0)
                    'Do
                    If sqlrd(0) >= chkdate And chkdate < todt Then

                        'sqlcon3 = New SqlConnection(constr)
                        'sqlcon3.Open()
                        'strsqls = "Select TOP 1 dateadd(d,276,[date]),(Nav_rs-53)/76 from nav_rec where sch_code='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,[date]) >='" & Convert.ToDateTime(sqlrd(0)).ToString("dd MMM yyyy") & "'"
                        'Sqlcom = New SqlCommand(strsqls, sqlcon3)
                        'sqlrd3 = Sqlcom.ExecuteReader
                        'If sqlrd3.Read Then
                        '    TrueFlg = True
                        '    GoTo ContNext
                        'Else
                        '    chkdate = DateAdd(DateInterval.Day, 1, chkdate)
                        '    TrueFlg = False
                        'End If
                        'sqlcon3.Close()
                        'sqlcon3.Dispose()

                        '****New
                        'Convert.ToDateTime(sqlrd(0)).ToString("dd MMM yyyy")
                        Dim data = DtNavRecSch1.AsEnumerable.Where(Function(s) s(0) >= Convert.ToDateTime(sqlrd(0)))
                        If data.Any() Then
                            TrueFlg = True
                            GoTo ContNext
                        Else
                            chkdate = DateAdd(DateInterval.Day, 1, chkdate)
                            TrueFlg = False
                        End If
                        '****


                        If ddperiod.SelectedItem.Text <> "Fortnightly" Then
                            If rbcapital.Checked = False Then
                                If SplitDateSTP(sqlrd(0), "/")(1) <= STP_date Then
                                    If STP_date > 28 Then
                                        Math.DivRem(CInt(SplitDateSTP(sqlrd(0), "/")(2)), 4, valReminder)
                                        If valReminder <> 0 Then
                                            If STP_date > 28 And CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 2 Then
                                                STP_date = 28
                                            ElseIf STP_date > 29 And (CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 4 Or CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 6 Or CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 9 Or CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 11) Then
                                                STP_date = 30
                                            End If
                                        Else
                                            If STP_date > 28 And CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 2 Then
                                                STP_date = 29
                                            ElseIf STP_date > 29 And (CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 4 Or CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 6 Or CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 9 Or CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 11) Then
                                                STP_date = 30
                                            End If
                                        End If
                                        chkdate = CDateSTP(SplitDateSTP(sqlrd(0), "/")(0) & "/" & STP_date & "/" & SplitDateSTP(sqlrd(0), "/")(2))
                                    Else
                                        chkdate = CDateSTP(SplitDateSTP(sqlrd(0), "/")(0) & "/" & STP_date & "/" & SplitDateSTP(sqlrd(0), "/")(2))
                                    End If

                                    If ddperiod.SelectedItem.Text = "Monthly" Then
                                        If Day(chkdate) <= STP_date Then
                                            chkdate = DateAdd(DateInterval.Month, 1, chkdate)
                                        End If
                                    End If
                                    If ddperiod.SelectedItem.Text = "Quarterly" Then
                                        If Day(chkdate) <= STP_date Then
                                            chkdate = DateAdd(DateInterval.Month, 3, chkdate)
                                        End If
                                    End If
                                    '***  Manish  For Weekly ***
                                    If ddperiod.SelectedItem.Text = "Weekly" Then
                                        If Day(chkdate) <= STP_date Then
                                            chkdate = DateAdd(DateInterval.Day, 7, chkdate)
                                        End If
                                    End If
                                Else
                                    'By Jayendra as on 26Dec2008 
                                    If ddperiod.SelectedItem.Text = "Weekly" Then
                                        chkdate = DateAdd(DateInterval.Day, PrdVal, sqlrd(0))
                                    Else
                                        chkdate = DateAdd(DateInterval.Month, PrdVal, sqlrd(0))
                                    End If
                                    'till here

                                    Tempdtstr = SplitDateSTP(chkdate, "/")
                                    chkdate = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                End If
                            Else
                                STP_date = 1
                                chkdate = DateAdd(DateInterval.Month, PrdVal, sqlrd(0))
                                Tempdtstr = SplitDateSTP(chkdate, "/")
                                chkdate = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                            End If
                        Else
                            STP_date1 = SplitDateSTP(CalcDt, "/")(1)
                            If STP_date1 >= 11 Then
                                Tempdtstr = SplitDateSTP(CalcDt, "/")
                                If Tempdtstr(0) < 12 Then
                                    CalcDt = CDateSTP(Tempdtstr(0) + 1 & "/" & 1 & "/" & Tempdtstr(2))
                                Else
                                    CalcDt = CDateSTP(1 & "/" & 1 & "/" & Tempdtstr(2) + 1)
                                End If
                            ElseIf STP_date1 < 11 Then
                                Tempdtstr = SplitDateSTP(CalcDt, "/")
                                If Tempdtstr(0) <= 12 Then
                                    CalcDt = CDateSTP(Tempdtstr(0) & "/" & 15 & "/" & Tempdtstr(2))
                                End If
                            End If
                        End If
                    End If
                    If TrueFlg = False Then
                        GoTo NextDate
                    End If
ContNext:
                    If j = 0 Then
                        Iprw = Ipdt.NewRow
                        Iprw(0) = Format(CDate(sqlrd(0)), "dd-MMM-yyyy")
                        CalcDt = sqlrd(0)
                        X1Date = sqlrd(0)
                        ReDim Preserve DtArr(Rowcount)
                        DtArr(Rowcount) = sqlrd(0)
                        ''for first transaction make it zero for cash flow in case of capital appreciation
                        If Fixed_Transfer = False Then
                            CashFlow = 0
                            ReDim Preserve cash_flow_capital(cash_flow_count)
                            ReDim Preserve cash_flow_date(cash_flow_count)
                            cash_flow_capital(cash_flow_count) = CashFlow
                            cash_flow_date(cash_flow_count) = sqlrd(0)
                            cash_flow_count = cash_flow_count + 1
                        End If
                        'vishal cash flow of capital appreciation

                        Iprw(1) = Math.Round(sqlrd(1), 4)
                        X1Nav = sqlrd(1)
                        Iprw(2) = Math.Round(Amt / sqlrd(1), 4)
                        X1units = (Math.Round(Amt / sqlrd(1), 4)) * -1
                        If IsDBNull(Iprw(2)) = True Then
                            FinalUnts = 0
                        Else
                            FinalUnts = Iprw(2)
                        End If
                        TotUnits = TotUnits + FinalUnts
                        Iprw(3) = Math.Round(Amt / sqlrd(1), 4)
                        ReDim Preserve Currval(Rowcount)
                        Currval(Rowcount) = Math.Round(Iprw(1) * Iprw(3), 2)
                        cuml_units = Iprw(3)
                        Iprw(5) = Amt * -1
                        ReDim Preserve CashFl(Rowcount)
                        CashFl(Rowcount) = Iprw(5)
                        CashInd = Iprw(5)

                        ''** 
                        sqlcon1 = New SqlConnection(constr)
                        sqlcon1.Open()
                        strsql = "Select top 1 (ind_val-53)/76,dt1  from ind_rec where ind_code='" & Indexval & "' And dateadd(d,276,dt1)<='" & Convert.ToDateTime(sqlrd(0)).ToString("dd MMM yyyy") & "' order by dt1 desc "
                        Sqlcom = New SqlCommand(strsql, sqlcon1)
                        sqlrd1 = Sqlcom.ExecuteReader
                        If sqlrd1.Read Then
                            ReDim Preserve IndexArr(m)
                            Iprw(7) = Math.Round(sqlrd1(0), 2)
                            currentIndex = sqlrd1(0)
                            IndUnits = Math.Round(Math.Round(Amt / sqlrd1(0), 4), 4)
                            Iprw(8) = Math.Round(currentIndex * IndUnits, 2)
                            IndexArr(m) = Iprw(8)
                            IniIndex = Iprw(7)
                            m += 1
                        Else
                            Response.Write("<script>alert(""Data not found for the selected index"")</script>")
                            Exit Sub
                        End If
                        sqlcon1.Close()
                        sqlcon1.Dispose()

                        '*** new
                        'Dim dataInd = DtNavRecInd.AsEnumerable().Where(Function(c) c(1) <= Convert.ToDateTime(sqlrd(0))).OrderByDescending(Function(n) n(1))
                        'If dataInd.Any() Then
                        '    ReDim Preserve IndexArr(m)
                        '    Iprw(7) = Math.Round(dataInd.FirstOrDefault()(0), 2)
                        '    currentIndex = dataInd.FirstOrDefault()(0)
                        '    IndUnits = Math.Round(Math.Round(Amt / dataInd.FirstOrDefault()(0), 4), 4)
                        '    Iprw(8) = Math.Round(currentIndex * IndUnits, 2)
                        '    IndexArr(m) = Iprw(8)
                        '    IniIndex = Iprw(7)
                        '    m += 1
                        'End If
                        ''*** new end

                        Ipdt.Rows.Add(Iprw)

                        If ddperiod.SelectedItem.Text <> "Fortnightly" Then
                            If SplitDateSTP(sqlrd(0), "/")(1) < STP_date And ddperiod.SelectedItem.Text <> "Weekly" Then
                                If rbcapital.Checked = False Then
                                    If STPdt.SelectedItem.Text <> "--" Then
                                        If CInt(STPdt.SelectedItem.Value) > 28 Then
                                            Math.DivRem(CInt(SplitDateSTP(sqlrd(0), "/")(2)), 4, valReminder)
                                            If valReminder <> 0 Then
                                                If CInt(STPdt.SelectedItem.Value) > 28 And CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 2 Then
                                                    STP_date = 28
                                                ElseIf CInt(STPdt.SelectedItem.Value) > 29 And (CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 4 Or CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 6 Or CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 9 Or CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 11) Then
                                                    STP_date = 30
                                                Else
                                                    STP_date = CInt(STPdt.SelectedItem.Value)
                                                End If
                                            Else
                                                If CInt(STPdt.SelectedItem.Value) > 28 And CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 2 Then
                                                    STP_date = 29
                                                ElseIf CInt(STPdt.SelectedItem.Value) > 29 And (CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 4 Or CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 6 Or CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 9 Or CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 11) Then
                                                    STP_date = 30
                                                Else
                                                    STP_date = CInt(STPdt.SelectedItem.Value)
                                                End If
                                            End If
                                            CalcDt = CDateSTP(SplitDateSTP(sqlrd(0), "/")(0) & "/" & STP_date & "/" & SplitDateSTP(sqlrd(0), "/")(2))
                                        Else
                                            CalcDt = CDateSTP(SplitDateSTP(sqlrd(0), "/")(0) & "/" & STP_date & "/" & SplitDateSTP(sqlrd(0), "/")(2))
                                        End If

                                        CalcDt = DateAdd(DateInterval.Month, PrdVal, CalcDt)

                                    Else
                                        CalcDt = CDateSTP(SplitDateSTP(sqlrd(0), "/")(0) & "/" & STP_date & "/" & SplitDateSTP(sqlrd(0), "/")(2))
                                    End If
                                Else
                                    STP_date = 1
                                    CalcDt = CDateSTP(SplitDateSTP(sqlrd(0), "/")(0) & "/" & STP_date & "/" & SplitDateSTP(sqlrd(0), "/")(2))
                                End If

                            Else
                                If ddperiod.SelectedItem.Text = "Weekly" Then
                                    STP_date1 = SplitDateSTP(CalcDt, "/")(1)

                                    If STP_date1 < 8 Then
                                        Tempdtstr = SplitDateSTP(CalcDt, "/")
                                        CalcDt = CDateSTP(Tempdtstr(0) & "/" & 8 & "/" & Tempdtstr(2))
                                    ElseIf STP_date1 >= 8 And STP_date1 < 15 Then
                                        Tempdtstr = SplitDateSTP(CalcDt, "/")
                                        CalcDt = CDateSTP(Tempdtstr(0) & "/" & 15 & "/" & Tempdtstr(2))
                                    ElseIf STP_date1 >= 15 And STP_date1 < 22 Then
                                        Tempdtstr = SplitDateSTP(CalcDt, "/")
                                        CalcDt = CDateSTP(Tempdtstr(0) & "/" & 22 & "/" & Tempdtstr(2))
                                    ElseIf STP_date1 >= 22 Then
                                        Tempdtstr = SplitDateSTP(CalcDt, "/")
                                        If Tempdtstr(0) < 12 Then
                                            CalcDt = CDateSTP(Tempdtstr(0) + 1 & "/" & 1 & "/" & Tempdtstr(2))
                                        Else
                                            CalcDt = CDateSTP(1 & "/" & 1 & "/" & Tempdtstr(2) + 1)
                                        End If
                                    End If
                                Else
                                    'By Jayendra as on 26Dec2008 
                                    If ddperiod.SelectedItem.Text = "Weekly" Then
                                        'STP_date = STP_date + 1
                                        chkdate = DateAdd(DateInterval.Day, PrdVal, sqlrd(0))
                                    Else
                                        CalcDt = DateAdd(DateInterval.Month, PrdVal, sqlrd(0))
                                    End If
                                    '''till here
                                    Tempdtstr = SplitDateSTP(CalcDt, "/")
                                    If rbcapital.Checked = False Then
                                        If STPdt.SelectedItem.Text <> "--" Then
                                            If CInt(STPdt.SelectedItem.Value) > 28 Then
                                                Math.DivRem(CInt(Tempdtstr(2)), 4, valReminder)
                                                If valReminder <> 0 Then
                                                    If CInt(STPdt.SelectedItem.Value) > 28 And CInt(Tempdtstr(0)) = 2 Then
                                                        STP_date = 28
                                                    ElseIf CInt(STPdt.SelectedItem.Value) > 29 And (CInt(Tempdtstr(0)) = 4 Or CInt(Tempdtstr(0)) = 6 Or CInt(Tempdtstr(0)) = 9 Or CInt(Tempdtstr(0)) = 11) Then
                                                        STP_date = 30
                                                    Else
                                                        STP_date = CInt(STPdt.SelectedItem.Value)
                                                    End If
                                                Else
                                                    If CInt(STPdt.SelectedItem.Value) > 28 And CInt(Tempdtstr(0)) = 2 Then
                                                        STP_date = 29
                                                    ElseIf CInt(STPdt.SelectedItem.Value) > 29 And (CInt(Tempdtstr(0)) = 4 Or CInt(Tempdtstr(0)) = 6 Or CInt(Tempdtstr(0)) = 9 Or CInt(Tempdtstr(0)) = 11) Then
                                                        STP_date = 30
                                                    Else
                                                        STP_date = CInt(STPdt.SelectedItem.Value)
                                                    End If
                                                End If
                                                CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                            Else
                                                CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                            End If
                                        Else
                                            If CInt(Tempdtstr(1)) > 28 Then
                                                Math.DivRem(CInt(Tempdtstr(2)), 4, valReminder)
                                                If valReminder <> 0 Then
                                                    If CInt(Tempdtstr(1)) >= 28 And CInt(Tempdtstr(0)) = 2 Then
                                                        STP_date = 28
                                                    ElseIf CInt(Tempdtstr(1)) > 29 And (CInt(Tempdtstr(0)) = 4 Or CInt(Tempdtstr(0)) = 6 Or CInt(Tempdtstr(0)) = 9 Or CInt(Tempdtstr(0)) = 11) Then
                                                        STP_date = 30
                                                    Else
                                                        STP_date = CInt(Tempdtstr(1))
                                                    End If
                                                Else
                                                    If CInt(Tempdtstr(1)) >= 28 And CInt(Tempdtstr(0)) = 2 Then
                                                        STP_date = 29
                                                    ElseIf CInt(Tempdtstr(1)) > 29 And (CInt(Tempdtstr(0)) = 4 Or CInt(Tempdtstr(0)) = 6 Or CInt(Tempdtstr(0)) = 9 Or CInt(Tempdtstr(0)) = 11) Then
                                                        STP_date = 30
                                                    Else
                                                        STP_date = CInt(Tempdtstr(1))
                                                    End If
                                                End If
                                                CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                            Else
                                                CalcDt = CDateSTP(Tempdtstr(0) & "/" & CInt(Tempdtstr(1)) & "/" & Tempdtstr(2))
                                            End If
                                        End If
                                    Else
                                        CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                    End If
                                End If
                            End If
                        Else
                            ' CalcDt = DateAdd(DateInterval.Day, PrdVal, CalcDt)'**MANISH
                            If SplitDateSTP(sqlrd(0), "/")(1) < STP_date Then
                                STP_date1 = SplitDateSTP(CalcDt, "/")(1)
                                If STP_date1 >= 11 Then
                                    Tempdtstr = SplitDateSTP(CalcDt, "/")
                                    If Tempdtstr(0) < 12 Then
                                        CalcDt = CDateSTP(Tempdtstr(0) + 1 & "/" & 1 & "/" & Tempdtstr(2))
                                    Else
                                        CalcDt = CDateSTP(1 & "/" & 1 & "/" & Tempdtstr(2) + 1)
                                    End If
                                ElseIf STP_date1 < 11 Then
                                    Tempdtstr = SplitDateSTP(CalcDt, "/")
                                    'CalcDt = CDateSTP(Tempdtstr(0) & "/" & 15 & "/" & Tempdtstr(2))
                                    If Tempdtstr(0) <= 12 Then
                                        CalcDt = CDateSTP(Tempdtstr(0) & "/" & 15 & "/" & Tempdtstr(2))
                                    End If
                                End If
                            Else
                                STP_date1 = SplitDateSTP(CalcDt, "/")(1)
                                If STP_date1 >= 11 Then
                                    Tempdtstr = SplitDateSTP(CalcDt, "/")
                                    If Tempdtstr(0) < 12 Then
                                        CalcDt = CDateSTP(Tempdtstr(0) + 1 & "/" & 1 & "/" & Tempdtstr(2))
                                    Else
                                        CalcDt = CDateSTP(1 & "/" & 1 & "/" & Tempdtstr(2) + 1)
                                    End If
                                ElseIf STP_date1 < 11 Then
                                    Tempdtstr = SplitDateSTP(CalcDt, "/")
                                    If Tempdtstr(0) <= 12 Then
                                        CalcDt = CDateSTP(Tempdtstr(0) & "/" & 15 & "/" & Tempdtstr(2))
                                    End If
                                End If
                            End If
                        End If
                        Rowcount += 1

                        chkdate = CalcDt
                        TrueFlg = False
                    ElseIf sqlrd(0) >= CalcDt And CalcDt <= todt Then
                        Iprw = Ipdt.NewRow
                        Rowcounter += 1
                        Iprw(0) = Format(CDate(sqlrd(0)), "dd-MMM-yyyy")
                        CalcDt = sqlrd(0)
                        ReDim Preserve DtArr(Rowcount)
                        DtArr(Rowcount) = sqlrd(0)

                        '//calcualete cash flow in case of capital appreciation
                        If Fixed_Transfer = False Then
                            CashFlow = 0
                            CashFlow = IIf(cuml_units * sqlrd(1) > Amt, (cuml_units * sqlrd(1)) - Amt, 0)
                            CashFlow = Math.Round(CashFlow, 2)
                            '//also consider the dividend                         
                        End If

                        ReDim Preserve cash_flow_capital(cash_flow_count)
                        ReDim Preserve cash_flow_date(cash_flow_count)
                        cash_flow_capital(cash_flow_count) = CashFlow
                        cash_flow_date(cash_flow_count) = sqlrd(0)
                        cash_flow_count = cash_flow_count + 1
                        'vishal cash flow of capital appreciation
                        If CashFlow > 0 Then
                            'If cuml_units - Math.Round(CashFlow / Sqlrd(1), 4) > 0.0 Then
                            If cuml_units > 0.0 Then

                                Iprw(1) = Math.Round(sqlrd(1), 4)

                                '' If (Amt - Temp) < 0.0 Then
                                ''Else
                                'If (Amt - Temp) <> 0.0 And cuml_units <> 0 Then

                                'If cuml_units <> 0 Then
                                If (sqlrd(1) * cuml_units < CashFlow) Then
                                    CashFlow = sqlrd(1) * cuml_units
                                    BalanceDate = sqlrd(0)
                                End If
                                Iprw(2) = Math.Round(CashFlow / sqlrd(1), 4)
                                If IsDBNull(Iprw(2)) = True Then
                                    FinalUnts = 0
                                Else
                                    FinalUnts = Iprw(2)
                                End If
                                TotUnits = TotUnits + FinalUnts
                                Iprw(3) = Math.Round(cuml_units - Iprw(2), 4)
                                cuml_units = Math.Round(cuml_units - Iprw(2), 4)
                                Iprw(4) = Math.Round(Iprw(1) * Iprw(3), 2)
                                ReDim Preserve Currval(Rowcount)
                                Currval(Rowcount) = Math.Round(Iprw(1) * Iprw(3), 4)
                                Iprw(5) = CashFlow
                                ReDim Preserve CashFl(Rowcount)
                                CashFl(Rowcount) = Iprw(5) - CashFlow

                                'sqlcon1 = New SqlConnection(constr)
                                'sqlcon1.Open()
                                'If rbindivd.Checked = True Then
                                '    strsql = "Select sum((divid_pt -53)/76) from div_rec_adv where sch_code='" & ddtrfrom.SelectedItem.Value & "' And date >='" & CDateSTP(Ipdt.Rows(Rowcounter - 1).Item(0)).ToString("dd MMM yyyy") & "' And date<='" & CDateSTP(Iprw(0)).ToString("dd MMM yyyy") & "'"
                                'ElseIf rbcorp.Checked = True Then
                                '    strsql = "Select sum((divid_pt_corp -53)/76) from div_rec_adv where sch_code='" & ddtrfrom.SelectedItem.Value & "' And date>='" & CDateSTP(Ipdt.Rows(Rowcounter - 1).Item(0)).ToString("dd MMM yyyy") & "' And date<='" & CDateSTP(Iprw(0)).ToString("dd MMM yyyy") & "'"
                                'End If
                                'Sqlcom = New SqlCommand(strsql, sqlcon1)
                                'sqlrd1 = Sqlcom.ExecuteReader
                                'If sqlrd1.Read Then
                                '    If IsDBNull(sqlrd1(0)) = False Then
                                '        Iprw(6) = sqlrd1(0)
                                '    Else
                                '        Iprw(6) = ""
                                '    End If
                                'End If
                                'sqlcon1.Close()
                                'sqlcon1.Dispose()

                                'DtDivRecAdv
                                '*** New
                                Dim divRec = DtDivRecAdv.AsEnumerable().Where(Function(v) (v(1) >= (CDateSTP(Ipdt.Rows(Rowcounter - 1).Item(0)))) And (v(1) <= CDateSTP(Iprw(0)))).Select(Function(n) n(0))
                                If divRec.Any() Then
                                    Dim Sum = (From p As Double In divRec Select p).Sum()
                                    If IsDBNull(Sum) = False Then
                                        Iprw(6) = Sum
                                    Else
                                        Iprw(6) = ""
                                    End If
                                Else
                                    Iprw(6) = ""
                                End If
                                '*** End

                                'sqlcon1 = New SqlConnection(constr)
                                'sqlcon1.Open()
                                'strsql = "Select top 1 (ind_val-53)/76,dt1 from ind_rec where ind_code='" & Indexval & "' And dateadd(d,276,dt1)<='" & Convert.ToDateTime(sqlrd(0)).ToString("dd MMM yyyy") & "' order by dt1 desc"
                                'Sqlcom = New SqlCommand(strsql, sqlcon1)
                                'sqlrd1 = Sqlcom.ExecuteReader
                                'If sqlrd1.Read Then
                                '    ReDim Preserve IndexArr(m)
                                '    Iprw(7) = Math.Round(sqlrd1(0), 2)
                                '    currentIndex = sqlrd1(0)
                                '    IndUnits = IndUnits - Math.Round(Math.Round(Transfer_Amt / sqlrd1(0), 4), 4)
                                '    Iprw(8) = Math.Round(currentIndex * IndUnits, 2)
                                '    IndexArr(m) = Iprw(8)
                                '    m += 1
                                'End If
                                'sqlcon1.Close()
                                'sqlcon1.Dispose()

                                '** new
                                Dim ind_rec = DtNavRecInd.AsEnumerable().Where(Function(c) c(1) <= Convert.ToDateTime(sqlrd(0))).OrderByDescending((Function(v) v(1)))

                                If ind_rec.Any Then
                                    ReDim Preserve IndexArr(m)
                                    Iprw(7) = Math.Round(ind_rec.FirstOrDefault()(0), 2)
                                    currentIndex = ind_rec(0)(0)
                                    IndUnits = IndUnits - Math.Round(Math.Round(Transfer_Amt / ind_rec.FirstOrDefault()(0), 4), 4)
                                    Iprw(8) = Math.Round(currentIndex * IndUnits, 2)
                                    IndexArr(m) = Iprw(8)
                                    m += 1
                                End If
                                '** end





                                Iprw(9) = Math.Round(Iprw(4) - Iprw(5), 2)
                                ReDim Preserve ValueAfter(x)
                                ValueAfter(x) = Iprw(9)
                                x += 1
                                Iprw(10) = Math.Round(Iprw(5) / Iprw(1), 4)
                                If IsDBNull(Iprw(9)) = True Then
                                    UntsRdmd = 0
                                Else
                                    UntsRdmd = Iprw(9)
                                End If

                                txtbal.Text = Math.Round(cuml_units * Iprw(1), 2)
                                dg1_last_date = CStr(Iprw(0))
                                'End If
                                'End If
                                Temp = Temp + CashFlow
                                'stp_cashflw_grd1 = Math.Round(CDbl(Iprw(1)) * CDbl(Iprw(3)), 4)
                            End If
                            'Else '//end of if unit available
                            '    ReDim Preserve CashFl(Rowcount)
                            '    CashFl(Rowcount) = 0
                            'End If
                        Else '//end of +ve cash flow
                            '//fill column with previous value or zero in case capital appreciation
                            Iprw(1) = Math.Round(sqlrd(1), 4) '//nav
                            Iprw(2) = 0 '//units
                            Iprw(3) = Math.Round(cuml_units, 4) '//cumulative units
                            Iprw(4) = Math.Round(cuml_units * Math.Round(sqlrd(1), 4), 2) '//current value
                            Iprw(5) = CashFlow  '//cash flow
                            'Iprw(6) = CashFlow  '//dividned

                            '//index calculation
                            'sqlcon1 = New SqlConnection(constr)
                            'sqlcon1.Open()
                            'strsql = "Select top 1 (ind_val-53)/76,dt1 from ind_rec where ind_code='" & Indexval & "' And dateadd(d,276,dt1)<='" & sqlrd(0) & "' order by dt1 desc"
                            'Sqlcom = New SqlCommand(strsql, sqlcon1)
                            'sqlrd1 = Sqlcom.ExecuteReader
                            'If sqlrd1.Read Then
                            '    ReDim Preserve IndexArr(m)
                            '    Iprw(7) = Math.Round(sqlrd1(0), 2)
                            '    currentIndex = sqlrd1(0)
                            '    IndUnits = IndUnits '//as cash flow is zero keep as it is
                            '    Iprw(8) = Math.Round(currentIndex * IndUnits, 2)
                            '    IndexArr(m) = Iprw(8)
                            '    m += 1
                            'End If
                            'sqlcon1.Close()
                            'sqlcon1.Dispose()

                            ''***new ***
                            'DtNavRecInd
                            Dim Indval = DtNavRecInd.AsEnumerable().Where(Function(c) c(1) <= Convert.ToDateTime(sqlrd(0))).OrderByDescending((Function(v) v(1)))

                            If Indval.Any Then
                                Dim val = Indval.FirstOrDefault()(0)
                                ReDim Preserve IndexArr(m)
                                Iprw(7) = Math.Round(val, 2)
                                currentIndex = val
                                IndUnits = IndUnits '//as cash flow is zero keep as it is
                                Iprw(8) = Math.Round(currentIndex * IndUnits, 2)
                                IndexArr(m) = Iprw(8)
                                m += 1
                            End If

                            ''** end new

                            Iprw(9) = Math.Round(Iprw(4) - Iprw(5), 2)
                            ReDim Preserve ValueAfter(x)
                            ValueAfter(x) = Iprw(9)
                            x += 1
                            Iprw(10) = Math.Round(Iprw(5) / Iprw(1), 4)
                            If IsDBNull(Iprw(9)) = True Then
                                UntsRdmd = 0
                            Else
                                UntsRdmd = Iprw(9)
                            End If


                            ReDim Preserve CashFl(Rowcount)
                            CashFl(Rowcount) = 0
                        End If

                        Ipdt.Rows.Add(Iprw)
                        If ddperiod.SelectedItem.Text <> "Fortnightly" Then
                            If SplitDateSTP(sqlrd(0), "/")(1) < STP_date Then
                                If ddperiod.SelectedItem.Text = "Weekly" Then
                                    STP_date1 = SplitDateSTP(CalcDt, "/")(1)

                                    If STP_date1 < 8 Then
                                        Tempdtstr = SplitDateSTP(CalcDt, "/")
                                        CalcDt = CDateSTP(Tempdtstr(0) & "/" & 8 & "/" & Tempdtstr(2))
                                    ElseIf STP_date1 >= 8 And STP_date1 < 15 Then
                                        Tempdtstr = SplitDateSTP(CalcDt, "/")
                                        CalcDt = CDateSTP(Tempdtstr(0) & "/" & 15 & "/" & Tempdtstr(2))
                                    ElseIf STP_date1 >= 15 And STP_date1 < 22 Then
                                        Tempdtstr = SplitDateSTP(CalcDt, "/")
                                        CalcDt = CDateSTP(Tempdtstr(0) & "/" & 22 & "/" & Tempdtstr(2))
                                    ElseIf STP_date1 >= 22 Then
                                        Tempdtstr = SplitDateSTP(CalcDt, "/")
                                        If Tempdtstr(0) < 12 Then
                                            CalcDt = CDateSTP(Tempdtstr(0) + 1 & "/" & 1 & "/" & Tempdtstr(2))
                                        Else
                                            CalcDt = CDateSTP(1 & "/" & 1 & "/" & Tempdtstr(2) + 1)
                                        End If
                                    End If
                                Else
                                    If rbcapital.Checked = False Then
                                        If STPdt.SelectedItem.Text <> "--" Then
                                            If CInt(STPdt.SelectedItem.Value) > 28 Then
                                                Math.DivRem(CInt(SplitDateSTP(sqlrd(0), "/")(2)), 4, valReminder)
                                                If valReminder <> 0 Then
                                                    If CInt(STPdt.SelectedItem.Value) > 28 And CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 2 Then
                                                        STP_date = 28
                                                    ElseIf CInt(STPdt.SelectedItem.Value) > 29 And (CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 4 Or CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 6 Or CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 9 Or CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 11) Then
                                                        STP_date = 30
                                                    Else
                                                        STP_date = CInt(STPdt.SelectedItem.Value)
                                                    End If
                                                Else
                                                    If CInt(STPdt.SelectedItem.Value) > 28 And CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 2 Then
                                                        STP_date = 29
                                                    ElseIf CInt(STPdt.SelectedItem.Value) > 29 And (CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 4 Or CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 6 Or CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 9 Or CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 11) Then
                                                        STP_date = 30
                                                    Else
                                                        STP_date = CInt(STPdt.SelectedItem.Value)
                                                    End If
                                                End If
                                                CalcDt = CDateSTP(SplitDateSTP(sqlrd(0), "/")(0) & "/" & STP_date & "/" & SplitDateSTP(sqlrd(0), "/")(2))
                                            Else
                                                CalcDt = CDateSTP(SplitDateSTP(sqlrd(0), "/")(0) & "/" & STP_date & "/" & SplitDateSTP(sqlrd(0), "/")(2))
                                            End If
                                        Else
                                            If CInt(SplitDateSTP(sqlrd(0), "/")(1)) > 28 Then
                                                Math.DivRem(CInt(Tempdtstr(2)), 4, valReminder)
                                                If valReminder <> 0 Then
                                                    If CInt(SplitDateSTP(sqlrd(0), "/")(1)) >= 28 And CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 2 Then
                                                        STP_date = 28
                                                    ElseIf CInt(SplitDateSTP(sqlrd(0), "/")(1)) > 29 And CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 4 Or CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 6 Or CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 9 Or CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 11 Then
                                                        STP_date = 30
                                                    Else
                                                        STP_date = CInt(SplitDateSTP(sqlrd(0), "/")(1))
                                                    End If
                                                Else
                                                    If CInt(SplitDateSTP(sqlrd(0), "/")(1)) >= 28 And CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 2 Then
                                                        STP_date = 29
                                                    ElseIf CInt(SplitDateSTP(sqlrd(0), "/")(1)) > 29 And CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 4 Or CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 6 Or CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 9 Or CInt(SplitDateSTP(sqlrd(0), "/")(0)) = 11 Then
                                                        STP_date = 30
                                                    Else
                                                        STP_date = CInt(SplitDateSTP(sqlrd(0), "/")(1))
                                                    End If
                                                End If
                                                CalcDt = CDateSTP(CInt(SplitDateSTP(sqlrd(0), "/")(0)) & "/" & STP_date & "/" & CInt(SplitDateSTP(sqlrd(0), "/")(2)))
                                            Else
                                                CalcDt = CDateSTP(SplitDateSTP(sqlrd(0), "/")(0) & "/" & CInt(SplitDateSTP(sqlrd(0), "/")(1)) & "/" & SplitDateSTP(sqlrd(0), "/")(2))
                                            End If
                                        End If
                                    Else
                                        CalcDt = CDateSTP(CInt(SplitDateSTP(sqlrd(0), "/")(0)) & "/" & STP_date & "/" & CInt(SplitDateSTP(sqlrd(0), "/")(2)))
                                    End If
                                End If
                            Else
                                '***  Manish  For Weekly ***
                                If ddperiod.SelectedItem.Text = "Weekly" Then
                                    STP_date1 = SplitDateSTP(CalcDt, "/")(1)
                                    If STP_date1 < 8 Then
                                        Tempdtstr = SplitDateSTP(CalcDt, "/")
                                        CalcDt = CDateSTP(Tempdtstr(0) & "/" & 8 & "/" & Tempdtstr(2))
                                    ElseIf STP_date1 >= 8 And STP_date1 < 15 Then
                                        Tempdtstr = SplitDateSTP(CalcDt, "/")
                                        CalcDt = CDateSTP(Tempdtstr(0) & "/" & 15 & "/" & Tempdtstr(2))
                                    ElseIf STP_date1 >= 15 And STP_date1 < 22 Then
                                        Tempdtstr = SplitDateSTP(CalcDt, "/")
                                        CalcDt = CDateSTP(Tempdtstr(0) & "/" & 22 & "/" & Tempdtstr(2))
                                    ElseIf STP_date1 >= 22 Then
                                        Tempdtstr = SplitDateSTP(CalcDt, "/")
                                        If Tempdtstr(0) < 12 Then
                                            CalcDt = CDateSTP(Tempdtstr(0) + 1 & "/" & 1 & "/" & Tempdtstr(2))
                                        Else
                                            CalcDt = CDateSTP(1 & "/" & 1 & "/" & Tempdtstr(2) + 1)
                                        End If
                                    End If

                                Else
                                    'By Jayendra as on 26Dec2008 
                                    If ddperiod.SelectedItem.Text = "Weekly" Then
                                        'STP_date = STP_date + 1
                                        CalcDt = DateAdd(DateInterval.Day, PrdVal, sqlrd(0))
                                    Else
                                        CalcDt = DateAdd(DateInterval.Month, PrdVal, sqlrd(0))
                                    End If
                                    'till here

                                    'CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
                                    Tempdtstr = SplitDateSTP(CalcDt, "/")
                                    If rbcapital.Checked = False Then
                                        If STPdt.SelectedItem.Text <> "--" Then
                                            If CInt(STPdt.SelectedItem.Value) > 28 Then
                                                Math.DivRem(CInt(Tempdtstr(2)), 4, valReminder)
                                                If valReminder <> 0 Then
                                                    If CInt(STPdt.SelectedItem.Value) > 28 And CInt(Tempdtstr(0)) = 2 Then
                                                        STP_date = 28
                                                    ElseIf CInt(STPdt.SelectedItem.Value) > 29 And (CInt(Tempdtstr(0)) = 4 Or CInt(Tempdtstr(0)) = 6 Or CInt(Tempdtstr(0)) = 9 Or CInt(Tempdtstr(0)) = 11) Then
                                                        STP_date = 30
                                                    Else
                                                        STP_date = CInt(STPdt.SelectedItem.Value)
                                                    End If
                                                Else
                                                    If CInt(STPdt.SelectedItem.Value) > 28 And CInt(Tempdtstr(0)) = 2 Then
                                                        STP_date = 29
                                                    ElseIf CInt(STPdt.SelectedItem.Value) > 29 And (CInt(Tempdtstr(0)) = 4 Or CInt(Tempdtstr(0)) = 6 Or CInt(Tempdtstr(0)) = 9 Or CInt(Tempdtstr(0)) = 11) Then
                                                        STP_date = 30
                                                    Else
                                                        STP_date = CInt(STPdt.SelectedItem.Value)
                                                    End If
                                                End If
                                                CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                            Else
                                                CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                            End If
                                        Else
                                            'CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                            If CInt(Tempdtstr(1)) > 28 Then
                                                Math.DivRem(CInt(Tempdtstr(2)), 4, valReminder)
                                                If valReminder <> 0 Then
                                                    If CInt(Tempdtstr(1)) > 28 And CInt(Tempdtstr(0)) = 2 Then
                                                        STP_date = 28
                                                    ElseIf CInt(Tempdtstr(1)) > 29 And (CInt(Tempdtstr(0)) = 4 Or CInt(Tempdtstr(0)) = 6 Or CInt(Tempdtstr(0)) = 9 Or CInt(Tempdtstr(0)) = 11) Then
                                                        STP_date = 30
                                                    Else
                                                        STP_date = CInt(Tempdtstr(1))
                                                    End If
                                                Else
                                                    If CInt(Tempdtstr(1)) > 28 And CInt(Tempdtstr(0)) = 2 Then
                                                        STP_date = 29
                                                    ElseIf CInt(Tempdtstr(1)) > 29 And (CInt(Tempdtstr(0)) = 4 Or CInt(Tempdtstr(0)) = 6 Or CInt(Tempdtstr(0)) = 9 Or CInt(Tempdtstr(0)) = 11) Then
                                                        STP_date = 30
                                                    Else
                                                        STP_date = CInt(Tempdtstr(1))
                                                    End If
                                                End If
                                                CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                            Else
                                                CalcDt = CDateSTP(Tempdtstr(0) & "/" & CInt(Tempdtstr(1)) & "/" & Tempdtstr(2))
                                            End If
                                        End If
                                    Else
                                        CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                    End If
                                End If
                            End If
                        Else
                            ' CalcDt = DateAdd(DateInterval.Day, PrdVal, CalcDt)'**MANISH
                            If SplitDateSTP(sqlrd(0), "/")(1) < STP_date Then
                                STP_date1 = SplitDateSTP(CalcDt, "/")(1)
                                If STP_date1 >= 11 Then
                                    Tempdtstr = SplitDateSTP(CalcDt, "/")
                                    'CalcDt = CDateSTP(Tempdtstr(0) + 1 & "/" & 1 & "/" & Tempdtstr(2))
                                    If Tempdtstr(0) < 12 Then
                                        CalcDt = CDateSTP(Tempdtstr(0) + 1 & "/" & 1 & "/" & Tempdtstr(2))
                                    Else
                                        CalcDt = CDateSTP(1 & "/" & 1 & "/" & Tempdtstr(2) + 1)
                                    End If
                                ElseIf STP_date1 < 11 Then
                                    Tempdtstr = SplitDateSTP(CalcDt, "/")
                                    'CalcDt = CDateSTP(Tempdtstr(0) & "/" & 15 & "/" & Tempdtstr(2))
                                    If Tempdtstr(0) <= 12 Then
                                        CalcDt = CDateSTP(Tempdtstr(0) & "/" & 15 & "/" & Tempdtstr(2))
                                    End If
                                End If
                            Else

                                STP_date1 = SplitDateSTP(CalcDt, "/")(1)
                                If STP_date1 >= 11 Then
                                    Tempdtstr = SplitDateSTP(CalcDt, "/")
                                    'CalcDt = CDateSTP(Tempdtstr(0) + 1 & "/" & 1 & "/" & Tempdtstr(2))
                                    If Tempdtstr(0) < 12 Then
                                        CalcDt = CDateSTP(Tempdtstr(0) + 1 & "/" & 1 & "/" & Tempdtstr(2))
                                    Else
                                        CalcDt = CDateSTP(1 & "/" & 1 & "/" & Tempdtstr(2) + 1)
                                    End If
                                ElseIf STP_date1 < 11 Then
                                    Tempdtstr = SplitDateSTP(CalcDt, "/")
                                    'CalcDt = CDateSTP(Tempdtstr(0) & "/" & 15 & "/" & Tempdtstr(2))
                                    If Tempdtstr(0) <= 12 Then
                                        CalcDt = CDateSTP(Tempdtstr(0) & "/" & 15 & "/" & Tempdtstr(2))
                                    End If
                                End If
                            End If
                        End If
                        Rowcount += 1
                        chkdate = CalcDt
                        TrueFlg = False
                        'NewFlg = False
                    End If
                    j += 1
NextDate:
                    'Loop While Sqlrd.Read
                Next
            Else
                Exit Sub
            End If

            Sqlcon.Close()
            Sqlcon.Dispose()

            Sqlcon = New SqlConnection(constr)
            Sqlcon.Open()
            'strsql = "Select rmf_todt,rmf_nav from nav_reg where rmf_scheme='" & scheme_code_from & "' and rmf_plan='" & plan_code_from & "' And rmf_todt<'" & Valdt & "' order by rmf_todt"''Valdt
            strsql = "Select (nav_rs-53)/76,dateadd(d,276,[date]) from nav_rec where sch_code='" & ddtrfrom.SelectedItem.Value & "' And dateadd(d,276,[date])<='" & Valdt.ToString("dd MMM yyyy") & "' order by dateadd(d,276,[date]) desc"

            'strsql = "Select (nav_rs-53)/76,dateadd(d,276,[date]) from nav_rec where sch_code='" & ddtrfrom.SelectedItem.Value & "' And dateadd(d,276,[date])>='" & fmt(txtvalue.Text) & "' order by dateadd(d,276,[date])"
            Sqlcom = New SqlCommand(strsql, Sqlcon)
            Sqlrd = Sqlcom.ExecuteReader
            'stp new
            Dim DtSqlrdTo1 As DataTable = New DataTable
            DtSqlrdTo1.Load(Sqlrd)
            Sqlcon.Close()
            'end
            'If Sqlrd.Read Then
            If DtSqlrdTo1.Rows.Count > 0 Then
                For Each Sqlrd As DataRow In DtSqlrdTo1.Rows
                    'Do
                    If IsDBNull(Sqlrd(0)) = False Then
                        Iprw = Ipdt.NewRow
                        Iprw(0) = Format(CDate(Sqlrd(1)), "dd-MMM-yyyy")
                        X2Date = Sqlrd(1)
                        Iprw(1) = Math.Round(Sqlrd(0), 4)
                        X2Nav = Sqlrd(0)

                        Iprw(3) = Math.Round(cuml_units, 2)
                        Iprw(4) = Math.Round(Iprw(3) * Sqlrd(0), 4)
                        Temp = Iprw(4)
                        txtbal.Text = Math.Round(cuml_units * Iprw(1), 2)
                        dt_as_on_1 = Iprw(0)
                        Ipdt.Rows.Add(Iprw)
                        Exit For
                    End If
                    'Loop While Sqlrd.Read
                Next
            Else
                '//calculate the latest date available b4 as on date
                '****vishal calculate present vaule as per last available date b4 as on date
                If Sqlcon.State = ConnectionState.Open Then
                    Sqlcon.Close()
                End If
                Sqlcon = New SqlConnection(constr)
                Sqlcon.Open()

                '' strsql = "Select (nav_rs-53)/76,dateadd(d,276,[date]) from nav_rec where sch_code='" & ddtrfrom.SelectedItem.Value & "' And dateadd(d,276,[date])<='" & fmt(txtvalue.Text) & "' order by dateadd(d,276,[date]) desc"
                strsql = "Select (nav_rs-53)/76,dateadd(d,276,[date]) from nav_rec where sch_code='" & ddtrfrom.SelectedItem.Value & "' And dateadd(d,276,[date])<='" & Date.Parse(txtvalue.Text).ToString("dd MMM yyyy") & "' order by dateadd(d,276,[date]) desc"

                Sqlcom = New SqlCommand(strsql, Sqlcon)
                Sqlrd = Sqlcom.ExecuteReader
                ' new syed 
                Dim DtSqlrd1 As DataTable = New DataTable
                DtSqlrd1.Load(rdSTP)
                Sqlcon.Close()
                'end

                If DtSqlrd1.Rows.Count > 0 Then
                    'If Sqlrd.Read Then
                    'Do
                    For Each Sqlrd As DataRow In DtSqlrd1.Rows
                        If IsDBNull(Sqlrd(0)) = False Then
                            Iprw = Ipdt.NewRow
                            Iprw(0) = Format(CDate(Sqlrd(1)), "dd-MMM-yyyy")
                            X2Date = Sqlrd(1)
                            Iprw(1) = Math.Round(Sqlrd(0), 4)
                            X2Nav = Sqlrd(0)

                            Iprw(3) = Math.Round(cuml_units, 2)
                            Iprw(4) = Math.Round(Iprw(3) * Sqlrd(0), 4)
                            Temp = Iprw(4)
                            txtbal.Text = Math.Round(cuml_units * Iprw(1), 2)
                            dt_as_on_1 = Iprw(0)
                            Ipdt.Rows.Add(Iprw)
                            'Exit Do
                            Exit For
                        End If
                    Next
                    'Loop While Sqlrd.Read
                End If
            End If
            Dim dtFrom As DataTable
            dtFrom = Ipdt.Copy
            Session("SIP") = Ipdt
            Session("S1") = Ipdt
            Dstp.DataSource = Ipdt
            Dstp.DataBind()
            Dstp.Visible = True


            '''''--------------GRID TWO-----------------------------
            '''''--------------GRID TWO-----------------------------
            Dim BalanceCash = CashFlow
            CashFlow = CashFlowOrginal
            Ipdt = New DataTable
            Rowcounter = 0
            Rowcount = 0
            ReDim Currval(0)
            Dim Transfer_count As Integer
            Transfer_count = 0

            'Colstr = "Date#NAV#Units#Cumulative Units"
            Colstr = "Date#NAV#Units#Cumulative Units#Dividend#Current Value#Investment In Index#Cumulative Amount#Value Of Investments"
            ColArr = Split(Colstr, "#")
            For i = 0 To 8
                Ipcol = New DataColumn
                Ipcol.ColumnName = ColArr(i)
                Ipdt.Columns.Add(Ipcol)
            Next i
            j = 0
            m = 0
            x = 0
            TotUnits = 0
            CalcDt = frdt
            Dstp1.HeaderStyle.ForeColor = Color.White
            '//Vishal 06-Aug-07 Transfer the amount as per the  cash flow and date present in first grid 
            '//only for capital appreciations
            Dim CashFlowDate As Date
            Dim PREVIOUS_DATE As Date

            '*** stp new

            Dim DtDivRecAdvTo As DataTable = New DataTable
            sqlcon1 = New SqlConnection(constr)
            sqlcon1.Open()
            If rbindivd.Checked Then
                strsql = "Select (divid_pt-53)/76,dateadd(d,276,date) from div_rec_adv where sch_code='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date)>='" & frdt.ToString("dd MMM yyyy") & "' And date<='" & todt.ToString("dd MMM yyyy") & "'"
            ElseIf rbcorp.Checked = True Then
                strsql = "Select (divid_pt_corp-53)/76,dateadd(d,276,Date) from div_rec_adv where sch_code='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date)>='" & frdt.ToString("dd MMM yyyy") & "' And date<='" & todt.ToString("dd MMM yyyy") & "'"
            End If
            Sqlcom = New SqlCommand(strsql, sqlcon1)
            sqlrd1 = Sqlcom.ExecuteReader
            DtDivRecAdvTo.Load(sqlrd1)
            sqlcon1.Close()
            sqlcon1.Dispose()

            'end

            If Fixed_Transfer = False Then
                For i = 0 To UBound(cash_flow_capital)
                    '//get nav for the date
                    CashFlow = cash_flow_capital(i)
                    CashFlowDate = cash_flow_date(i)
                    If i = 0 Then
                        PREVIOUS_DATE = cash_flow_date(i)
                    Else
                        PREVIOUS_DATE = cash_flow_date(i - 1)
                    End If
                    Sqlcon = New SqlConnection(constr)
                    Sqlcon.Open()
                    strsql = "Select top 1 dateadd(d,276,date),(nav_rs-53)/76 from nav_rec where sch_code='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,[date]) >='" & CashFlowDate.ToString("dd MMM yyyy") & "' And date<='" & todt.ToString("dd MMM yyyy") & "'order by dateadd(d,276,[date])"
                    Sqlcom = New SqlCommand(strsql, Sqlcon)
                    rdSTP1 = Sqlcom.ExecuteReader

                    'stp new 
                    Dim DtSqlrdTo2 As DataTable = New DataTable
                    DtSqlrdTo2.Load(rdSTP1)
                    Sqlcon.Close()
                    'end
                    If DtSqlrdTo2.Rows.Count > 0 Then
                        Dim Sqlrd As DataRow = DtSqlrdTo2(0)
                        'If Sqlrd.Read Then
                        If Not IsDBNull(Sqlrd(1)) Then
                            Iprw = Ipdt.NewRow
                            Rowcounter += 1
                            Iprw(0) = Format(CDate(Sqlrd(0)), "dd-MMM-yyyy")
                            CalcDt = Sqlrd(0)
                            ReDim Preserve DtArr(Rowcount)
                            If IsDBNull(Iprw(0)) = False Then
                                DtArr(Rowcount) = Sqlrd(0)
                            End If
                            Transfer_count = Transfer_count + 1
                            Iprw(1) = Math.Round(Sqlrd(1), 4)
                            If CashFlow > 0 Then
                                Iprw(2) = Math.Round(CashFlow / Sqlrd(1), 4)
                                TotUnits = TotUnits + Iprw(2)
                                NewUnts = Math.Round(CashFlow / Sqlrd(1), 4)
                                Iprw(3) = CumUnts + NewUnts
                                CumUnts = CumUnts + NewUnts
                            Else
                                Iprw(2) = 0
                                TotUnits = TotUnits + 0
                                NewUnts = 0
                                Iprw(3) = CumUnts + NewUnts
                                CumUnts = CumUnts + NewUnts
                            End If
                            'sqlcon1 = New SqlConnection(constr)
                            'sqlcon1.Open()
                            'If rbindivd.Checked Then
                            '    strsql = "Select sum((divid_pt-53)/76) from div_rec_adv where sch_code='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date)>='" & Format(PREVIOUS_DATE, "MM/dd/yyyy") & "' And dateadd(d,276,date)<='" & Format(CashFlowDate, "MM/dd/yyyy") & "'"
                            'ElseIf rbcorp.Checked = True Then
                            '    strsql = "Select sum((divid_pt_corp-53)/76) from div_rec_adv where sch_code='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date)>='" & Format(PREVIOUS_DATE, "MM/dd/yyyy") & "' And dateadd(d,276,date)<='" & Format(CashFlowDate, "MM/dd/yyyy") & "'"
                            'End If
                            'Sqlcom = New SqlCommand(strsql, sqlcon1)
                            'sqlrd1 = Sqlcom.ExecuteReader
                            'If sqlrd1.Read Then
                            '    If IsDBNull(sqlrd1(0)) = False Then
                            '        Iprw(4) = sqlrd1(0)
                            '    Else
                            '        Iprw(4) = 0
                            '    End If
                            'End If
                            'sqlcon1.Close()
                            'sqlcon1.Dispose()

                            '*** New 
                            Dim val1 = DtDivRecAdvTo.AsEnumerable().Where(Function(y) (y(1) >= PREVIOUS_DATE) And (y(1) <= CashFlowDate)).Select(Function(n) n(0))
                            If val1.Any() Then
                                Dim Sum = (From p As Double In val1 Select p).Sum()
                                If IsDBNull(Sum) = False Then
                                    Iprw(4) = Sum
                                Else
                                    Iprw(4) = 0
                                End If
                            End If


                            Iprw(5) = Math.Round(CumUnts * Sqlrd(1), 2)
                            If m <= x Then
                                Iprw(6) = Math.Round(((CashFlow * IndexArr(m)) / IniIndex), 2)
                            End If
                            Iprw(7) = Iprw(5)
                            If x <= UBound(ValueAfter) Then
                                Iprw(8) = Math.Round(Iprw(7) + IIf(IsNumeric(ValueAfter(x)), ValueAfter(x), 0), 2)
                                x += 1
                            End If
                            ReDim Preserve Currval(Rowcount)
                            Currval(Rowcount) = IIf(IsNumeric(Iprw(8)), Iprw(8), 0)
                            'by Jayendra 10/01/2009
                            txtacc.Text = Math.Round(Iprw(2) * Iprw(1), 2)
                            'txtacc.Text = Math.Round(Iprw(3) * Iprw(1), 2)
                            'till here
                            Ipdt.Rows.Add(Iprw)
                            m += 1
                            Rowcount += 1
                        End If
                        'End If
                    End If
                Next
            Else  '//fixed transfer
                Sqlcon = New SqlConnection(constr)
                Sqlcon.Open()
                strsql = "Select dateadd(d,276,date),(nav_rs-53)/76 from nav_rec where sch_code='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,[date]) >='" & frdt.ToString("dd MMM yyyy") & "' And date<='" & todt.ToString("dd MMM yyyy") & "' order by dateadd(d,276,[date])"
                Sqlcom = New SqlCommand(strsql, Sqlcon)
                Sqlrd = Sqlcom.ExecuteReader

                '*** stp new

                Dim DtSqlrdTo As DataTable = New DataTable
                DtSqlrdTo.Load(Sqlrd)
                Sqlcon.Close()
                Sqlcon.Dispose()

                'end

                CalcDt = frdt
                If ddperiod.SelectedItem.Text <> "Fortnightly" Then
                    If ddperiod.SelectedItem.Text = "Weekly" Then
                        STP_date1 = SplitDateSTP(CalcDt, "/")(1)
                        If STP_date1 < 8 Then
                            Tempdtstr = SplitDateSTP(CalcDt, "/")
                            CalcDt = CDateSTP(Tempdtstr(0) & "/" & 8 & "/" & Tempdtstr(2))
                        ElseIf STP_date1 >= 8 And STP_date1 < 15 Then
                            Tempdtstr = SplitDateSTP(CalcDt, "/")
                            CalcDt = CDateSTP(Tempdtstr(0) & "/" & 15 & "/" & Tempdtstr(2))
                        ElseIf STP_date1 >= 15 And STP_date1 < 22 Then
                            Tempdtstr = SplitDateSTP(CalcDt, "/")
                            CalcDt = CDateSTP(Tempdtstr(0) & "/" & 22 & "/" & Tempdtstr(2))
                        ElseIf STP_date1 >= 22 Then
                            Tempdtstr = SplitDateSTP(CalcDt, "/")
                            If Tempdtstr(0) < 12 Then
                                CalcDt = CDateSTP(Tempdtstr(0) + 1 & "/" & 1 & "/" & Tempdtstr(2))
                            Else
                                CalcDt = CDateSTP(1 & "/" & 1 & "/" & Tempdtstr(2) + 1)
                            End If
                        End If
                    Else
                        CalcDt = DateAdd(DateInterval.Month, PrdVal, CalcDt)
                        Tempdtstr = SplitDateSTP(CalcDt, "/")
                        If rbcapital.Checked = False Then
                            If STPdt.SelectedItem.Text <> "--" Then
                                If CInt(STPdt.SelectedItem.Value) > 28 Then
                                    Math.DivRem(CInt(Tempdtstr(2)), 4, valReminder)
                                    If valReminder <> 0 Then
                                        If CInt(STPdt.SelectedItem.Value) > 28 And CInt(Tempdtstr(0)) = 2 Then
                                            STP_date = 28
                                        ElseIf CInt(STPdt.SelectedItem.Value) > 29 And (CInt(Tempdtstr(0)) = 4 Or CInt(Tempdtstr(0)) = 6 Or CInt(Tempdtstr(0)) = 9 Or CInt(Tempdtstr(0)) = 11) Then
                                            STP_date = 30
                                        Else
                                            STP_date = CInt(STPdt.SelectedItem.Value)
                                        End If
                                    Else
                                        If CInt(STPdt.SelectedItem.Value) > 28 And CInt(Tempdtstr(0)) = 2 Then
                                            STP_date = 29
                                        ElseIf CInt(STPdt.SelectedItem.Value) > 29 And (CInt(Tempdtstr(0)) = 4 Or CInt(Tempdtstr(0)) = 6 Or CInt(Tempdtstr(0)) = 9 Or CInt(Tempdtstr(0)) = 11) Then
                                            STP_date = 30
                                        Else
                                            STP_date = CInt(STPdt.SelectedItem.Value)
                                        End If
                                    End If
                                    CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                Else
                                    CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                End If
                            Else
                                If CInt(Tempdtstr(0)) > 28 Then
                                    Math.DivRem(CInt(Tempdtstr(2)), 4, valReminder)
                                    If valReminder <> 0 Then
                                        If CInt(Tempdtstr(0)) > 28 And CInt(Tempdtstr(0)) = 2 Then
                                            STP_date = 28
                                        ElseIf CInt(Tempdtstr(0)) > 29 And (CInt(Tempdtstr(0)) = 4 Or CInt(Tempdtstr(0)) = 6 Or CInt(Tempdtstr(0)) = 9 Or CInt(Tempdtstr(0)) = 11) Then
                                            STP_date = 30
                                        Else
                                            STP_date = CInt(Tempdtstr(0))
                                        End If
                                    Else
                                        If CInt(Tempdtstr(0)) > 28 And CInt(Tempdtstr(0)) = 2 Then
                                            STP_date = 29
                                        ElseIf CInt(Tempdtstr(0)) > 29 And (CInt(Tempdtstr(0)) = 4 Or CInt(Tempdtstr(0)) = 6 Or CInt(Tempdtstr(0)) = 9 Or CInt(Tempdtstr(0)) = 11) Then
                                            STP_date = 30
                                        Else
                                            STP_date = CInt(Tempdtstr(0))
                                        End If
                                    End If
                                    CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                Else

                                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                    '''''''''''''''changed for daily. Original line was as follows
                                    '''''''''''''''CalcDt = CDateSTP(Tempdtstr(0) & "/" & CInt(Tempdtstr(0)) & "/" & Tempdtstr(2))
                                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                    CalcDt = CDateSTP(Tempdtstr(0) & "/" & CInt(Tempdtstr(1)) & "/" & Tempdtstr(2))


                                End If
                                'CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                            End If
                        Else
                            CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                        End If
                    End If
                Else
                    ' CalcDt = DateAdd(DateInterval.Day, PrdVal, CalcDt)'**MANISH

                    STP_date1 = SplitDateSTP(CalcDt, "/")(1)
                    If STP_date1 >= 11 Then
                        Tempdtstr = SplitDateSTP(CalcDt, "/")
                        'CalcDt = CDateSTP(Tempdtstr(0) + 1 & "/" & 1 & "/" & Tempdtstr(2))
                        If Tempdtstr(0) < 12 Then
                            CalcDt = CDateSTP(Tempdtstr(0) + 1 & "/" & 1 & "/" & Tempdtstr(2))
                        Else
                            CalcDt = CDateSTP(1 & "/" & 1 & "/" & Tempdtstr(2) + 1)
                        End If
                    ElseIf STP_date1 < 11 Then
                        Tempdtstr = SplitDateSTP(CalcDt, "/")
                        'CalcDt = CDateSTP(Tempdtstr(0) & "/" & 15 & "/" & Tempdtstr(2))
                        If Tempdtstr(0) <= 12 Then
                            CalcDt = CDateSTP(Tempdtstr(0) & "/" & 15 & "/" & Tempdtstr(2))
                        End If
                    End If

                End If
                'If Sqlrd.Read Then
                If DtSqlrdTo.Rows.Count > 0 Then
                    For Each Sqlrd As DataRow In DtSqlrdTo.Rows
                        'Do
                        If j = 0 And Sqlrd(0) >= CalcDt And CalcDt <= todt Then
                            Iprw = Ipdt.NewRow
                            Iprw(0) = Format(CDate(Sqlrd(0)), "dd/MM/yyyy")
                            CalcDt = Sqlrd(0)
                            Iprw(5) = Amt
                            Iprw(6) = Amt
                            Ipdt.Rows.Add(Iprw)
                            CumUnts = 0
                            m += 1
                            Iprw = Ipdt.NewRow
                            Rowcounter += 1
                            Iprw(0) = Format(CDate(Sqlrd(0)), "dd-MMM-yyyy")
                            ReDim Preserve DtArr(Rowcount)
                            DtArr(Rowcount) = Sqlrd(0)
                            '//for capital appreciation cash flow 
                            If Fixed_Transfer = False Then
                                CashFlow = 0
                                CashFlow = cash_flow_capital(Transfer_count)
                                Transfer_count = Transfer_count + 1
                            End If
                            'vishal cash flow of capital appreciation

                            Iprw(1) = Math.Round(Sqlrd(1), 4)
                            If CashFlow > 0 Then
                                Iprw(2) = Math.Round(CashFlow / Sqlrd(1), 4)
                                TotUnits = TotUnits + Iprw(2)
                                NewUnts = Math.Round(CashFlow / Sqlrd(1), 4)
                                Iprw(3) = CumUnts + NewUnts
                                CumUnts = CumUnts + NewUnts
                            Else
                                Iprw(2) = 0
                                TotUnits = TotUnits + 0
                                NewUnts = 0
                                Iprw(3) = CumUnts + NewUnts
                                CumUnts = CumUnts + NewUnts
                            End If
                            'sqlcon1 = New SqlConnection(constr)
                            'sqlcon1.Open()
                            'If rbindivd.Checked Then
                            '    strsql = "Select sum((divid_pt-53)/76) from div_rec_adv where sch_code='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date)>='" & cdates(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And dateadd(d,276,date)<='" & CDateSTP(Iprw(0)).ToString("dd MMM yyyy") & "'"
                            'ElseIf rbcorp.Checked = True Then
                            '    strsql = "Select sum((divid_pt_corp-53)/76) from div_rec_adv where sch_code='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date)>='" & CDateSTP(Ipdt.Rows(Rowcounter - 1).Item(0)).ToString("dd MMM yyyy") & "' And dateadd(d,276,date)<='" & CDateSTP(Iprw(0)).ToString("dd MMM yyyy") & "'"
                            'End If
                            'Sqlcom = New SqlCommand(strsql, sqlcon1)
                            'sqlrd1 = Sqlcom.ExecuteReader
                            'If sqlrd1.Read Then
                            '    If IsDBNull(sqlrd1(0)) = False Then
                            '        Iprw(4) = sqlrd1(0)
                            '    Else
                            '        Iprw(4) = 0
                            '    End If
                            'End If
                            'sqlcon1.Close()
                            'sqlcon1.Dispose()

                            '*** new cdatesSql
                            Dim val2 = DtDivRecAdv.AsEnumerable().Where(Function(v) ((v(1) >= cdatesSql(Ipdt.Rows(Rowcounter - 1).Item(0))) And (v(1) <= cdatesSql(Iprw(0))))).Select(Function(n) n(0))
                            If val2.Any() Then
                                Dim Sum2 = (From p As Double In val2 Select p).Sum()
                                If IsDBNull(Sum2) = False Then
                                    Iprw(4) = Sum2
                                Else
                                    Iprw(4) = 0
                                End If
                            End If
                            '*** end new
                            Iprw(5) = Math.Round(CumUnts * Sqlrd(1), 2)

                            Ipdt.Rows.Add(Iprw)
                            If ddperiod.SelectedItem.Text <> "Fortnightly" Then
                                If SplitDateSTP(Sqlrd(0), "/")(1) < STP_date Then
                                    If ddperiod.SelectedItem.Text = "Weekly" Then
                                        '''If Day(chkdate) <= STP_date Then
                                        '''    chkdate = DateAdd(DateInterval.Day, PrdVal, CalcDt)
                                        '''End If
                                        STP_date1 = SplitDateSTP(CalcDt, "/")(1)

                                        If STP_date1 < 8 Then
                                            Tempdtstr = SplitDateSTP(CalcDt, "/")
                                            CalcDt = CDateSTP(Tempdtstr(0) & "/" & 8 & "/" & Tempdtstr(2))
                                        ElseIf STP_date1 >= 8 And STP_date1 < 15 Then
                                            Tempdtstr = SplitDateSTP(CalcDt, "/")
                                            CalcDt = CDateSTP(Tempdtstr(0) & "/" & 15 & "/" & Tempdtstr(2))
                                        ElseIf STP_date1 >= 15 And STP_date1 < 22 Then
                                            Tempdtstr = SplitDateSTP(CalcDt, "/")
                                            CalcDt = CDateSTP(Tempdtstr(0) & "/" & 22 & "/" & Tempdtstr(2))
                                        ElseIf STP_date1 >= 22 Then
                                            Tempdtstr = SplitDateSTP(CalcDt, "/")
                                            If Tempdtstr(0) < 12 Then
                                                CalcDt = CDateSTP(Tempdtstr(0) + 1 & "/" & 1 & "/" & Tempdtstr(2))
                                            Else
                                                CalcDt = CDateSTP(1 & "/" & 1 & "/" & Tempdtstr(2) + 1)
                                            End If
                                        End If
                                    Else
                                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                        '''''''''''''' IF part was added for 'DAILY' option
                                        '''''''''''''' Original part is Else condition 
                                        ''''''''''''''(remove 'IF' part if not required)
                                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                        If ddperiod.SelectedItem.Text = "Daily" Then
                                            ''CalcDt = CDate(Split(Sqlrd(0), "/")(0) & "/" & STP_date & "/" & Split(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
                                            CalcDt = DateAdd(DateInterval.Day, 1, CalcDt)
                                        Else
                                            CalcDt = CDateSTP(SplitDateSTP(Sqlrd(0), "/")(0) & "/" & STP_date & "/" & SplitDateSTP(Sqlrd(0), "/")(2))     'DateAdd(DateInterval.Month, PrdVal, CalcDt)
                                        End If
                                    End If
                                Else

                                    '***  Manish  For Weekly ***
                                    If ddperiod.SelectedItem.Text = "Weekly" Then
                                        '''If Day(chkdate) <= STP_date Then
                                        '''    chkdate = DateAdd(DateInterval.Day, PrdVal, CalcDt)
                                        '''End If
                                        STP_date1 = SplitDateSTP(CalcDt, "/")(1)

                                        If STP_date1 < 8 Then
                                            Tempdtstr = SplitDateSTP(CalcDt, "/")
                                            CalcDt = CDateSTP(Tempdtstr(0) & "/" & 8 & "/" & Tempdtstr(2))
                                        ElseIf STP_date1 >= 8 And STP_date1 < 15 Then
                                            Tempdtstr = SplitDateSTP(CalcDt, "/")
                                            CalcDt = CDateSTP(Tempdtstr(0) & "/" & 15 & "/" & Tempdtstr(2))
                                        ElseIf STP_date1 >= 15 And STP_date1 < 22 Then
                                            Tempdtstr = SplitDateSTP(CalcDt, "/")
                                            CalcDt = CDateSTP(Tempdtstr(0) & "/" & 22 & "/" & Tempdtstr(2))
                                        ElseIf STP_date1 >= 22 Then
                                            Tempdtstr = SplitDateSTP(CalcDt, "/")
                                            If Tempdtstr(0) < 12 Then
                                                CalcDt = CDateSTP(Tempdtstr(0) + 1 & "/" & 1 & "/" & Tempdtstr(2))
                                            Else
                                                CalcDt = CDateSTP(1 & "/" & 1 & "/" & Tempdtstr(2) + 1)
                                            End If
                                        End If
                                    Else
                                        '''By Jayendra as on 26Dec2008 
                                        ''If ddperiod.SelectedItem.Text = "Weekly" Then
                                        ''    STP_date = STP_date + 1
                                        ''Else
                                        ''    chkdate = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
                                        ''End If
                                        'till here
                                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                        '''''''''''''' IF part was added for 'DAILY' option
                                        '''''''''''''' Original part is Else condition 
                                        ''''''''''''''(remove 'IF' part if not required)
                                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                        'If ddperiod.SelectedItem.Text <> "Daily" Then
                                        CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
                                        'End If

                                        Tempdtstr = SplitDateSTP(CalcDt, "/")

                                        If rbcapital.Checked = False Then
                                            If STPdt.SelectedItem.Text <> "--" Then
                                                If CInt(STPdt.SelectedItem.Value) > 28 Then
                                                    Math.DivRem(CInt(Tempdtstr(2)), 4, valReminder)
                                                    If valReminder <> 0 Then
                                                        If CInt(STPdt.SelectedItem.Value) > 28 And CInt(Tempdtstr(0)) = 2 Then
                                                            STP_date = 28
                                                        ElseIf CInt(STPdt.SelectedItem.Value) > 29 And (CInt(Tempdtstr(0)) = 4 Or CInt(Tempdtstr(0)) = 6 Or CInt(Tempdtstr(0)) = 9 Or CInt(Tempdtstr(0)) = 11) Then
                                                            STP_date = 30
                                                        Else
                                                            STP_date = CInt(STPdt.SelectedItem.Value)
                                                        End If
                                                    Else
                                                        If CInt(STPdt.SelectedItem.Value) > 28 And CInt(Tempdtstr(0)) = 2 Then
                                                            STP_date = 29
                                                        ElseIf CInt(STPdt.SelectedItem.Value) > 29 And (CInt(Tempdtstr(0)) = 4 Or CInt(Tempdtstr(0)) = 6 Or CInt(Tempdtstr(0)) = 9 Or CInt(Tempdtstr(0)) = 11) Then
                                                            STP_date = 30
                                                        Else
                                                            STP_date = CInt(STPdt.SelectedItem.Value)
                                                        End If
                                                    End If
                                                    CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                                Else
                                                    CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                                End If
                                            Else
                                                If CInt(Tempdtstr(0)) > 28 Then
                                                    Math.DivRem(CInt(Tempdtstr(2)), 4, valReminder)
                                                    If valReminder <> 0 Then
                                                        If CInt(Tempdtstr(0)) > 28 And CInt(Tempdtstr(0)) = 2 Then
                                                            STP_date = 28
                                                        ElseIf CInt(Tempdtstr(0)) > 29 And (CInt(Tempdtstr(0)) = 4 Or CInt(Tempdtstr(0)) = 6 Or CInt(Tempdtstr(0)) = 9 Or CInt(Tempdtstr(0)) = 11) Then
                                                            STP_date = 30
                                                        Else
                                                            STP_date = CInt(Tempdtstr(0))
                                                        End If
                                                    Else
                                                        If CInt(Tempdtstr(0)) > 28 And CInt(Tempdtstr(0)) = 2 Then
                                                            STP_date = 29
                                                        ElseIf CInt(Tempdtstr(0)) > 29 And (CInt(Tempdtstr(0)) = 4 Or CInt(Tempdtstr(0)) = 6 Or CInt(Tempdtstr(0)) = 9 Or CInt(Tempdtstr(0)) = 11) Then
                                                            STP_date = 30
                                                        Else
                                                            STP_date = CInt(Tempdtstr(0))
                                                        End If
                                                    End If
                                                    CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                                Else
                                                    CalcDt = CDateSTP(Tempdtstr(0) & "/" & CInt(Tempdtstr(0)) & "/" & Tempdtstr(2))
                                                End If
                                                'CalcDt = CDate(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                            End If
                                        Else
                                            CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                        End If
                                    End If

                                End If
                            Else
                                ' CalcDt = DateAdd(DateInterval.Day, PrdVal, CalcDt)'**MANISH
                                If SplitDateSTP(Sqlrd(0), "/")(1) < STP_date Then
                                    STP_date1 = SplitDateSTP(CalcDt, "/")(1)
                                    If STP_date1 >= 11 Then
                                        Tempdtstr = SplitDateSTP(CalcDt, "/")
                                        'CalcDt = CDateSTP(Tempdtstr(0) + 1 & "/" & 1 & "/" & Tempdtstr(2))
                                        If Tempdtstr(0) < 12 Then
                                            CalcDt = CDateSTP(Tempdtstr(0) + 1 & "/" & 1 & "/" & Tempdtstr(2))
                                        Else
                                            CalcDt = CDateSTP(1 & "/" & 1 & "/" & Tempdtstr(2) + 1)
                                        End If
                                    ElseIf STP_date1 < 11 Then
                                        Tempdtstr = SplitDateSTP(CalcDt, "/")
                                        'CalcDt = CDateSTP(Tempdtstr(0) & "/" & 15 & "/" & Tempdtstr(2))
                                        If Tempdtstr(0) <= 12 Then
                                            CalcDt = CDateSTP(Tempdtstr(0) & "/" & 15 & "/" & Tempdtstr(2))
                                        End If
                                    End If
                                Else

                                    STP_date1 = SplitDateSTP(CalcDt, "/")(1)
                                    If STP_date1 >= 11 Then
                                        Tempdtstr = SplitDateSTP(CalcDt, "/")
                                        'CalcDt = CDateSTP(Tempdtstr(0) + 1 & "/" & 1 & "/" & Tempdtstr(2))
                                        If Tempdtstr(0) < 12 Then
                                            CalcDt = CDateSTP(Tempdtstr(0) + 1 & "/" & 1 & "/" & Tempdtstr(2))
                                        Else
                                            CalcDt = CDateSTP(1 & "/" & 1 & "/" & Tempdtstr(2) + 1)
                                        End If
                                    ElseIf STP_date1 < 11 Then
                                        Tempdtstr = SplitDateSTP(CalcDt, "/")
                                        'CalcDt = CDateSTP(Tempdtstr(0) & "/" & 15 & "/" & Tempdtstr(2))
                                        If Tempdtstr(0) <= 12 Then
                                            CalcDt = CDateSTP(Tempdtstr(0) & "/" & 15 & "/" & Tempdtstr(2))
                                        End If
                                    End If
                                End If
                            End If
                            stp_cashflw_grd2 = Iprw(1) * Iprw(3)
                            If m <= UBound(IndexArr) Then
                                Iprw(6) = Math.Round(((CashFlow * IndexArr(m)) / IniIndex), 2)
                            End If
                            Iprw(7) = Iprw(5)
                            If IsNothing(ValueAfter) = False Then
                                If x <= UBound(ValueAfter) Then
                                    Iprw(8) = Math.Round(Iprw(7) + ValueAfter(x), 2)
                                    x += 1
                                End If
                                Currval(Rowcount) = Iprw(8)
                                ReDim Preserve Currval(Rowcount)
                            End If
                            Rowcount += 1
                            m += 1
                            j += 1
                            '//end of first row

                        ElseIf Sqlrd(0) >= CalcDt And CalcDt <= todt Then  'Manish

                            If Sqlrd(0) <= CDateSTP(dg1_last_date) Then
                                If Sqlrd(0) = BalanceDate Then
                                    CashFlow = BalanceCash
                                End If
                                'If Sqlrd(0) = CalcDt Then
                                Iprw = Ipdt.NewRow
                                Rowcounter += 1
                                Iprw(0) = Format(CDate(Sqlrd(0)), "dd-MMM-yyyy")
                                CalcDt = Sqlrd(0)
                                ReDim Preserve DtArr(Rowcount)
                                If IsDBNull(Iprw(0)) = False Then
                                    DtArr(Rowcount) = Sqlrd(0)
                                End If
                                '//for capital appreciation cash flow 
                                If Fixed_Transfer = False Then
                                    CashFlow = 0
                                    CashFlow = cash_flow_capital(Transfer_count)
                                    Transfer_count = Transfer_count + 1
                                End If
                                'vishal cash flow of capital appreciation 
                                Iprw(1) = Math.Round(Sqlrd(1), 4)
                                'If Sqlrd(0) = CalcDt Then
                                If m <= UBound(IndexArr) Then
                                    If CashFlow > 0 Then
                                        Iprw(2) = Math.Round(CashFlow / Sqlrd(1), 4)
                                        TotUnits = TotUnits + Iprw(2)
                                        NewUnts = Math.Round(CashFlow / Sqlrd(1), 4)
                                        Iprw(3) = CumUnts + NewUnts
                                        CumUnts = CumUnts + NewUnts
                                    Else
                                        Iprw(2) = 0
                                        TotUnits = TotUnits + 0
                                        NewUnts = 0
                                        Iprw(3) = CumUnts + NewUnts
                                        CumUnts = CumUnts + NewUnts
                                    End If


                                    'sqlcon1 = New SqlConnection(constr)
                                    'sqlcon1.Open()
                                    'If rbindivd.Checked Then
                                    '    strsql = "Select sum((divid_pt-53)/76) from div_rec_adv where sch_code='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date)>='" & cdatesSql(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And dateadd(d,276,date)<='" & cdatesSql(Iprw(0).ToString()) & "'"
                                    'ElseIf rbcorp.Checked = True Then
                                    '    strsql = "Select sum((divid_pt_corp-53)/76) from div_rec_adv where sch_code='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date)>='" & cdatesSql(Ipdt.Rows(Rowcounter - 1).Item(0)) & "' And dateadd(d,276,date)<='" & cdatesSql(Iprw(0).ToString()) & "'"
                                    'End If
                                    'Sqlcom = New SqlCommand(strsql, sqlcon1)
                                    'sqlrd1 = Sqlcom.ExecuteReader
                                    'If sqlrd1.Read Then
                                    '    If IsDBNull(sqlrd1(0)) = False Then
                                    '        Iprw(4) = sqlrd1(0)
                                    '    Else
                                    '        Iprw(4) = 0
                                    '    End If
                                    'End If
                                    'sqlcon1.Close()
                                    'sqlcon1.Dispose()



                                    '*** new 
                                    Dim val = DtDivRecAdvTo.AsEnumerable().Where(Function(y) (y(1) >= cdatesSql(Ipdt.Rows(Rowcounter - 1).Item(0))) And (y(1) <= cdatesSql(Iprw(0).ToString()))).Select(Function(n) n(0))
                                    If val.Any() Then
                                        Dim Sum = (From p As Double In val Select p).Sum()
                                        If IsDBNull(Sum) = False Then
                                            Iprw(4) = Sum
                                        Else
                                            Iprw(4) = 0
                                        End If
                                    End If
                                    '***end

                                    Iprw(5) = Math.Round(CumUnts * Sqlrd(1), 2)
                                    Iprw(6) = Math.Round(((CashFlow * IndexArr(m)) / IniIndex), 2)
                                    Iprw(7) = Iprw(5)
                                    If x <= UBound(ValueAfter) Then
                                        Iprw(8) = Math.Round(Iprw(7) + ValueAfter(x), 2)
                                        x += 1
                                    End If
                                    ReDim Preserve Currval(Rowcount)
                                    Currval(Rowcount) = Iprw(8)
                                    txtacc.Text = Math.Round(Iprw(3) * Iprw(1), 2)
                                    '  End' If
                                End If
                                If ddperiod.SelectedItem.Text <> "Fortnightly" Then
                                    If SplitDateSTP(Sqlrd(0), "/")(1) < STP_date Then

                                        If ddperiod.SelectedItem.Text = "Weekly" Then
                                            'CalcDt = DateAdd(DateInterval.Day, PrdVal, Sqlrd(0))
                                            STP_date1 = SplitDateSTP(CalcDt, "/")(1)

                                            If STP_date1 < 8 Then
                                                Tempdtstr = SplitDateSTP(CalcDt, "/")
                                                CalcDt = CDateSTP(Tempdtstr(0) & "/" & 8 & "/" & Tempdtstr(2))
                                            ElseIf STP_date1 >= 8 And STP_date1 < 15 Then
                                                Tempdtstr = SplitDateSTP(CalcDt, "/")
                                                CalcDt = CDateSTP(Tempdtstr(0) & "/" & 15 & "/" & Tempdtstr(2))
                                            ElseIf STP_date1 >= 15 And STP_date1 < 22 Then
                                                Tempdtstr = SplitDateSTP(CalcDt, "/")
                                                CalcDt = CDateSTP(Tempdtstr(0) & "/" & 22 & "/" & Tempdtstr(2))
                                            ElseIf STP_date1 >= 22 Then
                                                Tempdtstr = SplitDateSTP(CalcDt, "/")
                                                If Tempdtstr(0) < 12 Then
                                                    CalcDt = CDateSTP(Tempdtstr(0) + 1 & "/" & 1 & "/" & Tempdtstr(2))
                                                Else
                                                    CalcDt = CDateSTP(1 & "/" & 1 & "/" & Tempdtstr(2) + 1)
                                                End If
                                            End If
                                        Else
                                            If rbcapital.Checked = False Then
                                                If STPdt.SelectedItem.Text <> "--" Then
                                                    If CInt(STPdt.SelectedItem.Value) > 28 Then
                                                        Math.DivRem(CInt(SplitDateSTP(Sqlrd(0), "/")(2)), 4, valReminder)
                                                        If valReminder <> 0 Then
                                                            If CInt(STPdt.SelectedItem.Value) > 28 And CInt(SplitDateSTP(Sqlrd(0), "/")(0)) = 2 Then
                                                                STP_date = 28
                                                            ElseIf CInt(STPdt.SelectedItem.Value) > 29 And (CInt(SplitDateSTP(Sqlrd(0), "/")(0)) = 4 Or CInt(SplitDateSTP(Sqlrd(0), "/")(0)) = 6 Or CInt(SplitDateSTP(Sqlrd(0), "/")(0)) = 9 Or CInt(SplitDateSTP(Sqlrd(0), "/")(0)) = 11) Then
                                                                STP_date = 30
                                                            Else
                                                                STP_date = CInt(STPdt.SelectedItem.Value)
                                                            End If
                                                        Else
                                                            If CInt(STPdt.SelectedItem.Value) > 28 And CInt(SplitDateSTP(Sqlrd(0), "/")(0)) = 2 Then
                                                                STP_date = 29
                                                            ElseIf CInt(STPdt.SelectedItem.Value) > 29 And (CInt(SplitDateSTP(Sqlrd(0), "/")(0)) = 4 Or CInt(SplitDateSTP(Sqlrd(0), "/")(0)) = 6 Or CInt(SplitDateSTP(Sqlrd(0), "/")(0)) = 9 Or CInt(SplitDateSTP(Sqlrd(0), "/")(0)) = 11) Then
                                                                STP_date = 30
                                                            Else
                                                                STP_date = CInt(STPdt.SelectedItem.Value)
                                                            End If
                                                        End If
                                                        CalcDt = CDateSTP(SplitDateSTP(Sqlrd(0), "/")(0) & "/" & STP_date & "/" & SplitDateSTP(Sqlrd(0), "/")(2))
                                                    Else
                                                        CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                                    End If
                                                Else
                                                    If CInt(Tempdtstr(0)) > 28 Then
                                                        Math.DivRem(CInt(Tempdtstr(2)), 4, valReminder)
                                                        If valReminder <> 0 Then
                                                            If CInt(Tempdtstr(0)) > 28 And CInt(Tempdtstr(0)) = 2 Then
                                                                STP_date = 28
                                                            ElseIf CInt(Tempdtstr(0)) > 29 And (CInt(Tempdtstr(0)) = 4 Or CInt(Tempdtstr(0)) = 6 Or CInt(Tempdtstr(0)) = 9 Or CInt(Tempdtstr(0)) = 11) Then
                                                                STP_date = 30
                                                            Else
                                                                STP_date = CInt(Tempdtstr(0))
                                                            End If
                                                        Else
                                                            If CInt(Tempdtstr(0)) > 28 And CInt(Tempdtstr(0)) = 2 Then
                                                                STP_date = 29
                                                            ElseIf CInt(Tempdtstr(0)) > 29 And (CInt(Tempdtstr(0)) = 4 Or CInt(Tempdtstr(0)) = 6 Or CInt(Tempdtstr(0)) = 9 Or CInt(Tempdtstr(0)) = 11) Then
                                                                STP_date = 30
                                                            Else
                                                                STP_date = CInt(Tempdtstr(0))
                                                            End If
                                                        End If
                                                        CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                                    Else
                                                        CalcDt = CDateSTP(Tempdtstr(0) & "/" & CInt(Tempdtstr(0)) & "/" & Tempdtstr(2))
                                                    End If
                                                    'CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                                End If
                                            Else
                                                CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                            End If
                                            'DateAdd(DateInterval.Month, PrdVal, CalcDt)
                                        End If
                                    Else
                                        If ddperiod.SelectedItem.Text = "Weekly" Then
                                            '''If Day(chkdate) <= STP_date Then
                                            '''    chkdate = DateAdd(DateInterval.Day, PrdVal, CalcDt)
                                            '''End If
                                            'CalcDt = DateAdd(DateInterval.Day, PrdVal, Sqlrd(0))
                                            'Tempdtstr = SplitDateSTP(CalcDt, "/")
                                            '''CalcDt = CDateSTP(Tempdtstr(0) & "/" & Tempdtstr(1) & "/" & Tempdtstr(2))
                                            STP_date1 = SplitDateSTP(CalcDt, "/")(1)

                                            If STP_date1 < 8 Then
                                                Tempdtstr = SplitDateSTP(CalcDt, "/")
                                                CalcDt = CDateSTP(Tempdtstr(0) & "/" & 8 & "/" & Tempdtstr(2))
                                            ElseIf STP_date1 >= 8 And STP_date1 < 15 Then
                                                Tempdtstr = SplitDateSTP(CalcDt, "/")
                                                CalcDt = CDateSTP(Tempdtstr(0) & "/" & 15 & "/" & Tempdtstr(2))
                                            ElseIf STP_date1 >= 15 And STP_date1 < 22 Then
                                                Tempdtstr = SplitDateSTP(CalcDt, "/")
                                                CalcDt = CDateSTP(Tempdtstr(0) & "/" & 22 & "/" & Tempdtstr(2))
                                            ElseIf STP_date1 >= 22 Then
                                                Tempdtstr = SplitDateSTP(CalcDt, "/")
                                                If Tempdtstr(0) < 12 Then
                                                    CalcDt = CDateSTP(Tempdtstr(0) + 1 & "/" & 1 & "/" & Tempdtstr(2))
                                                Else
                                                    CalcDt = CDateSTP(1 & "/" & 1 & "/" & Tempdtstr(2) + 1)
                                                End If
                                            End If
                                        Else
                                            '''By Jayendra as on 26Dec2008 
                                            ''If ddperiod.SelectedItem.Text = "Weekly" Then
                                            ''    STP_date = STP_date + 1
                                            ''Else
                                            ''    chkdate = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
                                            ''End If
                                            '''till here

                                            CalcDt = DateAdd(DateInterval.Month, PrdVal, Sqlrd(0))
                                            Tempdtstr = SplitDateSTP(CalcDt, "/")
                                            If rbcapital.Checked = False Then
                                                If STPdt.SelectedItem.Text <> "--" Then
                                                    If CInt(STPdt.SelectedItem.Value) > 28 Then
                                                        Math.DivRem(CInt(Tempdtstr(2)), 4, valReminder)
                                                        If valReminder <> 0 Then
                                                            If CInt(STPdt.SelectedItem.Value) > 28 And CInt(Tempdtstr(0)) = 2 Then
                                                                STP_date = 28
                                                            ElseIf CInt(STPdt.SelectedItem.Value) > 29 And (CInt(Tempdtstr(0)) = 4 Or CInt(Tempdtstr(0)) = 6 Or CInt(Tempdtstr(0)) = 9 Or CInt(Tempdtstr(0)) = 11) Then
                                                                STP_date = 30
                                                            Else
                                                                STP_date = CInt(STPdt.SelectedItem.Value)
                                                            End If
                                                        Else
                                                            If CInt(STPdt.SelectedItem.Value) > 28 And CInt(Tempdtstr(0)) = 2 Then
                                                                STP_date = 29
                                                            ElseIf CInt(STPdt.SelectedItem.Value) > 29 And (CInt(Tempdtstr(0)) = 4 Or CInt(Tempdtstr(0)) = 6 Or CInt(Tempdtstr(0)) = 9 Or CInt(Tempdtstr(0)) = 11) Then
                                                                STP_date = 30
                                                            Else
                                                                STP_date = CInt(STPdt.SelectedItem.Value)
                                                            End If
                                                        End If
                                                        CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                                    Else
                                                        CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                                    End If
                                                Else
                                                    If CInt(Tempdtstr(0)) > 28 Then
                                                        Math.DivRem(CInt(Tempdtstr(2)), 4, valReminder)
                                                        If valReminder <> 0 Then
                                                            If CInt(Tempdtstr(0)) > 28 And CInt(Tempdtstr(0)) = 2 Then
                                                                STP_date = 28
                                                            ElseIf CInt(Tempdtstr(0)) > 29 And (CInt(Tempdtstr(0)) = 4 Or CInt(Tempdtstr(0)) = 6 Or CInt(Tempdtstr(0)) = 9 Or CInt(Tempdtstr(0)) = 11) Then
                                                                STP_date = 30
                                                            Else
                                                                STP_date = CInt(Tempdtstr(0))
                                                            End If
                                                        Else
                                                            If CInt(Tempdtstr(0)) > 28 And CInt(Tempdtstr(0)) = 2 Then
                                                                STP_date = 29
                                                            ElseIf CInt(Tempdtstr(0)) > 29 And (CInt(Tempdtstr(0)) = 4 Or CInt(Tempdtstr(0)) = 6 Or CInt(Tempdtstr(0)) = 9 Or CInt(Tempdtstr(0)) = 11) Then
                                                                STP_date = 30
                                                            Else
                                                                STP_date = CInt(Tempdtstr(0))
                                                            End If
                                                        End If
                                                        CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                                    Else
                                                        CalcDt = CDateSTP(Tempdtstr(0) & "/" & CInt(Tempdtstr(0)) & "/" & Tempdtstr(2))
                                                    End If
                                                    'CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                                End If
                                            Else
                                                CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                            End If
                                            'CalcDt = CDateSTP(Tempdtstr(0) & "/" & STP_date & "/" & Tempdtstr(2))
                                        End If
                                    End If
                                Else
                                    ' CalcDt = DateAdd(DateInterval.Day, PrdVal, CalcDt)'**MANISH
                                    If SplitDateSTP(Sqlrd(0), "/")(1) < STP_date Then
                                        STP_date1 = SplitDateSTP(CalcDt, "/")(1)
                                        If STP_date1 >= 11 Then
                                            Tempdtstr = SplitDateSTP(CalcDt, "/")
                                            'CalcDt = CDateSTP(Tempdtstr(0) + 1 & "/" & 1 & "/" & Tempdtstr(2))
                                            If Tempdtstr(0) < 12 Then
                                                CalcDt = CDateSTP(Tempdtstr(0) + 1 & "/" & 1 & "/" & Tempdtstr(2))
                                            Else
                                                CalcDt = CDateSTP(1 & "/" & 1 & "/" & Tempdtstr(2) + 1)
                                            End If
                                        ElseIf STP_date1 < 11 Then
                                            Tempdtstr = SplitDateSTP(CalcDt, "/")
                                            'CalcDt = CDateSTP(Tempdtstr(0) & "/" & 15 & "/" & Tempdtstr(2))
                                            If Tempdtstr(0) <= 12 Then
                                                CalcDt = CDateSTP(Tempdtstr(0) & "/" & 15 & "/" & Tempdtstr(2))
                                            End If
                                        End If
                                    Else

                                        STP_date1 = SplitDateSTP(CalcDt, "/")(1)
                                        If STP_date1 >= 11 Then
                                            Tempdtstr = SplitDateSTP(CalcDt, "/")
                                            'CalcDt = CDateSTP(Tempdtstr(0) + 1 & "/" & 1 & "/" & Tempdtstr(2))
                                            If Tempdtstr(0) < 12 Then
                                                CalcDt = CDateSTP(Tempdtstr(0) + 1 & "/" & 1 & "/" & Tempdtstr(2))
                                            Else
                                                CalcDt = CDateSTP(1 & "/" & 1 & "/" & Tempdtstr(2) + 1)
                                            End If
                                        ElseIf STP_date1 < 11 Then
                                            Tempdtstr = SplitDateSTP(CalcDt, "/")
                                            'CalcDt = CDateSTP(Tempdtstr(0) & "/" & 15 & "/" & Tempdtstr(2))
                                            If Tempdtstr(0) <= 12 Then
                                                CalcDt = CDateSTP(Tempdtstr(0) & "/" & 15 & "/" & Tempdtstr(2))
                                            End If
                                        End If
                                    End If
                                End If

                                Ipdt.Rows.Add(Iprw)
                                m += 1
                                Rowcount += 1
                            End If
                            'stp_cashflw_grd2 = Math.Round(CDbl(Iprw(1)) * CDbl(Iprw(3)), 4)
                            'End If
                        End If
                        'Loop While Sqlrd.Read
                    Next
                End If
                'Sqlcon.Close()
                'Sqlcon.Dispose()
            End If '//fixed transter ends

            '//calculate present value   
            strsql = ""

            'by Jayendra on 10/01/2009
            'strsql = "Select (nav_rs-53)/76,dateadd(d,276,date) from nav_rec where sch_code ='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date)>='" & CDateSTP(cdates(txtvalue.Text)) & "' order by dateadd(d,276,date)"
            If rbcapital.Checked Then
                strsql = "Select (nav_rs-53)/76,dateadd(d,276,date) from nav_rec where sch_code ='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date)>='" & todt.ToString("dd MMM yyyy") & "' order by dateadd(d,276,date)"
            Else
                strsql = "Select (nav_rs-53)/76,dateadd(d,276,date) from nav_rec where sch_code ='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date)<='" & Valdt.ToString("dd MMM yyyy") & "' order by dateadd(d,276,date) desc"
            End If
            'till here

            sqlcon1 = New SqlConnection(constr)
            sqlcon1.Open()
            Sqlcom = New SqlCommand(strsql, sqlcon1)
            sqlrd1 = Sqlcom.ExecuteReader

            'Dim dtSTPTo As DataTable = New DataTable

            If sqlrd1.Read Then
                Do
                    If IsDBNull(sqlrd1(0)) = False Then
                        Iprw = Ipdt.NewRow
                        Iprw(0) = Format(CDate(sqlrd1(1)), "dd-MMM-yyyy")
                        Iprw(1) = Math.Round(sqlrd1(0), 4)
                        Iprw(3) = CumUnts
                        txtacc.Text = Math.Round(CumUnts * Iprw(1), 2)
                        Ipdt.Rows.Add(Iprw)
                        dt_as_on_2 = Iprw(0)
                        Exit Do
                    End If
                Loop While sqlrd1.Read
            Else
                '//calculate the latest date available b4 as on date
                '****vishal calculate present vaule as per last available date b4 as on date

                'strsql = "Select (nav_rs-53)/76,dateadd(d,276,date) from nav_rec where sch_code ='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date)<='" & CDateSTP(cdates(txtvalue.Text)) & "' order by dateadd(d,276,date) desc"
                strsql = "Select (nav_rs-53)/76,dateadd(d,276,date) from nav_rec where sch_code ='" & ddtrto.SelectedItem.Value & "' And dateadd(d,276,date)<='" & Date.Parse(txtvalue.Text).ToString("dd MMM yyyy") & "' order by dateadd(d,276,date) desc"

                If Sqlcon.State = ConnectionState.Open Then
                    Sqlcon.Close()
                End If
                sqlcon1 = New SqlConnection(constr)
                sqlcon1.Open()
                Sqlcom = New SqlCommand(strsql, sqlcon1)
                sqlrd1 = Sqlcom.ExecuteReader
                If sqlrd1.Read Then
                    Do
                        If IsDBNull(sqlrd1(0)) = False Then
                            Iprw = Ipdt.NewRow
                            Iprw(0) = Format(CDate(sqlrd1(1)), "dd-MMM-yyyy")
                            Iprw(1) = Math.Round(sqlrd1(0), 4)
                            Iprw(3) = CumUnts
                            txtacc.Text = Math.Round(CumUnts * Iprw(1), 2)
                            'txtacc.Text = 0.0
                            Ipdt.Rows.Add(Iprw)
                            dt_as_on_2 = Iprw(0)
                            Exit Do
                        End If
                    Loop While sqlrd1.Read
                End If
            End If

            '''''''''''XIRRSSSSSSS CALCULATION''''''''''''''''''''''
            Dim Dt As String = ""
            Dim cashflw As String = ""
            Dim cashindx As String = ""

            ReDim Preserve CashFl(Rowcount - 1)
            CashFl(Rowcount - 1) = stp_cashflw_grd1 + stp_cashflw_grd2

            ReDim Preserve IndexArr(Rowcount - 1)
            'If Rowcount <> 0 Then
            IndexArr(Rowcount - 1) = stp_cashflw_grd1 + stp_cashflw_grd2
            'End If

            If IsNothing(DtArr) = False Then
                For i = 0 To UBound(DtArr)
                    If Dt = "" Then
                        Dt = Format(DtArr(i), "dd/MM/yyyy")
                    Else
                        If CashFl(i) <> 0 Then
                            Dt = Dt & "," & Format(DtArr(i), "dd/MM/yyyy")
                        End If
                    End If
                Next i
            End If
            If IsNothing(CashFl) = False Then
                For i = 0 To UBound(CashFl)
                    If cashflw = "" Then
                        cashflw = CashFl(i)
                    Else
                        If CashFl(i) <> 0 Then
                            cashflw = cashflw & "," & CashFl(i)
                        End If
                    End If
                Next i
            End If

            If IsNothing(IndexArr) = False Then
                For i = 0 To UBound(IndexArr)
                    If cashindx = "" Then
                        cashindx = IndexArr(i)
                    Else
                        If CashFl(i) <> 0 Then
                            cashindx = cashindx & "," & IndexArr(i)
                        End If
                    End If
                Next i
            End If
            '//or xirr consider first from date
            DtArr(0) = frdt

            Dt = CDate(DtArr(0)) & "," & CDate(dt_as_on_1)
            'Dt = cdates(CDate(DtArr(0))) & "," & cdates(CDate(dt_as_on_1))

            cashflw = CashFl(0) & "," & Val((Val(txtacc.Text) + Val(txtbal.Text)))
            getXirr = XIRR(Dt, cashflw)
            txtyield.Text = Math.Round(getXirr, 2)
            getXirr = XIRR(Dt, cashindx)
            txtyldinv.Text = Math.Round(getXirr, 2)
            'Dt = ""
            'cashflw = ""
            'Dt = X1Date & "," & X2Date
            'cashflw = (X1Nav * X1units) & "," & (X2Nav * X1units) * -1
            'cashflw = CStr(stp_cashflw_grd1 + stp_cashflw_grd2)
            'getXirr = XIRR(Dt, cashflw)
            'txtyldinv.Text = Math.Round(getXirr, 2)
            'txtyield.Text = Math.Round(getXirr, 2)
            'noxi:

            Dim ix As Integer
            ix = 0
            For Each dr As DataRow In Ipdt.Rows
                If (String.IsNullOrEmpty(Convert.ToString(dr("NAV")))) And (String.IsNullOrEmpty(Convert.ToString(dr("Units")))) Then
                    ix = ix + 1

                End If
            Next
            If ix > 0 Then
                Ipdt.Rows.RemoveAt(ix - 1)
            End If
            Session("S2") = Ipdt
            Session("SFROM") = ddtrfrom.SelectedItem.Text
            Session("STO") = ddtrto.SelectedItem.Text
            Dstp1.DataSource = Ipdt
            Dstp1.DataBind()
            Dstp1.Visible = True
            cmdexp1.Enabled = True
            '//charting vishal
            tblChart.Visible = False
            HttpContext.Current.Session("STP_Chart_Image") = ""
            'HttpContext.Current.Session("SIP_Chart_Image") = ""
            Dim yinterval As Double
            yinterval = 1000
            If Fixed_Transfer And txttranamt.Text <> "" Then
                yinterval = CDbl(txttranamt.Text)
                Session("yinterval") = CDbl(txttranamt.Text)
            End If
            If chkChart_STP.Checked = True Then
                Dim datatbl_stp As DataTable
                ''Call formatTable4Chart(datatbl_stp, True, 1, 0, True, , "Nav,Units,CashFlow,CashFlow(Index),Index", "Amount,SWP Value,Index Value")
                '//create table for STP chart and fill date
                datatbl_stp = getDataTable4STP_chart(dtFrom, Ipdt.Copy)
                Session("ChartData_SIP") = datatbl_stp
                Session("ChartData_SIP1") = datatbl_stp.Copy
                ''Add by Syed
                hdIsGraphExist.Value = 1

                hdChartData.Value = "STP"
                ''end Add by syed
                Dim sipChart As WebChart.ChartControl = New WebChart.ChartControl
                Call drawChart(sipChart, datatbl_stp, "STP", yinterval)
                HdGraphImgPath.Value = HttpContext.Current.Session("SIP_Chart_Image")

                HttpContext.Current.Session("All_Chart_Image") = ""
                HttpContext.Current.Session("All_Chart_Image_Ie8") = HttpContext.Current.Session("STP_Chart_Image") + ".png"
                HttpContext.Current.Session("IsChartExist") = True
                tblChart.Visible = True
                'hdIsGraphExist.Value = "1"
            Else
                hdChartData.Value = "0"
                HttpContext.Current.Session("IsChartExist") = False

                'hdIsGraphExist.Value = "0"
            End If
            'cmdexp1.Attributes.Add("onClick", "javascript:newexports('Dstp','Dstp1',1,'" & txtbal.Text & "','" & txtacc.Text & "','" & txtyield.Text & "','" & txtyldinv.Text & "','" & ddtrfrom.SelectedItem.Text & "','" & ddtrto.SelectedItem.Text & "');return false;")
            'cmdexp1.Attributes.Add("onClick", "javascript:newexports('Dstp','Dstp1',1,'" & txtbal.Text & "','" & txtacc.Text & "','" & txtyield.Text & "',' ','" & ddtrfrom.SelectedItem.Text & "','" & ddtrto.SelectedItem.Text & "');return false;")
            Dim StrStpDisText As String
            If ((ddperiod.SelectedItem.Text.ToUpper() = "MONTHLY") Or (ddperiod.SelectedItem.Text.ToUpper() = "QUARTERLY")) Then
                StrStpDisText = STPdt.SelectedItem.Text
            Else
                StrStpDisText = ddSTPDate.SelectedItem.Text
            End If

            If (ddperiod.SelectedItem.Text.ToUpper() = "DAILY") Then
                PStpDisclamer.InnerHtml = "<u>Note:</u> Past performance may or may not be sustained in future. It is assumed that a STP of " + txttranamt.Text + " each executed on daily including the first transfer from from-Scheme to to-Scheme. Yield of STP investment is annualized and cumulative investment return for cash flows resulting out of uniform and daily transfer have been worked out using XIRR calculation. Load has not been taken into consideration."
            Else
                If rbcapital.Checked = False Then
                    PStpDisclamer.InnerHtml = "<u>Note:</u> Past performance may or may not be sustained in future. It is assumed that a STP of " + txttranamt.Text + " each executed on " + StrStpDisText + " of every " + ddperiod.SelectedItem.Text.Substring(0, ddperiod.SelectedItem.Text.Length - 2).ToLower() + " including the first transfer from from-Scheme to to-Scheme. Yield of STP investment is annualized and cumulative investment return for cash flows resulting out of uniform and " + ddperiod.SelectedItem.Text.ToLower() + " transfer have been worked out using XIRR calculation. Load has not been taken into consideration."
                Else
                    PStpDisclamer.InnerHtml = "<u>Note:</u> Past performance may or may not be sustained in future. It is assumed that a STP of appreciated ammount executed on 1st of every " + ddperiod.SelectedItem.Text.Substring(0, ddperiod.SelectedItem.Text.Length - 2).ToLower() + " including the first transfer from from-Scheme to to-Scheme. Yield of STP investment is annualized and cumulative investment return for cash flows resulting out of uniform and " + ddperiod.SelectedItem.Text.ToLower() + " transfer have been worked out using XIRR calculation. Load has not been taken into consideration."
                End If
            End If


        Catch ex As Exception
            tblChart.Visible = False
            tblSTP1.Visible = False
            txtyield.Text = ""
            txtyldinv.Text = ""
            Dstp1.Visible = False
            Dstp.Visible = False
            txtbal.Text = ""
            txtacc.Text = ""
            cmdexp1.Enabled = False
            Response.Write("<script>alert(""Error on fetching report. Please contact Nippon India Mutual Fund team."" )</script>")

        End Try
    End Sub

    ''Private Sub btnRetReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Private Overloads Sub btnRetReset_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRetReset.Click

        tblSIP.Visible = False
        tblSIP1.Visible = False
        tblSTP.Visible = False
        tblSTP1.Visible = False
        tblSWP.Visible = False
        tblSWP1.Visible = False
        Label25.Visible = True
        ddlsipbnmark.Visible = False
        tblSWP_rdo.Visible = False
        Label18.Visible = False
        txtxind.Visible = False
        ddRetscname.SelectedIndex = 0
        ddPeriod_SIP.SelectedIndex = 0
        ddRetbnmark.SelectedIndex = 0
        ddRetbnmark1.SelectedIndex = 0
        txtRetFdt.Text = ""
        txtRetTodt.Text = ""
        txtRetInsAmt.Text = ""
        txtvalason.Text = ""
        '//charting 
        tblChart.Visible = False
        CalReturn.Visible = True
        CalReturn1.Visible = False

    End Sub

    ''Private Sub cmdReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Private Overloads Sub cmdReturn_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdReturn.Click

        '******************  Developed By Manish Prasad  03/10/2007 *******************

        Dim ColArr() As String
        Dim Colstr As String

        Dim Pre_Nav As Double = 0
        Dim frdt As Date
        Dim todt As Date
        Dim benchmark As String
        Dim cuml_units As Double

        Dim F_Nav, F_Ind As Double
        Dim S_Nav, S_Ind As Double
        Dim DtDiff, DtDiff_Ind As String
        Dim schReturn As Double
        Dim indexReturn As Double
        Dim sch_date, sch_date1 As Date
        Dim ind_date, ind_date1 As Date
        Dim initialval, TxtTransferAmt, Onetime, gain As Double

        Dim Todate, Fromdate, sch_date_First, sch_date_Second As Date



        Try

            If ddPlan.SelectedItem.Text = "--" Then
                Response.Write("<script>alert(""Please Select Plan.."")</script>")
                Exit Sub
            End If
            If ddRetscname.SelectedItem.Text = "--" Then
                Response.Write("<script>alert(""Please Select Scheme.."")</script>")
                Exit Sub
            End If

            If ddRetbnmark.SelectedItem.Text = "--" Then
                Response.Write("<script>alert(""Please Select BenchMark Index "")</script>")
                Exit Sub
            Else
                benchmark = ddRetbnmark.SelectedItem.Text
            End If

            If Val(txtRetInsAmt.Text) = 0 Then
                Response.Write("<script>alert(""Amount Cannot Be Blank.."")</script>")
                Exit Sub
            End If
            If txtRetFdt.Text = "" Or txtRetTodt.Text = "" Then
                Response.Write("<script>alert(""From Date / To Date Can Not be Blank.."")</script>")
                Exit Sub
            End If


            If IsDate(fmt(Trim(txtRetFdt.Text))) = False Or IsDate(fmt(Trim(txtRetTodt.Text))) = False Then
                Response.Write("<script>alert(""Please Enter The Dates in Proper Formats (dd/mm/yyyy).."")</script>")
                Exit Sub
            End If
            todt = txtRetTodt.Text.Replace("/", "-")
            frdt = txtRetFdt.Text.Replace("/", "-")

            If CDate(todt) <= frdt Then
                Response.Write("<script>alert(""From Date Should be less than To Date.."")</script>")
                Exit Sub
            End If
            '' end validation
















            '//CLEAR THE SESSION IMAGES
            HttpContext.Current.Session("SIP_Chart_Image") = ""
            HttpContext.Current.Session("SWP_Chart_Image") = ""
            HttpContext.Current.Session("STP_Chart_Image") = ""

            benchmark = ddRetbnmark1.SelectedItem.Text   ' BenchMark INDEX Value
            TxtTransferAmt = txtRetInsAmt.Text

            Todate = txtRetTodt.Text ''cdates(txtRetTodt.Text)
            Fromdate = txtRetFdt.Text ''cdates(txtRetFdt.Text)



            Colstr = "Scheme Return#Index Return#Value of Investment#Gain From Investment"
            ColArr = Split(Colstr, "#")
            For i = 0 To 3
                Ipcol = New DataColumn
                Ipcol.ColumnName = ColArr(i)
                Ipdt.Columns.Add(Ipcol)
            Next i

            Gsp.HeaderStyle.ForeColor = Color.White



            '**** For First NAV  & Date  ****
            strsql = "Select top 1 dateadd(d,276,[date]),(Nav_rs-53)/76 from nav_rec where sch_code='" & ddRetscname.SelectedItem.Value & "' And dateadd(d,276,[date]) >='" & Fromdate.ToString("dd MMM yyyy") & "'  order by dateadd(d,276,[date])"
            'strsql = "Select top 1 dateadd(d,276,[date]),(Nav_rs-53)/76 from   where sch_code='" & ddRetscname.SelectedItem.Value & "' And dateadd(d,276,[date]) >='" & Fromdate & "'  order by dateadd(d,276,[date])"
            Sqlcon = New SqlConnection(constr)
            Sqlcon.Open()
            Sqlcom = New SqlCommand(strsql, Sqlcon)
            Sqlrd = Sqlcom.ExecuteReader
            If Sqlrd.Read Then
                If Not IsDBNull(Sqlrd(1)) Then
                    sch_date_First = Sqlrd(0)
                    'F_Nav = Sqlrd(1)
                End If '
                Sqlcon.Close()
                Sqlcon.Dispose()
            End If

            '**** For Second NAV  & Date  ****
            strsql = "Select top 1 dateadd(d,276,[date]),(Nav_rs-53)/76 from nav_rec where sch_code='" & ddRetscname.SelectedItem.Value & "' And dateadd(d,276,[date]) <='" & Todate.ToString("dd MMM yyyy") & "'  order by dateadd(d,276,[date]) desc"
            'strsql = "Select top 1 dateadd(d,276,[date]),(Nav_rs-53)/76 from #temp_Rolling_Nav where sch_code='" & ddRetscname.SelectedItem.Value & "' And dateadd(d,276,[date]) <='" & Todate & "'  order by dateadd(d,276,[date]) desc"
            Sqlcon = New SqlConnection(constr)
            Sqlcon.Open()
            Sqlcom = New SqlCommand(strsql, Sqlcon)
            Sqlrd = Sqlcom.ExecuteReader
            If Sqlrd.Read Then
                If Not IsDBNull(Sqlrd(1)) Then
                    sch_date_Second = Sqlrd(0)
                    'S_Nav = Sqlrd(1)
                End If '
                Sqlcon.Close()
                Sqlcon.Dispose()
            End If


            '************* Find The NAV & Date  From Store Procedure   *********

            Sqlcon = New SqlConnection(constr) : Sqlcon.Open()
            Sqlcom = New SqlCommand("dbo.procCalcNAV", Sqlcon)
            With Sqlcom
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@schCode", SqlDbType.VarChar, 225).Value = ddRetscname.SelectedItem.Value
                .Parameters.Add("@dtFrom", SqlDbType.DateTime).Value = sch_date_First
                .Parameters.Add("@dtTO", SqlDbType.DateTime).Value = sch_date_Second
                .Parameters.Add("@navType", SqlDbType.VarChar, 50).Value = "Reinvest"
                .Parameters.Add("@DivType", SqlDbType.VarChar, 50).Value = "Individual"
                .ExecuteNonQuery()

                Dim ds As New DataSet
                Dim dtnew As New DataTable
                Dim adapter As New SqlDataAdapter
                'While con.ConnectionTimeout <> comm.CommandTimeout
                ds.Clear()
                adapter.SelectCommand = Sqlcom
                adapter.Fill(dtnew)
                'End While
                'DgReturn.DataSource = ds
                'DgReturn.DataBind()

                Sqlcon.Close()
                'End With
                '************* END **********  


                For i = 0 To dtnew.Rows.Count - 1
                    If dtnew.Rows(i).Item(1) = sch_date_First Then
                        sch_date = dtnew.Rows(i).Item(1)
                        F_Nav = dtnew.Rows(i).Item(2)
                    End If
                    If dtnew.Rows(i).Item(1) = sch_date_Second Then
                        sch_date1 = dtnew.Rows(i).Item(1)
                        S_Nav = dtnew.Rows(i).Item(2)
                    End If
                Next

            End With

            '**** For First Index  & Date  ****
            sqlcon1 = New SqlConnection(constr)
            sqlcon1.Open()
            strsql = "Select top 1 (ind_val-53)/76,dateadd(d,276,dt1) from ind_rec where ind_code='" & benchmark & "' And dateadd(d,276,dt1)>='" & Fromdate.ToString("dd MMM yyyy") & "' order by dateadd(d,276,dt1)"
            Sqlcom = New SqlCommand(strsql, sqlcon1)
            sqlrd1 = Sqlcom.ExecuteReader
            If sqlrd1.Read Then
                If Not IsDBNull(sqlrd1(0)) Then
                    ind_date = sqlrd1(1)
                    F_Ind = sqlrd1(0)
                End If '
                sqlcon1.Close()
                sqlcon1.Dispose()

            End If


            '**** For Second Index  & Date  ****
            sqlcon1 = New SqlConnection(constr)
            sqlcon1.Open()
            strsql = "Select top 1 (ind_val-53)/76,dateadd(d,276,dt1) from ind_rec where ind_code='" & benchmark & "' And dateadd(d,276,dt1)<='" & Todate.ToString("dd MMM yyyy") & "' order by dateadd(d,276,dt1) desc"
            Sqlcom = New SqlCommand(strsql, sqlcon1)
            sqlrd1 = Sqlcom.ExecuteReader
            If sqlrd1.Read Then
                If Not IsDBNull(sqlrd1(0)) Then
                    ind_date1 = sqlrd1(1)
                    S_Ind = sqlrd1(0)
                End If '
                sqlcon1.Close()
                sqlcon1.Dispose()

            End If


            DtDiff = DateDiff("d", sch_date, sch_date1)
            DtDiff_Ind = DateDiff("d", ind_date, ind_date1)

            If DtDiff > 365 Then
                If F_Nav > 0 And F_Ind > 0 Then
                    schReturn = (((S_Nav / F_Nav) ^ (365 / DtDiff)) - 1) * 100
                    indexReturn = (((S_Ind / F_Ind) ^ (365 / DtDiff_Ind)) - 1) * 100
                ElseIf F_Nav > 0 Then
                    schReturn = (((S_Nav / F_Nav) ^ (365 / DtDiff)) - 1) * 100
                    indexReturn = 0
                Else
                    schReturn = 0
                    indexReturn = 0
                End If
            Else
                If F_Nav > 0 And F_Ind > 0 Then
                    schReturn = (S_Nav - F_Nav) * 100 / F_Nav
                    indexReturn = (S_Ind - F_Ind) * 100 / F_Ind
                Else
                    schReturn = 0
                    indexReturn = 0
                End If

            End If


            If F_Nav > 0 And F_Ind > 0 Then
                initialval = TxtTransferAmt / F_Nav
                Onetime = initialval * S_Nav
                gain = Onetime - TxtTransferAmt
            ElseIf F_Nav > 0 Then
                initialval = TxtTransferAmt / F_Nav
                Onetime = initialval * S_Nav
                gain = Onetime - TxtTransferAmt
            Else
                initialval = 0
                Onetime = 0
                gain = 0
            End If


            Iprw = Ipdt.NewRow
            Iprw(0) = Format(schReturn, "0.00")
            Iprw(1) = Format(indexReturn, "0.00")
            Iprw(2) = Format(Onetime, "0.00")
            Iprw(3) = Format(gain, "0.00")
            Ipdt.Rows.Add(Iprw)

            DgReturn.DataSource = Ipdt
            DgReturn.DataBind()
            btnRetExport.Enabled = True

            lblschdt1.Text = Format(sch_date, "dd-MMM-yyyy")
            lblschdt2.Text = Format(sch_date1, "dd-MMM-yyyy")
            lblinddt1.Text = Format(ind_date, "dd-MMM-yyyy")
            lblinddt2.Text = Format(ind_date1, "dd-MMM-yyyy")
            DgReturn.Visible = True
            CalReturn1.Visible = True

        Catch ex As Exception
            DgReturn.Visible = False
            txtonttm.Text = ""
            'tblChart.Visible = False
            CalReturn1.Visible = False
            'txtxsch.Text = ""
            'txtxind.Text = ""
            'btnRetExport.Enabled = False
            Response.Write("<script>alert(""Error on fetching report. Please contact Nippon India Mutual Fund team."" )</script>")
        Finally
            'Sqlcon.Close()
            'Sqlcon.Dispose()
            'sqlcon1.Close()
            'sqlcon1.Dispose()
            SetHtmlLUMPSUM()
        End Try

    End Sub

    Private Sub ddRetbnmark_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddRetbnmark.SelectedIndexChanged
        ddRetbnmark1.SelectedIndex = ddRetbnmark.SelectedIndex
    End Sub


    ''Private Sub btnRetExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Private Overloads Sub btnRetExport_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRetExport.Click

        If DgReturn.Items.Count < 1 Then
            Response.Write("<script>alert(""No Data To Save Please Try Again"")</script>")
        Else
            Call SaveToExcel_RETURNS2(Response, DgReturn, , , , ddRetscname.SelectedItem.Text, ddRetbnmark.SelectedItem.Text, "", Format(CDate(txtRetFdt.Text), "dd-MMM-yyyy"), Format(CDate(txtRetTodt.Text), "dd-MMM-yyyy"))
        End If
    End Sub

    Public Sub ddPlan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddPlan.SelectedIndexChanged

        'add by syed
        hdChartData.Value = 0
        hdIsGraphExist.Value = 0
        'end add by syed
        If ddPlan.SelectedItem.Text = "SIP" Then
            tblSIP.Visible = True
            tblSIP1.Visible = False
            tblSTP.Visible = False
            tblSTP1.Visible = False
            tblSWP.Visible = False
            tblSWP1.Visible = False
            Label25.Visible = True
            ddlsipbnmark.Visible = True
            tblSWP_rdo.Visible = False
            Label18.Visible = True
            txtxind.Visible = True
            ddscheme.SelectedIndex = 0
            txtfromDate.Text = ""
            txtTdate.Text = ""
            txtinstall.Text = ""
            txtvalason.Text = ""
            cmdexp.Enabled = False
        ElseIf ddPlan.SelectedItem.Text = "STP" Then
            tblSIP.Visible = False
            tblSIP1.Visible = False
            tblSTP.Visible = True
            tblSTP1.Visible = False
            tblSWP.Visible = False
            tblSWP1.Visible = False
            Label10.Visible = True
            ddbnmark.Visible = True
            Table12.Visible = True
            txtfrdt.Text = ""
            txttodt.Text = ""
            txtvalue.Text = ""
            txtiniamt.Text = ""
            txttranamt.Text = ""
            ddperiod.SelectedIndex = 0
            ddtrfrom.SelectedIndex = 0
            ddtrto.SelectedIndex = 0
            ddbnmark.SelectedIndex = 0
            rbindivd.Checked = False
            rbcorp.Checked = False
            txttranamt.Visible = True
            cmdexp1.Enabled = False
            STPdt.Visible = False

        ElseIf ddPlan.SelectedItem.Text = "SWP" Then
            tblSIP.Visible = False
            tblSIP1.Visible = False
            tblSTP.Visible = False
            tblSTP1.Visible = False
            tblSWP.Visible = True
            tblSWP1.Visible = False
            Label24.Visible = True
            ddwbnmark.Visible = True
            ddwscname.SelectedIndex = 0
            txtwinamt.Text = ""
            ddwperiod.SelectedIndex = 0
            txtwfrdt.Text = ""
            txtwtdt.Text = ""
            txtwvaldate.Text = ""
            btnwexport.Enabled = False
        ElseIf ddPlan.SelectedItem.Text = "LUMPSUM INVESTMENT" Then
            tblSIP.Visible = False
            tblSIP1.Visible = False
            tblSTP.Visible = False
            tblSTP1.Visible = False
            tblSWP.Visible = False
            tblSWP1.Visible = False
            Label25.Visible = False
            ddlsipbnmark.Visible = False
            tblSWP_rdo.Visible = False
            Label18.Visible = False
            txtxind.Visible = False
            ddscheme.SelectedIndex = 0
            txtfromDate.Text = ""
            txtTdate.Text = ""
            txtinstall.Text = ""
            txtvalason.Text = ""
            cmdexp.Enabled = False
            btnwexport.Enabled = False
            CalReturn.Visible = True
            btnRetExport.Enabled = False
        Else
            tblSIP.Visible = False
            tblSIP1.Visible = False
            tblSTP.Visible = False
            tblSTP1.Visible = False
            tblSWP.Visible = False
            tblSWP1.Visible = False
            CalReturn.Visible = False
            CalReturn1.Visible = False
        End If
    End Sub

    Private Sub ddRetscname_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddRetscname.SelectedIndexChanged
        ''commented by 31 Oct 2014
        'Dim Eq_flag As Boolean

        'strsql = "Select nature from Scheme_info where mut_code in ('" & Replace(mut_code, ",", "','") & "') and sch_code='" & ddRetscname.SelectedItem.Value & "'"
        'Sqlcon = New SqlConnection(constr)
        'Sqlcon.Open()
        'Sqlcom = New SqlCommand(strsql, Sqlcon)
        'Sqlrd = Sqlcom.ExecuteReader
        'If Sqlrd.Read Then
        '    If LCase(Sqlrd(0)) = LCase("equity") Then
        '        Eq_flag = True
        '    End If
        'End If
        'strsql = "" : Sqlcon.Close() : Sqlrd.Close() : Sqlcom.Dispose()

        'If Eq_flag = True Then
        '    For i = 0 To ddRetbnmark.Items.Count - 1
        '        If ddRetbnmark.Items(i).Text = ConfigurationSettings.AppSettings("EQUITYSCHEME").ToString() Then
        '            ddRetbnmark.SelectedIndex = i
        '            ddRetbnmark1.SelectedIndex = i
        '            Exit For
        '        End If
        '    Next i
        'Else
        '    strsql = "Select ind_name,ind_code from ind_info where ind_code=(Select distinct top 1 ind_code from schemeindex where sch_code='" & ddRetscname.SelectedItem.Value & "' and ind_code not in ('" & Replace(disply_ind_code, ",", "','") & "'))"
        '    Sqlcon = New SqlConnection(constr)
        '    Sqlcon.Open()
        '    Sqlcom = New SqlCommand(strsql, Sqlcon)
        '    Sqlrd = Sqlcom.ExecuteReader

        '    If Sqlrd.Read Then
        '        For i = 0 To ddRetbnmark.Items.Count
        '            If ddRetbnmark.Items(i).Text = Sqlrd(0) Then
        '                ddRetbnmark.SelectedIndex = i
        '                ddRetbnmark1.SelectedIndex = i
        '                Exit For
        '            End If
        '        Next i
        '    End If
        'End If
        ''------------ end
        'Comment for TRI
        'strsql = "Select ind_name,ind_code from ind_info where ind_code=(Select distinct top 1 ind_code from schemeindex where sch_code='" & ddRetscname.SelectedItem.Value & "' and ind_code not in ('" & Replace(disply_ind_code, ",", "','") & "'))"
        If Scheme_Not_to_Display_Index.Split(",").Where(Function(c) c = ddRetscname.SelectedItem.Value).Any() = False Then

            strsql = "Select ind_name,ind_code from ind_info where REPLACE(ind_name,' ','')= REPLACE((Select ind_name from ind_info where ind_code=(Select distinct top 1 ind_code from schemeindex where sch_code='" & ddRetscname.SelectedItem.Value & "' and ind_code not in ('" & Replace(disply_ind_code, ",", "','") & "')))+ ' TRI',' ','')"
            Sqlcon = New SqlConnection(constr)
            Sqlcon.Open()
            Sqlcom = New SqlCommand(strsql, Sqlcon)
            Sqlrd = Sqlcom.ExecuteReader

            If Sqlrd.Read Then
                For i = 0 To ddRetbnmark.Items.Count
                    If ddRetbnmark.Items(i).Text = Sqlrd(0) Then
                        ddRetbnmark.SelectedIndex = i
                        ddRetbnmark1.SelectedIndex = i
                        Exit For
                    End If
                Next i
            Else
                strsql = "Select ind_name,ind_code from ind_info where ind_code=(Select distinct top 1 ind_code from schemeindex where sch_code='" & ddRetscname.SelectedItem.Value & "' and ind_code not in ('" & Replace(disply_ind_code, ",", "','") & "'))"
                Sqlcon = New SqlConnection(constr)
                Sqlcon.Open()
                Sqlcom = New SqlCommand(strsql, Sqlcon)
                Sqlrd = Sqlcom.ExecuteReader
                If Sqlrd.Read Then
                    For i = 0 To ddRetbnmark.Items.Count
                        If ddRetbnmark.Items(i).Text = Sqlrd(0) Then
                            ddRetbnmark.SelectedIndex = i
                            ddRetbnmark1.SelectedIndex = i
                            Exit For
                        End If
                    Next i
                End If
            End If
        Else
            ddRetbnmark.SelectedIndex = 0
            ddRetbnmark1.SelectedIndex = 0
        End If
        CalReturn1.Visible = False
        tblChart.Visible = False
    End Sub

    Private Sub txtfrdt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfrdt.TextChanged
        '*********  For STP date    "--Manish--"

        If txtfrdt.Text <> "" Then
            If Split(txtfrdt.Text, "/")(1) = 1 Or Split(txtfrdt.Text, "/")(1) = 3 Or Split(txtfrdt.Text, "/")(1) = 5 Or Split(txtfrdt.Text, "/")(1) = 7 Or Split(txtfrdt.Text, "/")(1) = 8 Or Split(txtfrdt.Text, "/")(1) = 10 Or Split(txtfrdt.Text, "/")(1) = 12 Then
                STPdt.Items.Clear()
                STPdt.Items.Add("--")
                For i = 1 To 31
                    STPdt.Items.Add(i)
                Next
            ElseIf Split(txtfrdt.Text, "/")(1) = 4 Or Split(txtfrdt.Text, "/")(1) = 6 Or Split(txtfrdt.Text, "/")(1) = 9 Or Split(txtfrdt.Text, "/")(1) = 11 Then
                STPdt.Items.Clear()
                STPdt.Items.Add("--")
                For i = 1 To 30
                    STPdt.Items.Add(i)
                Next
            ElseIf Split(txtfrdt.Text, "/")(1) = 2 Then
                STPdt.Items.Clear()
                STPdt.Items.Add("--")
                Math.DivRem(CInt(Split(txtfrdt.Text, "/")(2)), 4, Reminder)
                If Reminder <> 0 Then
                    For i = 1 To 28
                        STPdt.Items.Add(i)
                    Next
                Else
                    For i = 1 To 29
                        STPdt.Items.Add(i)
                    Next
                End If

            End If
        End If
    End Sub

    Public Function GetStartDate(ByVal schName As String) As Date
        Try
            GetStartDate = CDate("01/01/1900")
            strsql = ""
            strsql = "Select min(dateadd(day,276,[date])) from NAV_REC where sch_code='" & schName & "'"
            Sqlcon = New SqlConnection(constr)
            If Sqlcon.State = ConnectionState.Open Then
                Sqlcon.Close()
            End If
            Sqlcon.Open()
            Sqlcom = New SqlCommand(strsql, Sqlcon)
            Sqlrd = Sqlcom.ExecuteReader
            While Sqlrd.Read
                If Not IsDBNull(Sqlrd(0)) Then
                    GetStartDate = Sqlrd(0)
                End If
            End While
            Return GetStartDate
        Catch ex As Exception
        Finally
            If Sqlcon.State = ConnectionState.Open Then
                Sqlcon.Close()
            End If
            Sqlcom.Dispose()
        End Try
    End Function


    Private Sub cmdrs1_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdrs1.Click
        Try

            tblSIP.Visible = True
            tblSIP1.Visible = False
            tblSTP.Visible = False
            tblSTP1.Visible = False
            tblSWP.Visible = False
            tblSWP1.Visible = False
            Label25.Visible = True
            ddlsipbnmark.Visible = True
            tblSWP_rdo.Visible = False
            Label18.Visible = True
            txtxind.Visible = True
            ddscheme.SelectedIndex = 0
            txtfromDate.Text = ""
            txtTdate.Text = ""
            txtinstall.Text = ""
            txtvalason.Text = ""
            ''''ddscheme.SelectedIndex = 0
            ''''ddSIPdate.SelectedIndex = 0
            ddPeriod_SIP.SelectedIndex = 0
            ddlsipbnmark.SelectedIndex = 0
            hdIsGraphExist.Value = 0

            ''''txtfromDate.Text = ""
            ''''txtTdate.Text = ""
            ''''txtinstall.Text = ""
            ''''txtvalason.Text = ""
            Gsp.Columns.Clear()
        Catch ex As Exception

        End Try
    End Sub






End Class
