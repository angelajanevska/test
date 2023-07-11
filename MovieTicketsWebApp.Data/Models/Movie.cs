using System.ComponentModel.DataAnnotations;

namespace MovieTicketsWebApp.Domain.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
