using AutoMapper;
using GamesInfo.Application.Services.Genres;
using GamesInfo.Core.Domane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesInfo.Application.MapProfiles
{
    public class GamesInfoProfile : Profile
    {
        public GamesInfoProfile()
        {
            CreateMap<Genre, GenreDto>()
                .ReverseMap();
        }
    }
}
