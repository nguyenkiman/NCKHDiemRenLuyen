using Models.EF;
using PagedList;
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
        public IEnumerable<giangVien> ListWhereAll(string keysearch, int page, int pageSize)
        {
            if (!string.IsNullOrEmpty(keysearch))
                return db.giangViens.OrderByDescending(x => x.trangThai).ThenByDescending(x => x.maGiangVien).Where(x => x.maGiangVien.Contains(keysearch) || x.tenGiangVien.Contains(keysearch)).ToPagedList(page, pageSize);
            return db.giangViens.OrderByDescending(x => x.trangThai).ThenByDescending(x => x.maGiangVien).ToPagedList(page, pageSize);
        }
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
        public giangVien findBygmai(String maGiangVien)
        {
            return db.giangViens.Where(x => x.gmail.Equals(maGiangVien)).SingleOrDefault();
           
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
        public List<giaoVienChuNhiem> ListGVCN(string maLop, string maGiangVien)
        {
            return db.giaoVienChuNhiems.Where(x => x.maLop.Equals(maLop)).Where(x => x.maGiangVien.Equals(maGiangVien)).ToList();
        }
        public List<hocKi> ListHocKy()
        {
            return db.hocKis.OrderByDescending(x => x.maHocKi).ToList();
        }
    }
}
