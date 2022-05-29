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
    public class GetAllGeneresQuery : IRequest<IEnumerable<GenereDto>> { }

    public class GetAllGeneresQueryHandler : IRequestHandler<GetAllGeneresQuery, IEnumerable<GenereDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Genre> _genereRepository;

        public GetAllGeneresQueryHandler(IMapper mapper,
            IRepository<Genre> genereRepository)
        {
            _mapper = mapper;
            _genereRepository = genereRepository;
        }

        public async Task<IEnumerable<GenereDto>> Handle(GetAllGeneresQuery request, CancellationToken cancellationToken)
        {
            var generes = await _genereRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<GenereDto>>(generes);
        }
    }
}
