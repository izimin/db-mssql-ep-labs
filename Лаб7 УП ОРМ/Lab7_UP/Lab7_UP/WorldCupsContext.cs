namespace Lab7_UP
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WorldCupsContext : DbContext
    {
        public WorldCupsContext()
            : base("name=WorldCupsContext")
        {
        }

        public virtual DbSet<Гонка> Гонка { get; set; }
        public virtual DbSet<Кубок_мира> Кубок_мира { get; set; }
        public virtual DbSet<Трасса> Трасса { get; set; }
        public virtual DbSet<Этап_кубка_мира> Этап_кубка_мира { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Кубок_мира>()
                .HasMany(e => e.Этап_кубка_мира)
                .WithRequired(e => e.Кубок_мира)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Трасса>()
                .HasMany(e => e.Гонка)
                .WithRequired(e => e.Трасса)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Этап_кубка_мира>()
                .HasMany(e => e.Гонка)
                .WithRequired(e => e.Этап_кубка_мира)
                .WillCascadeOnDelete(false);
        }
    }
}
