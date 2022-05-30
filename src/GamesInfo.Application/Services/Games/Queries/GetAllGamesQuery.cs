using AutoMapper;
using GamesInfo.Core.Abstractions;
using GamesInfo.Core.Domain;
using MediatR;

namespace GamesInfo.Application.Services.Games.Queries
{
    public class GetAllGamesQuery : IRequest<IEnumerable<GameResponse>> { }

    public class GetAllGamesQueryHandler : IRequestHandler<GetAllGamesQuery, IEnumerable<GameResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Game> _gameRepository;

        public GetAllGamesQueryHandler(IMapper mapper,
            IRepository<Game> gameRepository)
        {
            _mapper = mapper;
            _gameRepository = gameRepository;
        }

        public async Task<IEnumerable<GameResponse>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
        {
            var response = await _gameRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<GameResponse>>(response);
        }
    }
}
