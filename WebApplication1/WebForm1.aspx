<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
  <head>
    <title>WebForm1</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
      <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css">
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="http://code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
    <script language="javascript" type="text/javascript" src="http://jqcanvas.googlecode.com/svn/trunk/jqcanvas/jquery.jqcanvas.js"></script>
      <script type="text/javascript" src="../src/plugins/jqplot.canvasTextRenderer.min.js"></script><script type="text/javascript" src="../src/plugins/jqplot.canvasAxisLabelRenderer.min.js"></script>
      <script type="text/javascript">

          $(document).ready(function(){
              var plot2 = $.jqplot ('chart2', [[3,7,9,1,4,6,8,2,5]], {
                  // Give the plot a title.
                  title: 'Plot With Options',
                  // You can specify options for all axes on the plot at once with
                  // the axesDefaults object.  Here, we're using a canvas renderer
                  // to draw the axis label which allows rotated text.
                  axesDefaults: {
                      labelRenderer: $.jqplot.CanvasAxisLabelRenderer
                  },
                  // An axes object holds options for all axes.
                  // Allowable axes are xaxis, x2axis, yaxis, y2axis, y3axis, ...
                  // Up to 9 y axes are supported.
                  axes: {
                      // options for each axis are specified in seperate option objects.
                      xaxis: {
                          label: "X Axis",
                          // Turn off "padding".  This will allow data point to lie on the
                          // edges of the grid.  Default padding is 1.2 and will keep all
                          // points inside the bounds of the grid.
                          pad: 0
                      },
                      yaxis: {
                          label: "Y Axis"
                      }
                  }
              });

      </script>
  </head>
  <body MS_POSITIONING="GridLayout">

    <form id="Form1" method="post" runat="server">

    </form>

  </body>
</html>
