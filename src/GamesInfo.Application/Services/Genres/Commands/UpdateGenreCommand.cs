using AutoMapper;
using GamesInfo.Core.Abstractions;
using GamesInfo.Core.Domane;
using GamesInfo.Core.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesInfo.Application.Services.Genres.Commands
{
    public class UpdateGenreCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public GenreDto? Request { get; set; }
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

            await _genreRepository.UpdateAsync(genre);

            return genre.Id;
        }
    }
}
