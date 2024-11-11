using CNLTHD.DTO;
using CNLTHD.Models;

namespace CNLTHD.Repository.IRepository
{
    public interface IAuthRepository
    {
        Task CreateUser(User user);
        Task<bool> IsExist(CreateUserDto user);
        Task<User?> IsValidLogin(LoginUserDto loginUserDto);
    }
}
