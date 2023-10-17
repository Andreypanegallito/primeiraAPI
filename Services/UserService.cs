using MySql.Data.MySqlClient;
using primeiraAPI.Models;
using System.Data;
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
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            // Execute a consulta SQL
            var sql = "SELECT idUsuario, nome, sobrenome, username, email, DATE_FORMAT(data_criacao, ' % d -% m -% Y % H:% i:% s') as data_criacao, ativo, podeEditar FROM usuarios";
            var command = new MySqlCommand(sql, _connection);
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

        public User GetUserById(int idUsuario)
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            // Execute a consulta SQL
            var sql = "SELECT idUsuario, nome, sobrenome, username, email, DATE_FORMAT(data_criacao, '%d-%m-%Y %H:%i:%s') as data_criacao, ativo, podeEditar FROM usuarios WHERE idUsuario = @idUsuario";
            var command = new MySqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@idUsuario", idUsuario);

            var reader = command.ExecuteReader();

            var user = new User();
            if (reader.Read())
            {
                user.idUsuario = int.Parse(reader["idUsuario"].ToString());
                user.nome = reader["nome"].ToString() +" "+ reader["sobrenome"].ToString();
                user.username = reader["username"].ToString();
                user.email = reader["email"].ToString();
                user.data_criacao = reader["data_criacao"].ToString();
                user.ativo = bool.TryParse(reader["ativo"].ToString(), out bool ativo);
                user.podeEditar = bool.TryParse(reader["podeEditar"].ToString(), out bool podeEditar);
            };

            reader.Close();
            _connection.Close();

            return user;
        }
    }
}
