using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Survivor.Data;
using Survivor.Entities;
using Survivor.Data;
using Survivor.Entities;

namespace Survivor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorController : ControllerBase
    {
        private readonly SurvivorDbContext _context;

        public CompetitorController(SurvivorDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompetitors()
        {
            var competitors = await _context.Competitors.Include(c => c.Category).ToListAsync();
            return Ok(competitors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompetitor(int id)
        {
            var competitor = await _context.Competitors.Include(c => c.Category).FirstOrDefaultAsync(c => c.Id == id);
            if (competitor == null)
                return NotFound();

            return Ok(competitor);
        }

        [HttpGet("categories/{categoryId}")]
        public async Task<IActionResult> GetCompetitorsByCategory(int categoryId)
        {
            var competitors = await _context.Competitors
                                             .Where(c => c.CategoryId == categoryId)
                                             .Include(c => c.Category)
                                             .ToListAsync();
            return Ok(competitors);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompetitor(Competitor competitor)
        {
            _context.Competitors.Add(competitor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCompetitor), new { id = competitor.Id }, competitor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompetitor(int id, Competitor competitor)
        {
            if (id != competitor.Id)
                return BadRequest();

            _context.Entry(competitor).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetitor(int id)
        {
            var competitor = await _context.Competitors.FindAsync(id);
            if (competitor == null)
                return NotFound();

            _context.Competitors.Remove(competitor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
