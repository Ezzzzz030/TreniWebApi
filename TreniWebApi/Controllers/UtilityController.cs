using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using TreniDataModel.Models;
using TreniWebApi.Models.Requests;

namespace TreniWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UtilityController : MainController
    {
        public UtilityController(TreniDbContext dbContext, IConfiguration configuration) 
            : base(dbContext, configuration)
        {
        }

        [HttpGet("Ping")]
        public IActionResult Ping()
        {
            return Ok("Connessione al server riuscita");
        }
    }
}
