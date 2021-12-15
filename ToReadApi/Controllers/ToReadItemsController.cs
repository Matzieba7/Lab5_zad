using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToReadApi.Models;
using Swashbuckle.AspNetCore.Annotations;


namespace ToReadApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToReadItemsController : ControllerBase
    {
        private readonly ToReadContext _context;

        public ToReadItemsController(ToReadContext context)
        {
            _context = context;
        }

        // GET: api/ToReadItems
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ToReadItem>>> GetToReadItems()
        {
            return await _context.ToReadItems.ToListAsync();

        }

        // GET: api/ToReadItems/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ToReadItem>> GetToReadItem(long id)
        {
            var toReadItem = await _context.ToReadItems.FindAsync(id);

            if (toReadItem == null)
            {
                return NotFound();
            }

            return toReadItem;
        }

        // PUT: api/ToReadItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutToReadItem(long id, ToReadItem toReadItem)
        {
            if (id != toReadItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(toReadItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToReadItemExists(id))
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

        // POST: api/ToReadItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ToReadItem>> PostToReadItem(ToReadItem toReadItem)
        {
            _context.ToReadItems.Add(toReadItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToReadItem", new { id = toReadItem.Id }, toReadItem);
        }

        // DELETE: api/ToReadItems/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public async Task<IActionResult> DeleteToReadItem(long id)
        {
            var toReadItem = await _context.ToReadItems.FindAsync(id);
            if (toReadItem == null)
            {
                return NotFound();
            }

            _context.ToReadItems.Remove(toReadItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToReadItemExists(long id)
        {
            return _context.ToReadItems.Any(e => e.Id == id);
        }
    }
}
