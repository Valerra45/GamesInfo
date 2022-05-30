namespace GamesInfo.Core.Domain
{
    public class Developer
        : BaseEntity
    {
        public string? Name { get; set; }

        public virtual List<Game>? Games { get; set; }
    }
}
