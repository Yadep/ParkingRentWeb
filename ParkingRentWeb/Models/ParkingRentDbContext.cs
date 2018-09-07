using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ParkingRentWeb.Models
{
    public partial class ParkingRentDbContext : DbContext
    {

		public ParkingRentDbContext(DbContextOptions<ParkingRentDbContext> options)
: base(options)
		{
		}

		public virtual DbSet<LocationParking> LocationParking { get; set; }
        public virtual DbSet<Paking> Paking { get; set; }
        public virtual DbSet<TypeParking> TypeParking { get; set; }
        public virtual DbSet<TypeUser> TypeUser { get; set; }
        public virtual DbSet<TypeVehicule> TypeVehicule { get; set; }
        public virtual DbSet<VehiculeUser> VehiculeUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-BB061T6\SQLEXPRESS;Initial Catalog=ParkingRent;Integrated Security=True;User Id=sa;Password=RPJ;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LocationParking>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdParking)
                    .IsRequired()
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.IdUser)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.JourLocation).HasColumnType("date");
            });

            modelBuilder.Entity<Paking>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Adresse)
                    .IsRequired()
                    .HasColumnType("nchar(50)");

                entity.Property(e => e.Cp)
                    .IsRequired()
                    .HasColumnName("CP")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.IdUser)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.PrixJournalier).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Ville)
                    .IsRequired()
                    .HasColumnType("nchar(50)");
            });

            modelBuilder.Entity<TypeParking>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasColumnType("nchar(50)");
            });

            modelBuilder.Entity<TypeUser>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasColumnType("nchar(50)");
            });

            modelBuilder.Entity<TypeVehicule>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VehiculeUser>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdUser)
                    .IsRequired()
                    .HasMaxLength(450);
            });
        }
    }
}
