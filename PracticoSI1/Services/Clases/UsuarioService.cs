using PracticoSI1.Service.Contracts;
using PracticoSI1.Business.Contracts;
using PracticoSI1.Models;
using System.Security.Cryptography;
using System.Text;
using PracticoSI1.Services.Contracts;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.JsonWebTokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;
using Microsoft.IdentityModel.Tokens;

namespace PracticoSI1.Services.Clases
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _IUsuarioRepository;
        public UsuarioService(IUsuarioRepository temp)
        {
            _IUsuarioRepository = temp;
        }

        public Task<Usuario> GetNombreUsuario(string nombreusuario)
        {
            return _IUsuarioRepository.GetNombreUsuario(nombreusuario);
        }
        public string CrearPasswordHash(string password, string salt)
        {
            string cadenaUnida = string.Concat(password, salt);
            using (var sha256 = SHA256.Create())
            {
                var resultadoHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(cadenaUnida));
                var strResultadoHash = BitConverter.ToString(resultadoHash).Replace("-", "").ToUpper();
                return strResultadoHash;
            }
        }
        public string GenerarToken(DateTime fechaEmision, Usuario usuario, TimeSpan tiempoExpiracion,
            string claveFirma, string audiencia, string emisor)
        {
            var fechaExpiracion = fechaEmision.Add(tiempoExpiracion);
            var reclamaciones = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(fechaEmision).ToUnixTimeSeconds().ToString(),
                ClaimValueTypes.Integer64), new Claim("NombreUsuario", usuario.NombreUsuario), 
                new Claim("IdUsuario", usuario.IdUsuario.ToString())
            };
            var credencialesFirma = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(claveFirma)),
                SecurityAlgorithms.HmacSha256Signature);
            try
            {
                var tokenJwt = new JwtSecurityToken(
                    issuer: emisor,
                    audience: audiencia,
                    claims: reclamaciones,
                    notBefore: fechaEmision,
                    expires: fechaExpiracion,
                    signingCredentials: credencialesFirma
                    );
                var tokenCodificado = new JwtSecurityTokenHandler().WriteToken(tokenJwt);
                return tokenCodificado;
            }
            catch ( Exception ex )
            {
                Console.WriteLine($"Error al generar el token: {ex.Message}");
                throw;
            }
        }
    }
}
