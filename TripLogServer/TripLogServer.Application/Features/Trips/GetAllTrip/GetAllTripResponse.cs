using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripLogServer.Application.Features.Trips.GetAllTrip;

public sealed record GetAllTripResponse
    (
    Guid Id,
    string Title,
    string ImageUrl,
    DateTime CreatedDate,
    string AppUserId,
    string Description,
    List<QueryTags> Tags,
    List<QueryTripContents> TripContents,
    QueryAppUser AppUser,
    IOrderedEnumerable<QueryComment> Comments
    );

public sealed record QueryTags(
    Guid id,
    string Name);

public sealed record QueryTripContents(
    Guid id ,
    string Title,
    string Description,
    string ImageUrl
    );

public sealed record QueryAppUser(
    string Id,
    string Email,
    string UserName,
    bool IsAuthor
        );

public sealed record QueryComment(
    Guid Id,
    string Text,
    DateTime CreatedDate,
    QueryAppUser AppUser);



