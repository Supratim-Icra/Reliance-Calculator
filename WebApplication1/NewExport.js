<!--
/*
function newexports(eSrc, eSrc2, grd, p1,p2,p3,p4,s1,s2)
{
	var oExcel, oWkBooks, oExcelSheet, c, r, i, j, StartAt=1,ax="",cn=0;
	var sp1="SYSTEMATIC INVESTMENT PLAN",  sp2="SYSTEMATIC TRANSFER PLAN",sp3="SYSTEMATIC WITH DRAWL PLAN", fm=document.forms[0]; 
	var fonts , size8; fonts = "Arial"; size8=8; 

	eSrc=document.all(eSrc);
  	oExcel=new ActiveXObject('Excel.Application');
	oWkBooks=oExcel.Workbooks.Add;
	oExcel.Application.SheetsInNewWorkbook = 1;
	var sSheet; sSheet=oWkBooks.Worksheets(1);
	sSheet.Activate();
	with(sSheet)
	{

		sSheet.Rows.Font.Name=fonts;
		sSheet.Rows.Font.Size=size8;	
		Application.Visible = true;
       
		if(grd==0)
		{ 
			StartAt=StartAt+1;
			with(sSheet.Cells(StartAt, 1))
			{
				Font.Bold = true;
				if (p2=="")
				{
					var SRange="A" +StartAt+ ":G" +StartAt;
					var SourceRange;
					SourceRange=sSheet.Range(SRange);
					sSheet.Range(SRange).MergeCells = true;
					sSheet.Range(SRange).Interior.ColorIndex = 40;
					Value =sp3;
					StartAt=StartAt+2;
					var SRange="A" +StartAt+ ":G" +StartAt;
					var SourceRange;
					SourceRange=sSheet.Range(SRange);
					sSheet.Range(SRange).MergeCells = true;
					sSheet.Cells(StartAt, 1).Font.Bold = true;
					sSheet.Range(SRange).Interior.ColorIndex = 40;
					sSheet.Cells(StartAt, 1).Value ="Scheme Name: "+s1;
				}
				else
				{
					var SRange="A" +StartAt+ ":H" +StartAt;
					var SourceRange;
					SourceRange=sSheet.Range(SRange);
					sSheet.Range(SRange).MergeCells = true;
					sSheet.Range(SRange).Interior.ColorIndex = 40;
					Value =sp1;
					StartAt=StartAt+2;
					var SRange="A" +StartAt+ ":H" +StartAt;
					var SourceRange;
					SourceRange=sSheet.Range(SRange);
					sSheet.Cells(StartAt, 1).Font.Bold = true;
					sSheet.Range(SRange).MergeCells = true;
					sSheet.Range(SRange).Interior.ColorIndex = 40;
					sSheet.Cells(StartAt, 1).Value ="Scheme Name: "+s1;
				}

			} 
	
		}

	    if(grd==1)
		{ 
			StartAt=StartAt+1;
			with(sSheet.Cells(StartAt, 1))
			{
				var SRange="A" +StartAt+ ":J" +StartAt;
				var SourceRange;
				SourceRange=sSheet.Range(SRange);
				sSheet.Range(SRange).MergeCells = true;
				sSheet.Range(SRange).Interior.ColorIndex = 40;
				Font.Bold = true;
				Value =sp2;
				StartAt=StartAt+2;
				var SRange="A" +StartAt+ ":J" +StartAt;
				var SourceRange;
				SourceRange=sSheet.Range(SRange);
				sSheet.Range(SRange).MergeCells = true;
				sSheet.Cells(StartAt, 1).Font.Bold = true;
				sSheet.Range(SRange).Interior.ColorIndex = 40;
				sSheet.Cells(StartAt, 1).Value ="Transferd From Scheme: " +s1;
				StartAt++;
			} 
	
		}
			DisplayAutomaticPageBreaks = false;
		}

	StartAt=StartAt+2;
	var cols = Math.ceil(eSrc.cells.length/eSrc.rows.length);
	for (i=0;i<eSrc.cells.length;i++)
	{		
	 	r = Math.ceil((i+1)/cols); c=(i+1)-((r-1)*cols) ;j=StartAt;

		if ((r==1) && (r!=parseInt(eSrc.cells.length)))
		{
			sSheet.Cells(j, c).Font.Bold = true;
			sSheet.Cells(j, c).Interior.ColorIndex = 37;
			sSheet.Cells(j, c).WrapText = true;
		}
		if (trim(eSrc.cells(i).innerText)!="")
		{

			if (c==1)
			{
			   sSheet.Cells(j, c).NumberFormat = "mm/dd/yyyy"
			}
			if (eSrc.cells(i).innerText.value=='b')
			{
				
				sSheet.Cells(j, c).Value = eSrc.cells(i).innerText;
				sSheet.Cells(j, c).Font.Bold=true;
			}
			else
			{				
				sSheet.Cells(j, c).value = eSrc.cells(i).innerText;	    
			}
		}

		with(sSheet.Cells(j, c).Borders){LineStyle=1; ColorIndex=-4105;}
		if(c==cols) StartAt++;
	}

if(grd==0)
	{ 
		if(p2=="")
		{ 
			StartAt=StartAt+1;
			with(sSheet.Cells(StartAt, 1))
			{
				var SRange="A" +StartAt+ ":G" +StartAt;
				var SourceRange;
				SourceRange=sSheet.Range(SRange);
				sSheet.Range(SRange).MergeCells = true;
				sSheet.Range(SRange).Interior.ColorIndex = 40;
				Font.Bold = true;
				Value ="Yield(Scheme)                                : " + p1;
			} 
			StartAt=StartAt+1;
		}

		else
		{
			StartAt=StartAt+1;
			with(sSheet.Cells(StartAt, 1))
			{
				var SRange="A" +StartAt+ ":H" +StartAt;
				var SourceRange;
				SourceRange=sSheet.Range(SRange);
				sSheet.Range(SRange).MergeCells = true;
				sSheet.Range(SRange).Interior.ColorIndex = 40;
				Font.Bold = true;
				Value ="Yield(Scheme)                                : " + p1;
			} 
			StartAt=StartAt+1;
			with(sSheet.Cells(StartAt, 1))
			{
				var SRange="A" +StartAt+ ":H" +StartAt;
				var SourceRange;
				SourceRange=sSheet.Range(SRange);
				sSheet.Range(SRange).MergeCells = true;
				sSheet.Range(SRange).Interior.ColorIndex = 40;
				Font.Bold = true;
				Value ="Yield(Index)                                    : " + p2;
			} 
			StartAt=StartAt+1;
			with(sSheet.Cells(StartAt, 1))
			{
				var SRange="A" +StartAt+ ":H" +StartAt;
				var SourceRange;
				SourceRange=sSheet.Range(SRange);
				sSheet.Range(SRange).MergeCells = true;
				sSheet.Range(SRange).Interior.ColorIndex = 40;
				Font.Bold = true;
				Value ="Returns(One Time Investment) : " + p3;
			} 
		
		 	StartAt=StartAt+1; // 3 row
		}
	}

	if(grd==1) 
	{
		StartAt++;
		var SRange="A" +StartAt+ ":I" +StartAt;
		var SourceRange;
		SourceRange=sSheet.Range(SRange);
		sSheet.Range(SRange).MergeCells = true;
		sSheet.Cells(StartAt, 1).Font.Bold = true;
		sSheet.Range(SRange).Interior.ColorIndex = 40;
		sSheet.Cells(StartAt, 1).Value ="Transfered To Scheme: "+s2;
	}


if(grd==1) 
{
StartAt=StartAt+3;
eSrc2=document.all(eSrc2);
var cols = Math.ceil(eSrc2.cells.length/eSrc2.rows.length);
	for (i=0;i<eSrc2.cells.length;i++)
	{		
	//	var	tag;
	 	r = Math.ceil((i+1)/cols); c=(i+1)-((r-1)*cols) ;j=StartAt;		
		if ((r==1) && (r!=parseInt(eSrc2.cells.length)))
		{
			sSheet.Cells(j, c).Font.Bold = true;
			sSheet.Cells(j, c).Interior.ColorIndex = 37;
			/**sSheet.Cells(j, c).Font.Name = fonts;
			sSheet.Cells(j, c).Font.Size = 8;
			sSheet.Cells(j, c).Font.Color = 00000000;			
			

			sSheet.Cells(j, c).WrapText = true;
			//sSheet.Cells(j, c).HorizontalAlignment =-4108;sSheet.Cells(j, c).VerticalAlignment =-4108;
		}
		else if((eSrc2.cells(i).className=="snleft") || (eSrc2.cells(i).className=="snleftright") || (eSrc2.cells(i).className=="snright"))
		{
			//\\sSheet.Cells(j, c).Font.Bold = true;sSheet.Cells(j, c).Font.Name = "Arial";sSheet.Cells(j, c).Font.Size = 8;	
		}// sub total
		else if((eSrc2.cells(i).className=="cnleft") || (eSrc2.cells(i).className=="cnleftright") || (eSrc2.cells(i).className=="cnright"))
		{
			//\\sSheet.Cells(j, c).Font.Bold = true;sSheet.Cells(j, c).Font.Name = "Arial";sSheet.Cells(j, c).Font.Size = 8;	
		}//client total
		else if((eSrc2.cells(i).className=="gnleft") || (eSrc2.cells(i).className=="gnleftright") || (eSrc2.cells(i).className=="gnright"))
		{
			//\\sSheet.Cells(j, c).Font.Bold = true;sSheet.Cells(j, c).Font.Name = "Arial";sSheet.Cells(j, c).Font.Size = 8;	
		}//grand total
		else
		{
			//\\//sSheet.Cells(j, c).Font.Name = fonts;sSheet.Cells(j, c).Font.Size = size8;
			if(c>1) sSheet.Cells(j, c).HorizontalAlignment = -4152;
		}

		if (trim(eSrc2.cells(i).innerText)!="")
		{
			//tag=document.getElementByTag(eSrc2,tag);

//			alert(tag);
	//		if (tag.item(i-1).className=="DGRIDHEADClass")
			//alert (eSrc2.cells(i).className);
			if (c==1)
			{
			   sSheet.Cells(j, c).NumberFormat = "mm-dd-yyyy"
			}
			if (eSrc2.cells(i).innerText.value=='b')
			{
				
				sSheet.Cells(j, c).Value = eSrc2.cells(i).innerText;
				sSheet.Cells(j, c).Font.Bold=true;
			}
			else
			{				
				 sSheet.Cells(j, c).Value = eSrc2.cells(i).innerText;
			}
			//sSheet.Cells(j, c).Value = eSrc2.cells(i).innerText;
		}

		//sSheet.Cells(j, c).Value = eSrc2.cells(i).innerText;
		with(sSheet.Cells(j, c).Borders){LineStyle=1; ColorIndex=-4105;}
		if(c==cols) StartAt++;
	}

}

if(grd==1)
	{ 
		StartAt=StartAt+1;
		with(sSheet.Cells(StartAt, 1))
		{
			var SRange="A" +StartAt+ ":I" +StartAt;
			var SourceRange;
			SourceRange=sSheet.Range(SRange);
			sSheet.Range(SRange).MergeCells = true;
			sSheet.Range(SRange).Interior.ColorIndex = 40;
			Font.Bold = true;
			Value ="Value of balance units in transferor scheme              : " + p1;
		} 
		StartAt=StartAt+1;
		with(sSheet.Cells(StartAt, 1))
		{
			var SRange="A" +StartAt+ ":I" +StartAt;
			var SourceRange;
			SourceRange=sSheet.Range(SRange);
			sSheet.Range(SRange).MergeCells = true;
			sSheet.Range(SRange).Interior.ColorIndex = 40;
			Font.Bold = true;
			Value ="Value of Accumulated units in transferee scheme    : " + p2;
		} 
		StartAt=StartAt+1;
		with(sSheet.Cells(StartAt, 1))
		{
			var SRange="A" +StartAt+ ":I" +StartAt;
			var SourceRange;
			SourceRange=sSheet.Range(SRange);
			sSheet.Range(SRange).MergeCells = true;
			sSheet.Range(SRange).Interior.ColorIndex = 40;
			Font.Bold = true;
			Value ="Hence Yield from STP investment is (%)                      : " + p3;
		} 
	 	StartAt=StartAt+1; 
		with(sSheet.Cells(StartAt, 1))
		{
			var SRange="A" +StartAt+ ":I" +StartAt;
			var SourceRange;
			SourceRange=sSheet.Range(SRange);
			sSheet.Range(SRange).MergeCells = true;
			sSheet.Range(SRange).Interior.ColorIndex = 40;
			Font.Bold = true;
			Value ="Hence Yield from one time investment is (%)             : " + p4;
		} 
	}

	for (i=1;i<=cols;i++){ oExcel.Columns(i).Autofit;}
	oExcel.Columns(9).ColumnWidth="10";
}

function checkMultiple(sel)
{
	var j=0;
	for(var i=0; i< sel.options.length; i++) 
	{
		if(sel.options[i].selected==true) j=j+1;
	} 
	return j;
}

function trim(str)
{
	return str.replace(/^\s*|\s*$/g,"");
}
//-->

*/
// by Jayendra 


function newexports(eSrc, eSrc2, grd, p1,p2,p3,p4,s1,s2)
{
	var oExcel, oWkBooks, oExcelSheet, c, r, i, j, StartAt=1,ax="",cn=0;
	var sp1="SYSTEMATIC INVESTMENT PLAN",  sp2="SYSTEMATIC TRANSFER PLAN",sp3="SYSTEMATIC WITH DRAWL PLAN", fm=document.forms[0]; 
	var fonts , size8; fonts = "Arial"; size8=8; 

	eSrc=document.all(eSrc);
  	oExcel=new ActiveXObject('Excel.Application');
	oWkBooks=oExcel.Workbooks.Add;
	oExcel.Application.SheetsInNewWorkbook = 1;
	var sSheet; sSheet=oWkBooks.Worksheets(1);
	sSheet.Activate();
	with(sSheet)
	{

		sSheet.Rows.Font.Name=fonts;
		sSheet.Rows.Font.Size=size8;	
		Application.Visible = true;
       
		if(grd==0)
		{ 
			StartAt=StartAt+1;
			with(sSheet.Cells(StartAt, 1))
			{
				Font.Bold = true;				
				var SRange="A" +StartAt+ ":G" +StartAt;
				var SourceRange;
				SourceRange=sSheet.Range(SRange);
				sSheet.Range(SRange).MergeCells = true;
				sSheet.Range(SRange).Interior.ColorIndex = 40;
				Value =sp3;
				StartAt=StartAt+2;
				var SRange="A" +StartAt+ ":G" +StartAt;
				var SourceRange;
				SourceRange=sSheet.Range(SRange);
				sSheet.Range(SRange).MergeCells = true;
				sSheet.Cells(StartAt, 1).Font.Bold = true;
				sSheet.Range(SRange).Interior.ColorIndex = 40;
				sSheet.Cells(StartAt, 1).Value ="Scheme Name: "+s1;
			}
				
		}

		if(grd==2)
		{
			StartAt=StartAt+1;
			with(sSheet.Cells(StartAt, 1))
			{
				var SRange="A" +StartAt+ ":H" +StartAt;
				var SourceRange;
				SourceRange=sSheet.Range(SRange);
				sSheet.Range(SRange).MergeCells = true;
				sSheet.Range(SRange).Interior.ColorIndex = 40;
				Font.Bold = true;
				Value =sp1;
				StartAt=StartAt+2;
				var SRange="A" +StartAt+ ":H" +StartAt;
				var SourceRange;
				SourceRange=sSheet.Range(SRange);
				sSheet.Cells(StartAt, 1).Font.Bold = true;
				sSheet.Range(SRange).MergeCells = true;
				sSheet.Range(SRange).Interior.ColorIndex = 40;
				sSheet.Cells(StartAt, 1).Value ="Scheme Name: "+s1;
			}
		}
		
	    if(grd==1)
		{ 
			StartAt=StartAt+1;
			with(sSheet.Cells(StartAt, 1))
			{
				var SRange="A" +StartAt+ ":J" +StartAt;
				var SourceRange;
				SourceRange=sSheet.Range(SRange);
				sSheet.Range(SRange).MergeCells = true;
				sSheet.Range(SRange).Interior.ColorIndex = 40;
				Font.Bold = true;
				Value =sp2;
				StartAt=StartAt+2;
				var SRange="A" +StartAt+ ":J" +StartAt;
				var SourceRange;
				SourceRange=sSheet.Range(SRange);
				sSheet.Range(SRange).MergeCells = true;
				sSheet.Cells(StartAt, 1).Font.Bold = true;
				sSheet.Range(SRange).Interior.ColorIndex = 40;
				sSheet.Cells(StartAt, 1).Value ="Transferd From Scheme: " +s1;
				StartAt++;
			} 
	
		}
		DisplayAutomaticPageBreaks = false;
	}

	StartAt=StartAt+2;
	var cols = Math.ceil(eSrc.cells.length/eSrc.rows.length);
	for (i=0;i<eSrc.cells.length;i++)
	{		
	 	r = Math.ceil((i+1)/cols); c=(i+1)-((r-1)*cols) ;j=StartAt;

		if ((r==1) && (r!=parseInt(eSrc.cells.length)))
		{
			sSheet.Cells(j, c).Font.Bold = true;
			sSheet.Cells(j, c).Interior.ColorIndex = 37;
			sSheet.Cells(j, c).WrapText = true;
		}
		if (trim(eSrc.cells(i).innerText)!="")
		{

			if (c==1)
			{
			   sSheet.Cells(j, c).NumberFormat = "dd/MMM/yyyy"
			}
			if (eSrc.cells(i).innerText.value=='b')
			{
				
				sSheet.Cells(j, c).Value = eSrc.cells(i).innerText;
				sSheet.Cells(j, c).Font.Bold=true;
			}
			else
			{				
				sSheet.Cells(j, c).value = eSrc.cells(i).innerText;	    
			}
		}

		with(sSheet.Cells(j, c).Borders){LineStyle=1; ColorIndex=-4105;}
		if(c==cols) StartAt++;
	}

	if(grd==0)
	{ 
		StartAt=StartAt+1;
		with(sSheet.Cells(StartAt, 1))
		{
			var SRange="A" +StartAt+ ":G" +StartAt;
			var SourceRange;
			SourceRange=sSheet.Range(SRange);
			sSheet.Range(SRange).MergeCells = true;
			sSheet.Range(SRange).Interior.ColorIndex = 40;
			Font.Bold = true;
			Value ="Abs. Returns(Scheme)                          : " + p3;
		} 
		StartAt=StartAt+1;
		with(sSheet.Cells(StartAt, 1))
		{
			var SRange="A" +StartAt+ ":G" +StartAt;
			var SourceRange;
			SourceRange=sSheet.Range(SRange);
			sSheet.Range(SRange).MergeCells = true;
			sSheet.Range(SRange).Interior.ColorIndex = 40;
			Font.Bold = true;
			Value ="Yield(Scheme)                                : " + p1;
		} 
		StartAt=StartAt+1;		
	}

	if(grd==2)
	{
		StartAt=StartAt+1;
		with(sSheet.Cells(StartAt, 1))
		{
			var SRange="A" +StartAt+ ":H" +StartAt;
			var SourceRange;
			SourceRange=sSheet.Range(SRange);
			sSheet.Range(SRange).MergeCells = true;
			sSheet.Range(SRange).Interior.ColorIndex = 40;
			Font.Bold = true;
			Value ="Abs. Returns(Scheme)						: " + p3;
		} 
		StartAt=StartAt+1;
		with(sSheet.Cells(StartAt, 1))
		{
			var SRange="A" +StartAt+ ":H" +StartAt;
			var SourceRange;
			SourceRange=sSheet.Range(SRange);
			sSheet.Range(SRange).MergeCells = true;
			sSheet.Range(SRange).Interior.ColorIndex = 40;
			Font.Bold = true;
			Value ="Yield(Scheme)                                : " + p1;
		} 
			
		StartAt=StartAt+1;
		with(sSheet.Cells(StartAt, 1))
		{
			var SRange="A" +StartAt+ ":H" +StartAt;
			var SourceRange;
			SourceRange=sSheet.Range(SRange);
			sSheet.Range(SRange).MergeCells = true;
			sSheet.Range(SRange).Interior.ColorIndex = 40;
			Font.Bold = true;
			Value ="Yield(Index)                                : " + p2;
		} 
	}

	if(grd==1) 
	{
		StartAt++;
		var SRange="A" +StartAt+ ":I" +StartAt;
		var SourceRange;
		SourceRange=sSheet.Range(SRange);
		sSheet.Range(SRange).MergeCells = true;
		sSheet.Cells(StartAt, 1).Font.Bold = true;
		sSheet.Range(SRange).Interior.ColorIndex = 40;
		sSheet.Cells(StartAt, 1).Value ="Transfered To Scheme: "+s2;
	}


if(grd==1) 
{
StartAt=StartAt+3;
eSrc2=document.all(eSrc2);
var cols = Math.ceil(eSrc2.cells.length/eSrc2.rows.length);
	for (i=0;i<eSrc2.cells.length;i++)
	{		
	//	var	tag;
	 	r = Math.ceil((i+1)/cols); c=(i+1)-((r-1)*cols) ;j=StartAt;		
		if ((r==1) && (r!=parseInt(eSrc2.cells.length)))
		{
			sSheet.Cells(j, c).Font.Bold = true;
			sSheet.Cells(j, c).Interior.ColorIndex = 37;
			/**sSheet.Cells(j, c).Font.Name = fonts;
			sSheet.Cells(j, c).Font.Size = 8;
			sSheet.Cells(j, c).Font.Color = 00000000;			
			**/
			sSheet.Cells(j, c).WrapText = true;
			//sSheet.Cells(j, c).HorizontalAlignment =-4108;sSheet.Cells(j, c).VerticalAlignment =-4108;
		}
		else if((eSrc2.cells(i).className=="snleft") || (eSrc2.cells(i).className=="snleftright") || (eSrc2.cells(i).className=="snright"))
		{
			//\\sSheet.Cells(j, c).Font.Bold = true;sSheet.Cells(j, c).Font.Name = "Arial";sSheet.Cells(j, c).Font.Size = 8;	
		}// sub total
		else if((eSrc2.cells(i).className=="cnleft") || (eSrc2.cells(i).className=="cnleftright") || (eSrc2.cells(i).className=="cnright"))
		{
			//\\sSheet.Cells(j, c).Font.Bold = true;sSheet.Cells(j, c).Font.Name = "Arial";sSheet.Cells(j, c).Font.Size = 8;	
		}//client total
		else if((eSrc2.cells(i).className=="gnleft") || (eSrc2.cells(i).className=="gnleftright") || (eSrc2.cells(i).className=="gnright"))
		{
			//\\sSheet.Cells(j, c).Font.Bold = true;sSheet.Cells(j, c).Font.Name = "Arial";sSheet.Cells(j, c).Font.Size = 8;	
		}//grand total
		else
		{
			//\\//sSheet.Cells(j, c).Font.Name = fonts;sSheet.Cells(j, c).Font.Size = size8;
			if(c>1) sSheet.Cells(j, c).HorizontalAlignment = -4152;
		}

		if (trim(eSrc2.cells(i).innerText)!="")
		{
			//tag=document.getElementByTag(eSrc2,tag);

//			alert(tag);
	//		if (tag.item(i-1).className=="DGRIDHEADClass")
			//alert (eSrc2.cells(i).className);
			if (c==1)
			{
			   sSheet.Cells(j, c).NumberFormat = "dd/MMM/yyyy"
			}
			if (eSrc2.cells(i).innerText.value=='b')
			{
				
				sSheet.Cells(j, c).Value = eSrc2.cells(i).innerText;
				sSheet.Cells(j, c).Font.Bold=true;
			}
			else
			{				
				 sSheet.Cells(j, c).Value = eSrc2.cells(i).innerText;
			}
			//sSheet.Cells(j, c).Value = eSrc2.cells(i).innerText;
		}

		//sSheet.Cells(j, c).Value = eSrc2.cells(i).innerText;
		with(sSheet.Cells(j, c).Borders){LineStyle=1; ColorIndex=-4105;}
		if(c==cols) StartAt++;
	}

}

if(grd==1)
	{ 
		StartAt=StartAt+1;
		with(sSheet.Cells(StartAt, 1))
		{
			var SRange="A" +StartAt+ ":I" +StartAt;
			var SourceRange;
			SourceRange=sSheet.Range(SRange);
			sSheet.Range(SRange).MergeCells = true;
			sSheet.Range(SRange).Interior.ColorIndex = 40;
			Font.Bold = true;
			Value ="Value of balance units in transferor scheme              : " + p1;
		} 
		StartAt=StartAt+1;
		with(sSheet.Cells(StartAt, 1))
		{
			var SRange="A" +StartAt+ ":I" +StartAt;
			var SourceRange;
			SourceRange=sSheet.Range(SRange);
			sSheet.Range(SRange).MergeCells = true;
			sSheet.Range(SRange).Interior.ColorIndex = 40;
			Font.Bold = true;
			Value ="Value of Accumulated units in transferee scheme    : " + p2;
		} 
		StartAt=StartAt+1;
		with(sSheet.Cells(StartAt, 1))
		{
			var SRange="A" +StartAt+ ":I" +StartAt;
			var SourceRange;
			SourceRange=sSheet.Range(SRange);
			sSheet.Range(SRange).MergeCells = true;
			sSheet.Range(SRange).Interior.ColorIndex = 40;
			Font.Bold = true;
			Value ="Hence Yield from STP investment is (%)                      : " + p3;
		} 
		
	 	StartAt=StartAt+1; 
		with(sSheet.Cells(StartAt, 1))
		{
			var SRange="A" +StartAt+ ":I" +StartAt;
			var SourceRange;
			SourceRange=sSheet.Range(SRange);
			sSheet.Range(SRange).MergeCells = true;
			sSheet.Range(SRange).Interior.ColorIndex = 40;
			Font.Bold = true;
			Value ="Hence Yield from one time investment is (%)             : " + p4;
		}
	}

	for (i=1;i<=cols;i++){ oExcel.Columns(i).Autofit;}
	oExcel.Columns(9).ColumnWidth="10";
}

function checkMultiple(sel)
{
	var j=0;
	for(var i=0; i< sel.options.length; i++) 
	{
		if(sel.options[i].selected==true) j=j+1;
	} 
	return j;
}

function trim(str)
{
	return str.replace(/^\s*|\s*$/g,"");
}


