namespace FootBall.API.Models
{
    public class CreateRefereeModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int CardsGiven { get; set; }
        public double Experience { get; set; }
    }
}
