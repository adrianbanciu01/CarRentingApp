using System.ComponentModel.DataAnnotations;

namespace CarRentingApp.Models
{
    public class Rental : IValidatableObject
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        public int CarID { get; set; }
        public Car? Car { get; set; } // Navigation property

        [Required]
        public int CustomerID { get; set; }
        public Customer? Customer { get; set; } // Navigation property

        [Required]
        public int? LocationID { get; set; } // Foreign key for Location
        public Location? Location { get; set; } // Navigation property

        public int Days => (EndDate - StartDate).Days; // Calculate rental days
        public decimal TotalPrice => Days * (Car?.PricePerDay ?? 0); // Calculate total price

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndDate < StartDate)
            {
                yield return new ValidationResult(
                    "The end date cannot be earlier than the start date.",
                    new[] { nameof(EndDate) });
            }
        }
    }
}
