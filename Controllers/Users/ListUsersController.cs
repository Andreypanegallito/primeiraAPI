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
    public class ListUsersController : ControllerBase
    {
        private readonly UserService _userService;

        public ListUsersController(UserService userService)
        {
            _userService = userService;
        }
        // Implementa a rota `/users`
        [HttpGet(Name = "users")]
        public IActionResult Index()
        {
            // Obtém a lista de usuários do `UserService`
            var users = _userService.GetUsers();

            // Converta a lista de usuários em um JSON
            var json = JsonConvert.SerializeObject(users);

            // Retorne o JSON
            return Ok(json);
        }
    }
}
