using Microsoft.Web.WebView2.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Threading;
using System.Windows.Forms;
using wakeUp.Service;

namespace wakeUp
{
    public partial class Form1 : Form
    {
        private BlackForm[] blackForms;

        private const int MAX_SEARCH_COUNT = 20;

        private class YoutubeVideo
        {
            public string url;
            public string title;
        }

        public Form1()
        {
            InitializeComponent();

            autoStartTimer.Start();
            //autoStartTimer_Tick(null, null);

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenBlackForm();

            autoStartTimer_Tick(null, null);
        }

        private void BlackForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            BlackForm form = sender as BlackForm;
            form.CloseFullScreen();
        }

        private void autoStartTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!BlackForm.IsUseTimer())
                {
                    return;
                }
                
                string curTime = DateTime.Now.ToString("HHmm");

                if (curTime == "2300")
                {
                    OpenBlackForm();
                }
                else if (curTime == "0000")
                {
                    TaskKill("chrome");
                }
                else if (curTime == "0100")
                {
                    TaskKill("chrome");
                }
                else if (curTime == "0200")
                {
                    TaskKill("chrome");
                }
                else if (curTime == "0300")
                {
                    TaskKill("chrome");
                }
                else if (curTime == "0400")
                {
                    TaskKill("chrome");
                }
                else if (curTime == "0430")
                {
                    TaskKill("chrome");

                    new Thread(() =>
                    {
                        try
                        {
                            YoutubeVideo[] melonVideos = this.GetPlayListVideo("https://www.youtube.com/@chartdoong2/videos");
                            StartVideoPlay(melonVideos[0]);
                        }
                        catch(Exception ex)
                        {
                            Util.WriteLogFile(ex);

                            try
                            {
                                ShowMessageBox(ex.Message);
                            }
                            catch(Exception ex2)
                            {
                                Util.WriteLogFile(ex2);
                            }
                        }
                    }).Start();
                }
                else if (curTime == "0530")
                {
                    TaskKill("chrome");

                    new Thread(() =>
                    {
                        try
                        {
                            YoutubeVideo[] popVideos = GetRealTimeVideo("https://www.youtube.com/@Cold_Water/streams", "");
                            StartRandomVideoPlay(popVideos);
                        }
                        catch (Exception ex)
                        {
                            Util.WriteLogFile(ex);

                            ShowMessageBox(ex.Message);
                        }
                    }).Start();
                }
                else if (curTime == "0600")
                {
                    TaskKill("chrome");

                    new Thread(() =>
                    {
                        try {
                            YoutubeVideo[] newsVideos = GetRealTimeVideo("https://www.youtube.com/@newskbs/streams", "광장|어디서나");
                            StartVideoPlayFilteredByTitle(newsVideos, "");
                        }
                        catch (Exception ex)
                        {
                            Util.WriteLogFile(ex);

                            ShowMessageBox(ex.Message);
                        }
                    }).Start();
                }
                else if (curTime == "0700")
                {
                    TaskKill("chrome");

                    new Thread(() =>
                    {
                        try
                        {
                            YoutubeVideo[] popVideos = GetRealTimeVideo("https://www.youtube.com/@Cold_Water/streams", "");
                            StartRandomVideoPlay(popVideos);
                        }
                        catch (Exception ex)
                        {
                            Util.WriteLogFile(ex);

                            ShowMessageBox(ex.Message);
                        }
                    }).Start();
                }
                else if (curTime == "0820")
                {
                    TaskKill("KakaoTalk");

                    TaskKill("chrome");
                }
            }
            catch (Exception ex)
            {
                Util.WriteLogFile(ex);
            }
        }

        private YoutubeVideo[] GetRealTimeVideo(string homeUrl, string keyword)
        {
            var driverService = ChromeDriverService.CreateDefaultService(".\\");
            driverService.HideCommandPromptWindow = true; //크롬 콘솔창 숨기기 
            var options = new ChromeOptions();
            options.AddArgument("--window-position=-32000,-32000");
            options.AddArgument("headless");

            using (ChromeDriver driver = new ChromeDriver(driverService, options))
            {
                driver.Url = homeUrl;

                var contentsContainers = driver.FindElements(By.TagName("ytd-rich-grid-media"));

                List<YoutubeVideo> list = new List<YoutubeVideo>();

                for (int time = 0; time < 10; time++)
                {
                    for (int i = 0; i < contentsContainers.Count && i < MAX_SEARCH_COUNT; i++)
                    {
                        try
                        {
                            var contentsContainer = contentsContainers[i];


                            var thumbnails = contentsContainer.FindElements(By.Id("thumbnail"));
                            if (thumbnails.Count <= 0)
                            {
                                continue;
                            }


                            var liveIconElements = thumbnails[0].FindElements(By.TagName("ytd-thumbnail-overlay-time-status-renderer"));
                            if (liveIconElements.Count > 0 && liveIconElements[0].GetAttribute("overlay-style") == "LIVE")
                            {
                                string title = contentsContainer.FindElements(By.Id("video-title"))[0].Text;

                                if(!string.IsNullOrEmpty(keyword))
                                {
                                    bool isContinue = true;
                                    string[] keys = keyword.Split('|');
                                    foreach (string word in keys)
                                    {
                                        if (title.Contains(word))
                                        {
                                            isContinue = false;
                                            break;
                                        }
                                    }

                                    if(isContinue)
                                    {
                                        continue;
                                    }
                                }

                                foreach (var thumbnail in thumbnails)
                                {
                                    string url = thumbnail.GetAttribute("href");

                                    if (url != null && url.Contains("https://www.youtube.com/watch"))
                                    {
                                        YoutubeVideo youtubeVideo = new YoutubeVideo();
                                        youtubeVideo.url = url;
                                        youtubeVideo.title = title;
                                        list.Add(youtubeVideo);
                                        break;
                                    }
                                }
                            }
                        }
                        catch (NoSuchElementException)
                        {
                            continue;
                        }
                    }

                    if (list.Count > 0)
                    {
                        break;
                    }
                    else
                    {
                        Thread.Sleep(1000 * 30);
                    }
                }

                return list.ToArray();
            }
        }

        private YoutubeVideo[] GetPlayListVideo(string homeUrl)
        {
            var driverService = ChromeDriverService.CreateDefaultService(".\\");
            driverService.HideCommandPromptWindow = true; //크롬 콘솔창 숨기기 
            var options = new ChromeOptions();
            options.AddArgument("--window-position=-32000,-32000");
            options.AddArgument("headless");

            using (ChromeDriver driver = new ChromeDriver(driverService, options))
            {
                driver.Url = homeUrl;

                var contentsContainers = driver.FindElements(By.TagName("ytd-rich-grid-media"));

                List<YoutubeVideo> list = new List<YoutubeVideo>();

                for (int i = 0; i < contentsContainers.Count && i < MAX_SEARCH_COUNT; i++)
                {
                    try
                    {
                        var contentsContainer = contentsContainers[i];

                        var thumbnails = contentsContainer.FindElements(By.Id("thumbnail"));
                        if (thumbnails.Count <= 0)
                        {
                            continue;
                        }

                        string title = contentsContainer.FindElements(By.Id("video-title"))[0].Text;
                        
                        foreach (var thumbnail in thumbnails)
                        {
                            string url = thumbnail.GetAttribute("href");

                            if (url != null && url.Contains("https://www.youtube.com/watch"))
                            {
                                YoutubeVideo youtubeVideo = new YoutubeVideo();
                                youtubeVideo.url = url;
                                youtubeVideo.title = title;
                                list.Add(youtubeVideo);
                                break;
                            }
                        }
                    }
                    catch (NoSuchElementException)
                    {
                        continue;
                    }
                }

                return list.ToArray();
            }
        }

        private void StartRandomVideoPlay(YoutubeVideo[] vidoes)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            int index = random.Next(vidoes.Length);

            Process.Start("chrome.exe");
            Process.Start(vidoes[index].url);
        }

        private void StartVideoPlayFilteredByTitle(YoutubeVideo[] vidoes, string keyword)
        {
            if (vidoes.Length > 0)
            {
                for (int i = 0; i < vidoes.Length; i++)
                {
                    if (string.IsNullOrEmpty(keyword) || vidoes[i].title.Contains(keyword))
                    {
                        Process.Start("chrome.exe");
                        Process.Start(vidoes[i].url);
                        break;
                    }
                }
            }
        }

        private void StartVideoPlay(YoutubeVideo vidoe)
        {
            Process.Start("chrome.exe");
            Process.Start(vidoe.url);
        }

        private void OpenBlackForm()
        {
            CloseAllBlackForm();

            blackForms = new BlackForm[Screen.AllScreens.Length];

            for (int i = 0; i < blackForms.Length; i++)
            {
                Point location = Screen.AllScreens[i].Bounds.Location;
                blackForms[i] = new BlackForm();
                blackForms[i].MouseDoubleClick += new MouseEventHandler(BlackForm_MouseDoubleClick);
                blackForms[i].ShowFullScreen(location);
                blackForms[i].Focus();
            }
        }

        private void CloseAllBlackForm()
        {
            
            if (blackForms == null)
            {
                return;
            }

            try
            {
                foreach (BlackForm blackForm in blackForms)
                {
                    blackForm.CloseFullScreen();
                }
            }
            catch { }
        }

        private void ShowMessageBox(string message)
        {
            if(this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show(new Form { TopMost = true }, message);
                });
            }
            else
            {
                MessageBox.Show(new Form { TopMost = true }, message);
            }
        }

        private void TaskKill(string task)
        {
            Process[] processList = Process.GetProcessesByName(task);
            for (int i = 0; i < processList.Length; i++)
            {
                processList[i].Kill();
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                TaskKill("chromedriver");

                this.Close();
            }
        }
    }
}
