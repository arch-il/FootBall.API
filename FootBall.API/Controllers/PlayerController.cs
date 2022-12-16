using FootBall.API.Interfaces;
using FootBall.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootBall.API.Controllers
{
    using FootBall.API.Context;
    using FootBall.API.Models;
    using FootBall.API.Interfaces;

    using Microsoft.EntityFrameworkCore;

    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly IPlayerService _playerService;
        private readonly PlayerContext db;

        public PlayerController(ILogger<PlayerController> logger, IPlayerService playerService, PlayerContext db)
        {
            _logger = logger;
            _playerService = playerService;
            this.db = db;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Player>>> GetAll()
        {
            return await this.db.player.ToListAsync();
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Player>> GetById(int id)
        {
            Player player = await this.db.player.FirstOrDefaultAsync(x => x.Id == id);

            if (player == null)
                return NotFound();

            return new ObjectResult(player);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Player>> Create([FromQuery] Player player)
        {
            if (player == null)
                return this.BadRequest();

            db.player.Add(player);

            await this.db.SaveChangesAsync();

            return Ok(player);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<Player>> Update([FromQuery] Player player)
        {
            if (player == null)
                return this.BadRequest();

            if (!db.player.Any(x => x.Id == player.Id))
                return this.NotFound();

            db.player.Update(player);
            await db.SaveChangesAsync();

            return Ok(player);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<Player>> Delete(int id)
        {
            Player player = await this.db.player.FirstOrDefaultAsync(x => x.Id == id);

            if (id < 0)
                return NotFound();

            db.player.Remove(player);
            await db.SaveChangesAsync();
            return Ok(player);
        }
    }
}


/*
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootBall.API.Controllers
{
    using FootBall.API.Context;
    using FootBall.API.Entity;
    using FootBall.API.Models;

    using Microsoft.EntityFrameworkCore;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext db;

        public UserController(UserContext db)
        {
            this.db = db;
        }

        
    }
}
*/