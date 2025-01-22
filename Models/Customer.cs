using System.ComponentModel.DataAnnotations;
namespace CarRentingApp.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public ICollection<Rental>? Rentals { get; set; } // Navigation property
    }
}
