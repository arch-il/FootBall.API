namespace FootBall.API.Interfaces
{
    using FootBall.API.Entities;
    public interface IStadiumOwnerService
    {
        StadiumOwner GetConcretteStadiumOwner(StadiumOwner stadiumOwner);
    }
}
