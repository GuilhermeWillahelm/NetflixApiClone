using NetflixApiClone.Models;

namespace NetflixApiClone.Dtos
{
    public class SeriesDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ThumbSeries { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }
        public virtual GenreDto? GenreDto { get; set; }
        public virtual ICollection<EpisodeDto>? EpisodeDtos { get; set; }
    }
}
