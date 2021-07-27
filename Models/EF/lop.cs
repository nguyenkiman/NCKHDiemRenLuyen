namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("lop")]
    public partial class lop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public lop()
        {
            canBoLop = new HashSet<canBoLop>();
            giaoVienChuNhiem = new HashSet<giaoVienChuNhiem>();
            sinhVien = new HashSet<sinhVien>();
        }

        [Key]
        [StringLength(50)]
        public string maLop { get; set; }

        [StringLength(50)]
        public string maNganh { get; set; }

        public int trangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<canBoLop> canBoLop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<giaoVienChuNhiem> giaoVienChuNhiem { get; set; }

        public virtual nganh nganh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sinhVien> sinhVien { get; set; }
    }
}
