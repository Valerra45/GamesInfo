using AutoMapper;
using GamesInfo.Core.Abstractions;
using GamesInfo.Core.Domain;
using MediatR;

namespace GamesInfo.Application.Services.Genres.Queries
{
    public class GetAllGenresQuery : IRequest<IEnumerable<GenreResponse>> { }

    public class GetAllGenresQueryHandler : IRequestHandler<GetAllGenresQuery, IEnumerable<GenreResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Genre> _genreRepository;

        public GetAllGenresQueryHandler(IMapper mapper,
            IRepository<Genre> genreRepository)
        {
            _mapper = mapper;
            _genreRepository = genreRepository;
        }

        public async Task<IEnumerable<GenreResponse>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            var response = await _genreRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<GenreResponse>>(response);
        }
    }
}
