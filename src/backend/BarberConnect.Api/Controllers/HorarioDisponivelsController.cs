using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BarberConnect.Api.Context;
using BarberConnect.Api.Models;

namespace BarberConnect.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioDisponivelsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HorarioDisponivelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/HorarioDisponivels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HorarioDisponivel>>> GetHorariosDisponiveis()
        {
            return await _context.HorariosDisponiveis.ToListAsync();
        }

        // GET: api/HorarioDisponivels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HorarioDisponivel>> GetHorarioDisponivel(int id)
        {
            var horarioDisponivel = await _context.HorariosDisponiveis.FindAsync(id);

            if (horarioDisponivel == null)
            {
                return NotFound();
            }

            return horarioDisponivel;
        }

        // PUT: api/HorarioDisponivels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHorarioDisponivel(int id, HorarioDisponivel horarioDisponivel)
        {
            if (id != horarioDisponivel.IdHorario)
            {
                return BadRequest();
            }

            _context.Entry(horarioDisponivel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorarioDisponivelExists(id))
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

        // POST: api/HorarioDisponivels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HorarioDisponivel>> PostHorarioDisponivel(HorarioDisponivel horarioDisponivel)
        {
            _context.HorariosDisponiveis.Add(horarioDisponivel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHorarioDisponivel", new { id = horarioDisponivel.IdHorario }, horarioDisponivel);
        }

        // DELETE: api/HorarioDisponivels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHorarioDisponivel(int id)
        {
            var horarioDisponivel = await _context.HorariosDisponiveis.FindAsync(id);
            if (horarioDisponivel == null)
            {
                return NotFound();
            }

            _context.HorariosDisponiveis.Remove(horarioDisponivel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HorarioDisponivelExists(int id)
        {
            return _context.HorariosDisponiveis.Any(e => e.IdHorario == id);
        }
    }
}
