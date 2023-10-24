using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace primeiraAPI.Services
{
    internal class Token
    {
        public string GenerateToken(int userId)
        {
            // Cria um objeto JwtSecurityTokenHandler.
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            // Cria um objeto JwtBuilder.
            var jwtBuilder = new JwtBuilder(jwtSecurityTokenHandler);

            // Adiciona o claim userId ao token.
            jwtBuilder.Claims.Add("userId", userId);

            // Adiciona o claim issuer ao token.
            jwtBuilder.Claims.Add("issuer", "https://www.example.com");

            // Adiciona o claim audience ao token.
            jwtBuilder.Claims.Add("audience", "https://api.example.com");

            // Assina o token com uma chave secreta.
            var key = Encoding.UTF8.GetBytes("secret");
            jwtBuilder.Sign(new JwtSignatureAlgorithm("RS256"), new X509Certificate2("path/to/certificate.pfx", "password"));

            // Converte o token em uma string.
            var token = jwtBuilder.SerializeToString();

            // Retorna o token.
            return token;
        }
    }
}
