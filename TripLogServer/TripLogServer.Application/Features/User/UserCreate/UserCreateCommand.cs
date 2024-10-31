using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLogServer.Domain.Entities;
using TS.Result;

namespace TripLogServer.Application.Features.User.UserCreate;

public sealed record UserCreateCommand(string userName,
    string email,
    string password,
    string passwordCheck,
    bool isAuthor) : IRequest<Result<string>>;


internal sealed class UserCreateCommandHandler(UserManager<AppUser> userManager)
    : IRequestHandler<UserCreateCommand, Result<string>> 
{
    public async Task<Result<string>> Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.userName) ||
            string.IsNullOrEmpty(request.email) ||
            string.IsNullOrEmpty(request.password) ||
            string.IsNullOrEmpty(request.passwordCheck))

            if (request.password!=request.passwordCheck)
        {
            return Result<string>.Failure("şifreler eşleşmiyor");
        }

        if(userManager.Users.Any(x=>x.Email==request.email))
        {
            return Result<string>.Failure("böyle bir email zaten var ");
        }

        if (userManager.Users.Any(x => x.UserName == request.userName))
        {

            return Result<string>.Failure("böyle bir kullanıcı zaten var!!");
        };

        AppUser user = new()
        {
            UserName = request.userName,
            Email = request.email,
            IsAuthor = request.isAuthor

        };

       IdentityResult ıdentityResult= await userManager.CreateAsync(user,request.password);
        if (!ıdentityResult.Succeeded)
        {
            return Result<string>.Failure( "Kullanıcı ile oluşurken bir hata oluştu. Lütfen tüm alanları doldurunuz" +string.Join("\n", ıdentityResult.Errors.Select(x=>x.Description)));
        }

        return " kullanıcı kaydı başarıyla tamamlandı. Hoş geldin " + user.UserName;
        


       
    }


}


