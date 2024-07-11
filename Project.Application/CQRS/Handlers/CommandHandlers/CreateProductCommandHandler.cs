using AutoMapper;
using MediatR;
using Project.Application.CQRS.Commands.Request;
using Project.Application.CQRS.Commands.Response;
using Project.Domain.Entities;
using Project.Repository.UnitOfWorks;

namespace Project.Application.CQRS.Handlers.CommandHandlers;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    public readonly IMapper _mapper;
    public CreateProductCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {

        var data = _mapper.Map<Product>(request);
        await _unitOfWork.ProductRepository.AddProduct(data);
        await _unitOfWork.SaveChanegsAsync();
        return new CreateProductCommandResponse()
        {
            IsSuccess = true,
            Id = data.Id,
        };

    }
}
