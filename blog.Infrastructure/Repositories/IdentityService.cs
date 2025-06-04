using AutoMapper;
using blog.Core.DTOs.AccountDtos;
using blog.Core.Entities;
using blog.Core.Interfaces;
using blog.Infrastructure.DatabaseContext;
using Microsoft.AspNetCore.Identity;

namespace blog.Infrastructure.Repositories
{
    public class IdentityService : IIdentityService
    {


        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;

        public IdentityService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var result = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, isPersistent: false, lockoutOnFailure: false);

            return result.Succeeded
                ? "Login successful"
                : "Invalid email or password";
        }

        public async Task<string> RegisterAsync(RegisterDto dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                FullName = dto.FullName
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            return result.Succeeded
                ? "Registration successful"
                : string.Join(", ", result.Errors.Select(e => e.Description));
        }

    }
}
