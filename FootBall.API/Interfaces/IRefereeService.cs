namespace FootBall.API.Interfaces
{
    using FootBall.API.Entities;
    public interface IRefereeService
    {
        Referee GetConcretteReferee(Referee referee);
    }
}
