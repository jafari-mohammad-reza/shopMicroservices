using MediatR;
using Microsoft.Extensions.Logging;
using Products.Application.Exception;
using Products.Doamin;

namespace Products.Application.Product.Commands.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProcutCommand, bool>
    {
        private readonly IGenericWriteUnitOfWork _writeUnitOfWork;
        private readonly IGenericReadUnitOfWork _readUnitOfWork;
        private readonly ILogger<DeleteProductCommandHandler> _logger;
        public DeleteProductCommandHandler(ILogger<DeleteProductCommandHandler> logger, IGenericReadUnitOfWork readUnitOfWork, IGenericWriteUnitOfWork writeUnitOfWork)
        {
            _logger = logger;
            _readUnitOfWork = readUnitOfWork;
            _writeUnitOfWork = writeUnitOfWork;

        }
        public async Task<bool> Handle(DeleteProcutCommand request, CancellationToken cancellationToken)
        {
            var targetProduct = await _readUnitOfWork.ProductReadRepository.GetAsync(request.Id);
            if (targetProduct == null) throw new NotFoundException("product is null", "product");
            await _writeUnitOfWork.ProductWriteRepository.RemoveAsync(targetProduct);
            _logger.LogInformation($"product with id of {request.Id} has been removed successfully.");
            return true;
        }
    }
}