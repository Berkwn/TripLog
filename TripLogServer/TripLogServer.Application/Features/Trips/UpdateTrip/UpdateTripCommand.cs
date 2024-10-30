using MediatR;
using Microsoft.AspNetCore.Http;
using TripLogServer.Domain.Entities;
using TripLogServer.Domain.Repositories;
using TripLogServer.Infrastructure.Services;
using TS.Result;

namespace TripLogServer.Application.Features.Trips.UpdateTrip;

public sealed record UpdateTripCommand(
    Guid id,
    string title,
    string description,
    IFormFile? Image,
    string Tags,
    List<UpdateTripContent> TripContents
    ) : IRequest<Result<string>>;

public sealed record UpdateTripContent(
    Guid? id,
    string title,
    string description,
    IFormFile? Image
    );



internal sealed class UpdateTripCommandHandler(
    ITagRepository tagRepository,
    ITripRepository tripRepository,
    ITripContentRepository tripContentRepository,
    IFileStorageService fileStorageService) : IRequestHandler<UpdateTripCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateTripCommand request, CancellationToken cancellationToken)
    {
        var tagList =request.Tags.Split(' ',StringSplitOptions.RemoveEmptyEntries);

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


        var tripTags= tagRepository.where(searchtags=>tagList.Any(x=>x==searchtags.Name)).ToList();

        TripEntity trip = tripRepository.FirstOrDefault(x => x.Id == request.id);
        if (trip != null) 
        {
            trip.Title = request.title;
            trip.Description = request.description;
            var existingTagsIds=trip.Tags.Select(x=>x.Id);
            var updateTagIds=tripTags.Select(x=>x.Id);
            var TagIdsToAdd=updateTagIds.Except(existingTagsIds);
            var TagIdsToRemove = existingTagsIds.Except(updateTagIds);

            if (TagIdsToRemove.Any()) 
            {
                var tagsToRemove= trip.Tags.Where(x=>TagIdsToRemove.Contains(x.Id)).ToList();
                foreach (var tagToRemove in tagsToRemove) 
                { 
                
                    trip.Tags.Remove(tagToRemove);
                
                }
            
            }

            if (TagIdsToAdd.Any()) 
            {
                var tagsToAdd=tripTags.Where(x=>TagIdsToAdd.Contains(x.Id)).ToList();
                foreach(var tagToAdd in tagsToAdd)
                {
                    tripTags.Add(tagToAdd);
                }
            }

            if (request.Image != null) 
            {
                string ContentImageUrl = await fileStorageService.SaveFileAsync(request.Image, "trips", cancellationToken);

                trip.ImageUrl = ContentImageUrl;

            }

            foreach (var content in trip.TripContents)
            {
                UpdateTripContent tripContent = request.TripContents.FirstOrDefault(x => x.id == content.Id);
                if (tripContent != null) 
                {
                    content.Title = tripContent.title;
                    content.Description = tripContent.description;
                    if(tripContent.Image!= null)
                    {
                        string ContentImageUrl = await fileStorageService.SaveFileAsync(request.Image, "contents", cancellationToken);
                        await fileStorageService.DeleteFileAsync(ContentImageUrl, cancellationToken);   
                        content.ImageUrl = ContentImageUrl;

                    }

                }
            }

            List<UpdateTripContent> updateTripContents =request.TripContents.Where(x=>x.id==null).ToList();
            foreach (var item in updateTripContents)
            {
                string ContentImageUrl = await fileStorageService.SaveFileAsync(request.Image, "trips", cancellationToken);

                TripContent tripContent = new()
                {
                    Title = item.title,
                    Description = item.description,
                    ImageUrl = ContentImageUrl,
                    Trip = trip
                };

                await tripContentRepository.CreateAsync(tripContent,cancellationToken);
            }

        }

        return "OK";
    }

}

    


