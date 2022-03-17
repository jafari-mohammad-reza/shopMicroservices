using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Products.Application.Exception;
using Products.Doamin;
using Products.Doamin.products;

namespace Products.Application.Product.Queries.Get
{
    internal class ProductGetQueryHandler : IRequestHandler<ProductGetQuery, ProductResponseDto>
    {
        private IGenericReadUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;
        public ProductGetQueryHandler(IGenericReadUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfwork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ProductResponseDto> Handle(ProductGetQuery request, CancellationToken cancellationToken)
        {
            var product =await _unitOfwork.ProductReadRepository.GetAsync(request.Id);
            if(product == null) throw new NotFoundException("product is null", "product");
            return _mapper.Map<ProductResponseDto>(product);
        }
    }
}
