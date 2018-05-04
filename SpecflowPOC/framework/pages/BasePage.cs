using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecflowPOC.framework.model;
using System;
using System.Collections.Generic;

using static SpecflowPOC.framework.config.Config;

namespace SpecflowPOC.framework.pages
{
    public abstract class BasePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public abstract List<Element> Elements();
        public abstract string PageUrl();

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            SetWebDriverWait();
        }

        public void SetWebDriverWait()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(webDriverWait));
        }

        public BasePage NavigateToPageUrl()
        {
            driver.Navigate().GoToUrl(baseUrl + PageUrl());
            return this;
        }

        //I've decided to make PageElements optional to remove some logic from the Page classes, but it would be possible to
        //have an overriden WaitForPage instead which would select some elements from the list to sync against
        //I would add some logging through these sections
        public BasePage WaitForPage()
        {
            foreach (Element element in Elements())
            {
                if (!element.optional)
                {
                    WaitFor(element);
                }
            }
            return this;
        }

        public BasePage WaitFor(Element element)
        {
            wait.Until(driver => Find(element));
            return this;
        }

        public IWebElement Find(Element element)
        {
            return driver.FindElement(element.Identifier);
        }
    }
}
