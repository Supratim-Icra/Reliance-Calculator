		var xmlDoc=new ActiveXObject("Microsoft.XMLDOM");
		
		function ShowMess()
		{
			var str = document.forms[0];
				if (document.Form1.txtMess.value!="N")
				{
				alert(document.Form1.txtMess.value);	
				document.Form1.txtMess.value="N";
				}
		
			/*
				if (document.Form1.txtMess1.value!="N")
				{
					
						var ValSp=document.Form1.txtMess1.value.split("#");
					   	var id=ValSp[0];
	                	var tablename=ValSp[1];
				//var formname=ValSp[2];
	                	//var funName=ValSp[3]; 
				var var1 = confirm('For Delete Press OK \n Otherwise Press CANCEL','Confirmation');				
				if (var1==true)
                   {
				  call(id,tablename);
				   }	
 				document.Form1.txtMess1.value="N";
				}
			*/			

			}
	
	var obj;
	function call(id,tablename)
	{
	obj = new ActiveXObject("Msxml2.XMLHTTP");	
	if(obj!=null){
		obj.onreadystatechange = DetailsResponse;
		obj.open("GET", "deleteWebForm.aspx?  &ID=" + id + " &TABLENAME=" + tablename,  true);
    	obj.send(null);
         }
	return false;
	}
function DetailsResponse()
{ 
		if(obj.readyState == 4)	
		 {			
			if(obj.status == 200)
			{
				if (obj.responseText == "yes")
				{
					alert('Deleted successfully')
				}
				if (obj.responseText == "no")
				{
					alert('Not Deleted successfully')
				}
		    }
		  }
}
		
		function call1(id,tablename)
		{
			
			if (xmlDoc!=null)
			{
					xmlDoc.async="false"
					var Vertualdir =location.pathname.split("/")[1];
					xmlDoc.load("http://"+location.hostname+"/"+Vertualdir+"/deleteWebForm.aspx?  &ID=" + id +" &TABLENAME=" + tablename);
					//alert('javed');
					alert(xmlDoc.documentElement.childNodes);
					nodes=xmlDoc.documentElement.childNodes
					alert(nodes.item(0).text(0));
					if (nodes.item(0).text(0)="yes")
					{
						alert("deleted successfully");
					}
			}
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
   return message(tf,"Year should be between 1753 and 9999",true);
  if(yyyy && yy1-0 <1000)  return message(tf,"date has to be in yyyy Format",true);
  var ddate=new Date(yy1,--mm1,dd1);
  if(ddate.getMonth() != mm1)  return message(tf,"date");
  return true;
}
function dateValid_1tf(tf,delim,ddmmyy) {
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
    if(! canBeEmpty) {
    if(isEmpty(tf,text))  return false;}
  if(!delim || delim.length!=1)  delim="/";
  var format=(ddmmyy) ? "dd"+delim+"mm"+delim+"yy" : "mm"+delim+"dd"+delim+"yy"
  var arr=tf.value.split(delim);
  var fm=document.search;
  if(arr.length != 3)  return message(tf,"date in "+format+ " format");
  var dm=ddmmyy ? 1 : 0;
  var dd1=arr[1-dm];
  var mm1=arr[dm-0];
  var yy1=arr[2];
  if(! (isNumber(dd1)&&isNumber(mm1)&&isNumber(yy1) ))  return message(tf, "Date in "+format+ " format");
  if(yy1-0>100 && yy1-0<1000)  return message(tf,"date in "+format+ " format");
  var ddate=new Date(yy1,--mm1,dd1);
  if(ddate.getMonth() != mm1)  return message(tf,"date in "+format+ " format");
  return true;
}