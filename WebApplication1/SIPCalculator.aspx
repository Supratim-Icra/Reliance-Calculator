<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="SIPCalculator.aspx.vb"
    ViewStateEncryptionMode="Always" EnableViewStateMac="true"
    Inherits="RelianceSIP.SIPCalculator" %>

<%@ Register TagPrefix="web" Namespace="WebChart" Assembly="WebChart" %>
<!DOCTYPE HTML>
<html>
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>SIP Calculator, Mutual Fund Investment Calculator
        | Nippon India Mutual Fund</title>

    <meta name="description" content='Use our SIP Calculator to calculate the returns of the small investments. Browse now to use mutual fund investment calculator' />
    <meta name="google-site-verification" content="2GBwxUraB-k272RYJJEOcHyYfilxGlXi8GNmt0CfDMY" />
    <%--<meta name="keywords" content='SIP Calculator, Mutual Fund Investment Calculator | Reliance Mutual' />--%>

    <%--<link href="includes/Styles/bootstrap.min.css" rel="stylesheet" />--%>
    <%--<link href="includes/Heade-footer-styles.css" rel="stylesheet" />--%>
    <link href="Includes/SIPCalSheet.css" rel="stylesheet" />
    <link href="Includes/style_rel.css" rel="stylesheet" />
    <link href="Includes/style.css" rel="stylesheet" />
    <link href="includes/jquery-ui.css" rel="stylesheet" />
    <%--<script src="includes/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="includes/jquery-migrate-1.4.1.min.js"></script>--%>
    <script src="includes/jquery-3.7.1.js"></script>
    <script src="includes/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript" src="includes/WaterMark/jquery.watermark.js"></script>
    <link href="includes/Styles/jquery.jqplot.css" rel="stylesheet"
        type="text/css" />
    
    <script src="includes/jqplot/jquery.jqplot.min.js"
        type="text/javascript"></script>
    <script src="includes/jqplot/plugins/jqplot.canvasTextRenderer.min.js"
        type="text/javascript"></script>
    <script src="includes/jqplot/plugins/jqplot.canvasAxisLabelRenderer.min.js"
        type="text/javascript"></script>
    <script src="includes/jqplot/plugins/jqplot.enhancedLegendRenderer.js"
        type="text/javascript"></script>
    <script src="includes/HTML2PDF.js" type="text/javascript"></script>


    <%--<script src="includes/bootstrap.min.js" type="text/javascript"></script>--%>
    <!--[if lt IE 10]><script src="includes/jqplot/excanvas.js"></script><![endif]-->
    <!--[if IE 9]>
        <script type="text/javascript">
            //alert("asjgdvj11111111111");
            $(window).load(function () {
            $("#hdIEVersion").val("9");
            //alert($("#hdIEVersion").val());
            });
        </script>
    <![endif]-->
    <!--[if IE 8]>
        <script type="text/javascript">
            //alert("asjgdvj11111111111");
            $(window).load(function () {
            $("#hdIEVersion").val("8");
            //alert($("#hdIEVersion").val());
            });
        </script>
    <![endif]-->
    <script type="text/javascript" language="javascript">
        function valid_date(tf, delim, canBeEmpty, ddmmyy) {
            focusObj = null;
            //  if(focusObj==tf)  return false;     
            /*   if(! canBeEmpty) {
            if(isEmpty(tf,text))  return false;}*/
            if (!delim || delim.length != 1) delim = "/";
            var format = (ddmmyy) ? "dd" + delim + "mm" + delim + "yyyy" : "mm" + delim + "dd" + delim + "yyyy"
            var arr = tf.value.split(delim);
            //var fm=document.search;
            if (arr.length != 3) return message(tf, "date in " + format + " format");
            var dm = ddmmyy ? 1 : 0;
            var dd1 = arr[1 - dm];
            var mm1 = arr[dm - 0];
            var yy1 = arr[2];
            //alert(dd1);
            //alert(mm1);
            //alert(yy1);  
            if (!($.isNumeric(dd1) && $.isNumeric(mm1) && $.isNumeric(yy1))) return message(tf, "date in " + format + " format");
            if (yy1.length < 4 || yy1.length > 4) return message(tf, "date in " + format + " format");
            //alert('after is number');
            if (yy1 - 0 > 100 && yy1 - 0 < 1000) return message(tf, "date in " + format + " format");
            var ddate = new Date(yy1, --mm1, dd1);
            if (ddate.getMonth() != mm1) return message(tf, "date in " + format + " format");
            return true;
        }

        function ChkDtFrmTodate(tf) //  Created by Manilsh Prasad
        {
            var arr = tf.split("/");
            var currentTime = new Date()
            var month = currentTime.getMonth() + 1
            var day = currentTime.getDate()
            var year = currentTime.getFullYear()
            var todate = (day + "/" + month + "/" + year)
            var arr1 = todate.split("/");

            if (arr[2] > arr1[2]) {
                return false;
            }
            if (parseInt(arr[1], 10) > parseInt(arr1[1], 10) && (arr[2] == arr1[2])) {
                return false;
            }
            if ((parseInt(arr[0], 10) > parseInt(arr1[0], 10)) && (parseInt(arr[1], 10) == parseInt(arr1[1], 10) && arr[2] == arr1[2])) {
                return false;
            }
            if (parseInt(arr[0], 10) <= parseInt(arr1[0], 10)) {
                return true;
            }
            return true;
        }
        function compareDates(tf, sDate) {
            var dateString = tf.value.split('/'); var dateString1 = sDate.value.split('/');
            var dates = new Date(dateString[2], dateString[1] - 1, dateString[0]);
            var sdates = new Date(dateString1[2], dateString1[1] - 1, dateString1[0]);
            if (dates <= sdates) return false;
            return true;
        }
    </script>
    <script type="text/javascript" language="javascript">

        $(document).ready(function () {
            
            $("#cmdSIP").click(function () {
                var v_date = RtnDate($("#txtvalason").val());
                var f_date = RtnDate($("#txtfromDate").val());
                var t_date = RtnDate($("#txtTdate").val());

                if (new Date(v_date) >= new Date() || new Date(f_date) >= new Date() || new Date(t_date) >= new Date()) {
                    alert('Date should not be greater than current date');
                    return false;
                }
            });
            
            $("#cmdSWP").click(function () {
                var v_date = RtnDate($("#txtwvaldate").val());
                var f_date = RtnDate($("#txtwfrdt").val());
                var t_date = RtnDate($("#txtwtdt").val());

                if (new Date(v_date) >= new Date() || new Date(f_date) >= new Date() || new Date(t_date) >= new Date()) {
                    alert('Date should not be greater than current date');
                    return false;
                }
            });
            $("#cmdSTP").click(function () {
                var v_date = RtnDate($("#txtvalue").val());
                var f_date = RtnDate($("#txtfrdt").val());
                var t_date = RtnDate($("#txttodt").val());

                if (new Date(v_date) >= new Date() || new Date(f_date) >= new Date() || new Date(t_date) >= new Date()) {
                    alert('Date should not be greater than current date');
                    return false;
                }
            });
            $("#cmdReturn").click(function () {
                var f_date = RtnDate($("#txtRetFdt").val());
                var t_date = RtnDate($("#txtRetTodt").val());

                if (new Date(f_date) >= new Date() || new Date(t_date) >= new Date()) {
                    alert('Date should not be greater than current date');
                    return false;
                }
            });
            function RtnDate(str1) {
                // str1 format should be dd/mm/yyyy. Separator can be anything e.g. / or -. It wont effect
                var dt1 = parseInt(str1.substring(0, 2));
                var mon1 = parseInt(str1.substring(3, 5));
                var yr1 = parseInt(str1.substring(6, 10));
                var date1 = new Date(yr1, mon1 - 1, dt1);
                return date1;
            }
            $(".Save").mouseover(function () {

                


                if ($('#hdIsGraphExist').val() == "1") {
                    var graphicImage = $('#plotted_image_div');
                    var divGraph = $('#dvChartNew').jqplotToImageStr({});
                    var divElem = $('<img/>').attr('src', divGraph);
                    graphicImage.html(divElem);
                    var dataToPush = "";

                    

                    //debugger;
                    if ($("#hdIEVersion").val() == "8") {
                        dataToPush = "{ 'baseimg': '', 'ieVersion':'" + $("#hdIEVersion").val() + "' }";
                    }
                    else {
                        //                         dataToPush = JSON.stringify({
                        //                             baseimg: divGraph,
                        //                             ieVersion: $("#hdIEVersion").val()
                        //                         });
                        dataToPush = "{ 'baseimg': '" + divGraph + "', 'ieVersion':'" + $("#hdIEVersion").val() + "' }";
                    }
                    $.ajax({
                        type: "POST",
                        url: "SIPCalculator.aspx/setNPSChartimg",
                        async: false,
                        contentType: "application/json",
                        data: dataToPush,
                        dataType: "json",
                        success: function (msg) {
                            return true;
                        },
                        error: function (msg) {
                            // alert("Error! Try again...");
                        }
                    });
                }

                //var newchart = Highcharts.charts[0];

                //var svg = newchart.getSVG();
                //var blob = new Blob([svg], { type: 'image/svg+xml' });
                //var formData = new FormData();
                //formData.append('image', blob);
               

                //$.ajax({
                //    type: "POST",
                //    url: "SIPCalculator.aspx/SaveChartImageNew",
                    
                //    processData: false,
                //    contentType: false,
                //    data: formData,
                //     success: function (msg) {
                //            return true;
                //     },
                //     error: function (msg) {
                            
                //     }
                //});

                //newchart.exportChart({
                //    type: 'image/jpeg',
                //    filename: 'chart_img_new',
                //    blob : true
                //}, function (data) {
                //    var formData = new FormData();
                //    formData.append('image', data);

                //    $.ajax({
                //        type: "POST",
                //        url: "SIPCalculator.aspx/SaveChartImageNew",
                //        data: formData,
                //        processData: false,
                //        contentType: false
                //    });
                //});
            

            });

            



            $("#txtfromDate,#txtTdate,#txtvalason,#txtwfrdt,#txtwtdt,#txtwvaldate,#txtfrdt,#txttodt,#txtvalue,#txtRetFdt,#txtRetTodt").each(function () {
                $(this).datepicker({
                    showOn: "button",
                    buttonImageOnly: true,
                    buttonImage: "images/calendor.gif",
                    buttonText: "Select Date",
                    dateFormat: 'dd/mm/yy',
                    changeMonth: true,
                    changeYear: true,
                    width: 17,
                    Height: 17,
                    maxDate: -1
                }); //txtvalason

            });

            $("#txtwfrdt").watermark("From Date");
            $("#txtRetFdt").watermark("From Date");
            $("#txtfromDate").watermark("From Date");
            $("#txtfrdt").watermark("From Date");

            $("#txtwtdt").watermark("To Date");
            $("#txtRetTodt").watermark("To Date");
            $("#txtTdate").watermark("To Date");
            $("#txttodt").watermark("To Date");

            $("#txtwvaldate").watermark("Value as on date");
            $("#txtvalason").watermark("Value as on date");
            $("#txtvalue").watermark("Value as on date");

            //$("#txtinstall").watermark("Investment Amount");
            //debugger;

            if ($('#hdChartData').val() != 0) {
                //  debugger;
                if ($('#hdIsGraphExist').val() == 1) {
                    var val = "{'Type':'" + $('#hdChartData').val() + "'}";
                    if ($('#hdChartData').val() != 'STP') {
                        $.ajax({
                            type: "POST",
                            url: "SIPCalculator.aspx/getChartData",
                            async: false,
                            contentType: "application/json",
                            data: val,
                            dataType: "json",
                            success: function (msg) {
                                $('#hdIsGraphExist').val(1);
                                plotCart(msg.d);
                            },
                            error: function (msg) {
                                alert("Error! Try again...");
                            }
                        });
                    }
                    else {
                        $.ajax({
                            type: "POST",
                            url: "SIPCalculator.aspx/getChartData4Stp",
                            async: false,
                            contentType: "application/json",
                            data: val,
                            dataType: "json",
                            success: function (msg) {
                                $('#hdIsGraphExist').val(1);
                                plotCart4Stp(msg.d);
                            },
                            error: function (msg) {
                                alert("Error! Try again...");
                            }
                        });
                    }
                }
            }
        });

        function wordage(txt) {
            window.status = txt;
            setTimeout("clear()", 3000)
        }

        function clear() {
            window.status = "";
        }

        function plotCart4Stp(chart_data) {

            var dataPlot = [[]];
            var points = [];
            //var Amt = [];
            var Cumulative_Amount = [];
            var Investment_In_Index = [];
            var seriesNames = ["Cumulative Amount", "Investment In Index"];
            for (var i = 0; i < chart_data.length; i += 1) {

                //Amt.push(chart_data[i].Amount)
                Cumulative_Amount.push(chart_data[i].Cumulative_Amount)
                Investment_In_Index.push(chart_data[i].Investment_In_Index)
            }
            //dataPlot.push(Amt);
            dataPlot.push(Cumulative_Amount);
            dataPlot.push(Investment_In_Index);
            dataPlot.shift();
            var colorarray = ['#ffd700', '#4481b3', '#f92f2f', '#579575'];
            var plot2 = $.jqplot('dvChartNew', dataPlot, {
                // title: 'Chart with Point Labels',
                seriesDefaults: {
                    showMarker: false,
                    pointLabels: {
                        //show: true,
                        //edgeTolerance: 5
                    },
                    lineWidth: 1,
                    rendererOptions: {
                        smooth: true,
                        animation: { speed: 1000 }
                    }
                },
                highlighter: { show: true, sizeAdjust: 7.5 },
                cursor: { show: true, zoom: true, showTooltip: false },
                legend: {
                    renderer: $.jqplot.EnhancedLegendRenderer,
                    show: true,
                    location: 's',
                    background: '#e2e5ea',
                    placement: 'outsideGrid',
                    seriesToggle: 'on',
                    fontSize: '1em',
                    border: '0px solid black',
                    labels: seriesNames,
                    rendererOptions: {
                        numberRows: 1
                    }
                },
                grid: {
                    drawGridLines: true,        // wether to draw lines across the grid or not.
                    gridLineColor: '#cccccc',   // *Color of the grid lines.
                    background: '#e2e5ea',      // CSS color spec for background color of grid.
                    borderColor: '#999999',     // CSS color spec for border around grid.
                    borderWidth: 2.0,           // pixel width of border around grid.
                    shadow: true,               // draw a shadow for grid.
                    shadowAngle: 45,            // angle of the shadow.  Clockwise from x axis.
                    shadowOffset: 1.5,          // offset from the line of the shadow.
                    shadowWidth: 3,             // width of the stroke for the shadow.
                    shadowDepth: 3,             // Number of strokes to make when drawing shadow.
                    // Each stroke offset by shadowOffset from the last.
                    shadowAlpha: 0.07,         // Opacity of the shadow
                    renderer: $.jqplot.CanvasGridRenderer,  // renderer to use to draw the grid.
                    rendererOptions: {}         // options to pass to the renderer.  Note, the default
                    // CanvasGridRenderer takes no additional options.
                },
                axes: {
                    xaxis: {
                        min: 0,
                        max: chart_data.length + 1,
                        tickOptions: { formatString: '%.0f' } // tickOptions: { formatString: '$%d' }// change by syed
                    },
                    yaxis: { min: 0 }
                }
            });
        }

        function plotCart(chart_data) {

            var dataPlot = [[]];
            var points = [];
            var Amt = [];
            var Ind_Val = [];
            var Sip_Val = [];
            var seriesNames = ["Amount", "Sip Value", "Index Value"];
            for (var i = 0; i < chart_data.length; i += 1) {

                Amt.push(chart_data[i].Amount)
                Ind_Val.push(chart_data[i].Index_Value)
                Sip_Val.push(chart_data[i].Ret_Value)
            }
            dataPlot.push(Amt);
            dataPlot.push(Sip_Val);
            dataPlot.push(Ind_Val);
            dataPlot.shift();
            var colorarray = ['#ffd700', '#4481b3', '#f92f2f', '#579575'];

            var plot2 = $.jqplot('dvChartNew', dataPlot, {
                //title: 'Chart with Point Labels',
                seriesDefaults: {
                    showMarker: false,
                    pointLabels: {
                        //show: true,
                        //edgeTolerance: 5
                    },
                    lineWidth: 1,
                    rendererOptions: {
                        smooth: true,
                        animation: { speed: 1000 }
                    }
                },
                highlighter: { show: true, sizeAdjust: 7.5 },
                cursor: { show: true, zoom: true, showTooltip: false },
                legend: {
                    renderer: $.jqplot.EnhancedLegendRenderer,
                    show: true,
                    location: 's',
                    background: '#e2e5ea',
                    placement: 'outsideGrid',
                    seriesToggle: 'on',
                    fontSize: '1em',
                    border: '0px solid black',
                    labels: seriesNames,
                    rendererOptions: {
                        numberRows: 1
                    }
                },
                grid: {
                    drawGridLines: true,        // wether to draw lines across the grid or not.
                    gridLineColor: '#cccccc',   // *Color of the grid lines.
                    background: '#e2e5ea',      // CSS color spec for background color of grid.
                    borderColor: '#999999',     // CSS color spec for border around grid.
                    borderWidth: 2.0,           // pixel width of border around grid.
                    shadow: true,               // draw a shadow for grid.
                    shadowAngle: 45,            // angle of the shadow.  Clockwise from x axis.
                    shadowOffset: 1.5,          // offset from the line of the shadow.
                    shadowWidth: 3,             // width of the stroke for the shadow.
                    shadowDepth: 3,             // Number of strokes to make when drawing shadow.
                    // Each stroke offset by shadowOffset from the last.
                    shadowAlpha: 0.07,         // Opacity of the shadow
                    renderer: $.jqplot.CanvasGridRenderer,  // renderer to use to draw the grid.
                    rendererOptions: {}         // options to pass to the renderer.  Note, the default
                    // CanvasGridRenderer takes no additional options.
                },
                axes: {
                    xaxis: {
                        min: 0,
                        max: chart_data.length + 1,
                        tickOptions: { formatString: '%.0f' } // tickOptions: { formatString: '$%d' }// change by syed
                    },
                    yaxis: { min: 0 }
                }

            });
        }
    </script>

    <%-- New CSS / JS for Nippon --%>
    <%--<link id="CssRegistration7" rel="stylesheet" type="text/css"
        href="https://www.reliancemutual.com/Style%20Library/Reliance.MF.Resources/CSS/Old_reset.css" />--%>
    <link href="includes/nippon/css/style.css" rel="stylesheet" />
    <link href="includes/nippon/css/bootstrap.min.css"
        rel="stylesheet" type="text/css" />
    <link href="includes/nippon/css/RMFAnimate.css" rel="stylesheet"
        type="text/css" />
    <link href="includes/nippon/css/MenuStyle.css" rel="stylesheet"
        type="text/css" />
    <link href="includes/nippon/css/font-awesome.css" rel="stylesheet"
        type="text/css" />

    <%-- New JS for Nippon --%>

    <script language="javascript" type="text/javascript">

        function opnwindow(url) {
            window.open(url, '', 'top=0,left=0,toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,copyhistory=1,width= 1020,height= 720;');
        }

        //$(window).load(function () {
        //    // trLumpsumEmptyRow

        //    $("#ddPlan").change(function (e) {

        //        if ($("#ddPlan").val() == "4") {
        //            $("#trLumpsumEmptyRow").attr("style", "display: none!importent");
        //        }
        //        else {
        //            $("#trLumpsumEmptyRow").removeAttr("style");
        //        }
        //    });
        //});

        function wordage(txt) {
            window.status = txt;
            setTimeout("clear()", 3000)
        }

        function clear() {
            window.status = "";
        }


        function validate_SIP() {
            // ****************Created By MANISH PRASAD*****************

            //alert("hi");

            if (document.forms(0).ddPlan.options[document.forms(0).ddPlan.selectedIndex].value == '--') {
                alert('Please select any Plan.');
                document.forms(0).ddPlan.focus();
                return false;
            }

            if (document.forms(0).ddscheme.options[document.forms(0).ddscheme.selectedIndex].value == '--') {
                alert('Please select any Scheme.');
                document.forms(0).ddscheme.focus();
                return false;
            }

            if (document.forms(0).ddlsipbnmark.options[document.forms(0).ddlsipbnmark.selectedIndex].value == '--') {
                alert('Please select any Benchmark.');
                document.forms(0).ddlsipbnmark.focus();
                return false;
            }

            if (document.forms(0).txtinstall.value == '') {
                alert('Please enter the Installment amount.');
                document.forms(0).txtinstall.focus();
                return false;
            }


            if (!$.isNumeric(document.forms(0).txtinstall.value)) {
                alert('Please enter only number.');
                document.forms(0).txtinstall.focus();
                return false;
            }


            if (((document.forms(0).ddscheme.value != 'RC181') && (document.forms(0).ddscheme.value != 'RC182')) && (document.forms(0).txtinstall.value < 100) && (document.forms(0).ddPeriod_SIP.options[document.forms(0).ddPeriod_SIP.selectedIndex].value == 1)) {
                alert('Minimum installment amount is Rs. 100/- for 60 Months and in multiples of Rs.100/-');
                document.forms(0).txtinstall.focus();
                return false;
            }

            /*if(document.Form1.txtinstall.value < 100)
            {
            if (document.Form1.ddPeriod_SIP.options[document.Form1.ddPeriod_SIP.selectedIndex].value == 1)
            {
            if((document.Form1.ddscheme.value != 'RC182') || (document.Form1.ddscheme.value != 'RC181'))
            {
            alert(document.Form1.ddscheme.value);
            alert('Minimum installment amount is 100/- Rs. for 60 Months And in multiples of Rs.100/-');
            document.Form1.txtinstall.focus();
            return false;
            }
            }
            }*/

            //By Manish 14/11/2007

            //alert(document.Form1.ddscheme.value);
            if (document.forms(0).txtinstall.value < 500 && ((document.forms(0).ddscheme.value == 'RC182') || (document.forms(0).ddscheme.value == 'RC181')) && (document.forms(0).ddPeriod_SIP.options[document.forms(0).ddPeriod_SIP.selectedIndex].value == 1)) {

                alert('Minimum installment amount is Rs. 500/- for 12 Months and in multiples of Rs.100/- for Nippon India Tax Saver (ELSS) Fund ');
                document.forms(0).txtinstall.focus();
                return false;
            }
            //END	14/11/2007


            if (document.forms(0).txtinstall.value > 100) {
                var amt;
                amt = document.forms(0).txtinstall.value;
                if (amt % 100 != 0) {
                    if (document.forms(0).ddPeriod_SIP.options[document.forms(0).ddPeriod_SIP.selectedIndex].value == 2) {
                        alert('Minimum installment amount is  Rs. 1500/- and in multiples of Rs.100/-');
                        document.forms(0).txtinstall.focus();
                        return false;
                    }
                    if (document.forms(0).txtinstall.value > 500 && ((document.forms(0).ddscheme.value == 'RC182') || (document.forms(0).ddscheme.value == 'RC181')) && (document.forms(0).ddPeriod_SIP.options[document.forms(0).ddPeriod_SIP.selectedIndex].value == 1)) {

                        alert('Minimum installment amount is  Rs. 500/- for 12 Months and in multiples of Rs.100/- for Nippon India Tax Saver (ELSS) Fund ');
                        document.forms(0).txtinstall.focus();
                        return false;
                    }

                    if (document.forms(0).ddPeriod_SIP.options[document.forms(0).ddPeriod_SIP.selectedIndex].value == 1) {
                        alert('Minimum installment amount is  Rs. 100/- for 60 Months and in multiples of Rs.100/-');
                        document.forms(0).txtinstall.focus();
                        return false;
                    }


                }
            }

            if (document.forms(0).ddPeriod_SIP.options[document.forms(0).ddPeriod_SIP.selectedIndex].value == 0) {
                alert('Please select any Period.');
                document.forms(0).ddPeriod_SIP.focus();
                return false;
            }

            //validation for quarterly 
            if ((document.forms(0).ddPeriod_SIP.options[document.forms(0).ddPeriod_SIP.selectedIndex].value == 2) && ((document.forms(0).txtinstall.value < 1500) && (document.forms(0).txtinstall.value > 500))) {
                alert('Installment amount cant be less than  Rs. 1500/- and in multiples of Rs.100/- For 4 Quarters');
                document.forms(0).txtinstall.focus();
                return false;
            }

            if ((document.forms(0).ddPeriod_SIP.options[document.forms(0).ddPeriod_SIP.selectedIndex].value == 2) && (document.forms(0).txtinstall.value < 500)) {
                alert('Installment amount cant be less than  Rs. 500/- and in multiples of Rs.100/- For 12 Quarters');
                document.forms(0).txtinstall.focus();
                return false;
            }

            //validation for monthly 
            if ((document.forms(0).ddPeriod_SIP.options[document.forms(0).ddPeriod_SIP.selectedIndex].value == 1) && (document.forms(0).txtinstall.value < 100)) {
                alert('Installment amount cant be less then  Rs. 100/- and in multiples of Rs.100/-');
                document.forms(0).txtinstall.focus();
                return false;
            }

            if (document.forms(0).txtfromDate.value == '') {
                alert('Please enter From date.');
                document.forms(0).txtfromDate.focus();
                return false;
            }

            if (document.forms(0).txtTdate.value == '') {
                alert('Please enter To date.');
                document.forms(0).txtTdate.focus();
                return false;
            }

            if (document.forms(0).txtvalason.value == '') {
                alert('Please enter value as on date.');
                document.forms(0).txtvalason.focus();
                return false;
            }

            if (!valid_date(document.forms(0).txtfromDate, '/', false, true)) {
                //alert('Please enter from date in dd/MM/yyyy format');   
                return false;
            }

            if (!valid_date(document.forms(0).txtTdate, '/', false, true)) {
                return false;
            }

            if (!valid_date(document.forms(0).txtvalason, '/', false, true)) {

                return false;
            }


            if (!ChkDtFrmTodate(document.forms(0).txtfromDate.value)) {

                alert('From date can not be greater than Today date.');
                document.forms(0).txtfromDate.focus();
                return false;
            }
            if (!ChkDtFrmTodate(document.forms(0).txtTdate.value)) {

                alert('To date can not be greater than Today date.');
                document.forms(0).txtTdate.focus();
                return false;
            }
            if (!ChkDtFrmTodate(document.forms(0).txtvalason.value)) {

                alert('Value as on date can not be greater than Today date.');
                document.forms(0).txtvalason.focus();
                return false;
            }


            if (document.forms(0).txtfromDate.value == document.forms(0).txtTdate.value) {
                alert("From Date should be less than To Date..");
                return false;
            }

            if (compareDates(document.forms(0).txtTdate, document.forms(0).txtvalason)) {
                alert("To Date should be less than Value As On Date.");
                return false;
            }

            if (compareDates(document.forms(0).txtfromDate, document.forms(0).txtTdate)) {
                alert("From Date should be less than To Date..");
                return false;
            }



        }



        function validate_SWP() {
            // ****************Created By MANISH PRASAD*****************

            //alert("hi");

            if (document.forms(0).ddPlan.options[document.forms(0).ddPlan.selectedIndex].value == '--') {
                alert('Please select any Plan.');
                document.forms(0).ddPlan.focus();
                return false;
            }

            if (document.forms(0).ddwscname.options[document.forms(0).ddwscname.selectedIndex].value == '--') {
                alert('Please select any Scheme.');
                document.forms(0).ddwscname.focus();
                return false;
            }

            if (document.forms(0).ddwbnmark.options[document.forms(0).ddwbnmark.selectedIndex].value == '--') {
                alert('Please select any Benchmark.');
                document.forms(0).ddwbnmark.focus();
                return false;
            }

            if (document.forms(0).txtwinamt.value == '') {
                alert('Please enter the Initial amount.');
                document.forms(0).txtwinamt.focus();
                return false;
            }

            if (!$.isNumeric(document.forms(0).txtwinamt.value)) {
                alert('Please enter only number.');
                document.forms(0).txtwinamt.focus();
                return false;
            }

            if (document.forms(0).txtwtramt.value == '') {
                alert('Please enter the withdrawal amount.');
                document.forms(0).txtwtramt.focus();
                return false;
            }

            if (!$.isNumeric(document.forms(0).txtwtramt.value)) {
                alert('Please enter only number.');
                document.forms(0).txtwtramt.focus();
                return false;
            }



            if (document.forms(0).txtwtramt.value < 500) {
                alert('Minimum withdrawal amount should be Rs.500/- and in multiples of Rs.100/- thereafter');
                document.forms(0).txtwtramt.focus();
                return false;
            }

            if (document.forms(0).txtwtramt.value > 500) {
                var amt;
                amt = document.forms(0).txtwtramt.value;
                if (amt % 100 != 0) {
                    alert('Minimum withdrawal amount should be Rs.500/- and in multiples of Rs.100/- thereafter');
                    document.forms(0).txtwtramt.focus();
                    return false;
                }
            }

            var initamt;
            var withamt;
            initamt = document.forms(0).txtwinamt.value;
            withamt = document.forms(0).txtwtramt.value;
            //alert(initamt);
            //alert(initamt/withamt);

            if (initamt / withamt < 1) {
                alert('Withdrawal amount cannot be greater than initial amount.');
                document.forms(0).txtwtramt.focus();
                return false;

            }

            if (document.forms(0).txtwfrdt.value == '') {
                alert('Please enter From date.');
                document.forms(0).txtwfrdt.focus();
                return false;
            }

            if (document.forms(0).txtwtdt.value == '') {
                alert('Please enter To date.');
                document.forms(0).txtwtdt.focus();
                return false;
            }

            if (document.forms(0).txtwvaldate.value == '') {
                alert('Please enter value as on date.');
                document.forms(0).txtwvaldate.focus();
                return false;
            }


            if (!valid_date(document.forms(0).txtwfrdt, '/', false, true)) {
                return false;
            }

            if (!valid_date(document.forms(0).txtwtdt, '/', false, true)) {
                return false;
            }

            if (!valid_date(document.forms(0).txtwvaldate, '/', false, true)) {
                return false;
            }

            if (!ChkDtFrmTodate(document.forms(0).txtwfrdt.value)) {

                alert('From date can not be greater than Today date.');
                document.forms(0).txtwfrdt.focus();
                return false;
            }
            if (!ChkDtFrmTodate(document.forms(0).txtwtdt.value)) {

                alert('To date can not be greater than Today date.');
                document.forms(0).txtwtdt.focus();
                return false;
            }
            if (!ChkDtFrmTodate(document.forms(0).txtwvaldate.value)) {

                alert('Value as on date can not be greater than Today date.');
                document.forms(0).txtwvaldate.focus();
                return false;
            }



            if (document.forms(0).txtwfrdt.value == document.forms(0).txtwtdt.value) {
                alert("From Date should be less than  To Date..");
                return false;
            }

            if (compareDates(document.forms(0).txtwtdt, document.forms(0).txtwvaldate)) {
                alert("To Date should be less than As On Date.");
                return false;
            }

            if (compareDates(document.forms(0).txtwfrdt, document.forms(0).txtwtdt)) {
                alert("From Date should be less than To Date..");
                return false;
            }
        }



        function validate_STP() {
            // ****************Created By MANISH PRASAD*****************

            //alert("hi");

            if (document.forms(0).ddPlan.options[document.forms(0).ddPlan.selectedIndex].value == '--') {
                alert('Please select any Plan.');
                document.forms(0).ddPlan.focus();
                return false;
            }

            if (document.forms(0).ddtrfrom.options[document.forms(0).ddtrfrom.selectedIndex].value == '--') {
                alert('Please select any From Scheme.');
                document.forms(0).ddtrfrom.focus();
                return false;
            }

            if (document.forms(0).ddtrto.options[document.forms(0).ddtrto.selectedIndex].value == '--') {
                alert('Please select any To Scheme.');
                document.forms(0).ddtrto.focus();
                return false;
            }

            if (document.forms(0).ddbnmark.options[document.forms(0).ddbnmark.selectedIndex].value == '--') {
                alert('Please select any Benchmark.');
                document.forms(0).ddbnmark.focus();
                return false;
            }

            if (document.forms(0).txtiniamt.value == '') {
                alert('Please enter the Initial amount.');
                document.forms(0).txtiniamt.focus();
                return false;
            }

            if (!$.isNumeric(document.forms(0).txtiniamt.value)) {
                alert('Please enter only number.');
                document.forms(0).txtiniamt.focus();
                return false;
            }

            if (document.forms(0).txtiniamt.value < 1000 && ((document.forms(0).ddperiod.options[document.forms(0).ddperiod.selectedIndex].value == 1) || (document.forms(0).ddperiod.options[document.forms(0).ddperiod.selectedIndex].value == 2))) {
                alert('Initial amount cannot be less than 1,000/- Rs.');
                document.forms(0).txtiniamt.focus();
                return false;
            }


            if (document.forms(0).txtiniamt.value < 10000 && ((document.forms(0).ddperiod.options[document.forms(0).ddperiod.selectedIndex].value == 3) || (document.forms(0).ddperiod.options[document.forms(0).ddperiod.selectedIndex].value == 4))) {
                alert('Initial amount cannot be less than 10,000/- Rs.');
                document.forms(0).txtiniamt.focus();
                return false;
            }

            if (document.forms(0).txttranamt.value == '') {
                alert('Please enter the transfer amount.');
                document.forms(0).txttranamt.focus();
                return false;
            }


            if (!$.isNumeric(document.forms(0).txttranamt.value)) {
                alert('Please enter only number.');
                document.forms(0).txttranamt.focus();
                return false;
            }

            // By Manish 15/11/2007
            /*if(document.Form1.txttranamt.value < 1000)
            {  
            alert('Minimum transfer amount should be Rs.1000/- for Monthly option in multiples of Rs.100/- thereafter');
            document.Form1.txttranamt.focus();
            return false;
            }	
            */
            //END 15/11/2007

            if (document.forms(0).ddperiod.options[document.forms(0).ddperiod.selectedIndex].value == '--') {

                alert('Please select any period');
                document.forms(0).ddperiod.focus();
                return false;
            }
            //alert(document.Form1.ddperiod.value);

            //if (document.Form1.ddperiod.options[document.Form1.ddperiod.selectedIndex].value == 3)
            if (document.forms(0).ddperiod.options[document.forms(0).ddperiod.selectedIndex].value == 1) {
                if (document.forms(0).txttranamt.value > 1000) {
                    var amt;
                    amt = document.forms(0).txttranamt.value;
                    if (amt % 100 != 0) {
                        alert('Minimum transfer amount should be Rs.1000/- for Weekly option and in multiples of Rs.100/- thereafter');
                        document.forms(0).txttranamt.focus();
                        return false;
                    }
                }

                if (document.forms(0).txttranamt.value < 1000) {
                    alert('Minimum transfer amount should be Rs.1000/- for Weekly option in multiples of Rs.100/- thereafter');
                    document.forms(0).txttranamt.focus();
                    return false;
                }

            }


            if (document.forms(0).ddperiod.options[document.forms(0).ddperiod.selectedIndex].value == 2) {
                if (document.forms(0).txttranamt.value > 1000) {
                    var amt;
                    amt = document.forms(0).txttranamt.value;
                    if (amt % 100 != 0) {
                        alert('Minimum transfer amount should be Rs.1000/- for Fortnightly option and in multiples of Rs.100/- thereafter');
                        document.forms(0).txttranamt.focus();
                        return false;
                    }
                }

                if (document.forms(0).txttranamt.value < 1000) {
                    alert('Minimum transfer amount should be Rs.1000/- for Fortnightly option in multiples of Rs.100/- thereafter');
                    document.forms(0).txttranamt.focus();
                    return false;
                }

            }

            if (document.forms(0).ddperiod.options[document.forms(0).ddperiod.selectedIndex].value == 3) {
                if (document.forms(0).txttranamt.value > 1000) {
                    var amt;
                    amt = document.forms(0).txttranamt.value;
                    if (amt % 100 != 0) {
                        alert('Minimum transfer amount should be Rs.1000/- for Monthly option and in multiples of Rs.100/- thereafter');
                        document.forms(0).txttranamt.focus();
                        return false;
                    }
                }

                if (document.forms(0).txttranamt.value < 1000) {
                    alert('Minimum transfer amount should be Rs.1000/- for Monthly option in multiples of Rs.100/- thereafter');
                    document.forms(0).txttranamt.focus();
                    return false;
                }

            }


            if (document.forms(0).ddperiod.options[document.forms(0).ddperiod.selectedIndex].value == 4) {
                if (document.forms(0).txttranamt.value > 3000) {
                    var amt;
                    amt = document.forms(0).txttranamt.value;
                    if (amt % 100 != 0) {
                        alert('Minimum transfer amount should be Rs.3000/-for Quarterly option and in multiples of Rs.100/- thereafter');
                        document.forms(0).txttranamt.focus();
                        return false;
                    }
                }

                if (document.forms(0).txttranamt.value < 3000) {
                    alert('Minimum transfer amount should be Rs.3000/- for Quarterly option and in multiples of Rs.100/- thereafter');
                    document.forms(0).txttranamt.focus();
                    return false;
                }
            }



            if (document.forms(0).ddperiod.options[document.forms(0).ddperiod.selectedIndex].value == 0) {
                alert('Please select any Period.');
                document.forms(0).ddperiod.focus();
                return false;
            }


            //By Manish 17/11/2007
            //	alert(document.Form1.ddperiod.value);						
            //END


            if (document.forms(0).txtfrdt.value == '') {
                alert('Please enter From date.');
                document.forms(0).txtfrdt.focus();
                return false;
            }

            if (document.forms(0).txttodt.value == '') {
                alert('Please enter To date.');
                document.forms(0).txttodt.focus();
                return false;
            }

            if (document.forms(0).txtvalue.value == '') {
                alert('Please enter value as on date.');
                document.forms(0).txtvalue.focus();
                return false;
            }


            if (!valid_date(document.forms(0).txtfrdt, '/', false, true)) {
                return false;
            }

            if (!valid_date(document.forms(0).txttodt, '/', false, true)) {
                return false;
            }

            if (!valid_date(document.forms(0).txtvalue, '/', false, true)) {

                return false;
            }

            if (!ChkDtFrmTodate(document.forms(0).txtfrdt.value)) {

                alert('From date can not be greater than Today date.');
                document.forms(0).txtfrdt.focus();
                return false;
            }
            if (!ChkDtFrmTodate(document.forms(0).txttodt.value)) {

                alert('To date can not be greater than Today date.');
                document.forms(0).txttodt.focus();
                return false;
            }
            if (!ChkDtFrmTodate(document.forms(0).txtvalue.value)) {

                alert('Value as on date can not be greater than Today date.');
                document.forms(0).txtvalue.focus();
                return false;
            }


            if (document.forms(0).txtfrdt.value == document.forms(0).txttodt.value) {
                alert("From Date should be less than To Date..");
                return false;
            }

            if (compareDates(document.forms(0).txttodt, document.forms(0).txtvalue)) {
                alert("To Date should be less than  Value As On Date.");
                return false;
            }

            if (compareDates(document.forms(0).txtfrdt, document.forms(0).txttodt)) {
                alert("From Date should be less than To Date..");
                return false;
            }

            /*if (compareDates(document.Form1.txtfrdt,document.Form1.STPdt))
            {
            alert("From Date Can not be less than STP Date.");
            return false;
            }*/



        }

        function validate_STP_New() {
            // ****************Created By MANISH PRASAD*****************

            //alert("hi");

            if (document.forms(0).ddPlan.options[document.forms(0).ddPlan.selectedIndex].value == '--') {
                alert('Please select any Plan.');
                document.forms(0).ddPlan.focus();
                return false;
            }

            if (document.forms(0).ddtrfrom.options[document.forms(0).ddtrfrom.selectedIndex].value == '--') {
                alert('Please select any From Scheme.');
                document.forms(0).ddtrfrom.focus();
                return false;
            }

            if (document.forms(0).ddtrto.options[document.forms(0).ddtrto.selectedIndex].value == '--') {
                alert('Please select any To Scheme.');
                document.forms(0).ddtrto.focus();
                return false;
            }

            if (document.forms(0).ddbnmark.options[document.forms(0).ddbnmark.selectedIndex].value == '--') {
                alert('Please select any Benchmark.');
                document.forms(0).ddbnmark.focus();
                return false;
            }

            if (document.forms(0).txtiniamt.value == '') {
                alert('Please enter the Initial amount.');
                document.forms(0).txtiniamt.focus();
                return false;
            }

            if (!$.isNumeric(document.forms(0).txtiniamt.value)) {
                alert('Please enter only number.');
                document.forms(0).txtiniamt.focus();
                return false;
            }

            if (document.forms(0).txtiniamt.value < 1000 && ((document.forms(0).ddperiod.options[document.forms(0).ddperiod.selectedIndex].value == 1) || (document.forms(0).ddperiod.options[document.forms(0).ddperiod.selectedIndex].value == 2))) {
                alert('Initial amount cannot be less than 1,000/- Rs.');
                document.forms(0).txtiniamt.focus();
                return false;
            }


            if (document.forms(0).txtiniamt.value < 10000 && ((document.forms(0).ddperiod.options[document.forms(0).ddperiod.selectedIndex].value == 3) || (document.forms(0).ddperiod.options[document.forms(0).ddperiod.selectedIndex].value == 4))) {
                alert('Initial amount cannot be less than 10,000/- Rs.');
                document.forms(0).txtiniamt.focus();
                return false;
            }
            /*
            if(document.Form1.txttranamt.value == '')
            {
            alert('Please enter the transfer amount.');
            document.Form1.txttranamt.focus();
            return false;
            }
              
              
            if(!isNumber(document.Form1.txttranamt.value))
            {
            alert('Please enter only number.');
            document.Form1.txttranamt.focus();
            return false;
            }
            */
            // By Manish 15/11/2007
            /*if(document.Form1.txttranamt.value < 1000)
            {  
            alert('Minimum transfer amount should be Rs.1000/- for Monthly option in multiples of Rs.100/- thereafter');
            document.Form1.txttranamt.focus();
            return false;
            }	
            */
            //END 15/11/2007

            if (document.forms(0).ddperiod.options[document.forms(0).ddperiod.selectedIndex].value == '--') {

                alert('Please select any period');
                document.forms(0).ddperiod.focus();
                return false;
            }
            //alert(document.Form1.ddperiod.value);

            /*
            if (document.Form1.ddperiod.options[document.Form1.ddperiod.selectedIndex].value == 1)
            {
            if(document.Form1.txttranamt.value > 1000)
            {  
            var amt;
            amt=document.Form1.txttranamt.value;
            if(amt % 100 != 0)
            {
            alert('Minimum transfer amount should be Rs.1000/- for Weekly option and in multiples of Rs.100/- thereafter');
            document.Form1.txttranamt.focus();
            return false;
            }
            }	
              
            if(document.Form1.txttranamt.value < 1000)
            {  
            alert('Minimum transfer amount should be Rs.1000/- for Weekly option in multiples of Rs.100/- thereafter');
            document.Form1.txttranamt.focus();
            return false;
            }	
                      
            }	
          
          
            if (document.Form1.ddperiod.options[document.Form1.ddperiod.selectedIndex].value == 2)
            {
            if(document.Form1.txttranamt.value > 1000)
            {  
            var amt;
            amt=document.Form1.txttranamt.value;
            if(amt % 100 != 0)
            {
            alert('Minimum transfer amount should be Rs.1000/- for Fortnightly option and in multiples of Rs.100/- thereafter');
            document.Form1.txttranamt.focus();
            return false;
            }
            }	
              
            if(document.Form1.txttranamt.value < 1000)
            {  
            alert('Minimum transfer amount should be Rs.1000/- for Fortnightly option in multiples of Rs.100/- thereafter');
            document.Form1.txttranamt.focus();
            return false;
            }	
                      
            }	
          
            if (document.Form1.ddperiod.options[document.Form1.ddperiod.selectedIndex].value == 3)
            {
            if(document.Form1.txttranamt.value > 1000)
            {  
            var amt;
            amt=document.Form1.txttranamt.value;
            if(amt % 100 != 0)
            {
            alert('Minimum transfer amount should be Rs.1000/- for Monthly option and in multiples of Rs.100/- thereafter');
            document.Form1.txttranamt.focus();
            return false;
            }
            }	
              
            if(document.Form1.txttranamt.value < 1000)
            {  
            alert('Minimum transfer amount should be Rs.1000/- for Monthly option in multiples of Rs.100/- thereafter');
            document.Form1.txttranamt.focus();
            return false;
            }	
                      
            }	
          
          
            if (document.Form1.ddperiod.options[document.Form1.ddperiod.selectedIndex].value == 4)
            {
            if(document.Form1.txttranamt.value > 3000)
            {  
            var amt;
            amt=document.Form1.txttranamt.value;
            if(amt % 100 != 0)
            {
            alert('Minimum transfer amount should be Rs.3000/-for Quarterly option and in multiples of Rs.100/- thereafter');
            document.Form1.txttranamt.focus();
            return false;
            }
            }	
              
            if(document.Form1.txttranamt.value < 3000)
            {  
            alert('Minimum transfer amount should be Rs.3000/- for Quarterly option and in multiples of Rs.100/- thereafter');
            document.Form1.txttranamt.focus();
            return false;
            }							
            }	
          
            */

            if (document.forms(0).ddperiod.options[document.forms(0).ddperiod.selectedIndex].value == 0) {
                alert('Please select any Period.');
                document.forms(0).ddperiod.focus();
                return false;
            }

            /*
            //By Manish 17/11/2007
            //	alert(document.Form1.ddperiod.value);
            if ((document.Form1.ddperiod.value == 3)||(document.Form1.ddperiod.value == 4)||(document.Form1.ddperiod.value == 'Monthly')||(document.Form1.ddperiod.value == 'Quarterly')) 
            {
            if (document.Form1.STPdt.options[document.Form1.STPdt.selectedIndex].value == '--')
            {
          
            alert('Please select STP date');
            document.Form1.STPdt.focus();
            return false;
            }
              
            }
                      
            //END
          
            */
            if (document.forms(0).txtfrdt.value == '') {
                alert('Please enter From date.');
                document.forms(0).txtfrdt.focus();
                return false;
            }

            if (document.forms(0).txttodt.value == '') {
                alert('Please enter To date.');
                document.forms(0).txttodt.focus();
                return false;
            }

            if (document.forms(0).txtvalue.value == '') {
                alert('Please enter value as on date.');
                document.forms(0).txtvalue.focus();
                return false;
            }


            if (!valid_date(document.forms(0).txtfrdt, '/', false, true)) {
                return false;
            }

            if (!valid_date(document.forms(0).txttodt, '/', false, true)) {
                return false;
            }

            if (!valid_date(document.forms(0).txtvalue, '/', false, true)) {

                return false;
            }


            if (!ChkDtFrmTodate(document.forms(0).txtfrdt.value)) {

                alert('From date can not be greater than Today date.');
                document.forms(0).txtfrdt.focus();
                return false;
            }
            if (!ChkDtFrmTodate(document.forms(0).txttodt.value)) {

                alert('To date can not be greater than Today date.');
                document.forms(0).txttodt.focus();
                return false;
            }
            if (!ChkDtFrmTodate(document.forms(0).txtvalue.value)) {

                alert('Value as on date can not be greater than Today date.');
                document.forms(0).txtvalue.focus();
                return false;
            }


            if (document.forms(0).txtfrdt.value == document.forms(0).txttodt.value) {
                alert("From Date should be less than To Date..");
                return false;
            }

            if (compareDates(document.forms(0).txttodt, document.forms(0).txtvalue)) {
                alert("To Date should be less than  Value As On Date.");
                return false;
            }

            if (compareDates(document.forms(0).txtfrdt, document.forms(0).txttodt)) {
                alert("From Date should be less than To Date..");
                return false;
            }

            /*if (compareDates(document.Form1.txtfrdt,document.Form1.STPdt))
            {
            alert("From Date Can not be less than STP Date.");
            return false;
            }*/



        }

        function validate_RETURNS() {
            // ****************Created By MANISH PRASAD*****************

            //alert("hi");

            if (document.forms(0).ddPlan.options[document.forms(0).ddPlan.selectedIndex].value == '--') {
                alert('Please select any Plan.');
                document.forms(0).ddPlan.focus();
                return false;
            }

            if (document.forms(0).ddRetscname.options[document.forms(0).ddRetscname.selectedIndex].value == '--') {
                alert('Please select any Scheme.');
                document.forms(0).ddRetscname.focus();
                return false;
            }

            if (document.forms(0).ddRetbnmark.options[document.forms(0).ddRetbnmark.selectedIndex].value == '--') {
                alert('Please select any Benchmark.');
                document.forms(0).ddRetbnmark.focus();
                return false;
            }

            if (document.forms(0).txtRetInsAmt.value == '') {
                alert('Please enter the Investment amount.');
                document.forms(0).txtRetInsAmt.focus();
                return false;
            }


            //            if (!isNumber(document.forms(0).txtRetInsAmt.value)) {
            if (!$.isNumeric(document.forms(0).txtRetInsAmt.value)) {
                alert('Please enter only number.');
                document.forms(0).txtRetInsAmt.focus();
                return false;
            }

            /*if(document.Form1.txtRetInsAmt.value < 100 && (document.Form1.ddPeriod_SIP.options[document.Form1.ddPeriod_SIP.selectedIndex].value == 1))
            {
            alert('Minimum installment amount is 100/- Rs. And in multiples of Rs.100/-');
            document.Form1.txtinstall.focus();
            return false;
            }
              
          
            if(document.Form1.txtinstall.value > 100)
            {  
            var amt;
            amt=document.Form1.txtinstall.value;
            if(amt % 100 != 0)
            {
            if (document.Form1.ddPeriod_SIP.options[document.Form1.ddPeriod_SIP.selectedIndex].value == 2)
            {
            alert('Minimum installment amount is 1500/- Rs. And in multiples of Rs.100/-');
            document.Form1.txtinstall.focus();
            return false;
            }	
                  
            if (document.Form1.ddPeriod_SIP.options[document.Form1.ddPeriod_SIP.selectedIndex].value == 1)
            {				
            alert('Minimum installment amount is 100/- Rs. And in multiples of Rs.100/-');
            document.Form1.txtinstall.focus();
            return false;
            }
            }
            }
      
            if (document.Form1.ddPeriod_SIP.options[document.Form1.ddPeriod_SIP.selectedIndex].value == 0)
            {
            alert('Please select any Period.');
            document.Form1.ddPeriod_SIP.focus();
            return false;
            }
          
            //validation for quarterly 
            if ((document.Form1.ddPeriod_SIP.options[document.Form1.ddPeriod_SIP.selectedIndex].value == 2)  &&  (document.Form1.txtinstall.value <1500))
            {				
            alert('Installment amount cant be less than 1500/- Rs. And in multiples of Rs.100/-');
            document.Form1.txtinstall.focus();
            return false;
            }
            //validation for monthly 
            if ((document.Form1.ddPeriod_SIP.options[document.Form1.ddPeriod_SIP.selectedIndex].value == 1)  &&  (document.Form1.txtinstall.value <100))
            {				
            alert('Installment amount cant be less then 100/- Rs. And in multiples of Rs.100/-');
            document.Form1.txtinstall.focus();
            return false;
            }*/

            if (document.forms(0).txtRetFdt.value == '') {
                alert('Please enter From date.');
                document.forms(0).txtRetFdt.focus();
                return false;
            }

            if (document.forms(0).txtRetTodt.value == '') {
                alert('Please enter To date.');
                document.forms(0).txtRetTodt.focus();
                return false;
            }

            /*if(document.Form1.txtvalason.value == '')
            {
            alert('Please enter value as on date.');
            document.Form1.txtvalason.focus();
            return false;
            }*/

            if (!valid_date(document.forms(0).txtRetFdt, '/', false, true)) {
                //alert('Please enter from date in dd/MM/yyyy format');   
                return false;
            }

            if (!valid_date(document.forms(0).txtRetTodt, '/', false, true)) {
                return false;
            }

            /*if (! valid_date(document.Form1.txtvalason,'/',false,true))
            {  
                  
            return false;
            }*/


            if (!ChkDtFrmTodate(document.forms(0).txtRetFdt.value)) {

                alert('From date can not be greater than Today date.');
                document.forms(0).txtRetFdt.focus();
                return false;
            }
            if (!ChkDtFrmTodate(document.forms(0).txtRetTodt.value)) {

                alert('To date can not be greater than Today date.');
                document.forms(0).txtRetTodt.focus();
                return false;
            }
            /*if (!ChkDtFrmTodate(document.Form1.txtvalason.value))
            {  
              
            alert('Value as on date can not be greater than Today date.');
            document.Form1.txtvalason.focus();
            return false;
            }*/


            if (document.forms(0).txtRetFdt.value == document.forms(0).txtRetTodt.value) {
                alert("From Date should be less than To Date..");
                return false;
            }

            /*if (compareDates(document.forms(0).txtTdate,document.Form1.txtvalason))
            {
            alert("To Date should be less than Value As On Date.");
            return false;
            }*/

            if (compareDates(document.forms(0).txtRetFdt, document.forms(0).txtRetTodt)) {
                alert("From Date should be less than To Date..");
                return false;
            }



        }



    </script>

    <%--<link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300' rel='stylesheet' type='text/css'>--%>
    <style type="text/css">
        .ui-datepicker {
            font-size: 9pt !important;
        }

        body {
            font-family: "Open Sans", sans-serif;
        }
    </style>
    <%-- <script type="text/javascript">
        WebFontConfig = {
            google: { families: ['Open+Sans:400,300:latin'] }
        };
        (function () {
            var wf = document.createElement('script');
            wf.src = ('https:' == document.location.protocol ? 'https' : 'http') +
              '://ajax.googleapis.com/ajax/libs/webfont/1/webfont.js';
            wf.type = 'text/javascript';
            wf.async = 'true';
            var s = document.getElementsByTagName('script')[0];
            s.parentNode.insertBefore(wf, s);
        })(); </script>--%>
    <style type="text/css">
        #header{
            background-image: url(images/RMF_Spiral_Background.jpg);
            background-repeat: repeat;
        }
        
        .relianceblue {
            color: #034ea2;
            font-family: arial;
            font-size: 16px;
            font-weight: bold;
            padding-right: 10px;
        }
        .auto-style1 {
            width: 184px;
        }
        .auto-style2 {
            width: 230px;
        }

        /******************** Loader Style ***************************/

        #overlay {
            position: fixed;
            top: 0;
            z-index: 99999;
            width: 100%;
            height: 100%;
            display: none;
            background: rgba(0,0,0,0.6);
        }

        .cv-spinner {
            height: 100%;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .spinner {
            width: 40px;
            height: 40px;
            border: 4px #ddd solid;
            border-top: 4px #2e93e6 solid;
            border-radius: 50%;
            animation: sp-anime 0.8s infinite linear;
        }

        @keyframes sp-anime {
            100% {
                transform: rotate(360deg);
            }
        }

        ul li{
            list-style-type:none;
        }
        ul li a{
            display:inline;
        }
    </style>
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <asp:HiddenField ID="SIPPDFValue" runat="server" Value="" />
        <table>
            <tr>
                <td>
                    <header id="header">
                        <div id="header-BG">
                            <div class="row">
                <div id="top">
                    <div class="container-fluid">
                        <div class="row menu_top">
                            <div class="col-md-4 col-sm-3 col-xs-6 hidden-xs">
                                <div class="top-logo">
                                    <a href="/"><img src="images/reliance-mutual-fund.png" class="img-responsive" alt="Nippon India mutual fund" width="34%"></a>
                                </div>
                            </div>

                            <div class="col-md-2 col-sm-9 col-xs-6 no-padding form_text">
                                <p>(Formerly Reliance Mutual Fund)</p>
                            </div>
                            <div class="col-md-6 col-sm-9 col-xs-6 no-padding text-right">
                                <div class="login hidden-xs green-bg">
                                    <ul class="list-style-none list-inline top-menu-two">
                                        <li class="utility-menu-dropdown">
                                            <div class=" hidden-xs hidden-sm no-border">
                                                <div class="dropdown">
                                                    <a href="/" data-toggle="dropdown" class="dropdown-toggle ">Individual Investor<i class="fa fa-angle-down" aria-hidden="true"></i></a>
                                                    <ul class="dropdown-menu">
                                                        <li class="no-border"><a href="https://online.reliancemutual.com/investeasy/" target="_blank">Corporate Investor</a>
                                                        </li>
                                                        <li><a href="/distributor-centre" target="_blank">Distributor</a></li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </li>
                                        <li><a href="https://investeasy.reliancemutual.com/Online/transaction/dropoffauth" target="_blank">Resume Transaction</a></li>
                                        <li>
                                            <a href="tel:18602660111" class="phoneicon"><img src="images/phone-icon.png" />1860 266 0111</a>
                                        </li>
                                        <li><a href="https://www.reliancemutual.com/MediaRoom/Pages/MediaCenter.aspx">Media</a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
                        </div>
                        <script type="text/javascript">
                            //Display Popup
                            $(function () {
                                $(".after_login").on("click", function () {
                                    $(".user_Dash_dDown_blk").slideToggle();
                                });
                                menuSliding();
                            });

                            function menuSliding() {
                                $('.dropdown').on('show.bs.dropdown', function (e) {
                                    if ($(window).width() > 750) {
                                        $(this).find('.dropdown-menu').first().stop(true, true).slideDown();

                                    } else {
                                        $(this).find('.dropdown-menu').first().stop(true, true).show();
                                    }
                                });
                                $('.dropdown').on('hide.bs.dropdown', function (e) {
                                    if ($(window).width() > 750) {
                                        $(this).find('.dropdown-menu').first().stop(true, true).slideUp();
                                    } else {
                                        $(this).find('.dropdown-menu').first().stop(true, true).hide();
                                    }
                                });

                            }





        </script>

                        <input type="hidden" name="ctl00$WebsiteMasterHeader$MasterNavigation$hdnIsLoggedIn" id="hdnIsLoggedIn" value="false">
                        <input type="hidden" name="ctl00$WebsiteMasterHeader$MasterNavigation$hdnKarvyIntegrationParameters" id="hdnKarvyIntegrationParameters">
                        <input type="hidden" name="ctl00$WebsiteMasterHeader$MasterNavigation$hdnName" id="hdnName">
                        <input type="hidden" name="ctl00$WebsiteMasterHeader$MasterNavigation$hdnEmailID" id="hdnEmailID">
                        <input type="hidden" name="ctl00$WebsiteMasterHeader$MasterNavigation$hdnMobileNo" id="hdnMobileNo">
                        <input type="hidden" name="ctl00$WebsiteMasterHeader$MasterNavigation$hdnActivateChat" id="hdnActivateChat" value="1">
                        <input type="hidden" name="ctl00$WebsiteMasterHeader$MasterNavigation$hdChatLink" id="hdChatLink" value="007">
                        <input type="hidden" name="ctl00$WebsiteMasterHeader$MasterNavigation$hndservercount" id="hndservercount" value="">

                        <!-- Messgae Modal Pop-up Start -->
                             <div class="modal fade" id="myModal" role="dialog" style="z-index: 10000;">
                            <div class="modal-dialog">
                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal">×</button>
                                        <h4 class="modal-title" id="ErrorMessageHeader">Notification</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div id="ErrorMessage"></div>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">OK</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        

                             <div class="navbar-affixed-top affix-top" data-spy="affix" data-offset-top="200">
                            <div class="navbar navbar-default yamm" role="navigation" id="navbar">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="navbar-header">
                                            <div class="row">
                                                <div class="col-xs-2">
                                                    <div class="navbar-buttons">
                                                        <div class="cd-main-header ">
                                                            <ul class="cd-header-buttons1">
                                                                <li><a class="cd-nav-trigger" href="#cd-primary-nav"><span></span></a></li>
                                                            </ul>
                                                            <!-- cd-header-buttons -->
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xs-10">
                                                    <a class="navbar-brand home" href="/">
                                                        <img src="images/reliance-mutual-fund.png" alt="Universal logo" class="nav-logo" width="40%"></a>
                                                </div>
                                                <div class="col-md-12 col-sm-12 col-xs-12 no-padding form_text">
                                                    <p>(Formerly Reliance Mutual Fund)</p>
                                                </div>

                                            </div>
                                        </div>
                                        <!--/.navbar-header -->
                        
                                        <!-- Main Navigation (Toolbar) Goes Here -->
                                        <!-- Right Navigation Button Code Goes Here -->

                                        <!--/.nav-collapse -->
                                    </div>
                                </div>
                                <div id="cd-search" class="cd-search">

                                    <input type="search" placeholder="Search..." class="placeholder">

                                </div>
                            </div>
                            <!-- /#navbar -->
                        </div>

                    </header>
                </td>
            </tr>
            <tr>
                <td width="100%">&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <table width="940px !important" border="0" cellpadding="0"
                        cellspacing="0" align="center" style="padding-top: 20px">
                        <!-- For blank row -->
                        <!-- Manish Top Main Table -->
                        <tr>
                            <td>
                                <table cellspacing="0" cellpadding="0" width="100%"
                                    align="center" border="0">
                                    <tr>
                                        <td valign="top" align="center">
                                            <table id="Table1" cellspacing="0" cellpadding="0"
                                                width="100%" align="center" border="0">
                                                <tr>
                                                    <td style="height: 38px">
                                                        <table id="Table18" cellspacing="0" cellpadding="0"
                                                            width="100%" bgcolor="#ffffff"
                                                            border="0">
                                                            <tr>
                                                                <td class="title">
                                                                    <h1>FINANCIAL CALCULATOR FOR SIP / SWP / STP</h1>
                                                                    <p class="txt2" style="font-size: 13px; text-align: justify;
                                                                        line-height: 16px;">
                                                                        A Systematic Investment Plan (SIP)
                                                                        is the most convenient way of investing in mutual
                                                                        funds. It enables you to invest a certain amount of
                                                                        money determined by you on regular intervals of your
                                                                        choice (monthly, quarterly, or weekly). Our handy
                                                                        SIP calculator will assist you to find the future
                                                                        yield of your investment and make a prudent decision
                                                                        as how much you need to invest to realize your financial
                                                                        goal.
                                                                    </p>
                                                                    <input id="txtMess" style="width: 8px; height: 21px"
                                                                        type="hidden" size="1" value="N"
                                                                        name="txtMess" runat="server">
                                                                </td>
                                                                <td class="title">
                                                                    <asp:Label ID="Stplb" runat="server" Font-Bold="True"
                                                                        Height="20px" Width="16px"
                                                                        Font-Size="8pt" ForeColor="DimGray" Visible="False"></asp:Label><asp:Label
                                                                            ID="Siplb"
                                                                            runat="server" Font-Bold="True" Height="20px" Width="8px"
                                                                            Font-Size="8pt" ForeColor="DimGray"
                                                                            Visible="False"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <!-- Manish Top Main Table -->
                                            <!--<table width="100%" border="0" cellspacing="0" cellpadding="0" class="toppannel01" border=2 bordercolor=red >
							<tr width="100%">
								<td width="100%">-->
                                            <table id="Table2" cellspacing="0" cellpadding="0"
                                                width="100%" border="0">
                                                <tr class="row_clr">
                                                    <td class="left_row">
                                                        <asp:Label ID="Label26" runat="server" CssClass="txt2">
																&nbsp;Plans</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddPlan" runat="server" CssClass="select"
                                                            OnSelectedIndexChanged="ddPlan_SelectedIndexChanged"
                                                            Width="200px" AutoPostBack="true">
                                                            <asp:ListItem Value="1">SIP</asp:ListItem>
                                                            <asp:ListItem Value="2">SWP</asp:ListItem>
                                                            <asp:ListItem Value="3">STP</asp:ListItem>
                                                            <asp:ListItem Value="4">LUMPSUM INVESTMENT</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <input type="hidden" value="0" id="hdChartData" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <table id="tblSWP" cellspacing="0" cellpadding="0"
                                                width="100%" border="0" runat="server">
                                                <tr>
                                                    <td>
                                                        <table id="Table3" cellspacing="0" cellpadding="0"
                                                            width="100%" bgcolor="#ffffff"
                                                            border="0">
                                                            <tr class="row_altclr">
                                                                <td class="left_row">
                                                                    <asp:Label ID="Label11" runat="server" CssClass="txt2">
																			Scheme</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddwscname" runat="server" Width="300px"
                                                                        CssClass="select" AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 280px" valign="top"></td>
                                                            </tr>
                                                            <tr class="row_clr">
                                                                <td class="left_row">
                                                                    <asp:Label ID="Label24" runat="server" CssClass="txt2">
																			Benchmark</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddwbnmark" runat="server" Width="300px"
                                                                        CssClass="select" BackColor="White">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddwbnmark1" runat="server" Height="16px"
                                                                        Width="55px" Font-Size="11px"
                                                                        Visible="False" CssClass="select" AutoPostBack="True"
                                                                        BackColor="White">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table id="SIP" cellspacing="0" cellpadding="0" width="100%"
                                                            bgcolor="#ffffff" border="0">
                                                            <tr class="row_altclr">
                                                                <td class="left_row">
                                                                    <asp:Label ID="Label30" runat="server" CssClass="txt2">
																			Initial Amount (&#x20B9;)</asp:Label>
                                                                </td>
                                                                <td style="width: 131px">
                                                                    <asp:TextBox ID="txtwinamt" runat="server" MaxLength="14"
                                                                        CssClass="TextBox"></asp:TextBox>
                                                                </td>
                                                                <td style="width: 10px">
                                                                    <asp:Label ID="Label41" runat="server" Font-Size="8pt"
                                                                        ForeColor="White" Visible="False">Exit Load</asp:Label>
                                                                </td>
                                                                <td style="width: 151px">
                                                                    <asp:TextBox ID="txtSWP_EntryLoad" runat="server" Visible="False"
                                                                        MaxLength="14"
                                                                        CssClass="TextBox
                                                                        ">0</asp:TextBox>
                                                                </td>
                                                                <td style="width: 30px"></td>
                                                                <td></td>
                                                            </tr>
                                                            <tr class="row_clr">
                                                                <td class="left_row">
                                                                    <asp:Label ID="Label27" runat="server" CssClass="txt2">
																			Withdrawal Amount (&#x20B9;)</asp:Label>
                                                                </td>
                                                                <td style="width: 131px; height: 27px" align="left">
                                                                    <asp:TextBox ID="txtwtramt" runat="server" MaxLength="14"
                                                                        CssClass="TextBox"></asp:TextBox>
                                                                </td>
                                                                <td style="width: 10px; height: 27px"></td>
                                                                <td style="width: 151px; height: 27px">
                                                                    <table id="tblSWP_rdo" cellspacing="1" cellpadding="1"
                                                                        width="136" border="0" runat="server">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:RadioButton ID="rbwind" runat="server" Font-Size="11px"
                                                                                    Visible="False" CssClass="graytxtbold01"
                                                                                    Checked="True" Text="Individual"></asp:RadioButton>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RadioButton ID="rbwcorp" runat="server" Font-Size="11px"
                                                                                    Visible="False" CssClass="graytxtbold01"
                                                                                    Text="Corporate"></asp:RadioButton>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td style="width: 30px; height: 27px"></td>
                                                                <td style="height: 27px"></td>
                                                            </tr>
                                                            <tr class="row_altclr">
                                                                <td class="left_row">
                                                                    <asp:Label ID="Period" runat="server" CssClass="txt2">
																			Period</asp:Label>
                                                                </td>
                                                                <td style="width: 155px" align="left">
                                                                    <asp:DropDownList ID="ddwperiod" runat="server" CssClass="select"
                                                                        Enabled="False">
                                                                        <asp:ListItem Value="0">Monthly</asp:ListItem>
                                                                        <asp:ListItem Value="1">Fortnightly</asp:ListItem>
                                                                        <asp:ListItem Value="2">Monthly</asp:ListItem>
                                                                        <asp:ListItem Value="3">Quarterly</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 10px">&nbsp;
                                                                </td>
                                                                <td style="width: 151px"></td>
                                                                <td style="width: 30px">&nbsp;
                                                                </td>
                                                                <td></td>
                                                            </tr>
                                                            <tr class="row_clr">
                                                                <td class="left_row">
                                                                    <asp:Label ID="Label34" runat="server" CssClass="txt2">SWP Date</asp:Label>
                                                                </td>
                                                                <td style="width: 131px" align="left">
                                                                    <asp:DropDownList ID="ddSWPDate" runat="server" CssClass="select">
                                                                        <asp:ListItem Value="0">01st</asp:ListItem>
                                                                        <asp:ListItem Value="1">08th</asp:ListItem>
                                                                        <asp:ListItem Value="2">15th</asp:ListItem>
                                                                        <asp:ListItem Value="3">22nd</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 10px">&nbsp;
                                                                </td>
                                                                <td style="width: 151px">
                                                                    <asp:CheckBox ID="chkChart_SWP" runat="server" CssClass="graytxtbold01"
                                                                        Text="&nbsp;Show Graph"></asp:CheckBox>
                                                                </td>
                                                                <td style="width: 30px">&nbsp;
                                                                </td>
                                                                <td></td>
                                                            </tr>
                                                            <tr class="row_altclr">
                                                                <td class="left_row">
                                                                    <asp:Label ID="Label32" runat="server" CssClass="txt2">
																			Date</asp:Label>
                                                                </td>
                                                                <td style="width: 131px; vertical-align: middle">
                                                                    <asp:TextBox ID="txtwfrdt" runat="server" CssClass="TextBox"></asp:TextBox>
                                                                </td>
                                                                <td style="width: 10px">
                                                                    <%--<asp:Label ID="Label31" runat="server" CssClass="txt2">
																			To Date</asp:Label>--%>
                                                                &nbsp;
                                                                </td>
                                                                <td style="width: 151px">
                                                                    <asp:TextBox ID="txtwtdt" ToolTip="To Date" runat="server"
                                                                        CssClass="TextBox"></asp:TextBox>&nbsp;
                                                                <%--<a href="Javascript:ShowCalendars('document.forms(0).txtwtdt',1900,2100,'dd/mm/yyyy');"><img id="Img8" style="WIDTH: 17px" height="17" src="images/calendor.gif" width="17" align="middle"
                                                                        border="0"></a>--%>
                                                                </td>
                                                                <td style="width: 30px">
                                                                    <%--<asp:Label ID="Label29" runat="server" CssClass="txt2">
																			Value As On Date</asp:Label>--%>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtwvaldate" ToolTip="As On Date"
                                                                        runat="server" CssClass="TextBox" Width="135px"></asp:TextBox>&nbsp;
                                                                    <%--<a href="Javascript:ShowCalendars('document.forms(0).txtwvaldate',1900,2100,'dd/mm/yyyy');"><img id="Img9" style="WIDTH: 17px" height="17" src="images/calendor.gif" width="17" align="middle"
                                                                        border="0"></a>--%>
                                                                </td>
                                                            </tr>
                                                            <tr class="row_altclr">
                                                                <td class="left_row"></td>
                                                                <td colspan="5">
                                                                    <asp:Label ID="Label1" runat="server" CssClass="txt1">* Enter date in DD/MM/YYYY format</asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <%-- <table class="row_clr" id="Table21" style="WIDTH: 770px; HEIGHT: 8px" cellspacing="1" cellpadding="1" border="0">
                                                            <tr>
                                                                <td style="WIDTH: 727px">
                                                                    
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="linedotted01" colspan="3">
                                                                    <img alt="" src="images/blank_space.gif">
                                                                </td>
                                                            </tr>
                                                        </table>--%>
                                                        <table id="Table4" cellspacing="0" cellpadding="0"
                                                            width="100%" border="0" style="height: 70px">
                                                            <tr class="row_clr">
                                                                <td style="width: 16%;">&nbsp;</td>
                                                                <td style="width: 12%; padding-left: 15px">
                                                                    <%--<asp:Button ID="cmdSWP" runat="server"  Width="48px" Font-Size="11px"
                                                                    CssClass="bttn01" Text="Show"></asp:Button>--%>
                                                                    <asp:ImageButton ID="cmdSWP" runat="server" CssClass="button Save"
                                                                        ImageUrl="images/show.jpg" />
                                                                </td>
                                                                <td style="width: 12%; padding-left: 15px">
                                                                    <%--<asp:Button ID="btnwreset" runat="server"  Width="49px" Font-Size="11px"
                                                                    CssClass="bttn01" Text="Reset"></asp:Button>--%>
                                                                    <asp:ImageButton ID="btnwreset" runat="server" CssClass="button"
                                                                        ImageUrl="images/reset.jpg" />
                                                                </td>
                                                                <td style="padding-left: 15px" class="auto-style1">
                                                                    <%--<asp:Button ID="btnwexport" runat="server"  Width="48px" Font-Size="11px"
                                                                    CssClass="bttn01" Text="Save"></asp:Button>--%>
                                                                    <%--<asp:ImageButton ID="btnwexport" runat="server" CssClass="button"  style="display:none;"
                                                                        ImageUrl="images/save.jpg" />--%>
                                                                </td>
                                                                <td style="padding-left: 15px" class="auto-style2">
                                                                    <%--<asp:Button ID="btnwexport" runat="server"  Width="48px" Font-Size="11px"
                                                                    CssClass="bttn01" Text="Save"></asp:Button>--%>
                                                                    
                                                                    <%--<Button ID="btnExportPdf" type="button" class="button" style="display:none;">Export Pdf</Button>--%>
                                                                    
                                                                
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="tblSIP" cellspacing="0" cellpadding="0"
                                                width="100%" border="0" runat="server">
                                                <tr>
                                                    <td>
                                                        <table id="Table6" cellspacing="0" cellpadding="0"
                                                            width="100%" bgcolor="#ffffff"
                                                            border="0">
                                                            <tr class="row_altclr">
                                                                <td class="left_row">
                                                                    <asp:Label ID="Label12" runat="server" CssClass="txt2">
																			Scheme</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddscheme" runat="server" CssClass="select"
                                                                        AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td valign="middle"></td>
                                                            </tr>
                                                            <tr class="row_clr">
                                                                <td class="left_row">
                                                                    <asp:Label ID="Label25" runat="server" CssClass="txt2">
																			Benchmark</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlsipbnmark" runat="server"
                                                                        CssClass="select">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlsipbnmark1" runat="server"
                                                                        Visible="False" CssClass="select"
                                                                        AutoPostBack="True" BackColor="White">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr class="row_altclr">
                                                                <td class="left_row">
                                                                    <asp:Label ID="Label13" runat="server" CssClass="txt2">
																			Installment Amount (&#x20B9;)</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtinstall" runat="server" MaxLength="14"
                                                                        CssClass="TextBox" Width="120px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label37" runat="server" Visible="False"
                                                                        CssClass="txt2">
																			&nbsp;Entry Load</asp:Label>
                                                                    <asp:TextBox ID="txtSIP_EntryLoad" runat="server" Visible="False"
                                                                        MaxLength="14"
                                                                        CssClass="TextBox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table id="Table7" cellspacing="0" cellpadding="0"
                                                            width="100%" bgcolor="#ffffff"
                                                            border="0">
                                                            <tr class="row_clr">
                                                                <td class="left_row">
                                                                    <asp:Label ID="Label28" runat="server" CssClass="txt2">
																			Period</asp:Label>
                                                                </td>
                                                                <td style="width: 170px">
                                                                    <asp:DropDownList ID="ddPeriod_SIP" runat="server"
                                                                        CssClass="select" Width="120px">
                                                                        <asp:ListItem Value="0">--</asp:ListItem>
                                                                        <asp:ListItem Value="1">Monthly</asp:ListItem>
                                                                        <asp:ListItem Value="2">Quarterly</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 150px" valign="middle">
                                                                    <asp:Label ID="Label35" runat="server" CssClass="txt2">
																			SIP Date</asp:Label>
                                                                    &nbsp;
                                                                <asp:DropDownList ID="ddSIPdate" runat="server" CssClass="select"
                                                                    Style="width: 45%">
                                                                    <asp:ListItem Value="1">01st</asp:ListItem>
                                                                    <asp:ListItem Value="2">02nd</asp:ListItem>
                                                                    <asp:ListItem Value="3">03rd</asp:ListItem>
                                                                    <asp:ListItem Value="4">04th</asp:ListItem>
                                                                    <asp:ListItem Value="5">05th</asp:ListItem>
                                                                    <asp:ListItem Value="6">06th</asp:ListItem>
                                                                    <asp:ListItem Value="7">07th</asp:ListItem>
                                                                    <asp:ListItem Value="8">08th</asp:ListItem>
                                                                    <asp:ListItem Value="9">09th</asp:ListItem>
                                                                    <asp:ListItem Value="10">10th</asp:ListItem>
                                                                    <asp:ListItem Value="11">11th</asp:ListItem>
                                                                    <asp:ListItem Value="12">12th</asp:ListItem>
                                                                    <asp:ListItem Value="13">13th</asp:ListItem>
                                                                    <asp:ListItem Value="14">14th</asp:ListItem>
                                                                    <asp:ListItem Value="15">15th</asp:ListItem>
                                                                    <asp:ListItem Value="16">16th</asp:ListItem>
                                                                    <asp:ListItem Value="17">17th</asp:ListItem>
                                                                    <asp:ListItem Value="18">18th</asp:ListItem>
                                                                    <asp:ListItem Value="19">19th</asp:ListItem>
                                                                    <asp:ListItem Value="20">20th</asp:ListItem>
                                                                    <asp:ListItem Value="21">21st</asp:ListItem>
                                                                    <asp:ListItem Value="22">22nd</asp:ListItem>
                                                                    <asp:ListItem Value="23">23rd</asp:ListItem>
                                                                    <asp:ListItem Value="24">24th</asp:ListItem>
                                                                    <asp:ListItem Value="25">25th</asp:ListItem>
                                                                    <asp:ListItem Value="26">26th</asp:ListItem>
                                                                    <asp:ListItem Value="27">27th</asp:ListItem>
                                                                    <asp:ListItem Value="28">28th</asp:ListItem>
                                                                </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 140px;">
                                                                    <asp:CheckBox ID="chkChart_SIP" runat="server" Style="padding-left: 10px"
                                                                        CssClass="graytxtbold01"
                                                                        Text="&nbsp; Show Graph"></asp:CheckBox>
                                                                </td>
                                                                <td>&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr class="row_altclr">
                                                                <td class="left_row">
                                                                    <asp:Label ID="Label14" runat="server" CssClass="txt2">
																			Date</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtfromDate" ToolTip="From Date" runat="server"
                                                                        CssClass="TextBox" Width="120px"></asp:TextBox>
                                                                    <!--start Syed-->
                                                                    <%--<a href="Javascript:ShowCalendars('document.forms(0).txtfromDate',1900,2015,'dd/mm/yyyy');"><img id="Img2" style="WIDTH: 17px; HEIGHT: 17px" height="17" src="images/calendor.gif"
																				width="17" align="middle" border="0"></a>--%>
                                                                    <!-- end syed -->
                                                                </td>
                                                                <%--<td style="WIDTH: 58px" valign="middle">
                                                                    <asp:Label ID="Label15" runat="server" CssClass="txt2">
																			To Date</asp:Label>
                                                                </td>--%>
                                                                <td>
                                                                    <asp:TextBox ID="txtTdate" runat="server" ToolTip="To Date"
                                                                        CssClass="TextBox" Width="110px"></asp:TextBox>
                                                                    <%--<a href="Javascript:ShowCalendars('document.forms(0).txtTdate',1900,2100,'dd/mm/yyyy');"><img id="Img1" style="WIDTH: 17px; HEIGHT: 17px" height="17" src="images/calendor.gif"
                                                                        width="17" align="middle"  border="0"></a>--%>
                                                                </td>
                                                                <td style="width:160px;">
                                                                    <%--<asp:Label ID="Label16" runat="server" CssClass="txt2">
																			Value as on Date</asp:Label>--%>
                                                                    <asp:TextBox ID="txtvalason" ToolTip="As on Date" runat="server"
                                                                        CssClass="TextBox" Width="130px" Font-Size="15px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <%--<a href="Javascript:ShowCalendars('document.forms(0).txtvalason',1900,2100,'dd/mm/yyyy');"><img id="Img3" style="WIDTH: 17px; HEIGHT: 17px" height="17" src="images/calendor.gif"
                                                                        width="17" align="middle" border="0"></a>--%>
                                                                </td>
                                                            </tr>

                                                            <tr class="row_altclr">
                                                                <td>&nbsp;</td>
                                                                <td colspan="4" valign="top">
                                                                    <asp:Label ID="Label44" runat="server" CssClass="txt1">* Enter date in DD/MM/YYYY format</asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table id="Table8" style="height: 70px" cellspacing="0"
                                                            cellpadding="0" width="100%" border="0">
                                                            <tr class="row_clr">
                                                                <td style="width: 22%;">&nbsp;</td>
                                                                <td style="width: 12%; padding-left: 15px">
                                                                    <%--<asp:Button ID="cmdSIP" runat="server"  Width="49px" Font-Size="11px"
                                                                    CssClass="bttn01" Text="Show"></asp:Button>--%>
                                                                    <asp:ImageButton ID="cmdSIP" runat="server" CssClass="button Save" 
                                                                        ImageUrl="images/show.jpg" />
                                                                </td>
                                                                <td style="width: 12%; padding-left: 15px">
                                                                    <%--<asp:Button ID="cmdrs1" runat="server"  Width="52px" Font-Size="11px"
                                                                    CssClass="bttn01" Text="Reset"></asp:Button>--%>
                                                                    <asp:ImageButton ID="cmdrs1" runat="server" CssClass="button"
                                                                        ImageUrl="images/reset.jpg" />
                                                                </td>
                                                                <td style="padding-left: 15px" class="Save">
                                                                    <%--<asp:Button ID="cmdexp" runat="server"  Width="48px" Font-Size="11px"
                                                                    CssClass="bttn01" Text="Save"></asp:Button>--%>
                                                                    <%--<asp:ImageButton ID="cmdexp" runat="server" CssClass="button"
                                                                        ImageUrl="images/save.jpg" />--%>
                                                                    <%--<div id="PDFSIP" runat="server" style="display:none">
                                                                           
                                                                    </div>--%>
                                                                </td>
                                                                <%--<td>
																		<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/btn-save.gif" />
																	</td>--%>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                
                                            </table>
                                            
                                            <table id="tblSTP" cellspacing="0" cellpadding="0"
                                                width="100%" border="0" runat="server">
                                                <tr>
                                                    <td>
                                                        <table id="Table11" cellspacing="0" cellpadding="0"
                                                            width="100%" bgcolor="#ffffff"
                                                            border="0">
                                                            <tr class="row_altclr">
                                                                <td class="left_row">
                                                                    <asp:Label ID="Label8" runat="server" CssClass="txt2">
																			Transfer From</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddtrfrom" runat="server" CssClass="select"
                                                                        AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr class="row_clr">
                                                                <td class="left_row">
                                                                    <asp:Label ID="Label9" runat="server" CssClass="txt2">
																			Transfer To</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddtrto" runat="server" CssClass="select"
                                                                        AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr class="row_altclr">
                                                                <td class="left_row">
                                                                    <asp:Label ID="Label10" runat="server" CssClass="txt2">
																			Benchmark</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddbnmark" runat="server" CssClass="select">
                                                                    </asp:DropDownList>
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                                <asp:DropDownList ID="ddbnmark1" runat="server" Visible="False"
                                                                    CssClass="plan_txtfield"
                                                                    AutoPostBack="True" BackColor="White">
                                                                </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table id="Table5" style="width: 100%; height: 48px"
                                                            cellspacing="0" cellpadding="0"
                                                            bgcolor="#ffffff" border="0">
                                                            <tr class="row_clr">
                                                                <td class="left_row">
                                                                    <asp:Label ID="Label5" runat="server" CssClass="txt2">
																			Initial Amount (&#x20B9;)</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtiniamt" runat="server" MaxLength="14"
                                                                        CssClass="TextBox"></asp:TextBox>
                                                                </td>
                                                                <td style="height: 10px" valign="top"></td>
                                                                <td></td>
                                                            </tr>
                                                            <tr class="row_altclr">
                                                                <td class="left_row">
                                                                    <asp:Label ID="Label7" runat="server" CssClass="txt2">
																			Transfer Amount (&#x20B9;)</asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <p>
                                                                        <asp:TextBox ID="txttranamt" runat="server" MaxLength="14"
                                                                            CssClass="TextBox"></asp:TextBox>
                                                                    </p>
                                                                </td>
                                                                <td style="width: 200px">
                                                                    <table id="Table12" cellspacing="0" cellpadding="0"
                                                                        width="180" border="0" runat="server">
                                                                        <tr>
                                                                            <td style="width: 90px">
                                                                                <asp:RadioButton ID="rbindivd" runat="server" CssClass="graytxtbold01"
                                                                                    Checked="True"
                                                                                    Text="Individual" GroupName="rbindivd" Visible="False">
                                                                                </asp:RadioButton>
                                                                            </td>
                                                                            <td style="width: 90px">
                                                                                <asp:RadioButton ID="rbcorp" runat="server" CssClass="graytxtbold01"
                                                                                    AutoPostBack="True"
                                                                                    Text="Corporate" GroupName="rbindivd" Visible="False">
                                                                                </asp:RadioButton>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td></td>
                                                            </tr>
                                                        </table>
                                                        <table id="Table10" cellspacing="0" cellpadding="0"
                                                            width="100%" bgcolor="#ffffff"
                                                            border="0">
                                                            <tr class="row_clr">
                                                                <td class="left_row">
                                                                    <asp:Label ID="Label2" runat="server" CssClass="txt2">
																			Date</asp:Label>
                                                                </td>
                                                                <td style="width: 133px" align="left">
                                                                    <asp:TextBox ID="txtfrdt" ToolTip="From Date" runat="server"
                                                                        AutoPostBack="True"
                                                                        CssClass="TextBox"></asp:TextBox>
                                                                    <%--&nbsp;<a href="Javascript:ShowCalendars('document.forms(0).txtfrdt',1900,2100,'dd/mm/yyyy');"><img id="Img4" style="WIDTH: 17px; HEIGHT: 17px" height="17" src="images/calendor.gif"
                                                                        width="17" align="middle" border="0"></a>--%>
                                                                </td>
                                                                <%-- <td style="WIDTH: 80px">
                                                                    <asp:Label ID="Label3" runat="server" CssClass="txt2">
																			To Date</asp:Label>
                                                                </td>--%>
                                                                <td style="width: 150px">
                                                                    <asp:TextBox ID="txttodt" ToolTip="To Date" runat="server"
                                                                        CssClass="TextBox"></asp:TextBox>
                                                                    <%--&nbsp;<a href="Javascript:ShowCalendars('document.forms(0).txttodt',1900,2100,'dd/mm/yyyy');"><img id="Img5" style="WIDTH: 17px; HEIGHT: 17px" height="17" src="images/calendor.gif"
                                                                        width="17" align="middle" border="0"></a>--%>
                                                                </td>
                                                                <%--<td style="WIDTH: 150px">
                                                                    <asp:Label ID="Label4" runat="server" CssClass="txt2">
																			Value As On Date</asp:Label>
                                                                </td>--%>
                                                                <td>
                                                                    <asp:TextBox ID="txtvalue" ToolTip="As On Date" runat="server"
                                                                        CssClass="TextBox"></asp:TextBox>
                                                                    <%--&nbsp;<a href="Javascript:ShowCalendars('document.forms(0).txtvalue',1900,2100,'dd/mm/yyyy');"><img id="Img6" style="WIDTH: 17px; HEIGHT: 17px" height="17" src="images/calendor.gif"
                                                                        width="17" align="middle" border="0"></a>--%>
                                                                </td>
                                                            </tr>
                                                            <tr class="row_altclr">
                                                                <td class="left_row">
                                                                    <asp:Label ID="Label6" runat="server" CssClass="txt2">
																			Period</asp:Label>
                                                                </td>
                                                                <td style="width: 190px" align="left">
                                                                    <asp:DropDownList ID="ddperiod" runat="server" CssClass="select"
                                                                        AutoPostBack="True">
                                                                        <asp:ListItem Value="0">--</asp:ListItem>
                                                                        <asp:ListItem Value="1">Weekly</asp:ListItem>
                                                                        <asp:ListItem Value="2">Fortnightly</asp:ListItem>
                                                                        <asp:ListItem Value="3">Monthly</asp:ListItem>
                                                                        <asp:ListItem Value="4">Quarterly</asp:ListItem>
                                                                        <asp:ListItem Value="5">Daily</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <%--<td style="WIDTH: 55px"></td>--%>
                                                                <td style="width: 150px">
                                                                    <asp:CheckBox ID="chkChart_STP" runat="server" CssClass="graytxtbold01"
                                                                        Text="&nbsp;Show Graph"></asp:CheckBox>
                                                                </td>
                                                                <%--<td style="WIDTH: 81px"></td>--%>
                                                                <td></td>
                                                            </tr>
                                                            <tr class="row_clr" id="tr_STPdate" name="tr_STPdate"
                                                                runat="server">
                                                                <td class="left_row">
                                                                    <asp:Label ID="Label36" runat="server" CssClass="txt2">
																			STP Date</asp:Label>
                                                                </td>
                                                                <td style="width: 133px" align="left">
                                                                    <asp:DropDownList ID="ddSTPDate" runat="server" CssClass="select"
                                                                        Enabled="false">
                                                                        <asp:ListItem Value="0">02nd</asp:ListItem>
                                                                        <asp:ListItem Value="1">10th</asp:ListItem>
                                                                        <asp:ListItem Value="2">20th</asp:ListItem>
                                                                        <asp:ListItem Value="3">28th</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:DropDownList ID="STPdt" runat="server" Width="50px"
                                                                        CssClass="select">
                                                                        <asp:ListItem Value="0">02nd</asp:ListItem>
                                                                        <asp:ListItem Value="1">10th</asp:ListItem>
                                                                        <asp:ListItem Value="2">20th</asp:ListItem>
                                                                        <asp:ListItem Value="3">28th</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td colspan="2"></td>
                                                            </tr>
                                                        </table>
                                                        <table id="Table9" cellspacing="0" cellpadding="0"
                                                            width="100%" bgcolor="#ffffff"
                                                            border="0">
                                                            <tr class="row_altclr">
                                                                <td class="left_row" style="width: 280px">
                                                                    <asp:RadioButton ID="rbfixed" runat="server" Visible="True"
                                                                        CssClass="txt2" AutoPostBack="True"
                                                                        Checked="True" Text="&nbsp;Fixed Systematic Transfer Plan"
                                                                        GroupName="rbfixed"></asp:RadioButton>
                                                                </td>
                                                                <td>
                                                                    <asp:RadioButton ID="rbcapital" runat="server" CssClass="txt2"
                                                                        AutoPostBack="True"
                                                                        Text="&nbsp;Capital Appreciation Systematic Transfer Plan"
                                                                        GroupName="rbfixed"></asp:RadioButton>
                                                                </td>
                                                            </tr>
                                                            <tr class="row_clr">
                                                                <td class="left_row" style="width: 250px">
                                                                    <asp:Label ID="Label45" runat="server" CssClass="txt1">* Enter date in DD/MM/YYYY format</asp:Label>
                                                                </td>
                                                                <td>&nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <%--  <table id="Table19" cellspacing="1" cellpadding="1" width="100%" border="0">
                                                            <tr>
                                                                <td style="WIDTH: 802px" bgcolor="#ffffff">
                                                                    
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="linedotted01" colspan="3">
                                                                    <img alt="" src="images/blank_space.gif">
                                                                </td>
                                                            </tr>
                                                        </table>--%>
                                                        <table id="Table13" cellspacing="0" cellpadding="0"
                                                            width="100%" border="0" style="height: 70px">
                                                            <tr class="row_altclr">
                                                                <td style="width: 22%;">&nbsp;</td>
                                                                <td style="padding-left: 15px; width: 12%">
                                                                    <%--<asp:Button ID="cmdSTP" runat="server"  Width="49px" Font-Size="11px"
                                                                    CssClass="bttn01" Text="Show"></asp:Button>--%>
                                                                    <asp:ImageButton ID="cmdSTP" runat="server" CssClass="button Save"
                                                                        ImageUrl="images/show.jpg" />
                                                                </td>
                                                                <td style="padding-left: 15px; width: 12%">
                                                                    <%--<asp:Button ID="cmdreset" runat="server"  Width="48px" Font-Size="11px"
                                                                    CssClass="bttn01" Text="Reset"></asp:Button>--%>
                                                                    <asp:ImageButton ID="cmdreset" runat="server" CssClass="button"
                                                                        ImageUrl="images/reset.jpg" />
                                                                </td>
                                                                <td style="padding-left: 15px" class="Save">
                                                                    <%--<asp:Button ID="cmdexp1" runat="server"  Width="56px" Font-Size="11px"
                                                                    CssClass="bttn01" Text="Save"></asp:Button>--%>
                                                                    <%--<asp:ImageButton ID="cmdexp1" runat="server" CssClass="button"
                                                                        ImageUrl="images/save.jpg" />--%>
                                                                    
                                                                </td>
                                                                <td style="padding-left: 15px">
                                                                    <asp:Button ID="cmdcalc" runat="server" Width="64px"
                                                                        Font-Size="11px" Visible="False"
                                                                        CssClass="bttn01" Text="Calculation"></asp:Button>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <!-- Manish For Returns -->
                                            <table id="CalReturn" cellspacing="0" cellpadding="0"
                                                width="100%" border="0" runat="server">
                                                <tr>
                                                    <td>
                                                        <table id="Table61" cellspacing="0" cellpadding="0"
                                                            width="100%" bgcolor="#ffffff"
                                                            border="0">
                                                            <tr class="row_altclr">
                                                                <td class="left_row">
                                                                    <asp:Label ID="Label38" runat="server" CssClass="txt2">
																			Scheme</asp:Label>
                                                                </td>
                                                                <td style="width: 369px">
                                                                    <asp:DropDownList ID="ddRetscname" runat="server" CssClass="select"
                                                                        AutoPostBack="True"
                                                                        Style="width: 400px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td valign="middle">&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr class="row_clr">
                                                                <td class="left_row">
                                                                    <asp:Label ID="Label39" runat="server" CssClass="txt2">
																			Benchmark</asp:Label>
                                                                </td>
                                                                <td style="width: 369px; height: 19px" valign="middle">
                                                                    <asp:DropDownList ID="ddRetbnmark" runat="server" CssClass="select"
                                                                        AutoPostBack="True"
                                                                        Style="width: 400px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="height: 19px">
                                                                    <asp:DropDownList ID="ddRetbnmark1" runat="server"
                                                                        Visible="False" CssClass="select"
                                                                        AutoPostBack="True" BackColor="White">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr class="row_altclr">
                                                                <td class="left_row">
                                                                    <asp:Label ID="Label40" runat="server" CssClass="txt2">
																			Investment Amount (&#x20B9;)</asp:Label>
                                                                </td>
                                                                <td style="width: 369px">
                                                                    <asp:TextBox ID="txtRetInsAmt" runat="server" MaxLength="14"
                                                                        CssClass="TextBox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                    &nbsp;<asp:Label ID="Label43" runat="server" Visible="False"
                                                                        CssClass="txt2">Entry 
																				Load</asp:Label>&nbsp;<asp:TextBox ID="Textbox2" runat="server"
                                                                                    Visible="False" MaxLength="14"
                                                                                    CssClass="TextBox"></asp:TextBox>
                                                                </td>
                                                                <td>&nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table id="Table14" cellspacing="0" cellpadding="0"
                                                            width="100%" bgcolor="#ffffff"
                                                            border="0">
                                                            <tr class="row_clr">
                                                                <td class="left_row">
                                                                    <asp:Label ID="Label48" runat="server" CssClass="txt2">
																			Date</asp:Label>
                                                                </td>
                                                                <td style="width: 148px">
                                                                    <asp:TextBox ID="txtRetFdt" ToolTip="From Date" runat="server"
                                                                        CssClass="TextBox"></asp:TextBox>

                                                                </td>
                                                                <td style="width: 58px" valign="middle"></td>
                                                                <td style="width: 156px">
                                                                    <asp:TextBox ID="txtRetTodt" ToolTip="To Date" runat="server"
                                                                        CssClass="TextBox"></asp:TextBox>

                                                                </td>
                                                                <td style="width: 30px"></td>
                                                                <td></td>
                                                            </tr>
                                                            <tr class="row_clr">
                                                                <td class="left_row"></td>
                                                                <td colspan="5">
                                                                    <asp:Label ID="Label51" runat="server" CssClass="txt1">* Enter date in DD/MM/YYYY format</asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table id="Table15" width="100%" cellspacing="0" cellpadding="0"
                                                            border="0" style="height: 70px">
                                                            <tr class="row_altclr">
                                                                <td style="width: 22%;">&nbsp;</td>
                                                                <td style="width: 12%; padding-left: 15px">
                                                                    <asp:ImageButton ID="cmdReturn" runat="server" CssClass="button Save"
                                                                        ImageUrl="images/show.jpg" />
                                                                </td>
                                                                <td style="width: 12%; padding-left: 15px">
                                                                    <asp:ImageButton ID="btnRetReset" runat="server" CssClass="button"
                                                                        ImageUrl="images/reset.jpg" />
                                                                </td>
                                                                <td style="padding-left: 15px">
                                                                    <%--<asp:ImageButton ID="btnRetExport" runat="server" CssClass="button"
                                                                        ImageUrl="images/save.jpg" />--%>
                                                                    
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <!-- END Of Returns -->
                                            <!--chart table -->
                                            <table id="tblChart" style="width: 100%; height: 57px"
                                                cellspacing="0" cellpadding="0"
                                                width="100%" bgcolor="#ffffff" border="0" runat="server">
                                                <%--<tr class="row_clr">
                                                    <td style="width: 15px">&nbsp;
                                                    </td>
                                                    <td>
                                                        <web:ChartControl ID="sipChart" runat="server" alt="Reliance SIP Calculator Chart" Width="99%" Height="350" BorderStyle="None"
                                                            BorderWidth="5px">
                                                            <XTitle StringFormat="Center,Near,Character,LineLimit"></XTitle>
                                                            <YAxisFont StringFormat="Far,Near,Character,FitBlackBox"></YAxisFont>
                                                            <ChartTitle StringFormat="Center,Near,Character,LineLimit"></ChartTitle>
                                                            <XAxisFont StringFormat="Near,Near,Character,LineLimit"></XAxisFont>
                                                            <Background Color="#eaedf2"></Background>
                                                            <YTitle StringFormat="Center,Near,Character,LineLimit"></YTitle>
                                                            <PlotBackground Color="#e2e5ea" />
                                                        </web:ChartControl>
                                                    </td>
                                                    <td style="width: 15px"></td>
                                                </tr>--%>
                                                <tr class="row_clr">
                                                    <td style="width: 15px">&nbsp;
                                                    </td>
                                                    <td style="padding-top: 30px">
                                                        <div style="background: #e2e5ea; padding: 10px">
                                                            <div id="dvChartNew" style="width: 99%; height: 350px;
                                                                background: #e2e5ea; padding: 10px">
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td style="width: 15px">&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                            <!--End chart table -->
                                        </td>
                                    </tr>
                                </table>
                                <table id="tblSTP1" cellspacing="0" cellpadding="0"
                                    width="100%" border="0" runat="server">
                                    <tr>
                                        <td class="row_clr" style="padding: 15px">
                                            <asp:Label ID="L1" runat="server" CssClass="txt2">
										<b>Transfer From</b></asp:Label>
                                            <div class="divclass" id="Div1" style="overflow: auto;
                                                width: 100%;">
                                                <div style="float:right; margin-bottom:10px;">
                                                    <ul style="display:inline-flex">
                                                        <li>
                                                            <%--<a href="#" style="margin-right:8px;"><img src="Images/excel.svg" style="width:20px" /></a>--%> <%--style="margin-right:8px;" Width ="20px"--%> 
                                                            <asp:ImageButton ID="cmdexp1" runat="server" style="width:20px;border-width:0px;margin-right:8px;margin-top: 2px;"
                                                                        ImageUrl="Images/excel.svg" cssClass ="Save"/>
                                                        </li>
                                                        <li>
                                                            <%--<a href="#"><img src="Images/pdf.svg" style="width:20px" /></a>--%>
                                                            <%--<button type="button" id="btnExportPdfSTP" style="border:none"><img src="Images/pdf.svg" style="width:20px;" /></button>--%>
                                                            <button type="button" id="btnExportPdfSTP" class="Save" style="border:none;background: transparent;"><img src="Images/pdf.svg" style="width:17px;height: 16px;"></button>

                                                        </li>
                                                    </ul>
     
                                                </div>
                                                <asp:DataGrid ID="Dstp" CssClass="GridTable" runat="server"
                                                    CellSpacing="0" CellPadding="0"
                                                    Width="940px" Font-Size="11px" ForeColor="#004000"
                                                    Visible="False" BackColor="White"
                                                    ItemStyle-CssClass="grdRow" BorderWidth="0">
                                                    <HeaderStyle CssClass="grdHead"></HeaderStyle>
                                                </asp:DataGrid>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr class="row_clr">
                                        <td class="row_clr" style="padding: 15px">
                                            <asp:Label ID="L2" runat="server" CssClass="txt2">
										<b>Transfer To</b></asp:Label>
                                            <div class="divclass" id="Div2" style="overflow: auto;
                                                width: 100%;">
                                                <asp:DataGrid ID="Dstp1" CssClass="GridTable" runat="server"
                                                    CellSpacing="0" CellPadding="0"
                                                    Width="940px" Font-Size="11px" ForeColor="#004000"
                                                    Visible="False" BackColor="White"
                                                    ItemStyle-CssClass="grdRow" BorderWidth="0">
                                                    <HeaderStyle CssClass="grdHead"></HeaderStyle>
                                                </asp:DataGrid>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table id="Table16" style="width: 100%; height: 97px"
                                                cellspacing="0" cellpadding="0"
                                                bgcolor="#ffffff" border="0">
                                                <tr class="row_clr">
                                                    <td class="returnTdLeft" style="width: 50%">
                                                        <asp:Label ID="Label20" runat="server">Value of balance units in transferor scheme</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtbal" runat="server" CssClass="TextBox"
                                                            ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr class="row_clr">
                                                    <td class="returnTdLeft" style="width: 50%">
                                                        <asp:Label ID="Label19" runat="server">Value of Accumulated units in transferee scheme</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtacc" runat="server" CssClass="TextBox"
                                                            ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr class="row_clr">
                                                    <td class="returnTdLeft" style="width: 50%">
                                                        <asp:Label ID="Label21" runat="server">
													Hence Yield from STP investment is (%)</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtyield" runat="server" CssClass="TextBox"
                                                            ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr class="row_clr">
                                                    <td class="returnTdLeft" style="width: 50%">
                                                        <asp:Label ID="Label22" runat="server" Visible="False">
													Hence Yield from one time investment is (%)</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtyldinv" runat="server" Visible="False"
                                                            ReadOnly="True" CssClass="TextBox"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr class="row_clr">
                                                    <td class="returnTdLeft" colspan="2" id="PStpDisclamer"
                                                        runat="server" style="font-size: 12px; padding-top: 10px;
                                                        padding-right: 10px; padding-bottom: 10px"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <table id="tblSIP1" cellspacing="0" cellpadding="0"
                                    width="100%" border="0" runat="server">
                                    <tr class="row_clr">
                                        <%--<td style="width:15px">
                                            &nbsp;
                                        </td>--%>
                                        <td style="padding: 15px">
                                            <div class="divclass" id="dsp" style="overflow: auto;">
                                                <div style="float:right; margin-bottom:10px;">
                                                    <ul style="display:inline-flex">
                                                        <li>
                                                            <%--<a href="#" style="margin-right:8px;"><img src="Images/excel.svg" style="width:20px" /></a>--%>  <%--style="margin-right:8px;" Width ="20px"--%>
                                                            <asp:ImageButton ID="cmdexp" runat="server" style="width:20px;border-width:0px;margin-right:8px;margin-top: 2px;"
                                                                        ImageUrl="Images/excel.svg" cssClass="Save"/>
                                                        </li>
                                                        <li>
                                                            <%--<a href="#"><img src="Images/pdf.svg" style="width:20px" /></a>--%>
                                                            <%--<button type="button" id="btnExportPdfSIP" style="border:none"><img src="Images/pdf.svg" style="width:20px;" /></button>--%>
                                                            <button type="button" id="btnExportPdfSIP" class="Save" style="border:none;background: transparent;"><img src="Images/pdf.svg" style="width:17px;height: 16px;"></button>
                                                        </li>
                                                    </ul>
     
                                                </div>
                                                <asp:DataGrid CssClass="GridTable" runat="server" CellSpacing="0"
                                                    CellPadding="0"
                                                    Width="950px" Font-Size="11px" ForeColor="#004000"
                                                    Visible="False" BackColor="White"
                                                    ItemStyle-CssClass="grdRow" BorderWidth="0" ID="Gsp">
                                                    <%--<ItemStyle CssClass="grdRow" />--%>
                                                    <HeaderStyle CssClass="grdHead"></HeaderStyle>
                                                </asp:DataGrid>
                                            </div>
                                            
                                        </td>
                                        <%--<td style="width:15px">
                                            &nbsp;
                                        </td>--%>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table id="Table17" style="width: 100%; height: 73px"
                                                cellspacing="0" cellpadding="0"
                                                width="200" bgcolor="#ffffff" border="0">
                                                <tr class="row_clr" style="display: none">
                                                    <td class="returnTdLeft">
                                                        <asp:Label ID="Label23" runat="server">	Abs. Return (Scheme)</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtonttm" runat="server" CssClass="TextBox"
                                                            ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr class="row_clr">
                                                    <td class="returnTdLeft">
                                                        <asp:Label ID="Label17" runat="server">Yield (Scheme)</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtxsch" runat="server" CssClass="TextBox"
                                                            ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr class="row_clr">
                                                    <td class="returnTdLeft">
                                                        <asp:Label ID="Label18" runat="server">Yield (Index)</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtxind" runat="server" CssClass="TextBox"
                                                            ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr class="row_clr">
                                                    <td colspan="2" class="returnTdLeft" style="font-size: 12px;
                                                        padding-top: 10px; padding-right: 5px; padding-bottom: 10px"
                                                        id="PSipDisclamer" runat="server"></td>
                                                </tr>
                                            </table>
                                            
                                        </td>
                                    </tr>
                                </table>
                                <table id="tblSWP1" style="width: 100%; height: 205px"
                                    cellspacing="0" cellpadding="0"
                                    width="950px" border="0" runat="server">
                                    <tr class="row_clr">
                                        <td style="padding: 15px">
                                            <div class="divclass" id="Div3" style="overflow: auto;">
                                                <div style="float:right; margin-bottom:10px;">
                                                    <ul style="display:inline-flex">
                                                        <li>
                                                            <%--<a href="#" style="margin-right:8px;"><img src="Images/excel.svg" style="width:20px" /></a>--%>  <%--style="margin-right:8px;" Width ="20px"--%>
                                                            <asp:ImageButton ID="btnwexport" runat="server" style="width:20px;border-width:0px;margin-right:8px;margin-top: 2px;"
                                                                        ImageUrl="Images/excel.svg" cssClass ="Save"/>
                                                        </li>
                                                        <li>
                                                            <%--<button type="button" id="btnExportPdf" style="border:none"><img src="Images/pdf.svg" style="width:20px;" /></button>--%>
                                                            <button type="button" id="btnExportPdf" class="Save" style="border:none;background: transparent;"><img src="Images/pdf.svg" style="width:17px;height: 16px;"></button>
                                                            <%--<asp:ImageButton ID="btnExportPdf" runat="server" style="margin-right:8px;" Width ="20px"
                                                                        ImageUrl="Images/pdf.svg" />--%>
                                                            <%--<input type="image" name="btnExportPdf" id="btnExportPdf" src="Images/pdf.svg" style="width:20px;border-width:0px;margin-right:8px;">--%>
                                                        </li>
                                                    </ul>
     
                                                </div>
                                                <asp:DataGrid ID="Dgswp" CssClass="GridTable" runat="server"
                                                    CellSpacing="0" CellPadding="0"
                                                    Width="950px" Font-Size="11px" ForeColor="#004000"
                                                    Visible="False" BackColor="White" HeaderStyle-BackColor="Red"
                                                    ItemStyle-CssClass="grdRow" BorderWidth="0">
                                                    <%--<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#951E22"></HeaderStyle>--%>
                                                    <%--<ItemStyle CssClass="grdRow" />--%>
                                                    <HeaderStyle CssClass="grdSWPHead"></HeaderStyle>
                                                </asp:DataGrid>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table id="Table19" style="height: 57px" cellspacing="0"
                                                cellpadding="0" width="100%" bgcolor="#ffffff"
                                                border="0">
                                                <tr class="row_clr" style="display: none">
                                                    <td class="returnTdLeft">
                                                        <asp:Label ID="Label42" runat="server">
													Abs. Return(Scheme)</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtwAbsRet" runat="server" CssClass="TextBox"
                                                            ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr class="row_clr">
                                                    <td class="returnTdLeft">
                                                        <asp:Label ID="Label33" runat="server">Yield (Scheme) </asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtwyield" runat="server" CssClass="TextBox"
                                                            ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr class="row_clr">
                                                    <td colspan="2" class="returnTdLeft" style="font-size: 12px;
                                                        padding-top: 10px; padding-right: 10px; padding-bottom: 10px"
                                                        id="PSwpDisclamer" runat="server"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <!--Manish For Return Grid-->
                                <table id="CalReturn1" cellspacing="0" cellpadding="0"
                                    width="100%" border="0" runat="server">
                                    <tr class="row_clr">
                                        <td style="padding: 15px">
                                            <div class="divclass" id="Div4" style="overflow: auto;
                                                width: 100%;">
                                                <div style="float:right; margin-bottom:10px;">
                                                    <ul style="display:inline-flex">
                                                        <li>
                                                            <%--<a href="#" style="margin-right:8px;"><img src="Images/excel.svg" style="width:20px" /></a>--%> <%--style="margin-right:8px;" Width ="20px"--%>
                                                            <asp:ImageButton ID="btnRetExport" runat="server"  style="width:20px;border-width:0px;margin-right:8px;margin-top: 2px;"
                                                                        ImageUrl="Images/excel.svg" cssClass="Save"/>
                                                        </li>
                                                        <li>
                                                            <%--<a href="#"><img src="Images/pdf.svg" style="width:20px" /></a>--%>
                                                            <%--<button type="button" id="btnExportPdfLUMPSUM" style="border:none"><img src="Images/pdf.svg" style="width:20px;" /></button>--%>
                                                            <button type="button" id="btnExportPdfLUMPSUM" class="Save" style="border:none;background: transparent;"><img src="Images/pdf.svg" style="width:17px;height: 16px;"></button>
                                                        </li>
                                                    </ul>
     
                                                </div>
                                                <asp:DataGrid ID="DgReturn" CssClass="GridTable" runat="server"
                                                    CellSpacing="0" CellPadding="0"
                                                    Width="950px" Font-Size="11px" ForeColor="#004000"
                                                    Visible="False" BackColor="White"
                                                    ItemStyle-CssClass="grdRow" BorderWidth="0">
                                                    <HeaderStyle CssClass="grdHead"></HeaderStyle>
                                                </asp:DataGrid>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr class="row_clr">
                                        <td style="height: 76px">
                                            <table id="Table22" style="width: 100%; height: 57px"
                                                cellspacing="0" cellpadding="0"
                                                border="0">
                                                <tr class="row_clr">
                                                    <td class="returnTdLeft">
                                                        <asp:Label ID="Label53" runat="server">
													Scheme Dates</asp:Label>
                                                    </td>
                                                    <td style="width: 93px">
                                                        <asp:Label ID="lblschdt1" runat="server" CssClass="txt2"></asp:Label>
                                                    </td>
                                                    <td style="width: 9px">
                                                        <asp:Label ID="Label54" runat="server" CssClass="txt2">&</asp:Label>
                                                    </td>
                                                    <td style="width: 150px">
                                                        <asp:Label ID="lblschdt2" runat="server" CssClass="txt2"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="row_clr">
                                                    <td class="returnTdLeft">
                                                        <asp:Label ID="Label52" runat="server"> Index Dates</asp:Label>
                                                    </td>
                                                    <td style="width: 93px">
                                                        <asp:Label ID="lblinddt1" runat="server" CssClass="txt2"></asp:Label>
                                                    </td>
                                                    <td style="width: 9px">
                                                        <asp:Label ID="Label55" runat="server" CssClass="txt2">&</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblinddt2" runat="server" CssClass="txt2"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:Label ID="Label56" Style="padding-left: 15px"
                                                runat="server" CssClass="txt1">
										<b>Note : - For < 1 Year Return Type is Absolut and >= 1 Year Compound Annualized</b></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="row_clr">
                                        <td></td>
                                    </tr>
                                </table>
                                <!--END  Return Grid-->
                            </td>
                        </tr>
                        <!--footer start-->
                        <tr>
                            <td>
                                <table class="" cellspacing="0" cellpadding="0" width="950px"
                                    align="center" border="0" style="width: 950px !important">
                                    <tr>
                                        <td colspan="2">
                                            <table cellspacing="0" cellpadding="0" width="950px"
                                                border="0">
                                                <tr>
                                                    <td class="txt2" style="font-size: 12px; text-align: justify;
                                                        line-height: 16px;">Copyright 2017 Nippon India Mutual
                                                        Fund. All Rights Reserved.
                                                    </td>
                                                    <td class="txt2">
                                                        <!--Developed by <a href="http://www.icraonline.com" target="_blank" style="COLOR: #939498">
												ICRA Online Ltd.</a>-->
                                                    </td>
                                                </tr>
                                            </table>
                                            <table cellspacing="0" cellpadding="0" width="100%"
                                                align="center" border="0">
                                                <tr>
                                                    <td style="font-size: 12px; text-align: justify; color: #939498;
                                                        line-height: 16px;">
                                                        <p>
                                                            Nippon India Mutual Fund does not take the responsibility,
                                                            liability and undertake the
                                                        authenticity of the figures calculated on the basis of
                                                            calculator provided herein
                                                        for calculations towards prospective investments.Developed
                                                            and Maintained by <a href="http://www.icraanalytics.com"
                                                                target="_blank" style="color: #939498"><b>ICRA Analytics Limited</b></a> The data
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
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="plotted_image_div" class="" style="display: none;"
                                    runat="server">
                                </div>
                                <input id="HdGraphImgPath" value="0" runat="server"
                                    type="hidden" />
                                <input type="hidden" value="0" id="hdIsGraphExist"
                                    runat="server" />
                                <input type="hidden" value="0" id="hdIEVersion" runat="server" />
                            </td>
                        </tr>

                        <!--footer end-->
                        <!--Disclaimer start-->
                        <!--Disclaimer End-->
                    </table>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <div class="SiteFooter">
                        <section class=" no-mb" id="Important_Links">
                                    <div class="container">
                                        <div class="row showcase">
                                            <div class="col-md-12 col-sm-12">
                                                <div class="text-center">
                                                    <h1 class="default-color imp_link">Important Links</h1><br/><br/>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row hidden-xs">

                                            <div class="col-md-2 col-sm-2">
                                                <h3> Innovative Products </h3>
                                                <ul class="list-style-none cl-effect-4">
                                                    <li>
                                                        <a href="/investor-services/innovative-products/reliance-any-time-money-card">Reliance
                                                            Any Time Money Card</a>
                                                    </li>
                                                    <li>
                                                        <a href="/investor-services/innovative-products/reliance-salary-addvantage">Reliance
                                                            Salary Addvantage</a>
                                                    </li>
                                                    <li>
                                                        <a href="/investor-services/innovative-products/reliance-sip-insure">Reliance
                                                            SIP Insure</a>
                                                    </li>
                                                    <li>
                                                        <a href="/investor-services/innovative-products/reliance-smart-step">Reliance
                                                            Smart STeP</a>
                                                    </li>
                                                    <li>
                                                        <a href="/learn-and-invest/simply-save">Simply Save</a>
                                                    </li>
                                                </ul>
                                            </div>
                                            <div class="col-md-2 col-sm-2">
                                                <h3> Knowledge Center </h3>
                                                <ul class="list-style-none cl-effect-4">
                                                    <li>
                                                        <a href="/mutual-fund-articles">Mutual Fund Articles</a>
                                                    </li>
                                                    <li>
                                                        <a href="/learn-and-invest/updates-insights/tax-rate">Tax
                                                            Rate</a>
                                                    </li>
                                                    <li>
                                                        <a href="/learn-and-invest/updates-insights/whats-new">What’s
                                                            New</a>
                                                    </li>
                                                    <li>
                                                        <a href="/learn-and-invest/video-tutorials">e-Learning
                                                            courses</a>
                                                    </li>
                                                </ul>
                                            </div>
                                            <div class="col-md-2 col-sm-2">
                                                <h3> Transact Online </h3>
                                                <ul class="list-style-none cl-effect-4">
                                                    <li>
                                                        <a href="/transact-online/transact">Transact</a>
                                                    </li>
                                                    <li>
                                                        <a href="/transact-online/ways-to-transact">Ways To Transact</a>
                                                    </li>
                                                </ul>
                                            </div>

                                            <div class="col-md-2 col-sm-2">
                                                <h3> Investor Center </h3>
                                                <ul class="list-style-none cl-effect-4">
                                                    <li>
                                                        <a href="/funds-performance/track-fund">Track Funds</a>
                                                    </li>
                                                    <li>
                                                        <a href="/investor-services/downloads/forms">Download Forms</a>
                                                    </li>
                                                    <li>
                                                        <a href="/investor-services/trade-data">Trade Data</a>
                                                    </li>
                                                    <li>
                                                        <a href="https://investeasy.reliancemutual.com/online/accountmgmt/mailbacksoa">Get
                                                            Account Statements</a>
                                                    </li>
                                                    <li>
                                                        <a href="https://investeasy.reliancemutual.com/Online/Account/TrackTransactionoutside">Track
                                                            Your Transactions</a>
                                                    </li>
                                                    <li>
                                                        <a href="/investor-services/nri-centre">NRI Center</a>
                                                    </li>
                                                    <li>
                                                        <a href="https://www.sebi.gov.in">SEBI</a>
                                                    </li>
                                                    <li>
                                                        <a href="https://www.amfiindia.com/">AMFI</a>
                                                    </li>
                                                    <li>
                                                        <a href="/Documents/Update-on-RHF-and-RCF-rating-actions-and-its-impact.pdf" target="_blank">Update on RHF &amp; RCF rating action and it’s impact</a>
                                                    </li>
                                                    <li>
                                                        <a href="/Documents/DHFLUpdateNote.pdf" target="_blank">Update on DHFL</a>
                                                    </li>
                            <li>
                                                        <a href="/Documents/SegregationPressrelease1.pdf" target="_blank">Update on Nippon India Ultra Short Duration Fund</a>
                                                    </li>
                            <li>
                                                        <a href="/Documents/SegregationPressRelease2.pdf" target="_blank">Nippon India Ultra Short Duration Fund (Segregation of Portfolio)</a>
                                                    </li>
                                                </ul>
                                            </div>

                                            <div class="col-md-2 col-sm-2">
                                                <h3> About Us </h3>
                                                <ul class="list-style-none cl-effect-4">
                                                    <li>
                                                        <a href="/about-us/company-profile/reliance-mutual-fund">The
                                                            Company</a>
                                                    </li>
                                                    <li>
                                                        <a href="/career/why-choose-us">Careers</a>
                                                    </li>
                                                    <li>
                                                        <a href="/about-us/voting-policy">Voting Policy</a>
                                                    </li>
                                                    <li>
                                                        <a href="/investor-service/customer-service/rnam-shareholders-investors">RNAM
                                                            Shareholders/Investors</a>
                                                    </li>
                                                    <li>
                                                        <a href="https://www.reliancemutual.com/Pages/ExecutiveRemuneration.aspx">Remuneration</a>
                                                    </li>
                                                </ul>
                                            </div>

                                            <div class="col-md-2 col-sm-2">
                                                <h3> Customer Service </h3>
                                                <ul class="list-style-none cl-effect-4">
                                                    <li>
                                                        <a href="/investor-services/customer-service/locate-a-branch">Locate
                                                            a Branch</a>
                                                    </li>
                                                    <li>
                                                        <a href="/investor-services/customer-service/locate-an-advisor">Locate
                                                            an Advisor</a>
                                                    </li>
                                                    <li>
                                                        <a href="/investor-service/customer-service/non-transaction-days">Non
                                                            Transaction Days</a>
                                                    </li>
                                                    <li>
                                                        <a href="/investor-service/downloads/annual-half-yearly-reports">Annual
                                                            Reports</a>
                                                    </li>
                                                    <li>
                                                        <a href="/investor-services/downloads/total-expense-ratio-of-mutual-fund-schemes">Total
                                                            Expense Ratio of Mutual Fund Schemes</a>
                                                    </li>
                                                </ul>
                                            </div>

                                        </div>
                                        <div class="row visible-xs">

                                            <div class="col-xs-12">
                                                <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                                                    <div class="panel panel-default">
                                                        <div class="panel-heading" role="tab" id="headingOne">
                                                            <h4 class="panel-title">
                                                                <a role="button" data-toggle="collapse" data-parent="#accordion" href="#dvInnovative" products="" aria-expanded="false" aria-controls="collapseOne" class="collapsed">Innovative Products <i class="more-less glyphicon glyphicon-plus"></i>
                                                                </a>
                                                                <div id="dvInnovative" products="" class="panel-collapse collapse " role="tabpanel" aria-labelledby="headingOne" aria-expanded="true">
                                                                    <div class="panel-body" style="margin-bottom:0px">
                                                                        <ul class="list-style-none cl-effect-4">
                                                                            <li>
                                                                                <a href="/investor-services/innovative-products/reliance-any-time-money-card">Reliance
                                                                                    Any Time Money Card</a>
                                                                            </li>
                                                                            <li>
                                                                                <a href="/investor-services/innovative-products/reliance-salary-addvantage">Reliance
                                                                                    Salary Addvantage</a>
                                                                            </li>
                                                                            <li>
                                                                                <a href="/investor-services/innovative-products/reliance-sip-insure">Reliance
                                                                                    SIP Insure</a>
                                                                            </li>
                                                                            <li>
                                                                                <a href="/investor-services/innovative-products/reliance-smart-step">Reliance
                                                                                    Smart STeP</a>
                                                                            </li>
                                                                            <li>
                                                                                <a href="/learn-and-invest/simply-save">Simply
                                                                                    Save</a>
                                                                            </li>
                                                                        </ul>
                                                                    </div>
                                                                </div>
                                                            </h4>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-xs-12">
                                                <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                                                    <div class="panel panel-default">
                                                        <div class="panel-heading" role="tab" id="headingOne">
                                                            <h4 class="panel-title">
                                                                <a role="button" data-toggle="collapse" data-parent="#accordion" href="#dvKnowledge" center="" aria-expanded="false" aria-controls="collapseOne" class="collapsed">Knowledge Center <i class="more-less glyphicon glyphicon-plus"></i>
                                                                </a>
                                                                <div id="dvKnowledge" center="" class="panel-collapse collapse " role="tabpanel" aria-labelledby="headingOne" aria-expanded="true">
                                                                    <div class="panel-body" style="margin-bottom:0px">
                                                                        <ul class="list-style-none cl-effect-4">
                                                                            <li>
                                                                                <a href="/mutual-fund-articles">Mutual
                                                                                    Fund Articles</a>
                                                                            </li>
                                                                            <li>
                                                                                <a href="/learn-and-invest/updates-insights/tax-rate">Tax
                                                                                    Rate</a>
                                                                            </li>
                                                                            <li>
                                                                                <a href="/learn-and-invest/updates-insights/whats-new">What’s
                                                                                    New</a>
                                                                            </li>
                                                                            <li>
                                                                                <a href="/learn-and-invest/video-tutorials">e-Learning
                                                                                    courses</a>
                                                                            </li>
                                                                        </ul>
                                                                    </div>
                                                                </div>
                                                            </h4>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-xs-12">
                                                <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                                                    <div class="panel panel-default">
                                                        <div class="panel-heading" role="tab" id="headingOne">
                                                            <h4 class="panel-title">
                                                                <a role="button" data-toggle="collapse" data-parent="#accordion" href="#dvTransact" online="" aria-expanded="false" aria-controls="collapseOne" class="collapsed">Transact Online <i class="more-less glyphicon glyphicon-plus"></i></a>
                                                                <div id="dvTransact" online="" class="panel-collapse collapse " role="tabpanel" aria-labelledby="headingOne" aria-expanded="true">
                                                                    <div class="panel-body" style="margin-bottom:0px">
                                                                        <ul class="list-style-none cl-effect-4">
                                                                            <li>
                                                                                <a href="/transact-online/transact">Transact</a>
                                                                            </li>
                                                                            <li>
                                                                                <a href="/transact-online/ways-to-transact">Ways
                                                                                    To Transact</a>
                                                                            </li>
                                                                        </ul>
                                                                    </div>
                                                                </div>
                                                            </h4>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-xs-12">
                                                <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                                                    <div class="panel panel-default">
                                                        <div class="panel-heading" role="tab" id="headingOne">
                                                            <h4 class="panel-title">
                                                                <a role="button" data-toggle="collapse" data-parent="#accordion" href="#dvInvestor" center="" aria-expanded="false" aria-controls="collapseOne" class="collapsed">Investor Center <i class="more-less glyphicon glyphicon-plus"></i></a>
                                                                <div id="dvInvestor" center="" class="panel-collapse collapse " role="tabpanel" aria-labelledby="headingOne" aria-expanded="true">
                                                                    <div class="panel-body" style="margin-bottom:0px">
                                                                        <ul class="list-style-none cl-effect-4">
                                                                            <li>
                                                                                <a href="/funds-performance/track-fund">Track
                                                                                    Funds</a>
                                                                            </li>
                                                                            <li>
                                                                                <a href="/investor-services/downloads/forms">Download
                                                                                    Forms</a>
                                                                            </li>
                                                                            <li>
                                                                                <a href="/investor-services/trade-data">Trade
                                                                                    Data</a>
                                                                            </li>
                                                                            <li>
                                                                                <a href="https://investeasy.reliancemutual.com/online/accountmgmt/mailbacksoa">Get
                                                                                    Account Statements</a>
                                                                            </li>
                                                                            <li>
                                                                                <a href="https://investeasy.reliancemutual.com/Online/Account/TrackTransactionoutside">Track
                                                                                    Your Transactions</a>
                                                                            </li>
                                                                            <li>
                                                                                <a href="/investor-services/nri-centre">NRI
                                                                                    Center</a>
                                                                            </li>
                                                                            <li>
                                                                                <a href="https://www.sebi.gov.in">SEBI</a>
                                                                            </li>
                                                                            <li>
                                                                                <a href="https://www.amfiindia.com/">AMFI</a>
                                                                            </li>
                                                                            <li>
                                                                                <a href="/Documents/Update-on-RHF-and-RCF-rating-actions-and-its-impact.pdf" target="_blank">Update on RHF &amp; RCF rating action and it’s impact</a>
                                                                            </li>
                                                                            <li>
                                                                                <a href="/Documents/DHFLUpdateNote.pdf" target="_blank">Update on DHFL</a>
                                                                            </li>
                                        <li>
                                                        <a href="/Documents/SegregationPressrelease1.pdf" target="_blank">Update on Nippon India Ultra Short Duration Fund</a>
                                                    </li>
                            <li>
                                                        <a href="/Documents/SegregationPressRelease2.pdf" target="_blank">Nippon India Ultra Short Duration Fund (Segregation of Portfolio)</a>
                                                    </li>
                                                                        </ul>
                                                                    </div>
                                                                </div>
                                                            </h4>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-xs-12">
                                                <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                                                    <div class="panel panel-default">
                                                        <div class="panel-heading" role="tab" id="headingOne">
                                                            <h4 class="panel-title">
                                                                <a role="button" data-toggle="collapse" data-parent="#accordion" href="#dvAbout" us="" aria-expanded="false" aria-controls="collapseOne" class="collapsed">About Us <i class="more-less glyphicon glyphicon-plus"></i>
                                                                </a>
                                                                <div id="dvAbout" us="" class="panel-collapse collapse " role="tabpanel" aria-labelledby="headingOne" aria-expanded="true">
                                                                    <div class="panel-body" style="margin-bottom:0px">
                                                                        <ul class="list-style-none cl-effect-4">
                                                                            <li>
                                                                                <a href="/about-us/company-profile/reliance-mutual-fund">The
                                                                                    Company</a>
                                                                            </li>
                                                                            <li>
                                                                                <a href="/career/why-choose-us">Careers</a>
                                                                            </li>
                                                                            <li>
                                                                                <a href="/about-us/voting-policy">Voting
                                                                                    Policy</a>
                                                                            </li>
                                                                            <li>
                                                                                <a href="/investor-service/customer-service/rnam-shareholders-investors">RNAM
                                                                                    Shareholders/Investors</a>
                                                                            </li>
                                                                            <li>
                                                                                <a href="https://www.reliancemutual.com/Pages/ExecutiveRemuneration.aspx">Remuneration</a>
                                                                            </li>
                                                                        </ul>
                                                                    </div>
                                                                </div>
                                                            </h4>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-xs-12">
                                                <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                                                    <div class="panel panel-default">
                                                        <div class="panel-heading" role="tab" id="headingOne">
                                                            <h4 class="panel-title">
                                                                <a role="button" data-toggle="collapse" data-parent="#accordion" href="#dvCustomer" service="" aria-expanded="false" aria-controls="collapseOne" class="collapsed">Customer Service <i class="more-less glyphicon glyphicon-plus"></i></a>
                                                                <div id="dvCustomer" service="" class="panel-collapse collapse " role="tabpanel" aria-labelledby="headingOne" aria-expanded="true">
                                                                    <div class="panel-body" style="margin-bottom:0px">
                                                                        <ul class="list-style-none cl-effect-4">
                                                                            <li>
                                                                                <a href="/investor-services/customer-service/locate-a-branch">Locate
                                                                                    a Branch</a>
                                                                            </li>
                                                                            <li>
                                                                                <a href="/investor-services/customer-service/locate-an-advisor">Locate
                                                                                    an Advisor</a>
                                                                            </li>
                                                                            <li>
                                                                                <a href="/investor-service/customer-service/non-transaction-days">Non
                                                                                    Transaction Days</a>
                                                                            </li>
                                                                            <li>
                                                                                <a href="/investor-service/downloads/annual-half-yearly-reports">Annual
                                                                                    Reports</a>
                                                                            </li>
                                                                            <li>
                                                                                <a href="/investor-services/downloads/total-expense-ratio-of-mutual-fund-schemes">Total
                                                                                    Expense Ratio of Mutual Fund
                                                                                    Schemes</a>
                                                                            </li>
                                                                        </ul>
                                                                    </div>
                                                                </div>
                                                            </h4>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </section>
                        <section class="bar background-image-fixed-1  no-mb"
                            id="getAppwebSite">
                                    <div class="container">
                                        <div class="row showcase">
                                            <div class="col-md-12 col-sm-12">
                                                <div class="heading text-center">
                                                    <h1 class="default-color imp_link" style="font-size: 28px; font-weight:normal">Get the app</h1>
                                                </div>
                                                <div class="row" id="mobile-app">
                                                    <div class="col-md-offset-3 col-sm-offset-2 col-md-6 col-sm-8 col-xs-12">
                                                        <a href="https://itunes.apple.com/in/app/reliance-mutual-fund/id691879143?mt=8" class="col-md-4 col-sm-4 col-xs-4" text-center=""><img src="images/app-store.png" class="img-responsive"></a>
                                                        <a href="https://play.google.com/store/apps/details?id=com.godbtech.reliancemf" class="col-md-4 col-sm-4 col-xs-4" text-center=""><img src="images/google-play.png" class="img-responsive"></a>
                                                        <a href="https://play.google.com/store/apps/details?id=com.reliance.businesseasy2" class="col-md-4 col-sm-4 col-xs-4">
                                                            <img src="images/Business-Easy-logo.png" class="img-responsive">
                                                        </a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </section>
                        <!-- pre-footer section ends here -->

                        <!--Footer started here-->
                        <footer style="background: #d2cecd; padding: 30px;
                            color: #999999">
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="heading text-center">
                        <h1 class="default-color" style="font-size: 14px !important;">Be Social With Us</h1>
                    </div>
                </div>

            </div>

            <div class="row">
                <div class="col-md-12" style="padding:0px;">
                    <div class="text-center">
                        <ul class="list-style-none list-inline animated fadeInUp" data-animate="fadeInUp" style="opacity: 0;">
                            <li>
                                <a href="https://www.facebook.com/RelianceMutualFund"><img src="images/facebook.png" class="img-responsive"></a>
                            </li>
                            <li>
                                <a href="https://www.instagram.com/reliancemutualfund"><img src="images/instagram.png" class="img-responsive"></a>
                            </li>
                            <li>
                                <a href="https://twitter.com/reliance_mf"> <img src="images/twitter.png" class="img-responsive"></a>
                            </li>
                            <li>
                                <a href="https://www.linkedin.com/company/2275601/"><img src="images/Linkedin_logo.png" class="img-responsive"></a>
                            </li>
                            <li>
                                <a href="https://www.youtube.com/user/RelianceMF2010/videos"><img src="images/you-tube.png" class="img-responsive"></a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix"></div>
    </footer>
                        
                        
                        
                        <div id="copyright">
                            <div class="container">
                                <div class="col-xs-12">
                                    <p class="text-center">
                                        <br>
                                        To report unauthorized electronic (Debit card / Net
                                        banking) transactions, Please call us on 1860 266
                                        0111 and select option 4.
                    <br>
                                        <br>
                                        NIPPON INDIA MUTUAL FUND INVESTMENTS ARE SUBJECT TO
                                        MARKET RISKS, READ ALL SCHEME RELATED DOCUMENTS CAREFULLY.
                                        <br>
                                        <br>

                                        <select id="ddlGroupComp" style="opacity: 1; font-size: 14px;
                                            height: 30px; width: 240px; top: auto; position: static;">
                                            <option selected="" value="Sponsor's Group Company Sites">
                                                Sponsor's Group Company Sites</option>
                                            <option value="http://www.rarcl.com">Reliance Asset Reconstruction
                                            </option>
                                            <option value="https://www.reliancegeneral.co.in/Insurance/Home.aspx">
                                                Reliance General Insurance</option>
                                            <option value="https://www.reliancehealthinsurance.com">
                                                Reliance Health Insurance </option>
                                            <option value="https://www.reliancehomefinance.com">Reliance
                                                Home Finance</option>
                                            <option value="https://www.reliancemoney.co.in">Reliance
                                                Money
                                            </option>
                                            <option value="http://www.reliancenipponlife.com">Reliance
                                                Nippon Life Insurance</option>
                                            <option value="https://www.reliancesmartmoney.com/">reliancesmartmoney.com</option>
                                        </select>

                                        <br>
                                        <br>
                                        © Nippon India Mutual Fund. Read on <a style="color: #231f20;"
                                            href="/Pages/DisclaimerspolicyPrivacypolicy.aspx">
                                            Disclaimers,
Privacy Policy</a> and <a style="color: black;" href="/Pages/rules-and-regulations.aspx">
    Rules &amp;
Regulations</a>
                                        <br>
                                        Nippon India Mutual Fund, 7th Floor South Wing &amp;
                                        5th Floor North Wing, Near Prabhat Colony, Prabhat
                                        Colony Rd, Sen Nagar, Santacruz East, Mumbai, Maharashtra,
                                        India 400055
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
        <div id="overlay">
            <div class="cv-spinner">
                <span class="spinner"></span>
            </div>
        </div>
        <table>
            <tr>
                <td>
                    <div id="PDFSIP" runat="server" style="display:none">
                                                                           
                    </div>
                </td>
                <td>
                    <div id="PDFSWP" runat="server" style="display:none">
                                                                          
                    </div>
                </td>
                <td>
                    <div id="PDFSTP" runat="server" style="display:none">
                                                                          
                    </div>
                </td>
                <td>
                    <div id="PDFLUMPSUM" runat="server" style="display:none">
                                                                          
                    </div>
                </td>
                
            </tr>
        </table>
        

    </form>

    <script type="text/javascript">
        $(function () {
            //debugger;
          
            
            $('.dropdown').on('show.bs.dropdown', function (e) {
                $(this).find('.dropdown-menu').first().stop(true, true).slideDown();
            });

            // ADD SLIDEUP ANIMATION TO DROPDOWN //
            $('.dropdown').on('hide.bs.dropdown', function (e) {
                e.preventDefault();
                $(this).find('.dropdown-menu').first().stop(true, true).slideUp(400, function () {
                    $('.dropdown').removeClass('open');
                    $('.dropdown').find('.dropdown-toggle').attr('aria-expanded', 'false');
                });

            });

           

            $('#btnExportPdf').click(function () {
                $("#overlay").show();
                var ele = document.getElementById('PDFSWP1');

                var opt = {

                    filename: 'NipponIndiaSWP.pdf',
                    image: { type: 'jpeg', quality: 0.98 },
                    margin: [1, 1.8],
                    html2canvas: { dpi: 300, letterRendering: true, scrollY: 0 },
                    jsPDF: { unit: "in", format: "b4", orientation: "l" },
                   pagebreak: { mode: ['avoid-all', 'css', 'legacy'] }
                    //jsPDF: { format: 'b4', orientation: 'portrait' },
                };

                //html2pdf(ele, opt);

                html2pdf(ele, opt).then(function() {$("#overlay").hide();});

                //html2pdf(ele, opt).then(function () {
                //  $("#overlay").hide();
                //});

            });

            $('#btnExportPdfSIP').click(function () {
                $("#overlay").show();

                //var notes = document.getElementById('sipNotes');

                //notes = notes.innerText.replace("first", "             first")

                //$("#sipNotes").html(notes);

                var ele = document.getElementById('PDFSIP1');

                var opt = {

                    filename: 'NipponIndiaSIP.pdf',
                    image: { type: 'jpeg', quality: 0.98 },
                    margin:  [1, 1.8],
                    html2canvas: { dpi: 300, letterRendering: true, scrollY: 0 },
                    jsPDF: { unit: "in", format: "b4", orientation: "l" },
                    pagebreak: { mode: ['avoid-all', 'css', 'legacy'] }
                    //jsPDF: { format: 'b4', orientation: 'portrait' },
                };

                //html2pdf(ele, opt);

                html2pdf(ele, opt).then(function() {$("#overlay").hide();});

                //html2pdf(ele, opt).then(function () {
                //  $("#overlay").hide();
                //});

            });

            $('#btnExportPdfSTP').click(function () {
                $("#overlay").show();
                var ele = document.getElementById('PDFSTP1');

                var opt = {

                    filename: 'NipponIndiaSTP.pdf',
                    image: { type: 'jpeg', quality: 0.98 },
                    margin: [1, 1.8],
                    html2canvas: { dpi: 300, letterRendering: true, scrollY: 0 },
                    jsPDF: { unit: "in", format: "b4", orientation: "l" },
                   pagebreak: { mode: ['avoid-all', 'css', 'legacy'] }
                    //jsPDF: { format: 'b4', orientation: 'portrait' },
                };

                //html2pdf(ele, opt);

                html2pdf(ele, opt).then(function() {$("#overlay").hide();});

                //html2pdf(ele, opt).then(function () {
                //  $("#overlay").hide();
                //});

            });

            $('#btnExportPdfLUMPSUM').click(function () {
                $("#overlay").show();
                var ele = document.getElementById('PDFLUMPSUM1');

                var opt = {

                    filename: 'NipponIndiaLUMPSUM.pdf',
                    image: { type: 'jpeg', quality: 0.98 },
                    margin: [1, 1.9],
                    html2canvas: { dpi: 300, letterRendering: true, scrollY: 0 },
                    jsPDF: { unit: "in", format: "b4", orientation: "l" },
                   pagebreak: { mode: ['avoid-all', 'css', 'legacy'] }
                    //jsPDF: { format: 'b4', orientation: 'portrait' },
                };

                //html2pdf(ele, opt);

                html2pdf(ele, opt).then(function() {$("#overlay").hide();});

                //html2pdf(ele, opt).then(function () {
                //  $("#overlay").hide();
                //});

            });
            
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            // Add smooth scrolling to all links
            $(".scroll-trigger").on('click', function (event) {

                // Make sure this.hash has a value before overriding default behavior
                if (this.hash !== "") {
                    // Prevent default anchor click behavior
                    event.preventDefault();

                    // Store hash
                    var hash = this.hash;

                    // Using jQuery's animate() method to add smooth page scroll
                    // The optional number (800) specifies the number of milliseconds it takes to scroll to the specified area
                    $('html, body').animate({
                        scrollTop: $(hash).offset().top
                    }, 800, function () {

                        // Add hash (#) to URL when done scrolling (default click behavior)
                        window.location.hash = hash;
                    });
                } // End if
            });

            // browser window scroll (in pixels) after which the "back to top" link is shown
            var offset = 100,
                //browser window scroll (in pixels) after which the "back to top" link opacity is reduced
                offset_opacity = 1200,
                //duration of the top scrolling animation (in ms)
                scroll_top_duration = 700,
                //grab the "back to top" link
                $back_to_top = $('.cd-top');

            //hide or show the "back to top" link
            $(window).scroll(function () {
                $('.cd-top').css({ bottom: $('.mobile-menu').outerHeight(true) + $('.chat-floting').outerHeight(true) + 40 });
                ($(this).scrollTop() > offset) ? $back_to_top.addClass('cd-is-visible') : $back_to_top.removeClass('cd-is-visible cd-fade-out');
                if ($(this).scrollTop() > offset_opacity) {
                    $back_to_top.addClass('cd-fade-out');
                }
            });

            var IsLogin = $('input[id$="hdnIsLoggedIn"]').val();
            if (IsLogin == "true") {
                $('[id$="LoginId"]').css('display', 'none');
                $('[id$="MyPortfolioId"]').css('display', 'block');
            }
            else {
                $('[id$="LoginId"]').css('display', 'block');
                $('[id$="MyPortfolioId"]').css('display', 'none');
            }

            //smooth scroll to top
            $back_to_top.on('click', function (event) {
                event.preventDefault();
                $('body,html').animate({
                    scrollTop: 0,
                }, scroll_top_duration);
            });
        });

        // Footer Sponsor’s Group Company Sites links
        $("#ddlGroupComp").change(function () {
            var go_to_url = $("#ddlGroupComp").find(":selected").val();
            if (go_to_url != "Sponsor’s Group Company Sites") {
                window.open(go_to_url, '_blank');
            }
        });

    </script>


</body>
</html>
