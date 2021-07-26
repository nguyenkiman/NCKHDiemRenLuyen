namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("giangVien")]
    public partial class giangVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public giangVien()
        {
            giaoVienChuNhiem = new HashSet<giaoVienChuNhiem>();
        }

        [Key]
        [StringLength(50)]
        public string maGiangVien { get; set; }

        [Required]
        public string tenGiangVien { get; set; }

        [Required]
        public string matKhau { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngaySinh { get; set; }

        [Required]
        public string soDienThoai { get; set; }

        [Required]
        public string gmail { get; set; }

        public int gioiTinh { get; set; }

        public int trangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<giaoVienChuNhiem> giaoVienChuNhiem { get; set; }
    }
}
