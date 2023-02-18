using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YouDeliverAPI.Models;

namespace YouDeliverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly YoudeliverdbContext _context;

        public PurchaseController(YoudeliverdbContext context)
        {
            _context = context;
        }

        // GET: api/Purchase
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TPurchase>>> GetTPurchase()
        {
          if (_context.TPurchase == null)
          {
              return NotFound();
          }
            return await _context.TPurchase.ToListAsync();
        }

        // GET: api/Purchase/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TPurchase>> GetTPurchase(int id)
        {
          if (_context.TPurchase == null)
          {
              return NotFound();
          }
            var tPurchase = await _context.TPurchase.FindAsync(id);

            if (tPurchase == null)
            {
                return NotFound();
            }

            return tPurchase;
        }

        // PUT: api/Purchase/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTPurchase(int id, TPurchase tPurchase)
        {
            if (id != tPurchase.PurhcaseId)
            {
                return BadRequest();
            }

            _context.Entry(tPurchase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TPurchaseExists(id))
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

        // POST: api/Purchase
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TPurchase>> PostTPurchase(TPurchase tPurchase)
        {
          if (_context.TPurchase == null)
          {
              return Problem("Entity set 'YoudeliverdbContext.TPurchase'  is null.");
          }
            _context.TPurchase.Add(tPurchase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTPurchase", new { id = tPurchase.PurhcaseId }, tPurchase);
        }

        // DELETE: api/Purchase/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTPurchase(int id)
        {
            if (_context.TPurchase == null)
            {
                return NotFound();
            }
            var tPurchase = await _context.TPurchase.FindAsync(id);
            if (tPurchase == null)
            {
                return NotFound();
            }

            _context.TPurchase.Remove(tPurchase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TPurchaseExists(int id)
        {
            return (_context.TPurchase?.Any(e => e.PurhcaseId == id)).GetValueOrDefault();
        }
    }
}
