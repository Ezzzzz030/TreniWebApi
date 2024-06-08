using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using TreniDataModel.Models;
using TreniWebApi.Models.Requests;

namespace TreniWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StazioniController : ControllerBase
    {
        TreniDbContext _dbContext;
        
        public StazioniController(DbContextOptions options, TreniDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Stazione>> GetStazione(int id)
        {
            var stazione = await _dbContext.Staziones.FindAsync(id);

            if(stazione == null)
            {
                return NotFound();
            }

            return Ok(stazione);
        }

        [HttpGet]
        public async Task<ActionResult<Stazione>> GetStazioni()
        {
            return Ok(await _dbContext.Staziones.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> GetStazioni(StazioneRegistrationRequest request)
        {
            Stazione stazione = new Stazione { Indirizzo = request.Indirizzo, Nome = request.Nome };
            _dbContext.Add(stazione);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStazioni), new { id = stazione.Id }, stazione);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStazione(int id)
        {
            var stazione = await _dbContext.Staziones.FindAsync(id);

            if (stazione == null)
            {
                return NotFound();
            }
            _dbContext.Staziones.Remove(stazione);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, Stazione stazione)
        {
            if (id != stazione.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(stazione).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_dbContext.Staziones.FirstOrDefault(x=>x.Id == id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
    }
}
