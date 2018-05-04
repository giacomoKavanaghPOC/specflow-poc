using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowPOC.framework.data;
using SpecflowPOC.framework.model;
using System.Collections.Generic;

namespace SpecflowPOC.framework.pages
{
    class ContactUsPage : BasePage
    {
        public ContactUsPage(IWebDriver driver) : base(driver) { }

        public override string PageUrl()
        {
            return "contact-us/";
        }

        //I've decided to call the elements as required rather than identify them all and return them
        //Would prefer to add a specific class attribute or data-item-id to any element required but can use xpath
        public static Element Title = new Element(By.XPath(@"//div[@class='fusion-text']//span[contains(text(),'CONTACT US')]"));
        //Added in because it's large and took a while to load, because of some throttling problem on my pc
        public static Element HeaderImage = new Element(By.ClassName("background-image"));
        public static Element YourName = new Element(By.Name("your-name"));
        public static Element YourEmail = new Element(By.Name("your-email"));
        public static Element YourCompany = new Element(By.Name("your-company"));
        public static Element YourMessage = new Element(By.Name("your-message"));
        public static Element Send = new Element(By.Id("contact-us-send"));
        public static Element Alert = new Element(By.CssSelector(".fusion-alert")).IsOptional();
        public static Element InputError = new Element(By.XPath(@"//span[contains(@role, 'alert')]")).IsOptional();

        //This should be abstract static but c# doesn't support it
        public override List<Element> Elements()
        {
            return new List<Element> {
                Title,
                HeaderImage,
                YourName,
                YourEmail,
                YourCompany,
                YourMessage,
                Send,
                Alert,
                InputError
                };
        }

        public ContactUsPage EnterContactDetails(ContactUsFormModel contactUsFormModel)
        {
            Find(YourName).SendKeys(contactUsFormModel.Name);
            Find(YourEmail).SendKeys(contactUsFormModel.Email);
            //This looks odd, but it does describe what the page and data are doing and how the names differ
            Find(YourCompany).SendKeys(contactUsFormModel.Subject);
            Find(YourMessage).SendKeys(contactUsFormModel.Message);
            return this;
        }

        public ContactUsPage ClickSend()
        {
            Find(Send).Click();
            WaitForPage();
            return this;
        }

        public ContactUsPage WaitForAlert()
        {
            WaitFor(Alert);
            return this;
        }

        public ContactUsPage CheckInputError(string inputError)
        {
            WaitFor(InputError);
            Assert.AreEqual(Find(InputError).Text, inputError);
            return this;
        }
    } 
}
