
       

//验证投票
function CheckVote(aid,title){
     //验证是否可以投票       
     var obj={operType:'verifyvote'};
       $.ajax({
            type: "POST",
            url: "Handler/taohua_xianziHandler.ashx",
            data:obj,
            dataType:"json",
            cache: false,
            async: false,
            success: function(html) {
               if(html.result=="1")
               {
                  var html = "<div style='padding:10px;'>请输入验证码：<input type='text' id='some' name='some' />  <input type='text' onclick='createCode()' readonly='readonly'  id='checkCode' class='unchanged' style='width: 80px'  /></div>";
                    var submit = function (v, h, f) {
                        if (f.some == '') {
                            $.jBox.tip("请输入验证码。", 'error', { focusId: "some" }); // 关闭设置 some 为焦点
                            return false;
                        }
                        if(validate())
                        {
                            obj={operType:'vote',Aid:aid};
                            $.ajax({
                                type: "POST",
                                url: "Handler/taohua_xianziHandler.ashx",
                                data:obj,
                                dataType:"json",
                                cache: false,
                                async: false,
                                success: function(html) {
                                   if(html.result=="1")
                                   {
                                      $.jBox.tip(html.msg,'info');
                                      $("#lblticketnum"+aid).html(parseInt($("#lblticketnum"+aid).html())+1);
                                   }else if(html.result=="0")
                                    {
                                       $.jBox.tip(html.msg,'error');
                                    }                       
                                },error: function(html) {
                                   $.jBox.tip('网络异常，请稍后重试。。。','error');
                                }
                            });    
                           //开始投票
                           return true;
                        }
                        return false;
                   };
                  $.jBox(html, { title: "您选择了"+aid+"号 "+title+" 投票", submit: submit });     
                  createCode();      
                  //Votepic(aid,uid);
               }else if(html.result=="0")
               {
                  $.jBox.tip(html.msg,'error');
               }
            },
            error: function(html) {
               $.jBox.tip('网络异常，请稍后重试。。。','error');
            }
         });
}

 var code ; //在全局 定义验证码   
 function createCode()   
 {    
   code = "";   
   var codeLength = 6;//验证码的长度   
   var checkCode = document.getElementById("checkCode");   
   var selectChar = new Array(0,1,2,3,4,5,6,7,8,9,'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z');//所有候选组成验证码的字符，当然也可以用中文的   
       
   for(var i=0;i<codeLength;i++)   
   {   
     
       
   var charIndex = Math.floor(Math.random()*36);   
   code +=selectChar[charIndex];   
      
      
   }   
   if(checkCode)   
   {   
     checkCode.className="code";   
     checkCode.value = code;   
   }   
      
 }   
        
 function validate ()   
 {   
       var flag=false;
       var inputCode = document.getElementById("some").value;   
       if(inputCode.length <=0)   
       {   
           $.jBox.tip("请输入验证码。", 'info', { focusId: "some" }); // 关闭设置 some 为焦点
       }   
       else if(inputCode != code )   
       {   
           $.jBox.tip('验证码输入错误！', 'error', { closed: function () { $('#some').select(); } });
          createCode();//刷新验证码   
       }   
       else   
       { 
         flag=true;
       }      
       return flag;
   }  