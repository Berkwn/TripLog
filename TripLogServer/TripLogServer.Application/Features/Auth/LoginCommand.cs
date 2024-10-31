using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLogServer.Application.Services;
using TripLogServer.Domain.Entities;
using TS.Result;

namespace TripLogServer.Application.Features.Auth
{
    public sealed record LoginCommand(string userNameOrEmail,string password) :IRequest<Result<LoginCommandResponse>>;
    
    public sealed record LoginCommandResponse(string token);

    public sealed class LoginCommandHandler(UserManager<AppUser> userManager, IJwtProvider jwtProvider) :
 IRequestHandler<LoginCommand, Result<LoginCommandResponse>>
    {
        public async Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            AppUser? user =await userManager.Users.FirstOrDefaultAsync(x=>x.UserName==request.userNameOrEmail || x.Email==request.userNameOrEmail, cancellationToken);


            bool checkPassword= await userManager.CheckPasswordAsync(user,request.password);
            if (!checkPassword) 
            {
                return Result<LoginCommandResponse>.Failure("şifre doğru değil");
            }
              
            
            
            if (user == null) 
            {

                return Result<LoginCommandResponse>.Failure("Böyle bir kullanıcı bulunamadı");
            
            }

            string token = await jwtProvider.CreateToken(user);
            LoginCommandResponse response = new(token);

            return Result<LoginCommandResponse>.Succeed(response);

        }
    }
}
