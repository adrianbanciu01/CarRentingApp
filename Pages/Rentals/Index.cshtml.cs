using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentingApp.Data;
using CarRentingApp.Models;

namespace CarRentingApp.Pages.Rentals
{
    public class IndexModel : PageModel
    {
        private readonly CarRentingApp.Data.CarRentingAppContext _context;

        public IndexModel(CarRentingApp.Data.CarRentingAppContext context)
        {
            _context = context;
        }

        public IList<Rental> Rental { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Rental = await _context.Rentals
        .Include(r => r.Car)
        .Include(r => r.Customer)
        .Include(r => r.Location)
        .ToListAsync();
        }
    }
}
