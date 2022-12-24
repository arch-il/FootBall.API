namespace FootBall.API.Interfaces
{
    using FootBall.API.Entities;
    public interface ITeamService
    {
        Team GetConcretteTeam(Team team);
    }
}
