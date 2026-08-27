using System;

namespace Rental.Domain.Entities
{
    public sealed class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
 
        public Category(int id, string name)
        {
            if(id <= 0)
            {
                throw new ArgumentException("O Id da categoria deve ser maior que zero.");
            }
            Id = id;
            Name = name.Trim();
            ValidateName(name);
        }

        public void Update(string name)
        {
            Name = name.Trim();
            ValidateName(name);
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("O nome da categoria não pode ser vazio.");
            }

            if (name.Length > 100)
            {
                throw new ArgumentException("O nome da categoria não pode ter mais de 100 caracteres.");
            }

            if (name.Length < 3)
            {
                throw new ArgumentException("O nome da categoria deve ter pelo menos 3 caracteres.");
            }
        }
    }
}
