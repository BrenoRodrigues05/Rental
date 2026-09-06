using System.ComponentModel.DataAnnotations;

namespace Rental.Application.DTOs
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The {0} must be between {2} and {1} characters.")]
        [Display(Name = "Category Name")]
        public string Name { get; set; } 

    }
}
