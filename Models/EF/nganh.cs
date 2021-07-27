namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nganh")]
    public partial class nganh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nganh()
        {
            lops = new HashSet<lop>();
        }

        [Key]
        [StringLength(50)]
        public string maNganh { get; set; }

        [Required]
        public string tenNganh { get; set; }

        [StringLength(50)]
        public string maKhoa { get; set; }

        public int trangThai { get; set; }

        public virtual khoa khoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<lop> lops { get; set; }
    }
}
