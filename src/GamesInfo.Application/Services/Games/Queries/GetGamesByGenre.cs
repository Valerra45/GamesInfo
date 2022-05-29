using AutoMapper;
using GamesInfo.Core.Abstractions;
using GamesInfo.Core.Domain;
using GamesInfo.Core.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesInfo.Application.Services.Games.Queries
{
    public class GetGamesByGenre : IRequest<IEnumerable<GameResponse>>
    {
        public GameGenreRequest? Request { get; set; }
    }

    public class GetGamesByGenreHandler : IRequestHandler<GetGamesByGenre, IEnumerable<GameResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Game> _gameRepository;
        private readonly IRepository<Genre> _genreRepository;

        public GetGamesByGenreHandler(IMapper mapper,
            IRepository<Game> gameRepository,
            IRepository<Genre> genreRepository)
        {
            _mapper = mapper;
            _gameRepository = gameRepository;
            _genreRepository = genreRepository;
        }

        public async Task<IEnumerable<GameResponse>> Handle(GetGamesByGenre request, CancellationToken cancellationToken)
        {
            if (request.Request.Id == Guid.Empty)
            {
                throw new EmptyGuidException($"{nameof(Genre)} id is empty");
            }

            var genre = await _genreRepository.GetByIdAsync(request.Request.Id);

            if (genre is null)
            {
                throw new EntityNotFoundException($"{nameof(Genre)} with id '{request.Request.Id}' doesn't exist");
            }

            var response = await _gameRepository.GetWhere(x => x.Genres.Contains(genre));

            return _mapper.Map<IEnumerable<GameResponse>>(response);
        }
    }
}
