using AutoMapper;
using Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using Services.Contracts;

namespace Services
{
    public class AuthManager : IAuthService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public AuthManager(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IEnumerable<IdentityRole> Roles => _roleManager.Roles;

        public async Task<IdentityResult> CreateUser(UserDTO_ForCreation userDTO)
        {
            var user = _mapper.Map<IdentityUser>(userDTO);
            var result = await _userManager.CreateAsync(user, userDTO.Password);
            if (!result.Succeeded)
            {
                throw new Exception("Creation was failed");
            }


            if (userDTO.Roles.Count > 0)
            {
                var roleResult = await _userManager.AddToRolesAsync(user, userDTO.Roles);
                if (!roleResult.Succeeded)
                {
                    throw new Exception("System have problems with roles");
                }

            }
            return result;
        }

        public async Task<IdentityResult> DeleteOneUser(string userName)
        {
            var user = await GetOneUser(userName);
            return await _userManager.DeleteAsync(user);
        }

        public IEnumerable<IdentityUser> GetAllUsers()
        {
            return _userManager.Users.ToList();
        }

        public async Task<IdentityUser> GetOneUser(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user is not null)
                return user;
            throw new Exception("User could not be found.");

        }

        public async Task<UserDTO_ForUpdate> GetOneUserForUpdate(string userName)
        {
            var user = await GetOneUser(userName);
            var userDto = _mapper.Map<UserDTO_ForUpdate>(user);
            userDto.Roles = new HashSet<string>(Roles.Select(r => r.Name).ToList());
            userDto.UserRoles = new HashSet<string>(await _userManager.GetRolesAsync(user));
            return userDto;

        }

        public async Task<IdentityResult> ResetPassword(ResetPasswordDTO model)
        {
            var user = await GetOneUser(model.UserName);

            await _userManager.RemovePasswordAsync(user);
            var result = await _userManager.AddPasswordAsync(user, model.Password);
            return result;

        }

        public async Task Update(UserDTO_ForUpdate userDTO)
        {
            var user = await GetOneUser(userDTO.UserName);
            user.PhoneNumber = userDTO.PhoneNumber;
            user.Email = userDTO.Email;


            var result = await _userManager.UpdateAsync(user);

            if (userDTO.Roles.Count > 0)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var r1 = await _userManager.RemoveFromRolesAsync(user, userRoles);
                var r2 = await _userManager.AddToRolesAsync(user, userDTO.Roles);
            }
            return;

        }

    }
}