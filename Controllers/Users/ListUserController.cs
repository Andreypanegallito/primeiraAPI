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
    public class ListUserController : ControllerBase
    {
        private readonly UserService _userService;

        public ListUserController(UserService userService)
        {
            _userService = userService;
        }
        // Implementa a rota `/users`
        [HttpPost(Name = "dados")]
        public IActionResult Index([FromBody] int idUsuario)
        {
            // Obtém a lista de usuários do `UserService`
            var user = _userService.GetUserById(idUsuario);

            // Converta a lista de usuários em um JSON
            var json = JsonConvert.SerializeObject(user);

            // Retorne o JSON
            return Ok(json);
        }
    }
}
