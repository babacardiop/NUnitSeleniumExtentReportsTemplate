using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SeleniumPreTest
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("test case started ");
			//create the reference for the browser  
			IWebDriver driver = new ChromeDriver("C:\\WebDriver\\bin");

			//IWebDriver driver = new FirefoxDriver("C:\\WebDriver\\bin");
			// navigate to URL  
			//driver.Navigate().GoToUrl("https://www.google.com/");
			driver.Navigate().GoToUrl("https://www.testandquiz.com/selenium/testing.html");
			var jsExecutor = (IJavaScriptExecutor)driver;
			
			// identify the Google search text box  
			var element = driver.FindElement(By.Id("testingDropdown"));
			var select = new SelectElement(element);
			select.SelectByIndex(2);
			var act = new Actions(driver);
			//act.DragAndDropToOffset(from,to.Location.X, to.Location.Y).Build().Perform();
			//enter the value in the google search text box  
			//ele.SendKeys("javatpoint tutorials");
			//Thread.Sleep(2000);
			////identify the google search button  
			IWebElement ele1 = driver.FindElement(By.Name("btnK"));
			//ele1.Click();

			var sShot = ((ITakesScreenshot)driver).GetScreenshot();
			sShot.SaveAsFile("C:\\tmp\\1.png", ScreenshotImageFormat.Png);

			System.Drawing.Image img = System.Drawing.Image.FromFile("C:\\tmp\\1.png");
			Rectangle rect = new Rectangle();

			if (ele1 != null)
			{
				// Get the Width and Height of the WebElement using
				int width = ele1.Size.Width;
				int height = ele1.Size.Height;

				// Get the Location of WebElement in a Point.
				// This will provide X & Y co-ordinates of the WebElement
				Point p = ele1.Location;

				// Create a rectangle using Width, Height and element location
				rect = new Rectangle(p.X, p.Y, width, height);
			}

			Bitmap bmpImage = new Bitmap(img);
			var cropedImag = bmpImage.Clone(rect, bmpImage.PixelFormat);
			cropedImag.Save("C:\\tmp\\2.png");
			//var jsExecutor = (IJavaScriptExecutor)driver;

			long currentHeight;
			var totalHeight = (Int64)jsExecutor.ExecuteScript("return document.body.scrollHeight;");
			//IWebElement ele2 = driver.FindElement(By.("btnK"));
			// click on the Google search button
			do
			{
				jsExecutor.ExecuteScript("scrollBy(0, 400)");
				Thread.Sleep(1000);
				currentHeight = (long)jsExecutor.ExecuteScript("return window.pageYOffset;");
			}
			while (currentHeight < totalHeight);

			Thread.Sleep(3000);
			//close the browser  
			driver.Close();
			Console.Write("test case ended ");
		}
	}
}