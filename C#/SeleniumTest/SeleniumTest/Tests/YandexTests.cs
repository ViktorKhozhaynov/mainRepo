﻿using NUnit.Framework;
using SeleniumTest.Core;
using SeleniumTest.PageObject;

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
                TestStep("Open the main page and wait until it loads", () =>
                {

                });
            });
        }
    }
}
