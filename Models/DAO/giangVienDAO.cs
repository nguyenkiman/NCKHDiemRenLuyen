using Models.EF;
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
    }
}
