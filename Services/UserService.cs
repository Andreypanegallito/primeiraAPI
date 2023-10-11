using MySql.Data.MySqlClient;
using primeiraAPI.Models;
using System.Data.Common;

namespace primeiraAPI.Services
{
    public class UserService
    {
        private readonly MySqlConnection _connection;

        public UserService(MySqlConnection connection)
        {
            _connection = connection;
        }

        public List<User> GetUsers()
        {
            _connection.Open();
            // Execute a consulta SQL
            var command = new MySqlCommand("SELECT * FROM usuarios", _connection);
            var reader = command.ExecuteReader();

            // Itere sobre os resultados
            var users = new List<User>();
            while (reader.Read())
            {
                // Cria um novo usuário com os dados da consulta
                var user = new User
                {
                    idUsuario = int.Parse(reader["idUsuario"].ToString()),
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

            return users;
        }
    }
}
