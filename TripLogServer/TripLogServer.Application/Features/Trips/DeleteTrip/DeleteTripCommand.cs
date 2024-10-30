using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLogServer.Domain.Repositories;
using TripLogServer.Infrastructure.Services;
using TS.Result;

namespace TripLogServer.Application.Features.Trips.DeleteTrip
{
    public sealed record DeleteTripCommand(Guid id) :IRequest<Result<string>>;

    internal sealed class DeleteTripCommandHandler(ITripRepository tripRepository,IFileStorageService fileStorageService) : IRequestHandler<DeleteTripCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteTripCommand request, CancellationToken cancellationToken)
        {
            var response =  tripRepository.FirstOrDefault(x => x.Id == request.id);

            if (response.ImageUrl != null)
            {

                foreach (var item in response.TripContents)
                {
                    await fileStorageService.DeleteFileAsync(item.ImageUrl, cancellationToken);
                }

            }


            if (response != null) {

          
                await tripRepository.DeleteAsync(response, cancellationToken);
            }


         

            return "ok";

        }
    }
}
