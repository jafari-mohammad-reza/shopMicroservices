using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Products.Application.Exception;
using Products.Application.Product.Commands.Create;
using Products.Doamin;
using Products.Doamin.products;

namespace Products.Application.Product.Commands.Update
{
    public class UpdateProductCommandhandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IGenericWriteUnitOfWork _writeUnitOfWork;
        private readonly ILogger<AddProductCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IGenericReadUnitOfWork _readUnitOfWork;
        public UpdateProductCommandhandler(IMapper mapper, ILogger<AddProductCommandHandler> logger, IGenericWriteUnitOfWork writeUnitOfWork, IGenericReadUnitOfWork readUnitOfWork)
        {
            _readUnitOfWork = readUnitOfWork;
            _mapper = mapper;
            _logger = logger;
            _writeUnitOfWork = writeUnitOfWork;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Doamin.products.Product product = await _readUnitOfWork.ProductReadRepository.GetAsyncNotTracked(request.Id);
            if (product == null) throw new NotFoundException("product is null", "product");
            var updatableProduct = _mapper.Map<Doamin.products.Product>(request);
             await _writeUnitOfWork.ProductWriteRepository.UpdateAsync(updatableProduct);
            _logger.LogInformation($"Product {updatableProduct.Id} just updated successfully at {DateTime.UtcNow.Date}");
            return true;
        }
    }
}