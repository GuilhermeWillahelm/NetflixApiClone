using NetflixApiClone.Models;

namespace NetflixApiClone.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Director { get; set; }
        public string? ContentMovie { get; set; }
        public string? ThumbMovie { get; set; }
        public double Rating { get; set; }
    }
}
