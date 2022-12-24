namespace FootBall.API.Interfaces
{
    using FootBall.API.Entities;
    public interface ITeamOwnerService
    {
        TeamOwner GetConcretteTeamOwner(TeamOwner teamOwner);
    }
}
