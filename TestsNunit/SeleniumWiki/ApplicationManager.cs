using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWiki
{
    public class ApplicationManager
    {
        private static IWebDriver driver;
        private static ApplicationManager appManager=null;

        private MainPage mainPage;

        public static ApplicationManager GetInstance()
        {
            if (appManager == null)
            {
                appManager = new ApplicationManager();
            }
            return appManager;
        }

        private ApplicationManager()
        {
            driver = new ChromeDriver(@"D:\Projects\AutomationMentoring\NunitTasks\TestsNunit\SeleniumWiki\bin\Debug");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(@"https://www.wikipedia.org/");
            PageInitialization(this);
        }

        public IWebDriver Driver
        {
            get { return driver; }
        }

        public void Quit()
        {
            driver.Quit();
        }

        private void PageInitialization(ApplicationManager app)
        {
            mainPage = new MainPage(app);
        }

        public MainPage MainPage 
        {
            get { return mainPage; }
        }

        public void WaitForElementByClassName(string className)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until<IWebElement>(d=>d.FindElement(By.ClassName(className)));
        }

        public void Sleep()
        {
            System.Threading.Thread.Sleep(1000);
        }
       
    }
}
