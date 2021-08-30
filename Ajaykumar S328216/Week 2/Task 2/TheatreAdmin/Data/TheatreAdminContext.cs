using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheatreAdmin.Models;

namespace TheatreAdmin.Data
{
    public class TheatreAdminContext : DbContext
    {
        public TheatreAdminContext (DbContextOptions<TheatreAdminContext> options)
            : base(options)
        {
        }

        public DbSet<TheatreAdmin.Models.Movie> Movie { get; set; }

        public DbSet<TheatreAdmin.Models.Category> Category { get; set; }
    }
}
