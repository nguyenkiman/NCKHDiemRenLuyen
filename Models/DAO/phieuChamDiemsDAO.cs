using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class phieuChamDiemsDAO
    {
        Db db = new Db();
        public IEnumerable<phieuChamDiem> ListWhereAll(string keysearch, int page, int pageSize)
        {
            if (!string.IsNullOrEmpty(keysearch))
                return db.phieuChamDiems.OrderByDescending(x => x.maHocKi).ThenByDescending(x=> x.sinhVien.tenSinhVien).Where(x => x.maHocKi.Contains(keysearch) || x.sinhVien.tenSinhVien.Contains(keysearch)).ToPagedList(page, pageSize);
            return db.phieuChamDiems.OrderByDescending(x => x.maHocKi).ThenByDescending(x => x.sinhVien.tenSinhVien).ToPagedList(page, pageSize);
        }
    }
}
