using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InstituteOfFineArts.Models
{
    public class Painting
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        // Foreign key property
        //[Required]
        public int StudentId { get; set; }

        // Navigation property
        public Student Student { get; set; }
    }
}
