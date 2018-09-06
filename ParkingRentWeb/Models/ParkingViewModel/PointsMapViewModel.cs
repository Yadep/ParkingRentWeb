using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingRentWeb.Models.ParkingViewModel
{
	public class PointsMapViewModel
	{
		public PointsMapViewModel()
		{

		}

		public string latitude { get; set; }
		public string longitude { get; set; }
		public string description { get; set; }
		public decimal prix { get; set; }
	}
}
