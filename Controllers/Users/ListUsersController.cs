using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using primeiraAPI.Models;
using primeiraAPI.Repositories;

namespace primeiraAPI.Controllers.Users
{
    public class ListUsersController : Controller
    {
        private readonly MySqlConnection _connection;
        private readonly IUserRepository _userRepository;

        public ListUsersController(MySqlConnection connection, IUserRepository userRepository)
        {
            _connection = connection;
            _userRepository = userRepository;
        }

        // Implementa a rota `/users`
        public IActionResult Index()
        {
            // Execute uma consulta SQL usando a conexão
            var command = new MySqlCommand("SELECT * FROM users", _connection);
            var reader = command.ExecuteReader();

            // Itere sobre os resultados
            var users = new List<User>();
            while (reader.Read())
            {
                // Converte a string do campo "idUsuario" para um número inteiro
                int idUsuario = int.Parse(reader["idUsuario"].ToString());

                // Cria um novo usuário com os dados da consulta
                var user = new User
                {
                    idUsuario = idUsuario,
                    nome = reader["nome"].ToString(),
                    sobrenome = reader["sobrenome"].ToString(),
                    email = reader["email"].ToString()
                };

                // Adiciona o usuário à lista de usuários
                users.Add(user);
            }

            // Feche o leitor e a conexão
            reader.Close();
            _connection.Close();

            // Retorne os usuários
            return Ok(users);
        }
    }
}
