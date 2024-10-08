using Entities.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Services.Contracts
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles { get; }
        IEnumerable<IdentityUser> GetAllUsers();
        Task<IdentityUser>GetOneUser(string userName);
        Task<UserDTO_ForUpdate>GetOneUserForUpdate(string userName); //for using together user and roles
        Task<IdentityResult> CreateUser(UserDTO_ForCreation userDTO);
        Task Update(UserDTO_ForUpdate userDTO);
        Task<IdentityResult>ResetPassword(ResetPasswordDTO model);
        Task<IdentityResult>DeleteOneUser(string userName);
        
    }
}