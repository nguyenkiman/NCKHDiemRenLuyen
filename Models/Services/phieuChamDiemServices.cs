using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Services
{
    public class phieuChamDiemServices
    {
        noiDungDanhGiaDAO noiDungDanhGiaDAO = new noiDungDanhGiaDAO();
        const int BHYT = 1;
        public phieuChamDiem generateNewPhieuChamDiem(String masv)
        {
            phieuChamDiem newPhieuChamDiem = new phieuChamDiem();
            newPhieuChamDiem.maSinhVien = masv;
            List<chiTietPhieuCham> chiTietPhieuChams = new List<chiTietPhieuCham>();
            IQueryable<noiDungDanhGia> noiDungDanhGias = noiDungDanhGiaDAO.findAll();
            foreach(noiDungDanhGia noiDung in noiDungDanhGias)
            {
                chiTietPhieuCham chiTietPhieuCham = new chiTietPhieuCham();
                chiTietPhieuCham.maNoiDung = noiDung.maNoiDung;
                
                if(noiDung.maNoiDung == 1) { }

            }
            return newPhieuChamDiem;
        }
    }
}
