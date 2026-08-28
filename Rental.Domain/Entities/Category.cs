using Rental.Domain.Validation;
using System;
using System.Collections.Generic;

namespace Rental.Domain.Entities
{
    public sealed class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<Product> Products { get; set; } = new List<Product>(); 

        public Category(string name)
        {
            ValidateName(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "O Id da categoria não pode ser negativo.");
            Id = id;
            ValidateName(name);
        }

        public void Update(string name)
        {
            ValidateName(name);
        }

        public void AddProduct(Product product)
        {
            DomainExceptionValidation.When(product == null, "O produto não pode ser nulo.");
            Products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }

        private void ValidateName(string name)
        {
           DomainExceptionValidation.When(string.IsNullOrEmpty(name), 
               "O nome da categoria não pode ser nulo ou vazio.");

            string trimmedName = name.Trim();

            DomainExceptionValidation.When(trimmedName.Length < 3, 
                "O nome da categoria deve ter no mínimo 3 caracteres.");

            DomainExceptionValidation.When(trimmedName.Length > 50,
                "O nome da categoria deve ter no máximo 50 caracteres.");

            Name = trimmedName;
        }
    }
}
