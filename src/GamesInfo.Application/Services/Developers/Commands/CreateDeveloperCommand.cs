using AutoMapper;
using GamesInfo.Core.Abstractions;
using GamesInfo.Core.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesInfo.Application.Services.Developers.Commands
{
    public class CreateDeveloperCommand : IRequest<Guid>
    {
        public CreateOrEditDeveloperRequest? Request { get; set; }
    }

    public class CreateDeveloperCommandHandler : IRequestHandler<CreateDeveloperCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Developer> _developerRepository;

        public CreateDeveloperCommandHandler(IMapper mapper,
             IRepository<Developer> developerRepository)
        {
            _mapper = mapper;
            _developerRepository = developerRepository;
        }

        public async Task<Guid> Handle(CreateDeveloperCommand request, CancellationToken cancellationToken)
        {
            var developer = _mapper.Map<Developer>(request.Request);

            await _developerRepository.AddAsync(developer);

            return developer.Id;
        }
    }
}
