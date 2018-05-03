using SpecflowPOC.framework.data;
using SpecflowPOC.framework.model;
using SpecflowPOC.framework.pages;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowPOC.features
{
    [Binding]
    public class ContactUsPageSteps : BrowserTest
    {
        private ContactUsPage contactUsPage;

        [BeforeScenario(Order = 2)]
        public void InitialiseContactUsPage()
        {
            contactUsPage = new ContactUsPage(driver);
        }

        [Given(@"I am on the QAWorks Site")]
        public void GivenIAmOnTheQAWorksSite()
        {
            contactUsPage.NavigateToPageUrl()
                .WaitForPage();
        }

        [Then(@"I should be able to contact QAWorks with the following information")]
        public void ThenIShouldBeAbleToContactQAWorksWithTheFollowingInformation(Table contactUsTable)
        {
            var contactUsData = contactUsTable.CreateSet<ContactUsFormModel>().ToList()[0];

            contactUsPage.EnterContactDetails(contactUsData)
                .ClickSend()
                .WaitForAlert();
        }
    }
}
