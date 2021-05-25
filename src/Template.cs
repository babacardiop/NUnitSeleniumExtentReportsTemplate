using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTestReportsTemplate
{
	[TestFixture]
	public class Template
	{
		public IWebDriver driver;
		static ExtentReports Extent;

		[SetUp]
		public void Initialize()
		{
			// Prerequisite: Follow the installation guide of Selenium by clicking here: https://www.selenium.dev/documentation/en/selenium_installation/
			driver = new ChromeDriver("C:\\WebDriver\\bin");
		}

		[OneTimeSetUp]
		public void ExtentStart()
		{
			Extent = new ExtentReports();
			var featureName = "Feature you want to test";
			var htmlreporter = new ExtentHtmlReporter(@$"C:\ReportResults\{featureName}\index.html");
			Extent.AttachReporter(htmlreporter);
		}

		[Test]
		public void Test()
		{
			var test = Extent.CreateTest("Enter test name")
				.Info("Test initialized");

			try
			{
				// Step 1 - Go to the test page
				test.Log(Status.Info, "Tring to go to the URL");
				driver.Navigate().GoToUrl("PLACE HERE THE URL");
				test.Log(Status.Info, "Go to URL Success");

				// Step 2 - Actions
				test.Log(Status.Info, "Start actions");

				// ENTER ALL ASSERTIONS AND ACTIONS
				test.Log(Status.Info, "Finish actions");

				//Step 3 - If we are here the test is considered as passed
				test.Log(Status.Pass, "Test Pass");
			}
			catch
			{
				test.Log(Status.Fail, "Test Fail");
				throw;
			}
		}

		[TearDown]
		public void CloseBrowser()
		{
			driver.Close();
		}

		[OneTimeTearDown]
		public void ExtentClose()
		{
			Extent.Flush();
		}
	}
}
