using System;
using System.Data;
using MySql.Data.MySqlClient;


namespace primeiraAPI.Models
{
    public class User
    {
        public int idUsuario { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string data_criacao { get; set; }
        public Boolean ativo { get; set; }
        public Boolean podeEditar { get; set; }
    }

    public class LoginResponse
    {
        public DataRowState result { get; set; }
        public string status { get; set; }
        public string token { get; set; }
    }
}
