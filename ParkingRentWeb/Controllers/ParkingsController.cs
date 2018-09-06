using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParkingRentWeb.Data;
using ParkingRentWeb.Models;
using ParkingRentWeb.Models.ParkingViewModel;

namespace ParkingRentWeb.Controllers
{
	public class ParkingsController : Controller
	{
		private readonly ParkingRentDbContext _context;
		private readonly ApplicationDbContext _applicationDbContext;
		private readonly UserManager<ApplicationUser> _userManager;

		public ParkingsController(ParkingRentDbContext context, ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager)
		{
			_context = context;
			_applicationDbContext = applicationDbContext;
			_userManager = userManager;
		}

		public async Task<IActionResult> Map()
		{
			var locationparking = _context.LocationParking.Where(b => b.JourLocation.Date != DateTime.Now.Date).Select(b => b.IdParking).ToList();
			var points = _context.Paking.Where(b => !locationparking.Contains(b.Id)).ToList();


			var count = 0;
			var listPoint = new List<PointsMapViewModel>();
			foreach (var point in points)
			{
				string requestUri = string.Format("http://maps.google.com/maps/api/geocode/xml?address=" + point.Adresse + "+" + point.Cp + "+" + point.Ville + "&sensor=false");

				WebRequest request = WebRequest.Create(requestUri);
				WebResponse response = request.GetResponse();
				XDocument xdoc = XDocument.Load(response.GetResponseStream());
				System.Threading.Thread.Sleep(500);
				XElement result = xdoc.Element("GeocodeResponse").Element("result");
				XElement locationElement = result.Element("geometry").Element("location");
				XElement lat = locationElement.Element("lat");
				XElement lng = locationElement.Element("lng");
				var latitude = lat.ToString().Replace("<lat>", "").Replace("</lat>", "");
				var longitude = lng.ToString().Replace("<lng>", "").Replace("</lng>", "");
				var description = point.Description;
				var prix = point.PrixJournalier;
				listPoint.Add(new PointsMapViewModel { latitude = latitude, longitude = longitude, description = description, prix = prix });


				//var json = wc.DownloadString("http://maps.google.com/maps/api/geocode/json?address=58+rue+de+la+victoire+49800+Tr%C3%A9laz%C3%A9");
			}
			return View(listPoint);
		}

		// GET: Parkings
		public async Task<IActionResult> Index()
		{
			return View(await _context.Paking.ToListAsync());
		}

		// GET: Parkings/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var paking = await _context.Paking
				.SingleOrDefaultAsync(m => m.Id == id);
			if (paking == null)
			{
				return NotFound();
			}

			return View(paking);
		}

		// GET: Parkings/Create
		[Authorize(Roles = "Utilisateur")]
		public IActionResult Create()
		{
			ViewData["IdTypeParking"] = new SelectList(_context.TypeParking, "Id", "Libelle");
			return View();
		}

		// POST: Parkings/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Utilisateur")]
		public async Task<IActionResult> Create([Bind("IdTypeParking,Adresse,Ville,Cp,PrixJournalier,Description")] Paking paking)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.GetUserAsync(User);
				paking.IdUser = user.Id;
				_context.Add(paking);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(paking);
		}

		// GET: Parkings/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var paking = await _context.Paking.SingleOrDefaultAsync(m => m.Id == id);
			if (paking == null)
			{
				return NotFound();
			}
			return View(paking);
		}

		// POST: Parkings/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,IdUser,IdTypeParking,Adresse,Ville,Cp,PrixJournalier,Description")] Paking paking)
		{
			if (id != paking.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(paking);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!PakingExists(paking.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(paking);
		}

		// GET: Parkings/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var paking = await _context.Paking
				.SingleOrDefaultAsync(m => m.Id == id);
			if (paking == null)
			{
				return NotFound();
			}

			return View(paking);
		}

		// POST: Parkings/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var paking = await _context.Paking.SingleOrDefaultAsync(m => m.Id == id);
			_context.Paking.Remove(paking);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool PakingExists(int id)
		{
			return _context.Paking.Any(e => e.Id == id);
		}
	}
}
