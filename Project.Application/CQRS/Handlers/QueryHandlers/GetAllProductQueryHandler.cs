using AutoMapper;
using MediatR;
using Project.Application.CQRS.Queries.Request;
using Project.Application.CQRS.Queries.Response;
using Project.Domain.Entities;
using Project.Repository.UnitOfWorks;
using Project.SQL.Server.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.CQRS.Handlers.QueryHandlers
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public GetAllProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var data = _unitOfWork.ProductRepository.GetAllProducts();
            var data2 = _mapper.Map<List<GetAllProductQueryResponse>>(data);

            return data2;

        }
    } 
}

