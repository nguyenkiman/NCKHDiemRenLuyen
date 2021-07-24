namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("giaoVienChuNhiem")]
    public partial class giaoVienChuNhiem
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string maGiangVien { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string maLop { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngayBatDau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayKetThuc { get; set; }

        public int trangThai { get; set; }

        public virtual giangVien giangVien { get; set; }

        public virtual lop lop { get; set; }
    }
}
