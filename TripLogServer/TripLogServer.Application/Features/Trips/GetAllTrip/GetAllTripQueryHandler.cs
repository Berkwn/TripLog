﻿using MediatR;
using TripLogServer.Domain.Entities;
using TripLogServer.Domain.Repositories;
using TS.Result;

namespace TripLogServer.Application.Features.Trips.GetAllTrip
{
    public sealed class GetAllTripQueryHandler(ITripRepository tripRepository) : IRequestHandler<GetAllTripQuery, Result<List<TripEntity>>>
    {
        public async Task<Result<List<TripEntity>>> Handle(GetAllTripQuery request, CancellationToken cancellationToken)
        {
            var response =  tripRepository.GetAllTripWithContents();
            return response.ToList();
        }

        
    }
}