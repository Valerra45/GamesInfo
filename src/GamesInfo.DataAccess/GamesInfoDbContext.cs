using GamesInfo.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesInfo.DataAccess
{
    public class GamesInfoDbContext 
        : DbContext
    {
        public GamesInfoDbContext(DbContextOptions<GamesInfoDbContext> options)
            :base(options)
        {

        }

        public DbSet<Genre>? Genres { get; set; }

        public DbSet<Developer>? Developers { get; set; }

        public DbSet<Game>? Games { get; set; }
    }
}
