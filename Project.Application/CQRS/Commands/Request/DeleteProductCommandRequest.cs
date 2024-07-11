using MediatR;
using Project.Application.CQRS.Commands.Response;

namespace Project.Application.CQRS.Commands.Request;

public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
{
    public DeleteProductCommandRequest(int productId)
    {
        Id = productId;
    }

    public int Id { get; set; }
}
