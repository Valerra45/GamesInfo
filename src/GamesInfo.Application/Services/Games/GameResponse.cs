﻿using GamesInfo.Application.Services.Developers;
using GamesInfo.Application.Services.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesInfo.Application.Services.Games
{
    public class GameResponse
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DeveloperResponse? Developer { get; set; }

        public List<GenreResponse>? Genres { get; set; }
    }
}
