namespace FootBall.API.Entities
{
    public abstract class CreateMatchModel
    {
        public int Id { get; set; }
        public Stadium stadium { get; set; }
        public Team HomeTeam { get; set; }
        public Team GuestTeam { get; set; }
        public int LeftScore { get; set; }
        public int RightScore { get; set; }
    }
}
