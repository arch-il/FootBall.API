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
    public class RefereeController : ControllerBase
    {
        private readonly ILogger<RefereeController> _logger;
        private readonly IRefereeService _refereeService;
        private readonly RefereeContext db;

        public RefereeController(ILogger<RefereeController> logger, IRefereeService refereeService, RefereeContext db)
        {
            _logger = logger;
            _refereeService = refereeService;
            this.db = db;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Referee>>> GetAll()
        {
            return await this.db.referee.ToListAsync();
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Referee>> GetById(int id)
        {
            Referee referee = await this.db.referee.FirstOrDefaultAsync(x => x.Id == id);

            if (referee == null)
                return NotFound();

            return new ObjectResult(referee);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Referee>> Create([FromQuery] CreateRefereeModel referee)
        {
            if (referee == null)
                return this.BadRequest();


            db.referee.Add(new Referee
            {
                Name = referee.Name,
                Surname = referee.Surname,
                Age = referee.Age,
                CardsGiven = referee.CardsGiven,
                Experience = referee.Experience
            });

            await this.db.SaveChangesAsync();

            return Ok(referee);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<Referee>> Update([FromQuery] Referee referee)
        {
            if (referee == null)
                return this.BadRequest();

            if (!db.referee.Any(x => x.Id == referee.Id))
                return this.NotFound();

            db.referee.Update(referee);
            await db.SaveChangesAsync();

            return Ok(referee);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<Referee>> Delete(int id)
        {
            Referee referee = await this.db.referee.FirstOrDefaultAsync(x => x.Id == id);

            if (id < 0)
                return NotFound();

            db.referee.Remove(referee);
            await db.SaveChangesAsync();
            return Ok(referee);
        }
    }
}
