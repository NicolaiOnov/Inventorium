#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventorium.Server.Database;
using Inventorium.Server.Model;

namespace Inventorium.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariationsController : ControllerBase
    {
        private readonly InventoriumDbContext _context;

        public VariationsController(InventoriumDbContext context)
        {
            _context = context;
        }

        // GET: api/Variations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Variation>>> GetVariations()
        {
            return await _context.Variations.ToListAsync();
        }

        // GET: api/Variations/product/5
        [HttpGet("product/{id}")]
        public async Task<ActionResult<IEnumerable<Variation>>> GetVariationForProduct(int id)
        {
            var variations = await _context.Variations.Where(v => v.ProductId == id).Include(l => l.LocalVariationQuantities).ToListAsync();

            if (variations.Count == 0)
            {
                return NotFound();
            }

            return variations;
        }

        // GET: api/Variations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Variation>> GetVariation(int id)
        {
            var variation = await _context.Variations.FindAsync(id);

            if (variation == null)
            {
                return NotFound();
            }

            return variation;
        }

        // PUT: api/Variations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVariation(int id, Variation variation)
        {
            if (id != variation.Id)
            {
                return BadRequest();
            }

            _context.Entry(variation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VariationExists(id))
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

        // POST: api/Variations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Variation>> PostVariation(Variation variation)
        {
            _context.Variations.Add(variation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVariation", new { id = variation.Id }, variation);
        }

        // DELETE: api/Variations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVariation(int id)
        {
            var variation = await _context.Variations.FindAsync(id);
            if (variation == null)
            {
                return NotFound();
            }

            _context.Variations.Remove(variation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VariationExists(int id)
        {
            return _context.Variations.Any(e => e.Id == id);
        }
    }
}
