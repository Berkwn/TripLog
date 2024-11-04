using MediatR;
using TripLogServer.Domain.Entities;
using TripLogServer.Domain.Repositories;
using TS.Result;

namespace TripLogServer.Application.Features.Trips.GetAllTrip
{
    public sealed class GetAllTripQueryHandler(ITripRepository tripRepository) : IRequestHandler<GetAllTripQuery, Result<List<GetAllTripResponse>>>
    {
        public async Task<Result<List<GetAllTripResponse>>> Handle(GetAllTripQuery request, CancellationToken cancellationToken)
        {
            var response = tripRepository.GetAllTripWithContents().OrderByDescending(x => x.CreatedDate).ToList()
                .Select(x => new GetAllTripResponse
                (x.Id,
                  x.Title,
                  x.ImageUrl,
                  x.CreatedDate,
                  x.AppUserId,
                  x.Description,
                  x.Tags.Select(x => new QueryTags
                  (
                      x.Id,
                      x.Name
                     )).ToList(),
                  x.TripContents.Select(x => new QueryTripContents
                  (
                     x.Id,
                     x.Title,
                     x.Description,
                     x.ImageUrl)).ToList(),

                  new QueryAppUser
                  (
                    x.AppUser.Id,
                    x.AppUser.Email,
                    x.AppUser.UserName,
                    x.AppUser.IsAuthor


                  ),
                  x.Commands.Select(x => new QueryComment
                  (
                      x.Id,
                      x.Description,
                      x.CreatedDate,
                      new QueryAppUser(
                          x.AppUser.Id,
                          x.AppUser.Email,
                          x.AppUser.UserName,
                          x.AppUser.IsAuthor
                      ))).OrderByDescending(x => x.CreatedDate)
                    )).ToList();


            return response;
        }


        
    }
}
