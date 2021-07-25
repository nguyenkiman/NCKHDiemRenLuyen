
$(document).ready(function()
{
  moForm();
  dongForm();
});
//animation
var wow = new WOW(
  {
    boxClass:     'wow',      
    animateClass: 'animated',
    offset:       0,         
    mobile:       true,       
    live:         true,       
    callback:     function(box) {
     
     
    },
    scrollContainer: null 
  }
);
wow.init();
///hambuger
var menu=document.getElementById('hambuger_menu');
var btnhambuger=document.getElementById('button-event');
function show()
{
  btnhambuger.classList.toggle('change_btn');
  menu.classList.toggle("show_menu");
}

//menu fixed
window.onscroll = function() {myFunction()};

var header = document.getElementById("navbarDropdown");
var headerHide = document.getElementById("headerHide");
var sticky = header.offsetTop;
var stickyHeader = headerHide.offsetTop;
function myFunction() {
  if (window.pageYOffset > sticky) 
  {
    header.classList.add("sticky");
  } else {
    header.classList.remove("sticky");
  }

  if (window.pageYOffset > stickyHeader) 
  {
    headerHide.classList.add("sticky");
  } else {
    headerHide.classList.remove("sticky");
  }

}
//menu fixed

////scroll_to_top
$(window).scroll(function(){
    if($(window).scrollTop() >= 10) {
      $('.button_scrolltop').show(1000);
    } else {
      $('.button_scrolltop').hide(1000);
    }
  });
  
  function page_scrolltop(){
    $('html,body').animate({
      scrollTop: 0
      }, 1500);
  }
//// Tabs
// function getActiveTab()
// {
    
//     $('.tabitem').click(function()
//     {
//       $('.tabitem').removeClass("active");
//       $(this).addClass("active");
//     });
// }

function openCity(evt, cityName) {
  var i, tabcontent, tablinks;
  tabcontent = document.getElementsByClassName("tabcontent");
  for (i = 0; i < tabcontent.length; i++) {
    tabcontent[i].style.display = "none";
  }
  tablinks = document.getElementsByClassName("tabitem");
  for (i = 0; i < tablinks.length; i++) {
    tablinks[i].className = tablinks[i].className.replace("active", "");
  }
  document.getElementById(cityName).style.display = "block";
  evt.currentTarget.className += "active";
}

/// Chat
/*Hàm Mở Form*/
function moForm() {
  $('.nut-mo-chatbox').hide(1000);
  document.getElementById("myForm").classList.add("show_chatbox");
  document.getElementById("myForm").classList.remove("close_chatbox");
}
/*Hàm Đóng Form*/
function dongForm() {
  $('.nut-mo-chatbox').show(800);
  document.getElementById("myForm").classList.add("close_chatbox");
  document.getElementById("myForm").classList.remove("show_chatbox");
}