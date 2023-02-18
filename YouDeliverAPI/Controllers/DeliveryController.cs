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
    public class DeliveryController : ControllerBase
    {
        private readonly YoudeliverdbContext _context;

        public DeliveryController(YoudeliverdbContext context)
        {
            _context = context;
        }

        // GET: api/Delivery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TDelivery>>> GetTDelivery()
        {
          if (_context.TDelivery == null)
          {
              return NotFound();
          }
            return await _context.TDelivery.ToListAsync();
        }

        // GET: api/Delivery/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TDelivery>> GetTDelivery(int id)
        {
          if (_context.TDelivery == null)
          {
              return NotFound();
          }
            var tDelivery = await _context.TDelivery.FindAsync(id);

            if (tDelivery == null)
            {
                return NotFound();
            }

            return tDelivery;
        }

        // PUT: api/Delivery/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTDelivery(int id, TDelivery tDelivery)
        {
            if (id != tDelivery.DeliveryId)
            {
                return BadRequest();
            }

            _context.Entry(tDelivery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TDeliveryExists(id))
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

        // POST: api/Delivery
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TDelivery>> PostTDelivery(TDelivery tDelivery)
        {
          if (_context.TDelivery == null)
          {
              return Problem("Entity set 'YoudeliverdbContext.TDelivery'  is null.");
          }
            _context.TDelivery.Add(tDelivery);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTDelivery", new { id = tDelivery.DeliveryId }, tDelivery);
        }

        // DELETE: api/Delivery/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTDelivery(int id)
        {
            if (_context.TDelivery == null)
            {
                return NotFound();
            }
            var tDelivery = await _context.TDelivery.FindAsync(id);
            if (tDelivery == null)
            {
                return NotFound();
            }

            _context.TDelivery.Remove(tDelivery);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TDeliveryExists(int id)
        {
            return (_context.TDelivery?.Any(e => e.DeliveryId == id)).GetValueOrDefault();
        }
    }
}
