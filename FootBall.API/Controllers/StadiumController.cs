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
    public class StadiumController : ControllerBase
    {
        private readonly ILogger<StadiumController> _logger;
        private readonly IStadiumService _stadiumService;
        private readonly UserContext db;

        public StadiumController(ILogger<StadiumController> logger, IStadiumService stadiumService, UserContext db)
        {
            _logger = logger;
            _stadiumService = stadiumService;
            this.db = db;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Stadium>>> GetAll()
        {
            return await this.db.stadium.ToListAsync();
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Stadium>> GetById(int id)
        {
            Stadium stadium = await this.db.stadium.FirstOrDefaultAsync(x => x.Id == id);

            if (stadium == null)
                return NotFound();

            return new ObjectResult(stadium);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Stadium>> Create([FromQuery] Stadium stadium)
        {
            if (stadium == null)
                return this.BadRequest();

            db.stadium.Add(stadium);

            await this.db.SaveChangesAsync();

            return Ok(stadium);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<Stadium>> Update([FromQuery] Stadium stadium)
        {
            if (stadium == null)
                return this.BadRequest();

            if (!db.stadium.Any(x => x.Id == stadium.Id))
                return this.NotFound();

            db.stadium.Update(stadium);
            await db.SaveChangesAsync();

            return Ok(stadium);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<Stadium>> Delete(int id)
        {
            Stadium stadium = await this.db.stadium.FirstOrDefaultAsync(x => x.Id == id);

            if (id < 0)
                return NotFound();

            db.stadium.Remove(stadium);
            await db.SaveChangesAsync();
            return Ok(stadium);
        }
    }
}
