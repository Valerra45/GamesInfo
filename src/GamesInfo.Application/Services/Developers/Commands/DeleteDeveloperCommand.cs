using GamesInfo.Core.Abstractions;
using GamesInfo.Core.Domain;
using GamesInfo.Core.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesInfo.Application.Services.Developers.Commands
{
    public class DeleteDeveloperCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteDeveloperCommandHandler : IRequestHandler<DeleteDeveloperCommand>
    {
        private readonly IRepository<Developer> _developerRepository;

        public DeleteDeveloperCommandHandler(IRepository<Developer> developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public async Task<Unit> Handle(DeleteDeveloperCommand request, CancellationToken cancellationToken)
        {
            var developer = await _developerRepository.GetByIdAsync(request.Id);

            if (developer is null)
            {
                throw new EntityNotFoundException($"{nameof(Developer)} with id '{request.Id}' doesn't exist");
            }

            await _developerRepository.DeleteAsync(developer);

            return Unit.Value;
        }
    }
}
