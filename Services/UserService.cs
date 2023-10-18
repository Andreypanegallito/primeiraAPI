using MySql.Data.MySqlClient;
using primeiraAPI.Models;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using BCrypt.Net;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Org.BouncyCastle.Crypto.Generators;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Bcpg;
using System;

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
                user.isAtivo = bool.TryParse(reader["ativo"].ToString(), out bool ativo);
                user.podeEditar = bool.TryParse(reader["podeEditar"].ToString(), out bool podeEditar);
            };

            reader.Close();
            _connection.Close();

            return user;
        }
        
        public async Task<LoginResponse> AuthenticateUserAsync(string username, string password)
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.OpenAsync();
            }

            try
            {
                await _connection.OpenAsync();

                string sql = "SELECT idUsuario, username, isAdmin, podeEditar, password FROM usuarios WHERE username = @UserName";
                using (MySqlCommand command = new MySqlCommand(sql, _connection))
                {
                    command.Parameters.AddWithValue("@UserName", username);

                    using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            string storedHashedPassword = reader["password"].ToString();
                            bool passwordsMatch = BCrypt.Net.BCrypt.Verify(password, storedHashedPassword);

                            if (passwordsMatch)
                            {
                                var user = new User
                                {
                                    idUsuario = int.Parse(reader["idUsuario"].ToString()),
                                    username = reader["username"].ToString(),
                                    isAdmin = bool.TryParse(reader["isAdmin"].ToString(), out bool isAdmin),
                                    podeEditar = bool.TryParse(reader["podeEditar"].ToString(), out bool podeEditar)

                                };

                                var token = GenerateJwtToken(user);

                                return new LoginResponse
                                {
                                    result = user,
                                    status = "Ok",
                                    token = token
                                };
                            }
                            else
                            {
                                return new LoginResponse
                                {
                                    result = null,
                                    status = "passErr",
                                    token = null
                                };
                            }
                        }
                        else
                        {
                            return new LoginResponse
                            {
                                result = null,
                                status = "userErr",
                                token = null
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Lidar com exceções, registrar ou relatar o erro
                return new LoginResponse
                {
                    result = null,
                    status = "error",
                    token = null
                };
            }
            finally
            {
                _connection.Close();
            }
        }

        private string GenerateJwtToken(User user)
        {
            // Gere e retorne o token JWT aqui
            // Certifique-se de usar um código real para gerar o token JWT com base nas reivindicações do usuário.
            // Você deve usar um pacote de JWT como System.IdentityModel.Tokens.Jwt ou similar.
            return "TokenJWTGeradoAqui";
        }

    }
}
