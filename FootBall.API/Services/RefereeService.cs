namespace FootBall.API.Services
{
    using FootBall.API.Interfaces;
    using FootBall.API.Entities;
    public class RefereeService : IRefereeService
    {
        public Referee GetConcretteReferee(Referee referee)
        {
            if (referee == null ||
                referee.Name.Length < 3 ||
                referee.Surname.Length < 3 ||
                referee.Age < 14 ||
                referee.CardsGiven < 0 ||
                referee.Experience < 0.0
                )
            {
                return null;
            }
            return referee;
        }
    }
}
