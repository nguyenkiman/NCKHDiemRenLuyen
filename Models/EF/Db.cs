using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.EF
{
    public partial class Db : DbContext
    {
        public Db()
            : base("name=Db")
        {
        }

        public virtual DbSet<admin> admins { get; set; }
        public virtual DbSet<baoHiemYTe> baoHiemYTes { get; set; }
        public virtual DbSet<canBoLop> canBoLops { get; set; }
        public virtual DbSet<chiTietPhieuCham> chiTietPhieuChams { get; set; }
        public virtual DbSet<danhMucDanhGia> danhMucDanhGias { get; set; }
        public virtual DbSet<diemHocTap> diemHocTaps { get; set; }
        public virtual DbSet<giangVien> giangViens { get; set; }
        public virtual DbSet<giaoVienChuNhiem> giaoVienChuNhiems { get; set; }
        public virtual DbSet<hocKi> hocKis { get; set; }
        public virtual DbSet<hocPhi> hocPhis { get; set; }
        public virtual DbSet<khoa> khoas { get; set; }
        public virtual DbSet<lop> lops { get; set; }
        public virtual DbSet<nganh> nganhs { get; set; }
        public virtual DbSet<noiDungDanhGia> noiDungDanhGias { get; set; }
        public virtual DbSet<phieuChamDiem> phieuChamDiems { get; set; }
        public virtual DbSet<sinhVien> sinhViens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<admin>()
                .HasMany(e => e.hocKis)
                .WithOptional(e => e.admin)
                .HasForeignKey(e => e.nguoiTao);

            modelBuilder.Entity<giangVien>()
                .HasMany(e => e.giaoVienChuNhiems)
                .WithRequired(e => e.giangVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<hocKi>()
                .HasMany(e => e.baoHiemYTes)
                .WithRequired(e => e.hocKi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<hocKi>()
                .HasMany(e => e.diemHocTaps)
                .WithRequired(e => e.hocKi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<hocKi>()
                .HasMany(e => e.hocPhis)
                .WithRequired(e => e.hocKi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<lop>()
                .HasMany(e => e.canBoLops)
                .WithRequired(e => e.lop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<lop>()
                .HasMany(e => e.giaoVienChuNhiems)
                .WithRequired(e => e.lop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<noiDungDanhGia>()
                .HasMany(e => e.chiTietPhieuChams)
                .WithRequired(e => e.noiDungDanhGia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<phieuChamDiem>()
                .HasMany(e => e.chiTietPhieuChams)
                .WithRequired(e => e.phieuChamDiem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sinhVien>()
                .HasMany(e => e.baoHiemYTes)
                .WithRequired(e => e.sinhVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sinhVien>()
                .HasMany(e => e.canBoLops)
                .WithRequired(e => e.sinhVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sinhVien>()
                .HasMany(e => e.diemHocTaps)
                .WithRequired(e => e.sinhVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sinhVien>()
                .HasMany(e => e.hocPhis)
                .WithRequired(e => e.sinhVien)
                .WillCascadeOnDelete(false);
        }
    }
}
