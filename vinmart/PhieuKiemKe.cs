namespace vinmart
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuKiemKe")]
    public partial class PhieuKiemKe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuKiemKe()
        {
            PhieuKiemKeChiTiets = new HashSet<PhieuKiemKeChiTiet>();
        }

        [Key]
        [StringLength(10)]
        public string MaPKK { get; set; }

        [StringLength(10)]
        public string MaNV { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NgayCapThe { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuKiemKeChiTiet> PhieuKiemKeChiTiets { get; set; }
    }
}
