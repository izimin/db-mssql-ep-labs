namespace Lab7_UP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Этап_кубка_мира
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Этап_кубка_мира()
        {
            Гонка = new HashSet<Гонка>();
        }

        [Key]
        public int idЭтапа_кубка_мира { get; set; }

        [Required]
        [StringLength(50)]
        public string Название_этапа { get; set; }

        [Required]
        [StringLength(50)]
        public string Место_провеления { get; set; }

        [Column(TypeName = "date")]
        public DateTime Дата_начала { get; set; }

        [Column(TypeName = "date")]
        public DateTime Дата_конца { get; set; }

        public int idКубка_мира { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Гонка> Гонка { get; set; }

        public virtual Кубок_мира Кубок_мира { get; set; }

        public string ДлинноеНазвание => $"{Название_этапа} ({idЭтапа_кубка_мира})";
    }
}
