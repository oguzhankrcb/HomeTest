using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HomeTest.Models
{
    public class HomeTestContext : DbContext
    {
        public HomeTestContext (DbContextOptions<HomeTestContext> options)
            : base(options)
        {
        }

        public DbSet<HomeTest.Models.Car> Car { get; set; }
        public DbSet<HomeTest.Models.Buss> Buss { get; set; }
        public DbSet<HomeTest.Models.Boat> Boat { get; set; }
        public DbSet<HomeTest.Models.Wheel> Wheel { get; set; }
        public DbSet<HomeTest.Models.Headlight> Headlight { get; set; }
    }
}
