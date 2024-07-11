using MediatR;
using Project.Application.CQRS.Commands.Response;

namespace Project.Application.CQRS.Commands.Request;

public class CreateProductCommandRequest:IRequest<CreateProductCommandResponse>
{

    //cons
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Created_date { get; set; }
    public DateTime Updated_date { get; set; }
    public DateTime Deleted_date { get; set; }
    public bool IsDeleted { get; set; }
}
