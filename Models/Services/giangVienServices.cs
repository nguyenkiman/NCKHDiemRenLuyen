using Models.DAO;
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
    }
}
