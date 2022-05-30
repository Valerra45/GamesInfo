using GamesInfo.Application.Services.Developers;
using GamesInfo.Application.Services.Genres;

namespace GamesInfo.Application.Services.Games
{
    public class GameResponse
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DeveloperResponse? Developer { get; set; }

        public List<GenreResponse>? Genres { get; set; }
    }
}
