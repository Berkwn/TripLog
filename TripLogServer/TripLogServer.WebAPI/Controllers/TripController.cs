using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripLogServer.Application.Features.Trip.CreateTrip;
using TripLogServer.Application.Features.Trips.DeleteTrip;
using TripLogServer.Application.Features.Trips.GetAllTrip;
using TripLogServer.Application.Features.Trips.UpdateTrip;
using TripLogServer.WebAPI.Abstractions;

namespace TripLogServer.WebAPI.Controllers
{
   
    public class TripController : ApiController
    {
        public TripController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateTripCommand request,CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> GetAll( GetAllTripQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdateTripCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteTripCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
