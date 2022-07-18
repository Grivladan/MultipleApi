using Microsoft.AspNetCore.Mvc;
using MultipleApiQueriesTest.DomainLogic;
using MultipleApiQueriesTest.WebApi.Requests;
using System;
using System.Threading.Tasks;

namespace MultipleApiQueriesTest.WebApi.Controllers
{
    [Route("api/offers")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly IOffersService _offersService;

        public OffersController(IOffersService offersService)
        {
            _offersService = offersService ?? throw new ArgumentNullException(nameof(offersService));
        }

        [HttpPost]
        public async Task<ActionResult<decimal>> GetOffers(BestDealRequest request) 
        {
            return await _offersService.GetBestDealAsync(request.DestinationAddress, request.SourceAddress, request.CartonDimensions);
        }
    }
}
