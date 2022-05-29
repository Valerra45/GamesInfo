using AutoMapper;
using GamesInfo.Core.Abstractions;
using GamesInfo.Core.Domain;
using GamesInfo.Core.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesInfo.Application.Services.Developers.Queries
{
    public class GetDeveloperByIdQuery : IRequest<DeveloperResponse>
    {
        public Guid Id { get; set; }
    }

    public class GetDeveloperByIdQueryHandler : IRequestHandler<GetDeveloperByIdQuery, DeveloperResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Developer> _developerRepository;

        public GetDeveloperByIdQueryHandler(IMapper mapper,
           IRepository<Developer> developerRepository)
        {
            _mapper = mapper;
            _developerRepository = developerRepository;
        }

        public async Task<DeveloperResponse> Handle(GetDeveloperByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _developerRepository.GetByIdAsync(request.Id);

            if (response is null)
            {
                throw new EntityNotFoundException($"{nameof(Developer)} with id '{request.Id}' doesn't exist");
            }

            return _mapper.Map<DeveloperResponse>(response);
        }
    }
}
