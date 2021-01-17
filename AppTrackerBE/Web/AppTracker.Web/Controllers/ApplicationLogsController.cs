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
    public class ApplicationLogsController : ControllerBase
    {
        private readonly AppTrackerDbContext _context;

        public ApplicationLogsController(AppTrackerDbContext context)
        {
            _context = context;
        }

        // GET: api/ApplicationLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationLog>>> GetApplicationLogs()
        {
            return await _context.ApplicationLogs.ToListAsync();
        }

        // GET: api/ApplicationLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationLog>> GetApplicationLog(int id)
        {
            var applicationLog = await _context.ApplicationLogs.FindAsync(id);

            if (applicationLog == null)
            {
                return NotFound();
            }

            return applicationLog;
        }

        // PUT: api/ApplicationLogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplicationLog(int id, ApplicationLog applicationLog)
        {
            if (id != applicationLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(applicationLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationLogExists(id))
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

        // POST: api/ApplicationLogs
        [HttpPost]
        public async Task<ActionResult<ApplicationLog>> PostApplicationLog(ApplicationLog applicationLog)
        {
            _context.ApplicationLogs.Add(applicationLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplicationLog", new { id = applicationLog.Id }, applicationLog);
        }

        // DELETE: api/ApplicationLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicationLog(int id)
        {
            var applicationLog = await _context.ApplicationLogs.FindAsync(id);
            if (applicationLog == null)
            {
                return NotFound();
            }

            _context.ApplicationLogs.Remove(applicationLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApplicationLogExists(int id)
        {
            return _context.ApplicationLogs.Any(e => e.Id == id);
        }
    }
}
