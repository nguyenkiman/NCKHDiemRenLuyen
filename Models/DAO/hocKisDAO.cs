using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class hocKisDAO
    {
        Db db = new Db();
        public IEnumerable<hocKi> ListWhereAll(string keysearch, int page, int pageSize)
        {
            if (!string.IsNullOrEmpty(keysearch))
                return db.hocKis.OrderByDescending(x => x.maHocKi).Where(x => x.maHocKi.Contains(keysearch)).ToPagedList(page, pageSize);
            return db.hocKis.OrderByDescending(x => x.maHocKi).ToPagedList(page, pageSize);
        }
    }
}
