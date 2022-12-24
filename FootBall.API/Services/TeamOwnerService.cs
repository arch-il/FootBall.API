namespace FootBall.API.Services
{
    using FootBall.API.Interfaces;
    using FootBall.API.Entities;
    public class TeamOwnerService : ITeamOwnerService
    {
        public TeamOwner GetConcretteTeamOwner(TeamOwner teamOwner)
        {
            if (teamOwner == null ||
                teamOwner.Name.Length < 3 ||
                teamOwner.Surname.Length < 3 ||
                teamOwner.Age < 18
                )
            {
                return null;
            }
            return teamOwner;
        }
    }
}
