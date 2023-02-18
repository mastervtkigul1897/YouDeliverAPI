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
    public class UserInfoController : ControllerBase
    {
        private readonly YoudeliverdbContext _context;

        public UserInfoController(YoudeliverdbContext context)
        {
            _context = context;
        }

        // GET: api/UserInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TUserInfo>>> GetTUserInfo()
        {
          if (_context.TUserInfo == null)
          {
              return NotFound();
          }
            return await _context.TUserInfo.ToListAsync();
        }

        // GET: api/UserInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TUserInfo>> GetTUserInfo(int id)
        {
          if (_context.TUserInfo == null)
          {
              return NotFound();
          }
            var tUserInfo = await _context.TUserInfo.FindAsync(id);

            if (tUserInfo == null)
            {
                return NotFound();
            }

            return tUserInfo;
        }

        // PUT: api/UserInfo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTUserInfo(int id, TUserInfo tUserInfo)
        {
            if (id != tUserInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(tUserInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TUserInfoExists(id))
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

        // POST: api/UserInfo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TUserInfo>> PostTUserInfo(TUserInfo tUserInfo)
        {
          if (_context.TUserInfo == null)
          {
              return Problem("Entity set 'YoudeliverdbContext.TUserInfo'  is null.");
          }
            _context.TUserInfo.Add(tUserInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTUserInfo", new { id = tUserInfo.Id }, tUserInfo);
        }

        // DELETE: api/UserInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTUserInfo(int id)
        {
            if (_context.TUserInfo == null)
            {
                return NotFound();
            }
            var tUserInfo = await _context.TUserInfo.FindAsync(id);
            if (tUserInfo == null)
            {
                return NotFound();
            }

            _context.TUserInfo.Remove(tUserInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TUserInfoExists(int id)
        {
            return (_context.TUserInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
