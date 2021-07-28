namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("diemHocTap")]
    public partial class diemHocTap
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string maSinhVien { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string maHocKi { get; set; }

        [Display(Name = "Điểm trung bình")]
        public double? diemTrungBinh { get; set; }

        public virtual hocKi hocKi { get; set; }

        public virtual sinhVien sinhVien { get; set; }
    }
}
