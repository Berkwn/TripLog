using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLogServer.Application.Features.Trip.CreateTrip;
using TripLogServer.Domain.Entities;
using TripLogServer.Domain.Repositories;
using TripLogServer.Infrastructure.Context;
using TripLogServer.Infrastructure.Services;
using TS.Result;

namespace TripLogServer.Application.Features.Trips.CreateTrip
{
    public sealed class CreateTripCommandHandler(
        ITripRepository tripRepository,
        ITagRepository tagRepository,
        IFileStorageService fileStorageService) : IRequestHandler<CreateTripCommand, Result<string>>
    {
       

        public async Task<Result<string>> Handle(CreateTripCommand request, CancellationToken cancellationToken)
        {
           var tagList= request.Tags.Split(' ',StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var tags in tagList)
            {
                if (!tagRepository.Any(t => t.Name == tags))
                {
                    Tag tag = new()
                    {
                        Name = tags,
                    };

                    await tagRepository.CreateAsync(tag,cancellationToken);
                }

            }
            
            var triptags= tagRepository.where(searchtags=>tagList.Any(x=>x == searchtags.Name)).ToList();

            List<TripContent> tripContents = new();

            foreach (var item in request.tripContent)
            {  //content
                string ContentImageUrl = await fileStorageService.SaveFileAsync(item.Image, "contents", cancellationToken);
                TripContent tripContent = new()
                {
                    Title = item.title,
                    Description = item.description,
                    ImageUrl = ContentImageUrl
                };
                tripContents.Add(tripContent);
            }


            string ImageUrl = await fileStorageService.SaveFileAsync(request.Image, "trips", cancellationToken);

            TripEntity trip = new()
            {
                Title = request.title,
                Description = request.Description,
                Tags = triptags,
                ImageUrl = ImageUrl,
                TripContents = tripContents
            };

            Console.WriteLine(trip);
            await tripRepository.CreateAsync(trip, cancellationToken);
            
            Console.WriteLine(request);
            return "Ok";
        }
    }
}
