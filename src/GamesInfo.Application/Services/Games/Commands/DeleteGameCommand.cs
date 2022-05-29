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
    public class DeleteGameCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand>
    {
        private readonly IRepository<Game> _gameRepository;

        public DeleteGameCommandHandler(IRepository<Game> gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<Unit> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            var developer = await _gameRepository.GetByIdAsync(request.Id);

            if (developer is null)
            {
                throw new EntityNotFoundException($"{nameof(Game)} with id '{request.Id}' doesn't exist");
            }

            await _gameRepository.DeleteAsync(developer);

            return Unit.Value;
        }
    }
}
