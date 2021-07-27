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

        public virtual DbSet<admin> admin { get; set; }
        public virtual DbSet<baoHiemYTe> baoHiemYTe { get; set; }
        public virtual DbSet<canBoLop> canBoLop { get; set; }
        public virtual DbSet<chiTietPhieuCham> chiTietPhieuCham { get; set; }
        public virtual DbSet<danhMucDanhGia> danhMucDanhGia { get; set; }
        public virtual DbSet<diemHocTap> diemHocTap { get; set; }
        public virtual DbSet<giangVien> giangVien { get; set; }
        public virtual DbSet<giaoVienChuNhiem> giaoVienChuNhiem { get; set; }
        public virtual DbSet<hocKi> hocKi { get; set; }
        public virtual DbSet<hocPhi> hocPhi { get; set; }
        public virtual DbSet<khoa> khoa { get; set; }
        public virtual DbSet<lop> lop { get; set; }
        public virtual DbSet<noiDungDanhGia> noiDungDanhGia { get; set; }
        public virtual DbSet<nganh> nganh { get; set; }
        public virtual DbSet<phieuChamDiem> phieuChamDiem { get; set; }
        public virtual DbSet<sinhVien> sinhVien { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<admin>()
                .HasMany(e => e.hocKi)
                .WithOptional(e => e.admin)
                .HasForeignKey(e => e.nguoiTao);

            modelBuilder.Entity<giangVien>()
                .HasMany(e => e.giaoVienChuNhiem)
                .WithRequired(e => e.giangVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<hocKi>()
                .HasMany(e => e.baoHiemYTe)
                .WithRequired(e => e.hocKi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<hocKi>()
                .HasMany(e => e.diemHocTap)
                .WithRequired(e => e.hocKi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<hocKi>()
                .HasMany(e => e.hocPhi)
                .WithRequired(e => e.hocKi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<lop>()
                .HasMany(e => e.canBoLop)
                .WithRequired(e => e.lop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<lop>()
                .HasMany(e => e.giaoVienChuNhiem)
                .WithRequired(e => e.lop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<noiDungDanhGia>()
                .HasMany(e => e.chiTietPhieuCham)
                .WithRequired(e => e.noiDungDanhGia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<phieuChamDiem>()
                .HasMany(e => e.chiTietPhieuCham)
                .WithRequired(e => e.phieuChamDiem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sinhVien>()
                .HasMany(e => e.baoHiemYTe)
                .WithRequired(e => e.sinhVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sinhVien>()
                .HasMany(e => e.canBoLop)
                .WithRequired(e => e.sinhVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sinhVien>()
                .HasMany(e => e.diemHocTap)
                .WithRequired(e => e.sinhVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sinhVien>()
                .HasMany(e => e.hocPhi)
                .WithRequired(e => e.sinhVien)
                .WillCascadeOnDelete(false);
        }
    }
}
