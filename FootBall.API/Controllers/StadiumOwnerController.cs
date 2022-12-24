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
    public class StadiumOwnerController : ControllerBase
    {
        private readonly ILogger<StadiumOwnerController> _logger;
        private readonly IStadiumOwnerService _stadiumOwnerService;
        private readonly UserContext db;

        public StadiumOwnerController(ILogger<StadiumOwnerController> logger, IStadiumOwnerService stadiumOwnerService, UserContext db)
        {
            _logger = logger;
            _stadiumOwnerService = stadiumOwnerService;
            this.db = db;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<StadiumOwner>>> GetAll()
        {
            return await this.db.stadiumOwner.ToListAsync();
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<StadiumOwner>> GetById(int id)
        {
            StadiumOwner stadiumOwner = await this.db.stadiumOwner.FirstOrDefaultAsync(x => x.Id == id);

            if (stadiumOwner == null)
                return NotFound();

            return new ObjectResult(stadiumOwner);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<StadiumOwner>> Create([FromQuery] StadiumOwner stadiumOwner)
        {
            if (stadiumOwner == null)
                return this.BadRequest();

            db.stadiumOwner.Add(stadiumOwner);

            await this.db.SaveChangesAsync();

            return Ok(stadiumOwner);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<StadiumOwner>> Update([FromQuery] StadiumOwner stadiumOwner)
        {
            if (stadiumOwner == null)
                return this.BadRequest();

            if (!db.stadiumOwner.Any(x => x.Id == stadiumOwner.Id))
                return this.NotFound();

            db.stadiumOwner.Update(stadiumOwner);
            await db.SaveChangesAsync();

            return Ok(stadiumOwner);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<StadiumOwner>> Delete(int id)
        {
            StadiumOwner stadiumOwner = await this.db.stadiumOwner.FirstOrDefaultAsync(x => x.Id == id);

            if (id < 0)
                return NotFound();

            db.stadiumOwner.Remove(stadiumOwner);
            await db.SaveChangesAsync();
            return Ok(stadiumOwner);
        }
    }
}
