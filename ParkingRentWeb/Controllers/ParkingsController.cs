using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParkingRentWeb.Data;
using ParkingRentWeb.Models;

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

			return View();
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
