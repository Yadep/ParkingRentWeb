﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ParkingRentWeb.Models;
using System;

namespace ParkingRentWeb.Migrations
{
    [DbContext(typeof(ParkingRentDbContext))]
    [Migration("20180906075844_CorrectionIdLocationParking2")]
    partial class CorrectionIdLocationParking2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ParkingRentWeb.Models.LocationParking", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("IdParking")
                        .HasColumnType("nchar(10)");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<DateTime>("JourLocation")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("LocationParking");
                });

            modelBuilder.Entity("ParkingRentWeb.Models.Paking", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nchar(50)");

                    b.Property<string>("Cp")
                        .IsRequired()
                        .HasColumnName("CP")
                        .HasColumnType("nchar(10)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nchar(10)");

                    b.Property<int>("IdTypeParking");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<decimal>("PrixJournalier")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasColumnType("nchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Paking");
                });

            modelBuilder.Entity("ParkingRentWeb.Models.TypeParking", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nchar(10)");

                    b.HasKey("Id");

                    b.ToTable("TypeParking");
                });

            modelBuilder.Entity("ParkingRentWeb.Models.TypeUser", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TypeUser");
                });

            modelBuilder.Entity("ParkingRentWeb.Models.TypeVehicule", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("TypeVehicule");
                });

            modelBuilder.Entity("ParkingRentWeb.Models.VehiculeUser", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("IdTypeVehicule");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.HasKey("Id");

                    b.ToTable("VehiculeUser");
                });
#pragma warning restore 612, 618
        }
    }
}
