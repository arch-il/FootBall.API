using System.ComponentModel.DataAnnotations;

namespace FootBall.API.Models
{
    public class CreateRefereeModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int CardsGiven { get; set; }
        [Required]
        public double Experience { get; set; }
    }
}
