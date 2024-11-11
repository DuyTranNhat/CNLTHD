using CNLTHD.DTO;
using CNLTHD.Models;
using CNLTHD.Repository;
using CNLTHD.Repository.IRepository;
using CNLTHD.Service.IService;
using Org.BouncyCastle.Crypto.Generators;

namespace CNLTHD.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly ITokenService _tokenService;
        public AuthService(IAuthRepository authRepository, ITokenService tokenService)
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
        }
        public async Task<User?> Register(CreateUserDto createUserDto)
        {
            var isExit = await _authRepository.IsExist(createUserDto);
            if (isExit) return null;
            string hashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(createUserDto.Password, 13);
            createUserDto.Password = hashedPassword;
            var user = new User()
            {
                FullName = createUserDto.FullName,
                Password = createUserDto.Password,
                Email = createUserDto.Email,
                Role = createUserDto.Role,
                Phone = createUserDto.Phone,
                Address = createUserDto.Address
            };
            await _authRepository.CreateUser(user);
            return user;
        }
        public async Task<string?> Login(LoginUserDto loginUserDto)
        {
            var user = await _authRepository.IsValidLogin(loginUserDto);
            if (user == null) return null;
            string token = _tokenService.GenerateToken(user);
            return token;
        }

    }
}
