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
    public class BusinessController : ControllerBase
    {
        private readonly YoudeliverdbContext _context;

        public BusinessController(YoudeliverdbContext context)
        {
            _context = context;
        }

        // GET: api/Business
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TBusiness>>> GetTBusiness()
        {
          if (_context.TBusiness == null)
          {
              return NotFound();
          }
            return await _context.TBusiness.ToListAsync();
        }

        // GET: api/Business/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TBusiness>> GetTBusiness(int id)
        {
          if (_context.TBusiness == null)
          {
              return NotFound();
          }
            var tBusiness = await _context.TBusiness.FindAsync(id);

            if (tBusiness == null)
            {
                return NotFound();
            }

            return tBusiness;
        }

        // PUT: api/Business/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTBusiness(int id, TBusiness tBusiness)
        {
            if (id != tBusiness.BusinessId)
            {
                return BadRequest();
            }

            _context.Entry(tBusiness).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TBusinessExists(id))
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

        // POST: api/Business
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TBusiness>> PostTBusiness(TBusiness tBusiness)
        {
          if (_context.TBusiness == null)
          {
              return Problem("Entity set 'YoudeliverdbContext.TBusiness'  is null.");
          }
            _context.TBusiness.Add(tBusiness);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTBusiness", new { id = tBusiness.BusinessId }, tBusiness);
        }

        // DELETE: api/Business/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTBusiness(int id)
        {
            if (_context.TBusiness == null)
            {
                return NotFound();
            }
            var tBusiness = await _context.TBusiness.FindAsync(id);
            if (tBusiness == null)
            {
                return NotFound();
            }

            _context.TBusiness.Remove(tBusiness);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TBusinessExists(int id)
        {
            return (_context.TBusiness?.Any(e => e.BusinessId == id)).GetValueOrDefault();
        }
    }
}
