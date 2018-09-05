using System;
using System.Collections.Generic;

namespace ParkingRentWeb.Models
{
    public partial class Paking
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public int IdTypeParking { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Cp { get; set; }
        public decimal PrixJournalier { get; set; }
        public string Description { get; set; }
    }
}
