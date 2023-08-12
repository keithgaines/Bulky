using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bulky.Models
{
    public class ProductImage
    {

        public int Id { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public int Id { get; set; }
        [ForeignKey("Id")]
        public Product Product { get; set; }
    }
}