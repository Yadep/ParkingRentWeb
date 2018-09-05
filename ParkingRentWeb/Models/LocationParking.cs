using System;
using System.Collections.Generic;

namespace ParkingRentWeb.Models
{
    public partial class LocationParking
    {
        public int Id { get; set; }
        public string IdParking { get; set; }
        public string IdUser { get; set; }
        public DateTime JourLocation { get; set; }
    }
}
