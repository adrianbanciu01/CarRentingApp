using System.ComponentModel.DataAnnotations;
using CarRentingApp.Models;

namespace CarRentingApp.Models
{
    public class Location
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Country { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        public ICollection<Rental>? Rentals { get; set; } // Navigation property
    }
}
