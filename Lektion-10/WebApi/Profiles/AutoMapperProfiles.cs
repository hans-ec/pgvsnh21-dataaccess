using AutoMapper;
using WebApi.Models.Product;

namespace WebApi.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProductEntity, Product>()
                .ForMember(d => d.ArticleNumber, option => option.MapFrom(s => s.ArticleNr));
            CreateMap<Product, ProductEntity>()
                 .ForMember(d => d.ArticleNr, option => option.MapFrom(s => s.ArticleNumber));
        }
    }
}
