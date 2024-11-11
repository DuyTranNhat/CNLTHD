using CNLTHD.Data;
using CNLTHD.DTO;
using CNLTHD.Models;
using CNLTHD.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CNLTHD.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly CnlthdDbContext _context;

        public AuthRepository(CnlthdDbContext context)
        {
            _context = context;
        }
        public async Task CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> IsExist(CreateUserDto createUserDto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == createUserDto.Email || x.Phone == createUserDto.Phone);
            if (existingUser != null) return true;
            return false;
        }
        public async Task<User?> IsValidLogin(LoginUserDto loginUserDto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == loginUserDto.Username || x.Phone == loginUserDto.Username);
            if (existingUser == null) return null;
            if (!BCrypt.Net.BCrypt.EnhancedVerify(loginUserDto.Password, existingUser.Password)) return null;
            return existingUser;
        }
    }
}
