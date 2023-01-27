using System.ComponentModel.DataAnnotations;

namespace TopTrumpsFinal.Models
{
    public class DinoDeck : Deck
    {
        [Key]
        public int DinoDeckID { get; set; }

        [Required]
        [Display(Name = "Height (ft)")]
        [DataType(DataType.Text)]
        public double Height { get; set; }

        [Required]
        [Display(Name = "Weight (lbs)")]
        [DataType(DataType.Text)]
        public double Weight { get; set; }

        [Required]
        [Display(Name = "Length (ft)")]
        [DataType(DataType.Text)]
        public double GoodTemper { get; set; }

        [Required]
        [Display(Name = "Killer Rating")]
        [DataType(DataType.Text)]
        public int KillerRating { get; set; }

        [Required]
        [Display(Name = "Intelligence")]
        [DataType(DataType.Text)]
        public int Rating { get; set; }
    }
}