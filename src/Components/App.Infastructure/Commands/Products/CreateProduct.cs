using System.ComponentModel.DataAnnotations;

using MediatR;

using App.Infastructure.BasicResults;
using App.Data.Entities;
using App.Data.Contexts;
using App.Data.Helpers;
using AutoMapper;

namespace App.Infastructure.Commands
{
    public static class CreateProduct
    {
        public class Request : IRequest<Result>
        {
            [MaxLength(100)]
            [Required]
            public string Name { get; set; }

            [Required]
            public decimal Price { get; set; }

            [Required]
            public decimal Vat { get; set; }

            public Category Category { get; set; }
        }

        public class Result : BasicResult
        {
            public Guid Id { get; set; }

            public Result(string message) : base(message)
            {
            }

            public Result(Guid id) : base()
            {
                Id = id;
            }
        }


        public class Handler(ReadWriteAppContext readWriteAppContext, IMapper mapper) : IRequestHandler<Request, Result>
        {
            private readonly ReadWriteAppContext _readWriteAppContext = readWriteAppContext;

            private readonly IMapper _mapper = mapper;

            public async Task<Result> Handle(Request request, CancellationToken cancellationToken)
            {
                var id = SequentialGuid.Create();
                var now = DateTime.Now;

                var product = new Product
                {
                    Id = SequentialGuid.Create(),
                    CreatedOn = now,
                    ModifiedOn = now,
                    Vat = request.Vat,
                    Price = request.Price,
                    Name = request.Name,
                    Category = request.Category,
                    IsDeprecated = false
                };

                _readWriteAppContext.Products.Add(product);

                await _readWriteAppContext.SaveChangesAsync();

                return new Result(id);
            }
        }
    }
}
