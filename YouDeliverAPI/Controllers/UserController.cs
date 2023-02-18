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
    public class UserController : ControllerBase
    {
        private readonly YoudeliverdbContext _context;

        public UserController(YoudeliverdbContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TUsers>>> GetTUsers()
        {
          if (_context.TUsers == null)
          {
              return NotFound();
          }
            return await _context.TUsers.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TUsers>> GetTUsers(int id)
        {
          if (_context.TUsers == null)
          {
              return NotFound();
          }
            var tUsers = await _context.TUsers.FindAsync(id);

            if (tUsers == null)
            {
                return NotFound();
            }

            return tUsers;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTUsers(int id, TUsers tUsers)
        {
            if (id != tUsers.UserId)
            {
                return BadRequest();
            }

            _context.Entry(tUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TUsersExists(id))
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

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TUsers>> PostTUsers(TUsers tUsers)
        {
          if (_context.TUsers == null)
          {
              return Problem("Entity set 'YoudeliverdbContext.TUsers'  is null.");
          }
            _context.TUsers.Add(tUsers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTUsers", new { id = tUsers.UserId }, tUsers);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTUsers(int id)
        {
            if (_context.TUsers == null)
            {
                return NotFound();
            }
            var tUsers = await _context.TUsers.FindAsync(id);
            if (tUsers == null)
            {
                return NotFound();
            }

            _context.TUsers.Remove(tUsers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TUsersExists(int id)
        {
            return (_context.TUsers?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
