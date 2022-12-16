namespace FootBall.API.Interfaces
{
    using FootBall.API.Models;
    public interface IPlayerService
    {
        Player GetConcrettePlayer(Player player);
    }
}
