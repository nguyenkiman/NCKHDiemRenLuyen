using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Services
{
    public class phieuChamDiemServices
    {
        noiDungDanhGiaDAO noiDungDanhGiaDAO = new noiDungDanhGiaDAO();
        sinhVienDAO sinhVienDAO = new sinhVienDAO();
        hocKiServices hocKiServices = new hocKiServices();
        sinhVienServices sinhVienServices = new sinhVienServices();
        const int BHYT = 16;
        const int DTBCHK = 6;
        const int HOCPHI = 10;

        Db db = new Db();
        public int getDRLNoiDungBHYT(string masv, string mahocki)
        {
            var query = (from bhyt in db.baoHiemYTes
                         where bhyt.maSinhVien.Equals(masv) && bhyt.maHocKi.Equals(mahocki)
                         select bhyt).FirstOrDefault();
            //int trangThai = db.baoHiemYTes.Where(x => x.maSinhVien.Equals(masv)).Where(x => x.maHocKi.Equals(mahocki)).SingleOrDefault().trangThai;
            if (query is null)
            {
                return 0;
            }
            int trangThai = query.trangThai;
            if (trangThai == Constraints.Common.ACTIVATE)
            {
                return db.noiDungDanhGias.Find(BHYT).diemToiDa;
            }
            else
            {
                return 0;
            }
        }

        public int getDRLNoiDungHocPhi(string masv, string mahocki)
        {
            //int trangThai = db.hocPhis.Where(x => x.maSinhVien.Equals(masv)).Where(x => x.maHocKi.Equals(mahocki)).SingleOrDefault().trangThai;
            var query = (from hp in db.hocPhis
                         where hp.maSinhVien.Equals(masv) && hp.maHocKi.Equals(mahocki)
                         select hp).FirstOrDefault();

            if (query is null)
            {
                return 0;
            }
            int trangThai = query.trangThai;
            if (trangThai == Constraints.Common.ACTIVATE)
            {
                return db.noiDungDanhGias.Find(HOCPHI).diemToiDa;
            }
            else
            {
                return 0;
            }
        }
        public int getDRLNoiDungDTBCHK(string masv, string mahocki)
        {
            //double diemTrungBinh = (double)db.diemHocTaps.Where(x => x.maSinhVien.Equals(masv)).Where(x => x.maHocKi.Equals(mahocki)).SingleOrDefault().diemTrungBinh;
            var query = (from dht in db.diemHocTaps
                         where dht.maSinhVien.Equals(masv) && dht.maHocKi.Equals(mahocki)
                         select dht).FirstOrDefault();
            if (query is null)
            {
                return 0;
            }
            double diemTrungBinh = (double)query.diemTrungBinh;

            if (diemTrungBinh >= 3.2)
            {
                return 4;
            }
            else
            {
                if (diemTrungBinh >= 2.0)
                {
                    return 2;
                }
                else
                {
                    return 0;
                }
            }
        }

        public phieuChamDiem generateNewPhieuChamDiem(string masv)
        {
            phieuChamDiem newPhieuChamDiem = new phieuChamDiem();
            newPhieuChamDiem.maSinhVien = masv;
            newPhieuChamDiem.sinhVien = sinhVienServices.findByMaSinhVien(masv);
            newPhieuChamDiem.maHocKi = hocKiServices.getCurrentHocKi().maHocKi;
            newPhieuChamDiem.hocKi = hocKiServices.getCurrentHocKi();
            List<chiTietPhieuCham> chiTietPhieuChams = new List<chiTietPhieuCham>();
            IQueryable<noiDungDanhGia> noiDungDanhGias = noiDungDanhGiaDAO.findAll();
            foreach (noiDungDanhGia noiDung in noiDungDanhGias)
            {
                chiTietPhieuCham chiTietPhieuCham = new chiTietPhieuCham();
                chiTietPhieuCham.maNoiDung = noiDung.maNoiDung;
                chiTietPhieuCham.noiDungDanhGia = noiDung;

                if (noiDung.maNoiDung == DTBCHK)
                {
                    chiTietPhieuCham.diemTuCham = getDRLNoiDungDTBCHK(masv, newPhieuChamDiem.maHocKi);
                    chiTietPhieuCham.diemCBLCham = getDRLNoiDungDTBCHK(masv, newPhieuChamDiem.maHocKi);
                    chiTietPhieuCham.diemGVCNCham = getDRLNoiDungDTBCHK(masv, newPhieuChamDiem.maHocKi);
                }
                if (noiDung.maNoiDung == BHYT)
                {
                    chiTietPhieuCham.diemTuCham = getDRLNoiDungBHYT(masv, newPhieuChamDiem.maHocKi);
                    chiTietPhieuCham.diemCBLCham = getDRLNoiDungBHYT(masv, newPhieuChamDiem.maHocKi);
                    chiTietPhieuCham.diemGVCNCham = getDRLNoiDungBHYT(masv, newPhieuChamDiem.maHocKi);
                }
                if (noiDung.maNoiDung == HOCPHI)
                {
                    chiTietPhieuCham.diemTuCham = getDRLNoiDungHocPhi(masv, newPhieuChamDiem.maHocKi);
                    chiTietPhieuCham.diemCBLCham = getDRLNoiDungHocPhi(masv, newPhieuChamDiem.maHocKi);
                    chiTietPhieuCham.diemGVCNCham = getDRLNoiDungHocPhi(masv, newPhieuChamDiem.maHocKi);
                }
                chiTietPhieuChams.Add(chiTietPhieuCham);
            }
            newPhieuChamDiem.chiTietPhieuChams = chiTietPhieuChams;
            return newPhieuChamDiem;
        }
        public phieuChamDiem findByMaSinhVienAndMaHocKy(string maSinhVien,string maHocKi)
        {
            var query = (from dht in db.phieuChamDiems
                         where dht.maSinhVien.Equals(maSinhVien) && dht.maHocKi.Equals(maHocKi)
                         select dht).FirstOrDefault();
            return query;
        }
        public void saveChiTietPhieuCham(int maPhieuCham,int maNoiDung,int diemTuCham,int dienCBLCham,int diemGVCNCham,string minhChung)
        {
            chiTietPhieuCham noidung1 = new chiTietPhieuCham();
            noidung1.maNoiDung = maNoiDung;
            noidung1.diemTuCham = diemTuCham;
            noidung1.diemCBLCham = dienCBLCham;
            noidung1.diemGVCNCham = diemGVCNCham;
            noidung1.minhChung = minhChung;
            noidung1.maPhieuChamDiem = maPhieuCham;
            try
            {
                
                db.chiTietPhieuChams.Add(noidung1);
                db.SaveChanges();
            }
            catch
            {
                db.Entry(noidung1).State = EntityState.Modified;
                db.SaveChanges();

            }
        }
        public void CBLUpdateChiTietPhieuCham(int maPhieuCham,int maNoiDung,int diemCBLCham)
        {
            var query = (from dht in db.chiTietPhieuChams
                         where dht.maPhieuChamDiem.Equals(maPhieuCham) && dht.maNoiDung.Equals(maNoiDung)
                         select dht).FirstOrDefault();
            query.diemCBLCham = diemCBLCham;
            db.Entry(query).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
