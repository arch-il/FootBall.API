namespace FootBall.API.Entities
{
    using System.ComponentModel.DataAnnotations;
    public abstract class Match
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Stadium stadium { get; set; }
        [Required]
        public Team HomeTeam { get; set; }
        [Required]
        public Team GuestTeam { get; set; }
        [Required]
        public int LeftScore { get; set; }
        [Required]
        public int RightScore { get; set; }
    }
}
