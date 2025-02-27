<!--
//__________________ General __________________

var focusObj=null;		// this variable should be declared before calling validate()
var ch="abcdefghijklmnopqrstuvwxyz";
var an=ch+" '";
var nn="0123456789";
var pn="0123456789-+";
var cc="abcdefghijklmnopqrstuvwxyz0123456789-/.&() ";
var qn="abcdefghijklmnopqrstuvwxyz0123456789-/.&()#@$%*_";
var flt="0123456789.";
var ap="abcdefghijklmnopqrstuvwxyz0123456789-/.&() ";
var anum=ch+""+nn;
var pd =ch +""+ nn, li =ch +""+ nn,li2 =ch +" "+ nn+"_"+".",li =ch +" "+ nn+"_";
var st="abcdefghijklmnopqrstuvwxyz0123456789-/.&() ";
var dt="0123456789/";
ct= ch + " ."
/**/
var crs="abcdefghijklmnopqrstuvwxyz ";
var cd=nn+''+ch;
var pan=nn+''+ch;
var am="abcdefghijklmnopqrstuvwxyz&() ";

function selectItems(sel1,sel2,whatToSelect) {
  if(sel1==focusObj)  return false;
  if(sel2.options.length==0)
    return message(sel1,"Please select and add the "+whatToSelect+"(s) from the left list to the right. If it is not here, please add them to the "+whatToSelect+"'s Records",true);
  return true;
}

function checkAllowed(str,tf,text,canBeEmpty) {
//  if(focusObj==tf)  return false;	//
  if (! canBeEmpty) {
    if(isEmpty(tf,text))  return false;
  }
  var val=tf.value.toLowerCase()+"";
  str=str.toLowerCase();
  for(var i=0; i<val.length; i++) {
    if(str.indexOf(val.charAt(i)) == -1)  return message(tf,text);
  }
  return true;
}
function message(tf,text,full,noSelect) {		// displays apt error messages
  if(tf.type.indexOf("select") == -1 && !noSelect)  tf.select();
  if(tf.type != "hidden") tf.focus();
  alert((full? text : "please enter a valid "+text) +"..");
  return false;
}
function isEmpty(tf,text) {		// checks if textfield tf is empty
  if(focusObj==tf)  return true;
  var val=tf.value+" ";
  while(val.indexOf(" ") != -1)  val=val.replace(" ","");
  while(val.indexOf("\n") != -1)  val=val.replace("\n","");
  while(val.indexOf("\r") != -1)  val=val.replace("\r","");
  if(val=="")  return text ? !message(tf,"please enter "+text, true) : true;
  return false;
}


function isNumber(str) // Manish Prasad
{
		
	if(str.length>0) 
	{
		var str1 = str.replace(/[^\d]+/g, ''); 
		if(str1.length !=str.length)
		{
			return false;
		}
		
		return true;
		
	}
	
}




function checkMaxLength(tf,text,len) {
  if(focusObj==tf)  return true;
  return (tf.value.length > len) ? message(tf,text+" cannot have more than "+len+" characters",true) : true;
}
function checkMinLength(tf,text,len,canBeEmpty) {
  if(focusObj==tf)  return true;
  var val=tf.value;
  if(canBeEmpty && val=="")  return true;
  return (tf.value.length < len) ? message(tf,text+" cannot have less than "+len+" characters",true) : true;
}

function getSelValue(sel,noDefaultReturn) {		// returns value of a selection list
  if(sel.selectedIndex==-1)  {
    if(noDefaultReturn || sel.options.length==0)  return "";
    sel.options[0].selected=true;
  }
  return sel.options[sel.selectedIndex].value;
}
function getSelText(sel,noDefaultReturn) {		// returns text of a selection list
  if(sel.selectedIndex==-1)  {
    if(noDefaultReturn || sel.options.length==0)  return "";
    sel.options[0].selected=true;
  }
  return sel.options[sel.selectedIndex].text;
}
function setSelValue(sel,val) {
  for(var i=0; i< sel.options.length; i++) {
    if(sel.options[i].value+"" == val+"") {
      sel.options[i].selected=true;    return;
    }
  }
}
function getValueIndex(sel,val) {
  for(var i=0; i< sel.options.length; i++) {
    if(sel.options[i].value+"" == val+"")  return i;
  }
  return -1;
}
function selectAnItem(sel,whatToSelect) {
  if(sel==focusObj)  return false;
  if(getSelValue(sel)=="")
    return message(sel,"Please select a "+whatToSelect+". If it is not here, please add it to the "+whatToSelect+"'s Records.",true);
  return true;
}
function selectItems(sel1,sel2,whatToSelect) {
  if(sel1==focusObj)  return false;
  if(sel2.options.length==0)
    return message(sel1,"Please select and add the "+whatToSelect+"(s) from the left list to the right. If it is not here, please add them to the "+whatToSelect+"'s Records",true);
  return true;
}

function addItems(sel,target,text,canBeEmpty) {
  if(focusObj==sel)  return false;
  if(sel.options.length==0) {
    if(canBeEmpty) {
      if(! confirm("You have not added "+text+". Continue ...?")) {
        target.focus();  return false;
      }
    }
    else  return message(target,"Please add the " +text,true);
  }
  return true;
}
function isInt(str,lbound,ubound) {
  var i=parseInt(str);
  if(isNaN(i))  return false;
  if(i<lbound)  return false;
  if(i>ubound)  return false;
  return true;
}

function checkInt(tf,text,canBeEmpty,lbound,ubound) {
  if(tf==focusObj)  return false;
  if(canBeEmpty && tf.value=="")  return true;
  if(! canBeEmpty)  if(isEmpty(tf,text))  return false;
  var msg=text+ " should be a number";
  var belowMin=false,aboveMax=false;
  var no=parseInt(tf.value);
  if(!isNaN(no)) {
    if(no<lbound)  belowMin=true;
    if(no>ubound)  aboveMax=true;
    if(belowMin) 
      msg+= " greater than "+lbound;
    else if(aboveMax)
      msg+= " less than "+ubound;
    else  {
      tf.value=no;  return true;
    }
  }
  return message(tf,msg,true);
}

//_______________________URL_________________________
function urlValidate(tf,canBeEmpty) {
  var val=tf.value;
  if(canBeEmpty && val=="")  return true;
  var reg1=/^([a-zA-Z]+(:)(\/){2,2}){0,1}((\w)+[\w-.]*)((\w)+([\w-.]*)(\w))$/;
  var reg2=/(\.)+([a-zA-Z]*)$/;
  var arr1=val.match(reg1);
  var arr2=val.match(reg2);
  var dblDot=val.indexOf("..")>=0;
  if(arr1!= null && arr2!=null && !dblDot)  return true;
  return message(tf,"URL");
}

//__________________ URL __________________ wait
function checkValidURL(tf,canBeEmpty){
var val=tf.value;
if(canBeEmpty && val=="")  return true;
var httpregex=/^([a-zA-Z]+:\/\/)/
var urlregex=/^\w+.[.\w]*\w$/;
var match=val.match(httpregex); // has a protocol indicator
     if (match){
          match=tf.value.substr(match[1].length,val.length)
          match=match.match(urlregex);
     }else{
          var match=val.match(urlregex);
     }
     if(!match){
          if (errstmt) alert(errstmt);
          //if (excval) eval(excval);
          return false;
     }else return true;
}


//__________________ Date __________________

function dateValidate_3sel(dd,mm,yy) {
  if(focusObj==dd)  return false;
  var dd1=getSelValue(dd);
  var mm1=getSelValue(mm)-1;
  var yy1=getSelValue(yy);
  var ddate=new Date(yy1,mm1,dd1);
  if(ddate.getMonth() != mm1)  return message(dd,"Date");
  return true;
}
function dateValidate_1tf(tf,delim,ddmmyy,yyyy) {
  if(focusObj==tf)  return false;
  if(!delim || delim.length!=1)  delim="/";
  var arr=tf.value.split(delim);
  if(arr.length != 3)  return message(tf,"date");
  var dm=ddmmyy ? 1 : 0;
  var dd1=arr[1-dm];
  var mm1=arr[dm-0];
  var yy1=arr[2];
  if(! (isNumber(dd1)&&isNumber(mm1)&&isNumber(yy1) ))  return message(tf, "date");
  yy1-=0;
  
  if((yy1>100 && yy1<1800) || yy1<0)
   return message(tf,"Year should be between 1995 to Current Year",true);
  if(yyyy && yy1-0 <1000)  return message(tf,"date has to be in yyyy Format",true);
  var ddate=new Date(yy1,--mm1,dd1);
  if(ddate.getMonth() != mm1)  return message(tf,"date");
  return true;
}
function dateValid_1tf(tf,delim,ddmmyy) {
//alert("Manish");
focusObj=null;
  if(focusObj==tf)  return false;
  if(!delim || delim.length!=1)  delim="/";
  var format=(ddmmyy) ? "dd"+delim+"mm"+delim+"yy" : "mm"+delim+"dd"+delim+"yy"
  var arr=tf.value.split(delim);
  var fm=document.search;
  if(arr.length != 3)  return message(tf,"date in "+format+ " format");
  var dm=ddmmyy ? 1 : 0;
  var dd1=arr[1-dm];
  var mm1=arr[dm-0];
  var yy1=arr[2];
  if(yy1.length > 4)  return message(tf,"date in "+format+ " format"); //added line
  if(! (isNumber(dd1)&&isNumber(mm1)&&isNumber(yy1) ))  return message(tf, "Date in "+format+ " format");
  if(yy1-0>100 && yy1-0<1000)  return message(tf,"date in "+format+ " format");
  var ddate=new Date(yy1,--mm1,dd1);
  if(ddate.getMonth() != mm1)  return message(tf,"date in "+format+ " format");
  return true;
}
function checkFill(tf,text) {		// checks if Hidden tf is empty
  if(focusObj==tf)  return true;
  var val=tf.value+" ";
  while(val.indexOf(" ") != -1)  val=val.replace(" ","");
  while(val.indexOf("\n") != -1)  val=val.replace("\n","");
  while(val.indexOf("\r") != -1)  val=val.replace("\r","");
  if(val=="")  return text ? !message(tf,""+text, true) : true;
  return false;
}

function valid_date(tf,delim,canBeEmpty,ddmmyy) {
focusObj=null;
//  if(focusObj==tf)  return false;     
 /*   if(! canBeEmpty) {
    if(isEmpty(tf,text))  return false;}*/
  if(!delim || delim.length!=1)  delim="/";
  var format=(ddmmyy) ? "dd"+delim+"mm"+delim+"yyyy" : "mm"+delim+"dd"+delim+"yyyy"  
  var arr=tf.value.split(delim);  
  //var fm=document.search;
  if(arr.length != 3)  return message(tf,"date in "+format+ " format");  
  var dm=ddmmyy ? 1 : 0;
  var dd1=arr[1-dm];
  var mm1=arr[dm-0];
  var yy1=arr[2];
  //alert(dd1);
  //alert(mm1);
  //alert(yy1);  
  if(! (isNumber(dd1)&&isNumber(mm1)&&isNumber(yy1) ))  return message(tf, "date in "+format+ " format");
  if(yy1.length<4||yy1.length>4) return message(tf, "date in "+format+ " format");  
  //alert('after is number');
  if(yy1-0>100 && yy1-0<1000)  return message(tf,"date in "+format+ " format");
  var ddate=new Date(yy1,--mm1,dd1);
  if(ddate.getMonth() != mm1)  return message(tf,"date in "+format+ " format");
  return true;
}


function ChkDtFrmTodate(tf) //  Created by Manilsh Prasad
{
	//alert(tf);
	var arr=tf.split("/"); 
	//var year = true;
	//var month = true;
	var currentTime = new Date()
	var month = currentTime.getMonth() + 1
	var day = currentTime.getDate()
	var year = currentTime.getFullYear()
	var todate=(day + "/" + month + "/" + year)
	var arr1=todate.split("/"); 
		
	if(arr[2]>arr1[2])
	{
		//alert(arr[2]); 
		return false;
		
	}	
	if(arr[2]<=arr1[2])
	{
		// year = false;
		
	}
	//alert(year);

	if(parseInt(arr[1],10)>parseInt(arr1[1],10) && (arr[2]==arr1[2]))
	{
		//alert("Hello");
		return false;
		
	}	
	if(parseInt(arr[1],10)<=parseInt(arr1[1],10))
	{
		 //month = false;
	}
	
	if((parseInt(arr[0],10)>parseInt(arr1[0],10)) && (parseInt(arr[1],10)==parseInt(arr1[1],10) && arr[2]==arr1[2]))
	{
	   //alert("HI");
		return false;
		
	}	
	if(parseInt(arr[0],10)<=parseInt(arr1[0],10))
	{
		return true;
	}
	return true;
}


//__________________ E-Mail __________________

function emailValidate(tf,canBeEmpty) {
  if(focusObj==tf)  return false;
  var val=tf.value;
  if(canBeEmpty && val=="")  return true;
  var reg1=/^((\w)+[\w-.]*)@((\w)+([\w-.]*)(\w))$/
  var reg2=/(\.)+((\w)*)$/
  arr1=val.match(reg1);
  arr2=val.match(reg2);
  dblDotAfterAt=val.indexOf("..") > val.indexOf("@");
  if(arr1!= null && arr2!=null && !dblDotAfterAt)   return true;
  return message(tf,"e-mail");
}
//____________TimeValidation____________________vidu

function IsValidTime(tf,canBeEmpty) 
{
  if(focusObj==tf)  return false;
  var val=tf.value;
  if(canBeEmpty && val=="")  return true;
  //var timePat = /^(\d{1,2}):(\d{1,2})$/;
  var timePat = /^(\d{1,2}):(\d{1,2})(:(\d{1,2}))?(\s?(AM|am|PM|pm))?$/;
  var ary = val.match(timePat);
	if (ary == null)return message(tf,"Time is not in a valid format.",true);
  var hour = ary[1];
  var minute = ary[2];
  var second = ary[4];
  var ampm = ary[6];
	if (second=="") { second = null; }
	if (ampm=="") { ampm = null }
	if (hour < 0  || hour > 23) 
	 return message(tf,"Hour must be between 1 and 12. OR 0 and 23",true);
	//if (hour <= 12 && ampm == null)
	// return message(tf,"You must specify AM or PM.",true);
	if  (hour > 12 && ampm != null)
	return message(tf,"You can't specify AM or PM for military time.",true);
	if (minute < 0 || minute > 59) 
	 return message(tf,"Minute must be between 0 and 59.",true);
	if (second != null && (second < 0 || second > 59))
	 return message(tf,"Second must be between 0 and 59.",true);
	return true
}


function isEmptyNoMsg(tf) {		// checks if textfield tf is empty
  if(focusObj==tf)  return true;
  var val=tf.value+" ";
  while(val.indexOf(" ") != -1)  val=val.replace(" ","");
  while(val.indexOf("\n") != -1)  val=val.replace("\n","");
  while(val.indexOf("\r") != -1)  val=val.replace("\r","");
  if(val!="")  return true;
  return false;
}


function mathround(val){
	if(val.indexOf(".")>=0){
		var LenAfterDot=parseInt(val.length - val.indexOf(".")) - 2;
		var afterDot=val.substr(val.indexOf(".") + 1,val.length-1)
		if(LenAfterDot >=2){
		var CharAtOne=parseInt(afterDot.charAt(1));
			if(afterDot.charAt(2)>= 5){CharAtOne=parseInt(afterDot.charAt(1))+1;} 		
			val=val.substr(0,val.indexOf(".") + 2)+""+CharAtOne;		
		}
	}			 
	return val;
 }
/*

if(!IsValidTime(fm.t1,true or blank)) return false;        
	var aA="abcdefghijklmnopqrstuvwxyz` "; - Name
	var aR="abcdefghijklmnopqrstuvwxyz0123456789'/-,.:;()[] "; - Address
	var aAN="abcdefghijklmnopqrstuvwxyz0123456789 ";	   - 	
	var aAP="abcdefghijklmnopqrstuvwxyz0123456789_";	   - Id	
	var aN="0123456789- ";					   - Phone	

*/

function compareDates(tf,sDate){
	//type 3 : 29/05/1997
	var dateString =tf.value.split('/');var dateString1 =sDate.value.split('/');
	//var now = new Date();var todays = new Date(now.getYear(),now.getMonth(),now.getDate());
	var dates = new Date(dateString[2],dateString[1]-1,dateString[0]);
	var sdates = new Date(dateString1[2],dateString1[1]-1,dateString1[0]);
	//alert(dates +" - "+sdates);
	if (dates<=sdates) return false;
    return true;
}

function IsSelected(ControlID){
 if (!ControlID){return false;}
 if (ControlID.checked == true)return true;
 else{for (i = 0; i < ControlID.length; i++){
	if (ControlID[i].checked == true) return true;}
 }return false;
} 

-->