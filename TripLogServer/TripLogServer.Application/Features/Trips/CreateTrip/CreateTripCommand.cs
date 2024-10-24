using MediatR;
using Microsoft.AspNetCore.Http;
using TripLogServer.Domain.Entities;
using TS.Result;

namespace TripLogServer.Application.Features.Trip.CreateTrip
{
    public sealed record CreateTripCommand(
        string title,
        string Description,
        IFormFile Image,
        string Tags,
        List<TripContentCommand> tripContent
        ): IRequest<Result<string>>;
    
    public sealed record TripContentCommand(
        string title,
        string description,
        IFormFile Image
        );

}
