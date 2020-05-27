namespace vinmart
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuNhapChiTiet")]
    public partial class PhieuNhapChiTiet
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaPN { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaMH { get; set; }

        [StringLength(10)]
        public string MaNCC { get; set; }

        public virtual MatHang MatHang { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }

        public virtual PhieuNhap PhieuNhap { get; set; }
    }
}
