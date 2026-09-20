using AutoMapper;
using Rental.Application.Categories.Commands;
using Rental.Application.DTOs;
using Rental.Application.Products.Commands;

namespace Rental.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<CategoryDTO, CategoryCreateCommand>();
            CreateMap<CategoryDTO, CategoryUpdateCommand>();
           
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
         
        }
    }
}
