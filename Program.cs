using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ReLoginV1
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = "5555@bk.ru", pass = "Password51";
            Console.WriteLine("1: by \n\r2: com");
            //string n = Console.ReadLine();
            //if (n == "1")
            //{
            //    email = "iiin9@yandex.by";
            //}
            //else
            //{
            //    if (n == "2")
            //    {
            //        email = "iiin9@yandex.com";
            //    }
            //    else { Console.WriteLine("Wrong answer");
            //        Console.ReadKey();
            //    }
            //}
            ChromeDriver chromeDriver = new ChromeDriver();
            chromeDriver.Navigate().GoToUrl("https://youdo.com/?ReturnUrl=https%3A%2F%2Fm.youdo.com%2F");
            Auth(chromeDriver, "login", email);
            Auth(chromeDriver, "password", pass);
            Click(chromeDriver, ".smartform_submit", "войти");
            Thread.Sleep(500);
            chromeDriver.Navigate().GoToUrl("https://youdo.com/profile/settings");
            Click(chromeDriver, ".close___f8820", "");
            Thread.Sleep(500);
            chromeDriver.FindElement(By.Id("BtnDeleteProfile")).Click();

            chromeDriver.FindElement(By.CssSelector(".dialog-alert__btn .i-confirm .js-confirm-btn")).Click();
            // Click(chromeDriver, "js-confirm-btn", "удалить");  


        }

        private static void Auth(ChromeDriver chromeDriver, string value1, string value2)
        {
            List<IWebElement> webElements = (from item in chromeDriver.FindElementsByName(value1) where item.Displayed select item).ToList();
            if (!webElements.Any())
                return;
            webElements[0].SendKeys(value2);
        }
        private static void Click( ChromeDriver chromeDriver, string Value1, string Value2)
        {
            List<IWebElement> webElements = chromeDriver.FindElementsByCssSelector(Value1).ToList();
            foreach (IWebElement item in webElements)
            {
                if (!item.Displayed)
                {
                    continue;
                }
                if (!item.Text.ToLower().Equals(Value2))
                {
                    continue;
                }
                item.Click();
                break;
            }
        }
    }
}
