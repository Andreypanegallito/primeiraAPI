using System;

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
}
