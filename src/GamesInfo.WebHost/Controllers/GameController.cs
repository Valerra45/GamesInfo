using GamesInfo.Application.Services.Games;
using GamesInfo.Application.Services.Games.Commands;
using GamesInfo.Application.Services.Games.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GamesInfo.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController
        : ControllerBase
    {
        private readonly IMediator _mediatr;

        public GameController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameResponse>>> GetGamesAsync()
        {
            var response = await _mediatr.Send(new GetAllGamesQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameResponse>> GetGameAsync(Guid id)
        {
            var response = await _mediatr.Send(new GetGameByIdQuery { Id = id });

            return Ok(response);
        }

        [HttpGet("genre")]
        public async Task<ActionResult<GameResponse>> GetGameByGenreAsync([FromQuery] GameGenreRequest byGenre)
        {
            var response = await _mediatr.Send(new GetGamesByGenre { Request = byGenre });

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGameAsync(CreateOrEditGameRequest request)
        {
            var response = await _mediatr.Send(new CreateGameCommand { Request = request });

            return CreatedAtAction(nameof(GetGameAsync), new { id = response }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGameAsync(Guid id, CreateOrEditGameRequest request)
        {
            var response = await _mediatr.Send(new UpdateGameCommand { Id = id, Request = request });

            return CreatedAtAction(nameof(GetGameAsync), new { id = response }, response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGameAsync(Guid id)
        {
            await _mediatr.Send(new DeleteGameCommand { Id = id });

            return NoContent();
        }
    }
}
