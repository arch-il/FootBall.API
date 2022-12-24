namespace FootBall.API.Entities
{
    using System.ComponentModel.DataAnnotations;
    public abstract class Owner<T>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public List<T> TOwner { get; set; }
    }
}
