using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace League.Com.Pages
{
    public class TeamsStandingsPage
    {
        readonly IWebDriver _driver;

        public readonly TeamsStandingsPageMap Map;

        public TeamsStandingsPage(IWebDriver driver)
        {
            _driver = driver;
            Map = new TeamsStandingsPageMap(driver);
        }

        public void GoTo()
        {
            Map.TeamsStandingsTab.Click();
        }

        public IWebElement GetRowByName(string teamName)
        {
            IWebElement teamRow = null;

            foreach (var row in Map.Rows)
            {
                var rank = row.FindElement(By.CssSelector(".rank"));
                var record = row.FindElement(By.CssSelector(".record"));
                var name = row.FindElement(By.CssSelector(".team-name"));

                if (teamName == name.Text)
                {
                    teamRow = row;
                }
            }

            return teamRow;
        }

        public IWebElement GetNameOfRowByIndex(int index)
        {
            var name = Map.Rows[index].FindElement(By.CssSelector(".team-name"));
            return name;
        }
    }

    public class TeamsStandingsPageMap
    {
        readonly IWebDriver _driver;

        public TeamsStandingsPageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        // row is ".team-row"

        public IList<IWebElement> Rows => _driver.FindElements(By.CssSelector(".team-row"));
        public IWebElement TeamsStandingsTab => _driver.FindElement(By.XPath("//a[@class=active ember - view active]"));
        public IWebElement Rank => Rows[0].FindElement(By.XPath(""));
        public IWebElement TeamName => _driver.FindElement(By.XPath(""));
        public IWebElement TeamRecord => _driver.FindElement(By.XPath(""));
    }
}
