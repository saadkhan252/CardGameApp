using System.ComponentModel.DataAnnotations;

namespace CardGameApp.Entities
{
    /// <summary>
    /// Used for populating drop down lists and capturing selected values
    /// </summary>
    public class Card
    {
        public string Code { get; set; }
        public string Description { get; set; }

        [Display(Name = "Card Value")]
        [Required]
        public string SelectedCardValue { get; set; }

        [Display(Name = "Suit")]
        [Required]
        public string SelectedSuit { get; set; }
    }

    public enum NamedValue
    {
        T = 10,
        J = 11,
        Q = 12,
        K = 13,
        A = 14
    }

    public enum Suit
    {
        C = 1,
        D = 2,
        H = 3,
        S = 4
    }
}