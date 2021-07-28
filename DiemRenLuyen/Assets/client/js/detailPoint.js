
$(document).ready(function()
{
  LoadDiemSinhVien();
  LoadDiemLopDanhGia();
  LoadDiemGiaoVienDanhGia();
  Total();
  Total_Lop_Danh_Gia();
  Total_SinhVien_Danh_Gia()
});

//auto update point 


function LoadDiemSinhVien()
{
    //Muc I
    var diemTuCham_1 = parseInt(document.getElementsByClassName("diemTuCham_1")[0].value);
    var diemTuCham_2 = parseInt(document.getElementsByClassName("diemTuCham_2")[0].value);
    var diemTuCham_3 = parseInt(document.getElementsByClassName("diemTuCham_3")[0].value);
    var diemTuCham_4 = parseInt(document.getElementsByClassName("diemTuCham_4")[0].value);
    var diemTuCham_5 = parseInt(document.getElementsByClassName("diemTuCham_5")[0].value);
    var diemTuCham_6 = parseInt(document.getElementsByClassName("diemTuCham_6")[0].value);

    var txt_rs_yttght=document.getElementsByClassName("txt_rs_yttght")[0];
    txt_rs_yttght.innerHTML = diemTuCham_1 + diemTuCham_2 + diemTuCham_3 + diemTuCham_4 + diemTuCham_5 + diemTuCham_6;

   //Muc II
    var diemTuCham_7 = parseInt(document.getElementsByClassName("diemTuCham_7")[0].value);
    var diemTuCham_8 = parseInt(document.getElementsByClassName("diemTuCham_8")[0].value);
    var diemTuCham_9 = parseInt(document.getElementsByClassName("diemTuCham_9")[0].value);
    var diemTuCham_10 = parseInt(document.getElementsByClassName("diemTuCham_10")[0].value);

    var txt_rs_chny=document.getElementsByClassName("txt_rs_chny")[0];
    txt_rs_chny.innerHTML = diemTuCham_10 + diemTuCham_7 + diemTuCham_8 + diemTuCham_9;

    //Muc III
    var diemTuCham_11 = parseInt(document.getElementsByClassName("diemTuCham_11")[0].value);
    var diemTuCham_12 = parseInt(document.getElementsByClassName("diemTuCham_12")[0].value);
    var diemTuCham_13 = parseInt(document.getElementsByClassName("diemTuCham_13")[0].value);
    var diemTuCham_14 = parseInt(document.getElementsByClassName("diemTuCham_14")[0].value);

    var txt_rs_hdct=document.getElementsByClassName("txt_rs_hdct")[0];
    txt_rs_hdct.innerHTML = diemTuCham_11 + diemTuCham_12 + diemTuCham_13 + diemTuCham_14;

    //Muc IV
    var diemTuCham_15 = parseInt(document.getElementsByClassName("diemTuCham_15")[0].value);
    var diemTuCham_16 = parseInt(document.getElementsByClassName("diemTuCham_16")[0].value);
    var diemTuCham_17 = parseInt(document.getElementsByClassName("diemTuCham_17")[0].value);
    var diemTuCham_18 = parseInt(document.getElementsByClassName("diemTuCham_18")[0].value);
    var diemTuCham_19 = parseInt(document.getElementsByClassName("diemTuCham_19")[0].value);

    var txt_rs_ytcd=document.getElementsByClassName("txt_rs_ytcd")[0];
    txt_rs_ytcd.innerHTML = diemTuCham_15 + diemTuCham_16 + diemTuCham_17 + diemTuCham_18 + diemTuCham_19;

    

    //Muc V
    var diemTuCham_20 = parseInt(document.getElementsByClassName("diemTuCham_20")[0].value);
    var diemTuCham_21 = parseInt(document.getElementsByClassName("diemTuCham_21")[0].value);
    var diemTuCham_22 = parseInt(document.getElementsByClassName("diemTuCham_22")[0].value);
    var diemTuCham_23 = parseInt(document.getElementsByClassName("diemTuCham_23")[0].value);

    var txt_rs_tgctl=document.getElementsByClassName("txt_rs_tgctl")[0];
    txt_rs_tgctl.innerHTML = diemTuCham_20 + diemTuCham_21 + diemTuCham_22 + diemTuCham_23;

}
function LoadDiemLopDanhGia()
{
  //Muc I
    var diemTuCham_1 = parseInt(document.getElementsByClassName("diemTuCham_1")[1].value);
    var diemTuCham_2 = parseInt(document.getElementsByClassName("diemTuCham_2")[1].value);
    var diemTuCham_3 = parseInt(document.getElementsByClassName("diemTuCham_3")[1].value);
    var diemTuCham_4 = parseInt(document.getElementsByClassName("diemTuCham_4")[1].value);
    var diemTuCham_5 = parseInt(document.getElementsByClassName("diemTuCham_5")[1].value);
    var diemTuCham_6 = parseInt(document.getElementsByClassName("diemTuCham_6")[1].value);

    var txt_rs_yttght=document.getElementsByClassName("txt_rs_yttght")[1];
    txt_rs_yttght.innerHTML = diemTuCham_1 + diemTuCham_2 + diemTuCham_3 + diemTuCham_4 + diemTuCham_5 + diemTuCham_6;

    //Muc II
    var diemTuCham_7 = parseInt(document.getElementsByClassName("diemTuCham_7")[1].value);
    var diemTuCham_8 = parseInt(document.getElementsByClassName("diemTuCham_8")[1].value);
    var diemTuCham_9 = parseInt(document.getElementsByClassName("diemTuCham_9")[1].value);
    var diemTuCham_10 = parseInt(document.getElementsByClassName("diemTuCham_10")[1].value);

    var txt_rs_chny=document.getElementsByClassName("txt_rs_chny")[1];
    txt_rs_chny.innerHTML = diemTuCham_10 + diemTuCham_7 + diemTuCham_8 + diemTuCham_9;

    //Muc III
    var diemTuCham_11 = parseInt(document.getElementsByClassName("diemTuCham_11")[1].value);
    var diemTuCham_12 = parseInt(document.getElementsByClassName("diemTuCham_12")[1].value);
    var diemTuCham_13 = parseInt(document.getElementsByClassName("diemTuCham_13")[1].value);
    var diemTuCham_14 = parseInt(document.getElementsByClassName("diemTuCham_14")[1].value);

    var txt_rs_hdct=document.getElementsByClassName("txt_rs_hdct")[1];
    txt_rs_hdct.innerHTML = diemTuCham_11 + diemTuCham_12 + diemTuCham_13 + diemTuCham_14;

    //Muc IV
    var diemTuCham_15 = parseInt(document.getElementsByClassName("diemTuCham_15")[1].value);
    var diemTuCham_16 = parseInt(document.getElementsByClassName("diemTuCham_16")[1].value);
    var diemTuCham_17 = parseInt(document.getElementsByClassName("diemTuCham_17")[1].value);
    var diemTuCham_18 = parseInt(document.getElementsByClassName("diemTuCham_18")[1].value);
    var diemTuCham_19 = parseInt(document.getElementsByClassName("diemTuCham_19")[1].value);

    var txt_rs_ytcd=document.getElementsByClassName("txt_rs_ytcd")[1];
    txt_rs_ytcd.innerHTML = diemTuCham_15 + diemTuCham_16 + diemTuCham_17 + diemTuCham_18 + diemTuCham_19;

    //Muc V
    var diemTuCham_20 = parseInt(document.getElementsByClassName("diemTuCham_20")[1].value);
    var diemTuCham_21 = parseInt(document.getElementsByClassName("diemTuCham_21")[1].value);
    var diemTuCham_22 = parseInt(document.getElementsByClassName("diemTuCham_22")[1].value);
    var diemTuCham_23 = parseInt(document.getElementsByClassName("diemTuCham_23")[1].value);

    var txt_rs_tgctl=document.getElementsByClassName("txt_rs_tgctl")[1];
    txt_rs_tgctl.innerHTML = diemTuCham_20 + diemTuCham_21 + diemTuCham_22 + diemTuCham_23;
}
function LoadDiemGiaoVienDanhGia()
{
  //Muc I
    var diemTuCham_1 = parseInt(document.getElementsByClassName("diemTuCham_1")[2].value);
    var diemTuCham_2 = parseInt(document.getElementsByClassName("diemTuCham_2")[2].value);
    var diemTuCham_3 = parseInt(document.getElementsByClassName("diemTuCham_3")[2].value);
    var diemTuCham_4 = parseInt(document.getElementsByClassName("diemTuCham_4")[2].value);
    var diemTuCham_5 = parseInt(document.getElementsByClassName("diemTuCham_5")[2].value);
    var diemTuCham_6 = parseInt(document.getElementsByClassName("diemTuCham_6")[2].value);

    var txt_rs_yttght=document.getElementsByClassName("txt_rs_yttght")[2];
    txt_rs_yttght.innerHTML = diemTuCham_1 + diemTuCham_2 + diemTuCham_3 + diemTuCham_4 + diemTuCham_5 + diemTuCham_6;

    var total_mucI=document.getElementById("total_mucI");
    total_mucI.innerHTML = diemTuCham_1 + diemTuCham_2 + diemTuCham_3 + diemTuCham_4 + diemTuCham_5 + diemTuCham_6;

    //Muc II
    var diemTuCham_7 = parseInt(document.getElementsByClassName("diemTuCham_7")[2].value);
    var diemTuCham_8 = parseInt(document.getElementsByClassName("diemTuCham_8")[2].value);
    var diemTuCham_9 = parseInt(document.getElementsByClassName("diemTuCham_9")[2].value);
    var diemTuCham_10 = parseInt(document.getElementsByClassName("diemTuCham_10")[2].value);

    var txt_rs_chny=document.getElementsByClassName("txt_rs_chny")[2];
    txt_rs_chny.innerHTML = diemTuCham_10 + diemTuCham_7 + diemTuCham_8 + diemTuCham_9;

    var total_mucII=document.getElementById("total_mucII");
    total_mucII.innerHTML = diemTuCham_10 + diemTuCham_7 + diemTuCham_8 + diemTuCham_9;

    //Muc III
    var diemTuCham_11 = parseInt(document.getElementsByClassName("diemTuCham_11")[2].value);
    var diemTuCham_12 = parseInt(document.getElementsByClassName("diemTuCham_12")[2].value);
    var diemTuCham_13 = parseInt(document.getElementsByClassName("diemTuCham_13")[2].value);
    var diemTuCham_14 = parseInt(document.getElementsByClassName("diemTuCham_14")[2].value);

    var txt_rs_hdct=document.getElementsByClassName("txt_rs_hdct")[2];
    txt_rs_hdct.innerHTML = diemTuCham_11 + diemTuCham_12 + diemTuCham_13 + diemTuCham_14;

    var total_mucIII=document.getElementById("total_mucIII");
    total_mucIII.innerHTML = diemTuCham_11 + diemTuCham_12 + diemTuCham_13 + diemTuCham_14;

    //Muc IV
    var diemTuCham_15 = parseInt(document.getElementsByClassName("diemTuCham_15")[2].value);
    var diemTuCham_16 = parseInt(document.getElementsByClassName("diemTuCham_16")[2].value);
    var diemTuCham_17 = parseInt(document.getElementsByClassName("diemTuCham_17")[2].value);
    var diemTuCham_18 = parseInt(document.getElementsByClassName("diemTuCham_18")[2].value);
    var diemTuCham_19 = parseInt(document.getElementsByClassName("diemTuCham_19")[2].value);

    var txt_rs_ytcd=document.getElementsByClassName("txt_rs_ytcd")[2];
    txt_rs_ytcd.innerHTML = diemTuCham_15 + diemTuCham_16 + diemTuCham_17 + diemTuCham_18 + diemTuCham_19;

    var total_mucIV=document.getElementById("total_mucIV");
    total_mucIV.innerHTML = diemTuCham_15 + diemTuCham_16 + diemTuCham_17 + diemTuCham_18 + diemTuCham_19;

    //Muc V
    var diemTuCham_20 = parseInt(document.getElementsByClassName("diemTuCham_20")[2].value);
    var diemTuCham_21 = parseInt(document.getElementsByClassName("diemTuCham_21")[2].value);
    var diemTuCham_22 = parseInt(document.getElementsByClassName("diemTuCham_22")[2].value);
    var diemTuCham_23 = parseInt(document.getElementsByClassName("diemTuCham_23")[2].value);

    var txt_rs_tgctl=document.getElementsByClassName("txt_rs_tgctl")[2];
    txt_rs_tgctl.innerHTML = diemTuCham_20 + diemTuCham_21 + diemTuCham_22 + diemTuCham_23;

    var total_mucV=document.getElementById("total_mucV");
    total_mucV.innerHTML = diemTuCham_20 + diemTuCham_21 + diemTuCham_22 + diemTuCham_23;
}
//Muc I
function YThucThamGiaHocTap(){  
    var diemTuCham_1 = parseInt(document.getElementsByClassName("diemTuCham_1")[2].value);
    var diemTuCham_2 = parseInt(document.getElementsByClassName("diemTuCham_2")[2].value);
    var diemTuCham_3 = parseInt(document.getElementsByClassName("diemTuCham_3")[2].value);
    var diemTuCham_4 = parseInt(document.getElementsByClassName("diemTuCham_4")[2].value);
    var diemTuCham_5 = parseInt(document.getElementsByClassName("diemTuCham_5")[2].value);
    var diemTuCham_6 = parseInt(document.getElementsByClassName("diemTuCham_6")[2].value);

  

  var txt_rs_yttght=document.getElementsByClassName("txt_rs_yttght")[2];
  var txt_total_mucI=document.getElementById("total_mucI");

    txt_rs_yttght.innerHTML = diemTuCham_1 + diemTuCham_2 + diemTuCham_3 + diemTuCham_4 + diemTuCham_5 + diemTuCham_6;

    txt_total_mucI.innerHTML = diemTuCham_1 + diemTuCham_2 + diemTuCham_3 + diemTuCham_4 + diemTuCham_5 + diemTuCham_6;

  Total();
}
//Muc III
function YThucThamGiaHoatDongChinhTri(){  
    var diemTuCham_11 = parseInt(document.getElementsByClassName("diemTuCham_11")[2].value);
    var diemTuCham_12 = parseInt(document.getElementsByClassName("diemTuCham_12")[2].value);
    var diemTuCham_13 = parseInt(document.getElementsByClassName("diemTuCham_13")[2].value);
    var diemTuCham_14 = parseInt(document.getElementsByClassName("diemTuCham_14")[2].value);


  var txt_rs_hdct=document.getElementsByClassName("txt_rs_hdct")[2];
    txt_rs_hdct.innerHTML = diemTuCham_11 + diemTuCham_12 + diemTuCham_13 + diemTuCham_14;

  var total_mucIII=document.getElementById("total_mucIII");
    total_mucIII.innerHTML = diemTuCham_11 + diemTuCham_12 + diemTuCham_13 + diemTuCham_14;
  Total();
}
//Muc IV
function YThucCongDan(){  
    var diemTuCham_15 = parseInt(document.getElementsByClassName("diemTuCham_15")[2].value);
    var diemTuCham_16 = parseInt(document.getElementsByClassName("diemTuCham_16")[2].value);
    var diemTuCham_17 = parseInt(document.getElementsByClassName("diemTuCham_17")[2].value);
    var diemTuCham_18 = parseInt(document.getElementsByClassName("diemTuCham_18")[2].value);
    var diemTuCham_19 = parseInt(document.getElementsByClassName("diemTuCham_19")[2].value);

  var txt_rs_ytcd=document.getElementsByClassName("txt_rs_ytcd")[2];
    txt_rs_ytcd.innerHTML = diemTuCham_15 + diemTuCham_16 + diemTuCham_17 + diemTuCham_18 + diemTuCham_19;

  var txt_total_mucIV=document.getElementById("total_mucIV");
    txt_total_mucIV.innerHTML = diemTuCham_15 + diemTuCham_16 + diemTuCham_17 + diemTuCham_18 + diemTuCham_19;
  Total();
}
//Muc V
function ThamGiaCongTacLop(){  
    var diemTuCham_20 = parseInt(document.getElementsByClassName("diemTuCham_20")[1].value);
    var diemTuCham_21 = parseInt(document.getElementsByClassName("diemTuCham_21")[1].value);
    var diemTuCham_22 = parseInt(document.getElementsByClassName("diemTuCham_22")[1].value);
    var diemTuCham_23 = parseInt(document.getElementsByClassName("diemTuCham_23")[1].value);

  var txt_rs_tgctl=document.getElementsByClassName("txt_rs_tgctl")[2];
    txt_rs_tgctl.innerHTML = diemTuCham_20 + diemTuCham_21 + diemTuCham_22 + diemTuCham_23;

  var txt_total_mucV=document.getElementById("total_mucV");
    txt_total_mucV.innerHTML = diemTuCham_20 + diemTuCham_21 + diemTuCham_22 + diemTuCham_23;
  Total();
}
function Total()
{

  var txt_rs_yttght=parseInt(document.getElementsByClassName("txt_rs_yttght")[2].innerHTML);
  var txt_rs_chny=parseInt(document.getElementsByClassName("txt_rs_chny")[2].innerHTML);
  var txt_rs_hdct=parseInt(document.getElementsByClassName("txt_rs_hdct")[2].innerHTML);
  var txt_rs_ytcd=parseInt(document.getElementsByClassName("txt_rs_ytcd")[2].innerHTML);
  var txt_rs_tgctl=parseInt(document.getElementsByClassName("txt_rs_tgctl")[2].innerHTML);

  
  var txt_total_Giaovien=document.getElementById("txt_total_Giaovien");
  txt_total_Giaovien.innerHTML=txt_rs_yttght+txt_rs_chny+txt_rs_hdct+txt_rs_ytcd+txt_rs_tgctl;
  var txt_drl=document.getElementById("txt_drl");
  txt_drl.innerHTML=txt_rs_yttght+txt_rs_chny+txt_rs_hdct+txt_rs_ytcd+txt_rs_tgctl;
  
}
function Total_Lop_Danh_Gia()
{
  var txt_rs_yttght=parseInt(document.getElementsByClassName("txt_rs_yttght")[1].innerHTML);
  var txt_rs_chny=parseInt(document.getElementsByClassName("txt_rs_chny")[1].innerHTML);
  var txt_rs_hdct=parseInt(document.getElementsByClassName("txt_rs_hdct")[1].innerHTML);
  var txt_rs_ytcd=parseInt(document.getElementsByClassName("txt_rs_ytcd")[1].innerHTML);
  var txt_rs_tgctl=parseInt(document.getElementsByClassName("txt_rs_tgctl")[1].innerHTML);

  var txt_total_Lop=document.getElementById("txt_total_Lop");
  txt_total_Lop.innerHTML=txt_rs_yttght+txt_rs_chny+txt_rs_hdct+txt_rs_ytcd+txt_rs_tgctl;
}

function Total_SinhVien_Danh_Gia()
{
  var txt_rs_yttght=parseInt(document.getElementsByClassName("txt_rs_yttght")[0].innerHTML);
  var txt_rs_chny=parseInt(document.getElementsByClassName("txt_rs_chny")[0].innerHTML);
  var txt_rs_hdct=parseInt(document.getElementsByClassName("txt_rs_hdct")[0].innerHTML);
  var txt_rs_ytcd=parseInt(document.getElementsByClassName("txt_rs_ytcd")[0].innerHTML);
  var txt_rs_tgctl=parseInt(document.getElementsByClassName("txt_rs_tgctl")[0].innerHTML);

  var txt_total=document.getElementById("txt_total");
  txt_total.innerHTML=txt_rs_yttght+txt_rs_chny+txt_rs_hdct+txt_rs_ytcd+txt_rs_tgctl;
}
//auto update point
