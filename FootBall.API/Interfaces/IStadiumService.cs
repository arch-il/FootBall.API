namespace FootBall.API.Interfaces
{
    using FootBall.API.Entities;
    public interface IStadiumService
    {
        Stadium GetConcretteStadium(Stadium stadium);
    }
}
