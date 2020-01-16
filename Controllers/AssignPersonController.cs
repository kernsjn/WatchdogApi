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
    public class AssignPersonController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AssignPersonController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/AssignPerson
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssignPerson>>> GetAssignPerson()
        {
            return await _context.AssignPersons.ToListAsync();
        }

        // GET: api/AssignPerson/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssignPerson>> GetAssignPerson(int id)
        {
            var assignPerson = await _context.AssignPersons.FindAsync(id);

            if (assignPerson == null)
            {
                return NotFound();
            }

            return assignPerson;
        }

        // PUT: api/AssignPerson/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignPerson(int id, AssignPerson assignPerson)
        {
            if (id != assignPerson.Id)
            {
                return BadRequest();
            }

            _context.Entry(assignPerson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignPersonExists(id))
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

        // POST: api/AssignPerson
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AssignPerson>> PostAssignPerson(AssignPerson assignPerson)
        {
            _context.AssignPersons.Add(assignPerson);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssignPerson", new { id = assignPerson.Id }, assignPerson);
        }

        // DELETE: api/AssignPerson/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AssignPerson>> DeleteAssignPerson(int id)
        {
            var assignPerson = await _context.AssignPersons.FindAsync(id);
            if (assignPerson == null)
            {
                return NotFound();
            }

            _context.AssignPersons.Remove(assignPerson);
            await _context.SaveChangesAsync();

            return assignPerson;
        }

        private bool AssignPersonExists(int id)
        {
            return _context.AssignPersons.Any(e => e.Id == id);
        }
    }
}
