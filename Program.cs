using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using wakeUp.Service;

namespace wakeUp
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            TaskKillExceptCurrentProcess(Process.GetCurrentProcess().ProcessName + ".exe");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //YoutubeService service = new YoutubeService();
            //service.GetSubscribedList();
            Application.Run(new MainForm());

            //Application.Run(new BrowserForm());
        }

        private static void TaskKillExceptCurrentProcess(string processName)
        {
            int currentProcessId = Process.GetCurrentProcess().Id;

            // 모든 동일한 이름의 프로세스를 검색
            Process[] processes = Process.GetProcessesByName(processName.Replace(".exe", ""));

            foreach (Process process in processes)
            {
                // 본인 프로세스를 제외하고 종료
                if (process.Id != currentProcessId)
                {
                    try
                    {
                        Process.Start("taskkill", $"/PID {process.Id} /F");
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }
    }
}
