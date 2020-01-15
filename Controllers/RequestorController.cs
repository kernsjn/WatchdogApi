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
    public class RequestorController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public RequestorController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Requestor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Requestor>>> GetRequestor()
        {
            return await _context.Requestor.ToListAsync();
        }

        // GET: api/Requestor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Requestor>> GetRequestor(int id)
        {
            var requestor = await _context.Requestor.FindAsync(id);

            if (requestor == null)
            {
                return NotFound();
            }

            return requestor;
        }

        // PUT: api/Requestor/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequestor(int id, Requestor requestor)
        {
            if (id != requestor.Id)
            {
                return BadRequest();
            }

            _context.Entry(requestor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestorExists(id))
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

        // POST: api/Requestor
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Requestor>> PostRequestor(Requestor requestor)
        {
            _context.Requestor.Add(requestor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequestor", new { id = requestor.Id }, requestor);
        }

        // DELETE: api/Requestor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Requestor>> DeleteRequestor(int id)
        {
            var requestor = await _context.Requestor.FindAsync(id);
            if (requestor == null)
            {
                return NotFound();
            }

            _context.Requestor.Remove(requestor);
            await _context.SaveChangesAsync();

            return requestor;
        }

        private bool RequestorExists(int id)
        {
            return _context.Requestor.Any(e => e.Id == id);
        }
    }
}
