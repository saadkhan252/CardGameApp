using CardGameApp.Services;

namespace CardGameApp.Test
{
    [TestClass]
    public class CardGameTests
    {
        private ICardService _cardService;

        [TestInitialize]
        public void Initialize()
        {
            _cardService = new CardService();
        }

        [TestMethod]
        public void GetScore_TwoOfClubs_ScoreShouldBe2()
        {
            var expectedScore = 2;

            var card = "2C";
            var actualScore = _cardService.GetScore(card);

            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void GetScore_TwoOfDiamonds_ScoreShouldBe4()
        {
            var expectedScore = 4;

            var card = "2D";
            var actualScore = _cardService.GetScore(card);

            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void GetScore_TwoOfHearts_ScoreShouldBe6()
        {
            var expectedScore = 6;

            var card = "2H";
            var actualScore = _cardService.GetScore(card);

            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void GetScore_TwoOfSpades_ScoreShouldBe8()
        {
            var expectedScore = 8;

            var card = "2S";
            var actualScore = _cardService.GetScore(card);

            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void GetScore_TenOfClubs_ScoreShouldBe10()
        {
            var expectedScore = 10;

            var card = "TC";
            var actualScore = _cardService.GetScore(card);

            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void GetScore_JackOfClubs_ScoreShouldBe11()
        {
            var expectedScore = 11;

            var card = "JC";
            var actualScore = _cardService.GetScore(card);

            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void GetScore_QueenOfClubs_ScoreShouldBe12()
        {
            var expectedScore = 12;

            var card = "QC";
            var actualScore = _cardService.GetScore(card);

            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void GetScore_KingOfClubs_ScoreShouldBe13()
        {
            var expectedScore = 13;

            var card = "KC";
            var actualScore = _cardService.GetScore(card);

            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void GetScore_AceOfClubs_ScoreShouldBe14()
        {
            var expectedScore = 14;

            var card = "AC";
            var actualScore = _cardService.GetScore(card);

            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void GetScore_ThreeOfClubsAndFourOfClubs_ScoreShouldBe7()
        {
            var expectedScore = 7;

            var listOfCards = new List<string>() { "3C", "4C" };
            var commaSeparatedList = string.Join(",", listOfCards);
            var actualScore = _cardService.GetScore(commaSeparatedList);

            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void GetScore_TenOfClubsDiamondsHeartsAndSpades_ScoreShouldBe100()
        {
            var expectedScore = 100;

            var listOfCards = new List<string>() { "TC", "TD", "TH", "TS" };
            var commaSeparatedList = string.Join(",", listOfCards);
            var actualScore = _cardService.GetScore(commaSeparatedList);

            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void GetScore_SingleCardWithJoker_ScoreShouldBe0()
        {
            var expectedScore = 0;

            var card = "JK";
            var actualScore = _cardService.GetScore(card);

            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void GetScore_TwoCardsBothJokers_ScoreShouldBe0()
        {
            var expectedScore = 0;

            var listOfCards = new List<string>() { "JK", "JK" };
            var commaSeparatedList = string.Join(",", listOfCards);
            var actualScore = _cardService.GetScore(commaSeparatedList);

            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void GetScore_TwoOfClubsAndJoker_ScoreShouldBe4()
        {
            var expectedScore = 4;

            var listOfCards = new List<string>() { "2C", "JK" };
            var commaSeparatedList = string.Join(",", listOfCards);
            var actualScore = _cardService.GetScore(commaSeparatedList);

            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void GetScore_JokerTwoOfClubsAndJoker_ScoreShouldBe8()
        {
            var expectedScore = 8;

            var listOfCards = new List<string>() { "JK", "2C", "JK" };
            var commaSeparatedList = string.Join(",", listOfCards);
            var actualScore = _cardService.GetScore(commaSeparatedList);

            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void GetScore_TenOfClubsTenOfDiamondsJokerTenOfHeartsAndTenOfSpades_ScoreShouldBe200()
        {
            var expectedScore = 200;

            var listOfCards = new List<string>() { "TC", "TD", "JK", "TH", "TS" };
            var commaSeparatedList = string.Join(",", listOfCards);
            var actualScore = _cardService.GetScore(commaSeparatedList);

            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void GetScore_TenOfClubsTenOfDiamondsJokerTenOfHeartsAndTenOfSpades_ScoreShouldBe400()
        {
            var expectedScore = 400;

            var listOfCards = new List<string>() { "TC", "TD", "JK", "TH", "TS", "JK" };
            var commaSeparatedList = string.Join(",", listOfCards);
            var actualScore = _cardService.GetScore(commaSeparatedList);

            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Card not recognised")]
        public void GetScore_InvalidOneOfSpadesCard_ShouldThrowException()
        {
            var card = "1S";
            _cardService.GetScore(card);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Card not recognised")]
        public void GetScore_InvalidCard2B_ShouldThrowException()
        {
            var card = "2B";
            _cardService.GetScore(card);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Card not recognised")]
        public void GetScore_InvalidCards2SAnd1S_ShouldThrowException()
        {
            var listOfCards = new List<string>() { "2S", "1S" };
            var commaSeparatedList = string.Join(",", listOfCards);
            _cardService.GetScore(commaSeparatedList);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Cards cannot be duplicated")]
        public void GetScore_DuplicateCards_ShouldThrowException()
        {
            var listOfCards = new List<string>() { "3H", "3H" };
            var commaSeparatedList = string.Join(",", listOfCards);
            _cardService.GetScore(commaSeparatedList);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Cards cannot be duplicated")]
        public void GetScore_DuplicateCards_FourOfDiamondsFiveOfDiamondsFourOfDiamonds_ShouldThrowException()
        {
            var listOfCards = new List<string>() { "4D", "5D", "4D" };
            var commaSeparatedList = string.Join(",", listOfCards);
            _cardService.GetScore(commaSeparatedList);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "A hand cannot contain more than two Jokers")]
        public void GetScore_MoreThanTwoJokers_ShouldThrowException()
        {
            var listOfCards = new List<string>() { "JK", "JK", "JK" };
            var commaSeparatedList = string.Join(",", listOfCards);
            _cardService.GetScore(commaSeparatedList);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid input string")]
        public void GetScore_InvalidInputString_ShouldThrowException()
        {
            var cards = "2S|3D";
            _cardService.GetScore(cards);
        }
    }
}