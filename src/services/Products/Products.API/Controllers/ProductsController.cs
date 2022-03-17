using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Product.Commands.Create;
using Products.Application.Product.Commands.Delete;
using Products.Application.Product.Commands.Update;
using Products.Application.Product.Queries.GetAll;
using Products.Doamin;
using Products.Doamin.products;

namespace Products.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericReadUnitOfWork _readUnitOfWork;
        private readonly IGenericWriteUnitOfWork _writeUnitOfWork;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ProductsController(IGenericReadUnitOfWork readUnitOfWork, IGenericWriteUnitOfWork writeUnitOfWork, IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _writeUnitOfWork = writeUnitOfWork;
            _readUnitOfWork = readUnitOfWork;
        }
        [HttpGet]
        public async Task<List<ProductResponseDto>> GetProducts()
        {
            return await _mediator.Send(new ProductGetAllQuery());
            
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _readUnitOfWork.ProductReadRepository.GetAsync(id);
        }
        [HttpPost]
        public async Task<ProductResponseDto> CreateProduct([FromBody] AddProductCommand request)
        {
            return await _mediator.Send(request);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductCommand request)
        {
            if (id != request.Id)
            {
                return BadRequest("the id from the router and id from body are not the same");
            }
            await _mediator.Send(request);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _mediator.Send(new DeleteProcutCommand { Id = id });
            return Ok();
        }
    }
}