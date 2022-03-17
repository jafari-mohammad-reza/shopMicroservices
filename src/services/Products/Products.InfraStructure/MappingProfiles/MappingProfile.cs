using AutoMapper;
using Products.Doamin.products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.InfraStructure.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product , ProductRequestDto >().ReverseMap();
            CreateMap<Product, ProductResponseDto>().ReverseMap();
       
        }
    }
}
