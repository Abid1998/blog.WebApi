using blog.Core.DTOs.AccountDtos;

namespace blog.Core.Interfaces
{
    public interface IIdentityService
    {
        Task<string> RegisterAsync(RegisterDto dto);
        Task<string> LoginAsync(LoginDto dto);
    }
}
