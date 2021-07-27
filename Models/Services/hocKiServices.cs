using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Services
{
    public class hocKiServices
    {
        Db db = new Db();
        public hocKi getCurrentHocKi()
        {
            hocKi result = db.hocKis.OrderByDescending(x => x.ngayKetThucCham).First();
            //if(result.ngayKetThucCham > DateTime.Today)
            //{
            //    return null;
            //}
            int res = DateTime.Compare(result.ngayKetThucCham, DateTime.Today);
            if(res < 0)
            {
                return null;
            }
            return result;
        }
    }
}
