using System;
using System.Collections.Generic;

namespace ParkingRentWeb.Models
{
    public partial class VehiculeUser
    {
        public int Id { get; set; }
        public int IdTypeVehicule { get; set; }
        public string IdUser { get; set; }
    }
}
