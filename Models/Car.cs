using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CarRentingApp.Models
{
    public class Car
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Make { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [Range(0, 1000)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal PricePerDay { get; set; }

        public string FullModel => $"{Make} {Model}";

        public ICollection<Rental>? Rentals { get; set; } // Navigation property
    }
}
