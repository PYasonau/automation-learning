using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Pages
{
    public class NBCHeader
    {
        public static string lnkShows = "a[href='/shows']";
        public static string lnkEpisodes = "a[href='/video']";
        public static string lnkSchedule = "a[href='/schedule']";
        public static string lnkNewsSports = "//*[contains(text(), 'Sports')]/.."; //XPath locator
        public static string lnkShop = "a[href$='shop']"; //ends with shop
        public static string lnkApp = "a[href='/apps']";
        public static string btnSearch = "[class$='search'] button";
    }
}
