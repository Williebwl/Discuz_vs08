

 //验证抽奖券号
   function checkticketnubmer(){
     var jppattern=/^[0-9]+$/;
     var ticknumber=document .getElementById ("ticketnumber").value;
     if(!jppattern .test(ticknumber)){
       document.getElementById("ticketnumber").value="";
       document.getElementById("ticketnumber").focus();
       alert("只能输入数字");
     }else if(ticknumber .length>15){
       document.getElementById("ticketnumber").value="";
       document.getElementById("ticketnumber").focus();
       alert ("券号长度不能大于15");
      
     }else{
        document.formName.submit();
     }
   }
   
   
   function fsubmit(){
     if(document.getElementById ("ticketnumber").value==""){
       document.getElementById ("ticketnumber").focus();
       alert("请输入抽奖券号");
     }else{
       checkticketnubmer();
     }  
   }
   
   
   function empy(){
     document.getElementById ("ticketnumber").value="";
   }