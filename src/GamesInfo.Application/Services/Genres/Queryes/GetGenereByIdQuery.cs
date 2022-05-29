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

namespace GamesInfo.Application.Services.Genres.Queryes
{
    public class GetGenreByIdQuery : IRequest<GenreDto> 
    {
        public Guid Id { get; set; }
    }

    public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, GenreDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Genre> _genreRepository;

        public GetGenreByIdQueryHandler(IMapper mapper,
            IRepository<Genre> genreRepository)
        {
            _mapper = mapper;
            _genreRepository = genreRepository;
        }

        public async Task<GenreDto> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _genreRepository.GetByIdAsync(request.Id);

            if (response is null)
            {
                throw new EntityNotFoundException($"{nameof(Genre)} with id '{request.Id}' doesn't exist");
            }

            return _mapper.Map<GenreDto>(response);
        }
    }
}
