using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanetAPI.Data;
using PlanetAPI.Models;

namespace PlanetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetsController : ControllerBase
    {
        private readonly PlanetDbContext _context;

        public PlanetsController(PlanetDbContext context)
        {
            _context = context;
        }

        // GET: api/Planets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Planet>>> GetPlanets()
        {
          if (_context.Planets == null)
          {
              return NotFound();
          }
            return await _context.Planets.ToListAsync();
        }

        // GET: api/Planets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Planet>> GetPlanet(int id)
        {
          if (_context.Planets == null)
          {
              return NotFound();
          }
            var planet = await _context.Planets.FindAsync(id);

            if (planet == null)
            {
                return NotFound();
            }

            return planet;
        }

        // PUT: api/Planets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanet(int id, Planet planet)
        {
            if (id != planet.Id)
            {
                return BadRequest();
            }

            _context.Entry(planet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanetExists(id))
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

        // POST: api/Planets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Planet>> PostPlanet(Planet planet)
        {
          if (_context.Planets == null)
          {
              return Problem("Entity set 'PlanetDbContext.Planets'  is null.");
          }
            _context.Planets.Add(planet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlanet", new { id = planet.Id }, planet);
        }

        // DELETE: api/Planets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanet(int id)
        {
            if (_context.Planets == null)
            {
                return NotFound();
            }
            var planet = await _context.Planets.FindAsync(id);
            if (planet == null)
            {
                return NotFound();
            }

            _context.Planets.Remove(planet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlanetExists(int id)
        {
            return (_context.Planets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
