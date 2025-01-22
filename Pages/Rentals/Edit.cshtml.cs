using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRentingApp.Data;
using CarRentingApp.Models;

namespace CarRentingApp.Pages.Rentals
{
    public class EditModel : PageModel
    {
        private readonly CarRentingApp.Data.CarRentingAppContext _context;

        public EditModel(CarRentingApp.Data.CarRentingAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rental Rental { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental =  await _context.Rentals
                .Include(r => r.Location)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rental == null)
            {
                return NotFound();
            }
            Rental = rental;
           ViewData["CarID"] = new SelectList(_context.Cars, "ID", "Make");
           ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "FirstName");
           ViewData["LocationID"] = new SelectList(_context.Locations, "ID", "City");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["CarID"] = new SelectList(_context.Cars, "ID", "Make", Rental.CarID);
                ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "FirstName", Rental.CustomerID);
                ViewData["LocationID"] = new SelectList(_context.Locations, "ID", "City", Rental.LocationID);
                return Page();
            }

            _context.Attach(Rental).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalExists(Rental.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RentalExists(int id)
        {
            return _context.Rentals.Any(e => e.ID == id);
        }
    }
}
