using NetflixApiClone.Identity;

namespace NetflixApiClone.Models
{
    public class MyList
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Video>? Movies { get; set; }

        public MyList() 
        {
            Movies = new HashSet<Video>();
        }

    }
}
