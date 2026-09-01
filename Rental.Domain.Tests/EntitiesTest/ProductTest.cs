using System;
using FluentAssertions;
using Rental.Domain.Entities;
using Rental.Domain.Validation;
using Xunit;

namespace Rental.Domain.Tests.Entities
{
    public class ProductTest
    {
        [Fact(DisplayName = "Deve criar produto com parâmetros válidos")]
        public void CreateProduct_WithValidParameters_ShouldInstantiateSuccessfully()
        {
            var name = "Furadeira de Impacto";
            var description = "Furadeira profissional 750W com velocidade variável";
            var price = 150.00m;
            var quantity = 5;
            var imageUrl = "https://example.com/images/furadeira.jpg";

            var product = new Product(name, description, price, quantity, imageUrl);

            product.Should().NotBeNull();
            product.Name.Should().Be(name);
            product.Description.Should().Be(description);
            product.Price.Should().Be(price);
            product.Quantity.Should().Be(quantity);
            product.ImageUrl.Should().Be(imageUrl);
            product.Available.Should().BeTrue();
            product.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(2));
        }

        [Fact(DisplayName = "Deve criar produto informando Id e parâmetros válidos")]
        public void CreateProduct_WithIdAndValidParameters_ShouldInstantiateSuccessfully()
        {
            var id = Guid.NewGuid();
            var name = "Esmerilhadeira";
            var description = "Esmerilhadeira angular 4.1/2 polegadas 820W";
            var price = 90.00m;
            var quantity = 2;
            var imageUrl = "https://example.com/images/esmerilhadeira.jpg";

            var product = new Product(id, name, description, price, quantity, imageUrl);

            product.Id.Should().Be(id);
            product.Name.Should().Be(name);
        }

        [Fact(DisplayName = "Deve remover espaços em branco no início e fim das propriedades de texto")]
        public void CreateProduct_TextPropertiesWithLeadingOrTrailingSpaces_ShouldTrimValues()
        {
            var untrimmedName = "   Betoneira   ";
            var untrimmedDescription = "   Betoneira 400 litros monofásica 220v   ";
            var untrimmedImageUrl = "   https://example.com/images/betoneira.jpg   ";

            var product = new Product(untrimmedName, untrimmedDescription, 300.00m, 1, untrimmedImageUrl);

            product.Name.Should().Be("Betoneira");
            product.Description.Should().Be("Betoneira 400 litros monofásica 220v");
            product.ImageUrl.Should().Be("https://example.com/images/betoneira.jpg");
        }

        [Theory(DisplayName = "Não deve criar produto com nome nulo ou vazio")]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void CreateProduct_InvalidName_ShouldThrowDomainException(string invalidName)
        {
            Action act = () => new Product(invalidName, "Descrição válida com mais de 10 caracteres", 10.0m, 1, "https://example.com/image.jpg");

            act.Should().Throw<DomainExceptionValidation>()
               .WithMessage("O nome do produto não pode ser nulo ou vazio.");
        }

        [Theory(DisplayName = "Não deve criar produto com nome menor que 3 ou maior que 100 caracteres")]
        [InlineData("AB", "O nome do produto deve ter no mínimo 3 caracteres.")]
        [InlineData("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA", "O nome do produto deve ter no máximo 100 caracteres.")]
        public void CreateProduct_InvalidNameLength_ShouldThrowDomainException(string invalidName, string expectedMessage)
        {
            Action act = () => new Product(invalidName, "Descrição válida com mais de 10 caracteres", 10.0m, 1, "https://example.com/image.jpg");

            act.Should().Throw<DomainExceptionValidation>()
               .WithMessage(expectedMessage);
        }

        [Theory(DisplayName = "Não deve criar produto com descrição nula ou vazia")]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void CreateProduct_InvalidDescription_ShouldThrowDomainException(string invalidDescription)
        {
            Action act = () => new Product("Nome Válido", invalidDescription, 10.0m, 1, "https://example.com/image.jpg");

            act.Should().Throw<DomainExceptionValidation>()
               .WithMessage("A descrição do produto não pode ser nula ou vazia.");
        }

        [Fact(DisplayName = "Não deve criar produto com descrição menor que 10 caracteres")]
        public void CreateProduct_DescriptionLessThan10Characters_ShouldThrowDomainException()
        {
            var shortDescription = "Curta";

            Action act = () => new Product("Nome Válido", shortDescription, 10.0m, 1, "https://example.com/image.jpg");

            act.Should().Throw<DomainExceptionValidation>()
               .WithMessage("A descrição do produto deve ter no mínimo 10 caracteres.");
        }

        [Fact(DisplayName = "Não deve criar produto com descrição maior que 500 caracteres")]
        public void CreateProduct_DescriptionGreaterThan500Characters_ShouldThrowDomainException()
        {
            var longDescription = new string('A', 501);

            Action act = () => new Product("Nome Válido", longDescription, 10.0m, 1, "https://example.com/image.jpg");

            act.Should().Throw<DomainExceptionValidation>()
               .WithMessage("A descrição do produto deve ter no máximo 500 caracteres.");
        }

        [Theory(DisplayName = "Não deve criar produto com preço zero ou negativo")]
        [InlineData(0)]
        [InlineData(-10.50)]
        public void CreateProduct_InvalidPrice_ShouldThrowDomainException(decimal invalidPrice)
        {
            Action act = () => new Product("Nome Válido", "Descrição válida com mais de 10 caracteres", invalidPrice, 1, "https://example.com/image.jpg");

            act.Should().Throw<DomainExceptionValidation>()
               .WithMessage("O preço do produto não pode ser negativo ou zero.");
        }

        [Fact(DisplayName = "Não deve criar produto com quantidade negativa")]
        public void CreateProduct_NegativeQuantity_ShouldThrowDomainException()
        {
            var invalidQuantity = -1;

            Action act = () => new Product("Nome Válido", "Descrição válida com mais de 10 caracteres", 10.0m, invalidQuantity, "https://example.com/image.jpg");

            act.Should().Throw<DomainExceptionValidation>()
               .WithMessage("A quantidade do produto não pode ser negativa.");
        }

        [Theory(DisplayName = "Não deve criar produto com URL da imagem nula ou vazia")]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void CreateProduct_InvalidImageUrl_ShouldThrowDomainException(string invalidImageUrl)
        {
            Action act = () => new Product("Nome Válido", "Descrição válida com mais de 10 caracteres", 10.0m, 1, invalidImageUrl);

            act.Should().Throw<DomainExceptionValidation>()
               .WithMessage("A URL da imagem do produto não pode ser nula ou vazia.");
        }

        [Fact(DisplayName = "Não deve criar produto com URL da imagem maior que 500 caracteres")]
        public void CreateProduct_ImageUrlGreaterThan500Characters_ShouldThrowDomainException()
        {
            var longImageUrl = new string('A', 501);

            Action act = () => new Product("Nome Válido", "Descrição válida com mais de 10 caracteres", 10.0m, 1, longImageUrl);

            act.Should().Throw<DomainExceptionValidation>()
               .WithMessage("A URL da imagem do produto deve ter no máximo 500 caracteres.");
        }

        [Fact(DisplayName = "Deve atualizar a categoria do produto com um CategoryId válido")]
        public void Update_WithValidCategoryId_ShouldSetCategoryId()
        {
            var product = new Product("Nome Válido", "Descrição válida com mais de 10 caracteres", 10.0m, 1, "https://example.com/image.jpg");
            var categoryId = Guid.NewGuid();

            product.Update("Novo Nome", "Nova descrição longa para o produto", 20.0m, 5, "https://example.com/nova-imagem.jpg", categoryId);

            product.CategoryId.Should().Be(categoryId);
        }

        [Fact(DisplayName = "Não deve atualizar o produto se o CategoryId for vazio")]
        public void Update_WithEmptyCategoryId_ShouldThrowDomainException()
        {
            var product = new Product("Nome Válido", "Descrição válida com mais de 10 caracteres", 10.0m, 1, "https://example.com/image.jpg");
            var emptyCategoryId = Guid.Empty;

            Action act = () => product.Update("Novo Nome", "Nova descrição longa para o produto", 20.0m, 5, "https://example.com/nova-imagem.jpg", emptyCategoryId);

            act.Should().Throw<DomainExceptionValidation>()
               .WithMessage("O Id da categoria não pode ser vazio.");
        }

        [Theory(DisplayName = "Deve atualizar o status de disponibilidade do produto")]
        [InlineData(false)]
        [InlineData(true)]
        public void UpdateAvailability_ShouldChangeAvailableProperty(bool newStatus)
        {
            var product = new Product("Nome Válido", "Descrição válida com mais de 10 caracteres", 10.0m, 1, "https://example.com/image.jpg");

            product.UpdateAvailability(newStatus);

            product.Available.Should().Be(newStatus);
        }
    }
}