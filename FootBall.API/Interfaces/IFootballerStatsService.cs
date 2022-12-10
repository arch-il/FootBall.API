namespace FootBall.API.Interfaces
{
    using FootBall.API.Models;
    public interface IFootballerStatsService
    {
        FootballerStats GetConcretteFootballerStats(FootballerStats footballerStats);
    }
}
