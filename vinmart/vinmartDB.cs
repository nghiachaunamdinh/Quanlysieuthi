namespace vinmart
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class vinmartDB : DbContext
    {
        public vinmartDB()
            : base("name=vinmartDB")
        {
        }

        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<ChungLoai> ChungLoais { get; set; }
        public virtual DbSet<DonViTinh> DonViTinhs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiHang> LoaiHangs { get; set; }
        public virtual DbSet<MatHang> MatHangs { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhieuKiemKe> PhieuKiemKes { get; set; }
        public virtual DbSet<PhieuKiemKeChiTiet> PhieuKiemKeChiTiets { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public virtual DbSet<PhieuNhapChiTiet> PhieuNhapChiTiets { get; set; }
        public virtual DbSet<PhieuXuat> PhieuXuats { get; set; }
        public virtual DbSet<PhieuXuatChiTiet> PhieuXuatChiTiets { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietHoaDon>()
                .Property(e => e.MaHD)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietHoaDon>()
                .Property(e => e.MaMH)
                .IsUnicode(false);

            modelBuilder.Entity<ChucVu>()
                .Property(e => e.MaCV)
                .IsUnicode(false);

            modelBuilder.Entity<ChungLoai>()
                .Property(e => e.MaCL)
                .IsUnicode(false);

            modelBuilder.Entity<DonViTinh>()
                .Property(e => e.MaDVT)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaHD)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiHang>()
                .Property(e => e.MaLH)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiHang>()
                .Property(e => e.MaCL)
                .IsUnicode(false);

            modelBuilder.Entity<MatHang>()
                .Property(e => e.MaMH)
                .IsUnicode(false);

            modelBuilder.Entity<MatHang>()
                .Property(e => e.MaLH)
                .IsUnicode(false);

            modelBuilder.Entity<MatHang>()
                .Property(e => e.MaDVT)
                .IsUnicode(false);

            modelBuilder.Entity<MatHang>()
                .Property(e => e.HinhMinhHoa)
                .IsUnicode(false);

            modelBuilder.Entity<MatHang>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.MatHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MatHang>()
                .HasMany(e => e.PhieuKiemKeChiTiets)
                .WithRequired(e => e.MatHang)
                .HasForeignKey(e => e.MaPKK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MatHang>()
                .HasMany(e => e.PhieuNhapChiTiets)
                .WithRequired(e => e.MatHang)
                .HasForeignKey(e => e.MaPN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MatHang>()
                .HasMany(e => e.PhieuXuatChiTiets)
                .WithRequired(e => e.MatHang)
                .HasForeignKey(e => e.MaPX)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.MaNCC)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaCV)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuKiemKe>()
                .Property(e => e.MaPKK)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuKiemKe>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuKiemKe>()
                .HasMany(e => e.PhieuKiemKeChiTiets)
                .WithRequired(e => e.PhieuKiemKe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuKiemKeChiTiet>()
                .Property(e => e.MaPKK)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuKiemKeChiTiet>()
                .Property(e => e.MaMH)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhap>()
                .Property(e => e.MaPN)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhap>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhap>()
                .HasMany(e => e.PhieuNhapChiTiets)
                .WithRequired(e => e.PhieuNhap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuNhapChiTiet>()
                .Property(e => e.MaPN)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhapChiTiet>()
                .Property(e => e.MaMH)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhapChiTiet>()
                .Property(e => e.MaNCC)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuXuat>()
                .Property(e => e.MaPX)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuXuat>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuXuat>()
                .HasMany(e => e.PhieuXuatChiTiets)
                .WithRequired(e => e.PhieuXuat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuXuatChiTiet>()
                .Property(e => e.MaPX)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuXuatChiTiet>()
                .Property(e => e.MaMH)
                .IsUnicode(false);
        }
    }
}
