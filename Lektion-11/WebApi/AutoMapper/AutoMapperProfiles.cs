using AutoMapper;
using WebApi.Models;

namespace WebApi.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProductEntity, Product>();
            CreateMap<Product, ProductEntity>();
            CreateMap<ProductRequest, ProductEntity>();

            CreateMap<CustomerEntity, Customer>();
            CreateMap<Customer, CustomerEntity>();
            CreateMap<CustomerRequest, CustomerEntity>();
        }
    }
}
