$(document).ready(function()
{
  LoadDiemSinhVien();
  Total_markDrl();
});

//auto update point 

function LoadDiemSinhVien()
{
    //Muc I
    var txt_dtb= parseInt(document.getElementsByClassName("txt_dtb")[0].innerHTML);
    var txt_vuonlen= parseInt(document.getElementsByClassName("txt_vuonlen")[0].value);
    var txt_quychethi= parseInt(document.getElementsByClassName("txt_quychethi")[0].innerHTML);
    var txt_nckh= parseInt(document.getElementsByClassName("txt_nckh")[0].innerHTML);
    var txt_clb= parseInt(document.getElementsByClassName("txt_clb")[0].value);
    var txt_chuyencan= parseInt(document.getElementsByClassName("txt_chuyencan")[0].innerHTML);

    var txt_rs_yttght=document.getElementsByClassName("txt_rs_yttght")[0];
    txt_rs_yttght.innerHTML=txt_dtb+txt_vuonlen+txt_quychethi+txt_nckh+txt_clb+txt_chuyencan;

    var total_mucI=document.getElementById("total_mucI");
    total_mucI.innerHTML=txt_dtb+txt_vuonlen+txt_quychethi+txt_nckh+txt_clb+txt_chuyencan;
   //Muc II
    var txt_vbcd= parseInt(document.getElementsByClassName("txt_vbcd")[0].innerHTML);
    var txt_vd= parseInt(document.getElementsByClassName("txt_vd")[0].innerHTML);
    var txt_noiquy= parseInt(document.getElementsByClassName("txt_noiquy")[0].innerHTML);
    var txt_hocphi= parseInt(document.getElementsByClassName("txt_hocphi")[0].innerHTML);

    var txt_rs_chny=document.getElementsByClassName("txt_rs_chny")[0];
    txt_rs_chny.innerHTML=txt_vbcd+txt_vd+txt_noiquy+txt_hocphi;

    var total_mucII=document.getElementById("total_mucII");
    total_mucII.innerHTML=txt_vbcd+txt_vd+txt_noiquy+txt_hocphi;

    //Muc III
    var txt_shcd= parseInt(document.getElementsByClassName("txt_shcd")[0].innerHTML);
    var txt_rlct= parseInt(document.getElementsByClassName("txt_rlct")[0].value);
    var txt_hdci= parseInt(document.getElementsByClassName("txt_hdci")[0].value);
    var txt_tnxh= parseInt(document.getElementsByClassName("txt_tnxh")[0].value);

    var txt_rs_hdct=document.getElementsByClassName("txt_rs_hdct")[0];
    txt_rs_hdct.innerHTML=txt_shcd+txt_rlct+txt_hdci+txt_tnxh;

    var total_mucIII=document.getElementById("total_mucIII");
    total_mucIII.innerHTML=txt_shcd+txt_rlct+txt_hdci+txt_tnxh;

    //Muc IV
    var txt_ctcd= parseInt(document.getElementsByClassName("txt_ctcd")[0].innerHTML);
    var txt_bhyt= parseInt(document.getElementsByClassName("txt_bhyt")[0].innerHTML);
    var txt_vhgt= parseInt(document.getElementsByClassName("txt_vhgt")[0].innerHTML);
    var txt_tnxh= parseInt(document.getElementsByClassName("txt_hdxh")[0].value);
    var txt_gdnkk= parseInt(document.getElementsByClassName("txt_gdnkk")[0].value);

    var txt_rs_ytcd=document.getElementsByClassName("txt_rs_ytcd")[0];
    txt_rs_ytcd.innerHTML=txt_ctcd+txt_bhyt+txt_vhgt+txt_tnxh+txt_gdnkk;

    var total_mucIV=document.getElementById("total_mucIV");
    total_mucIV.innerHTML=txt_ctcd+txt_bhyt+txt_vhgt+txt_tnxh+txt_gdnkk;

    //Muc V
    var txt_qll= parseInt(document.getElementsByClassName("txt_qll")[0].value);
    var txt_tcd= parseInt(document.getElementsByClassName("txt_tcd")[0].value);
    var txt_tghdl= parseInt(document.getElementsByClassName("txt_tghdl")[0].value);
    var txt_dtt= parseInt(document.getElementsByClassName("txt_dtt")[0].value);

    var txt_rs_tgctl=document.getElementsByClassName("txt_rs_tgctl")[0];
    txt_rs_tgctl.innerHTML=txt_qll+txt_tcd+txt_tghdl+txt_dtt;

    var txt_total_mucV=document.getElementById("total_mucV");
    txt_total_mucV.innerHTML=txt_qll+txt_tcd+txt_tghdl+txt_dtt;
}

//Muc I
function YThucThamGiaHocTap(){  
     var txt_dtb= parseInt(document.getElementsByClassName("txt_dtb")[0].innerHTML);
    var txt_vuonlen= parseInt(document.getElementsByClassName("txt_vuonlen")[0].value);
    var txt_quychethi= parseInt(document.getElementsByClassName("txt_quychethi")[0].innerHTML);
    var txt_nckh= parseInt(document.getElementsByClassName("txt_nckh")[0].innerHTML);
    var txt_clb= parseInt(document.getElementsByClassName("txt_clb")[0].value);
    var txt_chuyencan= parseInt(document.getElementsByClassName("txt_chuyencan")[0].innerHTML);
    
    var txt_rs_yttght=document.getElementsByClassName("txt_rs_yttght")[0];
    var txt_total_mucI=document.getElementById("total_mucI");

    txt_rs_yttght.innerHTML=txt_dtb+txt_vuonlen+txt_quychethi+txt_nckh+txt_clb+txt_chuyencan;
    txt_total_mucI.innerHTML=txt_dtb+txt_vuonlen+txt_quychethi+txt_nckh+txt_clb+txt_chuyencan;
    Total_markDrl();
}
//Muc III
function YThucThamGiaHoatDongChinhTri(){  
  var txt_shcd= parseInt(document.getElementsByClassName("txt_shcd")[0].innerHTML);
  var txt_rlct= parseInt(document.getElementsByClassName("txt_rlct")[0].value);
  var txt_hdci= parseInt(document.getElementsByClassName("txt_hdci")[0].value);
  var txt_tnxh= parseInt(document.getElementsByClassName("txt_tnxh")[0].value);


  var txt_rs_hdct=document.getElementsByClassName("txt_rs_hdct")[0];
  txt_rs_hdct.innerHTML=txt_shcd+txt_rlct+txt_hdci+txt_tnxh;

  var total_mucIII=document.getElementById("total_mucIII");
  total_mucIII.innerHTML=txt_shcd+txt_rlct+txt_hdci+txt_tnxh;
  Total_markDrl();
}

//Muc IV
function YThucCongDan(){  
  var txt_ctcd= parseInt(document.getElementsByClassName("txt_ctcd")[0].innerHTML);
  var txt_bhyt= parseInt(document.getElementsByClassName("txt_bhyt")[0].innerHTML);
  var txt_vhgt= parseInt(document.getElementsByClassName("txt_vhgt")[0].innerHTML);
  var txt_hdxh= parseInt(document.getElementsByClassName("txt_hdxh")[0].value);
  var txt_gdnkk= parseInt(document.getElementsByClassName("txt_gdnkk")[0].value);

  var txt_rs_ytcd=document.getElementsByClassName("txt_rs_ytcd")[0];
  txt_rs_ytcd.innerHTML=txt_ctcd+txt_bhyt+txt_vhgt+txt_hdxh+txt_gdnkk;

  var txt_total_mucIV=document.getElementById("total_mucIV");
  txt_total_mucIV.innerHTML=txt_ctcd+txt_bhyt+txt_vhgt+txt_hdxh+txt_gdnkk;
  Total_markDrl();
}
//Muc V
function ThamGiaCongTacLop(){  
  var txt_qll= parseInt(document.getElementsByClassName("txt_qll")[0].value);
  var txt_tcd= parseInt(document.getElementsByClassName("txt_tcd")[0].value);
  var txt_tghdl= parseInt(document.getElementsByClassName("txt_tghdl")[0].value);
  var txt_dtt= parseInt(document.getElementsByClassName("txt_dtt")[0].value);

  var txt_rs_tgctl=document.getElementsByClassName("txt_rs_tgctl")[0];
  txt_rs_tgctl.innerHTML=txt_qll+txt_tcd+txt_tghdl+txt_dtt;

  var txt_total_mucV=document.getElementById("total_mucV");
  txt_total_mucV.innerHTML=txt_qll+txt_tcd+txt_tghdl+txt_dtt;
  Total_markDrl();
}
function Total_markDrl()
{

  var txt_rs_yttght=parseInt(document.getElementsByClassName("txt_rs_yttght")[0].innerHTML);
  var txt_rs_chny=parseInt(document.getElementsByClassName("txt_rs_chny")[0].innerHTML);
  var txt_rs_hdct=parseInt(document.getElementsByClassName("txt_rs_hdct")[0].innerHTML);
  var txt_rs_ytcd=parseInt(document.getElementsByClassName("txt_rs_ytcd")[0].innerHTML);
  var txt_rs_tgctl=parseInt(document.getElementsByClassName("txt_rs_tgctl")[0].innerHTML);

  
  var txt_total=document.getElementById("txt_total");
  txt_total.innerHTML=txt_rs_yttght+txt_rs_chny+txt_rs_hdct+txt_rs_ytcd+txt_rs_tgctl;

  var txt_drl=document.getElementById("txt_drl");
  txt_drl.innerHTML=txt_rs_yttght+txt_rs_chny+txt_rs_hdct+txt_rs_ytcd+txt_rs_tgctl;


}

//auto update point