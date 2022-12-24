using System.ComponentModel.DataAnnotations;

namespace FootBall.API.Entities
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TeamName { get; set; }
        [Required]
        public int TotalPlayers { get; set; }
        [Required]
        public decimal TeamPrice { get; set; }
        [Required]
        public List<Player> Players { get; set; }
        [Required]
        public int TotalWins { get; set; }
        [Required]
        public int TotalLoses { get; set; }
        [Required]
        public int TotalDraw { get; set; }
    }
}
