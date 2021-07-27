using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class adminDAO
    {
        Db db = new Db();
        public int checkLogin(String maAdmin, String matKhau)
        {
            admin admin = db.admin.Find(maAdmin);
            if(admin is null)
            {
                return Constraints.Common.ACCOUNT_NOT_EXISTS;
                
            }
            else
            {
                if (admin.trangThai == 0)
                {
                    return Constraints.Common.BLOCK;
                }
                else
                {
                    if (admin.matKhau.Equals(matKhau))
                    {
                        return Constraints.Common.LOGIN_SUCCESS;
                    }
                    else
                    {
                        return Constraints.Common.INVALID_PASSWORDS;
                    }
                }
            }
        }
    }
}
