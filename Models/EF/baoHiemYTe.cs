namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("baoHiemYTe")]
    public partial class baoHiemYTe
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string maSinhVien { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string maHocKi { get; set; }

        public int trangThai { get; set; }

        public virtual hocKi hocKi { get; set; }

        public virtual sinhVien sinhVien { get; set; }
    }
}
