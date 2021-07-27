$(document).ready(function () {
    LoadDiemSinhVien();
    Total_markDrl();
});

//auto update point 

function LoadDiemSinhVien() {
    //Muc I
    var diemTuCham_1 = parseInt(document.getElementsByClassName("diemTuCham_1")[0].value);
    var diemTuCham_2 = parseInt(document.getElementsByClassName("diemTuCham_2")[0].value);
    var diemTuCham_3 = parseInt(document.getElementsByClassName("diemTuCham_3")[0].value);
    var diemTuCham_4 = parseInt(document.getElementsByClassName("diemTuCham_4")[0].value);
    var diemTuCham_5 = parseInt(document.getElementsByClassName("diemTuCham_5")[0].value);
    var diemTuCham_6 = parseInt(document.getElementsByClassName("diemTuCham_6")[0].value);

    var txt_rs_yttght = document.getElementsByClassName("txt_rs_yttght")[0];
    txt_rs_yttght.innerHTML = diemTuCham_1 + diemTuCham_2 + diemTuCham_3 + diemTuCham_4 + diemTuCham_5 + diemTuCham_6;

    var total_mucI = document.getElementById("total_mucI");
    total_mucI.innerHTML = diemTuCham_1 + diemTuCham_2 + diemTuCham_3 + diemTuCham_4 + diemTuCham_5 + diemTuCham_6;
    //Muc II

    var diemTuCham_7 = parseInt(document.getElementsByClassName("diemTuCham_7")[0].value);
    var diemTuCham_8 = parseInt(document.getElementsByClassName("diemTuCham_8")[0].value);
    var diemTuCham_9 = parseInt(document.getElementsByClassName("diemTuCham_9")[0].value);
    var diemTuCham_10 = parseInt(document.getElementsByClassName("diemTuCham_10")[0].value);

    var txt_rs_chny = document.getElementsByClassName("txt_rs_chny")[0];
    txt_rs_chny.innerHTML = diemTuCham_10 + diemTuCham_7 + diemTuCham_8 + diemTuCham_9;

    var total_mucII = document.getElementById("total_mucII");
    total_mucII.innerHTML = diemTuCham_10 + diemTuCham_7 + diemTuCham_8 + diemTuCham_9;

    //Muc III
    var diemTuCham_11 = parseInt(document.getElementsByClassName("diemTuCham_11")[0].value);
    var diemTuCham_12 = parseInt(document.getElementsByClassName("diemTuCham_12")[0].value);
    var diemTuCham_13 = parseInt(document.getElementsByClassName("diemTuCham_13")[0].value);
    var diemTuCham_14 = parseInt(document.getElementsByClassName("diemTuCham_14")[0].value);

    var txt_rs_hdct = document.getElementsByClassName("txt_rs_hdct")[0];
    txt_rs_hdct.innerHTML = diemTuCham_11 + diemTuCham_12 + diemTuCham_13 + diemTuCham_14;

    var total_mucIII = document.getElementById("total_mucIII");
    total_mucIII.innerHTML = diemTuCham_11 + diemTuCham_12 + diemTuCham_13 + diemTuCham_14;

    //Muc IV
    var diemTuCham_15 = parseInt(document.getElementsByClassName("diemTuCham_15")[0].value);
    var diemTuCham_16 = parseInt(document.getElementsByClassName("diemTuCham_16")[0].value);
    var diemTuCham_17 = parseInt(document.getElementsByClassName("diemTuCham_17")[0].value);
    var diemTuCham_18 = parseInt(document.getElementsByClassName("diemTuCham_18")[0].value);
    var diemTuCham_19 = parseInt(document.getElementsByClassName("diemTuCham_19")[0].value);

    var txt_rs_ytcd = document.getElementsByClassName("txt_rs_ytcd")[0];
    txt_rs_ytcd.innerHTML = diemTuCham_15 + diemTuCham_16 + diemTuCham_17 + diemTuCham_18 + diemTuCham_19;

    var total_mucIV = document.getElementById("total_mucIV");
    total_mucIV.innerHTML = diemTuCham_15 + diemTuCham_16 + diemTuCham_17 + diemTuCham_18 + diemTuCham_19;

    //Muc V
    var diemTuCham_20 = parseInt(document.getElementsByClassName("diemTuCham_20")[0].value);
    var diemTuCham_21 = parseInt(document.getElementsByClassName("diemTuCham_21")[0].value);
    var diemTuCham_22 = parseInt(document.getElementsByClassName("diemTuCham_22")[0].value);
    var diemTuCham_23 = parseInt(document.getElementsByClassName("diemTuCham_23")[0].value);

    var txt_rs_tgctl = document.getElementsByClassName("txt_rs_tgctl")[0];
    txt_rs_tgctl.innerHTML = diemTuCham_20 + diemTuCham_21 + diemTuCham_22 + diemTuCham_23;

    var txt_total_mucV = document.getElementById("total_mucV");
    txt_total_mucV.innerHTML = diemTuCham_20 + diemTuCham_21 + diemTuCham_22 + diemTuCham_23;
}

//Muc I
function YThucThamGiaHocTap() {
    var txt_dtb = parseInt(document.getElementsByClassName("diemTuCham_1")[0].value);
    var txt_vuonlen = parseInt(document.getElementsByClassName("diemTuCham_2")[0].value);
    var txt_quychethi = parseInt(document.getElementsByClassName("diemTuCham_3")[0].value);
    var txt_nckh = parseInt(document.getElementsByClassName("diemTuCham_4")[0].value);
    var txt_clb = parseInt(document.getElementsByClassName("diemTuCham_5")[0].value);
    var txt_chuyencan = parseInt(document.getElementsByClassName("diemTuCham_6")[0].value);

    var txt_rs_yttght = document.getElementsByClassName("txt_rs_yttght")[0];
    var txt_total_mucI = document.getElementById("total_mucI");

    txt_rs_yttght.innerHTML = txt_dtb + txt_vuonlen + txt_quychethi + txt_nckh + txt_clb + txt_chuyencan;
    txt_total_mucI.innerHTML = txt_dtb + txt_vuonlen + txt_quychethi + txt_nckh + txt_clb + txt_chuyencan;
    Total_markDrl();
}

function QuyCheNhaTruong() {
    var txt_shcd = parseInt(document.getElementsByClassName("diemTuCham_7")[0].value);
    var txt_rlct = parseInt(document.getElementsByClassName("diemTuCham_8")[0].value);
    var txt_hdci = parseInt(document.getElementsByClassName("diemTuCham_9")[0].value);
    var txt_tnxh = parseInt(document.getElementsByClassName("diemTuCham_10")[0].value);


    var txt_rs_hdct = document.getElementsByClassName("txt_rs_chny")[0];
    txt_rs_hdct.innerHTML = txt_shcd + txt_rlct + txt_hdci + txt_tnxh;

    var total_mucIII = document.getElementById("total_mucII");
    total_mucIII.innerHTML = txt_shcd + txt_rlct + txt_hdci + txt_tnxh;
    Total_markDrl();
}
//Muc III


function YThucThamGiaHoatDongChinhTri() {
    var txt_shcd = parseInt(document.getElementsByClassName("diemTuCham_11")[0].value);
    var txt_rlct = parseInt(document.getElementsByClassName("diemTuCham_12")[0].value);
    var txt_hdci = parseInt(document.getElementsByClassName("diemTuCham_13")[0].value);
    var txt_tnxh = parseInt(document.getElementsByClassName("diemTuCham_14")[0].value);


    var txt_rs_hdct = document.getElementsByClassName("txt_rs_hdct")[0];
    txt_rs_hdct.innerHTML = txt_shcd + txt_rlct + txt_hdci + txt_tnxh;

    var total_mucIII = document.getElementById("total_mucIII");
    total_mucIII.innerHTML = txt_shcd + txt_rlct + txt_hdci + txt_tnxh;
    Total_markDrl();
}

//Muc IV
function YThucCongDan() {
    var txt_ctcd = parseInt(document.getElementsByClassName("diemTuCham_15")[0].value);
    var txt_bhyt = parseInt(document.getElementsByClassName("diemTuCham_16")[0].value);
    var txt_vhgt = parseInt(document.getElementsByClassName("diemTuCham_17")[0].value);
    var txt_hdxh = parseInt(document.getElementsByClassName("diemTuCham_18")[0].value);
    var txt_gdnkk = parseInt(document.getElementsByClassName("diemTuCham_19")[0].value);

    var txt_rs_ytcd = document.getElementsByClassName("txt_rs_ytcd")[0];
    txt_rs_ytcd.innerHTML = txt_ctcd + txt_bhyt + txt_vhgt + txt_hdxh + txt_gdnkk;

    var txt_total_mucIV = document.getElementById("total_mucIV");
    txt_total_mucIV.innerHTML = txt_ctcd + txt_bhyt + txt_vhgt + txt_hdxh + txt_gdnkk;
    Total_markDrl();
}
//Muc V
function ThamGiaCongTacLop() {
    var txt_qll = parseInt(document.getElementsByClassName("diemTuCham_20")[0].value);
    var txt_tcd = parseInt(document.getElementsByClassName("diemTuCham_21")[0].value);
    var txt_tghdl = parseInt(document.getElementsByClassName("diemTuCham_22")[0].value);
    var txt_dtt = parseInt(document.getElementsByClassName("diemTuCham_23")[0].value);

    var txt_rs_tgctl = document.getElementsByClassName("txt_rs_tgctl")[0];
    txt_rs_tgctl.innerHTML = txt_qll + txt_tcd + txt_tghdl + txt_dtt;

    var txt_total_mucV = document.getElementById("total_mucV");
    txt_total_mucV.innerHTML = txt_qll + txt_tcd + txt_tghdl + txt_dtt;
    Total_markDrl();
}
function Total_markDrl() {

    var txt_rs_yttght = parseInt(document.getElementsByClassName("txt_rs_yttght")[0].innerHTML);
    var txt_rs_chny = parseInt(document.getElementsByClassName("txt_rs_chny")[0].innerHTML);
    var txt_rs_hdct = parseInt(document.getElementsByClassName("txt_rs_hdct")[0].innerHTML);
    var txt_rs_ytcd = parseInt(document.getElementsByClassName("txt_rs_ytcd")[0].innerHTML);
    var txt_rs_tgctl = parseInt(document.getElementsByClassName("txt_rs_tgctl")[0].innerHTML);


    var txt_total = document.getElementById("txt_total");
    txt_total.innerHTML = txt_rs_yttght + txt_rs_chny + txt_rs_hdct + txt_rs_ytcd + txt_rs_tgctl;

    var txt_drl = document.getElementById("txt_drl");
    txt_drl.innerHTML = txt_rs_yttght + txt_rs_chny + txt_rs_hdct + txt_rs_ytcd + txt_rs_tgctl;


}