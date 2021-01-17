using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppTracker.Data;
using AppTracker.Data.Models;

namespace AppTracker.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackedItemsController : ControllerBase
    {
        private readonly AppTrackerDbContext _context;

        public TrackedItemsController(AppTrackerDbContext context)
        {
            _context = context;
        }

        // GET: api/TrackedItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrackedItem>>> GetTrackedItems()
        {
            return await _context.TrackedItems.ToListAsync();
        }

        // GET: api/TrackedItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrackedItem>> GetTrackedItem(int id)
        {
            var trackedItem = await _context.TrackedItems.FindAsync(id);

            if (trackedItem == null)
            {
                return NotFound();
            }

            return trackedItem;
        }

        // PUT: api/TrackedItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrackedItem(int id, TrackedItem trackedItem)
        {
            if (id != trackedItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(trackedItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackedItemExists(id))
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

        // POST: api/TrackedItems
        [HttpPost]
        public async Task<ActionResult<TrackedItem>> PostTrackedItem(TrackedItem trackedItem)
        {
            _context.TrackedItems.Add(trackedItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrackedItem", new { id = trackedItem.Id }, trackedItem);
        }

        // DELETE: api/TrackedItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrackedItem(int id)
        {
            var trackedItem = await _context.TrackedItems.FindAsync(id);
            if (trackedItem == null)
            {
                return NotFound();
            }

            _context.TrackedItems.Remove(trackedItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrackedItemExists(int id)
        {
            return _context.TrackedItems.Any(e => e.Id == id);
        }
    }
}
