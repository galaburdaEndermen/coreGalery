using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreGalery.Models
{
    public class GaleryDbContext : DbContext
    {
        public DbSet<PaintingModel> Paintings { get; set; }
        public GaleryDbContext(DbContextOptions<GaleryDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

       
    }
}
