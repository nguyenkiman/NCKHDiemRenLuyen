namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("noiDungDanhGia")]
    public partial class noiDungDanhGia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public noiDungDanhGia()
        {
            chiTietPhieuChams = new HashSet<chiTietPhieuCham>();
        }

        [Key]
        public int maNoiDung { get; set; }

        [Required]
        public string tenNoiDung { get; set; }

        public int? maDanhMuc { get; set; }

        public int diemToiDa { get; set; }

        public int cachCham { get; set; }

        public int trangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chiTietPhieuCham> chiTietPhieuChams { get; set; }

        public virtual danhMucDanhGia danhMucDanhGia { get; set; }
    }
}
