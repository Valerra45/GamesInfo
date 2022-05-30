using GamesInfo.Core.Abstractions;
using GamesInfo.Core.Domain;
using GamesInfo.Core.Exceptions;
using MediatR;

namespace GamesInfo.Application.Services.Genres.Commands
{
    public class UpdateGenreCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public CreateOrEditGenreRequest? Request { get; set; }
    }

    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, Guid>
    {
        private readonly IRepository<Genre> _genreRepository;

        public UpdateGenreCommandHandler(IRepository<Genre> genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<Guid> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.GetByIdAsync(request.Id);

            if (genre is null)
            {
                throw new EntityNotFoundException($"{nameof(Genre)} with id '{request.Id}' doesn't exist");
            }

            genre.Name = request.Request.Name;
            genre.Update = DateTime.Now;

            await _genreRepository.UpdateAsync(genre);

            return genre.Id;
        }
    }
}
