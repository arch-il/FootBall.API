namespace FootBall.API.Models
{
    using FootBall.API.Entities;
    public class CreateTeamModel
    {
        public string TeamName { get; set; }
        public int TotalPlayers { get; set; }
        public decimal TeamPrice { get; set; }
        public List<Player> Players { get; set; }
        public int TotalWins { get; set; }
        public int TotalLoses { get; set; }
        public int TotalDraw { get; set; }
    }
}
