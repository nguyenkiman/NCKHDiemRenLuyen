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
            baoHiemYTes = new HashSet<baoHiemYTe>();
            diemHocTaps = new HashSet<diemHocTap>();
            hocPhis = new HashSet<hocPhi>();
            phieuChamDiems = new HashSet<phieuChamDiem>();
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
        public virtual ICollection<baoHiemYTe> baoHiemYTes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<diemHocTap> diemHocTaps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hocPhi> hocPhis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<phieuChamDiem> phieuChamDiems { get; set; }
    }
}
