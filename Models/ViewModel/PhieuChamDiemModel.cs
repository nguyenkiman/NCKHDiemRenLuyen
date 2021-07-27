using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class PhieuChamDiemModel
    {
        [Required]
        public string maSinhVien { get; set; }
        public string tenSinhVien { get; set; }
        public int tongDiem { get; set; }

        public PhieuChamDiemModel()
        { }
        public PhieuChamDiemModel(string maSinhVien, string tenSinhVien, int tongDiem)
        {
            this.maSinhVien = maSinhVien;
            this.tenSinhVien = tenSinhVien;
            this.tongDiem = tongDiem;
        }
    }
}
