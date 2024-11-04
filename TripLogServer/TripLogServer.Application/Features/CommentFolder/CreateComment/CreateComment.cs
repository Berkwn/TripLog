using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLogServer.Domain.Entities;
using TripLogServer.Domain.Repositories;
using TS.Result;

namespace TripLogServer.Application.Features.CommandFolder.CreateCommand
{
    public sealed record  CreateComment(Guid TripId,string AppUserId,string Description) :IRequest<Result<string>>;


    internal sealed class CreateCommentHandler(UserManager<AppUser> userManager, ICommentRepository commentRepository) : IRequestHandler<CreateComment, Result<string>>
{
        public async Task<Result<string>> Handle(CreateComment request, CancellationToken cancellationToken)
        {
            var user = userManager.Users.FirstOrDefault(x => x.Id == request.AppUserId);

                if (user == null)
                {
                return Result<string>.Failure("Kullanıcı bilgileri alınamadı lütfen tekrar giriş yapınız!");
                }


            Command command = new()
            {
                AppUserId = request.AppUserId,
                Description = request.Description,
                TripEntityId=request.TripId
            };

            await commentRepository.CreateAsync(command, cancellationToken);

            return "Değerli görüşünüz gezi sahibiyle paylaşılmıştır";
          
        }
    }
}
