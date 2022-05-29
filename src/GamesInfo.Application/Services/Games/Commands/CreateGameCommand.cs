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

namespace GamesInfo.Application.Services.Games.Commands
{
    public class CreateGameCommand : IRequest<Guid>
    {
        public CreateOrEditGameRequest? Request { get; set; }
    }

    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Game> _gameRepository;
        private readonly IRepository<Developer> _developerRepository;
        private readonly IRepository<Genre> _genreRepository;

        public CreateGameCommandHandler(IMapper mapper,
            IRepository<Game> gameRepository,
            IRepository<Developer> developerRepository,
            IRepository<Genre> genreRepository)
        {
            _mapper = mapper;
            _gameRepository = gameRepository;
            _developerRepository = developerRepository;
            _genreRepository = genreRepository;
        }

        public async Task<Guid> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var game = _mapper.Map<Game>(request.Request);

            if (request.Request.DeveloperId != Guid.Empty)
            {
                var developer = await _developerRepository.GetByIdAsync(request.Request.DeveloperId);

                if (developer is null)
                {
                    throw new EntityNotFoundException($"{nameof(Developer)} with id '{request.Request.DeveloperId}' doesn't exist");
                }

                game.Developer = developer;
            }

            if (request.Request.GenreIds is not null)
            {
                var genres = await _genreRepository.GetRangeByIdsAsync(request.Request.GenreIds);

                if (genres is null)
                {
                    throw new EntityNotFoundException($"{nameof(Genre)} with ids '{request.Request.DeveloperId}' doesn't exist");
                }

                game.Genres = new List<Genre>(genres);
            }

            game.Created = DateTime.Now;

            await _gameRepository.AddAsync(game);

            return game.Id;
        }
    }
}
