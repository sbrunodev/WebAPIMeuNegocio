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
    public class VendasController : ControllerBase
    {
        private readonly AplicacaoContexto _context;

        public VendasController(AplicacaoContexto context)
        {
            _context = context;
        }

        // GET: api/Vendas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venda>>> GetVenda()
        {
            return await _context.Venda.Include(e => e.itens).Include(e => e.colaborador).Include(e => e.cliente).ToListAsync();
        }

        // GET: api/Vendas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Venda>> GetVenda(int id)
        {
            var venda = await _context.Venda.Include(e =>e.itens).Include(e => e.colaborador).Include(e => e.cliente).SingleOrDefaultAsync(i => i.vendaId == id);
  
            if (venda == null)
            {
                return NotFound();
            }

            return venda;
        }

        // PUT: api/Vendas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenda(int id, Venda venda)
        {
            if (id != venda.vendaId)
            {
                return BadRequest();
            }

            _context.Entry(venda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendaExists(id))
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

        // POST: api/Vendas
        [HttpPost]
        public async Task<ActionResult<Venda>> PostVenda(Venda venda)
        {
            decimal valorTotal = 0;
            foreach(Item item in venda.itens)
            {
                valorTotal += (item.quantidade * item.valorunitario);
            }

            venda.totalBruto = valorTotal;
            venda.totalLiquido = valorTotal;

            _context.Venda.Add(venda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVenda", new { id = venda.vendaId }, venda);
        }

        // DELETE: api/Vendas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Venda>> DeleteVenda(int id)
        {
            var venda = await _context.Venda.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }

            _context.Venda.Remove(venda);
            await _context.SaveChangesAsync();

            return venda;
        }

        private bool VendaExists(int id)
        {
            return _context.Venda.Any(e => e.vendaId == id);
        }
    }
}
