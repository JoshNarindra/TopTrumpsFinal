using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TopTrumpsFinal.Models
{
    public class StarWarsDeck : Deck
    {
        [Key]
        public int StarWarsDeckID { get; set; }

        [Required]
        [Display(Name = "Size")]
        [DataType(DataType.Text)]
        public int Size { get; set; }

        [Required]
        [Display(Name = "Speed")]
        [DataType(DataType.Text)]
        public int Speed { get; set; }

        [Required]
        [Display(Name = "Fire Power")]
        [DataType(DataType.Text)]
        public int FirePower { get; set; }

        [Required]
        [Display(Name = "Maneuvering")]
        [DataType(DataType.Text)]
        public int Maneuvering { get; set; }

        [Required]
        [Display(Name = "Force Factor")]
        [DataType(DataType.Text)]
        public int ForceFactor { get; set; }
    }
}
