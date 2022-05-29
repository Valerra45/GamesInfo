using GamesInfo.Core.Abstractions;
using GamesInfo.Core.Domain;
using GamesInfo.Core.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesInfo.Application.Services.Genres.Commands
{
    public class DeleteGenreCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand>
    {
        private readonly IRepository<Genre> _genreRepository;

        public DeleteGenreCommandHandler(IRepository<Genre> genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<Unit> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.GetByIdAsync(request.Id);

            if (genre is null)
            {
                throw new EntityNotFoundException($"{nameof(Genre)} with id '{request.Id}' doesn't exist");
            }
          
            await _genreRepository.DeleteAsync(genre);

            return Unit.Value;
        }
    }
}
