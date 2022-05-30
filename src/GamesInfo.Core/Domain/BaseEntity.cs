namespace GamesInfo.Core.Domain
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Update { get; set; }
    }
}
