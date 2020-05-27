namespace vinmart
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MatHang")]
    public partial class MatHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MatHang()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
            PhieuKiemKeChiTiets = new HashSet<PhieuKiemKeChiTiet>();
            PhieuNhapChiTiets = new HashSet<PhieuNhapChiTiet>();
            PhieuXuatChiTiets = new HashSet<PhieuXuatChiTiet>();
        }

        [Key]
        [StringLength(10)]
        public string MaMH { get; set; }

        [Required]
        [StringLength(50)]
        public string Ten { get; set; }

        [StringLength(10)]
        public string MaLH { get; set; }

        [StringLength(10)]
        public string MaDVT { get; set; }

        [StringLength(50)]
        public string NgaySanXuat { get; set; }

        public int? SoLuongNhap { get; set; }

        public int? SoLuongBan { get; set; }

        public int? GiaBan { get; set; }

        public int? GiaMua { get; set; }

        public double? VAT { get; set; }

        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NgayNhap { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NgayHetHan { get; set; }

        [StringLength(50)]
        public string HinhMinhHoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual DonViTinh DonViTinh { get; set; }

        public virtual LoaiHang LoaiHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuKiemKeChiTiet> PhieuKiemKeChiTiets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuNhapChiTiet> PhieuNhapChiTiets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuXuatChiTiet> PhieuXuatChiTiets { get; set; }
    }
}
