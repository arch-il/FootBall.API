using Microsoft.AspNetCore.Mvc;

namespace FootBall.API.Controllers
{
    using FootBall.API.Interfaces;
    using FootBall.API.Models;

    [ApiController]
    [Route("[controller]")]
    public class FootballerStatsController : ControllerBase
    {
        private readonly ILogger<FootballerStatsController> _logger;
        private readonly IFootballerStatsService _footballerStats;

        public FootballerStatsController(ILogger<FootballerStatsController> logger, IFootballerStatsService footballerStats)
        {
            _logger = logger;
            _footballerStats = footballerStats;
        }

        [HttpGet(Name = "GetFootballerStats")]
        public FootballerStats GetFootballerStats([FromQuery] FootballerStats footballerStats) => _footballerStats.GetConcretteFootballerStats(footballerStats);
    }
}
