namespace Lab7_UP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Кубок_мира
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Кубок_мира()
        {
            Этап_кубка_мира = new HashSet<Этап_кубка_мира>();
        }

        [Key]
        public int idКубка_мира { get; set; }

        [Required]
        [StringLength(50)]
        public string Название_кубка { get; set; }

        [Required]
        [StringLength(50)]
        public string Период { get; set; }

        [Required]
        [StringLength(50)]
        public string Главный_приз { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Этап_кубка_мира> Этап_кубка_мира { get; set; }
    }
}
