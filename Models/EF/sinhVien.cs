namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sinhVien")]
    public partial class sinhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sinhVien()
        {
            baoHiemYTe = new HashSet<baoHiemYTe>();
            canBoLop = new HashSet<canBoLop>();
            diemHocTap = new HashSet<diemHocTap>();
            hocPhi = new HashSet<hocPhi>();
            phieuChamDiem = new HashSet<phieuChamDiem>();
        }

        [Key]
        [StringLength(50)]
        public string maSinhVien { get; set; }

        [Required]
        public string matKhau { get; set; }

        [Required]
        public string tenSinhVien { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngaySinh { get; set; }

        [Required]
        public string soDienThoai { get; set; }

        [Required]
        public string gmail { get; set; }

        public int gioiTinh { get; set; }

        public int trangThai { get; set; }

        [StringLength(50)]
        public string maLop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<baoHiemYTe> baoHiemYTe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<canBoLop> canBoLop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<diemHocTap> diemHocTap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hocPhi> hocPhi { get; set; }

        public virtual lop lop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<phieuChamDiem> phieuChamDiem { get; set; }
    }
}
