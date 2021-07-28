using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class diemHocTapDAO
    {
        Db db = new Db();

        public IEnumerable<diemHocTap> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<diemHocTap> model = db.diemHocTaps;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.maSinhVien.Contains(keysearch));
            }
            return model.OrderBy(x => x.maSinhVien).ToPagedList(page, pagesize);
        }
    }
}
