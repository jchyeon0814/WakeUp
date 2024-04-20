using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace wakeUp.Service
{
    class YoutubeService
    {
        public List<Dictionary<string, string>> GetSubscribedList()
        {
            //Process.Start("C:\\Users\\ss\\Documents\\MyProgram\\c#\\wakeUp\\wakeUp\\ChromeTemp\\chrome.lnk");

            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            var driverService = ChromeDriverService.CreateDefaultService(".\\");
            driverService.HideCommandPromptWindow = true; //크롬 콘솔창 숨기기 
            var options = new ChromeOptions();
            
            options.DebuggerAddress = "127.0.0.1:9222";
            options.AddArgument("--window-position=-32000,-32000");
            options.AddArgument("headless");

            using (ChromeDriver driver = new ChromeDriver(driverService, options))
            {
                for (int times = 0; ; times++)
                {
                    driver.Url = "https://www.youtube.com";
                    
                    var subscriberContainer = driver.FindElements(By.ClassName("style-scope ytd-guide-renderer"));
                    
                    foreach (var container in subscriberContainer)
                    {
                        var subscriberHeader = container.FindElement(By.ClassName("style-scope ytd-guide-section-renderer"));
                        if (subscriberHeader.Text == "구독")
                        {

                            var subscriberList = subscriberHeader.FindElements(By.Id("endpoint"));
                            foreach(var subscriber in subscriberList)
                            {
                                Console.WriteLine(subscriber.Text);
                            }
                            
                            break;
                        }
                    }
                }
            }

            return list;
        }
    }
}
