using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentingApp.Data;
using CarRentingApp.Models;

namespace CarRentingApp.Pages.Rentals
{
    public class CreateModel : PageModel
    {
        private readonly CarRentingApp.Data.CarRentingAppContext _context;

        public CreateModel(CarRentingApp.Data.CarRentingAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var locations = _context.Locations
            .Select(x => new { x.ID, LocationName = $"{x.City}, {x.Country}" })
            .ToList();

            ViewData["LocationID"] = new SelectList(locations, "ID", "LocationName");
            ViewData["CarID"] = new SelectList(_context.Cars, "ID", "Model");
            ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "FirstName");
            return Page();
        }

        [BindProperty]
        public Rental Rental { get; set; } = default!;

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

            _context.Rentals.Add(Rental);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
