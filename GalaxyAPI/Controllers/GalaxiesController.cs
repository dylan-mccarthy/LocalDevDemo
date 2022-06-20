using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GalaxyAPI.Data;
using GalaxyAPI.Model;

namespace GalaxyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalaxiesController : ControllerBase
    {
        private readonly GalaxyDbContext _context;

        public GalaxiesController(GalaxyDbContext context)
        {
            _context = context;
        }

        // GET: api/Galaxies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Galaxy>>> GetGalaxies()
        {
          if (_context.Galaxies == null)
          {
              return NotFound();
          }
            return await _context.Galaxies.ToListAsync();
        }

        // GET: api/Galaxies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Galaxy>> GetGalaxy(int id)
        {
          if (_context.Galaxies == null)
          {
              return NotFound();
          }
            var galaxy = await _context.Galaxies.FindAsync(id);

            if (galaxy == null)
            {
                return NotFound();
            }

            return galaxy;
        }

        // PUT: api/Galaxies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGalaxy(int id, Galaxy galaxy)
        {
            if (id != galaxy.Id)
            {
                return BadRequest();
            }

            _context.Entry(galaxy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GalaxyExists(id))
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

        // POST: api/Galaxies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Galaxy>> PostGalaxy(Galaxy galaxy)
        {
          if (_context.Galaxies == null)
          {
              return Problem("Entity set 'GalaxyDbContext.Planets'  is null.");
          }
            _context.Galaxies.Add(galaxy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGalaxy", new { id = galaxy.Id }, galaxy);
        }

        // DELETE: api/Galaxies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGalaxy(int id)
        {
            if (_context.Galaxies == null)
            {
                return NotFound();
            }
            var galaxy = await _context.Galaxies.FindAsync(id);
            if (galaxy == null)
            {
                return NotFound();
            }

            _context.Galaxies.Remove(galaxy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GalaxyExists(int id)
        {
            return (_context.Galaxies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
