using AutoMapper;
using GamesInfo.Application.Services.Developers;
using GamesInfo.Application.Services.Games;
using GamesInfo.Application.Services.Genres;
using GamesInfo.Core.Domain;

namespace GamesInfo.Application.MapProfiles
{
    public class GamesInfoProfile : Profile
    {
        public GamesInfoProfile()
        {
            CreateMap<Genre, CreateOrEditGenreRequest>()
                .ReverseMap();

            CreateMap<Genre, GenreResponse>()
              .ReverseMap();

            CreateMap<Developer, DeveloperResponse>()
                .ReverseMap();

            CreateMap<Developer, CreateOrEditDeveloperRequest>()
               .ReverseMap();

            CreateMap<Game, GameResponse>()
              .ReverseMap();

            CreateMap<Game, CreateOrEditGameRequest>()
               .ReverseMap();
        }
    }
}
