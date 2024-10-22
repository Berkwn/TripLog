using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLogServer.Domain.Entities;
using TripLogServer.Domain.Repositories;
using TS.Result;

namespace TripLogServer.Application.Features.Trip.CreateTrip
{
    public sealed class CreateTripCommandHandler(ITripRepository tripRepository) : IRequestHandler<CreateTripCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateTripCommand request, CancellationToken cancellationToken)
        {

            Console.WriteLine(request);
            return "Ok";
        }
    }
}
