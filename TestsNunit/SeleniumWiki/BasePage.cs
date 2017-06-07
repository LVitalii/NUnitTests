using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumWiki
{
    public class BasePage
    {
        protected ApplicationManager appManager;
        protected IWebDriver driver;

        public BasePage(ApplicationManager manager)
        {
            this.appManager= manager;
            this.driver = manager.Driver;
            PageFactory.InitElements(this.driver, this);
        }
    }
}
