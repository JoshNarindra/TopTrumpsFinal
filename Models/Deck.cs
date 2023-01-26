using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TopTrumpsFinal.Models
{
    public class Deck
    {
        [Required]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "ImageLink")]
        [DataType(DataType.Text)]
        public string? ImageLink { get; set; }

        [Required]
        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        public string? Description { get; set; }
    }
}
