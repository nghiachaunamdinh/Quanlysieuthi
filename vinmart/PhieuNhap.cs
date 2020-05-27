namespace vinmart
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuNhap")]
    public partial class PhieuNhap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuNhap()
        {
            PhieuNhapChiTiets = new HashSet<PhieuNhapChiTiet>();
        }

        [Key]
        [StringLength(10)]
        public string MaPN { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ThoiDiemLap { get; set; }

        [StringLength(10)]
        public string MaNV { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuNhapChiTiet> PhieuNhapChiTiets { get; set; }
    }
}
