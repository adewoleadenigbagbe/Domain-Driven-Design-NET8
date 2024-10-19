using System.ComponentModel.DataAnnotations;

using MediatR;

using App.Infastructure.BasicResults;
using App.Data.Entities;
using App.Data.Contexts;
using App.Data.Helpers;

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


        public class Handler : IRequestHandler<Request, Result>
        {
            private readonly ReadWriteAppContext _readWriteAppContext;

            public Handler(ReadWriteAppContext readWriteAppContext)
            {
                _readWriteAppContext = readWriteAppContext;
            }

            public async Task<Result> Handle(Request request, CancellationToken cancellationToken)
            {
                var id = SequentialGuid.Create();
                var now = DateTime.Now;

                var product = new Product
                {
                    Id = id,
                    Name = request.Name,
                    Vat = request.Vat,
                    Category = request.Category,
                    Price = request.Price,
                    IsDeprecated = false,
                    CreatedOn = now,
                    ModifiedOn = now
                };

                _readWriteAppContext.Products.Add(product);

                await _readWriteAppContext.SaveChangesAsync();

                return new Result(id);
            }
        }
    }
}
