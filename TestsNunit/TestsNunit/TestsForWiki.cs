using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumWiki;
using NUnit.Framework;

namespace TestsNunit
{
    [TestFixture]
    public class TestsForWiki
    {
        public ApplicationManager appManager;

        [TestFixtureSetUp]
        public void Init()
        {
            appManager = ApplicationManager.GetInstance();
        }

        [TestFixtureTearDown]
        public void Down()
        {
            appManager.Quit();
        }

        [Test]
        public void FirsrPageIsOpened()
        {
            string pageName = "Wikipedia";
            Assert.That(appManager.MainPage.PageTitle(), Is.EqualTo(pageName));
        }

        [Test]
        public void LangIsShown()
        {
            //string language = "Українська"; //main page of wiki does not contain it
            string language = "English";
            Assert.That(appManager.MainPage.IsLangIsShown(language), Is.True);
        }

        [Test]
        public void SearchListIsOpened()
        {
            string searchWord = "animal";
            Assert.That(appManager.MainPage.IsListOfSearchesFull(searchWord), Is.True);
        }

        [Test]
        public void SearchListItemsContainSearchWord()
        {
            string searchWord = "animal";
            Assert.That(appManager.MainPage.IsSearchedWordInAllItems(searchWord), Is.True);
        }        
    }
}
