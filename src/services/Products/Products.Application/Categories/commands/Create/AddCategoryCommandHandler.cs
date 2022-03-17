using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Products.Doamin;
using Products.Doamin.categories;

namespace Products.Application.Categories.commands.Create
{
    public class AddCategoryCommnadHandler : IRequestHandler<AddCategoryCommnad, Category>
    {
        private readonly IGenericWriteUnitOfWork _writeUnitOfWrok;
        private readonly ILogger<AddCategoryCommnadHandler> _logger;
        private readonly IMapper _mapper;
        public AddCategoryCommnadHandler(ILogger<AddCategoryCommnadHandler> logger, IGenericWriteUnitOfWork writeUnitOfWrok, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _writeUnitOfWrok = writeUnitOfWrok;

        }
        public async Task<Category> Handle(AddCategoryCommnad request, CancellationToken cancellationToken)
        {

            var newCategory = _mapper.Map<Category>(request);
            await _writeUnitOfWrok.CategoryWriteRepository.AddAsync(newCategory);
            _logger.LogInformation($"category with id of {newCategory.Id} just added successfully");
            return newCategory;
        }
    }
}