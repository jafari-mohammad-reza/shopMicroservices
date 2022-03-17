using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Products.Doamin;
using Products.Doamin.products;

namespace Products.Application.Product.Commands.Create
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, ProductResponseDto>
    {
        private readonly IGenericWriteUnitOfWork _writeUnitOfWork;
        private readonly ILogger<AddProductCommandHandler> _logger;
        private readonly IMapper _mapper;
        public AddProductCommandHandler(IMapper mapper, ILogger<AddProductCommandHandler> logger, IGenericWriteUnitOfWork writeUnitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _writeUnitOfWork = writeUnitOfWork;
        }
        public async Task<ProductResponseDto> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            Doamin.products.Product newProduct = _mapper.Map<Doamin.products.Product>(request);
            await _writeUnitOfWork.ProductWriteRepository.AddAsync(newProduct);
            _logger.LogInformation($"Product {newProduct.Title} just added successfully {DateTime.Today}");
            return _mapper.Map<ProductResponseDto>(newProduct);
        }
    }
}