using GamesInfo.Core.Domain;

namespace GamesInfo.DataAccess.Data
{
    public class FakeDataFactory
    {
        public static IEnumerable<Genre> Genres => new List<Genre>
        {
            new Genre
            {
                Id = Guid.Parse("AC854817-4EE3-4E87-89BD-FC7F2823EE3F"),
                Name = "Action",
                Created = DateTime.Now
            },

             new Genre
            {
                Id = Guid.Parse("7822BD17-CDD2-4ECD-A083-DB8238109090"),
                Name = "Adventure",
                Created = DateTime.Now
            },

          new Genre
            {
                Id = Guid.Parse("AC4B3E64-53ED-46AA-B3E3-16894B559781"),
                Name = "MMO",
                Created = DateTime.Now
            }
        };

        public static IEnumerable<Developer> Developers => new List<Developer>
        {
            new Developer
            {
                Id = Guid.Parse("CFB68A66-DACD-4751-AF53-AB72AA583B5E"),
                Name = "Valve Corporation",
                Created = DateTime.Now
            },

             new Developer
            {
                Id = Guid.Parse("6E123151-FBF4-4180-9FA8-F29F9D2FA33D"),
                Name = "RockStar Games",
                Created = DateTime.Now
            }
        };

        public static IEnumerable<Game> Games()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            yield return new Game
            {
                Id = Guid.Parse("A26F7827-B9CA-4CB0-AA1D-2765330B7E80"),
                Name = "Counter-Strike",

                Description = "It's hard to talk about a storyline when there isn't one. " +
                "There are also no different levels, because there are only rounds when you " +
                "need to destroy enemies and leave them as few as possible.",

                Developer = Developers.FirstOrDefault(x => x.Name == "Valve Corporation"),
                Genres = new List<Genre>
                {
                    Genres.FirstOrDefault(x => x.Name == "Action"),
                    Genres.FirstOrDefault(x => x.Name == "MMO"),
                },

                Created = DateTime.Now
            };

            yield return new Game
            {
                Id = Guid.Parse("5C6D5C52-C515-4375-ADEA-F0D25A052F51"),
                Name = "Red Dead Redemption 2",

                Description = "The main character of the game is a professional gangster named Arthur Morgan. " +
                "Previously, he was engaged in the fact that he robbed everyone and traded in extortion.",

                Developer = Developers.FirstOrDefault(x => x.Name == "RockStar Games"),
                Genres = new List<Genre>
                {
                    Genres.FirstOrDefault(x => x.Name == "Adventure"),
                },

                Created = DateTime.Now
            };
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
