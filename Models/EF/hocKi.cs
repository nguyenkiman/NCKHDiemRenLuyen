namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hocKi")]
    public partial class hocKi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public hocKi()
        {
            baoHiemYTe = new HashSet<baoHiemYTe>();
            diemHocTap = new HashSet<diemHocTap>();
            hocPhi = new HashSet<hocPhi>();
            phieuChamDiem = new HashSet<phieuChamDiem>();
        }

        [Key]
        [StringLength(50)]
        public string maHocKi { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngayBatDauCham { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngayKetThucCham { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngayTao { get; set; }

        [StringLength(50)]
        public string nguoiTao { get; set; }

        public virtual admin admin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<baoHiemYTe> baoHiemYTe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<diemHocTap> diemHocTap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hocPhi> hocPhi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<phieuChamDiem> phieuChamDiem { get; set; }
    }
}
