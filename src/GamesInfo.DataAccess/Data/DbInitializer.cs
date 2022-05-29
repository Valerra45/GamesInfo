using GamesInfo.Core.Abstractions;

namespace GamesInfo.DataAccess.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly GamesInfoDbContext _context;

        public DbInitializer(GamesInfoDbContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _context.Database.EnsureDeleted();

            if (_context.Database.EnsureCreated())
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
               
                _context.Games.AddRange(FakeDataFactory.Games());
                _context.SaveChanges();

#pragma warning disable CS8604 // Possible null reference argument.
                foreach (var genere in FakeDataFactory.Genres)
                {
                    if (!_context.Genres.Contains(genere))
                    {
                        _context.Genres.Add(genere);
                    }
                }

                foreach (var developer in FakeDataFactory.Developers)
                {
                    if (!_context.Developers.Contains(developer))
                    {
                        _context.Developers.Add(developer);
                    }
                }

                _context.SaveChanges();

#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            }
        }
    }
}
