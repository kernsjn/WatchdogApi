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
  public class BuildingController : ControllerBase
  {
    private readonly DatabaseContext _context;

    public BuildingController(DatabaseContext context)
    {
      _context = context;
    }

    // GET: api/Building
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Building>>> GetBuildings()
    {
      return await _context.Buildings.ToListAsync();
    }

    // GET: api/Building/5
    [HttpGet("{facilityId}")]
    public async Task<ActionResult> GetBuilding(int facilityId)
    {
      var building = _context.Buildings.Where(w => w.FacilityId == facilityId);
      return Ok(await building.ToListAsync());
    }

    // PUT: api/Building/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBuilding(int id, Building building)
    {
      if (id != building.Id)
      {
        return BadRequest();
      }

      _context.Entry(building).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!BuildingExists(id))
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

    // POST: api/Building
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPost]
    public async Task<ActionResult<Building>> PostBuilding(Building building)
    {
      _context.Buildings.Add(building);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetBuilding", new { id = building.Id }, building);
    }

    // DELETE: api/Building/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Building>> DeleteBuilding(int id)
    {
      var building = await _context.Buildings.FindAsync(id);
      if (building == null)
      {
        return NotFound();
      }

      _context.Buildings.Remove(building);
      await _context.SaveChangesAsync();

      return building;
    }

    private bool BuildingExists(int id)
    {
      return _context.Buildings.Any(e => e.Id == id);
    }
  }
}
