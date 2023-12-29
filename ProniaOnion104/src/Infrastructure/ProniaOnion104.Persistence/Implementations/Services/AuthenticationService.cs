using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProniaOnion104.Application.Abstractions.Services;
using ProniaOnion104.Application.DTOs.Tokens;
using ProniaOnion104.Application.DTOs.Users;
using ProniaOnion104.Domain.Entities;
using System.Text;

namespace ProniaOnion104.Persistence.Implementations.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMapper _mapper;
        private readonly ITokenHandler _handler;
        private readonly UserManager<AppUser> _userManager;

        public AuthenticationService(IMapper mapper,ITokenHandler handler, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _handler = handler;
            _userManager = userManager;
        }

       
        public async Task Register(RegisterDto dto)
        {

           AppUser user=await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == dto.UserName || u.Email == dto.Email);
            if (user is not null) throw new Exception("same");
           user=_mapper.Map<AppUser>(dto);

           var result= await _userManager.CreateAsync(user,dto.Password);
            if (!result.Succeeded)
            {
                StringBuilder message = new StringBuilder();

                foreach (var error in result.Errors)
                {
                    message.AppendLine(error.Description);
                }
                
                throw new Exception(message.ToString());
            }

        }
        public async Task<TokenResponseDto> Login(LoginDto dto)
        {
            AppUser user = await _userManager.FindByNameAsync(dto.UserNameOrEmail);
            if (user is null)
            {
                user = await _userManager.FindByEmailAsync(dto.UserNameOrEmail);
                if (user is null) throw new Exception("Username, Email or Password incorrect"); 
            }
            if (!await _userManager.CheckPasswordAsync(user, dto.Password)) throw new Exception("Username, Email or Password incorrect");

            return _handler.CreateJwt(user, 60);
          
        }

    }
}
