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
  public class PunchListItemController : ControllerBase
  {
    private readonly DatabaseContext _context;

    public PunchListItemController(DatabaseContext context)
    {
      _context = context;
    }

    [HttpGet("list")]
    public async Task<ActionResult> SearchPunchListItems(int facilityId, int buildingId, int scopeId, int assignId)
    {
      var punchListItem = _context
            .PunchListItems
                .Include(i => i.Facility)
                .Include(i => i.Building)
                .Include(i => i.Scope)
                .Include(i => i.AssignPerson)
                .Where(w => w.FacilityId == facilityId && w.BuildingId == buildingId && w.ScopeId == scopeId && w.AssignId == assignId);


      return Ok(await punchListItem.ToListAsync());
    }

    // GET: api/PunchListItem
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PunchListItem>>> GetPunchListItems()
    {
      return await _context.PunchListItems.ToListAsync();
    }

    // GET: api/PunchListItem/5
    [HttpGet("{id}")]
    public async Task<ActionResult<PunchListItem>> GetPunchListItem(int id)
    {
      var punchListItem = await _context.PunchListItems.FindAsync(id);

      if (punchListItem == null)
      {
        return NotFound();
      }

      return punchListItem;
    }

    // PUT: api/PunchListItem/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPunchListItem(int id, PunchListItem punchListItem)
    {
      if (id != punchListItem.Id)
      {
        return BadRequest();
      }

      _context.Entry(punchListItem).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!PunchListItemExists(id))
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

    // POST: api/PunchListItem
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPost]
    public async Task<ActionResult<PunchListItem>> PostPunchListItem(PunchListItem punchListItem)
    {
      _context.PunchListItems.Add(punchListItem);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetPunchListItem", new { id = punchListItem.Id }, punchListItem);
    }

    // DELETE: api/PunchListItem/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<PunchListItem>> DeletePunchListItem(int id)
    {
      var punchListItem = await _context.PunchListItems.FindAsync(id);
      if (punchListItem == null)
      {
        return NotFound();
      }

      _context.PunchListItems.Remove(punchListItem);
      await _context.SaveChangesAsync();

      return punchListItem;
    }

    private bool PunchListItemExists(int id)
    {
      return _context.PunchListItems.Any(e => e.Id == id);
    }
  }
}
