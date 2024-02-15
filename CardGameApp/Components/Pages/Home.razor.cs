using CardGameApp.Entities;
using CardGameApp.Services;
using Microsoft.AspNetCore.Components;

namespace CardGameApp.Components.Pages
{
    public partial class Home
    {
        [Inject]
        protected ICardService CardService { get; set; }

        public List<Card> CardValues { get; set; } = [];
        public List<Card> Suits { get; set; } = [];

        public Card Card { get; set; } = new Card();
        public string Joker { get; set; } = "JK";

        public List<string> SelectedCardsList { get; set; } = [];

        public int? Score { get; set; } = null;

        public bool HasError { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;

        protected override void OnInitialized()
        {
            GetData();
            ClearAll();
        }

        private void GetData()
        {
            PopulateCardValueDropDownList();
            PopulateSuitDropDownList();
        }

        private void PopulateSuitDropDownList()
        {
            Suits =
            [
                new() { Code = "C", Description = "C - Clubs" },
                new() { Code = "D", Description = "D - Diamonds" },
                new() { Code = "H", Description = "H - Hearts" },
                new() { Code = "S", Description = "S - Spades" }
            ];
        }

        private void PopulateCardValueDropDownList()
        {
            CardValues =
            [
                new() { Code = "2", Description = "2" },
                new() { Code = "3", Description = "3" },
                new() { Code = "4", Description = "4" },
                new() { Code = "5", Description = "5" },
                new() { Code = "6", Description = "6" },
                new() { Code = "7", Description = "7" },
                new() { Code = "8", Description = "8" },
                new() { Code = "9", Description = "9" },
                new() { Code = "T", Description = "T - 10" },
                new() { Code = "J", Description = "J - Jack" },
                new() { Code = "Q", Description = "Q - Queen" },
                new() { Code = "K", Description = "K - King" },
                new() { Code = "A", Description = "A - Ace" }
            ];
        }

        public void OnValidSubmit()
        {
            AddToCardsList();
        }

        private void AddToCardsList()
        {
            if (Card != null)
            {
                SelectedCardsList.Add($"{Card.SelectedCardValue}{Card.SelectedSuit}");
            }
        }

        private void AddJoker()
        {
            SelectedCardsList.Add(Joker);
        }

        public void ClearDropDownSelections()
        {
            Card = new Card();
        }

        public void ClearAll()
        {
            SelectedCardsList.Clear();
            ClearDropDownSelections();
            ClearMessage();
            ClearScore();
        }

        public void ClearMessage()
        {
            HasError = false;
            ErrorMessage = string.Empty;
        }

        public void ClearScore()
        {
            Score = null;
        }

        public void GetScore()
        {
            var commaSeparatedCardsList = string.Join(",", SelectedCardsList);

            try
            {
                Score = CardService.GetScore(commaSeparatedCardsList);
            }
            catch (ArgumentException ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
