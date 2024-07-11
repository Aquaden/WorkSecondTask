using AutoMapper;
using Project.Application.CQRS.Commands.Request;
using Project.Application.CQRS.Queries.Response;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Profiles
{
    public class MyMapper : Profile
    {
        public MyMapper()
        {
            CreateMap<CreateProductCommandRequest, Product>().ReverseMap();
            CreateMap<GetAllProductQueryResponse, Product>().ReverseMap();

        }
    }
}
