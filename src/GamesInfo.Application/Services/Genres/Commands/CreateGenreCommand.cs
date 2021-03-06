using AutoMapper;
using GamesInfo.Core.Abstractions;
using GamesInfo.Core.Domain;
using MediatR;

namespace GamesInfo.Application.Services.Genres.Commands
{
    public class CreateGenreCommand : IRequest<Guid>
    {
        public CreateOrEditGenreRequest? Request { get; set; }
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

            genre.Created = DateTime.Now;

            await _genreRepository.AddAsync(genre);

            return genre.Id;
        }
    }
}
