using OpenQA.Selenium;
using SpecflowPOC.framework.data;
using SpecflowPOC.framework.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowPOC.framework.pages
{
    class ContactUsPage : BasePage
    {
        public ContactUsPage(IWebDriver driver) : base(driver) { }

        public override string PageUrl()
        {
            return "contact-us/";
        }

        //Would prefer to add a specific class attribute or data-item-id to any element required but can use xpath
        public static Element Title = new Element(ElementIdentifierType.XPath, @"//div[@class='fusion-text']//span[contains(text(),'CONTACT US')]");

        //Added in because it's large and took a while to load, because of some throttling problem on my pc
        public static Element HeaderImage = new Element(ElementIdentifierType.ClassName, "background-image");

        public static Element YourName = new Element(ElementIdentifierType.Name, "your-name");
        public static Element YourEmail = new Element(ElementIdentifierType.Name, "your-email");
        public static Element YourCompany = new Element(ElementIdentifierType.Name, "your-company");
        public static Element YourMessage = new Element(ElementIdentifierType.Name, "your-message");
        public static Element Send = new Element(ElementIdentifierType.Id, "contact-us-send");
        public static Element Alert = new Element(ElementIdentifierType.CssSelector, ".fusion-alert").IsOptional();

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
                Alert
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
    }
}
