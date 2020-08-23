using Microsoft.EntityFrameworkCore;
using SamsSoup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamsSoup.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Soup> Soups { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
