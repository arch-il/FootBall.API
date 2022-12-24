
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
    public class TeamController : ControllerBase
    {
        private readonly ILogger<TeamController> _logger;
        private readonly ITeamService _teamService;
        private readonly UserContext db;

        public TeamController(ILogger<TeamController> logger, ITeamService teamService, UserContext db)
        {
            _logger = logger;
            _teamService = teamService;
            this.db = db;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Team>>> GetAll()
        {
            return await this.db.team.ToListAsync();
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Team>> GetById(int id)
        {
            Team team = await this.db.team.FirstOrDefaultAsync(x => x.Id == id);

            if (team == null)
                return NotFound();

            return new ObjectResult(team);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Team>> Create([FromQuery] Team team)
        {
            if (team == null)
                return this.BadRequest();

            db.team.Add(team);

            await this.db.SaveChangesAsync();

            return Ok(team);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<Team>> Update([FromQuery] Team team)
        {
            if (team == null)
                return this.BadRequest();

            if (!db.team.Any(x => x.Id == team.Id))
                return this.NotFound();

            db.team.Update(team);
            await db.SaveChangesAsync();

            return Ok(team);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<Team>> Delete(int id)
        {
            Team team = await this.db.team.FirstOrDefaultAsync(x => x.Id == id);

            if (id < 0)
                return NotFound();

            db.team.Remove(team);
            await db.SaveChangesAsync();
            return Ok(team);
        }
    }
}
