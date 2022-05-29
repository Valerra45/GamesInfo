using AutoMapper;
using GamesInfo.Core.Abstractions;
using GamesInfo.Core.Domane;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesInfo.Application.Services.Genres.Commands
{
    public class CreateGenreCommand : IRequest<Guid>
    {
        public GenreDto? Request { get; set; }
    }

    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Genre> _genreRepository;

        public CreateGenreCommandHandler(IMapper mapper,
            IRepository<Genre> genreRepository)
        {
            _mapper = mapper;
            _genreRepository = genreRepository;
        }

        public async Task<Guid> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = _mapper.Map<Genre>(request.Request);

            await _genreRepository.AddAsync(genre);

            return genre.Id;
        }
    }
}
