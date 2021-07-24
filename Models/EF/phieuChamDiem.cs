namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("phieuChamDiem")]
    public partial class phieuChamDiem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public phieuChamDiem()
        {
            chiTietPhieuChams = new HashSet<chiTietPhieuCham>();
        }

        [Key]
        public int maPhieuChamDiem { get; set; }

        [StringLength(50)]
        public string maSinhVien { get; set; }

        [StringLength(50)]
        public string maHocKi { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngayCham { get; set; }

        public int trangThai { get; set; }

        public int tongDiem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chiTietPhieuCham> chiTietPhieuChams { get; set; }

        public virtual hocKi hocKi { get; set; }

        public virtual sinhVien sinhVien { get; set; }
    }
}
