namespace FootBall.API.Services
{
    using FootBall.API.Interfaces;
    using FootBall.API.Entities;
    public class StadiumOwnerService : IStadiumOwnerService
    {
        public StadiumOwner GetConcretteStadiumOwner(StadiumOwner stadiumOwner)
        {
            if (stadiumOwner == null ||
                stadiumOwner.Name.Length < 3 ||
                stadiumOwner.Surname.Length < 3 ||
                stadiumOwner.Age < 18
                )
            {
                return null;
            }
            return stadiumOwner;
        }
    }
}
