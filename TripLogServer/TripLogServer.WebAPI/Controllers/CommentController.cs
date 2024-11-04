using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripLogServer.Application.Features.Auth;
using TripLogServer.Application.Features.CommandFolder.CreateCommand;
using TripLogServer.Application.Features.CommentFolder.GetComments;
using TripLogServer.WebAPI.Abstractions;

namespace TripLogServer.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : ApiController
    {
        public CommentController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateComment request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);

        }

        [HttpPost]
        public async Task<IActionResult> GetAllComments(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);

        }
    }
}
