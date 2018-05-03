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
            //This line below seems to be unnecessary in this test
            //wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
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

        //I would look to split everything below into a separate find class possibly
        public BasePage WaitFor(Element element)
        {
            wait.Until(driver => Find(element));
            return this;
        }

        public IWebElement Find(Element element)
        {
            switch (element.IdentifierType)
            {
                case ElementIdentifierType.ClassName:
                    return driver.FindElement(By.ClassName(element.ClassName));

                case ElementIdentifierType.Name:
                    return driver.FindElement(By.Name(element.Name));

                case ElementIdentifierType.Id:
                    return driver.FindElement(By.Id(element.Id));

                case ElementIdentifierType.CssSelector:
                    return driver.FindElement(By.CssSelector(element.CssSelector));

                case ElementIdentifierType.XPath:
                    return driver.FindElement(By.XPath(element.XPath));

                default:
                    throw new ArgumentException("Element Identifier not recognised: " + element.IdentifierType);
            }
        }
    }
}
