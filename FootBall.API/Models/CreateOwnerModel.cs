using System.ComponentModel.DataAnnotations;

namespace FootBall.API.Models
{
    public abstract class CreateOwnerModel<T>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public List<T> TOwner { get; set; }
    }
}
