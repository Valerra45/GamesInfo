using AutoMapper;
using GamesInfo.Core.Abstractions;
using GamesInfo.Core.Domane;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesInfo.Application.Services.Genres.Queryes
{
    public class GetAllGenresQuery : IRequest<IEnumerable<GenreDto>> { }

    public class GetAllGenresQueryHandler : IRequestHandler<GetAllGenresQuery, IEnumerable<GenreDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Genre> _genreRepository;

        public GetAllGenresQueryHandler(IMapper mapper,
            IRepository<Genre> genreRepository)
        {
            _mapper = mapper;
            _genreRepository = genreRepository;
        }

        public async Task<IEnumerable<GenreDto>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            var response = await _genreRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<GenreDto>>(response);
        }
    }
}
