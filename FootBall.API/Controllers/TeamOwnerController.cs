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
    public class TeamOwnerController : ControllerBase
    {
        private readonly ILogger<TeamOwnerController> _logger;
        private readonly ITeamOwnerService _teamOwnerService;
        private readonly UserContext db;

        public TeamOwnerController(ILogger<TeamOwnerController> logger, ITeamOwnerService teamOwnerService, UserContext db)
        {
            _logger = logger;
            _teamOwnerService = teamOwnerService;
            this.db = db;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<TeamOwner>>> GetAll()
        {
            return await this.db.teamOwner.ToListAsync();
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<TeamOwner>> GetById(int id)
        {
            TeamOwner teamOwner = await this.db.teamOwner.FirstOrDefaultAsync(x => x.Id == id);

            if (teamOwner == null)
                return NotFound();

            return new ObjectResult(teamOwner);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<TeamOwner>> Create([FromQuery] TeamOwner teamOwner)
        {
            if (teamOwner == null)
                return this.BadRequest();

            db.teamOwner.Add(teamOwner);

            await this.db.SaveChangesAsync();

            return Ok(teamOwner);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<TeamOwner>> Update([FromQuery] TeamOwner teamOwner)
        {
            if (teamOwner == null)
                return this.BadRequest();

            if (!db.teamOwner.Any(x => x.Id == teamOwner.Id))
                return this.NotFound();

            db.teamOwner.Update(teamOwner);
            await db.SaveChangesAsync();

            return Ok(teamOwner);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<TeamOwner>> Delete(int id)
        {
            TeamOwner teamOwner = await this.db.teamOwner.FirstOrDefaultAsync(x => x.Id == id);

            if (id < 0)
                return NotFound();

            db.teamOwner.Remove(teamOwner);
            await db.SaveChangesAsync();
            return Ok(teamOwner);
        }
    }
}
