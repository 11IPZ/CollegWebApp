namespace CollegWebApp.Domain.Models
{
    public class Profession
    {
        public int Id { get; set; }
        public ICollection<Group> Groups { get; set;}
        public string Name { get; set; }
    }
}
