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
    public class UpdateGameCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public CreateOrEditGameRequest? Request { get; set; }
    }

    public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, Guid>
    {
        private readonly IRepository<Game> _gameRepository;
        private readonly IRepository<Developer> _developerRepository;
        private readonly IRepository<Genre> _genreRepository;

        public UpdateGameCommandHandler(IRepository<Game> gameRepository,
            IRepository<Developer> developerRepository,
            IRepository<Genre> genreRepository)
        {
            _gameRepository = gameRepository;
            _developerRepository = developerRepository;
            _genreRepository = genreRepository;
        }

        public async Task<Guid> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            var game = await _gameRepository.GetByIdAsync(request.Id);

            if (game is null)
            {
                throw new EntityNotFoundException($"{nameof(Game)} with id '{request.Id}' doesn't exist");
            }

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

                game.Genres.Clear();
                game.Genres.AddRange(genres);
            }

            game.Update = DateTime.Now;

            await _gameRepository.UpdateAsync(game);

            return game.Id;
        }
    }
}
