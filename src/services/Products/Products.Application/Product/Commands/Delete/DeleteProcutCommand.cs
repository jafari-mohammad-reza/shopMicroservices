using MediatR;

namespace Products.Application.Product.Commands.Delete
{
    public class DeleteProcutCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}