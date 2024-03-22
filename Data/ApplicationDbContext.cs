using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TN_Treasury_Web_Portal.Models;

namespace TN_Treasury_Web_Portal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TN_Treasury_Web_Portal.Models.FAQ> FAQ { get; set; } = default!;

        public DbSet<TN_Treasury_Web_Portal.Models.Guide>? Guide { get; set; }

        public DbSet<TN_Treasury_Web_Portal.Models.GuideSection>? GuideSection { get; set; }
    }
}
