﻿using Models.EF;
using PagedList;
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
        public sinhVien findByGmail(String gmail)
        {
            sinhVien sinhVien = db.sinhViens.Where(x=>x.gmail.Equals(gmail)).SingleOrDefault();
            return sinhVien;
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

        public List<sinhVien> ListWhereAll(string maSinhVien)
        {
            return db.sinhViens.Where(x => x.maSinhVien == maSinhVien).ToList();
        }

        public string UpdatePersonalInfo(sinhVien sv)
        {
            var sinhVien = db.sinhViens.Find(sv.maSinhVien);
            if (sinhVien != null)
            {
                sinhVien.soDienThoai = sv.soDienThoai;
                sinhVien.gmail = sv.gmail;
            }
            db.SaveChanges();
            return sv.tenSinhVien;
        }
        
        public bool checkBHYTBySinhVienAndMaHocKy(sinhVien sinhVien, String maHocKy)
        {
            int trangThai = db.baoHiemYTes.Where(x => x.maHocKi.Equals(maHocKy)).Where(x => x.maSinhVien.Equals(sinhVien.maSinhVien)).SingleOrDefault().trangThai;
            if (trangThai == Constraints.Common.ACTIVATE)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public List<hocKi> ListHocKy()
        {
            return db.hocKis.OrderByDescending(x => x.maHocKi).ToList();
        }

        public IEnumerable<sinhVien> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<sinhVien> model = db.sinhViens;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.maSinhVien.Contains(keysearch));
            }
            return model.OrderBy(x => x.maSinhVien).ToPagedList(page, pagesize);
        }


    }
}
