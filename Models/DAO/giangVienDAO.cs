﻿using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class giangVienDAO
    {
        Db db = new Db();

        public int checkLoginGiangVien(String maGiaoVien, String matKhaus)
        {
            giangVien giangVien = db.giangViens.Find(maGiaoVien);
            if (giangVien is null)
            {
                return Constraints.Common.ACCOUNT_NOT_EXISTS;
            }
            else
            {
                if (giangVien.matKhau.Equals(matKhaus))
                {
                    if (giangVien.trangThai == Constraints.Common.ACTIVATE)
                    {
                        return Constraints.Common.LOGIN_SUCCESS;
                    }
                    else
                    {
                        return Constraints.Common.BLOCK;
                    }
                }
                else
                {
                    return Constraints.Common.INVALID_PASSWORDS;
                }
            }
        }

        public giangVien findByMaGiangVien(String maGiangVien)
        {
            giangVien giangVien = db.giangViens.Find(maGiangVien);
            if (giangVien.trangThai == Constraints.Common.ACTIVATE)
            {
                return giangVien;
            }
            else
            {
                return null;
            }
        }
        public List<giangVien> ListWhereAll(string maGiangVien)
        {
            return db.giangViens.Where(x => x.maGiangVien == maGiangVien).ToList();
        }
        public List<giaoVienChuNhiem> ListClass(string maGiangVien)
        {
            return db.giaoVienChuNhiems.Where(x => x.maGiangVien == maGiangVien).ToList();
        }
        public string UpdatePersonalInfo(giangVien gv)
        {
            var giangVien = db.giangViens.Find(gv.maGiangVien);
            if (giangVien != null)
            {
                giangVien.soDienThoai = gv.soDienThoai;
                giangVien.gmail = gv.gmail;
            }
            db.SaveChanges();
            return gv.tenGiangVien;

        }
        public List<hocKi> ListHocKy()
        {
            return db.hocKis.ToList();
        }
    }
}
