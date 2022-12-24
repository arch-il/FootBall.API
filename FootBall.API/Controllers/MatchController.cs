namespace FootBall.API.Controllers
{
    using FootBall.API.Context;
    using FootBall.API.Models;
    using FootBall.API.Entities;
    using FootBall.API.Interfaces;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [ApiController]
    [Route("[controller]")]
    public class MatchController : ControllerBase
    {
        private readonly ILogger<MatchController> _logger;
        private readonly IMatchService _matchService;
        private readonly UserContext db;

        public MatchController(ILogger<MatchController> logger, IMatchService matchService, UserContext db)
        {
            _logger = logger;
            _matchService = matchService;
            this.db = db;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Match>>> GetAll()
        {
            return await this.db.match.ToListAsync();
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Match>> GetById(int id)
        {
            Match match = await this.db.match.FirstOrDefaultAsync(x => x.Id == id);

            if (match == null)
                return NotFound();

            return new ObjectResult(match);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Match>> Create([FromQuery] Match match)
        {
            if (match == null)
                return this.BadRequest();

            db.match.Add(match);

            await this.db.SaveChangesAsync();

            return Ok(match);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<Match>> Update([FromQuery] Match match)
        {
            if (match == null)
                return this.BadRequest();

            if (!db.match.Any(x => x.Id == match.Id))
                return this.NotFound();

            db.match.Update(match);
            await db.SaveChangesAsync();

            return Ok(match);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<Match>> Delete(int id)
        {
            Match match = await this.db.match.FirstOrDefaultAsync(x => x.Id == id);

            if (id < 0)
                return NotFound();

            db.match.Remove(match);
            await db.SaveChangesAsync();
            return Ok(match);
        }
    }
}
