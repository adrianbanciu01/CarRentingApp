using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentingApp.Data;
using CarRentingApp.Models;

namespace CarRentingApp.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly CarRentingApp.Data.CarRentingAppContext _context;

        public IndexModel(CarRentingApp.Data.CarRentingAppContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Car = await _context.Cars.ToListAsync();
        }
    }
}
