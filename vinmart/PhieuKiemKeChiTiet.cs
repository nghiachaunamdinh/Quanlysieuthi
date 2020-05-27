namespace vinmart
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuKiemKeChiTiet")]
    public partial class PhieuKiemKeChiTiet
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaPKK { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaMH { get; set; }

        public int? SLTon { get; set; }

        public virtual MatHang MatHang { get; set; }

        public virtual PhieuKiemKe PhieuKiemKe { get; set; }
    }
}
