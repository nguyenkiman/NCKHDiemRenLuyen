namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("danhMucDanhGia")]
    public partial class danhMucDanhGia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public danhMucDanhGia()
        {
            noiDungDanhGia = new HashSet<noiDungDanhGia>();
        }

        [Key]
        public int maDanhMuc { get; set; }

        [Required]
        public string tenDanhMuc { get; set; }

        public int? trangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<noiDungDanhGia> noiDungDanhGia { get; set; }
    }
}
