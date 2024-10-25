using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLogServer.Domain.Entities;
using TS.Result;

namespace TripLogServer.Application.Features.Trips.GetAllTrip
{
    public sealed record GetAllTripQuery() :IRequest<Result<List<TripEntity>>>;
}
