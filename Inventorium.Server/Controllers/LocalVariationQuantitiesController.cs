#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventorium.Server.Database;
using Inventorium.Server.Model;

namespace Inventorium.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalVariationQuantitiesController : ControllerBase
    {
        private readonly InventoriumDbContext _context;

        public LocalVariationQuantitiesController(InventoriumDbContext context)
        {
            _context = context;
        }

        // GET: api/LocalVariationQuantities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocalVariationQuantity>>> GetLocalVariationQuantities()
        {
            return await _context.LocalVariationQuantities.ToListAsync();
        }

        // GET: api/LocalVariationQuantities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocalVariationQuantity>> GetLocalVariationQuantity(int id)
        {
            var localVariationQuantity = await _context.LocalVariationQuantities.FindAsync(id);

            if (localVariationQuantity == null)
            {
                return NotFound();
            }

            return localVariationQuantity;
        }

        // PUT: api/LocalVariationQuantities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocalVariationQuantity(int id, LocalVariationQuantity localVariationQuantity)
        {
            if (id != localVariationQuantity.LocalVariationQuantityId)
            {
                return BadRequest();
            }

            _context.Entry(localVariationQuantity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalVariationQuantityExists(id))
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

        // POST: api/LocalVariationQuantities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LocalVariationQuantity>> PostLocalVariationQuantity(LocalVariationQuantity localVariationQuantity)
        {
            _context.LocalVariationQuantities.Add(localVariationQuantity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocalVariationQuantity", new { id = localVariationQuantity.LocalVariationQuantityId }, localVariationQuantity);
        }

        // DELETE: api/LocalVariationQuantities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocalVariationQuantity(int id)
        {
            var localVariationQuantity = await _context.LocalVariationQuantities.FindAsync(id);
            if (localVariationQuantity == null)
            {
                return NotFound();
            }

            _context.LocalVariationQuantities.Remove(localVariationQuantity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocalVariationQuantityExists(int id)
        {
            return _context.LocalVariationQuantities.Any(e => e.LocalVariationQuantityId == id);
        }
    }
}
