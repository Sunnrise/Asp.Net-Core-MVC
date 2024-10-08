using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IServiceManager _manager;
        public UserController(IServiceManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index()
        {
            var users = _manager.AuthService.GetAllUsers();
            return View(users);
        }
        public IActionResult Create()
        {
            return View(new UserDTO_ForCreation()
            {
                Roles = new HashSet<string>(_manager
                    .AuthService
                    .Roles
                    .Select(r => r.Name).
                    ToList())

            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] UserDTO_ForCreation userDTO)
        {
            var result = await _manager.AuthService.CreateUser(userDTO);
            return result.Succeeded
                ? RedirectToAction(nameof(Index))
                : View();
        }

        public async Task<IActionResult> Update([FromRoute(Name = "id")] string id)
        {
            var user = await _manager.AuthService.GetOneUserForUpdate(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] UserDTO_ForUpdate userDTO)
        {
            if (ModelState.IsValid)
            {
                await _manager.AuthService.Update(userDTO);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> ResetPassword([FromRoute(Name = "id")] string id)
        {
            return View(new ResetPasswordDTO()
            {
                UserName = id
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordDTO model)
        {
            var result = await _manager.AuthService.ResetPassword(model);

            return result.Succeeded
                ? RedirectToAction(nameof(Index))
                : View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOneUser([FromForm] UserDTO userDTO)
        {
            var result = await _manager
                .AuthService
                .DeleteOneUser(userDTO.UserName);
            return result.Succeeded
                ? RedirectToAction(nameof(Index))
                : View();
        }
    }
}