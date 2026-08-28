using Rental.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental.Domain.Entities
{
    public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; } 
        public int Quantity { get; private set; }
        public string ImageUrl { get; private set; }
        public bool Available { get; private set; } = true;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(string name, string description, decimal price, int quantity, string imageUrl)
        {
            ValidateDomain(name, description, price, quantity, imageUrl);
         
        }

        public Product(int id, string name, string description, decimal price, int quantity, string imageUrl)
        {
            DomainExceptionValidation.When(id < 0, "O Id do produto não pode ser negativo.");
            Id = id;
            ValidateDomain(name, description, price, quantity, imageUrl);

        }

        public void Update(string name, string description, decimal price, int quantity, string imageUrl, int categoryId)
        {
            ValidateDomain(name, description, price, quantity, imageUrl);
            DomainExceptionValidation.When(categoryId < 0, "O Id da categoria não pode ser negativo.");
            CategoryId = categoryId;
        }

        public void UpdateAvailability(bool available)
        {
            Available = available;
        }

        public void ValidateDomain(string name, string description, decimal price, int quantity, string imageUrl)
        {
           DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "O nome do produto não pode ser nulo ou vazio.");

            DomainExceptionValidation.When(name.Length < 3,
                "O nome do produto deve ter no mínimo 3 caracteres.");

            DomainExceptionValidation.When(name.Length > 100,
                "O nome do produto deve ter no máximo 100 caracteres.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "A descrição do produto não pode ser nula ou vazia.");

            DomainExceptionValidation.When(description.Length < 10,
                "A descrição do produto deve ter no mínimo 10 caracteres.");

            DomainExceptionValidation.When(description.Length > 500,
                "A descrição do produto deve ter no máximo 500 caracteres.");

            DomainExceptionValidation.When(price <= 0,
                "O preço do produto não pode ser negativo ou zero.");

            DomainExceptionValidation.When(quantity < 0,
                "A quantidade do produto não pode ser negativa.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(imageUrl),

                "A URL da imagem do produto não pode ser nula ou vazia.");

            DomainExceptionValidation.When(imageUrl.Length > 500,
                "A URL da imagem do produto deve ter no máximo 500 caracteres.");

            Name = name.Trim();
            Description = description.Trim();
            Price = price;
            Quantity = quantity;
            ImageUrl = imageUrl.Trim();
        }
    }
}
