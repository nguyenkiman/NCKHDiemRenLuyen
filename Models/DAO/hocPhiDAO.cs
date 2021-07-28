using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class hocPhiDAO
    {
        Db db = new Db();

        public IEnumerable<hocPhi> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<hocPhi> model = db.hocPhis;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.maSinhVien.Contains(keysearch));
            }
            return model.OrderBy(x => x.maSinhVien).ToPagedList(page, pagesize);
        }
    }
}
