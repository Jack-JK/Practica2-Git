using Microsoft.AspNetCore.Mvc;
using PracticoSI1.Models;
using PracticoSI1.Services.Contracts;
using System.Linq.Expressions;

namespace PracticoSI1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControlController : ControllerBase
    {
        private readonly IConfiguration _Configuration;
        private readonly IUsuarioService _IUsuarioService;
        public ControlController (IConfiguration Configuration, IUsuarioService UsuarioService)
        {
            _IUsuarioService = UsuarioService;
            _Configuration = Configuration;
        }
        [HttpPost("CrearToken")]
        public async Task<TokenModelo> PostToken(string login, string password)
        {
            TokenModelo token = new TokenModelo();
            try
            {
                var usuario = await _IUsuarioService.GetNombreUsuario(login);
                if(usuario!= null)
                {
                    var hashedPassword = _IUsuarioService.CrearPasswordHash(password, usuario.Salt);
                    if(hashedPassword == usuario.Clave)
                    {
                        var currentDate = DateTime.UtcNow;
                        var expirationTime = TimeSpan.FromMinutes(10);
                        var expireDateTime = currentDate.Add(expirationTime);

                        var authSettings = _Configuration.GetSection("AuthentificationSettings");

                        string issuer = authSettings["Issuer"];
                        string audience = authSettings["Audence"];
                        string signingKey = authSettings["Signingkey"];

                        token.token = _IUsuarioService.GenerarToken(currentDate, usuario, expirationTime, signingKey, audience, issuer);
                        token.tiempoExpira = expireDateTime;
                    }
                    else
                    {
                        //manejar error de contraseña incorrecta
                    }
                }
                else
                {
                    //manejar error de usuario incorrecto
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erroren la generacion del token:{ ex.Message}");
            }
            return token;
        }
    }
}
