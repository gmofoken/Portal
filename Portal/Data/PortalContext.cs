using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Portal.Models;

namespace Portal.Data
{
    public class PortalContext : DbContext
    {
        public PortalContext (DbContextOptions<PortalContext> options)
            : base(options)
        {
        }

        public DbSet<Portal.Models.Users> Users { get; set; }

        public DbSet<Portal.Models.Submissions> Submissions { get; set; }
    }
}
