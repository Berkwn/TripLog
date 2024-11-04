using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLogServer.Application.Features.Trips.GetAllTrip;
using TripLogServer.Domain.Repositories;
using TS.Result;

namespace TripLogServer.Application.Features.CommentFolder.GetComments
{
    public sealed record GetCommentsQuery(
        
        Guid TripId


        ) :IRequest<Result<List<QueryComment>>>;

    public sealed class GetCommentQueryResponse(ICommentRepository commentRepository) : IRequestHandler<GetCommentsQuery, Result<List<QueryComment>>>
    {
        public async Task<Result<List<QueryComment>>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var response = commentRepository.where(x => x.TripEntityId == request.TripId).OrderByDescending(x => x.CreatedDate).Select(x=> new  QueryComment
            (
                x.Id,
                x.Description,
                x.CreatedDate,
                new QueryAppUser(
                    x.AppUser.Id,
                    x.AppUser.Email,
                    x.AppUser.UserName,
                    x.AppUser.IsAuthor
                    ))).ToList();


            return response;
        }
    }
}
