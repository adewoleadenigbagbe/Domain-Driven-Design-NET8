using App.Infastructure.Queries.Countrys;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("population/cities")]
        public async Task<IActionResult> GetCityPopulation()
        {
            var request = new GetCityPopulation.Query();
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
