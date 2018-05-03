using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SpecflowPOC.framework.model
{
    public abstract class BrowserTest
    {
        //In order for this not to be static https://github.com/techtalk/SpecFlow/issues/706
        //I have had to use BeforeScenario rather than BeforeTest - which also seems to have issues being called in the superclass
        protected IWebDriver driver;

        [BeforeScenario(Order = 1)]
        protected void InitialiseWebdriver()
        {
            //Extend for potentially a config driven choice of browser
            driver = new ChromeDriver();
            //Iteration++;
        }

        [AfterScenario]
        public void CloseBrowser()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
