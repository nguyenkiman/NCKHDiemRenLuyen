using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Services
{
    public class ResetmatkhauServices
    {
        giangVienDAO giangVien = new giangVienDAO();
        sinhVienServices s = new sinhVienServices();
        public void resetmatkhau(string userField) {
            if(s.findByGmail(userField) is null)
            {
                if(giangVien.findBygmai(userField) is null)
                {

                }
                else
                {

                }
            }
        }
    }
}
