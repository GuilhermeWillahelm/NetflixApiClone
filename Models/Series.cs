namespace NetflixApiClone.Models
{
    public class Series
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ThumbSeries { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }
        public virtual ICollection<Episode>? Episodes { get; set; }
        
    }
}
