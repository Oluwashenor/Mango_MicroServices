using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IAuthService
    {
        Task<ResponseDto?> LoginAsync(LoginRequestDto model);
        Task<ResponseDto?> RegisterAsync(RegistrationRequestDTO model);
        Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDTO model);
    }
}
