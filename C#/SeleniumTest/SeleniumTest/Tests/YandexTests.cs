using NUnit.Framework;
using SeleniumTest.Core;
using SeleniumTest.PageObject;
using System.Linq;

namespace SeleniumTest.Tests
{
    [TestFixture]
    public class YandexTests : TestBase
    {
        private MainPage MainPage;

        protected override void Initialize()
        {
            base.Initialize();
            MainPage = OpenMainPage();
        }

        [Test]
        [Category("Smoke")]
        public void SmokeTest()
        {   
            TestCase("Smoke test for the main page of yandex taxi portal", () =>
            {
                var OrderSection = MainPage.MainOverlay.OrderSection;
                string firstSampleAddress = string.Empty;

                TestStep("1. Validate samples count and select on of them", () =>
                {
                    waitUntil(() => OrderSection.FromInputBlock.InputSamples.Elements[0].IsDisplayed);

                    firstSampleAddress = OrderSection.FromInputBlock.InputSamples.Elements[0].Text;
                    OrderSection.FromInputBlock.InputSamples.CLickElementByIndex(0);

                    Assert.Multiple(() =>
                    {
                        Assert.AreEqual(2, OrderSection.FromInputBlock.InputSamples.Elements.Count, "The two input samples haven't been found!");
                        Assert.AreEqual(firstSampleAddress, OrderSection.FromInputBlock.Input.Text, "'From' input text hasn't been changed!");
                    });
                });

                TestStep("2. Click on swap button and validate that it swaps 'From' and 'To' inputs' values", () =>
                {
                    OrderSection.SwapButton.Click();
                    waitUntil(() => OrderSection.FromInputBlock.Input.Text.Equals(string.Empty));

                    Assert.AreEqual(firstSampleAddress, OrderSection.ToInputBlock.Input.Text, "Swap button hasn't changed 'To' input text");
                });

                TestStep("3. Repeat 1. step", () =>
                {
                    OrderSection.SelectSample(index: 0);
                    Assert.AreEqual(firstSampleAddress, OrderSection.FromInputBlock.Input.Text, "'From' input text hasn't been changed!");
                });

                TestStep("4. Select custom Rate from the dropdown", () =>
                {
                    OrderSection.ClickRatesButton();
                    var customOptionText = OrderSection.RatesOptions.ElementsText[2];
                    var cost = OrderSection.GetRateOptionCost(2);
                    OrderSection.SelectRate(2);

                    Assert.Multiple(() =>
                    {
                        Assert.AreEqual(customOptionText, OrderSection.RatesSelectButton.Text);
                        Assert.AreEqual($"Стоимость поездки — {cost} Р", OrderSection.PreliminaryCost.Text);
                    });
                });

                TestStep("5. Validate that by changing Rate option Final Cost changes accordingly", () =>
                {
                    OrderSection.ClickRatesButton();

                    var cost = OrderSection.GetRateOptionCost(4);
                    OrderSection.SelectRate(4);

                    Assert.AreEqual($"Стоимость поездки — {cost} Р", OrderSection.PreliminaryCost.Text);
                });
            });
        }
    }
}
