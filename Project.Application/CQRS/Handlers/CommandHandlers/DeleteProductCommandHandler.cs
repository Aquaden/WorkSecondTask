using AutoMapper;
using MediatR;
using Project.Application.CQRS.Commands.Request;
using Project.Application.CQRS.Commands.Response;
using Project.Repository.UnitOfWorks;
using Project.SQL.Server.DbContexts;

namespace Project.Application.CQRS.Handlers.CommandHandlers;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    public readonly IMapper _mapper;
    public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        _unitOfWork.ProductRepository.DeleteProudct(request.Id);
        _unitOfWork.SaveChanegsAsync();
        return new DeleteProductCommandResponse()
        {
            IsSuccess = true,
            
        };
    }
}
