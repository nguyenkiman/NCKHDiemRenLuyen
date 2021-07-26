using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class noiDungDanhGiaDAO
    {
        Db db = new Db();
        public IQueryable<noiDungDanhGia> findAll()
        {
            return db.noiDungDanhGias.Where(x => x.trangThai == Constraints.Common.ACTIVATE);
        }
    }
}
