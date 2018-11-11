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
        public void UC1_SamplesTest()
        {
            TestCase("UC1 Validate click on sample affects appropriate address input", () =>
            {
                var OrderSection = MainPage.MainOverlay.OrderSection;
                string sampleAddress = string.Empty;

                TestStep("Click on one of the samples below the From address input", () =>
                {
                    waitUntil(x => OrderSection.FromInputBlock.InputSamples.Elements[0].IsDisplayed);

                    sampleAddress = OrderSection.FromInputBlock.InputSamples.Elements[0].Text;
                    OrderSection.FromInputBlock.InputSamples.CLickElementByIndex(0);

                    Assert.Multiple(() =>
                    {
                        Assert.AreEqual(2, OrderSection.FromInputBlock.InputSamples.Elements.Count, "The two input samples haven't been found!");
                        Assert.AreEqual(sampleAddress, OrderSection.FromInputBlock.Input.Text, "'From' input text hasn't been changed!");
                    });
                });

                TestStep("Click on one of the samples below the To address input", () =>
                {
                    waitUntil(x => OrderSection.ToInputBlock.InputSamples.Elements[0].IsDisplayed);

                    sampleAddress = OrderSection.ToInputBlock.InputSamples.Elements[0].Text;
                    OrderSection.ToInputBlock.InputSamples.CLickElementByIndex(0);

                    Assert.Multiple(() =>
                    {
                        Assert.AreEqual(2, OrderSection.ToInputBlock.InputSamples.Elements.Count, "The two input samples haven't been found!");
                        Assert.AreEqual(sampleAddress, OrderSection.ToInputBlock.Input.Text, "'From' input text hasn't been changed!");
                    });
                });
            });
        }
               
        [Test]
        [Category("Smoke")]
        public void UC2_SwapOneAddressOnlyTest()
        {
            TestCase("UC2 Validate swap works when one address input filled in only", () =>
            {
                var OrderSection = MainPage.MainOverlay.OrderSection;
                string sampleAddress = string.Empty;

                TestStep("Click on one of the samples below the From address input", () =>
                {
                    sampleAddress = OrderSection.FromInputBlock.SelectSample(SampleType.Left);
                    Assert.AreEqual(sampleAddress, OrderSection.FromInputBlock.Input.Text, "'From' input text hasn't been changed!");
                });

                TestStep("Click on swap button and validate that it swaps 'From' and 'To' inputs' values", () =>
                {
                    OrderSection.SwapButton.Click();

                    Assert.Multiple(() =>
                    {
                        Assert.AreEqual(string.Empty, OrderSection.FromInputBlock.Input.Text, "Swap button hasn't changed 'From' input value");
                        Assert.AreEqual(sampleAddress, OrderSection.ToInputBlock.Input.Text, "Swap button hasn't changed 'To' input value");
                    });
                });
            });
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
                    waitUntil(x => OrderSection.FromInputBlock.InputSamples.Elements[0].IsDisplayed);

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
                    waitUntil(x => OrderSection.FromInputBlock.Input.Text.Equals(string.Empty));

                    Assert.AreEqual(firstSampleAddress, OrderSection.ToInputBlock.Input.Text, "Swap button hasn't changed 'To' input text");
                });

                TestStep("3. Repeat 1. step", () =>
                {
                    OrderSection.FromInputBlock.SelectSample(SampleType.Left);
                    Assert.AreEqual(firstSampleAddress, OrderSection.FromInputBlock.Input.Text, "'From' input text hasn't been changed!");
                });

                TestStep("4. Select custom Rate from the dropdown", () =>
                {
                    OrderSection.ClickRatesButton();
                    var customOptionText = OrderSection.RatesOption(2).Text;
                    var cost = OrderSection.GetRateOptionCost(customOptionText);
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

                    var customOptionText = OrderSection.RatesOption(4).Text;
                    var cost = OrderSection.GetRateOptionCost(customOptionText);
                    OrderSection.SelectRate(4);

                    Assert.AreEqual($"Стоимость поездки — {cost} Р", OrderSection.PreliminaryCost.Text);
                });
            });
        }
    }
}
