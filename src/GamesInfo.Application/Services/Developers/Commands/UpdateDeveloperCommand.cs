using GamesInfo.Core.Abstractions;
using GamesInfo.Core.Domain;
using GamesInfo.Core.Exceptions;
using MediatR;

namespace GamesInfo.Application.Services.Developers.Commands
{
    public class UpdateDeveloperCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public CreateOrEditDeveloperRequest? Request { get; set; }
    }

    public class UpdateDeveloperCommandHandler : IRequestHandler<UpdateDeveloperCommand, Guid>
    {
        private readonly IRepository<Developer> _developerRepository;

        public UpdateDeveloperCommandHandler(IRepository<Developer> developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public async Task<Guid> Handle(UpdateDeveloperCommand request, CancellationToken cancellationToken)
        {
            var developer = await _developerRepository.GetByIdAsync(request.Id);

            if (developer is null)
            {
                throw new EntityNotFoundException($"{nameof(Developer)} with id '{request.Id}' doesn't exist");
            }

            developer.Name = request.Request.Name;
            developer.Update = DateTime.Now;

            await _developerRepository.UpdateAsync(developer);

            return developer.Id;
        }
    }
}
