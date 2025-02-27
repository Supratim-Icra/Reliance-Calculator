<!--
var ControlToSet;
var theForm = document.theForm;
var CalWidth=120;
var StartYear = "";
var EndYear = "";
var FormatAs;
var NN4 = (navigator.appName.indexOf("Netscape")>=0 && !document.getElementById)? true : false;
var NN6 = (document.getElementById && navigator.appName.indexOf("Netscape")>=0 )? true: false;
var TOP;
var LEFT;
var DefaultMonthNYear;   //New code

if(NN4)document.captureEvents(Event.MOUSEMOVE);

document.onmousemove = LogPosition;
function LogPosition(evt){

	if (NN4||NN6){
	LEFT=evt.screenX;
	TOP=evt.screenY-10;
	}
	else{
	LEFT=event.screenX;
	TOP=event.screenY-10;
	}
}

function ReturnDate(CONTROL)
{
	DAY = CONTROL.toString();
	MONTH = (parseInt(CalendarForm.cboMonth.options[CalendarForm.cboMonth.selectedIndex].value) + 1);	
	YEAR = CalendarForm.cboYear.options[CalendarForm.cboYear.selectedIndex].value;
	var DateOutput = FormatDate();
	objOpener.SetDate(DateOutput);		
	window.close();
} //End Function

/*
function SetSTPDates(DATE){	
	var temp = DATE.split("/");	
	tempMonth= temp[1];
	tempYear = temp[2];	
	if(ControlToSet1)
	{			
		if (tempYear%4 > 0 )
		{
			if (tempMonth ==2)
			{
				for (i=0;i<30;i++)
				{
					ControlToSet1.options[i].value=i;
					
				}
			}
			else if ((tempMonth ==4)||(tempMonth ==6)||(tempMonth ==9)||(tempMonth ==11))
			{
				for (i=0;i<31;i++)
				{
					ControlToSet1.options[i].value=i;
				}
			}
			else
			{
				for (i=0;i=31;i++)
				{
					ControlToSet1.options[i].value=i;
				}
			}
		}
		else
		{
			if (tempMonth ==2)
			{
				for (i=0;i<30;i++)
				{
					ControlToSet1.options[i].value=i;
				}
			}
			else if ((tempMonth ==4)||(tempMonth ==6)||(tempMonth ==9)||(tempMonth ==11))
			{
				for (i=0;i<31;i++)
				{
					ControlToSet1.options[i].value=i;
				}
			}
			else
			{
				for (i=0;i=31;i++)
				{
					ControlToSet1.options[i].value=i;
				}
			}
		}
			
	}
	else ControlToSet1 = null;
}
*/

function isDate(DateToCheck)
{
	var arrDate = DateToCheck.split("/");
	var myDAY = arrDate[0];
	var myMONTH = arrDate[1];
	var myYEAR = arrDate[2];
	var strDate;
	strDate = myMONTH + "/" + myDAY + "/" + myYEAR;
	var testDate=new Date(strDate);
	if(testDate.getMonth()+1==myMONTH)
	{
		return true;
	} 
	else
	{
		return false;
	}
}//end function

function ShowCalendar(CONTROL,START_YEAR,END_YEAR,FORMAT){
var temp;
var tempMonth;
var tempYear;
var Today = new Date();
var dt;   //getdefaultdate


ControlToSet = eval(CONTROL);
StartYear = START_YEAR;
EndYear = END_YEAR;
FormatAs = FORMAT;


tempMonth = Today.getMonth();
tempYear = Today.getFullYear();

dt=ControlToSet.value;
if (isDate(dt))
{
	temp = dt.split("/");
	tempMonth= temp[1];
	tempYear = temp[2];	
}

DefaultMonthNYear = tempMonth + "#" + tempYear;

var strFeatures = "width=" + CalWidth + ",height=153" + ",left=" + LEFT + ",top=" + TOP;
var CalWindow = window.open("./includes/HTMLCalendar.htm","Calendar", strFeatures)
CalWindow.focus();

} //End Function

function ShowCalendars(CONTROL,START_YEAR,END_YEAR,FORMAT){

var temp;
var tempMonth;
var tempYear;
var Today = new Date();
var dt;   //getdefaultdate

ControlToSet = eval(CONTROL);
//StartYear = START_YEAR;
//EndYear = END_YEAR;
StartYear = "1995"; //first scheme launch of reliance mutual fund
EndYear = Today.getYear();
FormatAs = FORMAT;

tempMonth = Today.getMonth();
tempYear = Today.getFullYear();

dt=ControlToSet.value;
if (isDate(dt))
{
	temp = dt.split("/");
	tempMonth= temp[1];
	tempYear = temp[2];	
}
DefaultMonthNYear = tempMonth + "#" + tempYear;
var strFeatures = "width=" + CalWidth + ",height=153" + ",left=" + LEFT + ",top=" + TOP;
var CalWindow = window.open("./HTMLCalendar.htm","Calendar", strFeatures)
CalWindow.focus();
} //End Function

function ShowCalendars_STP(CONTROL,START_YEAR,END_YEAR,FORMAT,CONTROL1){
var temp;
var tempMonth;
var tempYear;
var Today = new Date();
var dt;   //getdefaultdate
var setStpDate;
var i;

ControlToSet = eval(CONTROL);
//StartYear = START_YEAR;
//EndYear = END_YEAR;
StartYear = "1995"; //first scheme launch of reliance mutual fund
EndYear = Today.getYear();
FormatAs = FORMAT;

tempMonth = Today.getMonth();
tempYear = Today.getFullYear();

dt=ControlToSet.value;
if (isDate(dt))
{
	temp = dt.split("/");
	tempMonth= temp[1];
	tempYear = temp[2];	
}
DefaultMonthNYear = tempMonth + "#" + tempYear;
ControlToSet1 = eval(CONTROL1);
var strFeatures = "width=" + CalWidth + ",height=153" + ",left=" + LEFT + ",top=" + TOP;
var CalWindow = window.open("./HTMLCalendar.htm","Calendar", strFeatures)
CalWindow.focus();
} //End Function

function SetDate(DATE){
if(ControlToSet){
ControlToSet.value = DATE; 
//document.forms[0].submit();
}
ControlToSet = null;
StartYear = null;
EndYear = null;
FormatAs = null;
}

function Chk(cntl)
{
	var cntlA;
	cntlA = eval(cntl);
	cntlA.value = 1; 
	return false;
}
//-->