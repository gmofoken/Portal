using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.Data;
using Portal.Models;

namespace Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionsController : ControllerBase
    {
        private readonly PortalContext _context;

        public SubmissionsController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/Submissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Submissions>>> GetSubmissions()
        {
            return await _context.Submissions.ToListAsync();
        }

        // GET: api/Submissions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Submissions>> GetSubmissions(int id)
        {
            var submissions = await _context.Submissions.FindAsync(id);

            if (submissions == null)
            {
                return NotFound();
            }

            return submissions;
        }

        // PUT: api/Submissions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubmissions(int id, Submissions submissions)
        {
            if (id != submissions.SubmissionID)
            {
                return BadRequest();
            }

            _context.Entry(submissions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubmissionsExists(id))
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

        // POST: api/Submissions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Submissions>> PostSubmissions(Submissions submissions)
        {
            _context.Submissions.Add(submissions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubmissions", new { id = submissions.SubmissionID }, submissions);
        }

        // DELETE: api/Submissions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubmissions(int id)
        {
            var submissions = await _context.Submissions.FindAsync(id);
            if (submissions == null)
            {
                return NotFound();
            }

            _context.Submissions.Remove(submissions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubmissionsExists(int id)
        {
            return _context.Submissions.Any(e => e.SubmissionID == id);
        }
    }
}
