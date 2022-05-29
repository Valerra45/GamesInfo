using GamesInfo.Application.Services.Genres;
using GamesInfo.Application.Services.Genres.Commands;
using GamesInfo.Application.Services.Genres.Queryes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesInfo.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController
        : ControllerBase
    {
        private readonly IMediator _mediatr;

        public GenreController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDto>>> GetGenresAsync()
        {
            var response = await _mediatr.Send(new GetAllGenresQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDto>> GetGenreAsync(Guid id)
        {
            var response = await _mediatr.Send(new GetGenreByIdQuery { Id = id });

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenreAsync(GenreDto request)
        {
            var response = await _mediatr.Send(new CreateGenreCommand { Request = request });

            return CreatedAtAction(nameof(GetGenreAsync), new { id = response }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenreAsync(Guid id, GenreDto request)
        {
            var response = await _mediatr.Send(new UpdateGenreCommand { Id = id, Request = request });

            return CreatedAtAction(nameof(GetGenreAsync), new { id = response }, response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGenerAsync(Guid id)
        {
            await _mediatr.Send(new DeleteGenreCommand { Id = id });

            return NoContent();
        }
    }
}
