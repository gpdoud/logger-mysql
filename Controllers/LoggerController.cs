using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Logger.Models;

namespace Logger.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class LoggerController : ControllerBase {

        private readonly LoggerContext _context = null;

        public LoggerController(LoggerContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Log>>> GetAll() {
            return await _context.Logs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Log>> Get(int id) {
            var log =  await _context.Logs.FindAsync(id);
            if(log == null) 
                return NotFound();
            return log;
        }

        [HttpPost]
        public async Task<ActionResult<Log>> Insert(Log log) {
            _context.Logs.Add(log);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Log log) {
            if(id != log.Id) {
                return BadRequest();
            }
            _context.Entry(log).State = EntityState.Modified;
            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if(!LogExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Log>> Delete(int id) {
            var log = await _context.Logs.FindAsync(id);
            if(log == null) {
                return NotFound();
            }
            _context.Logs.Remove(log);
            await _context.SaveChangesAsync();
            return log;
        }

        private bool LogExists(int id) {
            return _context.Logs.Any(l => l.Id == id);
        }

    }
}