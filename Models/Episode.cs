namespace NetflixApiClone.Models
{
    public class Episode
    {
        public int Id { get; set; }
        public int SeriesId { get; set; }
        public string? Title { get; set; }
        public int EpisodeNumber { get; set; }
        public string? ContentEpisode {  get; set; }
        public virtual Series? Series { get; set; }

    }
}
