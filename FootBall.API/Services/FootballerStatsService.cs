namespace FootBall.API.Services
{
    using FootBall.API.Interfaces;
    using FootBall.API.Models;
    public class FootballerStatsService : IFootballerStatsService
    {
        public FootballerStats GetConcretteFootballerStats(FootballerStats footballerStats)
        {
            if (footballerStats == null ||
                footballerStats.Name.Length <= 3 ||
                footballerStats.Surname.Length <= 3 ||
                footballerStats.Age < 18 ||
                footballerStats.Height < 1.5 ||
                footballerStats.NumberOfGoals < 0 ||
                footballerStats.NETWorth < 0)
            {
                return null;
            }
            return footballerStats;
        }
    }
}
