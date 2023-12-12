using NetflixApiClone.Identity;

namespace NetflixApiClone.Models
{
    public class MyList
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Movie>? Movies { get; set; }
        public virtual ICollection<Series>? Series { get; set; }

        public MyList() 
        {
            Movies = new HashSet<Movie>();
            Series = new HashSet<Series>();
        }

    }
}
