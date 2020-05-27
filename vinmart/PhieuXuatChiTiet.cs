namespace vinmart
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuXuatChiTiet")]
    public partial class PhieuXuatChiTiet
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaPX { get; set; }

        public int? SoLuong { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaMH { get; set; }

        public virtual MatHang MatHang { get; set; }

        public virtual PhieuXuat PhieuXuat { get; set; }
    }
}
