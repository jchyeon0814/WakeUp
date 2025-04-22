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
using wakeUp.Model;
using wakeUp.Service;
using System.Data.SQLite;
using static System.Net.WebRequestMethods;
using System.Runtime.InteropServices;

namespace wakeUp
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        static extern void SwitchToThisWindow(IntPtr hWnd, bool turnOn);

        [DllImport("user32.dll")]
        static extern bool AllowSetForegroundWindow(uint dwProcessId);

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);


        const int SW_RESTORE = 9;

        private const uint MOUSEEVENTF_MOVE = 0x0001;

        const uint MOUSEEVENTF_LEFTDOWN = 0x0002;

        const uint MOUSEEVENTF_LEFTUP = 0x0004;

        const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;

        const uint MOUSEEVENTF_RIGHTUP = 0x0010;

        private BlackForm[] blackForms;

        private const int MAX_SEARCH_COUNT = 40;

        private const string CHROMEDRIVER_PATH = @"C:\Program Files\chromedrivers\";

        private class YoutubeVideo
        {
            public string url;
            public string title;
        }

        private YoutubeTimeTable[] yTimeTables;

        private YoutubeTimeTableModel youtubeTimeTableModel;

        public MainForm()
        {
            InitializeComponent();

            InitData();

            //OpenBlackForm();

            int curHour = Int32.Parse(DateTime.Now.ToString("HH"));

            if (curHour >= 5 && curHour <= 23)
            {
                ShowWhether();
            }

            autoStartTimer_Tick(null, null);

            autoStartTimer.Start();
        }

        public void InitData()
        {
            youtubeTimeTableModel = YoutubeTimeTableModel.GetSingletonInstance();

            yTimeTables = youtubeTimeTableModel.Select().ToArray();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenBlackForm();

            int curHour = Int32.Parse(DateTime.Now.ToString("HH"));

            if(curHour >= 5 && curHour <= 23)
            {
                ShowWhether();
            }

            autoStartTimer_Tick(null, null);
        }

        private void BlackForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            BlackForm form = sender as BlackForm;
            form.CloseFullScreen();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TaskKill("chromedriver.exe");

                this.Close();
            }
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
                
                if (Util.IsSunday(DateTime.Today))
                {
                    return;
                }
                else if(Util.IsSaturday(DateTime.Today))
                {

                }
                else
                {
                    if (curTime == "0500")
                    {
                        OpenBlackForm();
                        ShowWhether();
                    }

                    yTimeTables = youtubeTimeTableModel.Select().ToArray();

                    SchedulingTimeTable(yTimeTables, curTime);
                }
            }
            catch (Exception ex)
            {
                Util.WriteLogFile(ex);
            }
        }

        private void SchedulingTimeTable(YoutubeTimeTable[] youtubeTimeTables, string hhmm)
        {
            foreach (YoutubeTimeTable timeTable in youtubeTimeTables)
            {
                if (timeTable.GetStartTime() != hhmm && timeTable.GetStartTime() != "9999")
                {
                    continue;
                }

                WakeUpScreen();

                TaskKill("msedge.exe");
                TaskKill("msedgewebview2.exe");

                YoutubeTimeTable.ExecuteMode mode = timeTable.GetExecuteMode();

                switch (mode)
                {
                    case YoutubeTimeTable.ExecuteMode.RECENTLY:
                        {
                            new Thread(() =>
                            {
                                try
                                {
                                    string playUrl = $@"https://www.youtube.com/@{timeTable.GetChannel()}/videos";

                                    YoutubeVideo[] melonVideos = GetPlayListVideo(playUrl);
                                    StartVideoPlay(melonVideos[0]);
                                }
                                catch (Exception ex)
                                {
                                    Util.WriteLogFile(ex);

                                    try
                                    {
                                        ShowMessageBox(ex.Message);
                                    }
                                    catch (Exception ex2)
                                    {
                                        Util.WriteLogFile(ex2);
                                    }
                                }
                            }).Start();
                        }
                        break;

                    case YoutubeTimeTable.ExecuteMode.REALTIME:
                        {
                            new Thread(() =>
                            {
                                try
                                {
                                    string playUrl = $@"https://www.youtube.com/@{timeTable.GetChannel()}/streams";

                                    PlayRealTimeVideo(playUrl, timeTable.GetTitleKeyword());
                                }
                                catch (Exception ex)
                                {
                                    Util.WriteLogFile(ex);

                                    ShowMessageBox(ex.Message);
                                }
                            }).Start();
                        }
                        break;

                    case YoutubeTimeTable.ExecuteMode.RECORD_RANDOM:
                        {
                            new Thread(() =>
                            {
                                try
                                {
                                    string playUrl = $@"https://www.youtube.com/@{timeTable.GetChannel()}/videos";

                                    PlayRecordVideo(playUrl);
                                }
                                catch (Exception ex)
                                {
                                    Util.WriteLogFile(ex);

                                    try
                                    {
                                        ShowMessageBox(ex.Message);
                                    }
                                    catch (Exception ex2)
                                    {
                                        Util.WriteLogFile(ex2);
                                    }
                                }
                            }).Start();
                        }
                        break;

                    case YoutubeTimeTable.ExecuteMode.NONE:
                        break;
                }
            }
        }

        private void PlayRealTimeVideo(string playUrl, string keyword, int intervalMin)
        {
            YoutubeVideo[] videos = GetRealTimeVideo(playUrl, keyword);
            StartRandomVideoPlay(videos);
        }

        private void PlayRecordVideo(string playUrl, int intervalMin)
        {
            YoutubeVideo[] videos = GetPlayListVideo(playUrl);
            StartRandomVideoPlay(videos);
        }

        private void PlayRealTimeVideo(string playUrl, string keyword)
        {
            YoutubeVideo[] videos = GetRealTimeVideo(playUrl, keyword);
            StartRandomVideoPlay(videos);
        }

        private void PlayRecordVideo(string playUrl)
        {
            YoutubeVideo[] videos = GetPlayListVideo(playUrl);
            StartRandomVideoPlay(videos);
        }

        private YoutubeVideo[] GetRealTimeVideo(string homeUrl, string keyword)
        {
            var driverService = ChromeDriverService.CreateDefaultService(CHROMEDRIVER_PATH);
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
                            if (thumbnails.Count == 0)
                            {
                                continue;
                            }


                            var liveIconElements = thumbnails[0].FindElements(By.TagName("ytd-thumbnail-overlay-time-status-renderer"));
                            if (liveIconElements.Count > 0 && liveIconElements[0].GetAttribute("overlay-style") == "LIVE")
                            {
                                if(contentsContainer.FindElements(By.Id("video-title")).Count == 0)
                                {
                                    continue;
                                }

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
                        catch (StaleElementReferenceException e)
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

        private YoutubeVideo[] GetRealTimeVideo(string homeUrl)
        {
            return GetRealTimeVideo(homeUrl, null);
        }

        private YoutubeVideo[] GetPlayListVideo(string homeUrl)
        {
            var driverService = ChromeDriverService.CreateDefaultService(CHROMEDRIVER_PATH);
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
                        catch (StaleElementReferenceException e)
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

        private void StartRandomVideoPlay(YoutubeVideo[] videos)
        {
            if(videos == null || videos.Length == 0)
            {
                return;
            }

            Random random = new Random(DateTime.Now.Millisecond);
            int index = random.Next(videos.Length);
            
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe",
                Arguments = "--app=\"" + videos[index].url + "\"",
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                Verb = "runas"
            };

            // 프로세스 시작
            Process process = new Process
            {
                StartInfo = startInfo
            };

            process.Start();

            try
            {
                SetForegroundWindow(process.MainWindowHandle);
            }
            catch (Exception ex)
            {

            }

            //try
            //{
            //    while (process.MainWindowHandle == IntPtr.Zero)
            //    {
            //        Thread.Sleep(100); // 짧은 시간 대기 후 반복

            //        process.Refresh(); // 프로세스 정보를 갱신
            //    }
            //}
            //catch (Exception ex)
            //{
                
            //}
        }

        private void StartVideoPlay(YoutubeVideo video)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe",
                Arguments = "--app=\"" + video.url + "\"",
                UseShellExecute = true,
                //CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Normal,
                Verb = "runas"
            };


            Thread.Sleep(500);  // 약간 대기

            // 프로세스 시작
            var process = Process.Start(startInfo);
            if (process == null)
            {
                Thread.Sleep(5000);

                process = Process.Start(startInfo);
            }

            try
            {
                Thread.Sleep(1000);

                try
                {
                    process.WaitForInputIdle();
                }
                catch (InvalidOperationException)
                {

                }

                // 주기적으로 포커스 상태 확인
                for (int i = 0; i < 30; i++) // 예: 10번 체크
                {
                    process.Refresh();

                    IntPtr browserHandle = process.MainWindowHandle;
                    IntPtr foregroundHandle = GetForegroundWindow();

                    if (browserHandle != IntPtr.Zero && browserHandle != foregroundHandle)
                    {
                        ShowWindow(browserHandle, SW_RESTORE);
                        Thread.Sleep(500);
                        AllowSetForegroundWindow((uint)process.Id);
                        Thread.Sleep(500);
                        SetForegroundWindow(browserHandle); // 창 다시 활성화
                    }
                    else if (browserHandle != IntPtr.Zero)
                    {
                        ShowWindow(browserHandle, SW_RESTORE);
                        Thread.Sleep(500);
                        AllowSetForegroundWindow((uint)process.Id);

                        break;
                    }

                    Thread.Sleep(1000); // 1초 간격으로 체크
                }
            }
            catch (Exception ex)
            {

            }


            //try
            //{
            //    while (process.MainWindowHandle == IntPtr.Zero)
            //    {
            //        Thread.Sleep(100); // 짧은 시간 대기 후 반복

            //        process.Refresh(); // 프로세스 정보를 갱신
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
        }

        private void ShowWhether()
        {
            if(blackForms == null)
            {
                return;
            }

            for (int i = 0; i < blackForms.Length; i++)
            {
                if(blackForms[i] == null)
                {
                    continue;
                }

                blackForms[i].SetShowWhether(true);
            }
        }

        private void OpenBlackForm()
        {
            CloseAllBlackForm();

            blackForms = new BlackForm[1];

            Point location = Screen.PrimaryScreen.Bounds.Location;
            blackForms[0] = new BlackForm(this);
            blackForms[0].MouseDoubleClick += new MouseEventHandler(BlackForm_MouseDoubleClick);
            blackForms[0].ShowFullScreen(location);
            blackForms[0].Focus();
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

        private void WakeUpScreen()
        {
            
            MoveMouse();
            Thread.Sleep(1000);

            ClickAt(0, 1405); //왼쪽 모니터 왼쪽 하단 작업표시줄 위치
        }

        private void MoveMouse()
        {
            mouse_event(MOUSEEVENTF_MOVE, 100, 0, 0, UIntPtr.Zero);
            mouse_event(MOUSEEVENTF_MOVE, unchecked((uint)-1), 0, 0, UIntPtr.Zero);
        }

        private void RightClickMouse()
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, UIntPtr.Zero);
            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, UIntPtr.Zero);
        }

        private void ShowMessageBox(string message)
        {
            if(this.InvokeRequired)
            {
                this.Invoke((MethodInvoker) delegate
                {
                    MessageBox.Show(new Form { TopMost = true }, message);
                });
            }
            else
            {
                MessageBox.Show(new Form { TopMost = true }, message);
            }
        }

        private void TaskKill(string processName)
        {
            try
            {
                // 동일한 이름을 가진 모든 프로세스를 가져옵니다.
                while (true)
                {
                    Process[] processes = Process.GetProcessesByName(processName.Replace(".exe", ""));
                    if (processes.Length == 0)
                    {
                        Util.WriteLogFile($"No instances of {processName} are currently running.");
                        return;
                    }

                    ProcessStartInfo processStartInfo = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = $"/C taskkill /F /IM {processName} /T",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden,
                        Verb = "runas" // 관리자 권한으로 실행
                    };

                    using (Process cmdProcess = Process.Start(processStartInfo))
                    {
                        cmdProcess.WaitForExit();
                        if (cmdProcess.ExitCode != 0)
                        {
                            throw new Exception($"Failed to terminate {processName}. Exit code: {cmdProcess.ExitCode}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Util.WriteLogFile($"An error occurred: {ex.Message}");
            }
        }

        private void CmdDisplayOn()
        {
            CommandExe("C:\\Program Files\\MonitorProfileSwitcher\\MonitorSwitcher.exe", "-load:\"C:\\Program Files\\MonitorProfileSwitcher\\On.xml\"", true);
        }

        private void CmdDisplayOff()
        {
            CommandExe(@"C:\Program Files\MonitorProfileSwitcher\MonitorSwitcher.exe", "-load:\"C:\\Program Files\\MonitorProfileSwitcher\\Off.xml\"", true);
        }

        private void CommandExe(string fileName, string arguments, bool isWait)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                Verb = "runas"
            };

            if (isWait)
            {
                using (Process cmdProcess = Process.Start(processStartInfo))
                {
                    cmdProcess.WaitForExit();
                }
            }
            else
            {
                Process.Start(processStartInfo);
            }
        }

        private void CommandExe(string fileName, string arguments)
        {
            CommandExe(fileName, arguments, false);
        }

        public static void ClickAt(int x, int y)
        {
            SetCursorPos(x, y);
            Thread.Sleep(100); // 커서 이동 후 잠깐 대기

            mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)x, (uint)y, 0, UIntPtr.Zero);
            Thread.Sleep(50);
            mouse_event(MOUSEEVENTF_LEFTUP, (uint)x, (uint)y, 0, UIntPtr.Zero);
        }

    }
}
