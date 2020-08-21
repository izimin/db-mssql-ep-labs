namespace Lab7_UP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Трасса
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Трасса()
        {
            Гонка = new HashSet<Гонка>();
        }

        [Key]
        public int idТрассы { get; set; }

        [Required]
        [StringLength(50)]
        public string Название_трассы { get; set; }

        [Required]
        [StringLength(50)]
        public string Расположение_трассы { get; set; }

        public double Длина_трассы { get; set; }

        public int Средний_уклон { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Гонка> Гонка { get; set; }
    }
}
