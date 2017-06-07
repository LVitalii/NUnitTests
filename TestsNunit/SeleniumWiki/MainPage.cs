using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;


namespace SeleniumWiki
{
    public class MainPage : BasePage
    {
        public MainPage(ApplicationManager manager) : base(manager) { }

        [FindsBy(How = How.CssSelector, Using = ".central-featured-lang strong")]
        public IList<IWebElement> langsLinks;

        [FindsBy(How = How.Id, Using = "searchInput")]
        public IWebElement txtSearch;

        [FindsBy(How = How.ClassName, Using = "suggestion-highlight")]
        public IList<IWebElement> listOfSearches;

        public string PageTitle()
        {
            return driver.Title;
        }

        public bool IsLangIsShown(string lang)
        { 
            foreach(IWebElement langLink in langsLinks)
            {
                if (langLink.Text.Contains(lang))
                {
                    return true;
                }                
            }
            return false;
        }

        public void EnterSearchWord(string searchWord)
        {
            //works in this consequent of steps
            txtSearch.Clear();
            txtSearch.SendKeys(searchWord);
            appManager.Sleep();
            txtSearch.Clear();
            txtSearch.SendKeys(searchWord);
            //end of action
        }

        public bool IsSearchedWordInAllItems(string searchWord)
        {
            EnterSearchWord(searchWord);
            
            foreach (IWebElement element in listOfSearches)
            {
                if(!element.Text.ToLower().Contains(searchWord))
                {
                    return false;
                }
            }
            return true;
        }

        
        public bool IsListOfSearchesFull(string searchWord)
        {
            EnterSearchWord(searchWord);
            appManager.WaitForElementByClassName("suggestion-highlight");
            return (driver.FindElements(By.ClassName("suggestion-highlight")).Count>0);
        }

    }
}
