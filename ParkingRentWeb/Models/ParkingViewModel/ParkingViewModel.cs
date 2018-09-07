using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingRentWeb.Models.ParkingViewModel
{
	public class ParkingViewModel
	{
		public int Id { get; set; }
		public string IdUser { get; set; }
		[Display(Name = "Type de parking")]
		public int IdTypeParking { get; set; }
		[Display(Name = "Adresse")]
		public string Adresse { get; set; }
		[Display(Name = "Ville")]
		public string Ville { get; set; }
		[Display(Name = "Code postal")]
		public string Cp { get; set; }
		[Display(Name = "Prix journalier")]
		public decimal PrixJournalier { get; set; }
		[Display(Name = "Description du parking")]
		public string Description { get; set; }
	}
}
