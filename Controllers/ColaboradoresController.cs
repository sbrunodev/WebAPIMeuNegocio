using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIMeuNegocio.Models;

namespace WebAPIMeuNegocio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradoresController : ControllerBase
    {
        private readonly AplicacaoContexto _context;

        public ColaboradoresController(AplicacaoContexto context)
        {
            _context = context;
        }

        // GET: api/Colaboradores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colaborador>>> GetColaborador()
        {
            return await _context.Colaborador.ToListAsync();
        }

        // GET: api/Colaboradores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Colaborador>> GetColaborador(int id)
        {
            var colaborador = await _context.Colaborador.FindAsync(id);

            if (colaborador == null)
            {
                return NotFound();
            }

            return colaborador;
        }

        // PUT: api/Colaboradores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColaborador(int id, Colaborador colaborador)
        {
            if (id != colaborador.colaboradorId)
            {
                return BadRequest();
            }

            _context.Entry(colaborador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColaboradorExists(id))
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

        // POST: api/Colaboradores
        [HttpPost]
        public async Task<ActionResult<Colaborador>> PostColaborador(Colaborador colaborador)
        {
            _context.Colaborador.Add(colaborador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColaborador", new { id = colaborador.colaboradorId }, colaborador);
        }

        // DELETE: api/Colaboradores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Colaborador>> DeleteColaborador(int id)
        {
            var colaborador = await _context.Colaborador.FindAsync(id);
            if (colaborador == null)
            {
                return NotFound();
            }

            _context.Colaborador.Remove(colaborador);
            await _context.SaveChangesAsync();

            return colaborador;
        }

        private bool ColaboradorExists(int id)
        {
            return _context.Colaborador.Any(e => e.colaboradorId == id);
        }
    }
}
