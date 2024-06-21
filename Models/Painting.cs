using InstituteOfFineArts.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InstituteOfFineArts.Models
{
    public class Painting
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Artist { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [Required]
        public string Medium { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        // Foreign key to ApplicationUser
        [Required]
        public string StudentId { get; set; }

        [ForeignKey("StudentId")]
        public ApplicationUser Student { get; set; }

        // Picture file path
        [StringLength(255)]
        public string PicturePath { get; set; } = string.Empty;
    }
}
