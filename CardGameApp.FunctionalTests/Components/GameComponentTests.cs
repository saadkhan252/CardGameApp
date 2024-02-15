using Bunit;
using CardGameApp.Components.Pages;
using CardGameApp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CardGameApp.FunctionalTests.Components
{
    [TestClass]
    public class GameComponentTests : Bunit.TestContext
    {
        [TestInitialize]
        public void Initialize()
        {
            Services.AddSingleton<ICardService>(new CardService());
        }

        [TestMethod]
        public void RenderGameComponent_SingleCard_AceOfClubs_ShouldRenderScoreOf14()
        {
            //render Game component
            var cut = RenderComponent<Game>();

            //select card value and suit from the drop down lists
            cut.Find("#ddl-values").Change("A");
            cut.Find("#ddl-suits").Change("C");

            //submit form
            cut.Find("form").Submit();

            //check cards list table
            var cardsTable = cut.Find("#tbl-cards");
            cardsTable.MarkupMatches(@"<table class=""table table-hover mt-4"" id=""tbl-cards"">
              <thead>
                <tr>
                  <th scope=""col"">Cards List</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>AC</td>
                </tr>
              </tbody>
            </table>");

            //click on the Score button to calculate and show score
            cut.Find("#btn-score").Click();

            //check score
            var result = cut.Find("#score");
            result.MarkupMatches(@"<div id=""score"" class=""mt-4"">
                <p style=""color:green"">Score: 14</p>
            </div>");
        }

        [TestMethod]
        public void RenderGameComponent_MultipleCards_ThreeOfClubsAndFourOfClubs_ShouldRenderScoreOf7()
        {
            //render Game component
            var cut = RenderComponent<Game>();

            //select card value and suit (3C) from the drop down lists
            cut.Find("#ddl-values").Change("3");
            cut.Find("#ddl-suits").Change("C");

            //submit form
            cut.Find("form").Submit();

            //check cards list table
            var cardsTable = cut.Find("#tbl-cards");
            cardsTable.MarkupMatches(@"<table class=""table table-hover mt-4"" id=""tbl-cards"">
              <thead>
                <tr>
                  <th scope=""col"">Cards List</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>3C</td>
                </tr>
              </tbody>
            </table>");

            //clear drop down selections
            cut.Find("#clear-ddl-selections").Click();

            //select another card value and suit (4C) from the drop down lists
            cut.Find("#ddl-values").Change("4");
            cut.Find("#ddl-suits").Change("C");

            //submit form
            cut.Find("form").Submit();

            //check updated cards list table
            var updatedCardsTable = cut.Find("#tbl-cards");
            updatedCardsTable.MarkupMatches(@"<table class=""table table-hover mt-4"" id=""tbl-cards"">
              <thead>
                <tr>
                  <th scope=""col"">Cards List</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>3C</td>
                </tr>
                <tr>
                  <td>4C</td>
                </tr>
              </tbody>
            </table>");

            //click on the Score button to calculate and show score
            cut.Find("#btn-score").Click();

            //check score
            var result = cut.Find("#score");
            result.MarkupMatches(@"<div id=""score"" class=""mt-4"">
                <p style=""color:green"">Score: 7</p>
            </div>");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Cards cannot be duplicated")]
        public void RenderGameComponent_DuplicateCards_ShouldRenderCardsCannotBeDuplicated()
        {
            //render Game component
            var cut = RenderComponent<Game>();

            //select card value and suit (2S) from the drop down lists
            cut.Find("#ddl-values").Change("2");
            cut.Find("#ddl-suits").Change("S");

            //submit form
            cut.Find("form").Submit();

            //check cards list table
            var cardsTable = cut.Find("#tbl-cards");
            cardsTable.MarkupMatches(@"<table class=""table table-hover mt-4"" id=""tbl-cards"">
              <thead>
                <tr>
                  <th scope=""col"">Cards List</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>2S</td>
                </tr>
              </tbody>
            </table>");

            //submit form again to add another 2S to the table
            cut.Find("form").Submit();

            //check updated cards list table
            var updatedCardsTable = cut.Find("#tbl-cards");
            updatedCardsTable.MarkupMatches(@"<table class=""table table-hover mt-4"" id=""tbl-cards"">
              <thead>
                <tr>
                  <th scope=""col"">Cards List</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>2S</td>
                </tr>
                <tr>
                  <td>2S</td>
                </tr>
              </tbody>
            </table>");

            //click on the Score button
            cut.Find("#btn-score").Click();
        }
    }
}