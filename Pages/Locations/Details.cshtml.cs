using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentingApp.Data;
using CarRentingApp.Models;

namespace CarRentingApp.Pages.Locations
{
    public class DetailsModel : PageModel
    {
        private readonly CarRentingApp.Data.CarRentingAppContext _context;

        public DetailsModel(CarRentingApp.Data.CarRentingAppContext context)
        {
            _context = context;
        }

        public Location Location { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Locations.FirstOrDefaultAsync(m => m.ID == id);
            if (location == null)
            {
                return NotFound();
            }
            else
            {
                Location = location;
            }
            return Page();
        }
    }
}
