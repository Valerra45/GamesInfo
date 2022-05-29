using GamesInfo.Application.Services.Genres;
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
        public async Task<ActionResult<IEnumerable<GenereDto>>> GetGeneresAsync()
        {
            var response = await _mediatr.Send(new GetAllGeneresQuery());

            return Ok(response);
        } 
    }
}
