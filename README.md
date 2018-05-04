# specflow-poc
# Dependencies
You must install nuget packages in visual studio:
SpecRun.SpecFlow 2.3.0
	Which includes:
	SpecFlow v2.3.2
	SpecRun.Runner v1.7.1
	SpecRun.SpecFlow.2-3-0 v1.7.1
	
Selenium Support v3.11.2
Selenium Webdriver v3.11.2
Selenium Webdriver ChromeDriver v2.38.0.1
NUnit v3.10.1

This includes automatically:
NewtonSoft.Json v11.0.2
System.ValueTuple v4.4.0

These versions may or may not be necessary, I have updated to the specified from the versions originally present.


# Running
Once the packages are all installed, it should be as simple as Ctrl+R, A.	

# Platform limitations
C#, like java doesn't support abstract static - in my thinking this is a thing, although there is a lot of argument.
Specflow forces static implementations of BeforeTest and AfterTest which I try and avoid, there is an issue open at https://github.com/techtalk/SpecFlow/issues/706 for this. This has forced me to do some odd things around [BeforeScenario(Order = 1)] in the BrowserTest class and the inherited classes.
C# doesn't have assertions built in.
There is some bizare behaviour in visual studio around handled exceptions which can cause problem when debugging the wait function.
There are a lot of errors being thrown during debug from parts of the system, largely by specflow.


# Highlights

BasePage class - WaitForPage
I've decided to make Elements optional to remove some logic from the Page classes, but it would be possible to have an overriden WaitForPage instead which would select some elements from the list to sync against. This is a groovy geb pattern really.
I would add some logging through the find sections, or potentially extend the webdriver calls and log there. I'm used to an environment where we must record all browser or api interactions.

ContactUsPage 
I've decided to call the elements as required rather than identify them all and return them up front.
Would prefer to add a specific class attribute or data-item-id to any element which doesn't have a unique identifer rather than use xpath

Element
I've built an element class as a container for element data. I would probably start adding attributes to test into here, and then iterate through them all rather than write separate assertions. It is fairly empty at this point.

ContactUsPageSteps
I've repeated the odd call here between the invalid and valid entry, where I would have to change the feature steps to something like 'I can enter the Contact us form data' to make this make more sense.



# Improvements

I could use Selenium's inbuilt PageFactory, I think it could make the code slightly cleaner. I don't think it would reduce the need for an element class for verification though, and once you use that it makes sense to put things in one place.

I could probably write something that allowed elements to be used as element.click, rather than Find(element).click.

I could build something around SendKeys to handle exiting the text field and similar events that might be necessary in other scenarios.

I've used a static class to hold some config data - I would likely read this in from an environment file instead of hardcoding.

I've used the SpecFlow Runner, which is an evaluation version with a delay built in, but does give some nice reports. There is only a paid version of this. I suspect I would build custom reporting anyway, and use a different runner.

I haven't been able to make the tables functionality operate as a where level item, as in spock, where you iterate over each row. I haven't found anything that suggests people do this either, which is strange. There must be a way to do this in Specflow, that would greatly extend the valid and invalid scenario coverage without adding any code.
