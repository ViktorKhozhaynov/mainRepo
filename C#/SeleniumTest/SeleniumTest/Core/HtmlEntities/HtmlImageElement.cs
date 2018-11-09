﻿using System;
using OpenQA.Selenium;

namespace SeleniumTest.Core.HtmlEntities
{
    public class HtmlImageElement : HtmlElement
    {
        public HtmlImageElement(IWebDriver webDriver, By by) : base(webDriver, by)
        {
        }

        public HtmlImageElement(IWebElement webElement, By by) : base(webElement, by)
        {
        }

        public string Src
        {
            get
            {
                try
                {
                    using (new CustomImplicitTimeout(WebDriver, QUICK_SEARCH_TIMEOUT))
                    {
                        return WebElement.GetAttribute("src");
                    }
                }
                catch (Exception ex)
                {
                    log.Warn($"An error has occurred while getting src attribute of an IMG element! Message: {ex.Message}");
                }
                return "";
            }
        }

        #region methods

        //TODO: rewrite to C#
        //public Optional<BufferedImage> TryGetImage()
        //{
        //    try
        //    {
        //        String logoSRC = Src().orElseThrow(()-> new Exception("No Src attribute has been found in the element '" + InternalId() + "'!"));

        //        URL imageURL = new URL(logoSRC);
        //        return Optional.of(ImageIO.read(imageURL));
        //    }
        //    catch (Exception ex)
        //    {
        //        log.warn("An error has occurred while downloading the image! Message: %s", ex.getMessage());
        //    }
        //    return Optional.empty();
        //}
        #endregion
    }
}