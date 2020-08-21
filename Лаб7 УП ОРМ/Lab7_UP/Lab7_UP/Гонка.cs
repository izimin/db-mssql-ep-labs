namespace Lab7_UP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Гонка
    {
        [Key]
        public int idГонки { get; set; }

        public int idЭтапа_кубка_мира { get; set; }

        [Required]
        [StringLength(50)]
        public string Тип_гонки { get; set; }

        public int idТрассы { get; set; }

        [Column(TypeName = "date")]
        public DateTime Дата_начала { get; set; }

        [Column(TypeName = "date")]
        public DateTime Дата_окончания { get; set; }

        public TimeSpan Время_начала { get; set; }

        public TimeSpan Время_окончания { get; set; }

        public virtual Трасса Трасса { get; set; }

        public virtual Этап_кубка_мира Этап_кубка_мира { get; set; }
    }
}
