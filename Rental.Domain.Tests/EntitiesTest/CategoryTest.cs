using System;
using FluentAssertions;
using Rental.Domain.Entities;
using Rental.Domain.Validation;
using Xunit;

namespace Rental.Domain.Tests.Entities
{
    public class CategoryTest
    {
        [Fact(DisplayName = "Deve criar categoria com dados válidos")]
        public void CreateCategory_WithValidParameters_ShouldInstantiateSuccessfully()
        {
            var validName = "Eletrônicos";

            var category = new Category(validName);

            category.Should().NotBeNull();
            category.Name.Should().Be(validName);
            category.Products.Should().BeEmpty();
        }

        [Fact(DisplayName = "Deve criar categoria informando Id e nome válidos")]
        public void CreateCategory_WithIdAndValidName_ShouldInstantiateSuccessfully()
        {
            var validId = Guid.NewGuid();
            var validName = "Ferramentas";

            var category = new Category(validId, validName);

            category.Id.Should().Be(validId);
            category.Name.Should().Be(validName);
        }

        [Fact(DisplayName = "Deve remover espaços em branco no início e fim do nome")]
        public void CreateCategory_NameWithLeadingOrTrailingSpaces_ShouldTrimName()
        {
            var untrimmedName = "   Jogos   ";
            var expectedName = "Jogos";

            var category = new Category(untrimmedName);

            category.Name.Should().Be(expectedName);
        }

        [Theory(DisplayName = "Não deve criar categoria com nome nulo ou vazio")]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void CreateCategory_InvalidName_ShouldThrowDomainException(string invalidName)
        {
            Action act = () => new Category(invalidName);

            act.Should().Throw<DomainExceptionValidation>()
               .WithMessage("O nome da categoria não pode ser nulo ou vazio.");
        }

        [Fact(DisplayName = "Não deve criar categoria com nome menor que 3 caracteres")]
        public void CreateCategory_NameLessThan3Characters_ShouldThrowDomainException()
        {
            var shortName = "AB";

            Action act = () => new Category(shortName);

            act.Should().Throw<DomainExceptionValidation>()
               .WithMessage("O nome da categoria deve ter no mínimo 3 caracteres.");
        }

        [Fact(DisplayName = "Não deve criar categoria com nome maior que 50 caracteres")]
        public void CreateCategory_NameGreaterThan50Characters_ShouldThrowDomainException()
        {
            var longName = new string('A', 51);

            Action act = () => new Category(longName);

            act.Should().Throw<DomainExceptionValidation>()
               .WithMessage("O nome da categoria deve ter no máximo 50 caracteres.");
        }

        [Fact(DisplayName = "Deve atualizar o nome da categoria quando o novo nome for válido")]
        public void Update_WithValidName_ShouldUpdateCategoryName()
        {
            var category = new Category("Antigo Nome");
            var newName = "Novo Nome";

            category.Update(newName);

            category.Name.Should().Be(newName);
        }

        [Fact(DisplayName = "Não deve adicionar um produto nulo à categoria")]
        public void AddProduct_NullProduct_ShouldThrowDomainException()
        {
            var category = new Category("Eletrodomésticos");

            Action act = () => category.AddProduct(null!);

            act.Should().Throw<DomainExceptionValidation>()
               .WithMessage("O produto não pode ser nulo.");
        }
    }
}