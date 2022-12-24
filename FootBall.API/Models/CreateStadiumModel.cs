namespace FootBall.API.Entities
{
    public class CreateStadiumModel
    {
        public string StadiumName { get; set; }
        public string Adress { get; set; }
        public string Country { get; set; }
        public List<Team> teams { get; set; }
        public StadiumOwner stadiumOwner { get; set; }
    }
}
