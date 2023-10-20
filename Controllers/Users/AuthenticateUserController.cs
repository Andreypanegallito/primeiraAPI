using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using primeiraAPI.Models;
using primeiraAPI.Repositories;
using primeiraAPI.Services;
using System.Data.Common;

namespace primeiraAPI.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticateUserController: ControllerBase
    {
        private readonly UserService _userService;

        public AuthenticateUserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost(Name = "authenticateUser")]
        public async  Task<IActionResult> Index([FromBody] UserLoginModel userLoginModel)
        {
            var user = await _userService.AuthenticateUserAsync(userLoginModel.usernameLogin, userLoginModel.passwordLogin);

            var json = JsonConvert.SerializeObject(user);

            return Ok(json);
        }

    }
}
