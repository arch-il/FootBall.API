namespace FootBall.API.Services
{
    using FootBall.API.Interfaces;
    using FootBall.API.Entities;
    public class StadiumService : IStadiumService
    {
        public Stadium GetConcretteStadium(Stadium stadium)
        {
            if (stadium == null ||
                stadium.StadiumName.Length < 3 ||
                stadium.Adress.Length < 3 ||
                stadium.Country.Length < 3)
            {
                return null;
            }
            return stadium;
        }
    }
}
