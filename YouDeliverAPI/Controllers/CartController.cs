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
    public class CartController : ControllerBase
    {
        private readonly YoudeliverdbContext _context;

        public CartController(YoudeliverdbContext context)
        {
            _context = context;
        }

        // GET: api/Cart
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TCart>>> GetTCart()
        {
          if (_context.TCart == null)
          {
              return NotFound();
          }
            return await _context.TCart.ToListAsync();
        }

        // GET: api/Cart/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TCart>> GetTCart(int id)
        {
          if (_context.TCart == null)
          {
              return NotFound();
          }
            var tCart = await _context.TCart.FindAsync(id);

            if (tCart == null)
            {
                return NotFound();
            }

            return tCart;
        }

        // PUT: api/Cart/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTCart(int id, TCart tCart)
        {
            if (id != tCart.CartId)
            {
                return BadRequest();
            }

            _context.Entry(tCart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TCartExists(id))
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

        // POST: api/Cart
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TCart>> PostTCart(TCart tCart)
        {
          if (_context.TCart == null)
          {
              return Problem("Entity set 'YoudeliverdbContext.TCart'  is null.");
          }
            _context.TCart.Add(tCart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTCart", new { id = tCart.CartId }, tCart);
        }

        // DELETE: api/Cart/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTCart(int id)
        {
            if (_context.TCart == null)
            {
                return NotFound();
            }
            var tCart = await _context.TCart.FindAsync(id);
            if (tCart == null)
            {
                return NotFound();
            }

            _context.TCart.Remove(tCart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TCartExists(int id)
        {
            return (_context.TCart?.Any(e => e.CartId == id)).GetValueOrDefault();
        }
    }
}
