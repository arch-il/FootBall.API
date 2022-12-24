namespace FootBall.API.Models
{
    using FootBall.API.Entities;
    public class CreatePlayerModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public double Rating { get; set; }
        public Team team { get; set; }
    }
}
