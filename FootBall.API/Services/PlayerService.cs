namespace FootBall.API.Services
{
    using FootBall.API.Interfaces;
    using FootBall.API.Entities;
    public class PlayerService : IPlayerService
    {
        public Player GetConcrettePlayer(Player player)
        {
            if (player == null ||
                player.Name.Length < 3 ||
                player.Surname.Length < 3 ||
                player.Age < 14 ||
                player.Platform.Length < 3 ||
                player.Rating < 0
                )
            {
                return null;
            }
            return player;
        }
    }
}
