using CardGameApp.Entities;
using System.Text.RegularExpressions;

namespace CardGameApp.Services
{
    public class CardService : ICardService
    {
        public int GetScore(string cards)
        {
            var totalScore = 0;
            var joker = "JK";
            var countOfJokers = 0;

            var cardsList = ConvertStringToList(cards);
            WarnIfCardsAreDuplicated(joker, cardsList);

            foreach (var card in cardsList)
            {
                if (card != joker)
                {
                    totalScore = CalculateScore(totalScore, card);
                }
                else
                {
                    CountJokers(ref countOfJokers);
                }
            }

            if (countOfJokers > 0)
            {
                DoubleScore(ref totalScore, countOfJokers);
            }

            return totalScore;
        }

        private List<string> ConvertStringToList(string commaSeparatedList)
        {
            var isValid = ValidateCommaSeparatedList(commaSeparatedList);
            if (isValid)
            {
                return commaSeparatedList.Split(',').ToList();
            }

            throw new ArgumentException("Invalid input string");
        }

        private bool ValidateCommaSeparatedList(string cards)
        {
            var pattern = @"^\s*(\w+\s*,\s*)*\w+\s*$";

            return Regex.IsMatch(cards, pattern);
        }

        private void WarnIfCardsAreDuplicated(string joker, List<string> cardsList)
        {
            var duplicateCards = GetDuplicateCards(cardsList);
            if (duplicateCards.Count > 0 && !duplicateCards.Contains(joker))
            {
                throw new InvalidOperationException("Cards cannot be duplicated");
            }
        }

        private List<string> GetDuplicateCards(List<string> cardsList)
        {
            var duplicateCards = cardsList
                            .GroupBy(x => x)
                            .Where(group => group.Count() > 1)
                            .Select(group => group.Key).ToList();

            return duplicateCards;
        }

        private int CalculateScore(int totalScore, string card)
        {
            var cardValue = GetCardValue(card[0].ToString());
            var suitMultiplier = GetSuitMultiplyValue(card[1].ToString());
            var score = cardValue * suitMultiplier;
            totalScore += score;
            return totalScore;
        }

        private int GetCardValue(string card)
        {
            if (int.TryParse(card, out int cardValue))
            {
                if (cardValue == 1 || cardValue > 14)
                {
                    throw new ArgumentException("Card not recognised");
                }

                return cardValue;
            }

            if (Enum.TryParse(card, out NamedValue namedValue))
            {
                return (int)namedValue;
            }

            throw new ArgumentException("Card not recognised");
        }

        private int GetSuitMultiplyValue(string card)
        {
            if (Enum.TryParse(card, out Suit suit))
            {
                return (int)suit;
            }

            throw new ArgumentException("Card not recognised");
        }

        private void CountJokers(ref int countOfJokers)
        {
            countOfJokers++;

            if (countOfJokers > 2)
            {
                throw new InvalidOperationException("A hand cannot contain more than two Jokers");
            }
        }

        private void DoubleScore(ref int totalScore, int countOfJokers)
        {
            var index = 1;

            while (index <=  countOfJokers)
            {
                totalScore *= 2;
                index++;
            }
        }
    }
}