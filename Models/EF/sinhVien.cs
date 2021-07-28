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
            baoHiemYTes = new HashSet<baoHiemYTe>();
            canBoLops = new HashSet<canBoLop>();
            diemHocTaps = new HashSet<diemHocTap>();
            hocPhis = new HashSet<hocPhi>();
            phieuChamDiems = new HashSet<phieuChamDiem>();
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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Không được để trống số điện thoại")]
        [Phone(ErrorMessage = "Please enter a valid Phone No")]
        public string soDienThoai { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Không được để trống gmail")]
        public string gmail { get; set; }

        public int gioiTinh { get; set; }

        public int trangThai { get; set; }

        [StringLength(50)]
        public string maLop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<baoHiemYTe> baoHiemYTes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<canBoLop> canBoLops { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<diemHocTap> diemHocTaps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hocPhi> hocPhis { get; set; }

        public virtual lop lop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<phieuChamDiem> phieuChamDiems { get; set; }
    }
}
