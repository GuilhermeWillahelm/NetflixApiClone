namespace NetflixApiClone.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Director { get; set; }
        public string? ContentMovie { get; set; }
        public string? ThumbMovie { get; set; }
        public double Rating { get; set; }
        public virtual Genre? Genre { get; set; }
    }
}
