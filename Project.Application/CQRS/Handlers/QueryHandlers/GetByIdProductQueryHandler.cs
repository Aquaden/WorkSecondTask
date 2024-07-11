using AutoMapper;
using MediatR;
using Project.Application.CQRS.Commands.Request;
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
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest,GetByIdProductQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public GetByIdProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var data = _unitOfWork.ProductRepository.GetById(request.Id);
            var data2 = _mapper.Map<Product>(data);
            return new GetByIdProductQueryResponse
            {
                Id = data2.Id,
                Name = data2.Name,
                Description = data2.Description,
                Created_date = DateTime.Now,
                Updated_date = data2.Updated_date,
                Deleted_date = data2.Deleted_date,
                IsDeleted = data2.IsDeleted

            };
        }
    }
}
