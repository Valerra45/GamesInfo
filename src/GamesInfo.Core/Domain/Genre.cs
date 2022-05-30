namespace GamesInfo.Core.Domain
{
    public class Genre
        : BaseEntity
    {
        public string? Name { get; set; }

        public virtual List<Game>? Games { get; set; }
    }
}
