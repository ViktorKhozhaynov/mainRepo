using NUnit.Framework;
using SeleniumTest.Core;

namespace SeleniumTest.Tests
{
    [TestFixture]
    public class YandexTests : TestBase
    {
        [Test]
        [Category("Smoke")]
        public void SmokeTest()
        {
            TestCase("Smoke test for the main page of yandex taxi portal", () =>
            {
                TestStep("Open the main page and wait until it loads", () =>
                {
                    logger.Info(config.GetValue("implicitTimeout"));
                    logger.Info(config.GetValue("driverType"));
                });
            });
        }
    }
}
