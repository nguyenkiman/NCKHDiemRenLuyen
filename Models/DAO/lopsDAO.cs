using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class lopsDAO
    {
        Db db = new Db();
        public IPagedList<lop> ListWhereAll(string keysearch, int page, int pageSize)
        {
            if (!string.IsNullOrEmpty(keysearch))
                return db.lops.OrderByDescending(x => x.trangThai).Where(x => x.maLop.Contains(keysearch)).ToPagedList(page, pageSize);
            return db.lops.OrderByDescending(x => x.trangThai).ToPagedList(page, pageSize);
        }
    }
}
