using Mango.Services.AuthAPI.Data;
using Mango.Services.AuthAPI.Models;
using Mango.Services.AuthAPI.Models.Dto;
using Mango.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Identity;

namespace Mango.Services.AuthAPI.Service
{
    public class AuthService(AppDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator) : IAuthService
    {
        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = db.ApplicationUsers.FirstOrDefault(u=>u.Email.ToLower() == email.ToLower());
            if(user != null)
            {
                if(!roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult()) {
                    //Create role if it does not exist
                    roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                }
                await userManager.AddToRoleAsync(user, roleName);
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto requestDto)
        {
            var user = db.ApplicationUsers.FirstOrDefault(u=>u.UserName.ToLower() == requestDto.UserName.ToLower());
            bool isValid = await userManager.CheckPasswordAsync(user, requestDto.Password);
            if (user == null || isValid == false) return new LoginResponseDto() { User = null, Token = "" };
            var roles = await userManager.GetRolesAsync(user);
            var token = jwtTokenGenerator.GenerateToken(user, roles);
            UserDTO userDto = new()
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber
            };
            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                User = userDto,
                Token = token
            };
            return loginResponseDto;
        }

        public async Task<string> Register(RegistrationRequestDTO requestDTO)
        {
            ApplicationUser user = new()
            {
                UserName = requestDTO.Email,
                Email = requestDTO.Email,
                NormalizedEmail = requestDTO.Email.ToUpper(),
                Name = requestDTO.Name,
                PhoneNumber = requestDTO.PhoneNumber,
            };
            try
            {
                var result = await userManager.CreateAsync(user, requestDTO.Password);
                if (result.Succeeded)
                {
                    var userToReturn = db.ApplicationUsers.First(x => x.UserName == requestDTO.Email);
                    return string.Empty;
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return ex.Message;
            }
        }
    }
}
