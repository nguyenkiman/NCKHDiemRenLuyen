using Models.DAO;
using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Services
{
    public class sinhVienServices
    {
        sinhVienDAO sinhVienDAO = new sinhVienDAO();
        public sinhVien findByMaSinhVien(String maSinhVien)
        {
            return sinhVienDAO.findByMaSinhVien(maSinhVien);
        }
        public IPagedList<sinhVien> findByMaLop(String maLop,int pageIndex)
        {
            return sinhVienDAO.findByMaLop(maLop).ToPagedList(pageIndex, Constraints.Common.PAGE_SIZE);
        }
        public IPagedList<sinhVien> findByMaNganh(String maNganh, int pageIndex)
        {
            return sinhVienDAO.findByMaNganh(maNganh).ToPagedList(pageIndex, Constraints.Common.PAGE_SIZE);
        }
        public int checkLogin(String maSinhVien, String matKhau)
        {
            return sinhVienDAO.checkLogin(maSinhVien, matKhau);
        }
        public bool isCanBoLop(String maSinhVien)
        {
            return sinhVienDAO.isCanBoLop(maSinhVien);
        }
        public List<sinhVien> ListWhereAll(string maSinhVien)
        {
            return sinhVienDAO.ListWhereAll(maSinhVien);
        }
        public string UpdatePersonalInfo(sinhVien sv)
        {
            return sinhVienDAO.UpdatePersonalInfo(sv);
        }
    }
}
