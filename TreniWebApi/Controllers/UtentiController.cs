using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using TreniDataModel.Models;
using TreniWebApi.Models.Requests;
using TreniWebApi.Manager;
using Microsoft.AspNetCore.Http;
using TreniWebApi.Models.Response;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace TreniWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UtentiController : MainController
    {
        private UtentiManager _utentiManager;

        public UtentiController(TreniDbContext dbContext, IConfiguration configuration) 
            : base(dbContext, configuration) 
        {
            _utentiManager = new UtentiManager();
        }

        #region Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UtenteRegistrationRequest request)
        {
            if(_dbContext.Utentes.Any(x=>x.Email == request.Email))
            {
                return BadRequest();
            }

            _utentiManager.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var utente = new Utente
            {
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };

            _dbContext.Add(utente);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Register), new { id = utente.Id }, utente);
        }
        #endregion

        #region Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UtenteLoginRequest request)
        {
            string messageBadRequest = "Credenziali Errate";
            string messageOk = "Benvenuto";
            UtenteLoginResponse response = new UtenteLoginResponse();

            var utente = await _dbContext.Utentes.FirstOrDefaultAsync(x => x.Email == request.Email);

            if(utente == null)
            {
                response.Message = messageBadRequest;
                return BadRequest(response);
            }

            if (_utentiManager.VerifyPasswordHash(request.Password, utente.PasswordHash, utente.PasswordSalt))
            {
                response.TokenSession = _utentiManager.CreateToken(utente, _configuration.GetSection("AppSettings:TokenKey").Value!);
                response.Message = messageOk;
                return Ok(response);
            }
            else
            {
                response.Message = messageBadRequest;
                return BadRequest(response);
            }
        }
        #endregion
    }
}
