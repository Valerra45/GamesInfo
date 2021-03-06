namespace GamesInfo.Application.Services.Games
{
    public class CreateOrEditGameRequest
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public Guid DeveloperId { get; set; }

        public List<Guid>? GenreIds { get; set; }
    }
}
