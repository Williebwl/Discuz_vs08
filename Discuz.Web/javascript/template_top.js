

function SearchFocus(){
  var topsearch=$('txt_topsearch');
  if(topsearch.value=='景区或酒店名称')
  {
    topsearch.value="";
  }
}

function SearchBlur(){
  var topsearch=$('txt_topsearch');
  if(topsearch.value==''){
    topsearch.value="景区或酒店名称";
  }
}