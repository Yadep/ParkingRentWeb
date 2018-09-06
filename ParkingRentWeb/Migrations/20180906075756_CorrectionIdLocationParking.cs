using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ParkingRentWeb.Migrations
{
    public partial class CorrectionIdLocationParking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "LocationParking",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false),
            //        IdParking = table.Column<string>(type: "nchar(10)", nullable: false),
            //        IdUser = table.Column<string>(maxLength: 450, nullable: false),
            //        JourLocation = table.Column<DateTime>(type: "date", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LocationParking", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Paking",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false),
            //        Adresse = table.Column<string>(type: "nchar(50)", nullable: false),
            //        CP = table.Column<string>(type: "nchar(10)", nullable: false),
            //        Description = table.Column<string>(type: "nchar(10)", nullable: false),
            //        IdTypeParking = table.Column<int>(nullable: false),
            //        IdUser = table.Column<string>(maxLength: 450, nullable: false),
            //        PrixJournalier = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
            //        Ville = table.Column<string>(type: "nchar(50)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Paking", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TypeParking",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false),
            //        Libelle = table.Column<string>(type: "nchar(10)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TypeParking", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TypeUser",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false),
            //        Libelle = table.Column<string>(type: "nchar(50)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TypeUser", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TypeVehicule",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false),
            //        Libelle = table.Column<string>(maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TypeVehicule", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "VehiculeUser",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false),
            //        IdTypeVehicule = table.Column<int>(nullable: false),
            //        IdUser = table.Column<string>(maxLength: 450, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_VehiculeUser", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "LocationParking");

            //migrationBuilder.DropTable(
            //    name: "Paking");

            //migrationBuilder.DropTable(
            //    name: "TypeParking");

            //migrationBuilder.DropTable(
            //    name: "TypeUser");

            //migrationBuilder.DropTable(
            //    name: "TypeVehicule");

            //migrationBuilder.DropTable(
            //    name: "VehiculeUser");
        }
    }
}
