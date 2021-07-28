using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Services
{
    public class giangVienServices
    {
        giangVienDAO giangVienDAO = new giangVienDAO();
        public int checkLoginGiangVien(String maGiaoVien, String matKhaus)
        {
            return giangVienDAO.checkLoginGiangVien(maGiaoVien, matKhaus);
        }
        public giangVien findByMaGiangVien(String maGiangVien)
        {
            return giangVienDAO.findByMaGiangVien(maGiangVien);
        }
        public List<giangVien> ListWhereAll(string maGiangVien)
        {
            return giangVienDAO.ListWhereAll(maGiangVien);
        }
        public List<giaoVienChuNhiem> ListClass(string maGiangVien)
        {
            return giangVienDAO.ListClass(maGiangVien);
        }
        public string UpdatePersonalInfo(giangVien gv)
        {
            return giangVienDAO.UpdatePersonalInfo(gv);
        }
        public List<giaoVienChuNhiem> ListGVCN(string maLop, string maGiangVien)
        {
            return giangVienDAO.ListGVCN(maLop, maGiangVien);
        }    
        public List<hocKi> ListHocKy()
        {
            return giangVienDAO.ListHocKy();
        }

        public object ListGVCN(object maLop, string userName)
        {
            throw new NotImplementedException();
        }
    }
}
