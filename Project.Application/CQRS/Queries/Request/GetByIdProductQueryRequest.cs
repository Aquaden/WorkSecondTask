using MediatR;
using Project.Application.CQRS.Queries.Response;

namespace Project.Application.CQRS.Queries.Request;

public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
{
    public GetByIdProductQueryRequest(int id)
    {
        Id = id;
    }

    public int Id { get; set; }  
}
