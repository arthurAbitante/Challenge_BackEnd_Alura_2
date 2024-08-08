﻿using ChallengeBackEndAlura1.Data;
using ChallengeBackEndAlura1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChallengeBackEndAlura1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepoimentosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepoimentosController(AppDbContext context)
        {
            _context= context;
        }

        // GET: api/<DepoimentosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Depoimento>>> GetDepoimentos()
        {
            return await _context.Depoimentos.ToListAsync();
        }

        // GET api/<DepoimentosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Depoimento>> GetDepoimento(int id)
        {

            var depoimento = await _context.Depoimentos.FindAsync(id);

            if (depoimento == null)
            {
                return NotFound();
            }

            return depoimento;
        }

        // POST api/<DepoimentosController>
        [HttpPost]
        public async Task<ActionResult<Depoimento>> PostDepoimento([FromBody] Depoimento depoimento)
        {
            _context.Depoimentos.Add(depoimento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepoimento", new { id = depoimento.id }, depoimento);
        }

        // PUT api/<DepoimentosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepoimento(int id, [FromBody] Depoimento depoimento)
        {
            if (id != depoimento.id)
            {
                return BadRequest();
            }

            _context.Entry(depoimento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!DepoimentoExists(id)) 
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


        // DELETE api/<DepoimentosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepoimento(int id)
        {
            var depoimento = await _context.Depoimentos.FindAsync(id);
            if (depoimento == null)
            {
                return NotFound();
            }

            _context.Depoimentos.Remove(depoimento);
            await _context.SaveChangesAsync();

            return NoContent();
            
        }

        private bool DepoimentoExists(int id)
        {
            return _context.Depoimentos.Any(e => e.id == id);
        }
    }
}
