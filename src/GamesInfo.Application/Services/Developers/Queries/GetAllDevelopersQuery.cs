using AutoMapper;
using GamesInfo.Core.Abstractions;
using GamesInfo.Core.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesInfo.Application.Services.Developers.Queries
{
    public class GetAllDevelopersQuery : IRequest<IEnumerable<DeveloperResponse>> { }

    public class GetAllDevelopersQueryHadler : IRequestHandler<GetAllDevelopersQuery, IEnumerable<DeveloperResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Developer> _developerRepository;

        public GetAllDevelopersQueryHadler(IMapper mapper,
            IRepository<Developer> developerRepository)
        {
            _mapper = mapper;
            _developerRepository = developerRepository;
        }

        public async Task<IEnumerable<DeveloperResponse>> Handle(GetAllDevelopersQuery request, CancellationToken cancellationToken)
        {
            var response = await _developerRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<DeveloperResponse>>(response);
        }
    }
}
