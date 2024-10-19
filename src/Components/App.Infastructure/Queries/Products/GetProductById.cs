using System.Net;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Newtonsoft.Json;

using App.Data.Contexts;
using App.Infastructure.BasicResults;
using App.Infastructure.Models;
using MediatR;

namespace App.Infastructure.Queries.Products
{
    public static class GetProductById
    {
        public class Query : IRequest<Result>
        {
            [JsonIgnore]
            public Guid Id { get; set;}
        }

        public class Result : BasicResult
        {
            public ProductModel Product { get; set;}

            public Result(HttpStatusCode code, string message) : base(code,message)
            {
            }

            public Result(ProductModel product) : base()
            {
                Product = product;
            }
        }


        public class Handler : IRequestHandler<Query, Result>
        {
            private readonly ReadAppContext _readAppContext;

            private readonly IMapper _mapper;

            public Handler(ReadAppContext readAppContext, IMapper mapper)
            {
                _readAppContext = readAppContext;
                _mapper = mapper;
            }

            public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
            {
                var product = await _readAppContext.Products.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (product == null)
                {
                    return new Result(HttpStatusCode.NotFound,"Product not found");
                }

                var productModel = _mapper.Map<ProductModel>(product);

                return new Result(productModel);
            }
        }

    }
}
