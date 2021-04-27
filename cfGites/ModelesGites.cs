namespace cfGites
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelesGites : DbContext
    {
        public ModelesGites()
            : base("name=ModelesGites")
        {
        }

        public virtual DbSet<client> clients { get; set; }
        public virtual DbSet<contrat> contrats { get; set; }
        public virtual DbSet<gite> gites { get; set; }
        public virtual DbSet<periode> periodes { get; set; }
        public virtual DbSet<planning> plannings { get; set; }
        public virtual DbSet<semaine> semaines { get; set; }
        public virtual DbSet<tarif> tarifs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<client>()
                .Property(e => e.nomClient)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.adresseClient)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.cpClient)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.villeClient)
                .IsUnicode(false);

            modelBuilder.Entity<gite>()
                .Property(e => e.nomGite)
                .IsUnicode(false);

            modelBuilder.Entity<gite>()
                .Property(e => e.adresseGite)
                .IsUnicode(false);

            modelBuilder.Entity<gite>()
                .Property(e => e.cpGite)
                .IsUnicode(false);

            modelBuilder.Entity<gite>()
                .Property(e => e.villeGite)
                .IsUnicode(false);

            modelBuilder.Entity<gite>()
                .Property(e => e.descriptionGite)
                .IsUnicode(false);

            modelBuilder.Entity<gite>()
                .HasMany(e => e.plannings)
                .WithRequired(e => e.gite)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<gite>()
                .HasMany(e => e.tarifs)
                .WithRequired(e => e.gite)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<periode>()
                .HasMany(e => e.tarifs)
                .WithRequired(e => e.periode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<semaine>()
                .HasMany(e => e.plannings)
                .WithRequired(e => e.semaine)
                .WillCascadeOnDelete(false);
        }
    }
}
