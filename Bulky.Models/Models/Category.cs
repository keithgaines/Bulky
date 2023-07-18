using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Range(1, 100, ErrorMessage = "Display Order must be between 1 and 100.")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }

    }
}
