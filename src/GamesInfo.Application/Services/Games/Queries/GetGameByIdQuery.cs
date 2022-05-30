using AutoMapper;
using GamesInfo.Core.Abstractions;
using GamesInfo.Core.Domain;
using GamesInfo.Core.Exceptions;
using MediatR;

namespace GamesInfo.Application.Services.Games.Queries
{
    public class GetGameByIdQuery : IRequest<GameResponse>
    {
        public Guid Id { get; set; }
    }

    public class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, GameResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Game> _gameRepository;

        public GetGameByIdQueryHandler(IMapper mapper,
            IRepository<Game> gameRepository)
        {
            _mapper = mapper;
            _gameRepository = gameRepository;
        }

        public async Task<GameResponse> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _gameRepository.GetByIdAsync(request.Id);

            if (response is null)
            {
                throw new EntityNotFoundException($"{nameof(Game)} with id '{request.Id}' doesn't exist");
            }

            return _mapper.Map<GameResponse>(response);
        }
    }
}
