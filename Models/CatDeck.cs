using System.ComponentModel.DataAnnotations;

namespace TopTrumpsFinal.Models
{
    public class CatDeck : Deck
    {
        [Key]
        public int CatDeckID { get; set; }

        [Required]
        [Display(Name = "Size")]
        [DataType(DataType.Text)]
        public int Size { get; set; }

        [Required]
        [Display(Name = "Rarity")]
        [DataType(DataType.Text)]
        public int Rarity { get; set; }

        [Required]
        [Display(Name = "Good Temper")]
        [DataType(DataType.Text)]
        public int GoodTemper { get; set; }

        [Required]
        [Display(Name = "Cuteness")]
        [DataType(DataType.Text)]
        public int Cuteness { get; set; }

        [Required]
        [Display(Name = "Rating")]
        [DataType(DataType.Text)]
        public int Rating { get; set; }
    }
}
