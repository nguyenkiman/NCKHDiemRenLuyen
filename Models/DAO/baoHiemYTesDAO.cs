using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class baoHiemYTesDAO
    {
        Db db = new Db();
        public IEnumerable<baoHiemYTe> ListWhereAll(string keysearch, int page, int pageSize)
        {
            if (!string.IsNullOrEmpty(keysearch))
                return db.baoHiemYTes.OrderByDescending(x => x.maHocKi).ThenByDescending(x => x.trangThai).Where(x => x.sinhVien.tenSinhVien.Contains(keysearch) || x.maSinhVien.Contains(keysearch) || x.sinhVien.maLop.Contains(keysearch)).ToPagedList(page, pageSize);
            return db.baoHiemYTes.OrderByDescending(x => x.maHocKi).ThenByDescending(x => x.trangThai).ToPagedList(page, pageSize);
        }
    }
}
