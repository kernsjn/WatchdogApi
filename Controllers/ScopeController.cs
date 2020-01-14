using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchdogApi.Models;

namespace WatchdogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScopeController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ScopeController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Scope
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scope>>> GetScopes()
        {
            return await _context.Scopes.ToListAsync();
        }

        // GET: api/Scope/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Scope>> GetScope(int id)
        {
            var scope = await _context.Scopes.FindAsync(id);

            if (scope == null)
            {
                return NotFound();
            }

            return scope;
        }

        // PUT: api/Scope/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScope(int id, Scope scope)
        {
            if (id != scope.Id)
            {
                return BadRequest();
            }

            _context.Entry(scope).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScopeExists(id))
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

        // POST: api/Scope
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Scope>> PostScope(Scope scope)
        {
            _context.Scopes.Add(scope);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScope", new { id = scope.Id }, scope);
        }

        // DELETE: api/Scope/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Scope>> DeleteScope(int id)
        {
            var scope = await _context.Scopes.FindAsync(id);
            if (scope == null)
            {
                return NotFound();
            }

            _context.Scopes.Remove(scope);
            await _context.SaveChangesAsync();

            return scope;
        }

        private bool ScopeExists(int id)
        {
            return _context.Scopes.Any(e => e.Id == id);
        }
    }
}
