namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("chiTietPhieuCham")]
    public partial class chiTietPhieuCham
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int maPhieuChamDiem { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int maNoiDung { get; set; }

        public int? diemTuCham { get; set; }

        public int? diemCBLCham { get; set; }

        public int? diemGVCNCham { get; set; }

        public string minhChung { get; set; }

        public virtual noiDungDanhGia noiDungDanhGia { get; set; }

        public virtual phieuChamDiem phieuChamDiem { get; set; }
    }
}
