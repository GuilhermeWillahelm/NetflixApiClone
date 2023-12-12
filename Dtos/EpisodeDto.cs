using NetflixApiClone.Models;

namespace NetflixApiClone.Dtos
{
    public class EpisodeDto
    {
        public int Id { get; set; }
        public int SeriesId { get; set; }
        public string? Title { get; set; }
        public int EpisodeNumber { get; set; }
        public string? ContentEpisode { get; set; }
        public virtual SeriesDto? SeriesDto { get; set; }
    }
}
