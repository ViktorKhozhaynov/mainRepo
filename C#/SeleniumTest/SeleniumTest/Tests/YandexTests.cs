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
            logger.Info(config.GetValue("implicitTimeout"));
            logger.Info(config.GetValue("driverType"));
        }
    }
}
