using CNLTHD.DTO;
using CNLTHD.Models;

namespace CNLTHD.Service.IService
{
    public interface IAuthService
    {
        Task<User?> Register(CreateUserDto createUserDto);
        Task<string> Login(LoginUserDto loginUserDto);
    }
}
