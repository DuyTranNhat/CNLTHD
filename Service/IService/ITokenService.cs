using CNLTHD.Models;

namespace CNLTHD.Service.IService
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
