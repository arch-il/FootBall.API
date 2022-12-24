using System.ComponentModel.DataAnnotations;

namespace FootBall.API.Entities
{
    public class Stadium
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string StadiumName { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public List<Team> Teams { get; set; }
    }
}
