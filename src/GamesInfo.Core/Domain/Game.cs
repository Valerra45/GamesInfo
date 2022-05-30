namespace GamesInfo.Core.Domain
{
    public class Game
        : BaseEntity
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public virtual Developer? Developer { get; set; }

        public virtual List<Genre>? Genres { get; set; }
    }
}
