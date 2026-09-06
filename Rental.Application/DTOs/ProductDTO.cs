using Rental.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Rental.Application.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The {0} must be between {2} and {1} characters.")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "The {0} must be between {2} and {1} characters.")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [Range(0.01, 10000.00, ErrorMessage = "The {0} must be between {1:C} and {2:C}.")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [Range(0, 1000, ErrorMessage = "The {0} must be between {1} and {2}.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set;}

        [StringLength(250, ErrorMessage = "The {0} cannot exceed {1} characters.")]
        [Url(ErrorMessage = "The {0} must be a valid URL.")]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        [Display(Name = "Available")]
        public bool Available { get; set; }

        public Category Category { get; set; }

        [Display(Name = "Category")]
        public Guid CategoryId { get; set; }
    }
}
