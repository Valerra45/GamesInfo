using GamesInfo.Application.Services.Developers;
using GamesInfo.Application.Services.Developers.Commands;
using GamesInfo.Application.Services.Developers.Queries;
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
    public class DeveloperController 
        : ControllerBase
    {
        private readonly IMediator _mediatr;

        public DeveloperController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeveloperResponse>>> GetDevelopersAsync()
        {
            var response = await _mediatr.Send(new GetAllDevelopersQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeveloperResponse>> GetDeveloperAsync(Guid id)
        {
            var response = await _mediatr.Send(new GetDeveloperByIdQuery { Id = id });

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeveloperAsync(CreateOrEditDeveloperRequest request)
        {
            var response = await _mediatr.Send(new CreateDeveloperCommand { Request = request });

            return CreatedAtAction(nameof(GetDeveloperAsync), new { id = response }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDeveloperAsync(Guid id, CreateOrEditDeveloperRequest request)
        {
            var response = await _mediatr.Send(new UpdateDeveloperCommand { Id = id, Request = request });

            return CreatedAtAction(nameof(GetDeveloperAsync), new { id = response }, response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDeveloperAsync(Guid id)
        {
            await _mediatr.Send(new DeleteDeveloperCommand { Id = id });

            return NoContent();
        }
    }
}
