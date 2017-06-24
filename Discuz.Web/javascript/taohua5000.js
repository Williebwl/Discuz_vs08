

$(document).ready(function(){
  clock();
});
function clock(){
   $.ajax({
        type: "POST",
        url: "Handler/taohuo5000Handler.ashx",
        dataType:"json",
        cache: false,
        async: true,
        success: function(html) {
           if(html.result=="1")
           {
              $('#lblnum').html(html.num);
           }else if(html.result=="0")
           {
              
           }
        },
        error: function(html) {
           alert("网络异常，请稍后重试。。。");
        }
     });
      
 setTimeout("clock()",2*60*1000)
 //setTimeout("clock()",1000)
}