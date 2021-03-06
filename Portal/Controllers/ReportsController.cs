using System;
using System.Collections;
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
    public class ReportsController : ControllerBase
    {
        private readonly PortalContext _context;
        public ReportsController(PortalContext context)
        {
            _context = context;
        }

        [HttpPost("usersReport")]
        public async Task<ActionResult<List<Users>>> PostSubmissions()
        {
            var users = await _context.Users.ToListAsync();

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        [HttpPost("submissionsReport")]
        public async Task<ActionResult<List<Submissions>>> submissionsReport()
        {
            var subs = await _context.Submissions.ToListAsync();

            if (subs == null)
            {
                return NotFound();
            }

            return subs;
        }

        [HttpPost("submissionsPerModuleReport")]
        public async Task<ActionResult<IEnumerable>> submissionsPerModuleReport()
        {
            var subs = await _context.Submissions.GroupBy(x => x.ModuleCode).ToListAsync();

            var obj = new List<modulesSubmitted>();

            //foreach (var item in subs)
            //{
            //    foreach (var item in obj)
            //    {

            //    }
            //}

            if (subs == null)
            {
                return NotFound();
            }

            return subs;
        }
    }

    public class modulesSubmitted
    {
        public string Module { get; set; }
        public int Submissions { get; set; }
    }
}
