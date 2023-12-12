using NetflixApiClone.Identity;
using NetflixApiClone.Models;

namespace NetflixApiClone.Dtos
{
    public class MyListDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<MovieDto>? MovieDtos { get; set; }
        public virtual ICollection<SeriesDto>? SeriesDtos { get; set; }

        public MyListDto()
        {
            MovieDtos = new HashSet<MovieDto>();
            SeriesDtos = new HashSet<SeriesDto>();
        }
    }
}
