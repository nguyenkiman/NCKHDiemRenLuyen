using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class sinhVienDAO
    {
         Db db =  new Db();
        
        public sinhVien findByMaSinhVien(String maSinhVien)
        {
            sinhVien sinhVien =  db.sinhViens.Find(maSinhVien);
            if(sinhVien.trangThai == Constraints.Common.ACTIVATE)
            {
                return sinhVien;
            }
            else
            {
                return null;
            }
        }
        public ICollection<sinhVien> findByMaLop(String maLop)
        {
            return db.lops.Where(x => x.maLop.Equals(maLop)).Where(x => x.trangThai == Constraints.Common.ACTIVATE).SingleOrDefault().sinhViens;
        }
        public ICollection<sinhVien> findByMaNganh(String maNganh)
        {
            ICollection<lop> lops = db.nganhs.Where(x => x.maNganh.Equals(maNganh)).Where(x => x.trangThai == Constraints.Common.ACTIVATE).SingleOrDefault().lops;
            List<sinhVien> result = new List<sinhVien>();
            foreach (lop templop in lops){
                result.Concat(templop.sinhViens);
            }
            return result;
        }
        public int checkLogin(String maSinhVien,String matKhau)
        {
            sinhVien sinhVien = db.sinhViens.Find(maSinhVien);
            if(sinhVien is null)
            {
                return Constraints.Common.ACCOUNT_NOT_EXISTS;
            }
            else
            {
                if (sinhVien.matKhau.Equals(matKhau))
                {
                    if (sinhVien.trangThai == Constraints.Common.INACTIVATE)
                    {
                        return Constraints.Common.BLOCK;
                    }
                    else
                    {
                        return Constraints.Common.LOGIN_SUCCESS;
                    }
                }
                else
                {
                    return Constraints.Common.INVALID_PASSWORDS;
                }
            }
        }
        public bool isCanBoLop(String maSinhVien)
        {
            canBoLop canBoLop = db.canBoLops.Where(x => x.maSinhVien.Equals(maSinhVien)).Where(x => x.trangThai == Constraints.Common.ACTIVATE).SingleOrDefault();
            if(canBoLop is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
