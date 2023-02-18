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
    public class ProductController : ControllerBase
    {
        private readonly YoudeliverdbContext _context;

        public ProductController(YoudeliverdbContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TProducts>>> GetTProducts()
        {
          if (_context.TProducts == null)
          {
              return NotFound();
          }
            return await _context.TProducts.ToListAsync();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TProducts>> GetTProducts(int id)
        {
          if (_context.TProducts == null)
          {
              return NotFound();
          }
            var tProducts = await _context.TProducts.FindAsync(id);

            if (tProducts == null)
            {
                return NotFound();
            }

            return tProducts;
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTProducts(int id, TProducts tProducts)
        {
            if (id != tProducts.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(tProducts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TProductsExists(id))
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

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TProducts>> PostTProducts(TProducts tProducts)
        {
          if (_context.TProducts == null)
          {
              return Problem("Entity set 'YoudeliverdbContext.TProducts'  is null.");
          }
            _context.TProducts.Add(tProducts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTProducts", new { id = tProducts.ProductId }, tProducts);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTProducts(int id)
        {
            if (_context.TProducts == null)
            {
                return NotFound();
            }
            var tProducts = await _context.TProducts.FindAsync(id);
            if (tProducts == null)
            {
                return NotFound();
            }

            _context.TProducts.Remove(tProducts);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TProductsExists(int id)
        {
            return (_context.TProducts?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
