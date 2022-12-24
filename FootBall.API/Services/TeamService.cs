namespace FootBall.API.Services
{
    using FootBall.API.Interfaces;
    using FootBall.API.Entities;
    public class TeamService : ITeamService
    {
        public Team GetConcretteTeam(Team team)
        {
            if (team == null ||
                team.TeamName.Length < 3 ||
                team.TotalPlayers < 0 ||
                team.TeamPrice < 0 ||
                team.TotalWins < 0 ||
                team.TotalLoses < 0 ||
                team.TotalDraw < 0
                )
            {
                return null;
            }
            return team;
        }
    }
}
