namespace FootBall.API.Interfaces
{
    using FootBall.API.Entities;
    public interface IMatchService
    {
        Match GetConcretteMatch(Match match);
    }
}
