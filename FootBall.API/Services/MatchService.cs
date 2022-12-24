namespace FootBall.API.Services
{
    using FootBall.API.Interfaces;
    using FootBall.API.Entities;
    public class MatchService : IMatchService
    {
        public Match GetConcretteMatch(Match match)
        {
            if (match == null ||
                match.stadium == null ||
                match.HomeTeam == null ||
                match.GuestTeam == null ||
                match.LeftScore < 0 ||
                match.RightScore < 0
                )
            {
                return null;
            }
            return match;
        }
    }
}
