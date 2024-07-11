using MediatR;
using Project.Application.CQRS.Queries.Response;

namespace Project.Application.CQRS.Queries.Request;

public class GetAllProductQueryRequest : IRequest<List<GetAllProductQueryResponse>>
{
}
