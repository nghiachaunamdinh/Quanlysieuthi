namespace vinmart
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChungLoai")]
    public partial class ChungLoai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChungLoai()
        {
            LoaiHangs = new HashSet<LoaiHang>();
        }

        [Key]
        [StringLength(10)]
        public string MaCL { get; set; }

        [Required]
        [StringLength(100)]
        public string Ten { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoaiHang> LoaiHangs { get; set; }
    }
}
