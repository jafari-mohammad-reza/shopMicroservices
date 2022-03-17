using AutoMapper;
using MediatR;
using Products.Doamin;
using Products.Doamin.products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Product.Queries.GetAll
{
    public class ProductsGetAllQueryHandler : IRequestHandler<ProductGetAllQuery, List<ProductResponseDto>>
    {
        private IGenericReadUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;
        public ProductsGetAllQueryHandler(IGenericReadUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfwork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ProductResponseDto>> Handle(ProductGetAllQuery request, CancellationToken cancellationToken)
        {
            var products = await _unitOfwork.ProductReadRepository.GetAllAsync();
            return _mapper.Map<List<ProductResponseDto>>(products);
        }   
    }
}
