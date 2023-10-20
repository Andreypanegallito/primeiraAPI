using System;
using System.Data;
using MySql.Data.MySqlClient;


namespace primeiraAPI.Models
{
    public class User
    {
        public int idUsuario { get; set; }
        public string nome { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string creationDate { get; set; }
        public Boolean isActive { get; set; }
        public Boolean isAdmin { get; set; }
        public Boolean isCanEdit { get; set; }
    }

    public class LoginResponse
    {
        public User? result { get; set; }
        public string status { get; set; }
        public string? token { get; set; }
    }

    public class UserLoginModel 
    {
        public string usernameLogin { get; set; }
        public string passwordLogin { get; set; }
    }

}
